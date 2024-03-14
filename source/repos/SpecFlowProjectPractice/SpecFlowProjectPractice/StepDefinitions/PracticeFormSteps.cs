using SpecFlowProjectPractice.Drivers;
using TechTalk.SpecFlow;
using SpecFlowProjectPractice.PageObjects;
using SpecFlowProjectPractice.Helper;
using Bogus;
using NUnit.Framework;
using SpecFlowProjectPractice.Models;
using System.Linq;

namespace SpecFlowProjectPractice.StepDefinitions
{
    [Binding]
    public class PracticeFormSteps
    {
        private WebDriverManager _driverManager;
        private PracticeFormPage _practiceFormPage;
        private Faker _faker;
        private PopUpHandler popUpHandler;
        private StudentInfoModel _formData = new StudentInfoModel();

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
            _formData.StudentName = $"{_faker.Name.FirstName()} {_faker.Name.LastName()}";
            _formData.StudentEmail = $"{_formData.StudentName.Split(' ').First()}.{_formData.StudentName.Split(' ').Last()}@example.com";
            _formData.Address = _faker.Address.StreetAddress();
            _formData.Mobile = _faker.Phone.PhoneNumber()
                .Replace("-", "")
                .Replace(".", "")
                .Replace("(", "")
                .Replace(")", "")
                .Replace("x", "")
                .Replace(" ", "")
                .Substring(0, 10);

            _practiceFormPage.FillForm(_formData);
            _formData.Gender = "Female";
            _practiceFormPage.SelectGender(_formData.Gender);
            _formData.DateOfBirth = "14 March,202420";
            _practiceFormPage.SetDateOfBirth((_formData.DateOfBirth));
            _formData.State = "Uttar Pradesh";
            _practiceFormPage.SelectState(_formData.State);
            _formData.City = "Merrut";
            _practiceFormPage.SelectCity(_formData.City);

            _formData.Subjects = new List<string> { "Maths", "Physics" };
            _practiceFormPage.SelectSubjects(_formData.Subjects);

            _formData.Hobbies = new List<string> { "Reading", "Music" };
            _practiceFormPage.SelectHobbies(_formData.Hobbies);
        }

        [When(@"I click the Submit button")]
        public void WhenISubmitTheForm()
        {
            _practiceFormPage.ClickSubmit();
        }

        [Then(@"I should see the model with submitted data matching my input")]
        public void ThenIShouldSeeTheSubmittedDataMatchingMyInput()
        {
            StudentInfoModel userData = _practiceFormPage.GetSubmittedData();
            var expectedSubjects = string.Join(", ", _formData.Subjects);
            var expectedHobbies = string.Join(", ", _formData.Hobbies);


            Assert.AreEqual(_formData.StudentName.Split(' ').First(), userData.StudentName.Split(' ').First());
            Assert.AreEqual(_formData.StudentName.Split(' ').Last(), userData.StudentName.Split(' ').Last());
            Assert.AreEqual(_formData.StudentEmail, userData.StudentEmail);
            Assert.AreEqual(_formData.Mobile, userData.Mobile);
            Assert.AreEqual(_formData.Address, userData.Address);
            Assert.AreEqual(_formData.Gender, userData.Gender);
            Assert.AreEqual(_formData.DateOfBirth, userData.DateOfBirth);
            Assert.AreEqual(expectedSubjects, string.Join(", ", userData.Subjects));
            Assert.AreEqual(expectedHobbies, string.Join(", ", userData.Hobbies));
            Assert.AreEqual($"{_formData.State} {_formData.City}", userData.StateAndCity);
        }
    }
}