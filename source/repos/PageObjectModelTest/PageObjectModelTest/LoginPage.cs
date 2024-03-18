using OpenQA.Selenium;

namespace PageObjectModelTest
{
    public class LoginPage
    {
        private IWebDriver driver;
        private LocatorClass locators;

        public LoginPage(IWebDriver _driver)
        {
            driver = _driver;
            locators = new LocatorClass();
        }

        public string GetLostPasswordText()
        {
            var lostPasswordLink = driver.FindElement(locators.LostPasswordLink);
            return lostPasswordLink.Text;
        }

        public string GetRememberMeText()
        {
            var rememberMeCheckBox = driver.FindElement(locators.RememberMeCheckBox);
            return rememberMeCheckBox.Text;
        }

        public string GetRegisterButtonText()
        {
            var registerButton = driver.FindElement(locators.RegisterButton);
            return registerButton.Text;
        }

        public void Login(string username, string password)
        {
            var usernameField = driver.FindElement(locators.UsernameField);
            var passworField = driver.FindElement(locators.PasswordField);
            var loginButton = driver.FindElement(locators.LoginButton);
            var doNotConsentButton = driver.FindElement(locators.DoNotConsentButton);

            doNotConsentButton.Click();
            usernameField.SendKeys(username);
            passworField.SendKeys(password);
            loginButton.Click();
        }
    }
}
