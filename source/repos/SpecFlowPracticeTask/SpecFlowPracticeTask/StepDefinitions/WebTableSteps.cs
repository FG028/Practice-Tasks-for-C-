using NUnit.Framework;
using System.Data;
using TechTalk.SpecFlow;
using SpecFlowPracticeTask.POM;
using SpecFlowPracticeTask.Hooks;

namespace SpecFlowPracticeTask.StepDefinitions
{
    [Binding]
    public class WebTableSteps
    {
        private readonly WebTablePage webTablePage;

        public WebTableSteps()
        {
            this.webTablePage = webTablePage;
        }

        [Given(@"I am on the DemoQA page ""https://demoqa.com/webtables""")]
        public void NavigateToDemoQA()
        {
            BrowserManager.GetDriver().Navigate().GoToUrl("https://demoqa.com/webtables");
        }

        [When(@"I click on the ""(.*)"" column header")]
        public void ClickColumnHeader(string columnName)
        {
            webTablePage.GetColumnHeader(columnName).Click();
        }

        [Then(@"I should see the values in the ""(.*)"" column are in ascending order")]
        public void VerifyColumnOrder(string columnName)
        {
            var values = webTablePage.GetColumnValues(columnName);

            // Check data type and order accordingly
            if (int.TryParse(values[0].Text, out int _))
            {
                var orderedNumbers = values.Select(v => int.Parse(v.Text)).OrderBy(n => n).ToList();
                Assert.That(orderedNumbers.SequenceEqual(orderedNumbers), Is.True);
            }
            else
            {
                var orderedText = values.OrderBy(v => v.Text).ToList();
                Assert.That(orderedText.SequenceEqual(orderedText), Is.True);
            }
        }

        [Then(@"I delete the second row name Alden")]
        public void DeleteSecondRow()
        {
            webTablePage.GetDeleteButtonForRow(1).Click();
        }

        [Then(@"I should see there are only two rows left in the table")]
        public void VerifyRowCount()
        {
            Assert.That(webTablePage.GetRowCount, Is.EqualTo(2));
        }

        [Then(@"I should not see the value ""(.*)"" among the values in the ""(.*)"" column")]
        public void VerifyValueAbsence(string unwantedValue, string columnName)
        {
            var values = webTablePage.GetColumnValues(columnName);
            Assert.That(values.Any(v => v.Text == unwantedValue), Is.False);
        }
    }
}
