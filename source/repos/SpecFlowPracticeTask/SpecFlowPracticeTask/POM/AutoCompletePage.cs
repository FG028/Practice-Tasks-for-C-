using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using SpecFlowPracticeTask.Hooks;

namespace SpecFlowPracticeTask.POM
{
    public class AutoCompletePage
    {
        
        public AutoCompletePage(WebDriver _driver)
        {
            this.driver = _driver;
            PageFactory.InitElements(driver, this);
        }

        public void NavigateToDemoQA()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/auto-complete");
        }

        [FindsBy(How = How.Id, Using = "autoCompleteMultipleInput")]
        public IWebElement ColorInput { get; set; }

        [FindsBy(How = How.Id, Using = ".ui-autocomplete li")]
        public IReadOnlyCollection<WebElement> AutoCompleteSuggestions { get; set;}

        public void EnterText(string text) 
        {
            ColorInput.SendKeys(text);
        }

        public int GetNumberOfSuggestion()
        {
            return AutoCompleteSuggestions.Count;
        }

        public List<string> GetSuggestionText() 
        {
            return AutoCompleteSuggestions.Select(s => s.Text).ToList();
        }

        public void AddColor(string color)
        {
            EnterText(color);
            new WebDriverWait(driver, TimeSpan.FromSeconds(2)).Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//li/div/span[text()='{color}']")));
            driver.FindElement(By.XPath($"//li/div/span[text()='{color}']")).Click();
        }

        public void DeleteColor(string color)
        {
            var deleteButton = ColorInput.FindElement(By.XPath($".//following-sibling::span[text()='{color}']/preceding-sibling::span[@class='ms-2 ui-close-icon']"));
            deleteButton.Click();
        }

        public List<String> GetSelectedColorText() 
        {
            var selectedColors = ColorInput.FindElements(By.CssSelector(".tag"));
            return selectedColors.Select(s => s.Text).ToList();
        }
    }
}