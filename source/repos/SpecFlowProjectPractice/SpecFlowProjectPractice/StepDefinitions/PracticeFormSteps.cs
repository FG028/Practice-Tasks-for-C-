using SpecFlowProjectPractice.Drivers;
using TechTalk.SpecFlow;
using SpecFlowProjectPractice.PageObjects;
using SpecFlowProjectPractice.Helper;
using Bogus;
using NUnit.Framework;

namespace SpecFlowProjectPractice.StepDefinitions
{
    [Binding]
    public class PracticeFormSteps
    {
        private WebDriverManager _driverManager;
        private readonly PracticeFormPage _practiceFormPage;
        private Faker _faker;
        private PopUpHandler popUpHandler;
        private string firstName;
        private string lastName;
        private string userEmail;
        private string userAddress;
        private string userPhone;

        public PracticeFormSteps(WebDriverManager driverManager)
        {
            _driverManager = driverManager;
            popUpHandler = new PopUpHandler(driverManager);
            _faker = new Faker();
            _practiceFormPage = new PracticeFormPage(_driverManager);
        }

        [When(@"I fill the form with random data")]
        public void FillFormWithRandomData()
        {
            var faker = new Bogus.Faker();

            firstName = _faker.Name.FirstName();
            lastName = _faker.Name.LastName();
            userEmail = $"{firstName}.{lastName}@example.com";
            userAddress = _faker.Address.StreetAddress();

            userPhone = _faker.Phone.PhoneNumber()
              .Replace("-", "")
              .Replace(".", "")
              .Replace("(", "")
              .Replace(")", "")
              .Replace("x", "")
              .Replace(" ", "")
              .Substring(0, 10);

            _practiceFormPage.FillForm(firstName, lastName, userEmail, userAddress, userPhone);
            _practiceFormPage.SelectGender();
            _practiceFormPage.SetDateOfBirth("2000-01-10");
            _practiceFormPage.SelectState("Uttar Pradesh");
            _practiceFormPage.SelectCity("Merrut");
            _practiceFormPage.SelectSubjects("Maths");
            _practiceFormPage.SelectSubjects("Physics");
            _practiceFormPage.SelectHobbies(new[] { "Reading", "Music" });
        }

        [Then(@"I click the Submit button")]
        public void WhenISubmitTheForm()
        {
            _practiceFormPage.ClickSubmit();
        }

        [Then(@"I should see the model with submitted data matching my input")]
        public void VerifySubmittedData()
        {
            var submittedData = _practiceFormPage.GetSubmittedData();

            var expectedFirstName = firstName;
            var expectedLastName = lastName;
            var expectedEmail = userEmail;
            var expectedMobile = userPhone;
            var expectedAddress = userAddress;
            var expectedGender = "Female";
            var expectedDoB = "10 March,2000";
            var expectedState = "Uttar Pradesh";
            var expectedCity = "Merrut";
            var expectedSubjects = new List<string> { "Maths", "Physics" };
            var expectedHobbies = new List<string> { "Reading", "Music" };

            Assert.AreEqual(expectedFirstName, submittedData["Student Name"].Split(' ').First());
            Assert.AreEqual(expectedLastName, submittedData["Student Name"].Split(' ').Last());
            Assert.AreEqual(expectedEmail, submittedData["Student Email"]);
            Assert.AreEqual(expectedMobile, submittedData["Mobile"]);
            Assert.AreEqual(expectedAddress, submittedData["Address"]);

            Assert.AreEqual(expectedGender, submittedData["Gender"] ?? "Female");
            Assert.AreEqual(expectedDoB, submittedData["Date of Birth"]);
            CollectionAssert.AreEquivalent(expectedSubjects, submittedData["Subjects"].Split(',').Select(x => x.Trim()).ToList());
            CollectionAssert.AreEquivalent(expectedHobbies, submittedData["Hobbies"].Split(',').Select(x => x.Trim()).ToList());
            Assert.AreEqual($"{expectedState} {expectedCity}", submittedData["State and City"]!);
        }
    }
}