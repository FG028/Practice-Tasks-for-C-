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
                    NavigateToUrl(BaseUrl + "elements-forms/text-box");
                    break;
                case "check box":
                    NavigateToUrl(BaseUrl + "elements-forms/check-box");
                    break;
                case "web tables":
                    NavigateToUrl(BaseUrl + "elements-web-tables");
                    break;
                case "buttons":
                    NavigateToUrl(BaseUrl + "elements-forms/buttons");
                    break;
                case "browser windows":
                    NavigateToUrl(BaseUrl + "alerts-frame-and-windows/browser-windows");
                    break;
                case "auto complete":
                    NavigateToUrl(BaseUrl + "widgets/auto-complete");
                    break;
                case "selectable":
                    NavigateToUrl(BaseUrl + "interactions/selectable");
                    break;
                case "practice form":
                    NavigateToUrl(BaseUrl + "forms/practice-form");
                    break;
                default:
                    throw new ArgumentException($"Unsupported page name: {pageName}");
            }
        }
    }
}
