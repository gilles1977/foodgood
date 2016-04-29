using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Ultra.DomainModel;
using Ultra.Services.Contracts;

namespace Ultra.Services
{
    public class UsdaApiClientService : IApiClientService
    {
        private HttpClient _httpClient;
        private string _apiKey;

        public UsdaApiClientService() : this("", "")
        {
        }

        public UsdaApiClientService(string apiKey, string apiUrl)
        {
            Proxy = WebRequest.GetSystemWebProxy();
            Proxy.Credentials = CredentialCache.DefaultNetworkCredentials;
            _httpClient = new HttpClient(new HttpClientHandler() { Proxy = Proxy });
            ApiKey = apiKey;
            ApiUrl = apiUrl;
        }

        public string ApiKey
        {
            get { return _apiKey; }
            set
            {
                _apiKey = value;
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(value + ":")));
            }
        }
        public string ApiUrl { get; set; }
        public IWebProxy Proxy { get; set; }

        public async Task<string> Search(string query)
        {
            try
            {
                var searchQuery = JsonConvert.DeserializeObject<SearchQuery>(query);

                return await Search(searchQuery);
            }
            catch (JsonSerializationException ex)
            {
                //TODO logging
                throw;
            }
        }

        public async Task<string> Search(SearchQuery query)
        {
            var response = await _httpClient.PostAsync(ApiUrl, GetContent(query));

            return await ProcessResponse(response);
        }

        public async Task<string> GetNutrientReport(NutrientReportQuery query)
        {
            var response = await _httpClient.PostAsync(ApiUrl, GetContent(query));

            return await ProcessResponse(response);
        }

        //private HttpClient GetHttpClient()
        //{
        //    var client = new HttpClient(new HttpClientHandler() {Proxy = Proxy});
        //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(ApiKey + ":")));
        //    return client;
        //}

        private HttpContent GetContent<T>(T query)
        {
            var json = JsonConvert.SerializeObject(query);
            var content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return content;
        }

        private async Task<string> ProcessResponse(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
                throw new ApplicationException(
                    $"Error while requesting API: status {response.StatusCode}, response: {await response.Content.ReadAsStringAsync()}");

            var str = await response.Content.ReadAsStringAsync();

            return str;
        }
    }
}
