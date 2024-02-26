using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SpecFlowPracticeTask.POM
{

    public class TextBoxPage
    {
        private readonly IWebDriver driver;

        public TextBoxPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "[id*='fullName']")]
        public IWebElement FullNameField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[id*='userEmail']")]
        public IWebElement EmailField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[id*='currentAddress']")]
        public IWebElement CurrentAddressField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[id*='permanentAddress']")]
        public IWebElement PermanentAddressField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[type='submit']")]
        public IWebElement SubmitButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".rt-tr-group")]
        public IReadOnlyCollection<IWebElement> SubmittedDataRows { get; set; }

        public void NavigateToPage()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/text-box");
        }

        public void EnterUserData(string fullName, string email, string currentAddress, string permanentAddress)
        {
            FullNameField.SendKeys(fullName);
            EmailField.SendKeys(email);
            CurrentAddressField.SendKeys(currentAddress);
            PermanentAddressField.SendKeys(permanentAddress);
        }

        public void SubmitUserData()
        {
            SubmitButton.Click();
        }

        public List<List<string>> GetSubmittedData()
        {
            List<List<string>> data = new List<List<string>>();
            foreach (var row in SubmittedDataRows)
            {
                List<string> rowData = row.FindElements(By.TagName("td")).Select(cell => cell.Text).ToList();
                data.Add(rowData);
            }
            return data;
        }
    }
}
