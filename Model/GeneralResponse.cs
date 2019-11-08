using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartPaymentClientNet.Model
{
    public class GeneralResponse
    {

        [JsonProperty(PropertyName = "terminalId")]
        public string TerminalId { get; set; }

        [JsonProperty(PropertyName = "merchantId")]
        public string MerchantId { get; set; }

        [JsonProperty(PropertyName = "paymentDate")]
        public string PaymentDatetime { get; set; }

        [JsonProperty(PropertyName = "cardHostApprovedTransaction")]
        public bool CardHostApprovedTransaction { get; set; }

        [JsonProperty(PropertyName = "cardHostResponseCode")]
        public string CardHostResponseCode { get; set; }

        [JsonProperty(PropertyName = "cardHostResponseText")]
        public string CardHostResponseText { get; set; }

        [JsonProperty(PropertyName = "transactionEcrUuid")]
        public string TransactionEcrUuid { get; set; }


        public override string ToString()
        {
            var info = new StringBuilder();
            info.Append("Terminal ID:").AppendLine(TerminalId);
            info.Append("Merchant ID:").AppendLine(MerchantId);
            info.Append("Payment Date:").AppendLine(PaymentDatetime);
            info.Append("Card Host Approved Transaction:").AppendLine(CardHostApprovedTransaction.ToString());
            info.Append("Card Host Response Code:").AppendLine(CardHostResponseCode);
            info.Append("Card Host Response Text").AppendLine(CardHostResponseText);
            info.Append("Transaction Ecr Uuid:").AppendLine(TransactionEcrUuid);

            return info.ToString();
        }
    }
}
