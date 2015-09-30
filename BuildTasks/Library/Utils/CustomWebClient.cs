using System;
using System.Net;
using System.Text;

namespace JFrogTFSPlugin.Library.Utils
{
    class CustomWebClient : WebClient
    {
        private string _username;
        private string _password;
        private readonly string CLIENT_VERSION = "unknown";///!!!!!!!! for now

        public int Timeout { set; get; }

        public CustomWebClient(string username, string password)
        {
            _username = username;
            _password = password;
        }

        public CustomWebClient(string username, string password, int timeout)
        {
            _username = username;
            _password = password;
            Timeout = timeout;
        }

        protected override WebRequest GetWebRequest(Uri uri)
        {
            WebRequest request = base.GetWebRequest(uri);
            if (request != null)
            {
                request.Timeout = Timeout * 1000;

                //Add Basic Authentication 
                var auth = string.Format("{0}:{1}", _username, _password);
                var enc = Convert.ToBase64String(Encoding.UTF8.GetBytes(auth));
                var cred = string.Format("{0} {1}", "Basic ", enc);
                request.Headers["Authorization"] = cred;

                //Add Agent
                ((HttpWebRequest)request).UserAgent = "ArtifactoryBuildClient/.NET" + CLIENT_VERSION;

                return request;
            }
            return null;
        }

        protected override WebResponse GetWebResponse(WebRequest request)
        {
            HttpWebResponse response = (HttpWebResponse)base.GetWebResponse(request);

            //A way to pass the Web Response object.
            //System.Net.WebClient by default returns only status OK (200)
            if (response != null && response.StatusCode != HttpStatusCode.OK)
            {
                throw new WebException(response.StatusCode.ToString(), null, WebExceptionStatus.SendFailure, response);
            }

            return response;
        }
    }
}
