using TechTalk.SpecFlow;
using OpenQA.Selenium;
using TechTalk.SpecFlow.Assist;
using NUnit.Framework;
using SpecFlowPracticeTask.POM;
using SpecFlowPracticeTask.Hooks;

namespace SpecFlowPracticeTask.StepDefinitions;

[Binding]
public class TextBoxSteps
{
    private readonly TextBoxPage textBoxPage;

    public TextBoxSteps(TextBoxPage textBoxPage)
    {
        this.textBoxPage = textBoxPage;
    }

    [Given(@"I am on the DemoQA page ""https://demoqa.com/text-box""")]
    public void NavigateToDemoQA()
    {
        BrowserManager.GetDriver().Navigate().GoToUrl("https://demoqa.com/text-box");
    }

    [When(@"I enter the following data:")]
    public void EnterFromData(Table table)
    {
        var data = table.CreateSet<Dictionary<string, string>>().ToList();
        textBoxPage.FullNameField.SendKeys(data[0]["FullName"]);
        textBoxPage.EmailField.SendKeys(data[0]["Email"]);
        textBoxPage.CurrentAddressField.SendKeys(data[0]["Current Address"]);
        textBoxPage.PermanentAddressField.SendKeys(data[0]["Permanent Address"]);
    }

    [Then(@"I select on the ""Submit"" button")]
    public void SubmitUserData()
    {
        textBoxPage.SubmitButton.Click();
    }

    [Then(@"I should see the submitted data displayed in the table")]
    public void VerifySubmittedData(Table table)
    {
        var expectedData = table.CreateSet<List<string>>().ToList();
        List<List<string>> GetSubmittedData()
        {
            List<List<string>> data = new List<List<string>>();
            foreach (var row in textBoxPage.SubmittedDataRows)
            {
                List<string> rowData = row.FindElements(By.TagName("td")).Select(cell => cell.Text).ToList();
                data.Add(rowData);
            }
            return data;
        }
        Assert.That(GetSubmittedData(), Is.EqualTo(expectedData));
    }
}