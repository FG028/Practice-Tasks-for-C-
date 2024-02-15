using OpenQA.Selenium;

namespace PageObjectModel
{
    internal class LocatorClass
    {
        public By LostPasswordLink => By.CssSelector("#customer_login > div.u-column1.col-1 > form > p.woocommerce-LostPassword.lost_password > a");
        public By RememberMeCheckBox => By.Id("rememberme");
        public By RegisterButton => By.CssSelector("#customer_login > div.u-column2.col-2 > form > p.woocomerce-FormRow.form-row > input.woocommerce-Button.button");
        public By UsernameField => By.Id("username");
        public By PasswordField => By.Id("password");
        public By LoginButton => By.CssSelector("#customer_login > div.u-column1.col-1 > form > p:nth-child(3) > input.woocommerce-Button.button");

        public By DoNotConsentButton => By.CssSelector("body > div.fc-consent-root > div.fc-dialog-container > div.fc-dialog.fc-choice-dialog > div.fc-footer-buttons-container > div.fc-footer-buttons > button.fc-button.fc-cta-do-not-consent.fc-secondary-button > p");
    }
}
