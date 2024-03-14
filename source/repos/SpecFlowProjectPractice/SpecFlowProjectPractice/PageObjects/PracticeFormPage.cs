using Bogus;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SpecFlowProjectPractice.Drivers;
using SpecFlowProjectPractice.Models;

namespace SpecFlowProjectPractice.PageObjects
{
    public class PracticeFormPage
    {
        private readonly WebDriverManager _driverManager;
        public StudentInfoModel _formData;
        private Faker _faker;

        public PracticeFormPage(WebDriverManager driverManager)
        {
            _driverManager = driverManager;
            _faker = new Faker();
        }
        
        public void FillForm(StudentInfoModel formData)
        {
            _driverManager.Driver().FindElement(By.Id("firstName")).SendKeys(formData.StudentName.Split(' ').First());
            _driverManager.Driver().FindElement(By.Id("lastName")).SendKeys(formData.StudentName.Split(' ').Last());
            _driverManager.Driver().FindElement(By.Id("userEmail")).SendKeys(formData.StudentEmail);
            _driverManager.Driver().FindElement(By.Id("userNumber")).SendKeys((formData.Mobile));
            _driverManager.Driver().FindElement(By.Id("currentAddress")).SendKeys(formData.Address);
        }

        public string GetRandomDateOfBirth(string dateOfBirth)
        {
            var random = new Random();
            int year = random.Next(2000, 2099);
            int month = random.Next(1, 13);
            int day = random.Next(1, DateTime.DaysInMonth(year, month));
            var dob = new DateTime(year, month, day);
            return dob.ToString("yyyy-MM-dd");
        }

        public void SetDateOfBirth(string dateOfBirth)
        {
            var dateOfBirthInput = _driverManager.Driver().FindElement(By.Id("dateOfBirthInput"));
            dateOfBirthInput.Click();
            dateOfBirthInput.Clear();
            dateOfBirthInput.SendKeys(GetRandomDateOfBirth(dateOfBirth) + Keys.Enter);
        }

        public void SelectGender(string Gender)
        {
            var maleRadioButton = _driverManager.Driver().FindElement(By.Id("gender-radio-1"));
            var femaleRadioButton = _driverManager.Driver().FindElement(By.Id("gender-radio-2"));
            var otherRadioButton = _driverManager.Driver().FindElement(By.Id("gender-radio-3"));

            var jsExecutor = (IJavaScriptExecutor)_driverManager.Driver();
            jsExecutor.ExecuteScript("arguments[0].click();", femaleRadioButton);
            /*
            var jsExecutor = (IJavaScriptExecutor)_driverManager.Driver();
            switch (gender.ToLower())
            {
              case "male":
                jsExecutor.ExecuteScript("arguments[0].click();", _driverManager.Driver().FindElement(By.Id("gender-radio-1")));
                break;
              case "female":
                jsExecutor.ExecuteScript("arguments[0].click();", _driverManager.Driver().FindElement(By.Id("gender-radio-2")));
                break;
              case "other":
                jsExecutor.ExecuteScript("arguments[0].click();", _driverManager.Driver().FindElement(By.Id("gender-radio-3")));
                break;
            }*/
        }

        public void SelectSubjects(List<string> subjects)
        {
            try
            {
                _driverManager.Driver().FindElement(By.XPath("//*[@id='subjectsContainer']/div/div[1]")).Click();

                foreach (var subject in subjects)
                {
                    Actions actions = new Actions(_driverManager.Driver());
                    actions.SendKeys(subject);
                    actions.Build().Perform();

                    WebDriverWait wait = new WebDriverWait(_driverManager.Driver(), TimeSpan.FromSeconds(2));
                    wait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"//*[@id='react-select-2-option-0']")));

                    var element = _driverManager.Driver().FindElement(By.XPath($"//*[@id='react-select-2-option-0']"));
                    var subjectText = element.Text;

                    if (subjectText.Equals(subject))
                    {
                        element.Click();
                    }
                }
            }
            catch (WebDriverException ex)
            {
                Console.WriteLine("Error during wait: " + ex.Message);
            }
        }

        public void SelectHobbies(List<string> hobbiesToSelect)
        {
            IWebElement sportCheckbox = _driverManager.Driver().FindElement(By.Id("hobbies-checkbox-1"));
            IWebElement readingCheckbox = _driverManager.Driver().FindElement(By.Id("hobbies-checkbox-2"));
            IWebElement musicCheckbox = _driverManager.Driver().FindElement(By.Id("hobbies-checkbox-3"));
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driverManager.Driver();

            foreach (var hobby in hobbiesToSelect)
            {
                if (hobby == "Reading")
                {
                    jsExecutor.ExecuteScript("arguments[0].click();", readingCheckbox);
                }
                else if (hobby == "Music")
                {
                    jsExecutor.ExecuteScript("arguments[0].click();", musicCheckbox);
                } else
                {
                    return;
                }
            }
        }

        public void SelectState(string stateName)
        {
            IWebElement stateDropdown = _driverManager.Driver().FindElement(By.Id("state"));
            ((IJavaScriptExecutor)_driverManager.Driver()).ExecuteScript(
            "arguments[0].scrollIntoView(true);", stateDropdown);
            stateDropdown.Click();
            IWebElement upOption = _driverManager.Driver().FindElement(By.CssSelector("#react-select-3-option-1"));
            upOption.Click();
        }
        public void SelectCity(string cityName)
        {
            IWebElement cityDropdown = _driverManager.Driver().FindElement(By.Id("city"));
            cityDropdown.Click();

            IWebElement upOption = _driverManager.Driver().FindElement(By.CssSelector("#react-select-4-option-2"));
            upOption.Click();
        }

        public void ClickSubmit()
        {
            var SubmitButton = _driverManager.Driver().FindElement(By.Id("submit"));
            var jsExecutor = (IJavaScriptExecutor)_driverManager.Driver();
            jsExecutor.ExecuteScript("arguments[0].click();", SubmitButton);
        }

        public StudentInfoModel GetSubmittedData()
        {
            return new StudentInfoModel
            {
            StudentName = _driverManager.Driver().FindElement(By.XPath(".//tr[1]/td[2]")).Text,
            StudentEmail = _driverManager.Driver().FindElement(By.XPath(".//tr[2]/td[2]")).Text,
            Gender = _driverManager.Driver().FindElement(By.XPath(".//tr[3]/td[2]")).Text,
            Mobile = _driverManager.Driver().FindElement(By.XPath(".//tr[4]/td[2]")).Text,
            DateOfBirth = _driverManager.Driver().FindElement(By.XPath(".//tr[5]/td[2]")).Text,
            Subjects = _driverManager.Driver().FindElements(By.XPath(".//tr[6]/td[2]")).Select(x => x.Text).ToList(),
            Hobbies = _driverManager.Driver().FindElements(By.XPath(".//tr[7]/td[2]")).Select(x => x.Text).ToList(),
            Address = _driverManager.Driver().FindElement(By.XPath(".//tr[9]/td[2]")).Text,
            StateAndCity = _driverManager.Driver().FindElement(By.XPath(".//tr[10]/td[2]")).Text,
            };
        }
    }
}