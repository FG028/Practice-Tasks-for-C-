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
    [Given(@"I navigate to the ""Elements"" category and ""Check Box"" section")]
    public void NavigateToCheckBoxSection(string url)
    {
        driver.Navigate().GoToUrl(url);
    }

    /*[When(@"I expand the ""(.*)"" folder")]
    public void ExpandFolder(string folderName)
    {
        driver.FindElement(By.XPath($"//label[text()='{folderName}']//input[@type='checkbox']")).Click();
    }

    [Then(@"I select the ""(.*)"" folder without expanding it")]
    public void SelectItemsFromFolder(string folderName)
    {
        driver.FindElement(By.XPath($"//label[text()='{folderName}']//input[@type='checkbox']")).Click();
    }

    [Then(@"I select ""(.*)"" and ""(.*)"" from the ""(.*)"" folder")]
    public void SelectItemsFromFolder(string item1, string item2, string folderName)
    {
        ExpandFolder(folderName);
        driver.FindElement(By.XPath($"//label[text()='{folderName}']//label[text()='{item1}']//input")).Click();
        driver.FindElement(By.XPath($"//label[text()='{folderName}']//label[text()='{item2}']//input")).Click();
    }

    [Then(@"I expand the ""(.*)"" folder and click on each item in the folder")]
    public void ClickAllItemsInFolder(string folderName)
    {
        ExpandFolder(folderName);
        var options = driver.FindElements(By.XPath($"//label[text()='{folderName}']//input[@type='checkbox']"));
        foreach (var option in options)
        {
            option.Click();
        }
    }

    [Then(@"I expand the ""(.*)"" folder and select the whole folder")]
    public void SelectEntireFolder(string folderName)
    {
        ExpandFolder(folderName);
        driver.FindElement(By.XPath($"//label[text()='{folderName}']//input[@type='checkbox']")).Click();
    }
    */

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
