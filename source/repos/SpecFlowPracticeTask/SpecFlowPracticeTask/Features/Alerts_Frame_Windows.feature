Feature: Manage browser windows and frames on DemoQA

Background:
  Given I am on the DemoQA page "https://demoqa.com/"

Scenario Outline: 2.1. Navigate to and verify content in new browser windows or tabs
	Given I am on the DemoQA page "https://demoqa.com/"
		And I navigate to the "Alerts, Frame & Windows" category and "Browser Windows" section
	When I click on the "<button_type>" button
	Then A new "<window_type>" should be loaded and "<expected_content>" should be displayed

Examples:
  | button_type | window_type |
  | New Tab     | tab        |
  | New Window  | window     |