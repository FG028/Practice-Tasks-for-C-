using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowProjectPractice.Helper;
using TechTalk.SpecFlow;
using SpecFlowProjectPractice.PageObjects;

namespace SpecFlowProjectPractice.StepDefinitions
{
    [Binding]
    public class TextBoxesSteps
    {
        private readonly IWebDriver _driver;
        private readonly ElementsPage _elementsPage;
        private readonly WaitHelper _waitHelper;

        public TextBoxesSteps(IWebDriver driver)
        {
            _driver = driver;
            _elementsPage = new ElementsPage(_driver);
            _waitHelper = new WaitHelper();
        }

        [Then(@"I enter ""(.*)"" in the ""(.*)"" field")]
        public void GivenIEnterInTheField(string value, string fieldName)
        {
            var fieldElement = _elementsPage.FindElement(By.Name("fieldName"));

            fieldElement.SendKeys(value);
        }

        [When(@"I click the Submit button")]
        public void WhenIClickTheSubmitButton()
        {
            _elementsPage.ClickSubmitButton();
        }

        [Then(@"I verify the displayed table contains the entered data")]
        public void ThenIVerifyTheDisplayedTableContainsTheEnteredData()
        {
            // Assuming entered values are stored in variables or properties
            string enteredName = "John Doe"; // Replace with actual entered name
            string enteredEmail = "johndoe@example.com"; // Replace with actual entered email
            
            // Retrieve table row elements with entered data
            var nameCell = _driver.FindElement(By.XPath($"//table//td[text()='{enteredName}']"));
            var emailCell = _driver.FindElement(By.XPath($"//table//td[text()='{enteredEmail}']"));

            // Assert that the table cells contain the expected values
            Assert.IsTrue(nameCell.Displayed, "Name not found in the table");
            Assert.IsTrue(emailCell.Displayed, "Email not found in the table");
        }
    }
}
