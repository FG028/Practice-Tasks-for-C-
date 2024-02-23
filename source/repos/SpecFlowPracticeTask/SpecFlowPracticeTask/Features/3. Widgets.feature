Feature: 3. Interact with interactive widgets on DemoQA

Scenario: 3.1. Verify Auto Complete suggestions for letter 'g'
    Given I am on the DemoQA page "https://demoqa.com/auto-complete"
        And I navigate to the "Widgets" category and "Auto Complete" section
    When I enter the letter "g" in the "Type multiple color names" field
    Then I should see 3 unique color suggestions containing the letter "g"
        And I should see no duplicate colors in the field
    Then I delete "Yellow" and "Purple"
        And I should see only "Red", "Green", and "Blue" in the field

Scenario: 3.2. Start, wait, reset, and verify progress bar
    Given I am on the DemoQA page "https://demoqa.com/progress-bar"
        And I navigate to the "Widgets" category and "Progress Bar" section
    Then I click the "Start" button
        And I wait until the progress bar reaches 100%
        And I verify that the button text becomes "Reset"
    Then I click the "Reset" button
        And I verify that the button text becomes "Start"
        And I verify that the progress bar value is "0"%