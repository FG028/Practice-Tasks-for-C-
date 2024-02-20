﻿Feature: Interact with Selectable on DemoQA

  Scenario: Select specific squares and verify values
    Given I am on the DemoQA page "https://demoqa.com/"
    And I navigate to the "Interactions" category and "Selectable" section
    And I switch to the "Grid" tab
    When I select squares 1, 3, 5, 7, and 9
    Then I should see the selected squares have values "One", "Three", "Five", "Seven", "Nine"