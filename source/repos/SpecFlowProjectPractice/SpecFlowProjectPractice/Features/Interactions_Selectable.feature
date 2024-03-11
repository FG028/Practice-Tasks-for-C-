Feature: Selectable Functionality
	@CHROME
	Scenario: Select squares and verify values
	Given I am on the "Selectable" page
	When I switch to the Grid tab
    Then I select squares 1, 3, 5, 7, and 9
    Then the selected squares should display One, Three, Five, Seven, and Nine