	Feature: Check Box Functionality
	
	Background: 
	Given I am on the "Check Box" page
	
	Scenario: Select and verify checkboxes
	When I select the following checkboxes:
	
	| Item        |
	|-----------  |
	| Home folder |
	| Angular     |
	| Veu         |
	| Office      |
	| Downloads   |
	
	Then I verify the output is "You have selected : desktop notes commands angular veu office public private classified general downloads wordFile excelFile"