@CHROME
Feature: Text Box Functionality
Background:
	Given I am on the "Text Box" page

Scenario: Fill out and verify text box data

	Given I enter the following data
		| Field             | Value                               |
		| Full Name         | John Doe                            |
		| Email             | john.doe@example.com                |
		| Current Address   | 123 Main Street, Anytown, USA 12345 |
		| Permanent Address | 456 Pub Street, Buffalo, USA 45789  |

	When I click on the Submit button
	Then I verify the displayed table contains the entered data
		| Field             | Value								  |
		| Full Name         | John Doe                            |
		| Email             | john.doe@example.com                |
		| Current Address   | 123 Main Street, Anytown, USA 12345 |
		| Permanent Address | 456 Pub Street, Buffalo, USA 45789  | 