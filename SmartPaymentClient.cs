using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using SmartPaymentClientNet.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;

namespace SmartPaymentClientNet
{
    public class SmartPaymentClient
    {

        private IWebProxy _httpProxy;
        /// <summary>
        /// Timeout-ul de request in milliseconds, default value 5 minutes.
        /// </summary>
        public int Timeout { get; set; } = 300000;
        public Uri BaseUrl { get; set; }
        public string UserAgent { get; set; }
        public IWebProxy HttpProxy
        {
            get { return _httpProxy; }
            set
            {
                _httpProxy = value;
                this._clientHttp.Proxy = _httpProxy;
            }
        }
        //
        private RestClient _clientHttp;

        private void createHttpClient(string baseUrl, IAuthenticator auth)
        {
            this.BaseUrl = new Uri(baseUrl);
            this.UserAgent = "SmartPaymentNet35/" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
            if (this._clientHttp == null)
            {
                this._clientHttp = new RestClient(this.BaseUrl);
                this._clientHttp.UserAgent = this.UserAgent;
                this._clientHttp.Timeout = this.Timeout;

                if (auth != null)
                {
                    this._clientHttp.Authenticator = auth;
                }
            }
        }



        public SmartPaymentClient(string baseUrl)
        {
            if (string.IsNullOrEmpty(baseUrl))
            {
                throw new SmartPaymentException("Base URL not specified");
            }

            createHttpClient(baseUrl, null);
        }


        public SmartPaymentClient(string baseUrl, string username, string password)
        {
            if (string.IsNullOrEmpty(baseUrl))
            {
                throw new SmartPaymentException("Base URL not specified");
            }

            if (string.IsNullOrEmpty(username))
            {
                throw new SmartPaymentException("Username not specified");
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new SmartPaymentException("Password not specified");
            }

            createHttpClient(baseUrl, new HttpBasicAuthenticator(username, password));
        }



        //public functions 


        #region CONFIG ENDPOINTS

        public WebService GetWebServiceConfig()
        {
            var request = new RestRequest("config/webservice", Method.GET);
            var response = _clientHttp.Execute(request);


            if (response.ErrorException != null)
            {
                throw new SmartPaymentException(response.ErrorException.Message);
            }

            var content = response.Content;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonUtils.DecodeJson<WebService>(content);
            }
            else
            {
                throw ProcessWebServiceException(content);
            }
        }

