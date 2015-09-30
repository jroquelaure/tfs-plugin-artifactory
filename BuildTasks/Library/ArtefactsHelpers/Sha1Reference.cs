using System;
using System.IO;
using System.Security.Cryptography;

namespace JFrogTFSPlugin.Library.ArtefactsHelpers
{
    internal static class Sha1Reference
    {
        public static string GenerateSHA1(string path)
        {
            if (path == null) return string.Empty;
            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                fs.Position = 0;
                using (var sha1 = new SHA1Managed())
                {
                    return BitConverter.ToString(sha1.ComputeHash(fs)).Replace("-", String.Empty).ToLower();
                }
            }
        }
    }
}