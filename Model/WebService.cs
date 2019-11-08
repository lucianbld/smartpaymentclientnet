using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartPaymentClientNet.Model
{
    public class WebService
    {

        [JsonProperty(PropertyName = "isPublic")]
        public bool IsPublic { get; set; }

        [JsonProperty(PropertyName = "httpPort")]
        public int HttpPort { get; set; }

        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }

        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }

        [JsonProperty(PropertyName = "corsActive")]
        public bool IsCorsActive { get; set; }

        [JsonProperty(PropertyName = "sslActive")]
        public bool IsSslActive { get; set; }

        [JsonProperty(PropertyName = "sslCertificate")]
        public string SslCertificatePath { get; set; }

        [JsonProperty(PropertyName = "sslCertificateKey")]
        public string SslCertificateKeyPath { get; set; }

        [JsonProperty(PropertyName = "logDirectory")]
        public string LogDirectoryPath { get; set; }

        [JsonProperty(PropertyName = "logRotationInterval")]
        public int LogRotationInterval { get; set; }

        [JsonProperty(PropertyName = "accessLogActive")]
        public bool IsAccessLogActive { get; set; }

        [JsonProperty(PropertyName = "serviceSideEventsActive")]
        public bool IsServiceSideEventsActive { get; set; }


        public override string ToString()
        {

            var info = new StringBuilder();
            info.Append("IsPublic: ").AppendLine(IsPublic.ToString());
            info.Append("HttpPort: ").AppendLine(HttpPort.ToString());
            info.Append("Username: ").AppendLine(Username);
            info.Append("Password:").AppendLine(Password);
            info.Append("IsCorsActive:").AppendLine(IsCorsActive.ToString());
            info.Append("IsSslActive:").AppendLine(IsSslActive.ToString());
            info.Append("SSL Certificate Path:").AppendLine(SslCertificatePath);
            info.Append("SSL Certificate Key Path:").AppendLine(SslCertificateKeyPath);
            info.Append("Log directory:").AppendLine(LogDirectoryPath);
            info.Append("Log rotation interval (days):").AppendLine(LogRotationInterval.ToString());
            info.Append("IsAccessLogActive:").AppendLine(IsAccessLogActive.ToString());
            info.Append("IsServiceSideEventsActive:").AppendLine(IsServiceSideEventsActive.ToString());

            return info.ToString();
        }

    }
}
