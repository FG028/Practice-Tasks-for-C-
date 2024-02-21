﻿using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Interactions;
using System;

namespace SpecFlowPracticeTask.StepDefinitions
{
    [Binding]
    public class SelectableSteps
    {
        private readonly WebDriver driver;

        public SelectableSteps(WebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"I am on the DemoQA Test Automation page ""https://demoqa.com/selectable""")]
        public void NavigateToDemoQA()
        {
            string url = "https://demoqa.com/selectable";
            driver.Navigate().GoToUrl(url);
        }

        [Given(@"I navigate to the ""Interactions"" category and ""Selectable"" section")]
        public void NavigateToAutoCompleteSection()
        {
            driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div[1]/div/div/div[5]/div/ul/li[2]")).Click();
        }

        [Given(@"I switch to the ""Grid"" tab")]
        public void SwitchToGridTab()
        {
            var gridTab = driver.FindElement(By.Id("gridTab"));
            gridTab.Click();
        }

        [When(@"I select squares (.*), (.*), (.*), (.*), and (.*)")]
        public void SelectSquares(int square1, int square2, int square3, int square4, int square5)
        {
            var squares = driver.FindElements(By.CssSelector(".ui-selectable-item"));

            SelectSquare(squares[square1 -1]);
            SelectSquare(squares[square2 - 1]);
            SelectSquare(squares[square3 - 1]);
            SelectSquare(squares[square4 - 1]);
            SelectSquare(squares[square5 - 1]);
        }

        private void SelectSquare(IWebElement square)
        {
            if(!IsSelected(square))
            {
                Actions actions = new Actions(driver);
                actions.ClickAndHold(square).Build().Perform();
            }
        }

        private bool IsSelected(IWebElement square)
        {
            return square.GetAttribute("class").Contains(".ui-selected");
        }

        [Then(@"I should see the selected squares have values ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)""")]
        public void VerifySelectedValues(string value1, string value2, string value3, string value4, string value5)
        {
            var squares = driver.FindElements(By.CssSelector(".ui-selected"));

            Assert.Multiple(() =>
            {
                Assert.That(squares[0].Text, Is.EqualTo(value1));
                Assert.That(squares[1].Text, Is.EqualTo(value2));
                Assert.That(squares[2].Text, Is.EqualTo(value3));
                Assert.That(squares[3].Text, Is.EqualTo(value4));
                Assert.That(squares[4].Text, Is.EqualTo(value5));

            });
        }
    }
}
