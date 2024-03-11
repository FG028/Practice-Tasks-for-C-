Feature: Selectable Functionality
	Background: 
	Given I am on the "Selectable" page

	Scenario: Select squares and verify values
	Given I switch to the Grid tab
    When I select squares 1, 3, 5, 7, and 9
    Then the selected squares should display One, Three, Five, Seven, and Nine