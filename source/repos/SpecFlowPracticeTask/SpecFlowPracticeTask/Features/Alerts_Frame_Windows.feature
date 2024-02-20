Feature: Manage browser windows and frames on DemoQA

Background:
  Given I am on the DemoQA page "https://demoqa.com/"

Scenario Outline: Navigate to and verify content in new browser windows or tabs
  Given I navigate to the "Alerts, Frame & Windows" category and "Browser Windows" section
  When I click on the "<button_type>" button
  Then a new "<window_type>" should be loaded
  And the new "<window_type>" should contain the text "This is a sample page"

Examples:
  | button_type | window_type |
  | New Tab     | tab        |
  | New Window  | window     |