        public bool SaveWebServiceConfig(WebService ws)
        {
            var request = new RestRequest("config/webservice", Method.PUT);
            request.AddJsonBody(ws);
            var response = _clientHttp.Execute(request);


            if (response.ErrorException != null)
            {
                throw new SmartPaymentException(response.ErrorException.Message);
            }


            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                throw ProcessWebServiceException(response.Content);
            }

        }

        public List<DeviceWithValidation> GetAllDevices()
        {
            var request = new RestRequest("config/devices", Method.GET);
            var response = _clientHttp.Execute(request);


            if (response.ErrorException != null)
            {
                throw new SmartPaymentException(response.ErrorException.Message);
            }

            var content = response.Content;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonUtils.DecodeJson<List<DeviceWithValidation>>(content);
            }
            else
            {
                throw ProcessWebServiceException(content);
            }

        }

        public bool AddNewDevice(Device device)
        {
            var request = new RestRequest("config/devices", Method.POST);
            request.AddJsonBody(device);
            var response = _clientHttp.Execute(request);


            if (response.ErrorException != null)
            {
                throw new SmartPaymentException(response.ErrorException.Message);
            }


            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                throw ProcessWebServiceException(response.Content);
            }

        }

        public bool DeleteDevice(string uuid)
        {

            if (string.IsNullOrEmpty(uuid))
            {
                throw new SmartPaymentException("Uuid for deleting device not specified!");
            }


            var request = new RestRequest("config/devices", Method.DELETE);
            request.AddQueryParameter("uuid", uuid);
            var response = _clientHttp.Execute(request);


            if (response.ErrorException != null)
            {
                throw new SmartPaymentException(response.ErrorException.Message);
            }


            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                throw ProcessWebServiceException(response.Content);
            }
        }

        #endregion




        #region GENERAL ENDPOINTS

        public About GetAboutInfo()
        {
            var request = new RestRequest("about", Method.GET);
            var response = _clientHttp.Execute(request);


            if (response.ErrorException != null)
            {
                throw new SmartPaymentException(response.ErrorException.Message);
            }

            var content = response.Content;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonUtils.DecodeJson<About>(content);
            }
            else
            {
                throw ProcessWebServiceException(content);
            }

        }

        public List<DeviceType> GetAllBanksSupported()
        {

            var request = new RestRequest("banks", Method.GET);
            var response = _clientHttp.Execute(request);


            if (response.ErrorException != null)
            {
                throw new SmartPaymentException(response.ErrorException.Message);
            }

            var content = response.Content;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonUtils.DecodeJson<List<DeviceType>>(content);
            }
            else
            {
                throw ProcessWebServiceException(content);
            }
        }

        public List<AccessLog> GetAccessLogs()
        {
            var request = new RestRequest("logs/access", Method.GET);
            var response = _clientHttp.Execute(request);


            if (response.ErrorException != null)
            {
                throw new SmartPaymentException(response.ErrorException.Message);
            }

            var content = response.Content;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonUtils.DecodeJson<List<AccessLog>>(content);
            }
            else
            {
                throw ProcessWebServiceException(content);
            }
        }

        public List<ApplicationLog> GetApplicationLogs()
        {
            var request = new RestRequest("logs", Method.GET);
            var response = _clientHttp.Execute(request);


            if (response.ErrorException != null)
            {
                throw new SmartPaymentException(response.ErrorException.Message);
            }

            var content = response.Content;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonUtils.DecodeJson<List<ApplicationLog>>(content);
            }
            else
            {
                throw ProcessWebServiceException(content);
            }
        }

        public List<DeviceWithStatus> GetAllDevicesWithStatus()
        {
            var request = new RestRequest("status", Method.GET);
            var response = _clientHttp.Execute(request);

            if (response.ErrorException != null)
            {
                throw new SmartPaymentException(response.ErrorException.Message);
            }

            var content = response.Content;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonUtils.DecodeJson<List<DeviceWithStatus>>(content);
            }
            else
            {
                throw ProcessWebServiceException(content);
            }
        }

        #endregion



        #region POS ACTION ENDPOINTS

        public SaleResponse Sale(string deviceUuid, SaleRequest saleRequest)
        {

            var request = new RestRequest("sale", Method.POST);
            request.AddQueryParameter("uuid", deviceUuid);
            request.AddJsonBody(saleRequest);
            var response = _clientHttp.Execute(request);


            if (response.ErrorException != null)
            {
                throw new SmartPaymentException(response.ErrorException.Message);
            }

            var content = response.Content;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonUtils.DecodeJson<SaleResponse>(content);
            }
            else
            {
                throw ProcessWebServiceException(content);
            }
        }

        public SaleResponse SaleVoid(string deviceUuid, SaleVoidRequest saleVoidRequest)
        {

            var request = new RestRequest("sale/void", Method.POST);
            request.AddQueryParameter("uuid", deviceUuid);
            request.AddJsonBody(saleVoidRequest);
            var response = _clientHttp.Execute(request);


            if (response.ErrorException != null)
            {
                throw new SmartPaymentException(response.ErrorException.Message);
            }

            var content = response.Content;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonUtils.DecodeJson<SaleResponse>(content);
            }
            else
            {
                throw ProcessWebServiceException(content);
            }
        }

        public SaleResponse SalePreauthorization(string deviceUuid, SalePreauthorizationRequest salePreauthorizationRequest)
        {

            var request = new RestRequest("sale/preauthorization", Method.POST);
            request.AddQueryParameter("uuid", deviceUuid);
            request.AddJsonBody(salePreauthorizationRequest);
            var response = _clientHttp.Execute(request);


            if (response.ErrorException != null)
            {
                throw new SmartPaymentException(response.ErrorException.Message);
            }

            var content = response.Content;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonUtils.DecodeJson<SaleResponse>(content);
            }
            else
            {
                throw ProcessWebServiceException(content);
            }
        }

        public SaleResponse SaleCompletion(string deviceUuid, SaleCompletionRequest saleCompletionRequest)
        {

            var request = new RestRequest("sale/completion", Method.POST);
            request.AddQueryParameter("uuid", deviceUuid);
            request.AddJsonBody(saleCompletionRequest);
            var response = _clientHttp.Execute(request);


            if (response.ErrorException != null)
            {
                throw new SmartPaymentException(response.ErrorException.Message);
            }

            var content = response.Content;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonUtils.DecodeJson<SaleResponse>(content);
            }
            else
            {
                throw ProcessWebServiceException(content);
            }
        }

        public SaleOfflineSyncResponse SaleOfflineSync(string deviceUuid, string currencyName)
        {

            var request = new RestRequest("sale/offline/sync", Method.POST);
            request.AddQueryParameter("uuid", deviceUuid);
            request.AddQueryParameter("currency", currencyName);

            var response = _clientHttp.Execute(request);


            if (response.ErrorException != null)
            {
                throw new SmartPaymentException(response.ErrorException.Message);
            }

            var content = response.Content;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonUtils.DecodeJson<SaleOfflineSyncResponse>(content);
            }
            else
            {
                throw ProcessWebServiceException(content);
            }
        }

        public CashBackResponse CashBackStatus(string deviceUuid, CashBackRequest cashBackRequest)
        {

            var request = new RestRequest("cashback/status", Method.POST);
            request.AddQueryParameter("uuid", deviceUuid);
            request.AddJsonBody(cashBackRequest);

            var response = _clientHttp.Execute(request);


            if (response.ErrorException != null)
            {
                throw new SmartPaymentException(response.ErrorException.Message);
            }

            var content = response.Content;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonUtils.DecodeJson<CashBackResponse>(content);
            }
            else
            {
                throw ProcessWebServiceException(content);
            }
        }



        public SettlementResponse PrintSettlement(string deviceUuid, SettlementRequest settlementRequest)
        {

            var request = new RestRequest("report/settlement", Method.POST);
            request.AddQueryParameter("uuid", deviceUuid);
            request.AddJsonBody(settlementRequest);
            var response = _clientHttp.Execute(request);


            if (response.ErrorException != null)
            {
                throw new SmartPaymentException(response.ErrorException.Message);
            }

            var content = response.Content;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonUtils.DecodeJson<SettlementResponse>(content);
            }
            else
            {
                throw ProcessWebServiceException(content);
            }

        }

        public SaleSummaryResponse GetSaleSummaryReport(string deviceUuid, string currencyName)
        {

            var request = new RestRequest("report/summary", Method.GET);
            request.AddQueryParameter("uuid", deviceUuid);
            request.AddQueryParameter("currency", currencyName);
            var response = _clientHttp.Execute(request);


            if (response.ErrorException != null)
            {
                throw new SmartPaymentException(response.ErrorException.Message);
            }

            var content = response.Content;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonUtils.DecodeJson<SaleSummaryResponse>(content);
            }
            else
            {
                throw ProcessWebServiceException(content);
            }

        }

        public SaleDetailsResponse GetSaleDetailsReport(string deviceUuid, int transactionId)
        {

            var request = new RestRequest("report/details", Method.GET);
            request.AddQueryParameter("uuid", deviceUuid);
            request.AddQueryParameter("transaction_id", transactionId.ToString());
            var response = _clientHttp.Execute(request);


            if (response.ErrorException != null)
            {
                throw new SmartPaymentException(response.ErrorException.Message);
            }

            var content = response.Content;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonUtils.DecodeJson<SaleDetailsResponse>(content);
            }
            else
            {
                throw ProcessWebServiceException(content);
            }

        }

        public DeviceInfo GetDeviceInfo(string deviceUuid)
        {

            var request = new RestRequest("device/info", Method.GET);
            request.AddQueryParameter("uuid", deviceUuid);
            var response = _clientHttp.Execute(request);


            if (response.ErrorException != null)
            {
                throw new SmartPaymentException(response.ErrorException.Message);
            }

            var content = response.Content;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonUtils.DecodeJson<DeviceInfo>(content);
            }
            else
            {
                throw ProcessWebServiceException(content);
            }

        }


        //partea de sse events => get /events
        public List<String> GetSseEvents()
        {
            throw new NotImplementedException();
        }

        #endregion





        /// <summary>
        /// Functie de transformare a erorii primite din webservice in eroare de librarie
        /// </summary>
        /// <param name="exceptionContent">Eroarea json primita de la webservice</param>
        /// <returns></returns>
        private SmartPaymentException ProcessWebServiceException(string exceptionContent)
        {

            try
            {
                var wse = JsonUtils.DecodeJson<WebServiceError>(exceptionContent);
                if (wse != null)
                {
                    return new SmartPaymentException(wse.statusCode, wse.errorMessage, wse.errorType);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Decode error: " + ex.StackTrace);
            }

            return new SmartPaymentException(exceptionContent);
        }

    }
}
