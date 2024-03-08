using Bogus;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SpecFlowProjectPractice.Drivers;
using System.Security.Cryptography.X509Certificates;


namespace SpecFlowProjectPractice.PageObjects
{
    public class PracticeFormPage
    {
        private readonly WebDriverManager _driverManager;
        private Faker _faker;

        public PracticeFormPage(WebDriverManager driverManager)
        {
            _driverManager = driverManager;
            _faker = new Faker();
        }

        public void PopUpButtonConfirmation()
        {
            var popup = _driverManager.Driver().FindElement(By.CssSelector("body > div.fc-consent-root > div.fc-dialog-container > div.fc-dialog.fc-choice-dialog > div.fc-dialog-content"));
            popup.FindElement(By.XPath("/html/body/div[3]/div[2]/div[1]/div[2]/div[2]/button[1]/p")).Click();
        }

        public void FillForm(string firstName, string lastName, string email, string address, string phone)
        {
            _driverManager.Driver().FindElement(By.Id("firstName")).SendKeys(firstName);
            _driverManager.Driver().FindElement(By.Id("lastName")).SendKeys(lastName);
            _driverManager.Driver().FindElement(By.Id("userEmail")).SendKeys(email);
            _driverManager.Driver().FindElement(By.Id("userNumber")).SendKeys(phone);
            _driverManager.Driver().FindElement(By.Id("currentAddress")).SendKeys(address);
        }

        public void SelectGender()
        {
            var maleRadioButton = _driverManager.Driver().FindElement(By.Id("gender-radio-1"));
            var femaleRadioButton = _driverManager.Driver().FindElement(By.Id("gender-radio-2"));
            var otherRadioButton = _driverManager.Driver().FindElement(By.Id("gender-radio-3"));

            var jsExecutor = (IJavaScriptExecutor)_driverManager.Driver();
            jsExecutor.ExecuteScript("arguments[0].click();", femaleRadioButton);
        }

        public void SetDateOfBirth(string date)
        {
            _driverManager.Driver().FindElement(By.Id("dateOfBirthInput")).Click();
            _driverManager.Driver().FindElement(By.CssSelector(".react-datepicker__month-select")).SendKeys(date.Split('-')[1]); // Select Month
            _driverManager.Driver().FindElement(By.CssSelector(".react-datepicker__year-select")).SendKeys(date.Split('-')[0]); // Select Year
            _driverManager.Driver().FindElement(By.XPath("//div[contains(@class, 'react-datepicker__day') and text()='" + date.Split('-')[2] + "']")).Click(); // Select Day
        }


        public void SelectSubjects(string subjects)
        {
            _driverManager.Driver().FindElement(By.XPath("//*[@id='subjectsContainer']/div/div[1]")).Click();
            var subjectsInput = _driverManager.Driver().FindElement(By.Id("subjectsInput"));
            subjectsInput.SendKeys(subjects);

        }

        public void SelectHobbies(string[] hobbiesToSelect)
        {
            IWebElement sportCheckbox =  _driverManager.Driver().FindElement(By.Id("hobbies-checkbox-1"));
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
                    jsExecutor.ExecuteScript("arguments[0].click();",musicCheckbox);
                } else
                {
                    return;
                }
            }
        }

        public void SelectState(string stateName)
        {
            IWebElement stateDropdown = _driverManager.Driver().FindElement(By.Id("state"));
            stateDropdown.Click();

            Actions actions = new Actions(_driverManager.Driver());
            actions.SendKeys(stateName + Keys.Enter).Perform();
        }

        public void SelectCity(string city)
        {

            IWebElement cityDropdown = _driverManager.Driver().FindElement(By.Id("city"));
            cityDropdown.Click();
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driverManager.Driver();
            jsExecutor.ExecuteScript("arguments[0].querySelector('option[text=Merrut]').selected = true;", cityDropdown);
        }

        public void ClickSubmit()
        {
            _driverManager.Driver().FindElement(By.Id("submit")).Click();
        }

        public Dictionary<string, string> GetSubmittedData()
        {
            var data = new Dictionary<string, string>();
            data["Student Name"] = _driverManager.Driver().FindElement(By.CssSelector(".table-responsive tbody tr:nth-child(1) td:nth-child(2)")).Text;
            data["Student Email"] = _driverManager.Driver().FindElement(By.CssSelector(".table-responsive tbody tr:nth-child(2) td:nth-child(2)")).Text;
            data["Gender"] = _driverManager.Driver().FindElement(By.CssSelector("label.custom-control-label.active")).Text; // Get text of active gender label
            data["Date of Birth"] = _driverManager.Driver().FindElement(By.CssSelector("#dateOfBirthInput")).GetAttribute("value"); // Get date of birth input value
            data["Subjects"] = _driverManager.Driver().FindElements(By.CssSelector(".table-responsive tbody tr:nth-child(5) td:nth-child(2) span")).Select(x => x.Text).Aggregate((a, b) => $"{a}, {b}"); // Get and combine subject texts
            data["Hobbies"] = _driverManager.Driver().FindElements(By.CssSelector(".table-responsive tbody tr:nth-child(6) td:nth-child(2) span")).Select(x => x.Text).Aggregate((a, b) => $"{a}, {b}"); // Get and combine hobby texts
            data["Address"] = _driverManager.Driver().FindElement(By.CssSelector(".table-responsive tbody tr:nth-child(3) td:nth-child(2)")).Text;
            data["Mobile"] = _driverManager.Driver().FindElement(By.CssSelector(".table-responsive tbody tr:nth-child(4) td:nth-child(2)")).Text;

            data["State"] = _driverManager.Driver().FindElement(By.CssSelector(".table-responsive tbody tr:nth-child(7) td:nth-child(2)")).Text; // Adjust selector as needed
            data["City"] = _driverManager.Driver().FindElement(By.CssSelector(".table-responsive tbody tr:nth-child(8) td:nth-child(2)")).Text; // Adjust selector as needed

            return data;
        }
    }
}
