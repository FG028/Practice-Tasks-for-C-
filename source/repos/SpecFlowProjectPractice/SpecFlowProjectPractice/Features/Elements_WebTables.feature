Feature: Web Tables Functionality
	Background:
		Given I am on the "Web Tables" page
	@CHROME
	Scenario: Verify Salary sorting and row deletion
	When I click on the Salary column
    Then the values in the Salary column should be in ascending order
        And I delete the second row
    Then there should be only two rows left in the table
        And there should be no "Compliance" value among the values in the Department column