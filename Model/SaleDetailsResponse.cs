using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartPaymentClientNet.Model
{
    public class SaleDetailsResponse : SaleResponse
    {
        [JsonProperty(PropertyName = "transactionType")]
        public string TransactionType { get; set; }


        public override string ToString()
        {

            var info = new StringBuilder();
            info.Append(base.ToString());
            info.Append("Transaction Type: ").AppendLine(TransactionType);
        

            return info.ToString();
        }
    }
}
