using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowProjectPractice.Drivers;
using TechTalk.SpecFlow;
using SpecFlowProjectPractice.PageObjects;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SpecFlowProjectPractice.StepDefinitions
{
    [Binding]
    public class PracticeFormSteps
    {
        private WebDriverManager _driverManager;
        private readonly PracticeFormPage _practiceFormPage;
        private string firstName;
        private string lastName;
        private string userEmail;
        private string userAddress;
        private string userPhone;

        public PracticeFormSteps(WebDriverManager driverManager)
        {
            _driverManager = driverManager;
            _practiceFormPage = new PracticeFormPage(_driverManager);
        }

        [When(@"I fill the form with random data")]
        public void FillFormWithRandomData()
        {
            var faker = new Bogus.Faker();

            firstName = faker.Name.FirstName();
            lastName = faker.Name.LastName();
            userEmail = $"{firstName}.{lastName}@example.com";
            userAddress = faker.Address.StreetAddress();
            userPhone = faker.Phone.PhoneNumber();

            _practiceFormPage.FillForm(firstName, lastName, userEmail, userAddress, userPhone);

            _practiceFormPage.SelectGender(faker.Random.Bool());
            _practiceFormPage.SetDateOfBirth("2000-01-10");

            _practiceFormPage.SelectSubjects(new[] { "Physics", "Maths" });
            _practiceFormPage.SelectHobbies(new[] { "Reading", "Music" });

            _practiceFormPage.SelectState("Uttar Pradesh");
            _practiceFormPage.SelectCity("Merrut");
        }

        [Then(@"I click the Submit button")]
        public void WhenISubmitTheForm()
        {
            _practiceFormPage.SubmitButton.Click();
        }

        [Then(@"I should see the model with submitted data matching my input")]
        public void VerifySubmittedData()
        {
            WebDriverWait wait = new WebDriverWait(_driverManager.Driver(), TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("example-modal-sizes-title-lg")));

            Assert.Multiple(() =>
            {
                Assert.That(firstName, Is.EqualTo(_practiceFormPage.FirstNameInput.Text));
                Assert.That(lastName, Is.EqualTo(_practiceFormPage.LastNameInput.Text));
                Assert.That(userEmail, Is.EqualTo(_practiceFormPage.UserEmailInput.Text));
                Assert.That(userAddress, Is.EqualTo(_practiceFormPage.UserAddressInput.Text));
                Assert.That(userPhone, Is.EqualTo(_practiceFormPage.UserPhoneInput.Text));

                var isFemaleSelected = _practiceFormPage.FemaleGenderRadio.Selected;
                Assert.That(isFemaleSelected || !_practiceFormPage.MaleGenderRadio.Selected);

                Assert.That(_practiceFormPage.DateOfBirthInput.GetAttribute("value"), Is.EqualTo("2000-01-10"));

                var selectedSubjects = _practiceFormPage.SubjectCheckBoxes
                    .Where(x => x.Selected)
                    .Select(x => x.GetAttribute("value"))
                    .ToList();
                Assert.That(selectedSubjects, Is.EquivalentTo(new[] { "Physics", "Maths" }));

                var selectedHobbies = _practiceFormPage.HobbyCheckBoxes
                    .Where(x => x.Selected)
                    .Select(x => x.GetAttribute("values"))
                    .ToList();
                Assert.That(selectedHobbies, Is.EquivalentTo(new[] { "Reading", "Music" }));

                var stateSelectElement = new SelectElement(_practiceFormPage.StateDropDown);
                var citySelectElement = new SelectElement(_practiceFormPage.CityDropDown);
                Assert.That(stateSelectElement.SelectedOption.Text, Is.EqualTo("Uttar Pradesh"));
                Assert.That(citySelectElement.SelectedOption.Text, Is.EqualTo("Merrut"));
            });

            _practiceFormPage.CloseModalButton.Click();
        }
    }
}
