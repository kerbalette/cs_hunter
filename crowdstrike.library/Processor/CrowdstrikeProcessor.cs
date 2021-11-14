using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using crowdstrike.library.Helpers;
using crowdstrike.library.Model;
using System.Text.Json;
using Microsoft.VisualBasic;

namespace crowdstrike.library.Processor
{
    public class CrowdstrikeProcessor
    {
        private ApiHelper _apiHelper;
        public string BaseUrl { get; set; }

        public CrowdstrikeProcessor(string baseUrl, string proxy)
        {
            this.BaseUrl = baseUrl;
            if (proxy == "")
                _apiHelper = new ApiHelper();
            else
                _apiHelper = new ApiHelper(proxy);
            
            _apiHelper.InitialiseClient();
        }
        
        public async Task<Token> Authenticate(string client_id, string client_secret)
        {
            string url = BaseUrl + "/oauth2/token";
            oAuth2 auth = new oAuth2();
            auth.client_id = client_id;
            auth.client_secret = client_secret;
            var formData = new FormUrlEncodedContent(auth.ToKeyValue());
            using (HttpResponseMessage responseMessage = await _apiHelper.ApiClient.PostAsync(url, formData))
            {
                if (responseMessage.IsSuccessStatusCode)
                {
                    Token token = await responseMessage.Content.ReadAsAsync<Token>();
                    Console.Write(token.access_token);
                    return token;
                }
                else
                {
                    throw new Exception(responseMessage.ReasonPhrase);
                }
            }
        }
    }
}