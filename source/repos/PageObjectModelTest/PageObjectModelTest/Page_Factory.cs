using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace PageObjectModelTest
{
    internal class Page_Factory : LoginPage
    {
        [FindsBy(How = How.Id, Using = "lostPassword")]
        private IWebElement lostPasswordLink { get; set; }

        [FindsBy(How = How.Id, Using = "rememberme")]
        private IWebElement rememberMeCheckBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[contains(@text(), 'Register')]")]
        private IWebElement registerButton { get; set; }

        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement usernameField { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement passwordField { get; set; }

        [FindsBy(How = How.Id, Using = "login")]
        private IWebElement loginButton { get; set; }

        public Page_Factory(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }
        public string GetLostPasswordText()
        {
            return lostPasswordLink.Text;
        }
        public string GetRememberMeText()
        {
            return rememberMeCheckBox.Text;
        }
        public string GetRegisterButtonText()
        {
            return registerButton.Text;
        }
        public void Login(string userName, string password)
        {
            usernameField.SendKeys(userName);
            passwordField.SendKeys(password);
            loginButton.Click();
        }
    }
}
