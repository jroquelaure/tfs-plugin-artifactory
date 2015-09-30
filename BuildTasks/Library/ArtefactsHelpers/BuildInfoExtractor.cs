using System;
using System.Activities;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using JFrogTFSPlugin.Library.Artifactory;
using Microsoft.TeamFoundation.Build.Client;
using Microsoft.TeamFoundation.Build.Workflow.Activities;

namespace JFrogTFSPlugin.Library.ArtefactsHelpers
{
    static class  BuildInfoExtractor
    {
        private const string artifactoryDateFormat = "yyyy-MM-dd'T'HH:mm:ss.ssszzzz";

        public static Build ExtractBuildInfoForArtifactory(IBuildDetail buildDetail, CodeActivityContext context)
        {
            Build build = new Build
            {
                modules = new List<Module>(),
            };

            build.started = string.Format(Build.STARTED_FORMAT, buildDetail.StartTime.ToString(artifactoryDateFormat));

            IBuildAgent currentAgent = null;
            foreach (IBuildAgent agent in buildDetail.BuildController.Agents)
            {

                if (Uri.Equals(agent.ReservedForBuild, buildDetail.Uri))
                {
                    currentAgent = agent;
                    break;
                }
            }

           // build.buildAgent = new BuildAgent { name = currentAgent.Name, version = task.ToolVersion };
            build.type = "TFS";

            build.agent = new AgentTFS
            {
                name = currentAgent.Name,
                version = "",
            };

            //get the current use from the windows OS
            System.Security.Principal.WindowsIdentity user;
            user = System.Security.Principal.WindowsIdentity.GetCurrent();
            if (user != null) build.principal = string.Format(@"{0}", user.Name);

            //Calculate how long it took to do the build
            build.startedDateMillis = GetTimeStamp();
            build.durationMillis = Convert.ToInt64((DateTime.Now - buildDetail.StartTime).TotalMilliseconds);

            build.number = string.IsNullOrWhiteSpace(buildDetail.BuildNumber) ? build.startedDateMillis : buildDetail.BuildNumber;
            build.name = buildDetail.BuildDefinition.Name;
            build.url =  string.Format(@"{0}/{1}/_build#_a=summary&buildUri={2}", buildDetail.BuildServer.TeamProjectCollection.Uri.AbsoluteUri, buildDetail.TeamProject, buildDetail.Uri.AbsoluteUri) ;
            build.vcsRevision = buildDetail.SourceGetVersion;
            
            //Add build server properties, if exists.
            //AddSystemVariables(artifactoryConfig, build);
            //AddLicenseControl(artifactoryConfig, build, log);
            //AddBlackDuck(artifactoryConfig, build, log);

            //ConfigHttpClient(artifactoryConfig, build);

            return build;
        }

        //private static void AddSystemVariables(ArtifactoryConfig artifactoryConfig, Build build)
        //{
        //    if (artifactoryConfig.PropertyGroup.EnvironmentVariables == null)
        //        return;

        //    string enable = artifactoryConfig.PropertyGroup.EnvironmentVariables.EnabledEnvVariable;
        //    if (string.IsNullOrWhiteSpace(enable) || !enable.ToLower().Equals("true"))
        //        return;

        //    // includePatterns = new List<Pattern>();
        //    //List<Pattern> excludePatterns = new List<Pattern>();
        //    List<Pattern> includePatterns = artifactoryConfig.PropertyGroup.EnvironmentVariables.IncludePatterns.Pattern;
        //    List<Pattern> excludePatterns = artifactoryConfig.PropertyGroup.EnvironmentVariables.ExcludePatterns.Pattern;

        //    StringBuilder includeRegexUnion = new StringBuilder();
        //    StringBuilder excludeRegexUnion = new StringBuilder();

        //    if (includePatterns != null && includePatterns.Count > 0)
        //    {
        //        includePatterns.ForEach(pattern => includeRegexUnion.Append(WildcardToRegex(pattern.key)).Append("|"));
        //        includeRegexUnion.Remove(includeRegexUnion.Length - 1, 1);
        //    }

        //    if (excludePatterns != null && excludePatterns.Count > 0)
        //    {
        //        excludePatterns.ForEach(pattern => excludeRegexUnion.Append(WildcardToRegex(pattern.key)).Append("|"));
        //        excludeRegexUnion.Remove(excludeRegexUnion.Length - 1, 1);
        //    }

