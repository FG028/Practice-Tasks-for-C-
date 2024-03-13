@CHROME
Feature: Browser Windows Management

Background:
	Given I am on the "Browser Windows" page

Scenario: Open new window or tab and verify its content
	When I click the link "<buttonText>" button
	Then The new window contains the text "<expectedText>"

Examples:
	| buttonText  | expectedText		  |
	| New Tab     | This is a sample page |
	| New Window  | This is a sample page |