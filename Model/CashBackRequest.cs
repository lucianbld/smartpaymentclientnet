using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartPaymentClientNet.Model
{
    public class CashBackRequest:GeneralRequest
    {
        [JsonProperty(PropertyName = "amount")]
        public decimal Amount { get; set; }
    }
}
