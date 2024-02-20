Feature: Interact with interactive widgets on DemoQA

Scenario: Use and verify Autocomplete suggestions
    Given I am on the DemoQA page "https://demoqa.com/"
    And I navigate to the "Forms" category and "Auto Complete" section
    When I enter the letter "g" in the "Type multiple color names" field
    Then I should see 3 color suggestions containing the letter "g"
    When I add "Red", "Yellow", "Green", "Blue", and "Purple" to the field
    Then I should see "Red", "Yellow", "Green", "Blue", and "Purple" in the field
    And I delete "Yellow" and "Purple"
    Then I should see only "Red", "Green", and "Blue" in the field

Scenario: Start, wait, reset, and verify progress bar
    Given I am on the DemoQA page "https://demoqa.com/progress-bar"
    When I click the "Start" button
    Then I wait until the progress bar reaches 100%
    And I verify that the button text becomes "Reset"
    When I click the "Reset" button
    Then I verify that the button text becomes "Start"
    And I verify that the progress bar value is 0%