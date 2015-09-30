using System;
using System.Activities;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using JFrogTFSPlugin.CustomTypes;
using JFrogTFSPlugin.Library.ArtefactsHelpers;
using JFrogTFSPlugin.Library.Artifactory;
using JFrogTFSPlugin.Library.Utils;

namespace JFrogTFSPlugin.Library
{
    public class ArtefactsDeployer
    {
        private const string BUILD_REST_URL = "/api/build";
        private const string BUILD_BROWSE_URL = "/webapp/builds";
        private const int DEFAULT_CONNECTION_TIMEOUT_SECS = 300;

        /* Try checksum deploy of files greater than 10KB */
        private const int CHECKSUM_DEPLOY_MIN_FILE_SIZE = 10240;
        private ArtifactoryHttpClient _httpClient;
        private string _artifactoryUrl;
        private BuildInfoLog _log;

        public ArtefactsDeployer(string artifactoryUrl, string username, string password, ProxyConfiguration proxyConfiguration, int timeOut, CodeActivityContext context)
        {
            //Removing ending slash
            if ((!string.IsNullOrEmpty(artifactoryUrl)) && artifactoryUrl.EndsWith("/"))
            {
                artifactoryUrl = artifactoryUrl.Remove(artifactoryUrl.LastIndexOf('/'));
            }

            _httpClient = new ArtifactoryHttpClient(artifactoryUrl, username, password);
            _artifactoryUrl = artifactoryUrl;
            //TODO figure how to log and pass logger throught constructor
            _log = new BuildInfoLog(context);

            SetProxy(proxyConfiguration);
            SetConnectionTimeout(timeOut);
        }

        internal HashSet<Artifact> DeployArtefacts(IList<FileInfo> matchingArtifacts, string targetRepository, bool isFlatDeploy, string folderToDeploy, List<KeyValuePair<string, string>> propertiesList)
        {
            HashSet<Artifact> deployedArtifacts = new HashSet<Artifact>();
            foreach (var details in matchingArtifacts.ToDeployDetailsList(targetRepository))
            {

                details.properties = Build.buildMatrixParamsString(propertiesList);

                if (!isFlatDeploy)
                {
                    //when not set to flat deploy we preserve the folders hierarchy
                    details.artifactPath = string.Format(@"{0}\{1}", details.file.FullName.Replace(folderToDeploy, String.Empty).Replace(details.file.Name, String.Empty), details.artifactPath);
                }
                DeployArtefact(details);

                deployedArtifacts.Add(new Artifact
                {
                    type = details.file.Extension.Replace(".", String.Empty),
                    md5 = details.md5,
                    sha1 = details.sha1,
                    name = details.file.Name
                });

            }
            return deployedArtifacts;
        }

        public void SendBuildInfo(String buildInfoJson)
        {
            string url = _artifactoryUrl + BUILD_REST_URL;

            try
            {
                var bytes = Encoding.Default.GetBytes(buildInfoJson);
                {
                    //Custom headers
                    WebHeaderCollection headers = new WebHeaderCollection();
                    headers.Add(HttpRequestHeader.ContentType, "application/vnd.org.jfrog.build.BuildInfo+json");
                    _httpClient.getHttpClient().SetHeader(headers);

                    HttpResponse response = _httpClient.getHttpClient().Execute(url, "PUT", bytes);

                    //When sending build info, Expecting for NoContent (204) response from Artifactory 
                    if (response._statusCode != HttpStatusCode.NoContent)
                    {
                        throw new WebException("Failed to send build info:" + response._message);
                    }
                }
            }
            catch (Exception we)
            {
                _log.Error(we.Message, we);
                throw new WebException("Exception in Uploading BuildInfo: " + we.Message, we);
            }
        }

        #region PRIVATE METHODS


        private void SetProxy(ProxyConfiguration proxyConfiguration)
        {
            if (proxyConfiguration.Bypass)
                return;

            WebProxy proxy = new WebProxy(proxyConfiguration.Host, proxyConfiguration.Port);
            proxy.UseDefaultCredentials = false;
            if (proxyConfiguration.IsCredentialsExists)
            {
                proxy.Credentials = new NetworkCredential(proxyConfiguration.Username, proxyConfiguration.Password);
            }

            _httpClient.getHttpClient().SetProxy(proxy);
        }

