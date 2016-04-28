Feature: UsdaApiSearch
	In order to get list of available foods
	As an API user
	I want to get food list result on a given keyword

@mytag
Scenario: Search food with keyword
	Given I setup "eIQTHeqjEITpxwy1AcdHXijwJFRwI8WDSasId5pK" as an API key
	And I setup "http://api.nal.usda.gov/ndb/search" as an API URL
	When I search "{ "q":"banana" }" with the API
	Then the result should be a list on the screen
