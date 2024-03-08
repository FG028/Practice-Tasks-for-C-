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

        private const string ExpandFolderXPath = "//*/span[@class = 'rct-title' and text()='{0}']";
        private const string SelectFolderXPath = "//*/span[@class = 'rct-title' and text()='{0}']";
        private const string SelectItemXPath = "//span[text()='{0}']/preceding-sibling::input";
        private const string SelectedItemsXPath = "//span[contains(@class, 'text-success')]";
        private const string OfficeItemsXPath = "//span[text()='{0}']/following-sibling::ul//span[@class='ng-star-inserted']";

        public void PopUpButtonConfirmation()
        {
            var popup = driverManager.Driver().FindElement(By.CssSelector("body > div.fc-consent-root > div.fc-dialog-container > div.fc-dialog.fc-choice-dialog > div.fc-footer-buttons-container > div.fc-footer-buttons > button.fc-button.fc-cta-consent.fc-primary-button > p"));
            popup.FindElement(By.XPath("/html/body/div[3]/div[2]/div[1]/div[2]/div[2]/button[1]/p")).Click();
        }

        public void ExpandFolder(string folderName)
        {
            var formattedXPath = string.Format(ExpandFolderXPath, folderName);
            var expandButton = driverManager.Driver().FindElement(By.XPath(formattedXPath));
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
