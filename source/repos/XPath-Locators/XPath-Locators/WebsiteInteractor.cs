using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
namespace XPath_Locators;

internal class WebsiteInteractor
{
    public IWebDriver driver;
    public WebsiteInteractor()
    {
        driver = new ChromeDriver();
    }
    public void NavigateTo(string url)
    {
        driver.Navigate().GoToUrl(url);
    }
    public IWebElement FindElementByXPath(string XPath)
    {
        return driver.FindElement(By.XPath(XPath));
    }
    public IWebElement FindElementByCSSSelector(string cSSSelector)
    {
        return driver.FindElement(By.CssSelector(cSSSelector));
    }
}
