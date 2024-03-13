@CHROME
Feature: Auto Complete Functionality

Background:
    Given I am on the "Auto Complete" page

Scenario: 1.1 AutoComplete suggestions for color names starting with 'g'
	Given I enter the letter 'g' in the Type multiple color names field
        And I should see three AutoComplete suggestions containing 'g'

Scenario: 1.2 Adding multiple colors
    Given I add the colors Red, Yellow, Green, Blue, and Purple
        And I should see the following colors in the field: Red, Yellow, Green, Blue, Purple
    When I delete the colors Yellow and Purple
    Then I should see the following colors remaining in the field: Red, Green, Blue