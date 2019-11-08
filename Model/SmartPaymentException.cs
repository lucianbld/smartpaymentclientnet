using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartPaymentClientNet.Model
{
    public class SmartPaymentException : Exception
    {

        public int statusCode { get; set; }
        public String statusMessage { get; set; }
        public String token { get; set; }


        public SmartPaymentException(int statusCode, String statusMessage, String token)
        {
            this.statusCode = statusCode;
            this.statusMessage = statusMessage;
            this.token = token;
        }


        public SmartPaymentException(int statusCode) : this(statusCode, null, null) { }

        public SmartPaymentException(String statusMessage) : this(0, statusMessage, null) { }

        public SmartPaymentException(int statusCode, String message) : this(statusCode, message, null) { }


        public override string ToString()
        {
            var info = new StringBuilder();
            info.Append("Status code: ").AppendLine(statusCode.ToString());
            info.Append("Token: ").AppendLine(token);
            info.Append("Message: ").AppendLine(statusMessage);

            return info.ToString();
        }
    }
}
