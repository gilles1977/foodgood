using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public UsdaApiClientService() : this("", "", "", "r", 50, 0)
        {
        }

        public UsdaApiClientService(string apiKey, string apiUrl, string foodGroup, string sortType, int maxResults, int offset)
        {
            ApiKey = apiKey;
            ApiUrl = apiUrl;
            FoodGroup = foodGroup;
            SortType = sortType;
            MaxResults = maxResults;
            Offset = offset;
        }

        public string ApiKey { get; set; }
        public string ApiUrl { get; set; }
        public string FoodGroup { get; set; }
        public string SortType { get; set; }
        public int MaxResults { get; set; }
        public int Offset { get; set; }

        public async Task<string> Search(string query)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(ApiKey+":")));

                var search = new SearchQuery() { Q = query, Fg = FoodGroup, Max = MaxResults.ToString(), Offset = Offset.ToString(), Sort = SortType };
                var json = JsonConvert.SerializeObject(search);
                var content = new StringContent(json);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await client.PostAsync(ApiUrl, content);

                if (!response.IsSuccessStatusCode)
                    throw new ApplicationException(
                        $"Error while requesting API: status {response.StatusCode}, response: {await response.Content.ReadAsStringAsync()}");

                var str = await response.Content.ReadAsStringAsync();

                return str;
            }
        }
    }
}
