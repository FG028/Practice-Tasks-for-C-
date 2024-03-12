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

        public void ExpandHomeFolder()
        {
            var expandHomeButton = driverManager.Driver().FindElement(By.CssSelector("#tree-node > div > button.rct-option.rct-option-expand-all"));
            expandHomeButton.Click();
        }

        public void DesktopSelector()
        {
            var desktopSelector = driverManager.Driver().FindElement(By.XPath("/html/body/div[2]/div/div/div/div[2]/div[2]/div/ol/li/ol/li[1]/span/button"));
            desktopSelector.Click();
        }
        public void SelectDesktopCheckBox()
        {
            var desktopCheckBox = driverManager.Driver().FindElement(By.XPath("/html/body/div[2]/div/div/div/div[2]/div[2]/div/ol/li/ol/li[1]/span/label/span[1]"));
            desktopCheckBox.Click();
        }
        public void SelectItem1()
        {
            var checkBox = driverManager.Driver().FindElement(By.XPath("/html/body/div[2]/div/div/div/div[2]/div[2]/div[1]/ol/li/ol/li[2]/ol/li[1]/ol/li[2]/span/label/span[1]"));
            checkBox.Click();
        }
        public void SelectItem2()
        {
            var checkBox = driverManager.Driver().FindElement(By.XPath("/html/body/div[2]/div/div/div/div[2]/div[2]/div/ol/li/ol/li[2]/ol/li[1]/ol/li[3]/span/label/span[1]"));
            checkBox.Click();
        }

        public void GetOfficeItems()
        {
            var getAllTheOfficeItem = driverManager.Driver().FindElement(By.XPath("/html/body/div[2]/div/div/div/div[2]/div[2]/div/ol/li/ol/li[2]/ol/li[2]/span/label/span[3]"));
            getAllTheOfficeItem.Click();
        }

        public void SelectDownloadsFolder()
        {
            var desktopCheckbox = driverManager.Driver().FindElement(By.XPath("/html/body/div[2]/div/div/div/div[2]/div[2]/div[1]/ol/li/ol/li[3]/span/label/span[1]"));
            ((IJavaScriptExecutor)driverManager.Driver()).ExecuteScript("arguments[0].scrollIntoView(true);", desktopCheckbox);
            desktopCheckbox.Click();
        }

        public string GetSelectedItemsText()
        {
            var selectedItems = driverManager.Driver().FindElements(By.Id("result"));
            var selectedItemsText = selectedItems.Select(
            item => string.Join(" ", item.Text.Trim().Split("\r\n", StringSplitOptions.RemoveEmptyEntries)));

            return string.Join(" ", selectedItemsText);
        }
    }
}