using OpenQA.Selenium;

namespace Page_Object_Model_and_Page_Object_Pattern
{
    public class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver _driver)
        {
            driver = _driver;
        }
        public string GetLostPasswordText()
        {
            var lostPasswordLink = driver.FindElement(By.LinkText("Lost your password?"));
            return lostPasswordLink.Text;
        }
        public string GetRememberMeText()
        {
            var rememberMeCheckBox = driver.FindElement(By.Id("rememberme"));
            return rememberMeCheckBox.Text;
        }
        public string GetRegisterButtonText()
        {
            var registerButton = driver.FindElement(By.XPath("/ html / body / div[1] / div[2] / div / div / div / div / div[1] / div / div[2] / form / p[3] / input[3]"));
            return registerButton.Text;
        }
        public void Login(string username, string password)
        {
            var usernameField = driver.FindElement(By.Id("username"));
            var passworField = driver.FindElement(By.Id("password"));
            var loginButton = driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div/div/div/div[1]/div/div[1]/form/p[3]/input[3]"));

            usernameField.SendKeys(username);
            passworField.SendKeys(password);
            loginButton.Click();
        }
    }
}