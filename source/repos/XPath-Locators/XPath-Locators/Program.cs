using OpenQA.Selenium;
using FluentAssertions;
using XPath_Locators;

namespace XPathLocators;
public class MainTest
{
    public void RunTest()
    {
        string websiteUrl = "https://practice.automationtesting.in/shop/";
        WebsiteInteractor interactor = new WebsiteInteractor();

        interactor.NavigateTo(websiteUrl);

        Console.WriteLine("The first element work");
        IWebElement firstElement = interactor.FindElementByXPath(ElementOfXPathSelectors.FirstElementXPath);
        firstElement.Text.Should().BeEmpty();

        IWebElement secondElement = interactor.FindElementByCSSSelector("#mc4wp-form-1 > div.mc4wp-form-fields > p:nth-child(1) > input[type=email]");

        Console.WriteLine("The second element work");
        IWebElement thirdElement = interactor.FindElementByXPath(ElementOfXPathSelectors.SecondElementXPath);
        thirdElement.Text.Contains("Filter");

        IWebElement fourthElement = interactor.FindElementByCSSSelector("#woocommerce_price_filter-2 > form > div > div.price_slider_amount > button");

        Console.WriteLine("The third element work");
        IWebElement fifthElement = interactor.FindElementByXPath(ElementOfXPathSelectors.ThirdElementXPath);
        fifthElement.Text.Contains("JavaScript");

        IWebElement sixthElement = interactor.FindElementByCSSSelector("#woocommerce_product_categories-2 > ul > li.cat-item.cat-item-21 > a");

        Console.WriteLine("The fourth element work");
        IWebElement seventhElement = interactor.FindElementByXPath(ElementOfXPathSelectors.FourthElementXPath);
        seventhElement.Text.Should().BeEmpty();

        IWebElement eighthElement = interactor.FindElementByCSSSelector("#searchform > i");

        Console.WriteLine("The fifth element work");
        IWebElement ninthElement = interactor.FindElementByXPath(ElementOfXPathSelectors.FifthElementXPath);
        ninthElement.Text.Contains("Test Case");

        IWebElement tenthlement = interactor.FindElementByCSSSelector("#menu-item-224 > a");

        Console.WriteLine("The sixth element work");
        IWebElement eleventhElement = interactor.FindElementByXPath(ElementOfXPathSelectors.SixthElementXPath);
        eleventhElement.Text.Should().BeEmpty();

        IWebElement twelfthElement = interactor.FindElementByCSSSelector("#header > a");

        Console.WriteLine("The seventh element work");
        IWebElement thirteenthElement = interactor.FindElementByXPath(ElementOfXPathSelectors.SeventhElementXPath);
        thirteenthElement.Text.Contains("Newest");

        IWebElement fourteenthElement = interactor.FindElementByCSSSelector("#content > form > select > option:nth-child(4)");

        Console.WriteLine("The eight element work");
        IWebElement fifteenthElement = interactor.FindElementByXPath(ElementOfXPathSelectors.EighthElementXPath);
        thirteenthElement.Text.Contains("Android");

        IWebElement sixteenthElement = interactor.FindElementByCSSSelector("#content > ul > li.post-169.product.type-product.status-publish.product_cat-android.product_tag-android.has-post-title.no-post-date.has-post-category.has-post-tag.has-post-comment.has-post-author.first.instock.sale.downloadable.taxable.shipping-taxable.purchasable.product-type-simple > a.woocommerce-LoopProduct-link");

        Console.WriteLine("The ninth element work");
        IWebElement seventeenthElement = interactor.FindElementByXPath(ElementOfXPathSelectors.NinthElementXPath);
        seventeenthElement.Text.Should().BeEmpty();

        IWebElement eighteenthElement = interactor.FindElementByCSSSelector("#content > ul > li.post-180.product.type-product.status-publish.product_cat-javascript.product_tag-javascript.has-post-title.no-post-date.has-post-category.has-post-tag.has-post-comment.has-post-author.first.instock.downloadable.taxable.shipping-taxable.purchasable.product-type-simple > a.woocommerce-LoopProduct-link > span > span");

        Console.WriteLine("The tenth element work");
        IWebElement nineteenth = interactor.FindElementByXPath(ElementOfXPathSelectors.TenthElementXPath);
        nineteenth.Text.Should().BeEmpty();

        IWebElement twentiethElement = interactor.FindElementByCSSSelector("#footer > div.footer-text.clearfix > div > div.one > a");

        Console.WriteLine("All verification assertions passed!");

        interactor.driver.Quit();
    }
    public static void Main(string[] args)
    {
        var test = new MainTest();
        test.RunTest();

        Console.WriteLine("Test execution complete");
    }
}