Feature: Selectable Functionality
	@CHROME
	Scenario: Select squares and verify values
	Given I am on the "Selectable" page
	When I select squares "1, 3, 5, 7, 9"
	Then I verify the selected squares' values are "One, Three, Five, Seven, and Nine"