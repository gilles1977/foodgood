using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using Ultra.DomainModel;

namespace Ultra.Services.Tests
{
    [Binding]
    public class UsdaApiSteps
    {
        private UsdaApiClientService _service = new UsdaApiClientService();
        private string _result;

        [Given(@"I setup ""(.*)"" as an API key")]
        public void GivenISetupAsAnApiKey(string apiKey)
        {
            _service.ApiKey = apiKey;
        }

        [Given(@"I setup ""(.*)"" as an API URL")]
        public void GivenISetupAsAnApiurl(string apiUrl)
        {
            _service.ApiUrl = apiUrl;
        }

        [When(@"I search ""(.*)"" with the API")]
        public void WhenISearchWithTheApi(string query)
        {
            _result = _service.Search(query).Result;
        }
        
        [Then(@"the result should be a list on the screen")]
        public void ThenTheResultShouldBeAListOnTheScreen()
        {
            var searchResult = JsonConvert.DeserializeObject<SearchResult>(_result);
            Assert.IsNotNull(searchResult);
            Assert.IsNotNull(searchResult.Result);
            Assert.IsNotNull(searchResult.Result.Q);
            Assert.IsNotNull(searchResult.Result.Group);
            Assert.IsNotNull(searchResult.Result.Item);
            Assert.IsTrue(searchResult.Result.Item.Count > 0);
        }

        [When(@"I query the API for the nutrients ""(.*)"" and ""(.*)"" and for food group ""(.*)""")]
        public void WhenIQueryTheAPIForTheNutrientsAndAndForFoodGroup(string nutrient1, string nutrient2, string foodGroup)
        {
            var query = new NutrientReportQuery()
            { Nutrients = new List<String>() { nutrient1, nutrient2 }, FoodGroup = foodGroup, Max = 50, Offset = 0 };
            _result = _service.GetNutrientReport(query).Result;
        }
                
        [Then(@"the result should be a report of nutrients")]
        public void ThenTheResultShouldBeAReportOfNutrients()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            //settings.ContractResolver = new DataContract
            var nutrientReport = JsonConvert.DeserializeObject<NutrientReportResult>(_result);
            Assert.IsNotNull(nutrientReport);
        }
    }
}
