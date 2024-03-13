@CHROME
Feature: Progress Bar

Background: 
    Given I am on the "Progress Bar" page

Scenario: Start, Complete, and Reset Progress Bar
    Given I click on Start
        And the progress bar should be complete
        And the button should have changed its name to Reset
    When I click on Reset
    Then the Reset button should have become Start and the value in the progress bar should be 0%