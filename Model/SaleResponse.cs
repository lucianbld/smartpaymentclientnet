using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartPaymentClientNet.Model
{
    public class SaleResponse:GeneralResponse
    {
        [JsonProperty(PropertyName = "approvedAmount")]
        public decimal ApprovedAmount { get; set; }

        [JsonProperty(PropertyName = "approvedAmountCurrency")]
        public string ApprovedAmountCurrency { get; set; }

        [JsonProperty(PropertyName = "batchNumber")]
        public int BatchNumber { get; set; }

        [JsonProperty(PropertyName = "receiptNumber")]
        public int ReceiptNumber { get; set; }

        [JsonProperty(PropertyName = "returnReferenceNumber")]
        public string ReturnReferenceNumber { get; set; }

        [JsonProperty(PropertyName = "authorizationCode")]
        public string AuthorizationCode { get; set; }

        [JsonProperty(PropertyName = "cardNumber")]
        public string CardNumber { get; set; }

        [JsonProperty(PropertyName = "cardHolderName")]
        public string CardHolderName { get; set; }

        [JsonProperty(PropertyName = "cardCompany")]
        public string CardCompany { get; set; }

        [JsonProperty(PropertyName = "emvApplicationLabel")]
        public string EmvApplicationLabel { get; set; }

        [JsonProperty(PropertyName = "emvApplicationId")]
        public string EmvApplicationId { get; set; }

        [JsonProperty(PropertyName = "transactionFlag")]
        public List<string> TransactionFlag { get; set; }

        [JsonProperty(PropertyName = "isPinUsed")]
        public bool IsPinUsed { get; set; }


        public override string ToString()
        {

            var info = new StringBuilder();
            info.Append(base.ToString());
            info.Append("Approved amount: ").AppendLine(ApprovedAmount.ToString());
            info.Append("Approved Amount Currency: ").AppendLine(ApprovedAmountCurrency);
            info.Append("Batch number: ").AppendLine(BatchNumber.ToString());
            info.Append("Receipt number: ").AppendLine(ReceiptNumber.ToString());
            info.Append("RRN: ").AppendLine(ReturnReferenceNumber);
            info.Append("Authorization code: ").AppendLine(AuthorizationCode);
            info.Append("Card number: ").AppendLine(CardNumber);
            info.Append("Card holder name: ").AppendLine(CardHolderName);
            info.Append("Card company: ").AppendLine(CardCompany);
            info.Append("EMV Application Label: ").AppendLine(EmvApplicationLabel);
            info.Append("EMV Application ID: ").AppendLine(EmvApplicationId);
            info.Append("Transaction Flag: ").AppendLine(TransactionFlag.ToString());
            info.Append("Is Pin Used: ").AppendLine(IsPinUsed.ToString());

            return info.ToString();
        }

    }
}
