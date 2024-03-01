Feature: Text Box Functionality
	Background:
		Given I am on the "Text Box" page
	@CHROME
	Scenario: Fill out and verify text box data
	Then I enter "John Doe" in the "Full Name" field
		And I enter "john.doe@example.com" in the "Email" field
	When I click the Submit button
	Then I verify the displayed table contains the entered data

	Scenario Outline: Fill out and verify text box data with Examples
	Then I enter "<Name>" in the "Full Name" field
		And I enter "<Email>" in the "Email" field

	When I click the Submit button
	Then I verify the displayed table contains the entered data
	
	Examples:
	
	| Name			| Email						|
	| John Doe		| john.doe@example.com		|
	| Jane Smith	| jane.smith@example.com	|
	| Michael Brown | michael.brown@example.com |