using NUnit.Framework;
using TechTalk.SpecFlow;
using SpecFlowProjectPractice.PageObjects;
using SpecFlowProjectPractice.Drivers;
using TechTalk.SpecFlow.Assist;
using SpecFlowProjectPractice.Models;

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
            _textBoxPage.PopUpButtonConfirmation();
            if (_textBoxPage.FullNameField == null || _textBoxPage.EmailField == null || _textBoxPage.CurrentAddressField == null || _textBoxPage.PermanentAddressField == null)
            {
                throw new ArgumentNullException(
                    "One or more web element parameters are null. Please ensure all elements are properly initialized.");
            }
            else
            {
                var data = table.CreateInstance<FormPayload>();

                _textBoxPage?.FullNameField.SendKeys(data.FullName);
                _textBoxPage?.EmailField.SendKeys(data.Email);
                _textBoxPage?.CurrentAddressField.SendKeys(data.CurrentAddress);
                _textBoxPage?.PermanentAddressField.SendKeys(data.PermanentAddress);
            }
        }

        [Then(@"I click on the Submit button")]
        public void WhenIClickTheSubmitButton()
        {
            _textBoxPage.ClickSubmitButton();
        }

        [Then(@"I verify the displayed table contains the entered data")]
        public void ThenIVerifyTheDisplayedTableContainsTheEnteredData(Table table)
        {
            var expectedData = table.CreateInstance<FormPayload>();

            Assert.AreEqual($"Name:{expectedData.FullName}", _textBoxPage?.FullNameLabel.Text);
            Assert.AreEqual($"Email:{expectedData.Email}", _textBoxPage?.EmailLabel.Text);
            Assert.AreEqual($"Current Address :{expectedData.CurrentAddress}", _textBoxPage?.CurrentAddressLabel.Text);
            Assert.AreEqual($"Permananet Address :{expectedData.PermanentAddress}", _textBoxPage?.PermanentAddressLabel.Text);
        }
    }
}