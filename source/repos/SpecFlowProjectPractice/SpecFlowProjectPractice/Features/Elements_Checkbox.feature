@CHROME
Feature: CheckBox Interaction

Background: 
	Given I am on the "Check Box" page

Scenario: Select specific items from a tree structure
    Given I expand the "Home" folder
    When I select the Desktop folder without expanding
    Then I select Angular and Veu from the Workspace folder
        And I expand and click each item in the Office folder
        And I select the Downloads folder
    Then I verify the selected items are "You have selected : desktop notes commands angular veu office public private classified general downloads wordFile excelFile"