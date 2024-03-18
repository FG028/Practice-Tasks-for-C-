using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SpecFlowPracticeTask.POM;
using SpecFlowPracticeTask.Hooks;

[Binding]
public class PracticeFormSteps
{
    private readonly PracticeFormPage practiceFormPage;
    WebDriver driver = WebDriverManager.GetDriver();

    private string firstName;
    private string lastName;
    private string userEmail;
    private string userAddress;
    private string userPhone;

    public PracticeFormSteps(WebDriver _driver)
    {
        driver = _driver;
        practiceFormPage = new PracticeFormPage(driver);
    }

    [Given(@"I am on the DemoQA page ""https://demoqa.com/automation-practice-form""")]
    public void NavigateToDemoQA()
    {
        practiceFormPage.NavigateToPage();
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

        practiceFormPage.FillForm(firstName, lastName, userEmail, userAddress, userPhone);

        practiceFormPage.SelectGender(faker.Random.Bool());
        practiceFormPage.SetDateOfBirth("2000-01-10");

        practiceFormPage.SelectSubjects(new[] { "Physics", "Maths" });
        practiceFormPage.SelectHobbies(new[] { "Reading", "Music" });

        practiceFormPage.SelectState("Uttar Pradesh");
        practiceFormPage.SelectCity("Merrut");
    }

    [Then(@"I submit the form")]
    public void SubmitForm()
    {
        practiceFormPage.SubmitButton.Click();
    }

    [Then(@"I should see the model with submitted data matching my input")]
    public void VerifySubmittedData()
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("example-modal-sizes-title-lg")));

        Assert.Multiple(() =>
        {
            Assert.That(firstName, Is.EqualTo(practiceFormPage.FirstNameInput.Text));
            Assert.That(lastName, Is.EqualTo(practiceFormPage.LastNameInput.Text));
            Assert.That(userEmail, Is.EqualTo(practiceFormPage.UserEmailInput.Text));
            Assert.That(userAddress, Is.EqualTo(practiceFormPage.UserAddressInput.Text));
            Assert.That(userPhone, Is.EqualTo(practiceFormPage.UserPhoneInput.Text));

            var isFemaleSelected = practiceFormPage.FemaleGenderRadio.Selected;
            Assert.That(isFemaleSelected || !practiceFormPage.MaleGenderRadio.Selected);

            Assert.That(practiceFormPage.DateOfBirthInput.GetAttribute("value"), Is.EqualTo("2000-01-10"));

            var selectedSubjects = practiceFormPage.SubjectCheckBoxes
                .Where(x => x.Selected)
                .Select(x => x.GetAttribute("value"))
                .ToList();
            Assert.That(selectedSubjects, Is.EquivalentTo(new[] { "Physics", "Maths" }));

            var selectedHobbies = practiceFormPage.HobbyCheckBoxes
                .Where(x => x.Selected)
                .Select(x => x.GetAttribute("values"))
                .ToList();
            Assert.That(selectedHobbies, Is.EquivalentTo(new[] { "Reading", "Music" }));

            var stateSelectElement = new SelectElement(practiceFormPage.StateDropDown);
            var citySelectElement = new SelectElement(practiceFormPage.CityDropDown);
            Assert.That(stateSelectElement.SelectedOption.Text, Is.EqualTo("Uttar Pradesh"));
            Assert.That(citySelectElement.SelectedOption.Text, Is.EqualTo("Merrut"));
        });
        practiceFormPage.CloseModalButton.Click();
    }
}