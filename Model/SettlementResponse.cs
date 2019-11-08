using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartPaymentClientNet.Model
{
    public class SettlementResponse:GeneralResponse
    {
        [JsonProperty(PropertyName = "currencyName")]
        public string CurrencyName { get; set; }

        [JsonProperty(PropertyName = "transactionsCount")]
        public int TransactionsCount { get; set; }

        [JsonProperty(PropertyName = "batchNumber")]
        public int BatchNumber { get; set; }

        [JsonProperty(PropertyName = "transactionTotalAmount")]
        public decimal TransactionTotalAmount { get; set; }

        public override string ToString()
        {

            var info = new StringBuilder();
            info.Append(base.ToString());
            info.Append("CurrencyName: ").AppendLine(CurrencyName);
            info.Append("TransactionsCount: ").AppendLine(TransactionsCount.ToString());
            info.Append("BatchNumber: ").AppendLine(BatchNumber.ToString());
            info.Append("TransactionTotalAmount: ").AppendLine(TransactionTotalAmount.ToString());
           
            return info.ToString();
        }

    }
}
