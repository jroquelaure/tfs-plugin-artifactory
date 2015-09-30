using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using JFrogTFSPlugin.Library.Artifactory;

namespace JFrogTFSPlugin.Library.ArtefactsHelpers
{
    public static class MatchArtifactHelper
    {
        /// <summary>
        /// Returns Artifacts files'information list from a given folder respecting include and exclude pattern
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <param name="includePatterns"></param>
        /// <param name="excludePatterns"></param>
        public static IList<FileInfo> GetMatchingArtifactsFrom(string directoryPath, string includePatterns, string excludePatterns)
        {
            var fileInfos = new List<FileInfo>();

            if (Directory.Exists((directoryPath)))
            {
                var includeFiles = new List<string>();
                if (!string.IsNullOrEmpty(includePatterns))
                {
                    foreach (var includePattern in includePatterns.Split(','))
                    {

                        if (includePattern.Contains(@"\") || includePattern.Contains(@"/"))
                        {
                            var regex = WildcardToRegex(includePattern);
                            includeFiles.InsertRange(0,
                                Directory.GetFiles(directoryPath, "*", SearchOption.AllDirectories)
                                    .Where(x => Regex.IsMatch(x, regex)));
                            ;
                        }
                        else
                        {
                            includeFiles.InsertRange(0,
                                Directory.GetFiles(directoryPath, includePattern, SearchOption.AllDirectories));
                        }

                    }
                }
                var exludeFiles= new List<string>();
                if (!string.IsNullOrEmpty(excludePatterns))
                {
                    foreach (var excludePattern in excludePatterns.Split(','))
                    {

                        if (excludePattern.Contains(@"/") || excludePattern.Contains(@"\"))
                        {
                            var regex = WildcardToRegex(excludePattern);
                            exludeFiles.InsertRange(0,
                                Directory.GetFiles(directoryPath, "*", SearchOption.AllDirectories)
                                    .Where(x => Regex.IsMatch(x, regex)));
                        }
                        else
                        {
                            exludeFiles.InsertRange(0,
                                Directory.GetFiles(directoryPath, excludePattern, SearchOption.AllDirectories));
                        }
                    }
                }
                fileInfos = includeFiles.Except(exludeFiles)
                    .Select(x=> new FileInfo(x)).ToList();
            }

            return fileInfos;
        }

        internal static string WildcardToRegex(string pattern)
        {
            if (string.IsNullOrWhiteSpace(pattern))
                return pattern;

            return "^" + Regex.Escape(pattern).Replace("\\*", ".*").Replace("\\?", ".") + "$";
        }

        internal static DeployDetails ToDeployDetails(this FileInfo artefactFileInfo, string repository)
        {
            var deployDetails = new DeployDetails
            {
                //TODO : artefact path should be overwritten by config?
                artifactPath = artefactFileInfo.Name,
                file = artefactFileInfo,
                md5 = MD5CheckSum.GenerateMD5(artefactFileInfo.FullName),
                sha1 = Sha1Reference.GenerateSHA1(artefactFileInfo.FullName),
                targetRepository = repository
            };

            return deployDetails;
        }

        internal static IList<DeployDetails> ToDeployDetailsList(this IList<FileInfo> artefactFilesInfo,
            string repository)
        {
            return artefactFilesInfo.Select(x => x.ToDeployDetails(repository)).ToList();
        }
    }
}
