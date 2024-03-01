using OpenQA.Selenium;
using SpecFlowProjectPractice.Helper;
using TechTalk.SpecFlow;

[Binding]
public class CommonStepDefinitionPageCaller
{
    // private readonly IWebDriver _driver;
    protected IWebDriver _driver { get; }

    public CommonStepDefinitionPageCaller(IWebDriver driver)
    {
        _driver = driver;
    }

    [Given(@"I am on the ""(.*)"" page")]
    public void GivenIAmOnThePage(string pageName)
    {
        NavigationHelper.NavigateToPage(_driver, pageName);
    }
}
