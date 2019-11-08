using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartPaymentClientNet.Model
{
    public class SaleVoidRequest:GeneralRequest
    {
        [JsonProperty(PropertyName = "amount")]
        public decimal Amount { get; set; }

        [JsonProperty(PropertyName = "receiptNumber")]
        public int ReceiptNumber { get; set; }

        [JsonProperty(PropertyName = "authorizationCode")]
        public string AuthorizationCode { get; set; }

        [JsonProperty(PropertyName = "returnReferenceNumber")]
        public string ReturnReferenceNumber { get; set; }

        public override string ToString()
        {

            var info = new StringBuilder();
            info.Append(base.ToString());
            info.Append("Amount: ").AppendLine(Amount.ToString());
            info.Append("Receipt number: ").AppendLine(ReceiptNumber.ToString());
            info.Append("RRN: ").AppendLine(ReturnReferenceNumber);
            info.Append("Authorization code: ").AppendLine(AuthorizationCode);  

            return info.ToString();
        }

    }
}
