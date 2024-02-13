using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Page_Object_Model_and_Page_Object_Pattern
{
    internal class Page_Factory : LoginPage
    {
        [FindsBy(Id = "lostPassword")]
        private IWebElement lostPasswordLink { get; set; }

        [FindsBy(Id = "rememberMe")]
        private IWebElement rememberMeCheckBox { get; set; }

        [FindsBy(XPath = "//button[contains(@text(), 'Register')]")]
        private IWebElement registerButton { get; set; }

        [FindsBy(Id = "username")]
        private IWebElement usernameField { get; set; }

        [FindsBy(Id = "password")]
        private IWebElement passwordField { get; set; }

        [FindsBy(Id = "login")]
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
