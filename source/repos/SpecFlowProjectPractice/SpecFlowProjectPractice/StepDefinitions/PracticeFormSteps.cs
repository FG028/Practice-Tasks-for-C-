using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowProjectPractice.Drivers;
using TechTalk.SpecFlow;
using SpecFlowProjectPractice.PageObjects;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Bogus;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowProjectPractice.StepDefinitions
{
    [Binding]
    public class PracticeFormSteps
    {
        private WebDriverManager _driverManager;
        private readonly PracticeFormPage _practiceFormPage;
        private Faker _faker;

        public PracticeFormSteps(WebDriverManager driverManager)
        {
            _driverManager = driverManager;
            _faker = new Faker();
            _practiceFormPage = new PracticeFormPage(_driverManager);
        }

        [When(@"I fill the form with random data")]
        public void FillFormWithRandomData()
        {
            _practiceFormPage.PopUpButtonConfirmation();

            var faker = new Bogus.Faker();

            var firstName = _faker.Name.FirstName();
            var lastName = _faker.Name.LastName();
            var userEmail = $"{firstName}.{lastName}@example.com";
            var userAddress = _faker.Address.StreetAddress();
            var userPhone = _faker.Phone.PhoneNumber();

            _practiceFormPage.FillForm(firstName, lastName, userEmail, userAddress, userPhone);

            _practiceFormPage.SelectGender();
            _practiceFormPage.SetDateOfBirth("2000-01-10");

            _practiceFormPage.SelectSubjects("Physics, Maths");
            _practiceFormPage.SelectHobbies(new[] { "Reading", "Music" });

            _practiceFormPage.SelectState("Uttar Pradesh");
            _practiceFormPage.SelectCity("Merrut");
        }

        [Then(@"I click the Submit button")]
        public void WhenISubmitTheForm()
        {
            _practiceFormPage.ClickSubmit();
        }

        [Then(@"I should see the model with submitted data matching my input")]
        public void VerifySubmittedData(Dictionary<string, string> expectedData)
        {
            var submittedData = _practiceFormPage.GetSubmittedData();

            var table = new Table("Field", "Expected Value", "Actual Value");
            foreach (var key in submittedData.Keys)
            {
                table.AddRow(key, expectedData[key], submittedData[key]);
            }

            Assert.That(table.CreateInstance<Dictionary<string, string>>(), Is.EquivalentTo(expectedData));
        }
    }
}
