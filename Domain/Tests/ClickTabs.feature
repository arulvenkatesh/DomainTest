Feature: ClickTabs
Verify the all pages are loaded successfully when each tabs in the domain home page is clicked.

@DomainTestCases
Scenario Outline: Click and verify successful loading for tabs.
	Given Open the home page in chrome bowser.
	And I click on the tab <Tab_Name>.	
	Then The page should be successfully loaded with title <Title>.

Examples:
| Id | TestCaseName | Tab_Name   | Title                                                                                              |
| 1  | TC_001       | Buy        | Buy Houses, Apartments, Units, Flats and New Developments \| Real Estate \| Domain                 |
| 2  | TC_002       | Rent       | Rent Houses, Apartments, Units, Flats and New Developments \| Real Estate \| Domain                |
| 3  | TC_003       | New Homes  | New Homes \| Home & Land Packages \| Off the Plan Apartments                                       |
| 4  | TC_004       | Sold       | Sold Houses, Apartments, Units, Flats and New Developments \| Real Estate \| Domain                |
| 5  | TC_005       | News       | News – Domain                                                                                      |
| 6  | TC_006       | Advice     | Advice – Domain                                                                                    |
| 7  | TC_007       | Agents     | Search for real estate agents to sell your property in Australia                                   |
| 8  | TC_008       | Commercial | Commercial Real Estate and Property For Sale and Lease in Australia \| CommercialRealEstate.com.au |
