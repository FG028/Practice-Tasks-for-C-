Feature: Text Box Functionality
	Background:
		Given I am on the "Text Box" page
	@CHROME
	Scenario: Fill out and verify text box data
	When I enter the following data:
      | Field             | Value                                  |
      |-------------------|----------------------------------------|
      | Full Name         | John Doe                               |
      | Email             | john.doe@example.com                   |
      | Current Address   | 123 Main Street, Anytown, USA 12345    |
      | Permanent Address | Same as Current Address                | 
	
	Then I click on the Submit button
	Then I verify the displayed table contains the entered "data"