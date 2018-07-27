Feature: AvivaGoogleSearch

Scenario: GoogleAvivaSearchPositive
	Given I want to use the Google Search Engine
	When I search for "Aviva"
	Then I expect "11" link results on the first page
	Then I print link "5"
	Then I expect a result greater than "26200000"

Scenario: GoogleAvivaSearchNegative
	Given I want to use the Google Search Engine
	When I search for "@\/|\/@"
	Then I expect a no search results returned