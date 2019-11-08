using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartPaymentClientNet.Model
{
    public class GeneralRequest
    {
        [JsonProperty(PropertyName = "currencyName")]
        public string CurrencyName { get; set; }

        [JsonProperty(PropertyName = "transactionEcrUuid")]
        public string TransactionEcrUuid { get; set; }

        [JsonProperty(PropertyName = "printReceiptOnEcr")]
        public bool PrintReceiptOnEcr { get; set; }


        public override string ToString()
        {

            var info = new StringBuilder();
            info.Append("CurrencyName: ").AppendLine(CurrencyName);
            info.Append("TransactionEcrUuid: ").AppendLine(TransactionEcrUuid);
            info.Append("PrintReceiptOnEcr: ").AppendLine(PrintReceiptOnEcr.ToString());

            return info.ToString();
        }
    }
}
