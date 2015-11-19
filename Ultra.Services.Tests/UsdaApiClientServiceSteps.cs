using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using TechTalk.SpecFlow;
using Ultra.DomainModel;

namespace Ultra.Services.Tests
{
    [Binding]
    public class UsdaApiClientServiceSteps
    {
        private UsdaApiClientService _service = new UsdaApiClientService();
        private string _result;

        [Given(@"I setup ""(.*)"" as an API key")]
        public void GivenISetupAsAnAPIKey(string apiKey)
        {
            _service.ApiKey = apiKey;
        }

        [Given(@"I setup ""(.*)"" as an API URL")]
        public void GivenISetupAsAnAPIURL(string apiUrl)
        {
            _service.ApiUrl = apiUrl;
        }

        [When(@"I have search ""(.*)"" with the API")]
        public void WhenIHaveSearchWithTheAPI(string query)
        {
            _result = _service.Search(query).Result;
        }

        [Then(@"the result should be a list on the screen")]
        public void ThenTheResultShouldBeAListOnTheScreen()
        {
            var searchResult = JsonConvert.DeserializeObject<SearchResult>(_result);
            Assert.IsNotNull(searchResult);
        }
    }
}
