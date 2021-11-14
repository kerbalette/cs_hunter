using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security;

namespace crowdstrike.library.Helpers
{
    public class ApiHelper
    {
        public HttpClient ApiClient { get; set; }

        private readonly WebProxy _webProxy;
        private readonly HttpClientHandler _httpClientHandler;
        private static ApiHelper _instance = null;

        public static ApiHelper Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ApiHelper();
                }

                return _instance;
            }
        }


        public ApiHelper()
        {
            _httpClientHandler = new HttpClientHandler();
            _httpClientHandler.AllowAutoRedirect = true;
            _httpClientHandler.UseProxy = false;
        }

        public ApiHelper(string proxyUri)
        {
            _httpClientHandler = new HttpClientHandler();
            _httpClientHandler.AllowAutoRedirect = true;
            _httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
            
            _webProxy = new WebProxy(new Uri(proxyUri));
            _httpClientHandler.UseProxy = true;
            _httpClientHandler.Proxy = _webProxy;
        }
        
        public void InitialiseClient()
        {
            ApiClient = new HttpClient(_httpClientHandler);
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}