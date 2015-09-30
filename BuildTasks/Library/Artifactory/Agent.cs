using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFrogTFSPlugin.Library.Artifactory
{
    public abstract class Agent
    {
        public string name { get; set; }
        public string version { get; set; }

        protected const string PRE_FIX_ENV = "buildInfo.env.";

      /// <summary>
        /// Specific environment variables to a Build server/agent
        /// </summary>
        /// <returns></returns>
     //   public abstract IDictionary<string, string> BuildAgentEnvironment();

      //  public abstract string BuildAgentUrl();
    }
}
