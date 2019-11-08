using SmartPaymentClientNet;
using SmartPaymentClientNet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartPaymentClientDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            var url = "http://127.0.0.1:8090";

            //for http proxy 
            //var proxyObject = new System.Net.WebProxy();
            //proxyObject.Address = new Uri("https://1.2.3.4:8080");


            Console.WriteLine("Client trying to connect to " + url + "...");

            try
            {

                var client = new SmartPaymentClient(url);
                //client.HttpProxy = proxyObject;


                var devices = client.GetAllDevices();


                Console.WriteLine("Trying to get all the devices...\r\n");

                foreach (DeviceWithValidation device in devices)
                {
                    Console.WriteLine("----------------------------------\r\n");
                    Console.WriteLine("Device: \r\n" + device.ToString());
                }

                Console.WriteLine("----------------------------------\r\n");
                Console.WriteLine("Web service config:\r\n");

                var webserviceConfig = client.GetWebServiceConfig();
                Console.WriteLine(webserviceConfig.ToString());


                Console.WriteLine("----------------------------------\r\n");
                Console.WriteLine("Sale 0.50 lei:\r\n");


                //trying to get first device from device list
                var deviceUuid = "";
                if (devices.Count > 0)
                {
                    //extract the first valid device from list
                    foreach (DeviceWithValidation dev in devices)
                    {
                        if (dev.IsValid)
                        {
                            deviceUuid = devices[0].Uuid;
                            break;
                        }
                    }
                }


                if (string.IsNullOrEmpty(deviceUuid))
                {
                    Console.WriteLine("Device uuid is not specified!");
                    return;
                }

                //
                //SALE
                //
                var sr = new SaleRequest();
                sr.Amount = 0.50m;
                sr.CurrencyName = "RON";
                sr.CashBackAmount = 0.00m;//optional
                sr.TransactionEcrUuid = "";//optional
                sr.PrintReceiptOnEcr = false;//optional


                var saleResponse = client.Sale(deviceUuid, sr);
                Console.WriteLine("Sale response:\r\n");
                Console.WriteLine(saleResponse.ToString());

                //if the sale was successful 
                if (saleResponse.CardHostApprovedTransaction)
                {
                    //
                    //SALE VOID
                    //
                    var sv = new SaleVoidRequest();
                    sv.Amount = 0.50m;
                    sv.CurrencyName = "RON";
                    sv.AuthorizationCode = saleResponse.AuthorizationCode;
                    sv.ReceiptNumber = saleResponse.ReceiptNumber;
                    sv.ReturnReferenceNumber = saleResponse.ReturnReferenceNumber;


                    var saleVoidResponse = client.SaleVoid(deviceUuid, sv);
                    Console.WriteLine("Sale void response:\r\n");
                    Console.WriteLine(saleVoidResponse.ToString());

                    //if the sale void was approved we launch the settlement report
                    if (saleVoidResponse.CardHostApprovedTransaction)
                    {

                        var settlementRequest = new SettlementRequest();
                        settlementRequest.CurrencyName = "RON";


                        var settlementResponse = client.PrintSettlement(deviceUuid, settlementRequest);
                        Console.WriteLine("Settlement response:\r\n");
                        Console.WriteLine(settlementResponse.ToString());
                    }

                }
    
            }
            catch (SmartPaymentException ex)
            {
                Console.WriteLine("Error received: \r\n");
                Console.WriteLine(ex.ToString());
            }


            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }
    }
}
