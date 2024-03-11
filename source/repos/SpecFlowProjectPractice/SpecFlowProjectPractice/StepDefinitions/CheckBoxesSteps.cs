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
            checkBoxPage.ExpandHomeFolder();
        }

        [Then(@"I select the Desktop folder without expanding")]
        public void WhenISelectTheDesktopFolderWithoutExpanding()
        {
            checkBoxPage.DesktopSelector();
            checkBoxPage.SelectDesktopCheckBox();
        }

        [Then(@"I select Angular and Veu from the Workspace folder")]
        public void WhenISelectAngularAndVeuFromTheWorkspaceFolder()
        {
            checkBoxPage.SelectItem1();
            checkBoxPage.SelectItem2();
        }

        [Then(@"I expand and click each item in the Office folder")]
        public void WhenIExtendAndClickEachItemInTheOfficeFolder()
        {
            checkBoxPage.GetOfficeItems();
        }

        [Then(@"I select the Downloads folder")]
        public void WhenIExtendAndSelectTheDownloadsFolder()
        {
            checkBoxPage.SelectDownloadsFolder();
        }

        [Then(@"I verify the selected items are ""(.*?)""")]
        public void ThenIVerifyTheSelectedItemsAre(string expectedSelection)
        {
            var actualSelection = checkBoxPage.GetSelectedItemsText();
            Assert.AreEqual(expectedSelection, actualSelection);
        }
    }
}
