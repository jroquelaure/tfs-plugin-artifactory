using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JFrogTFSPlugin.Library.Utils
{
    class HttpResponse
    {
        public HttpStatusCode _statusCode { set; get; }

        public string _message { get; set; }

        public HttpResponse(HttpStatusCode statusCode, string message)
        {
            _statusCode = statusCode;
            _message = message;
        }
    }
}
