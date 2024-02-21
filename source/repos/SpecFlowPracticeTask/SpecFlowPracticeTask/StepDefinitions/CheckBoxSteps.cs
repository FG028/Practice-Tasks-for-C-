using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using System.Linq;

namespace SpecFlowPracticeTask.StepDefinitions;

[Binding]
public class CheckBoxSteps
{
    private readonly WebDriver driver;

    public CheckBoxSteps(WebDriver driver)
    {
        this.driver = driver;
    }

    [Given(@"I am on the DemoQA page ""(.*)""")]
    [Given(@"I navigate to the ""Alerts, Frame & Windows"" category and ""Browser Windows"" section")]
    public void NavigateToBrowserWindowsSection(string url)
    {
        driver.Navigate().GoToUrl("https://demoqa.com/checkbox");
    }

    [When(@"I expand the ""(.*)"" folder and select the ""(.*)"" folder")]
    public void WhenIExpandTheFolderAndSelectTheFolder(string parentFolder, string childFolder)
    {
        var parentElement = driver.FindElement(By.Name(parentFolder));
        parentElement.Click();

        var childElement = driver.FindElement(By.Name(childFolder));
        childElement.Click();
    }

    [Then(@"I select ""(.*)"" and ""(.*)"" from the ""(.*)"" folder")]
    public void WhenISelectAndFromTheFolder(string item1, string item2, string folder)
    {
        var folderElement = driver.FindElement(By.Name(folder));
        var item1Element = folderElement.FindElements(By.Name(item1)).FirstOrDefault();
        var item2Element = folderElement.FindElements(By.Name(item2)).FirstOrDefault();

        item1Element.Click();
        item2Element.Click();
    }

    [Then(@"I expand the ""(.*)"" folder and click on each item")]
    public void WhenIExpandTheFolderAndClickOnEachItem(string folder)
    {
        var folderElement = driver.FindElement(By.Name(folder));
        folderElement.Click();

        var itemElements = folderElement.FindElements(By.TagName("label"));
        foreach (var item in itemElements)
        {
            item.Click();
        }
    }

    [Then(@"I expand the ""(.*)"" folder and select the entire folder")]
    public void WhenIExpandTheFolderAndSelectTheEntireFolder(string folder)
    {
        var folderElement = driver.FindElement(By.Name(folder));
        folderElement.Click();

        var checkboxElement = folderElement.FindElement(By.XPath("//input[@type='checkbox']"));
        checkboxElement.Click();
    }

    [Then(@"I should see the output ""(.*)""")]
    public void VerifyOutput(string expectedOutput)
    {
        var actualOutput = driver.FindElement(By.Id("result")).Text;
        Assert.That(actualOutput, Is.EqualTo(expectedOutput));
    }
}
