using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SpecFlowProjectPractice.Drivers;

namespace SpecFlowProjectPractice.PageObjects
{
    public class PracticeFormPage
    {
        private readonly WebDriverManager _driverManager;

        public PracticeFormPage(WebDriverManager driverManager)
        {
            _driverManager = driverManager;
        }

        public IWebElement FirstNameInput => _driverManager.Driver().FindElement(By.Id("firstName"));

        public IWebElement LastNameInput=> _driverManager.Driver().FindElement(By.Id("lastName"));

        public IWebElement UserEmailInput => _driverManager.Driver().FindElement(By.Id("userEmail"));

        public IWebElement UserAddressInput => _driverManager.Driver().FindElement(By.Id("userAddress"));

        public IWebElement UserPhoneInput => _driverManager.Driver().FindElement(By.Id("userNumber"));

        public IWebElement FemaleGenderRadio => _driverManager.Driver().FindElement(By.CssSelector("[for='gender-female'] input"));

        public IWebElement MaleGenderRadio => _driverManager.Driver().FindElement(By.CssSelector("[for='gender-male'] input"));

        public IWebElement DateOfBirthInput => _driverManager.Driver().FindElement(By.Id("dateOfBirthInput"));

        [FindsBy(How = How.CssSelector, Using = "[name='subjects'] input")]
        public IReadOnlyCollection<IWebElement> SubjectCheckBoxes { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[name='hobbies'] input")]
        public IReadOnlyCollection<IWebElement> HobbyCheckBoxes { get; set; }

        public IWebElement StateDropDown => _driverManager.Driver().FindElement(By.Id("state"));

        public IWebElement CityDropDown => _driverManager.Driver().FindElement(By.Id("state"));

        public IWebElement SubmitButton => _driverManager.Driver().FindElement(By.Id("state"));

        public IWebElement CloseModalButton => _driverManager.Driver().FindElement(By.Id("closeLargeModel"));


        public void FillForm(string firstName, string lastName, string email, string address, string phone)
        {
            // 'Object reference not set to an instance of an object.'
            FirstNameInput.SendKeys(firstName);
            LastNameInput.SendKeys(lastName);
            UserEmailInput.SendKeys(email);
            UserAddressInput.SendKeys(address);
            UserPhoneInput.SendKeys(phone);
        }

        public void SelectGender(bool isFemale)
        {
            if (isFemale)
            {
                FemaleGenderRadio.Click();
            }
            else
            {
                MaleGenderRadio.Click();
            }
        }

        public void SetDateOfBirth(string date)
        {
            DateOfBirthInput.SendKeys(date);
        }

        public void SelectSubjects(string[] subjects)
        {
            foreach (var subject in subjects)
            {
                var checkbox = SubjectCheckBoxes.FirstOrDefault(x => x.GetAttribute("value").Contains(subject));
                if (checkbox != null)
                {
                    checkbox.Click();
                }
            }
        }

        public void SelectHobbies(string[] hobbies)
        {
            foreach (var hobby in hobbies)
            {
                var checkbox = HobbyCheckBoxes.FirstOrDefault(x => x.GetAttribute("values").Contains(hobby));
                if (checkbox != null)
                {
                    checkbox.Click();
                }
            }
        }

        public void SelectState(string state)
        {
            StateDropDown.Click();
            var stateOption = _driverManager.Driver().FindElement(By.XPath($"//option[text()='{state}']"));
            stateOption.Click();
        }

        public void SelectCity(string city)
        {
            CityDropDown.Click();
            var cityOption = _driverManager.Driver().FindElement(By.XPath($"//option[text()='{city}']"));
            cityOption.Click();
        }
    }
}
