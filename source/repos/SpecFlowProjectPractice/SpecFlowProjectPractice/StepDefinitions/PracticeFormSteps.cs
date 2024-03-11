using SpecFlowProjectPractice.Drivers;
using TechTalk.SpecFlow;
using SpecFlowProjectPractice.PageObjects;
using SpecFlowProjectPractice.Helper;
using Bogus;
using System.Text;

namespace SpecFlowProjectPractice.StepDefinitions
{
    [Binding]
    public class PracticeFormSteps
    {
        private WebDriverManager _driverManager;
        private readonly PracticeFormPage _practiceFormPage;
        private Faker _faker;
        private PopUpHandler popUpHandler;

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

            var firstName = _faker.Name.FirstName();
            var lastName = _faker.Name.LastName();
            var userEmail = $"{firstName}.{lastName}@example.com";
            var userAddress = _faker.Address.StreetAddress();
            var userPhone = _faker.Phone.PhoneNumber()
                .Replace("-", "")
                .Replace(".", "")
                .Replace("(", "")
                .Replace(")", "");
            userPhone = userPhone.Replace(" ", "");

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
            var expectedData = new Dictionary<string, string>()
            {
                ["Student Name"] = _faker.Name.FirstName() + " " + _faker.Name.LastName(),
                ["Student Email"] = $"{_faker.Name.FirstName()}.{_faker.Name.LastName()}@example.com",
                ["Gender"] = "Female",
                ["Subjects"] = "Maths, Physics", 
                ["Hobbies"] = "Reading, Music", 
                ["Address"] = _faker.Address.StreetAddress(),
                ["Mobile"] = _faker.Phone.PhoneNumber().Replace("-", "").Replace(".", "").Replace("(", "").Replace(")", ""),
                ["State and City"] = "Uttar Pradesh, Merrut"
            };

            bool allDataMatches = true;
            StringBuilder comparisonLog = new StringBuilder();

            foreach (var key in submittedData.Keys)
            {
                if (submittedData[key] != expectedData[key])
                {
                    allDataMatches = false;
                    comparisonLog.AppendLine($"  - {key}: Expected '{expectedData[key]}', Actual '{submittedData[key]}'");
                }
            }

            if (allDataMatches)
            {
                Console.WriteLine("Submitted data matches expected data!");
            }
            else
            {
                Console.WriteLine("Submitted data does not match expected data!");
                Console.WriteLine(comparisonLog.ToString());
            }
        }

    }
}
