using System.Collections.Generic;

namespace JFrogTFSPlugin.Library.Artifactory
{
    /// <summary>
    /// build module data
    /// </summary>
    public class Module
    {
        public Module(string projectName)
        {
            Artifacts = new HashSet<Artifact>(new Artifact());
            Dependencies = new List<Dependency>();
            id = projectName;
        }

        /// <summary>
        /// module identifier
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// A list of artifacts deployed for this module
        /// </summary>
        public HashSet<Artifact> Artifacts { get; set; }

        /// <summary>
        /// A list of dependencies used when building this module
        /// </summary>
        public List<Dependency> Dependencies { get; set; }
    }
}