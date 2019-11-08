using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartPaymentClientNet.Model
{
    public class AccessLog
    {
        [JsonProperty(PropertyName = "timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }

        [JsonProperty(PropertyName = "ipAddress")]
        public string IpAddress { get; set; }

        [JsonProperty(PropertyName = "method")]
        public string HttpMethod { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string UrlPath { get; set; }

        [JsonProperty(PropertyName = "userAgent")]
        public string UserAgent { get; set; }

        public override string ToString()
        {
            var info = new StringBuilder();
            info.Append("Timestamp: ").AppendLine(Timestamp);
            info.Append("Username: ").AppendLine(Username);
            info.Append("IP Address: ").AppendLine(IpAddress);
            info.Append("Http Method: ").AppendLine(HttpMethod);
            info.Append("URL: ").AppendLine(UrlPath);
            info.Append("User Agent: ").AppendLine(UserAgent);

            return info.ToString();
        }
    }
}
