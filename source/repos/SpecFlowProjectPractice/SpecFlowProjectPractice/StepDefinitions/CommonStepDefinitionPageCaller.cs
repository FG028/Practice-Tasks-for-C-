using OpenQA.Selenium;
using SpecFlowProjectPractice.Helper;
using TechTalk.SpecFlow;
using SpecFlowProjectPractice.Drivers;

[Binding]
public class CommonStepDefinitionPageCaller
{

    private WebDriverManager _webDriverManager;

    public CommonStepDefinitionPageCaller(WebDriverManager webDriverManager)
    {
        _webDriverManager = webDriverManager;
    }

    [Given(@"I am on the ""(.*)"" page")]
    public void GivenIAmOnThePage(string pageName)
    {
        var navigateHelper = new NavigationHelper(_webDriverManager);
        navigateHelper.NavigateToPage(pageName);
    }
}
