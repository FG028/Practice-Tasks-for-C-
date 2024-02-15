using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PageObjectModelTest
{
    [TestClass]
    public class LoginPageTests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://practice.automationtesting.in/my-account/.");

        }
        [Test]
        public void TestGetLostPassword()
        {
            LoginPage page = new LoginPage(driver);
            string text = page.GetLostPasswordText();

            NUnit.Framework.Assert.That(text, Is.EqualTo("Lost your password?"));
        }
        [Test]
        public void TestGetRememberMeText()
        {
            LoginPage page = new LoginPage(driver);
            string text = page.GetRememberMeText();

            NUnit.Framework.Assert.That(text, Is.Empty);

        }
        [Test]
        public void TestGetRegisterButtonText()
        {
            LoginPage page = new LoginPage(driver);
            string text = page.GetRegisterButtonText();

            NUnit.Framework.Assert.That(text, Is.Empty);
        }
        [Test]
        public void TestLogin()
        {
            LoginPage page = new LoginPage(driver);
            string username = "testuser";
            string password = "password";

            page.Login(username, password);


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