using OpenQA.Selenium;
using SpecFlowProjectPractice.Drivers;

namespace SpecFlowProjectPractice.Helper
{
    public class NavigationHelper
    {
        
        private readonly WebDriverManager _webDriverManager;

        public NavigationHelper(WebDriverManager webDriverManager)
        {
            _webDriverManager = webDriverManager;
        }

        private readonly string BaseUrl = "https://demoqa.com/";
        public void NavigateToUrl(string url)
        {
           _webDriverManager.Driver().Navigate().GoToUrl(url);
        }
        public void NavigateToPage(string pageName)
        {

            switch (pageName.ToLower())
            {
                case "text box":
                    NavigateToUrl(BaseUrl + "text-box");
                    break;
                case "check box":
                    NavigateToUrl(BaseUrl + "check-box");
                    break;
                case "web tables":
                    NavigateToUrl(BaseUrl + "web-tables");
                    break;
                case "buttons":
                    NavigateToUrl(BaseUrl + "buttons");
                    break;
                case "browser windows":
                    NavigateToUrl(BaseUrl + "browser-windows");
                    break;
                case "auto complete":
                    NavigateToUrl(BaseUrl + "auto-complete");
                    break;
                case "selectable":
                    NavigateToUrl(BaseUrl + "selectable");
                    break;
                case "practice form":
                    NavigateToUrl(BaseUrl + "practice-form");
                    break;
                default:
                    throw new ArgumentException($"Unsupported page name: {pageName}");
            }
        }
    }
}
