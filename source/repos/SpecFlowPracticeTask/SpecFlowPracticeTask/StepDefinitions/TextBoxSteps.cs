using TechTalk.SpecFlow;
using OpenQA.Selenium;
using TechTalk.SpecFlow.Assist;
using NUnit.Framework;


namespace SpecFlowPracticeTask.StepDefinitions;

[Binding]
public class TextBoxSteps
{
    private readonly WebDriver driver;

    public TextBoxSteps(WebDriver driver)
    {
        this.driver = driver;
    }

    [Given(@"I am on the DemoQA page ""(.*)""")]
    public void NavigateToDemoQA(string url)
    {
        url = "https://demoqa.com/text-box";
        driver.Navigate().GoToUrl(url);
    }

    [Given(@"I navigate to the ""Elements"" category and ""Text Box"" section")]
    public void NavigateToAutoCompleteSection(string url)
    {
        driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div[1]/div/div/div[1]/div/ul/li[1]")).Click();
    }

    [When(@"I enter the following data:")]
    public void EnterFromData(Table table) 
    {
        var data = table.CreateSet<Dictionary<string, string>>();

        foreach (var item in data) 
        {
            var fieldName = item["Field"];
            var fieldValue = item["Value"];

            var field = driver.FindElement(By.Id(fieldName.ToLower()));
            field.SendKeys(fieldValue);
        }
    }

    [Then(@"I should see the submitted data displayed in the table")]
    public void VerifySubmittedData(Table table)
    {
        var rows = driver.FindElements(By.TagName("tr"));
        var data = table.CreateSet<List<string>>().ToList();

        for (int i = 1; i < rows.Count; i++)
        {
            var cells = rows[i].FindElements(By.TagName("td"));
            var actualRow = cells.Select(cell => cell.Text).ToList();

            Assert.That(data[i - 1], Is.EqualTo(actualRow)); 
        }
    }
}