using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using Bogus;
using SeleniumExtras.WaitHelpers;

namespace SpecFlowPracticeTask.StepDefinitions
{
    [Binding]
    public class PracticeFormSteps
    {
        private readonly WebDriver driver;
        private string firstName;
        private string lastName;
        private string userEmail;
        private string userAddress;
        private string userPhone;

        public PracticeFormSteps(WebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"I am on the DemoQA page ""(.*)""")]
        [Given(@"I navigate to the ""Forms"" category and ""Practice Form"" section")]
        public void NavigateToPracticeForm(string url)
        {
            driver.Navigate().GoToUrl("https://demoqa.com/forms");
            driver.FindElement(By.LinkText("Practice Form")).Click();
        }

        [When(@"I fill the form with random data")]
        public void FillFormWithRandomData()
        {
            var faker = new Bogus.Faker();

            string firstName = faker.Name.FirstName();
            string lastName = faker.Name.LastName();
            string userEmail = $"{firstName}.{lastName}@example.com";
            string userAddress = faker.Address.StreetAddress();
            string userPhone = faker.Phone.PhoneNumber();

            driver.FindElement(By.Id("firstName")).SendKeys(firstName);
            driver.FindElement(By.Id("lastName")).SendKeys(lastName);
            driver.FindElement(By.Id("userEmail")).SendKeys(userEmail);
            driver.FindElement(By.Id("userAddress")).SendKeys(userAddress);
            driver.FindElement(By.Id("userNumber")).SendKeys(userPhone);

            var genderField = driver.FindElement(By.CssSelector("[for='gender-female'] input"));
            genderField.Click();

            driver.FindElement(By.Id("dateOfBirthInput")).SendKeys("2000-01-10");

            var subjectFields = driver.FindElements(By.CssSelector("[name='subjects'] input"));
            foreach (var field in subjectFields)
                if (field.GetAttribute("value").Contains("Physics") || field.GetAttribute("value").Contains("Maths"))
                {
                    field.Click();
                }

            var hobbiesFields = driver.FindElements(By.CssSelector("[name='hobbies] input"));
            foreach (var field in hobbiesFields)
            {
                if (field.GetAttribute("values").Contains("Reading") || field.GetAttribute("values").Contains("Music"))
                {
                    field.Click();
                }
            }

            driver.FindElement(By.Id("state")).Click();
            driver.FindElement(By.XPath("//option[text()='Uttar Pradesh']")).Click();

            driver.FindElement(By.Id("city")).Click();
            driver.FindElement(By.XPath("//option[text()='Merrut']")).Click();
        }

        [Then(@"I submit the form")]
        public void SubmitFrom()
        {
            driver.FindElement(By.Id("submit")).Click();
        }
        [Then(@"I should see the model with submitted data matching my input")]
        public void VerifySubmittedData()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("example-modal-sizes-title-lg")));

            Assert.Multiple(() =>
            {
                Assert.That(firstName, Is.EqualTo(driver.FindElement(By.Id("firstName")).Text));
                Assert.That(lastName, Is.EqualTo(driver.FindElement(By.Id("lastName")).Text));
                Assert.That(userEmail, Is.EqualTo(driver.FindElement(By.Id("userEmail")).Text));
                Assert.That(userAddress, Is.EqualTo(driver.FindElement(By.Id("userAddress")).Text));
                Assert.That(userPhone, Is.EqualTo(driver.FindElement(By.Id("userPhone")).Text));
            });

            bool isFemaleSelected = driver.FindElement(By.CssSelector("[for='gender-female'] input")).Selected;
            Assert.That(isFemaleSelected, Is.True);

            Assert.That(driver.FindElement(By.CssSelector("dateOfBirthInput")).GetAttribute("value"), Is.EqualTo("200-01-10"));

            var selectSubjects = driver.FindElements(By.CssSelector(".mb-3:nth-child(3) label span[class='checkmark checked']"));
            var expectedSubjects = new List<string> { "Physics", "Maths" };
            Assert.That(selectSubjects.Select(s => s.Text).All(s => expectedSubjects.Contains(s)), Is.True);

            var selectedHobbies = driver.FindElements(By.CssSelector(".mb-3:nth-child(4) label span[class='checkmark checked']"));
            var expectedHobbies = new List<string> { "Reading", "Music" };
            Assert.That(selectedHobbies.Select(s => s.Text).All(s => expectedHobbies.Contains(s)), Is.True);

            Assert.That(driver.FindElement(By.Id("state")).Text, Is.EqualTo("Uttar Pradesh"));
            Assert.That(driver.FindElement(By.Id("city")).Text, Is.EqualTo("Merrut"));

            driver.FindElement(By.Id("closeLargeModel")).Click();
        }
    }
}
