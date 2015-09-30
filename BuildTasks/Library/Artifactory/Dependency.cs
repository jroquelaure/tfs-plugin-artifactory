using System.Collections.Generic;

namespace JFrogTFSPlugin.Library.Artifactory
{
    public class Dependency
    {
        public string type { get; set; }
        public string sha1 { get; set; }
        public string md5 { get; set; }
        public string id { get; set; }
        public List<string> scopes { get; set; }
    }
}