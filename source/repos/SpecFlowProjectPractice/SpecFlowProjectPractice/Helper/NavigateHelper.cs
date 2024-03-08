﻿using OpenQA.Selenium;
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
                    NavigateToUrl(BaseUrl + "checkbox");
                    break;
                case "web tables":
                    NavigateToUrl(BaseUrl + "webtables");
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
                case "progress bar":
                    NavigateToUrl(BaseUrl + "progress-bar");
                    break;
                case "practice form":
                    NavigateToUrl(BaseUrl + "automation-practice-form");
                    break;
                default:
                    throw new ArgumentException($"Unsupported page name: {pageName}");
            }
        }
    }
}
