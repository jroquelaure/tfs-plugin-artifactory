using System.Collections.Generic;
using System.Net;
using System.Text;

namespace JFrogTFSPlugin.Library.Artifactory
{
    class Build
    {
        public readonly static string STARTED_FORMAT = "{0}";//.000+0000";

        /// <summary>
        /// build/assembly  version
        /// </summary>
        public string version { get { return "1.0.1"; } }
        /// <summary>
        /// project name
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// build number
        /// </summary>
        public string number { get; set; }

        public string type { get; set; }
        public Agent agent { get; set; }

        /// <summary>
        /// Build start time
        /// </summary>
        public string started { get; set; }
        /// <summary>
        /// Build start time
        /// </summary>
        public string startedDateMillis { get; set; }
        /// <summary>
        /// Build duration in millis
        /// </summary>
        public long durationMillis { get; set; }
        /// <summary>
        /// The user who executed the build (TFS user or system user)
        /// </summary>
        public string principal { get; set; }
        /// <summary>
        /// The artifactory user used for deploythe build’s artifacts
        /// </summary>
        public string artifactoryPrincipal { get; set; }

        /// <summary>
        /// build url in the build server
        /// </summary>
        public string url { get; set; }

        /// <summary>
        /// system variables
        /// </summary>
        public IDictionary<string, string> properties { get; set; }

        /// <summary>
        /// Version control revision (Changeset number in TFS)
        /// </summary>
        public string vcsRevision { get; set; }

        public LicenseControl licenseControl { get; set; }

        public BlackDuckGovernance blackDuckGovernance { get; set; }

        public BuildRetention buildRetention { get; set; }

        /// <summary>
        /// A list of one or more modules produced by this build
        /// </summary>
        public List<Module> modules { get; set; }

        public Dictionary<string, string> GetDefaultProperties()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            result.Add("build.name", name);
            result.Add("build.number", number);
            result.Add("build.timestamp", startedDateMillis);
            result.Add("vcs.revision", vcsRevision);

            return result;
        }

        /// <summary>
        /// Preparing the properties (Matrix params) to suitable Url Query 
        /// </summary>
        /// <param name="matrixParam"></param>
        /// <returns></returns>
        public static string buildMatrixParamsString(List<KeyValuePair<string, string>> matrixParam)
        {
            StringBuilder matrix = new StringBuilder();

            if (matrixParam != null)
            {
                matrixParam.ForEach(
                            pair => matrix.Append(";").Append(WebUtility.UrlEncode(pair.Key)).Append("=").
                                    Append(WebUtility.UrlEncode(pair.Value))
                );
            }

            return matrix.ToString();
        }

       
    }
}
