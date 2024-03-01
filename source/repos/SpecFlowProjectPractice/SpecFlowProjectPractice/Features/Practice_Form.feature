Feature: Practice Form Functionality

	Background:
		Given I am on the "Practice Form" page

	Scenario: Fill out and verify practice form data
		When I fill the form with random data
		Then I click the Submit button
			And I should see the model with submitted data matching my input