# smartpaymentclientnet
.NET 3.5 library for SmartPayment POS driver integration


Created with Visual Studio 16.3 and target the .NET 3.5 Framework.
It depends on RestSharp and Newtonsoft.Json


**Examples**:

```c#
  try
            {

                var client = new SmartPaymentClient("https://1.2.3.4:8080");
                var devices = client.GetAllDevices();

                Console.WriteLine("Trying to get all the devices connected...\r\n");

                foreach (DeviceWithValidation device in devices)
                {
                    Console.WriteLine("----------------------------------\r\n");
                    Console.WriteLine("Device: \r\n" + device.ToString());
                }

                Console.WriteLine("----------------------------------\r\n");
                Console.WriteLine("Sale 0.50 lei:\r\n");


                //trying to get first device from device list
                //It assumed that the first device is valid
                var deviceUuid = devices[0].Uuid;
             

                //
                //SALE
                //
                var sr = new SaleRequest();
                sr.Amount = 0.50m; //0.50 lei
                sr.CurrencyName = "RON";
                sr.CashBackAmount = 0.00m;   //optional
                sr.TransactionEcrUuid = "";  //optional
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
```

