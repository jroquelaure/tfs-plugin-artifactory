using System.Activities;
using System.Collections.Generic;
using JFrogTFSPlugin.CustomTypes;
using JFrogTFSPlugin.Library;
using JFrogTFSPlugin.Library.ArtefactsHelpers;
using JFrogTFSPlugin.Library.Artifactory;
using Microsoft.TeamFoundation.Build.Client;

namespace JFrogTFSPlugin.Activities
{
    [BuildActivity(HostEnvironmentOption.All)]
    public sealed class JFrogArtifactoryDeployer : CodeActivity
    {
        // Define an activity input argument of type string
        public InArgument<ArtifactoryConfiguration> ArtifactoryConfiguration { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            ArtifactoryConfiguration artifactoryConfig = context.GetValue(ArtifactoryConfiguration);

            //first step :initialize the build object from TFS properties
            IBuildDetail buildDetail = context.GetExtension<IBuildDetail>();

            var extractBuildInfoForArtifactory = BuildInfoExtractor.ExtractBuildInfoForArtifactory(buildDetail,
                context);
            extractBuildInfoForArtifactory.artifactoryPrincipal = artifactoryConfig.User;

            List<KeyValuePair<string, string>> properties = new List<KeyValuePair<string, string>>();
            properties.AddRange(extractBuildInfoForArtifactory.GetDefaultProperties());

            //second step : get files using folder and include/exclude patterns
            var matchingArtifacts = MatchArtifactHelper.GetMatchingArtifactsFrom(artifactoryConfig.FolderToDeploy, artifactoryConfig.IncludePatterns, artifactoryConfig.ExcludePatterns);
            //deploy artefacts
            var artefactsDeployer = new ArtefactsDeployer(artifactoryConfig.ArtifactoryUrl, artifactoryConfig.User, artifactoryConfig.Password, artifactoryConfig.ProxyConfiguration, artifactoryConfig.TimeOut, context);
            HashSet<Artifact> deployedArtefacts = artefactsDeployer.DeployArtefacts(matchingArtifacts, artifactoryConfig.TargetRepository, artifactoryConfig.IsFlatDeploy, artifactoryConfig.FolderToDeploy, properties);
            //add deployed artefacts
            //TODO : change the way module is used, actually it is by build definition, maybe a rework of the UI, a grid or something... don't really know if pertinent
            extractBuildInfoForArtifactory.modules.Add(new Module(buildDetail.BuildDefinition.Name) { Artifacts = deployedArtefacts });
            //deploy build infos

            if (artifactoryConfig.IncludeBuildInfo)
            {
                //TODO: see with Dror and eyal if we want environment variables
                //if (!string.IsNullOrEmpty(artifactoryConfig.IncludePatterns) && artifactoryConfig.IncludePatterns.Split(',').Length > 0)
                //{
                //    var includePatterns = artifactoryConfig.IncludePatterns.Split(',').Select(x => MatchArtifactHelper.WildcardToRegex(x));
                //    Regex includesRegex = new Regex(string.Join("|", includePatterns), RegexOptions.IgnoreCase);
                //}

                //if (!string.IsNullOrEmpty(artifactoryConfig.ExcludePatterns) && artifactoryConfig.ExcludePatterns.Split(',').Length > 0)
                //{
                //    var excludePatterns = artifactoryConfig.ExcludePatterns.Split(',').Select(x => MatchArtifactHelper.WildcardToRegex(x));
                //    Regex excludesRegex = new Regex(string.Join("|", excludePatterns), RegexOptions.IgnoreCase);
                //}

                artefactsDeployer.SendBuildInfo(extractBuildInfoForArtifactory.ToJsonString());
            }
            //


        }

       
    }
}
