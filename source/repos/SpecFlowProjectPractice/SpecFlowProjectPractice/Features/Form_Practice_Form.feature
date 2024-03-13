@CHROME
Feature: Practice Form Functionality

Background:
	Given I am on the "Practice Form" page

Scenario: Fill out and verify practice form data
	Given I fill the form with random data
	When I click the Submit button
	Then I should see the model with submitted data matching my input