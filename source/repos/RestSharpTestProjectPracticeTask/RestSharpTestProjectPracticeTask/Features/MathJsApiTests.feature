Feature: MathJS API Testing

Scenario Outline: Perform MathJS operation
    Given I send a POST request to "eval" with the following expression
          | Expression |
          |-------------|
          | <expression> |
    Then The status code should be the next 200
      And the response body should contain the following result:
          | Field        | Expected Value   |
          |--------------|------------------|
          | result       | <expectedResult> |

    Examples:
          | Expression        | expectedResult  |
          | 2 * 3             | 6               |
          | 10 / 2            | 5               |
          | 5 + 7             | 12              |
          | 8 - 4             | 4               |
          | sqrt(16)          | 4               |

Scenario: Invalid expression
    Given I send a POST request to "eval" with an invalid expression: "abc"
      Then The status code should be the next 400 (Bad Request)