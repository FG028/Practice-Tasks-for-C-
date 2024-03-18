Feature: 4. Interact with Selectable on DemoQA

 Scenario: 4.1. Select specific squares and verify values
    Given I am on the DemoQA Test Automation page "https://demoqa.com/selectable"
        And I switch to the "Grid" tab
    When I select squares 1, 3, 5, 7, and 9
    Then I should see the selected squares have values "One", "Three", "Five", "Seven", "Nine"