using TechTalk.SpecFlow;
using OpenQA.Selenium;
using TechTalk.SpecFlow.Assist;
using NUnit.Framework;
using SpecFlowPracticeTask.POM;

namespace SpecFlowPracticeTask.StepDefinitions;

[Binding]
public class TextBoxSteps
{
    private readonly TextBoxPage textBoxPage;

    public TextBoxSteps(IWebDriver driver)
    {
        textBoxPage = new TextBoxPage(driver);
    }

    [Given(@"I am on the DemoQA page ""https://demoqa.com/text-box""")]
    public void NavigateToDemoQA()
    {
        textBoxPage.NavigateToPage();
    }

    [When(@"I enter the following data:")]
    public void EnterFromData(Table table)
    {
        var data = table.CreateSet<Dictionary<string, string>>().ToList();
        textBoxPage.EnterUserData(data[0]["FullName"], data[0]["Email"], data[0]["Current Address"], data[0]["Permanent Address"]);
        textBoxPage.SubmitUserData();
    }

    [Then(@"I should see the submitted data displayed in the table")]
    public void VerifySubmittedData(Table table)
    {
        var expectedData = table.CreateSet<List<string>>().ToList();
        var actualData = textBoxPage.GetSubmittedData();
        Assert.AreEqual(expectedData, actualData);
    }
}