        //    Regex includeRegex = new Regex(includeRegexUnion.ToString(), RegexOptions.IgnoreCase);
        //    Regex excludeRegex = new Regex(excludeRegexUnion.ToString(), RegexOptions.IgnoreCase);

        //    //System.Environment.GetEnvironmentVariables()
        //    //EnvironmentVariableTarget
        //    IDictionary sysVariables = Environment.GetEnvironmentVariables(EnvironmentVariableTarget.Process);
        //    var dicVariables = new Dictionary<string, string>();

        //    foreach (string key in sysVariables.Keys)
        //    {
        //        if (!PathConflicts(includePatterns, excludePatterns, includeRegex, excludeRegex, key))
        //        {
        //            dicVariables.Add(key, (string)sysVariables[key]);
        //        }
        //    }

        //    dicVariables.AddRange(build.agent.BuildAgentEnvironment());

        //    build.properties = dicVariables;
        //}

        private static string GetTimeStamp()
        {
            int timestemp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            return timestemp.ToString();
        }

        public static string ToJsonString(this Build model)
        {
            // sb.AppendFormat("\"\":\"{0}\",", model);
            var json = new StringBuilder();
            //open json root
            json.Append("{");
            json.AppendFormat("\"version\":\"{0}\",", model.version);
            json.AppendFormat("\"name\":\"{0}\",", model.name);
            json.AppendFormat("\"number\":\"{0}\",", model.number);
            // json.AppendFormat("\"type\":\"{0}\",", model.type);
            //json.AppendFormat("\"buildAgent\":{{\"name\":\"{0}\",\"version\":\"{1}\"}},", model.buildAgent.name, model.buildAgent.version);
            json.AppendFormat("\"agent\":{{\"name\":\"{0}\",\"version\":\"{1}\"}},", model.agent.name, model.agent.version);
            json.AppendFormat("\"started\":\"{0}\",", model.started);
            json.AppendFormat("\"durationMillis\":{0},", model.durationMillis);
            var arrString = model.principal.Split('\\');
            json.AppendFormat("\"principal\":\"{0}\",", arrString.LastOrDefault());
            json.AppendFormat("\"artifactoryPrincipal\":\"{0}\",", model.artifactoryPrincipal);
            json.AppendFormat("\"url\":\"{0}\",", model.url);
            json.AppendFormat("\"vcsRevision\":\"{0}\",", model.vcsRevision);

            //createLicenseControl(json, model);
            //CreateBlackDuck(json, model);

            json.Append("\"buildRetention\":null,");

           // CreateEnvVar(json, model);

            json.Append("\"modules\":[");
            var modulesCount = model.modules.Count();
            for (var i = 0; i < modulesCount; i++)
            {
                CreateModule(model, json, i);
                if ((i + 1) < modulesCount)
                {
                    json.Append(",");
                }
            }
            json.Append("]");

            //close json root
            json.Append("}");

            return json.ToString();
        }

        private static void CreateModule(Build model, StringBuilder sb, int i)
        {
            //module start
            sb.Append("{");

            sb.AppendFormat("\"id\":\"{0}\",", model.modules[i].id);
            sb.Append("\"dependencies\": [");
            for (var ii = 0; ii < model.modules[i].Dependencies.Count(); ii++)
            {
                sb.Append("{");
                sb.AppendFormat("\"type\":\"{0}\",", model.modules[i].Dependencies[ii].type);
                sb.AppendFormat("\"sha1\":\"{0}\",", model.modules[i].Dependencies[ii].sha1);
                sb.AppendFormat("\"md5\":\"{0}\",", model.modules[i].Dependencies[ii].md5);
                sb.AppendFormat("\"id\":\"{0}\",", model.modules[i].Dependencies[ii].id);
                sb.Append("\"scopes\":[");
                for (var n = 0; n < model.modules[i].Dependencies[ii].scopes.Count; n++)
                {
                    sb.AppendFormat(
                        n + 1 < model.modules[i].Dependencies[ii].scopes.Count ? "\"{0}\"," : "\"{0}\"",
                        model.modules[i].Dependencies[ii].scopes[n]);
                }
                sb.Append("]}");
                if ((ii + 1) < model.modules[i].Dependencies.Count())
                {
                    sb.Append(",");
                }
            }
            sb.Append("],");

            sb.Append("\"artifacts\": [");

            foreach (var artifact in model.modules[i].Artifacts)
            {
                sb.Append("{");
                sb.AppendFormat("\"type\":\"{0}\",", artifact.type);
                sb.AppendFormat("\"sha1\":\"{0}\",", artifact.sha1);
                sb.AppendFormat("\"md5\":\"{0}\",", artifact.md5);
                sb.AppendFormat("\"name\":\"{0}\"", artifact.name);
                sb.Append("},");
            }

            if (model.modules[i].Artifacts.Count != 0)
                sb = (sb.Remove(sb.Length - 1, 1));

            sb.Append("]");

            //module end
            sb.Append("}");
        }

