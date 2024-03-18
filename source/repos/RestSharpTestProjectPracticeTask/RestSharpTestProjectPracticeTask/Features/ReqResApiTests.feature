Feature: ReqRes API Testing

Scenario Outline: Get a user by ID
    Given I send a GET request to "users/{userId}"
    Then the status code should be <expectedStatusCode>
        And the response body should contain the following user details
          | Field        | Expected Value |
          |--------------|----------------|
          | id           | <userId>       |
          | email        | <email>        |

    Examples:
          | userId      | expectedStatusCode | email                                       |
          | 2           | 200                | jane.doe@reqres.in                          |
          | 12345       | 404                | (no data expected in response body)         |

Scenario: Get a list of users (page 2)
    Given I send a GET request to "users?page=2"
    Then the status code should be 200
        And the response body should contain a list of users

Scenario: Create a new user
    Given I send a POST request to "users" with the following user data:
          | Field        | Value             |
          |--------------|-------------------|
          | name         | John Doe          |
          | job          | Software Engineer |
    Then the status code should be 201
        And the response body should contain the newly created user details

Scenario Outline: Update a user (PUT and PATCH)
    Given I send a "<requestMethod>" request to "users/{userId}" with the following user data:
          | Field        | Value             |
          |--------------|-------------------|
          | name         | Updated Name      |
          | job          | Updated Job       |
    Then the status code should be 200
        And the response body should contain the updated user details

    Examples:
          | requestMethod | userId |
          | --------------| ------ |
          | PUT           | 2      |
          | PATCH         | 3      |

Scenario: Delete a user (positive case)
    Given I send a DELETE request to "users/2"
    Then the status code should be 204 (No Content)

Scenario: Delete a user (negative case - non-existent user)
    Given I send a DELETE request to "users/12345"
    Then the status code should be 404 (Not Found)

Scenario: Register a new user
    Given I send a POST request to "auth/register" with the following user data:
          | Field        | Value               |
          |--------------|---------------------|
          | email        | newUser@example.com |
          | password     | password123         |
    Then the status code should be 200  # Registration successful
        And the response body should contain a token

Scenario: Login a user
    Given I send a POST request to "auth/login" with the following user data:
          | Field        | Value                |
          |--------------|----------------------|
          | email        | jane.doe@reqres.in   |
          | password     | password123          |
    Then the status code should be 200  # Login successful
        And the response body should contain a token

Scenario: Get a delayed response
    Given I send a GET request to "users/delayed"
    Then the status code should be 200
        And the response time should be greater than 2 seconds