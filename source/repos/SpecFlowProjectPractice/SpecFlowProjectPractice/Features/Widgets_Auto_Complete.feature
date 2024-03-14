@CHROME
Feature: Auto Complete Color's manipulation

Background:
    Given I am on the "Auto Complete" page

Scenario: 1.1 AutoComplete suggestions for color names starting with 'g'
	When The user enters the letter 'g' in the Type multiple color names field
    Then Three suggestions containing 'g' should be displayed.

Scenario: 1.2 Adding multiple colors
    Given The following colors displayed in the field: Red, Yellow, Green, Blue, and Purple
    When I am removing the colors Yellow and Purple
    Then I should see the following colors remaining in the field: Red, Green, Blue