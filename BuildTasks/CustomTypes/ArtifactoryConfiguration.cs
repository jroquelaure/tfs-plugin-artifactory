namespace JFrogTFSPlugin.CustomTypes
{
    public class ArtifactoryConfiguration
    {
        public string ArtifactoryUrl { get; set; }
        public string TargetRepository { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string FolderToDeploy { get; set; }
        public string IncludePatterns { get; set; }
        public string ExcludePatterns { get; set; }
        public int TimeOut { get; set; }
        public bool IncludeBuildInfo { get; set; }
        public bool IsFlatDeploy { get; set; }
        public ProxyConfiguration ProxyConfiguration { get; set; }

        public override string ToString()
        {
            return ArtifactoryUrl;
        }
    }
}
