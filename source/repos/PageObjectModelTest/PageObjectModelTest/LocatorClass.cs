using OpenQA.Selenium;

namespace PageObjectModelTest
{
    internal class LocatorClass
    {
        public By LostPasswordLink => By.XPath("//*[@id=\"customer_login\"]/div[1]/form/p[4]/a");
        public By RememberMeCheckBox => By.Name("rememberme");
        public By RegisterButton => By.XPath("//*[@id=\"customer_login\"]/div[2]/form/p[3]/input[3]");
        public By UsernameField => By.Id("username");
        public By PasswordField => By.Id("password");
        public By LoginButton => By.XPath("//*[@id=\"customer_login\"]/div[1]/form/p[3]/input[3]");

        public By DoNotConsentButton => By.CssSelector("body > div.fc-consent-root > div.fc-dialog-container > div.fc-dialog.fc-choice-dialog > div.fc-footer-buttons-container > div.fc-footer-buttons > button.fc-button.fc-cta-do-not-consent.fc-secondary-button > p");
    }
}