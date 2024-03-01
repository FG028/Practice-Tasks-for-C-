Feature: Auto Complete Functionality
	@CHROME
	Scenario: Filter and select colors in Auto Complete
		Given I am on the "Auto Complete" page

	When I enter the letter "g" in the "Type multiple color names" field
	Then I verify the AutoComplete offers three variants, all containing "g"
	
	Then I enter "Red, Yellow, Green, Blue, Purple" in the "Type multiple color names" field
		And I delete "Yellow" and "Purple"
	Then I should see only "Red", "Green", and "Blue" in the field