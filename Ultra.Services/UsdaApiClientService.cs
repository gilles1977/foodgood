﻿using Newtonsoft.Json;
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
        public UsdaApiClientService() : this("", "")
        {
        }

        public UsdaApiClientService(string apiKey, string apiUrl)
        {
            ApiKey = apiKey;
            ApiUrl = apiUrl;
            Proxy = WebRequest.GetSystemWebProxy();
            Proxy.Credentials = CredentialCache.DefaultNetworkCredentials;

        }

        public string ApiKey { get; set; }
        public string ApiUrl { get; set; }
        public IWebProxy Proxy { get; set; }

        public async Task<string> Search(string query)
        {
            var searchQuery = JsonConvert.DeserializeObject<SearchQuery>(query);
                //new SearchQuery() { Q = query, Fg = FoodGroup, Max = MaxResults.ToString(), Offset = Offset.ToString(), Sort = SortType };

            return await Search(searchQuery);
        }

        public async Task<string> Search(SearchQuery query)
        {
            using (var client = GetHttpClient())
            {
                var response = await client.PostAsync(ApiUrl, GetContent(query));

                return await ProcessResponse(response);
            }
        }

        public async Task<string> GetNutrientReport(NutrientReportQuery query)
        {
            using (var client = GetHttpClient())
            {
                var response = await client.PostAsync(ApiUrl, GetContent(query));

                return await ProcessResponse(response);
            }
        }

        private HttpClient GetHttpClient()
        {
            var client = new HttpClient(new HttpClientHandler() {Proxy = Proxy});
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(ApiKey + ":")));
            return client;
        }

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
