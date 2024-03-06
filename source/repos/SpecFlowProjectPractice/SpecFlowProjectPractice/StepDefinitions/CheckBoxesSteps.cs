using NUnit.Framework;
using TechTalk.SpecFlow;
using SpecFlowProjectPractice.PageObjects;
using SpecFlowProjectPractice.Drivers;

namespace SpecFlowProjectPractice.StepDefinitions
{
    [Binding]
    public class CheckBoxesSteps
    {
        private WebDriverManager _driverManager;
        private readonly CheckBoxPage checkBoxPage;

        public CheckBoxesSteps(WebDriverManager driverManager)
        {
            _driverManager = driverManager;
            checkBoxPage = new CheckBoxPage(_driverManager);
        }

        [When(@"I expand the ""(.*)"" folder")]
        public void WhenIExtendTheHomeFolder(string folderName)
        {
            checkBoxPage.PopUpButtonConfirmation();
            checkBoxPage.ExpandFolder(folderName);
        }

        [Then(@"I select the ""(.*)"" folder without expanding")]
        public void WhenISelectTheDesktopFolderWithoutExpanding(string folderName)
        {
            checkBoxPage.SelectFolder(folderName);
        }

        [Then(@"I select ""(.*)"" and ""(.*)"" from the ""(.*)"" folder")]
        public void WhenISelectAngularAndVeuFromTheWorkspaceFolder(string itemName1, string itemName2, string folderName)
        {
            checkBoxPage.ExpandFolder(folderName);
            checkBoxPage.SelectItem(itemName1);
            checkBoxPage.SelectItem(itemName2);
        }

        [Then(@"I expand and click each item in the ""(.*)"" folder")]
        public void WhenIExtendAndClickEachItemInTheOfficeFolder(string folderName)
        {
            checkBoxPage.ExpandFolder(folderName);
            var officeItems = checkBoxPage.GetOfficeItems();
            foreach (var item in officeItems)
            {
                checkBoxPage.SelectItem(item);
            }
        }

        [Then(@"I select the ""(.*)"" folder")]
        public void WhenIExtendAndSelectTheDownloadsFolder(string folderName)
        {
            checkBoxPage.SelectFolder(folderName);
        }

        [Then(@"I verify the selected items are ""(.*?)""")]
        public void ThenIVerifyTheSelectedItemsAre(string expectedSelection)
        {
            var actualSelection = checkBoxPage.GetSelectedItemsText();
            Assert.AreEqual(expectedSelection, actualSelection);
        }
    }
}
