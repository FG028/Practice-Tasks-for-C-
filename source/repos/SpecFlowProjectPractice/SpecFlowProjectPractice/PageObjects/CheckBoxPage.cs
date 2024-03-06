using OpenQA.Selenium;
using SpecFlowProjectPractice.Drivers;

namespace SpecFlowProjectPractice.PageObjects
{
    public class CheckBoxPage
    {
        private WebDriverManager driverManager;

        public CheckBoxPage(WebDriverManager _driverManager)
        {
            driverManager = _driverManager;
        }

        private const string ExpandFolderXPath = "//span[@class='ui-tree-toggler ui-icon ui-icon-plus' and contains(text(), '{folderName}')]/ancestor::*[contains(@class, 'ui-tree-node')]//*[contains(@class, 'ui-tree-label')]";
        private const string SelectFolderXPath = "//span[text()='{folderName}']/preceding-sibling::input";
        private const string SelectItemXPath = "//span[text()='{itemName}']/preceding-sibling::input";
        private const string SelectedItemsXPath = "//span[contains(@class, 'text-success')]";
        private const string OfficeItemsXPath = "//span[text()='{folderName}']/following-sibling::ul//span[@class='ng-star-inserted']";

        public void PopUpButtonConfirmation()
        {
            var popup = driverManager.Driver().FindElement(By.CssSelector("body > div.fc-consent-root > div.fc-dialog-container > div.fc-dialog.fc-choice-dialog > div.fc-dialog-content"));
            popup.FindElement(By.XPath("/html/body/div[3]/div[2]/div[1]/div[2]/div[2]/button[1]/p")).Click();
        }
        public void ExpandFolder(string folderName)
        {
            var expandButton = driverManager.Driver().FindElement(By.XPath(string.Format(ExpandFolderXPath, folderName)));
            expandButton.Click();
        }

        public void SelectItem(string itemName)
        {
            var checkBox = driverManager.Driver().FindElement(By.XPath(string.Format(SelectItemXPath, itemName)));
            checkBox.Click();
        }

        public List<string> GetOfficeItems()
        {
            var officeItems = driverManager.Driver().FindElements(By.XPath(string.Format(OfficeItemsXPath, "Office")));
            return officeItems.Select(item => item.Text).ToList();
        }
            public void SelectFolder(string folderName)
        {
            var checkBox = driverManager.Driver().FindElement(By.XPath(string.Format(SelectFolderXPath, folderName)));
            checkBox.Click();
        }

        public string GetSelectedItemsText()
        {
            var selectedItems = driverManager.Driver().FindElements(By.XPath(SelectedItemsXPath));
            return string.Join(" ", selectedItems.Select(item => item.Text));
        }
    }
}
