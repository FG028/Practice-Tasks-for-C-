Feature: Auto Complete Functionality
	Scenario: Filter and select colors in Auto Complete
		Given I am on the "Auto Complete" page

	When I enter the letter "g" in the "Type multiple color names" field
	Then I verify the autocomplete offers three variants, all containing "g"
	
	When I enter "Red, Yellow, Green, Blue, Purple" in the "Type multiple color names" field
	Then I delete "Yellow" and "Purple"
	Then I verify the selected value in the field is "Red, Green, Blue"