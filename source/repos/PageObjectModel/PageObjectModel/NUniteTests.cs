using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PageObjectModel
{
        [TestFixture]
        public class LoginPageTests
        {
            private IWebDriver driver;

            [SetUp]
            public void Setup()
            {
                driver = new ChromeDriver();
                locators = new LocatorClass();
        }
            [Test]
            public void TestGetLostPassword()
            {
                LoginPage page = new LoginPage(driver);
                string text = page.GetLostPasswordText();

                Assert.That(text, Is.EqualTo("Lost your password ?"));
            }
            [Test]
            public void TestGetRememberMeText()
            {
                LoginPage page = new LoginPage(driver);
                string text = page.GetRememberMeText();

                Assert.That(text, Is.EqualTo("Remember Me"));
        }
            [Test]
            public void TestGetRegisterButtonText()
            {
                LoginPage page = new LoginPage(driver);
                string text = page.GetRegisterButtonText();

                Assert.That(text, Is.EqualTo("Register"));
        }
            [Test]
            public void TestLogin()
            {
                LoginPage page = new LoginPage(driver);
                string username = "testuser";
                string password = "password";

                page.Login(username, password);

                string expectedTitle = "Welcome";
                Assert.That(driver.Title, Is.EqualTo(expectedTitle));

                var successMessage = driver.FindElement(By.Id("successMessage")); // Adjust ID as needed
                Assert.That(successMessage.Displayed, Is.True);
                Assert.That(successMessage.Text, Contains.Substring("Logged in successfully"));

            }
            [TearDownAttribute]
            public void TearDownAttribute()
            {
                driver.Dispose();
            }

            [TearDown]
            public void TearDown()
            {
                driver.Quit();
            }
        }
}