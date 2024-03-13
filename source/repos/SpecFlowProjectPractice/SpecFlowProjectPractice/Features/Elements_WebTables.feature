@CHROME
Feature: Web Tables Functionality

Background:
	Given I am on the "Web Tables" page

Scenario: Verify Salary sorting and row deletion
	Given I click on the Salary column
        And the values in the Salary column should be in ascending order
    When I delete the second row
    Then there should be only two rows left in the table
        And there should be no "Compliance" value among the values in the Department column