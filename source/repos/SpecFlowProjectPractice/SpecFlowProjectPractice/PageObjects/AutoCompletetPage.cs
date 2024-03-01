﻿using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SpecFlowProjectPractice.Drivers;

namespace SpecFlowProjectPractice.PageObjects
{
    public class AutoCompletePage
    {
        private readonly WebDriverManager _driverManager;

        public AutoCompletePage(WebDriverManager driverManager)
        {
            _driverManager = driverManager;
        }

        public void EnterText(string text, string fieldName)
        {
            // 'no such element: Unable to locate element
            var inputField = _driverManager.Driver().FindElement(By.Id("autoCompleteInput"));
            inputField.Clear();
            inputField.SendKeys(text);
            inputField.SendKeys(fieldName);
        }

        public void SelectSuggestion(string suggestionText)
        {
            if (!IsOptionVisible(suggestionText))
            {
                throw new ArgumentException($"Suggestion '{suggestionText}' is not visible in the autocomplete list.");
            }

            // Replace with actual selector for the autocomplete dropdown container and its options
            var dropdown = _driverManager.Driver().FindElement(By.Id("autoCompleteDropdown"));
            dropdown.FindElements(By.TagName("li"))
                .First(option => option.Text.Equals(suggestionText, StringComparison.InvariantCultureIgnoreCase))
                .Click();
        }
        public List<string> GetSuggestions()
        {
            // Replace with actual selector to target the autocomplete dropdown container
            var dropdown = _driverManager.Driver().FindElement(By.Id("autoCompleteDropdown"));

            // Handle if the dropdown is not currently visible
            if (!dropdown.Displayed)
            {
                return new List<string>(); // Or return an exception if preferred
            }

            return dropdown.FindElements(By.TagName("li"))
                           .Select(option => option.Text)
                           .ToList();
        }

        public string GetSelectedFieldValue()
        {
            var selectedField = _driverManager.Driver().FindElement(By.Id("selectedField"));
            return selectedField.GetAttribute("value");
        }

        public bool IsOptionVisible(string optionText)
        {
            // Replace with actual selector for the autocomplete dropdown container
            var dropdown = _driverManager.Driver().FindElement(By.Id("autoCompleteDropdown"));
            return dropdown.Displayed &&
                   dropdown.FindElements(By.TagName("li"))
                    .Any(option => option.Text.Equals(optionText, StringComparison.InvariantCultureIgnoreCase));
        }

        public void SelectOption(string optionText)
        {
            if (!IsOptionVisible(optionText))
            {
                throw new ArgumentException($"Option '{optionText}' is not visible in the autocomplete list.");
            }

            // Replace with actual selector for the autocomplete dropdown container and its options
            var dropdown = _driverManager.Driver().FindElement(By.Id("autoCompleteDropdown"));
            dropdown.FindElements(By.TagName("li"))
                .First(option => option.Text.Equals(optionText, StringComparison.InvariantCultureIgnoreCase))
                .Click();
        }

        [FindsBy(How = How.Id, Using = "autoCompleteMultipleInput")]
        public IWebElement ColorInput { get; set; }

        public void DeleteColor(string color)
        {
            var deleteButton = ColorInput.FindElement(By.XPath($".//following-sibling::span[text()='{color}']/preceding-sibling::span[@class='ms-2 ui-close-icon']"));
            deleteButton.Click();
        }
    }
}
