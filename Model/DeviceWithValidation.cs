using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartPaymentClientNet.Model
{
    public class DeviceWithValidation : Device
    {
        [JsonProperty(PropertyName = "isValid")]
        public bool IsValid { get; set; }

        public override string ToString()
        {

            var info = new StringBuilder();
            info.Append(base.ToString());
            info.Append("Is Valid: ").AppendLine(IsValid.ToString());
       
            return info.ToString();
        }
    }

}
