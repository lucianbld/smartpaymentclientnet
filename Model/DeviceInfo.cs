using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartPaymentClientNet.Model
{
    public class DeviceInfo
    {

        [JsonProperty(PropertyName = "terminalId")]
        public string TerminalId { get; set; }

        [JsonProperty(PropertyName = "merchantId")]
        public string MerchantId { get; set; }

        [JsonProperty(PropertyName = "hardwareVersion")]
        public string HardwareVersion { get; set; }

        [JsonProperty(PropertyName = "softwareVersion")]
        public string SoftwareVersion { get; set; }

        [JsonProperty(PropertyName = "serialNumber")]
        public string SerialNumber { get; set; }

        public override string ToString()
        {

            var info = new StringBuilder();
            info.Append("Terminal ID: ").AppendLine(TerminalId);
            info.Append("Merchant ID: ").AppendLine(MerchantId);
            info.Append("Hardware Version: ").AppendLine(HardwareVersion);
            info.Append("Software Version: ").AppendLine(SoftwareVersion);
            info.Append("SerialNumber: ").AppendLine(SerialNumber);
        
            return info.ToString();
        }


    }
}
