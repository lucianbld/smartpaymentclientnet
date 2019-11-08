using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartPaymentClientNet.Model
{
    public class Device
    {
        [JsonProperty(PropertyName = "uuid")]
        public string Uuid { get; set; }
        [JsonProperty(PropertyName = "denumire")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "comPort")]
        public string ComPort { get; set; }

        [JsonProperty(PropertyName = "baudRate")]
        public int BaudRate { get; set; }

        [JsonProperty(PropertyName = "connectTimeout")]
        public int ConnectionTimeoutInSeconds { get; set; }

        [JsonProperty(PropertyName = "deviceType")]
        public string DeviceType { get; set; }

        [JsonProperty(PropertyName = "licence")]
        public string Licence { get; set; }


        public override string ToString()
        {

            var info = new StringBuilder();
            info.Append("Uuid: ").AppendLine(Uuid);
            info.Append("Description: ").AppendLine(Description);
            info.Append("COM port: ").AppendLine(ComPort);
            info.Append("Baud rate: ").AppendLine(BaudRate.ToString());
            info.Append("Connect timeout (Sec): ").AppendLine(ConnectionTimeoutInSeconds.ToString());
            info.Append("Device type: ").AppendLine(DeviceType);
            info.Append("Licence: ").AppendLine(Licence);

            return info.ToString();
        }
    }
}
