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
    public class UsdaApiClientService : IApiClientService<SearchQuery, SearchResult>
    {
        public async Task<SearchResult> Search(SearchQuery query)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes("eIQTHeqjEITpxwy1AcdHXijwJFRwI8WDSasId5pK:")));

                var json = JsonConvert.SerializeObject(query);
                var content = new StringContent(json);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await client.PostAsync("http://api.nal.usda.gov/ndb/search", content);

                if (!response.IsSuccessStatusCode)
                    throw new ApplicationException(
                        $"Error while requesting API: status {response.StatusCode}, response: {await response.Content.ReadAsStringAsync()}");

                var str = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<SearchResult>(str);
            }
        }
    }
}
