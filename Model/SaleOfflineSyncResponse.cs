using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartPaymentClientNet.Model
{
    public class SaleOfflineSyncResponse
    {
        [JsonProperty(PropertyName = "terminalId")]
        public string TerminalId { get; set; }

        [JsonProperty(PropertyName = "merchantId")]
        public string MerchantId { get; set; }

        [JsonProperty(PropertyName = "paymentDate")]
        public string PaymentDatetime { get; set; }

        [JsonProperty(PropertyName = "currencyName")]
        public string CurrencyName { get; set; }

        [JsonProperty(PropertyName = "transactionsCount")]
        public int TransactionsCount { get; set; }

        [JsonProperty(PropertyName = "batchNumber")]
        public int BatchNumber { get; set; }

        [JsonProperty(PropertyName = "uploadedTransactionsTotalAmount")]
        public decimal TransactionsTotalAmount { get; set; }


        public override string ToString()
        {

            var info = new StringBuilder();
 
            info.Append("Terminal ID: ").AppendLine(TerminalId);
            info.Append("Merchant id: ").AppendLine(MerchantId);
            info.Append("Payment Datetime: ").AppendLine(PaymentDatetime);
            info.Append("CurrencyName: ").AppendLine(CurrencyName);
            info.Append("TransactionsCount: ").AppendLine(TransactionsCount.ToString());
            info.Append("BatchNumber: ").AppendLine(BatchNumber.ToString());
            info.Append("TransactionsTotalAmount: ").AppendLine(TransactionsTotalAmount.ToString());

            return info.ToString();
        }

    }
}
