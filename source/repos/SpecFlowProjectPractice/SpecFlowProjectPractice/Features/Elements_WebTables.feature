Feature: Web Tables Functionality
	Background:
		Given I am on the "Web Tables" page
	@CHROME
	Scenario: Sort and delete data in Web Tables
	When I click the "Salary" column
	Then I verify the values in the "Salary" column are in ascending order
		And I delete the second row name Alden
		And I verify there are only two rows left in the table
	Then I verify that there is no "Compliance" value among the values in the "Department" column