using TechTalk.SpecFlow;
using NUnit.Framework;
using SpecFlowProjectPractice.PageObjects;
using SpecFlowProjectPractice.Drivers;
using SpecFlowProjectPractice.Helper;

[Binding]
public class ProgressBarSteps : Steps
{
    private readonly WebDriverManager _driverManager;
    private readonly ProgressBarPage _progressBarPage;
    private PopUpHandler popUpHandler;

    public ProgressBarSteps(WebDriverManager driverManager)
    {
        _driverManager = driverManager;
        popUpHandler = new PopUpHandler(driverManager);
        _progressBarPage = new ProgressBarPage(_driverManager);
    }

    [When(@"I click on Start")]
    public void WhenIClickOnStart()
    {
        _progressBarPage.ClickStartButton();
    }

    [Then(@"the progress bar should be complete")]
    public void ThenTheProgressBarShouldBeComplete()
    {
        Assert.IsTrue(_progressBarPage.IsProgressBarComplete());
    }

    [Then(@"the button should have changed its name to Reset")]
    public void ThenTheButtonShouldHaveChangedItsNameToReset()
    {
        Assert.AreEqual("Reset", _progressBarPage.GetStartButtonName());
    }

    [Then(@"I click on Reset")]
    public void WhenIClickOnReset()
    {
        _progressBarPage.ClickResetButton();
    }

    [Then(@"the Reset button should have become Start and the value in the progress bar should be 0%")]
    public void ThenTheResetButtonShouldHaveBecomeStartAndTheValueInTheProgressBarShouldBe0()
    {
        Assert.IsTrue(_progressBarPage.IsProgressBarReset());
    }
}