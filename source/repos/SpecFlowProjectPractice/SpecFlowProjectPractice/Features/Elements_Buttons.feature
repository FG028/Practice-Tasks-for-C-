Feature: Buttons Functionality
	@CHROME
	Scenario Outline: Click button and verify text
	Given I am on the "Buttons" page
	When I click the "<ButtonName>" button
	Then I verify the text is "<ExpectedText>"
	
	Examples:
	| ButtonName		| ExpectedText					|
	| ----------------- | ----------------------------- |
	| Click Me			| You have clicked me			|
	| Double Click Me	| You have done a right click	|