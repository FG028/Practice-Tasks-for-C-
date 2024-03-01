Feature: Browser Windows Functionality

	Scenario Outline: Open new window and verify content (if applicable)
	Given I am on the "Browser Windows" page
	When I click the "<ButtonName>" button
	Then I switch to the new window
		And I verify the page contains the text "<ExpectedText>"
	
	Examples:
	| ButtonName		| ExpectedText			|
	| ----------------- | --------------------- |
	| New Tab			| This is a sample page |
	| New Window		| This is a sample page |