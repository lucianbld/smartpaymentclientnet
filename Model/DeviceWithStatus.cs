using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartPaymentClientNet.Model
{
    public class DeviceWithStatus : Device
    {
        [JsonProperty(PropertyName = "connectionStatus")]
        public string ConnectionStatus { get; set; }

        [JsonProperty(PropertyName = "licenceStatus")]
        public string LicenceStatus { get; set; }

        [JsonProperty(PropertyName = "licenceDemo")]
        public bool IsDemoLicence { get; set; }


        public override string ToString()
        {

            var info = new StringBuilder();
            info.Append(base.ToString());
            info.Append("ConnectionStatus: ").AppendLine(ConnectionStatus);
            info.Append("LicenceStatus: ").AppendLine(LicenceStatus);
            info.Append("IsDemoLicence: ").AppendLine(IsDemoLicence.ToString());
       
            return info.ToString();
        }
    }

}



