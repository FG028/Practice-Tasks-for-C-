    Feature: Checkbox Interaction
	Background: 
	Given I am on the "Check Box" page
	@CHROME

	Scenario: Select specific items from a tree structure
    When I expand the "Home" folder
    Then I select the "Desktop" folder without expanding
        And I select "Angular" and "Veu" from the "Workspace" folder
        And I expand and click each item in the "Office" folder
        And I select the "Downloads" folder
    Then I verify the selected items are "desktop notes commands angular veu office public private classified general downloads wordFile excelFile"