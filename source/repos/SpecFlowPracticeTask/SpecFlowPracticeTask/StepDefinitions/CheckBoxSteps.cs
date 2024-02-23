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

    [Given(@"I am on the DemoQA page ""https://demoqa.com/checkbox""")]
    public void NavigateToDemoQA()
    {
        string url = "https://demoqa.com/checkbox";
        driver.Navigate().GoToUrl(url);
    }

    [Given(@"I navigate to the ""Elements"" category and ""Check Box"" section")]
    public void NavigateToAutoCompleteSection()
    {
        driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div[1]/div/div/div[1]/div/ul/li[2]")).Click();
    }

    [When(@"I expand the Home folder")]
    public void WhenIExpandTheHomeFolder()
    {
        var parentElement = driver.FindElement(By.Name("Home"));
        parentElement.Click();        
    }
    
    [Then(@"I select the Desktop folder")]
    public void WhenISelectTheDesktopFolder()
    {
        var childElement = driver.FindElement(By.XPath("//*[@id=\"tree-node\"]/ol/li/ol/li[1]/span/label"));
        childElement.Click();
    }

    [Given(@"I select ""(.*)"" and ""(.*)"" from the ""(.*)"" folder")]
    public void WhenISelectAndFromTheFolder(string item1, string item2, string folder)
    {
        var folderElement = driver.FindElement(By.Name(folder));
        var item1Element = folderElement.FindElements(By.Name(item1)).FirstOrDefault();
        var item2Element = folderElement.FindElements(By.Name(item2)).FirstOrDefault();

        item1Element.Click();
        item2Element.Click();
    }

    [Then(@"I expand the Office folder")]
    public void WhenIExpandTheOfficeFolder()
    {
        var folderElement = driver.FindElement(By.Name("Office"));
        folderElement.Click();
    }

    [Then(@"I click on each item")]
    public void WhenIClickOnEachItem() 
    {
        var folderElement = driver.FindElement(By.CssSelector("#tree-node > ol > li > ol > li:nth-child(2) > ol > li.rct-node.rct-node-parent.rct-node-expanded > span > label > span.rct-checkbox > svg"));
        var itemElements = folderElement.FindElements(By.TagName("label"));
        foreach (var item in itemElements)
        {
            item.Click();
        }
    }

    [Then(@"I expand the Downloads folder")]
    public void WhenIExpandTheDownloadsFolder()
    {
        var folderElement = driver.FindElement(By.Name("Downloads"));
        folderElement.Click();
    }

    [Then(@"I select the entire folder")]
    public void WhenISelectTheEntireFolder()
    {
        var folderElement = driver.FindElement(By.Name("Downloads"));
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
