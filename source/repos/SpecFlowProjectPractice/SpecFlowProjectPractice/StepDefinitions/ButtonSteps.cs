using NUnit.Framework;
using TechTalk.SpecFlow;
using SpecFlowProjectPractice.PageObjects;
using SpecFlowProjectPractice.Drivers;

namespace SpecFlowProjectPractice.StepDefinitions
{
    [Binding]
    public class ButtonsSteps
    {
        private WebDriverManager _driverManager;
        private ButtonsPage _buttonsPage;

        public ButtonsSteps(WebDriverManager driverManager)
        {
            _driverManager = driverManager;
            _buttonsPage = new ButtonsPage(_driverManager);
        }
        
        [When(@"I click the ""(.*)"" button")]
        public void WhenIClickTheButton(string buttonLabel)
        {
            _buttonsPage.PopUpButtonConfirmation();
            var button = _buttonsPage.GetButtonByName(buttonLabel);
            _buttonsPage.PerformButtonAction(buttonLabel, button);
        }

        [Then(@"I verify the text is ""(.*)""")]
        public void ThenIVerifyTheFollowingTextIsDisplayed(string expectedMessage)
        { 
            Assert.That(_buttonsPage.GetResultText(), Is.EqualTo(expectedMessage));
        }
       
    }
}
