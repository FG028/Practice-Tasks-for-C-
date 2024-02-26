using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SpecFlowPracticeTask.POM
{
    public class CheckBoxPage
    {
        private readonly IWebDriver driver;

        public CheckBoxPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void NavigateToPage() 
        {
            driver.Navigate().GoToUrl("https://demoqa.com/checkbox");
        }

        public void NavigateToAutoCompleteSection() 
        {
            driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div[1]/div/div/div[1]/div/ul/li[2]")).Click();
        }


        [FindsBy(How = How.Name, Using = "Home")]
        public IWebElement HomeFolder { get; set; }

        [FindsBy(How = How.Name, Using = "Office")]
        public IWebElement OfficeFolder { get; set;}

        [FindsBy(How = How.Name, Using = "Downloads")]
        public IWebElement DownloadsFolder { get; set; }

        public IWebElement GetCheckBoxElement(string folderName, string itemName)
        {
            var folderElement = driver.FindElement(By.Name(folderName));
            return folderElement.FindElements(By.Name(itemName)).FirstOrDefault();
        }

        public void ExpandFolder(IWebElement folderElement)
        {
            folderElement.Click();
        }

        public IList<IWebElement> GetItemsInFolder(IWebElement folderElement) 
        {
            return folderElement.FindElements(By.TagName("label"));
        }

        public IWebElement GetDownloadFolderCheckBox()
        {
            var folderElement = driver.FindElement(By.Name("Downloads"));
            return folderElement.FindElement(By.XPath("//input[@type='checkbox']"));
        }

        public string GetResultText()
        {
            return driver.FindElement(By.Id("result")).Text;
        }
    }
}
