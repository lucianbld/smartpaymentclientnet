using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartPaymentClientNet.Model
{
    public class SalePreauthorizationRequest:GeneralRequest
    {
        [JsonProperty(PropertyName = "amount")]
        public decimal Amount { get; set; }

        public override string ToString()
        {

            var info = new StringBuilder();
            info.Append(base.ToString());
            info.Append("Amount: ").AppendLine(Amount.ToString());
        

            return info.ToString();
        }
    }
}
