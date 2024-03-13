using SpecFlowProjectPractice.Drivers;
using TechTalk.SpecFlow;
using SpecFlowProjectPractice.PageObjects;
using SpecFlowProjectPractice.Helper;
using Bogus;
using NUnit.Framework;
using SpecFlowProjectPractice.Models;

namespace SpecFlowProjectPractice.StepDefinitions
{
    [Binding]
    public class PracticeFormSteps
    {
        private WebDriverManager _driverManager;
        private PracticeFormPage _practiceFormPage;
        private Faker _faker;
        private PopUpHandler popUpHandler;
        private PracticeFormData _formData = new PracticeFormData();
        private StudentInfoModel userData;

        public PracticeFormSteps(WebDriverManager driverManager)
        {
            _driverManager = driverManager;
            popUpHandler = new PopUpHandler(driverManager);
            _faker = new Faker();
            _practiceFormPage = new PracticeFormPage(_driverManager);
        }

        [Given(@"I fill the form with random data")]
        public void FillFormWithRandomData()
        {
            _formData.FirstName = _faker.Name.FirstName();
            _formData.LastName = _faker.Name.LastName();
            _formData.Email = $"{_formData.FirstName}.{_formData.LastName}@example.com";
            _formData.Address = _faker.Address.StreetAddress();
            _formData.PhoneNumber = _faker.Phone.PhoneNumber()
                .Replace("-", "")
                .Replace(".", "")
                .Replace("(", "")
                .Replace(")", "")
                .Replace("x", "")
                .Replace(" ", "")
                .Substring(0, 10);
            _practiceFormPage.FillForm(_formData);
            _practiceFormPage.SelectGender(_formData.Gender);
            _practiceFormPage.SetDateOfBirth("2000-01-10");
            _practiceFormPage.SelectState(_formData.State);
            _practiceFormPage.SelectCity(_formData.City);
            _practiceFormPage.SelectSubjects("Maths");
            _practiceFormPage.SelectSubjects("Physics");
            _practiceFormPage.SelectHobbies(new[] { "Reading", "Music" });
            
        }

        [When(@"I click the Submit button")]
        public void WhenISubmitTheForm()
        {
            _practiceFormPage.ClickSubmit();
        }

        [Then(@"I should see the model with submitted data matching my input")]
        public void ThenIShouldSeeTheSubmittedDataMatchingMyInput()
        {
            var submittedData = _practiceFormPage.GetSubmittedData();
            userData = new StudentInfoModel(submittedData);

            var expectedDoB = "10 March,2000";
            var expectedSubjects = new List<string> { "Maths", "Physics" };
            var expectedHobbies = new List<string> { "Reading", "Music" };

            Assert.AreEqual(_formData.FirstName, userData.StudentName.Split(' ').First());
            Assert.AreEqual(_formData.LastName, userData.StudentName.Split(' ').Last());
            Assert.AreEqual(_formData.Email, userData.StudentEmail);
            Assert.AreEqual(_formData.PhoneNumber, userData.Mobile);
            Assert.AreEqual(_formData.Address, userData.Address);
            Assert.AreEqual(_formData.Gender, userData.Gender);
            Assert.AreEqual(expectedDoB, userData.DateOfBirth);
            Assert.AreEqual(_formData.Address, userData.Address);
            CollectionAssert.AreEquivalent(expectedSubjects, userData.Subjects);
            CollectionAssert.AreEquivalent(expectedHobbies, userData.Hobbies);
            Assert.AreEqual($"{_formData.State} {_formData.City}", userData.StateAndCity);
        }
    }
}