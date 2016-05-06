Feature: UsdaApiList
	In order to be informed on what USDA Api is providing
	As a customer
	I want to be get a list of foods

@mytag
Scenario: Get list of foods
	Given I setup "eIQTHeqjEITpxwy1AcdHXijwJFRwI8WDSasId5pK" as an API key
	And I setup "http://api.nal.usda.gov/ndb/list" as an API URL
	When I query the API for a list of "f"
	Then the result should show a list of foods on the screen

Scenario: Get list of nutrients
	Given I setup "eIQTHeqjEITpxwy1AcdHXijwJFRwI8WDSasId5pK" as an API key
	And I setup "http://api.nal.usda.gov/ndb/list" as an API URL
	When I query the API for a list of "n"
	Then the result should be a list of nutrients