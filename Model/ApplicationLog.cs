using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartPaymentClientNet.Model
{
    public class ApplicationLog
    {
        [JsonProperty(PropertyName = "timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty(PropertyName = "event")]
        public string Event { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        public override string ToString()
        {
            var info = new StringBuilder();
            info.Append("Timestamp: ").AppendLine(Timestamp);
            info.Append("Event: ").AppendLine(Event);
            info.Append("Message: ").AppendLine(Message);
        
            return info.ToString();
        }
    }
}
