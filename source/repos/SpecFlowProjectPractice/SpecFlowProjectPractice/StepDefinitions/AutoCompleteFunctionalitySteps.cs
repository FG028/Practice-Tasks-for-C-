using NUnit.Framework;
using TechTalk.SpecFlow;
using SpecFlowProjectPractice.PageObjects;
using SpecFlowProjectPractice.Drivers;
using SpecFlowProjectPractice.Helper;

namespace SpecFlowProjectPractice.StepDefinitions
{
    [Binding]
    public class AutoCompleteFunctionalitySteps
    {
        private WebDriverManager _driverManager;
        private readonly AutoCompletePage _autoCompletePage;
        private PopUpHandler popUpHandler;

        public AutoCompleteFunctionalitySteps(WebDriverManager driverManager)
        {
            _driverManager = driverManager;
            popUpHandler = new PopUpHandler(driverManager);
            _autoCompletePage = new AutoCompletePage(_driverManager);
        }

        [When("The user enters the letter 'g' in the Type multiple color names field")]
        public void WhenIEnterTheLetterGInTheTypeMultipleColorNamesField()
        {
            _autoCompletePage.EnterText("g");
        }

        [Then("Three suggestions containing 'g' should be displayed.")]
        public void ThenIShouldSeeThreeAutoCompleteSuggestionsContainingG()
        {
            Assert.That(_autoCompletePage.GetAutoCompleteSuggestions().Count, Is.EqualTo(2));
        }

        [Given("The following colors displayed in the field: Red, Yellow, Green, Blue, and Purple")]
        public void WhenIAddTheColorsRedYellowGreenBlueAndPurple()
        {

            _autoCompletePage.ClearInputField();
            _autoCompletePage.AddMultipleColors("Red", "Yellow", "Green", "Blue", "Purple");

            var expectedColors = new string[] { "Red", "Yellow", "Green", "Blue", "Purple" };
            foreach (var color in expectedColors)
            {
                Assert.That(_autoCompletePage.GetSelectedColors().Contains(color), $"Color '{color}' not found in selected options");
            }
        }

        [When("I am removing the colors Yellow and Purple")]
        public void WhenIDeleteTheColorsYellowAndPurple()
        {
            _autoCompletePage.DeleteColors("Yellow", "Purple");
        }

        [Then("I should see the following colors remaining in the field: Red, Green, Blue")]
        public void ThenIShouldSeeTheFollowingColorsRemainingInTheFieldRedGreenBlue()
        {
            var expectedColors = new List<string>() { "Red", "Green", "Blue" };
            foreach (var color in expectedColors)
            {
                Assert.That(_autoCompletePage.GetSelectedColors().Contains(color), $"Selected colors should contain {color}");
            }

            var unexpectedColors = new List<string>() { "Yellow", "Purple" };
            foreach (var color in unexpectedColors)
            {
                Assert.False(_autoCompletePage.GetSelectedColors().Contains(color), $"Selected colors should not contain {color}");
            }
        }
    }
}