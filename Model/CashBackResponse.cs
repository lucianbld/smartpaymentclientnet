using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartPaymentClientNet.Model
{
    public class CashBackResponse
    {
        [JsonProperty(PropertyName = "terminalId")]
        public string TerminalId { get; set; }

        [JsonProperty(PropertyName = "merchantId")]
        public string MerchantId { get; set; }

        [JsonProperty(PropertyName = "paymentDate")]
        public string PaymentDatetime { get; set; }

        [JsonProperty(PropertyName = "cashBackServiceAllowed")]
        public bool CashBackServiceAllowed { get; set; }

        [JsonProperty(PropertyName = "cashBackLimitAmount")]
        public decimal CashBackLimitAmount { get; set; }

        [JsonProperty(PropertyName = "transactionEcrUuid")]
        public string TransactionEcrUuid { get; set; }


        public override string ToString()
        {

            var info = new StringBuilder();
            info.Append("Terminal ID: ").AppendLine(TerminalId);
            info.Append("Merchant ID: ").AppendLine(MerchantId);
            info.Append("Payment Datetime: ").AppendLine(PaymentDatetime);
            info.Append("CashBack Service Allowed: ").AppendLine(CashBackServiceAllowed.ToString());
            info.Append("CashBack Limit Amount: ").AppendLine(CashBackLimitAmount.ToString());
            info.Append("Transaction Ecr UUID: ").AppendLine(TransactionEcrUuid);

            return info.ToString();
        }
    }
}