        private static void createLicenseControl(StringBuilder json, Build model)
        {
            json.Append("\"licenseControl\":{");
            json.AppendFormat("\"runChecks\":\"{0}\",", model.licenseControl.runChecks);
            json.AppendFormat("\"includePublishedArtifacts\":\"{0}\",", model.licenseControl.includePublishedArtifacts);
            json.AppendFormat("\"autoDiscover\":\"{0}\",", model.licenseControl.autoDiscover);
            json.Append("\"licenseViolationRecipients\":[");

            var lastRecip = model.licenseControl.licenseViolationsRecipients.LastOrDefault();
            foreach (string recip in model.licenseControl.licenseViolationsRecipients)
            {
                json.AppendFormat("\"{0}\"", recip);
                if (!lastRecip.Equals(recip))
                    json.Append(",");
            }
            json.Append("],");
            json.Append("\"scopes\":[");
            var lastScope = model.licenseControl.scopes.LastOrDefault();
            foreach (string scope in model.licenseControl.scopes)
            {
                json.AppendFormat("\"{0}\"", scope);
                if (!lastScope.Equals(scope))
                    json.Append(",");
            }
            json.Append("]");
            json.Append("},");

        }

        //BlackDuck
        private static void CreateBlackDuck(StringBuilder json, Build model)
        {
            if (model.blackDuckGovernance == null)
                return;

            json.Append("\"governance\":{");
            json.Append("\"blackDuckProperties\":{");
            json.AppendFormat("\"runChecks\":\"{0}\",", model.blackDuckGovernance.runChecks);
            json.AppendFormat("\"appName\":\"{0}\",", model.blackDuckGovernance.appName);
            json.AppendFormat("\"appVersion\":\"{0}\",", model.blackDuckGovernance.appVersion);

            if (model.blackDuckGovernance.reportRecipients.Count > 0)
            {
                json.Append("\"reportRecipients\":");
                var lastRecip = model.blackDuckGovernance.reportRecipients.LastOrDefault();
                string recipes = string.Empty;
                foreach (string recip in model.blackDuckGovernance.reportRecipients)
                {
                    recipes += recip;
                    if (!lastRecip.Equals(recip))
                        recipes += " ";
                }
                json.AppendFormat("\"{0}\"", recipes);
                json.Append(",");
            }

            if (model.blackDuckGovernance.scopes.Count > 0)
            {
                json.Append("\"scopes\":");
                var lastScope = model.blackDuckGovernance.scopes.LastOrDefault();
                string scopes = string.Empty;
                foreach (string scope in model.blackDuckGovernance.scopes)
                {
                    scopes += scope;
                    if (!lastScope.Equals(scope))
                        scopes += " ";
                }
                json.AppendFormat("\"{0}\"", scopes);
                json.Append(",");
            }

            json.AppendFormat("\"includePublishedArtifacts\":\"{0}\",", model.blackDuckGovernance.includePublishedArtifacts);
            json.AppendFormat("\"autoCreateMissingComponentRequests\":\"{0}\",", model.blackDuckGovernance.autoCreateMissingComponentRequests);
            json.AppendFormat("\"autoDiscardStaleComponentRequests\":\"{0}\"", model.blackDuckGovernance.autoDiscardStaleComponentRequests);
            json.Append("}");
            json.Append("},");
        }

        //system variables start
        private static void CreateEnvVar(StringBuilder json, Build model)
        {
            if (model.properties != null && model.properties.Count > 0)
            {
                json.Append("\"properties\":{");
                var lastKey = model.properties.LastOrDefault();

                String quoteMatch = @"""";
                String doubleBackSlashMatch = @"\\";

                foreach (var kvp in model.properties)
                {
                    String cleanValue = Regex.Replace(kvp.Value, doubleBackSlashMatch, doubleBackSlashMatch).Replace(quoteMatch, @"\""");
                    json.AppendFormat("\"{0}\":\"{1}\"", kvp.Key, cleanValue);
                    if (kvp.Key != lastKey.Key)
                    {
                        json.Append(",");
                    }
                }
                json.Append("},");
            }
        }
    }
}
