Feature: Complete and Verify Practice Form on DemoQA

Background: 
    Given I am on the DemoQA page "https://demoqa.com/"

Scenario: 5.1. Submit form with random data and verify submission
    Given I am on the DemoQA page "https://demoqa.com/automation-practice-form"
        And I navigate to the "Forms" category and "Practice Form" section
    When I fill the form with random data
    Then I submit the form
    Then I should see the model with submitted data matching my input