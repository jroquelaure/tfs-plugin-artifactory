using System.Collections.Generic;

namespace JFrogTFSPlugin.Library.Artifactory
{
    public class Artifact : IEqualityComparer<Artifact>
    {
        public string type { get; set; }
        public string sha1 { get; set; }
        public string md5 { get; set; }
        public string name { get; set; }

        public bool Equals(Artifact a, Artifact b)
        {
            if (!a.type.Equals(b.type))
                return false;
            if (!a.sha1.Equals(b.sha1))
                return false;
            if (!a.md5.Equals(b.md5))
                return false;
            if (!a.name.Equals(b.name))
                return false;

            return true;
        }

        public int GetHashCode(Artifact obj)
        {
            int hash = 17;
            hash = hash * 31 + obj.type.GetHashCode();
            hash = hash * 31 + obj.sha1.GetHashCode();
            hash = hash * 31 + obj.md5.GetHashCode();
            hash = hash * 31 + obj.name.GetHashCode();

            return hash;
        }
    }
}