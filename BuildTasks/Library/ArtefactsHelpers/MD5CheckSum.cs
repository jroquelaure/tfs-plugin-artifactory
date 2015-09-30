using System;
using System.IO;
using System.Security.Cryptography;

namespace JFrogTFSPlugin.Library.ArtefactsHelpers
{
    internal static class MD5CheckSum
    {
        public static string GenerateMD5(string path)
        {
            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (var md5 = MD5.Create())
            {
                return BitConverter.ToString(md5.ComputeHash(fs)).Replace("-", "").ToLower();
            }
        }
    }
}