﻿Feature: 5. Complete and Verify Practice Form on DemoQA

Scenario: 5.1. Submit form with random data and verify submission
    Given I am on the DemoQA page "https://demoqa.com/automation-practice-form"
    When I fill the form with random data
    Then I submit the form
        And I should see the model with submitted data matching my input