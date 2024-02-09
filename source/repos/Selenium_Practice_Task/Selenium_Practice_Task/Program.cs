namespace SeleniumWebDriverFrameworkTest
{
    using System;
    using System.Linq;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;

    public class SeleniumWebDriverTest
    {
        IWebDriver driver;

        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://practice.automationtesting.in/shop/");
        }
        public void ShopTest()
        {

            var searchField = driver.FindElement(By.Id("woocommerce-product-search-field"));
            searchField.SendKeys("html");
            searchField.SendKeys(Keys.Enter);
            Assert.That(driver.Title.Contains("HTML"), Is.EqualTo(true));

            var productElements = driver.FindElements(By.CssSelector(".product-category h2 a"));
            foreach (var element in productElements)
            {
                Assert.That(element.Text.Contains("HTML"), Is.EqualTo(true));
                Assert.That(element.GetAttribute("href").StartsWith("https:/"), Is.EqualTo(true));
            }
            var thinkingInHtmlLink = driver.FindElement(By.LinkText("Thinking in HTML"));
            thinkingInHtmlLink.Click();

            var productImage = driver.FindElement(By.CssSelector(".woocommerce-product-gallery__image"));
            Assert.That(productImage.Displayed, Is.EqualTo(true));

            var priceElements = driver.FindElements(By.CssSelector(".price"));
            Assert.AreEqual(2, priceElements.Count());

            var relatedProductsSection = driver.FindElement(By.ClassName("related"));
            var html5WebAppLink = relatedProductsSection.FindElement(By.LinkText("HTML5 Web Development"));

            var addToCartButton = driver.FindElement(By.Name("add-to-cart"));
            addToCartButton.Click();

            var productName = driver.FindElement(By.CssSelector(".cart-item-name")).Text;
            var productPrice = driver.FindElement(By.CssSelector(".cart-item-price")).Text;

            var quantityField = driver.FindElement(By.Id("quantity_6a81321a8979f"));
            quantityField.Clear();
            quantityField.SendKeys("4");

            var cartLink = driver.FindElement(By.LinkText("Cart"));
            cartLink.Click();

            var totalProductName = driver.FindElement(By.CssSelector(".cart-product-name")).Text;
            var totalPrice = driver.FindElement(By.CssSelector(".amount")).Text;
            
            Assert.Multiple(() =>
            {
                Assert.AreEqual(productName, totalProductName);
                Assert.AreEqual(productPrice, totalPrice);
            });
            // main method required
            driver.Quit();
        }
    }
}