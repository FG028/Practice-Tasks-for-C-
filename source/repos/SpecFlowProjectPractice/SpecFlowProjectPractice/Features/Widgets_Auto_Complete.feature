Feature: Auto Complete Functionality
	@CHROME
	Scenario: Filter and select colors in Auto Complete
		Given I am on the "Auto Complete" page

	When I enter the letter 'g' in the Type multiple color names field
    Then I should see three AutoComplete suggestions containing 'g'
        And I add the colors Red, Yellow, Green, Blue, and Purple
    Then I should see the following colors in the field: Red, Yellow, Green, Blue, Purple
    Then I delete the colors Yellow and Purple
        And I should see the following colors remaining in the field: Red, Green, Blue