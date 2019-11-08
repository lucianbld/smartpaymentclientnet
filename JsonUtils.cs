using Newtonsoft.Json;
using SmartPaymentClientNet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartPaymentClientNet
{
    static class JsonUtils
    {
        public static string EncodeJson<T>(T content) where T : new()
        {

            if (content == null)
            {
                return null;
            }

            try
            {
                return JsonConvert.SerializeObject(content);
            }
            catch (JsonException jex)
            {
                throw new SmartPaymentException("Json string is not in correct format: " + Environment.NewLine + jex.Message + Environment.NewLine + content);
            }
        }


        public static T DecodeJson<T>(string content) where T : new()
        {

            if (content == null)
            {
                return default(T);
            }

            try
            {
                return JsonConvert.DeserializeObject<T>(content);
            }
            catch (JsonReaderException jex)
            {
            
                throw new SmartPaymentException("Json string is not in correct format: " + Environment.NewLine + jex.Message + Environment.NewLine + content);
            }
            catch (JsonException jex)
            {
                throw new SmartPaymentException("Json string is not in correct format: " + Environment.NewLine + jex.Message);
            }

        }
    }
}
