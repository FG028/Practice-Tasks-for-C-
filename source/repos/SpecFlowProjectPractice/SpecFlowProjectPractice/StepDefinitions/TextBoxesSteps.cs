using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SpecFlowProjectPractice.PageObjects;
using SpecFlowProjectPractice.Drivers;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowProjectPractice.StepDefinitions
{
    [Binding]
    public class TextBoxesSteps
    {
        private WebDriverManager driverManager;
        private TextBoxPage _textBoxPage;

        public TextBoxesSteps(WebDriverManager _driverManager)
        {
            driverManager = _driverManager;
            _textBoxPage = new TextBoxPage(driverManager);
        }

        [When(@"I enter the following data:")]
        public void GivenIEnterInTheField(Table table)
        {
            // The key is not present "FullName"
            var data = table.CreateSet<Dictionary<string, string>>().ToList();
            _textBoxPage.FullNameField.SendKeys(data[0]["Full Name"]);
            _textBoxPage.EmailField.SendKeys(data[0]["Email"]);
            _textBoxPage.CurrentAddressField.SendKeys(data[0]["Current Address"]);
            _textBoxPage.PermanentAddressField.SendKeys(data[0]["Permanent Address"]);

        }

        [Then(@"I click on the Submit button")]
        public void WhenIClickTheSubmitButton()
        {
            _textBoxPage.ClickSubmitButton();
        }

        [Then(@"I verify the displayed table contains the entered ""(.*)""")]
        public void ThenIVerifyTheDisplayedTableContainsTheEnteredData(Table table)
        {
            var expectedData = table.CreateSet<List<string>>().ToList();
            List<List<string>> GetSubmittedData()
            {
                List<List<string>> data = new List<List<string>>();
                foreach (var row in _textBoxPage.SubmittedDataRows)
                {
                    List<string> rowData = row.FindElements(By.TagName("td")).Select(cell => cell.Text).ToList();
                    data.Add(rowData);
                }
                return data;
            }
            Assert.That(GetSubmittedData(), Is.EqualTo(expectedData));
        }
    }
}
