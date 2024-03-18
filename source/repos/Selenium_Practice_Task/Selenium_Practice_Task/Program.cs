namespace SeleniumWebDriverFrameworkTest
{
    using System;
    using System.Linq;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;

    public class SeleniumWebDriverTest
    {
        private IWebDriver driver;

        public void SetUp()
        {
            driver = new ChromeDriver();

            string websiteURL = "https://practice.automationtesting.in/shop/";
            driver.Navigate().GoToUrl(websiteURL);
        }
        
        public async Task ShopTest()
        {

            try {
            
            var searchField = driver.FindElement(By.Id("s"));
            searchField.Click();
            searchField.SendKeys("html");
            searchField.SendKeys(Keys.Enter);
            Task.Delay(10).Wait();
            Assert.That(driver.Title.Contains("HTML"), Is.EqualTo(true));
            Console.WriteLine("The first part is okay!");


            var productElements = driver.FindElements(By.CssSelector(".product-category h2 a"));
            foreach (var element in productElements)
            {
                Assert.That(element.Text.Contains("HTML"), Is.EqualTo(true));
                Assert.That(element.GetAttribute("href").StartsWith("https:/"), Is.EqualTo(true));
            }
            Console.WriteLine("The second part is okay!");


            var thinkingInHtmlLink = driver.FindElement(By.LinkText("Thinking in HTML"));
            thinkingInHtmlLink.Click();
            Assert.That(thinkingInHtmlLink.Text.Contains("Thinking in HTML"), Is.EqualTo(true));
            Console.WriteLine("The third part is okay!");


            var productImage = driver.FindElement(By.CssSelector(".woocommerce-product-gallery__image"));
            Assert.That(productImage.Displayed, Is.EqualTo(true));
            Console.WriteLine("The fourth part is okay!");


            var priceElements = driver.FindElements(By.CssSelector(".price"));
            Assert.AreEqual(2, priceElements.Count());
            Console.WriteLine("The fifth part is okay!");


            var relatedProductsSection = driver.FindElement(By.ClassName("related"));
            var html5WebAppLink = relatedProductsSection.FindElement(By.LinkText("HTML5 Web Development"));
            Assert.That(html5WebAppLink.Text.Contains("HTML5 Web Development"), Is.EqualTo(true));
            Console.WriteLine("The sixth part is okay!");


            var addToCartButton = driver.FindElement(By.Name("add-to-cart"));
            addToCartButton.Click();
            Assert.That(addToCartButton.Displayed);
            Assert.IsTrue(addToCartButton.Enabled, "Add cart button is not enabled");
            Console.WriteLine("The seventh part is okay!");

            var productName = driver.FindElement(By.CssSelector(".cart-item-name")).Text;
            var productPrice = driver.FindElement(By.CssSelector(".cart-item-price")).Text;
            Console.WriteLine("The eight part is okay!");


            var quantityField = driver.FindElement(By.Id("quantity_6a81321a8979f"));
            quantityField.Clear();
            quantityField.SendKeys("4");
            Assert.That(quantityField.GetAttribute("value"), Is.EqualTo("true"));
            Console.WriteLine("The ninth part is okay!");


            var cartLink = driver.FindElement(By.LinkText("Cart"));
            cartLink.Click();
            Assert.That(html5WebAppLink.Text.Contains("Cart"), Is.EqualTo(true));
            Console.WriteLine("The tenth part is okay!");


            var totalProductName = driver.FindElement(By.CssSelector(".cart-product-name")).Text;
            var totalPrice = driver.FindElement(By.CssSelector(".amount")).Text;

            Assert.Multiple(() =>
            {
                Assert.AreEqual(productName, totalProductName);
                Assert.AreEqual(productPrice, totalPrice);
            });
            Console.WriteLine("The last part is okay!");

            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("Error: Null reference encountered.");
                Console.WriteLine($"Exception details: {ex.Message}");
            }
            finally 
            { 
                driver.Quit(); 
            }
        }
        public static void Main(string[] args)
        {
            var test = new SeleniumWebDriverTest();
            test.SetUp();
            _ = test.ShopTest();

            Console.WriteLine("Test execution complete!!!");
        }
    }
}