        private void SetConnectionTimeout(int timeOutConfiguration)
        {
            _httpClient.getHttpClient()
                .SetConnectionTimeout(timeOutConfiguration == 0 ? DEFAULT_CONNECTION_TIMEOUT_SECS : timeOutConfiguration);
        }

        private void DeployArtefact(DeployDetails details)
        {
            string deploymentPath = _artifactoryUrl + "/" + details.targetRepository + "/" + details.artifactPath;
            _log.Info("Deploying artifact: " + deploymentPath);

            if (TryChecksumDeploy(details, _artifactoryUrl))
            {
                return;
            }

            //Custom headers
            WebHeaderCollection headers = createHttpPutMethod(details);
            headers.Add(HttpRequestHeader.ContentType, "binary/octet-stream");

            /*
                 * "100 (Continue)" status is to allow a client that is sending a request message with a request body to determine if the origin server is
                 *  willing to accept the request (based on the request headers) before the client sends the request body.
                 */
            //headers.Add("Expect", "100-continue");

            _httpClient.getHttpClient().SetHeader(headers);

            byte[] data = File.ReadAllBytes(details.file.FullName);


            /* Add properties to the artifact, if any */
            deploymentPath = deploymentPath + details.properties;

            HttpResponse response = _httpClient.getHttpClient().Execute(deploymentPath, "PUT", data);

            //When deploying artifact, Expecting for Created (201) response from Artifactory 
            if ((response._statusCode != HttpStatusCode.OK) && (response._statusCode != HttpStatusCode.Created))
            {
                _log.Error("Error occurred while publishing artifact to Artifactory: " + details.file);
                throw new WebException("Failed to deploy file:" + response._message);
            }
        }


        private bool TryChecksumDeploy(DeployDetails details, String uploadUrl)
        {
            // Try checksum deploy only on file size greater than CHECKSUM_DEPLOY_MIN_FILE_SIZE
            if (details.file.Length < CHECKSUM_DEPLOY_MIN_FILE_SIZE)
            {
                _log.Debug("Skipping checksum deploy of file size " + details.file.Length + " , falling back to regular deployment.");
                return false;
            }

            string checksumUrlPath = uploadUrl + "/" + details.targetRepository + "/" + details.artifactPath;

            /* Add properties to the artifact, if any */
            checksumUrlPath = checksumUrlPath + details.properties;

            WebHeaderCollection headers = createHttpPutMethod(details);
            headers.Add("X-Checksum-Deploy", "true");
            headers.Add(HttpRequestHeader.ContentType, "application/vnd.org.jfrog.artifactory.storage.ItemCreated+json");

            _httpClient.getHttpClient().SetHeader(headers);
            HttpResponse response = _httpClient.getHttpClient().Execute(checksumUrlPath, "PUT");

            //When sending Checksum deploy, Expecting for Created (201) or Success (200) responses from Artifactory 
            if (response._statusCode == HttpStatusCode.Created || response._statusCode == HttpStatusCode.OK)
            {

                _log.Debug(string.Format("Successfully performed checksum deploy of file {0} : {1}", details.file.FullName, details.sha1));
                return true;
            }
            else
            {
                _log.Debug(string.Format("Failed checksum deploy of checksum '{0}' with statusCode: {1}", details.sha1, response._statusCode));
            }

            return false;
        }

        /// <summary>
        /// Typical PUT header with Checksums, for deploying files to Artifactory 
        /// </summary>
        private WebHeaderCollection createHttpPutMethod(DeployDetails details)
        {
            WebHeaderCollection putHeaders = new WebHeaderCollection();
            putHeaders.Add("X-Checksum-Sha1", details.sha1);
            putHeaders.Add("X-Checksum-Md5", details.md5);

            return putHeaders;
        }

        #endregion
    }
}
