using System;

namespace JFrogTFSPlugin.Library.Utils
{
    internal class ArtifactoryHttpClient :IDisposable
    {
        private string _artifactoryUrl;
        private string _password;
        private string _username;

        private PreemptiveHttpClient deployClient;

        public ArtifactoryHttpClient(string artifactoryUrl, string username, string password)
        {
            _artifactoryUrl = artifactoryUrl;
            _username = username;
            _password = password;
        }

        public PreemptiveHttpClient getHttpClient()
        {
            if (deployClient == null)
            {
                PreemptiveHttpClient client = new PreemptiveHttpClient(_username, _password);
                deployClient = client;
            }

            return deployClient;
        }

        public void Dispose()
        {
            if (deployClient != null)
            {
                deployClient.Dispose();
            }
        }
    }
}