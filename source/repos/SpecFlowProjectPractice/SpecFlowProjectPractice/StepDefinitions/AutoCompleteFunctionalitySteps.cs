using NUnit.Framework;
using TechTalk.SpecFlow;
using SpecFlowProjectPractice.PageObjects;
using SpecFlowProjectPractice.Drivers;


namespace SpecFlowProjectPractice.StepDefinitions
{
    [Binding]
    public class AutoCompleteFunctionalitySteps
    {
        private WebDriverManager _driverManager;
        private readonly AutoCompletePage _autoCompletePage;

        public AutoCompleteFunctionalitySteps(WebDriverManager driverManager)
        {
            _driverManager = driverManager;
            _autoCompletePage = new AutoCompletePage(_driverManager);
        }

        [When("I enter the letter 'g' in the Type multiple color names field")]
        public void WhenIEnterTheLetterGInTheTypeMultipleColorNamesField()
        {
            _autoCompletePage.EnterText("g");
        }

        [Then("I should see three AutoComplete suggestions containing 'g'")]
        public void ThenIShouldSeeThreeAutoCompleteSuggestionsContainingG()
        {
            Assert.That(_autoCompletePage.GetAutoCompleteSuggestions().Count, Is.EqualTo(3));
            foreach (var suggestion in _autoCompletePage.GetAutoCompleteSuggestions())
            {
                Assert.True(suggestion.Contains('g'));
            }
        }

        [Then("I add the colors Red, Yellow, Green, Blue, and Purple")]
        public void WhenIAddTheColorsRedYellowGreenBlueAndPurple()
        {
            _autoCompletePage.AddColors("Red", "Yellow", "Green", "Blue", "Purple");
        }

        [Then("I should see the following colors in the field: Red, Yellow, Green, Blue, Purple")]
        public void ThenIShouldSeeTheFollowingColorsInTheFieldRedYellowGreenBlueAndPurple()
        {
            Assert.That(_autoCompletePage.GetSelectedColors().Contains("Red"));
            Assert.That(_autoCompletePage.GetSelectedColors().Contains("Yellow"));
            Assert.That(_autoCompletePage.GetSelectedColors().Contains("Green"));
            Assert.That(_autoCompletePage.GetSelectedColors().Contains("Blue"));
            Assert.That(_autoCompletePage.GetSelectedColors().Contains("Purple"));
        }

        [Then("I delete the colors Yellow and Purple")]
        public void WhenIDeleteTheColorsYellowAndPurple()
        {
            _autoCompletePage.DeleteColors("Yellow", "Purple");
        }

        [Then("I should see the following colors remaining in the field: Red, Green, Blue")]
        public void ThenIShouldSeeTheFollowingColorsRemainingInTheFieldRedGreenBlue()
        {
            Assert.That(_autoCompletePage.GetSelectedColors().Contains("Red"));
            Assert.That(_autoCompletePage.GetSelectedColors().Contains("Green"));
            Assert.That(_autoCompletePage.GetSelectedColors().Contains("Blue"));
            Assert.False(_autoCompletePage.GetSelectedColors().Contains("Yellow"));
            Assert.False(_autoCompletePage.GetSelectedColors().Contains("Purple"));
        }
    }
}