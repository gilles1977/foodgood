Feature: UsdaApiNutrientReport
	In order to be informed on what I'm eating
	As a customer
	I want to be get a report on nutrients of a food

@mytag
Scenario: Get nutrient report for a food
	Given I setup "eIQTHeqjEITpxwy1AcdHXijwJFRwI8WDSasId5pK" as an API key
	And I setup "http://api.nal.usda.gov/ndb/nutrients" as an API URL
	When I query the API for the nutrients "203" and "204" and for food group "8"
	Then the result should be a report of nutrients
