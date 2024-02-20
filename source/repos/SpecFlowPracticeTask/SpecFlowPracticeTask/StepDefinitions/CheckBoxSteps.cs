using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SpecFlowPracticeTask.StepDefinitions;

[Binding]
public class CheckBoxSteps
{
    private readonly WebDriver driver;

    public CheckBoxSteps(WebDriver driver) 
    {
        this.driver = driver;
    }

    [Given(@"I navigate to the ""Elements"" category and ""Check Box"" section")]
    [Given(@"I navigate to the ""Elements"" category and ""Check Box"" section")]
    public void NavigateToCheckBoxSection()
    {
        driver.Navigate().GoToUrl("https://demoqa.com/checkbox");
    }

    [When(@"I expand the ""(.*)"" folder")]
    public void ExpandFolder(string folderName)
    {
        driver.FindElement(By.XPath($"//label[text()='{folderName}']//input[@type='checkbox']")).Click();
    }

    [When(@"I select the ""(.*)"" folder without expanding it")]
    public void SelectItemsFromFolder(string folderName) 
    {
        driver.FindElement(By.XPath("\"//label[text()='{folderName}']//input[@type='checkbox']")).Click();
    }

    [When(@"I select ""(.*)"" and ""(.*)"" from the ""(.*)"" folder")]
    public void SelectItemsFromFolder(string item1, string item2, string folderName)
    {
        ExpandFolder(folderName);
        driver.FindElement(By.XPath($"//label[text()='{folderName}']//label[text()='{item1}']//input")).Click();
        driver.FindElement(By.XPath($"//label[text()='{folderName}']//label[text()='{item2}']//input")).Click();
    }

    [When(@"I click on each item in the ""(.*)"" folder")]
    public void ClickAllItemsInFolder(string folderName)
    {
        ExpandFolder(folderName);
        var options = driver.FindElements(By.XPath($"//label[text()='{folderName}']//input[@type='checkbox']"));
        foreach (var option in options)
        {
            option.Click();
        }
    }

    [When(@"I select the whole ""(.*)"" folder")]
    public void SelectEntireFolder(string folderName)
    {
        ExpandFolder(folderName);
        driver.FindElement(By.XPath($"//label[text()='{folderName}']//input[@type='checkbox']")).Click();
    }

    [Then(@"I should see the output ""(.*)""")]
    public void VerifyOutput(string expectedOutput)
    {
        var actualOutput = driver.FindElement(By.Id("result")).Text;
        Assert.AreEqual(expectedOutput, actualOutput);
    }
}
