Feature: Progress Bar

    @CHROME
    Scenario: Start, Complete, and Reset Progress Bar
    Given I am on the "Progress Bar" page
    When I click on Start
    Then the progress bar should be complete
        And the button should have changed its name to Reset
    Then I click on Reset
        And the Reset button should have become Start and the value in the progress bar should be 0%