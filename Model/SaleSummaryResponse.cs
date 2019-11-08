using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartPaymentClientNet.Model
{
    public class SaleSummaryResponse
    {

        [JsonProperty(PropertyName = "batchNumber")]
        public int BatchNumber { get; set; }

        [JsonProperty(PropertyName = "transactionsCount")]
        public int TransactionsCount { get; set; }

        [JsonProperty(PropertyName = "transactionTotalAmount")]
        public decimal TransactionTotalAmount { get; set; }

        public override string ToString()
        {

            var info = new StringBuilder();

            info.Append("Batch number: ").AppendLine(BatchNumber.ToString());
            info.Append("TransactionsCount: ").AppendLine(TransactionsCount.ToString());
            info.Append("TransactionTotalAmount: ").AppendLine(TransactionTotalAmount.ToString());
        
            return info.ToString();
        }

    }
}
