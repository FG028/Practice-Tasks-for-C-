Feature: Interact with form elements on DemoQA

Scenario: 1.1. Fill TextBox form, submit, and verify displayed data
    Given I am on the DemoQA page "https://demoqa.com/text-box"
        And  I navigate to the "Elements" category and "Text Box" section
    When I enter the following data:
      | Field        | Value                                    |
      |--------------|------------------------------------------|
      | Full Name    | John Doe                                 |
      | Email       | john.doe@example.com                       |
      | Current Address | 123 Main Street, Anytown, USA 12345      |
      | Permanent Address | Same as Current Address                |
        And I click on the "Submit" button
    Then I should see the submitted data displayed in the table
      | Field        | Value                                    |
      |--------------|------------------------------------------|
      | Full Name    | John Doe                                 |
      | Email       | john.doe@example.com                       |
      | Current Address | 123 Main Street, Anytown, USA 12345      |
      | Permanent Address | Same as Current Address                |

Scenario: 1.2. Expand and Select Folders
    Given I am on the DemoQA page "https://demoqa.com/checkbox"
        And  I navigate to the "Elements" category and "Check Box" section
    When I expand the "Home" folder and select the "Desktop" folder
    Then I select "Angular" and "Veu" from the "WorkSpace" folder
    Then I expand the "Office" folder and click on each item
    Then I expand the "Downloads" folder and select the entire folder
    Then I should see the output "You have selected : desktop notes commands angular veu office public private classified general downloads wordFile excelFile"

Scenario: 1.3. Sort and delete row in Web Tables
    Given I am on the DemoQA page "https://demoqa.com/webtables"
        And I navigate to the "Elements" category and "Web Tables" section
    When I click on the "Salary" column header
    Then I should see the values in the "Salary" column are in ascending order
    Then I delete the second row name Alden
    Then I should see there are only two rows left in the table
        And I should not see the value "Compliance" among the values in the "Department" column

Scenario: 1.4. Interact with Buttons using Scenario Outline (choose one example)
    Scenario Outline: Perform various clicks on buttons
        Given I am on the DemoQA page "https://demoqa.com/buttons"
            And I navigate to the "Elements" category and "Buttons" section
        When I interact with the "<button_name>" button
        Then I should see the text "<expected_message>"

        Examples:
        | button_name      | expected_message                       |
        | Double Click Me  | You have done a double click           |
        | Right Click Me   | You have done a right click            |
        | Click Me         | You have done a dynamic click          |