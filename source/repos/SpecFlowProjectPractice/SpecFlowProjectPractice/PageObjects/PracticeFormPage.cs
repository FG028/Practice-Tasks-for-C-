﻿using Bogus;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SpecFlowProjectPractice.Drivers;
using System;



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
            /*var popup = _driverManager.Driver().FindElement(By.CssSelector("body > div.fc-consent-root > div.fc-dialog-container > div.fc-dialog.fc-choice-dialog > div.fc-dialog-content"));
            popup.FindElement(By.XPath("/html/body/div[3]/div[2]/div[1]/div[2]/div[2]/button[1]/p")).Click();q*/
        }

        public bool IsValidMobileNumber(string phoneNumber)
        {
            return phoneNumber.Length == 10 && !phoneNumber.StartsWith("0");
        }


        public void FillForm(string firstName, string lastName, string email, string address, string phone)
        {
            _driverManager.Driver().FindElement(By.Id("firstName")).SendKeys(firstName);
            _driverManager.Driver().FindElement(By.Id("lastName")).SendKeys(lastName);
            _driverManager.Driver().FindElement(By.Id("userEmail")).SendKeys(email);
            _driverManager.Driver().FindElement(By.Id("userNumber")).SendKeys(phone);
            _driverManager.Driver().FindElement(By.Id("currentAddress")).SendKeys(address);
        }

        public void SetDateOfBirth(string date)
        {
            _driverManager.Driver().FindElement(By.Id("dateOfBirthInput")).Click();
            _driverManager.Driver().FindElement(By.CssSelector(".react-datepicker__month-select")).SendKeys(date.Split('-')[1]); // Select Month
            _driverManager.Driver().FindElement(By.CssSelector(".react-datepicker__year-select")).SendKeys(date.Split('-')[0]); // Select Year
            _driverManager.Driver().FindElement(By.XPath("//div[contains(@class, 'react-datepicker__day') and text()='" + date.Split('-')[2] + "']")).Click(); // Select Day
        }

        public void SelectGender()
        {
            var maleRadioButton = _driverManager.Driver().FindElement(By.Id("gender-radio-1"));
            var femaleRadioButton = _driverManager.Driver().FindElement(By.Id("gender-radio-2"));
            var otherRadioButton = _driverManager.Driver().FindElement(By.Id("gender-radio-3"));

            var jsExecutor = (IJavaScriptExecutor)_driverManager.Driver();
            jsExecutor.ExecuteScript("arguments[0].click();", femaleRadioButton);
        }

        public void SelectSubjects(string subject)
        {
            try
            {
                _driverManager.Driver().FindElement(By.XPath("//*[@id='subjectsContainer']/div/div[1]")).Click();

                var subjectsInput = _driverManager.Driver().FindElement(By.Id("subjectsInput"));
                Actions actions = new Actions(_driverManager.Driver());
                actions.SendKeys(subject).Perform();
            }
            catch (WebDriverException ex)
            {
                Console.WriteLine("Error during wait: " + ex.Message);
            }
        }

        public void SelectHobbies(string[] hobbiesToSelect)
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
            stateDropdown.Click();

            Actions actions = new Actions(_driverManager.Driver());
            actions.SendKeys(stateName + Keys.Enter).Perform();
        }

        public void SelectCity(string cityName)
        {

            IWebElement cityDropdown = _driverManager.Driver().FindElement(By.Id("city"));
            cityDropdown.Click();

            Actions actions = new Actions(_driverManager.Driver());
            actions.SendKeys(cityName + Keys.Enter).Perform();
        }

        public void ClickSubmit()
        {
            var SubmitButton = _driverManager.Driver().FindElement(By.Id("submit"));
            var jsExecutor = (IJavaScriptExecutor)_driverManager.Driver();
            jsExecutor.ExecuteScript("arguments[0].click();", SubmitButton);
            
        }

        public Dictionary<string, string> GetSubmittedData()
        {
            var data = new Dictionary<string, string>();
            data["Student Name"] = _driverManager.Driver().FindElement(By.XPath("/html/body/div[4]/div/div/div[2]/div/table/tbody/tr[1]/td[2]]")).Text;
            data["Student Email"] = _driverManager.Driver().FindElement(By.XPath("/html/body/div[4]/div/div/div[2]/div/table/tbody/tr[2]/td[2]")).Text;
            data["Gender"] = _driverManager.Driver().FindElement(By.XPath("/html/body/div[4]/div/div/div[2]/div/table/tbody/tr[3]/td[2]")).Text;
            data["Date of Birth"] = _driverManager.Driver().FindElement(By.XPath("/html/body/div[4]/div/div/div[2]/div/table/tbody/tr[5]/td[2]")).GetAttribute("value");
            data["Subjects"] = _driverManager.Driver().FindElements(By.XPath("/html/body/div[4]/div/div/div[2]/div/table/tbody/tr[6]/td[2]")).Select(x => x.Text).Aggregate((a, b) => $"{a}, {b}"); // Get and combine subject texts
            data["Hobbies"] = _driverManager.Driver().FindElements((By.XPath("/html/body/div[4]/div/div/div[2]/div/table/tbody/tr[7]/td[2]"))).Select(x => x.Text).Aggregate((a, b) => $"{a}, {b}"); // Get and combine hobby texts
            data["Address"] = _driverManager.Driver().FindElement(By.XPath("/html/body/div[4]/div/div/div[2]/div/table/tbody/tr[9]/td[2]")).Text;
            data["Mobile"] = _driverManager.Driver().FindElement(By.XPath("/html/body/div[4]/div/div/div[2]/div/table/tbody/tr[4]/td[2]")).Text;

            data["State and City"] = _driverManager.Driver().FindElement(By.XPath("/html/body/div[4]/div/div/div[2]/div/table/tbody/tr[10]/td[2]")).Text;

            return data;
        }
    }
}