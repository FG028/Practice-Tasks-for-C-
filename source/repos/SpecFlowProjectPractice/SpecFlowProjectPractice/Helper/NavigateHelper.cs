using OpenQA.Selenium;

namespace SpecFlowProjectPractice.Helper
{
    public static class NavigationHelper
    {
        private static readonly string BaseUrl = "https://demoqa.com/";
        public static void NavigateToUrl(IWebDriver driver, string url)
        {
            driver.Navigate().GoToUrl(url);
        }
        public static void NavigateToPage(IWebDriver driver, string pageName)
        {

            switch (pageName.ToLower())
            {
                case "text box":
                    NavigateToUrl(driver, BaseUrl + "elements-forms/text-box");
                    break;
                case "check box":
                    NavigateToUrl(driver, BaseUrl + "elements-forms/check-box");
                    break;
                case "web tables":
                    NavigateToUrl(driver, BaseUrl + "elements-web-tables");
                    break;
                case "buttons":
                    NavigateToUrl(driver, BaseUrl + "elements-forms/buttons");
                    break;
                case "browser windows":
                    NavigateToUrl(driver, BaseUrl + "alerts-frame-and-windows/browser-windows");
                    break;
                case "auto complete":
                    NavigateToUrl(driver, BaseUrl + "widgets/auto-complete");
                    break;
                case "selectable":
                    NavigateToUrl(driver, BaseUrl + "interactions/selectable");
                    break;
                case "practice form":
                    NavigateToUrl(driver, BaseUrl + "forms/practice-form");
                    break;
                default:
                    throw new ArgumentException($"Unsupported page name: {pageName}");
            }
        }
    }
}
