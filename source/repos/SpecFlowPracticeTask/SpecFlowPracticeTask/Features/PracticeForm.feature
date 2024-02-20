Feature: Complete and Verify Practice Form on DemoQA

  Scenario: Submit form with random data and verify submission
    Given I am on the DemoQA page "https://demoqa.com/"
    And I navigate to the "Forms" category and "Practice Form" section
    When I fill the form with random data
    And I submit the form
    Then I should see the modal with submitted data matching my input