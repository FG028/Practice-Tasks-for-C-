@CHROME
Feature: Buttons Functionality

Background:
	Given I am on the "Buttons" page

Scenario: Click the button and verify text
	When I click the "<ButtonName>" button
	Then I verify the text is "<ExpectedText>"

Examples:
	| ButtonName		| ExpectedText					|
	| Click Me			| You have done a dynamic click |
	| Double Click Me	| You have done a double click	|
	| Right Click Me    | You have done a right click   | 