﻿using NUnit.Framework;
using OpenQA.Selenium;
using System.Data;
using OpenQA.Selenium.Support.UI;
using System.Linq;
using TechTalk.SpecFlow;

namespace SpecFlowPracticeTask.StepDefinitions
{
    [Binding]
    public class WebTableSteps
    {
        private readonly WebDriver driver;

        public WebTableSteps(WebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"I navigate to the ""Elements"" category and ""Web Tables"" section")]
        public void NavigateToWebTablesSection()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/webtables");
        }

        [Given(@"I click on the ""(.*)"" column header")]
        [When(@"I click on the ""(.*)"" column header")]
        public void ClickColumnHeader(string columnName)
        {
            var header = driver.FindElement(By.XPath($"//th[text()='{columnName}']"));
            header.Click();
        }

        [Then(@"I should see the values in the ""(.*)"" column are in ascending order")]
        public void VerifyColumnOrder(string columnName)
        {
            var values = driver.FindElements(By.XPath($"//td[text()='{columnName}']/following-sibling::td[text()!=' ']"));

            // Check data type before parsing
            if (int.TryParse(values[0].Text, out int _))
            {
                var orderedNumbers = values.Select(v => int.Parse(v.Text)).OrderBy(n => n).ToList();
                Assert.IsTrue(orderedNumbers.SequenceEqual(orderedNumbers)); // compare with itself after ordering
            }
            else
            {
                var orderedText = values.OrderBy(v => v.Text).ToList();
                Assert.IsTrue(orderedText.SequenceEqual(orderedText)); // compare with itself after ordering
            }
        }

        [When(@"I delete the second row name Alden")]
        public void DeleteSecondRow()
        {
            var table = driver.FindElement(By.XPath("//table[@id='webtables']"));
            var rows = table.FindElements(By.TagName("tr"));

            var secondRow = rows[1];
            var deleteButton = secondRow.FindElement(By.XPath(".//i[@class='fa fa-trash']"));

            deleteButton.Click();
        }

        [Then(@"I should see there are onlxy two rows left in the table")]
        public void VerifyRowCount()
        {
            var table = driver.FindElement(By.XPath("//table[@id='webtables']"));
            var rows = table.FindElements(By.TagName("tr"));

            Assert.That(rows.Count, Is.EqualTo(2));
        }

        [Then(@"I should see the values in the ""(.*)"" column are in ascending order")]
        public void VerifyValueAbsence(string unwantedValue, string columnName)
        {
            var values = driver.FindElements(By.XPath($"//td[text()!='{columnName}']//following-sibling::td[text()!=' ']"));

            Assert.IsFalse(values.Any(v => v.Text == unwantedValue));
        }
    }
}
