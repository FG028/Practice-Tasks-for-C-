using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SpecFlowPracticeTask.POM;

namespace SpecFlowPracticeTask.StepDefinitions;

[Binding]
public class CheckBoxSteps
{
    private readonly WebDriver driver;
    private readonly CheckBoxPage checkBoxPage;

    public CheckBoxSteps(WebDriver driver)
    {
        this.driver = driver;
        checkBoxPage = new CheckBoxPage(driver);
    }

    [Given(@"I am on the DemoQA page ""https://demoqa.com/checkbox""")]
    public void NavigateToDemoQA()
    {
        checkBoxPage.NavigateToPage();
    }

    [Given(@"I navigate to the ""Elements"" category and ""Check Box"" section")]
    public void NavigateToAutoCompleteSection()
    {
        checkBoxPage.NavigateToAutoCompleteSection();
    }

    [When(@"I expand the Home folder")]
    public void WhenIExpandTheHomeFolder()
    {
        checkBoxPage.ExpandFolder(checkBoxPage.HomeFolder);        
    }
    
    [Then(@"I select the Desktop folder")]
    public void WhenISelectTheDesktopFolder()
    {
        checkBoxPage.ExpandFolder(checkBoxPage.HomeFolder);
    }

    [Given(@"I select ""(.*)"" and ""(.*)"" from the ""(.*)"" folder")]
    public void WhenISelectAndFromTheFolder(string item1, string item2, string folder)
    {
        checkBoxPage.GetCheckBoxElement(folder, item1).Click();
        checkBoxPage.GetCheckBoxElement(folder, item2).Click();
    }

    [Then(@"I expand the Office folder")]
    public void WhenIExpandTheOfficeFolder()
    {
        checkBoxPage.ExpandFolder(checkBoxPage.OfficeFolder);
    }

    [Then(@"I click on each item")]
    public void WhenIClickOnEachItem() 
    {
        var items = checkBoxPage.GetItemsInFolder(checkBoxPage.OfficeFolder);
        foreach (var item in items)
        {
            item.Click();
        }
    }

    [Then(@"I expand the Downloads folder")]
    public void WhenIExpandTheDownloadsFolder()
    {
        checkBoxPage.ExpandFolder(checkBoxPage.DownloadsFolder);
    }

    [Then(@"I select the entire folder")]
    public void WhenISelectTheEntireFolder()
    {
        checkBoxPage.GetDownloadFolderCheckBox().Click();
    }

    [Then(@"I should see the output ""(.*)""")]
    public void VerifyOutput(string expectedOutput)
    {
        Assert.That(checkBoxPage.GetResultText(), Is.EqualTo(expectedOutput));
    }
}
