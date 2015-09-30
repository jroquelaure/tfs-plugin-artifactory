using System.Collections.Generic;

namespace JFrogTFSPlugin.Library.Artifactory
{
    /// <summary>
    /// CI server name and version, for example TFS 2013
    /// </summary>
    //public class Agent
    //{
    //    public string name { get; set; }
    //    public string version { get; set; }
    //}

    public class LicenseControl
    {
        public string runChecks { get; set; }
        public string includePublishedArtifacts { get; set; }
        public string autoDiscover { get; set; }
        public List<string> licenseViolationsRecipients { get; set; }
        public List<string> scopes { get; set; }

    }
}