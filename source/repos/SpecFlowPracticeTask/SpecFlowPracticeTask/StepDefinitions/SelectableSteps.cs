using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowPracticeTask.POM;
using SpecFlowPracticeTask.Hooks;

[Binding]
public class SelectableSteps
{
    private readonly SelectablePage selectablePage;
    WebDriver driver = WebDriverManager.GetDriver();

    public SelectableSteps(WebDriver _driver)
    {
        driver = _driver;
        selectablePage = new SelectablePage(driver);
    }

    [Given(@"I am on the DemoQA Test Automation page ""https://demoqa.com/selectable""")]
    public void NavigateToDemoQA()
    {
        selectablePage.NavigateToPage();
    }

    [Given(@"I switch to the ""Grid"" tab")]
    public void SwitchToGridTab()
    {
        selectablePage.GridTab.Click();
    }

    [When(@"I select squares (.*), (.*), (.*), (.*), and (.*)")]
    public void SelectSquares(int square1, int square2, int square3, int square4, int square5)
    {
        selectablePage.SelectSquare(square1);
        selectablePage.SelectSquare(square2);
        selectablePage.SelectSquare(square3);
        selectablePage.SelectSquare(square4);
        selectablePage.SelectSquare(square5);
    }

    [Then(@"I should see the selected squares have values ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)""")]
    public void VerifySelectedValues(string value1, string value2, string value3, string value4, string value5)
    {
        var selectedSquares = selectablePage.SelectableSquares.Where(x => x.Selected).ToList();

        Assert.Multiple(() =>
        {
            Assert.That(selectedSquares[0].Text, Is.EqualTo(value1));
            Assert.That(selectedSquares[1].Text, Is.EqualTo(value2));
            Assert.That(selectedSquares[2].Text, Is.EqualTo(value3));
            Assert.That(selectedSquares[3].Text, Is.EqualTo(value4));
            Assert.That(selectedSquares[4].Text, Is.EqualTo(value5));
        });
    }
}