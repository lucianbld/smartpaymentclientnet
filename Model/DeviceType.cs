using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartPaymentClientNet.Model
{
    public class DeviceType
    {
        [JsonProperty(PropertyName = "identifier")]
        public string Identifier { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Description { get; set; }

        public override string ToString()
        {

            var info = new StringBuilder();
            info.Append("Identifier: ").AppendLine(Identifier);
            info.Append("Description: ").AppendLine(Description);
          
            return info.ToString();
        }

    }
}
