using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace SpecFlowPracticeTask.POM
{
    public class PracticeFormPage
    {
        private readonly IWebDriver driver;

        public PracticeFormPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "firstName")]
        public IWebElement FirstNameInput { get; set; }

        [FindsBy(How = How.Id, Using = "lastName")]
        public IWebElement LastNameInput { get; set; }

        [FindsBy(How = How.Id, Using = "userEmail")]
        public IWebElement UserEmailInput { get; set; }

        [FindsBy(How = How.Id, Using = "userAddress")]
        public IWebElement UserAddressInput { get; set; }

        [FindsBy(How = How.Id, Using = "userNumber")]
        public IWebElement UserPhoneInput { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[for='gender-female'] input")]
        public IWebElement FemaleGenderRadio { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[for='gender-male'] input")]
        public IWebElement MaleGenderRadio { get; set; }

        [FindsBy(How = How.Id, Using = "dateOfBirthInput")]
        public IWebElement DateOfBirthInput { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[name='subjects'] input")]
        public IReadOnlyCollection<IWebElement> SubjectCheckBoxes { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[name='hobbies'] input")]
        public IReadOnlyCollection<IWebElement> HobbyCheckBoxes { get; set; }

        [FindsBy(How = How.Id, Using = "state")]
        public IWebElement StateDropDown { get; set; }

        [FindsBy(How = How.Id, Using = "city")]
        public IWebElement CityDropDown { get; set; }

        [FindsBy(How = How.Id, Using = "submit")]
        public IWebElement SubmitButton { get; set; }

        [FindsBy(How = How.Id, Using = "closeLargeModel")]
        public IWebElement CloseModalButton { get; set; }

        public void NavigateToPage()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/text-box");
        }

        public void NavigateToAutoCompleteSection()
        {
            driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div[1]/div/div/div[2]/div/ul/li")).Click();
        }

        public void FillForm(string firstName, string lastName, string email, string address, string phone)
        {
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
            var stateOption = driver.FindElement(By.XPath($"//option[text()='{state}']"));
            stateOption.Click();
        }

        public void SelectCity(string city)
        {
            CityDropDown.Click();
            var cityOption = driver.FindElement(By.XPath($"//option[text()='{city}']"));
            cityOption.Click();
        }
    }
}
