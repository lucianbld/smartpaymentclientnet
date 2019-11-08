using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartPaymentClientNet.Model
{
    public class WebServiceError
    {
        public int statusCode { get; set; }
        public string errorType { get; set; }
        public string errorMessage { get; set; }

        public override string ToString()
        {

            var info = new StringBuilder();
            info.Append("Status code: ").AppendLine(statusCode.ToString());
            info.Append("Error Type: ").AppendLine(errorType);
            info.Append("Error Message: ").AppendLine(errorMessage);
          
            return info.ToString();
        }
    }
}
