using System.Collections.Generic;

namespace JFrogTFSPlugin.Library.Artifactory
{
    public class BuildRetention
    {
        public int count { get; set; }
        public bool deleteBuildArtifacts { get; set; }
        public List<string> buildNumbersNotToBeDiscarded { get; set; }
    }
}