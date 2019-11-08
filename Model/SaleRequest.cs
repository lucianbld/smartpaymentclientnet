using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartPaymentClientNet.Model
{
    public class SaleRequest:GeneralRequest
    {
        [JsonProperty(PropertyName = "amount")]
        public decimal Amount { get; set; }

        [JsonProperty(PropertyName = "cashBackAmount")]
        public decimal CashBackAmount { get; set; }


    }
}
