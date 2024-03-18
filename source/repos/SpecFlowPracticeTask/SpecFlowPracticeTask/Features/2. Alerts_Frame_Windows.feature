Feature: 2. Manage browser windows and frames on DemoQA

Scenario: 2.1. Navigate to and verify content in new browser windows or tabs
	Given I am on the DemoQA page "https://demoqa.com/browser-windows"
	When I click on the "<button_type>" button
	Then A new "<window_type>" should be loaded

	Examples:
	| button_type | window_type |
	| New Tab     | tab         |
	| New Window  | window      |