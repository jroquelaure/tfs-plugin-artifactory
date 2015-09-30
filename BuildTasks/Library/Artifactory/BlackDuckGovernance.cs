using System.Collections.Generic;

namespace JFrogTFSPlugin.Library.Artifactory
{
    public class BlackDuckGovernance
    {
        public string runChecks { get; set; }
        public string appName { get; set; }
        public string appVersion { get; set; }
        public string autoCreateMissingComponentRequests { get; set; }
        public string autoDiscardStaleComponentRequests { get; set; }
        public string includePublishedArtifacts { get; set; }
        public List<string> reportRecipients { get; set; }
        public List<string> scopes { get; set; }
    }
}