using System;
using System.Xml.Serialization;

namespace JFrogTFSPlugin.CustomTypes
{
    [Serializable]
    public class ProxyConfiguration
    {
        public ProxyConfiguration() { }

        public ProxyConfiguration(string host, int port)
        {
            Host = host;
            Port = port;
            IsCredentialsExists = false;
        }

        public ProxyConfiguration(string host, int port, string username, string password)
        {
            Host = host;
            Port = port;
            Username = username;
            Password = password;
            IsCredentialsExists = true;
        }

        public string Host { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Bypass { get; set; }
        [XmlIgnore]
        public bool IsCredentialsExists { get; set; }
       
    }
}