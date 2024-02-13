using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PageObjectModel;

public class Program
{
    public static void Main(string[] args)
    {
        IWebDriver driver = new ChromeDriver();

        driver.Navigate().GoToUrl("https://practice.automationtesting.in/my-account/. ");

        LoginPage loginPage = new LoginPage(driver);

        string lostPasswordText = loginPage.GetLostPasswordText();
        Console.WriteLine(lostPasswordText);

        string rememberMeText = loginPage.GetRememberMeText();
        Console.WriteLine(rememberMeText);

        string registerButtoníText = loginPage.GetRegisterButtonText();
        Console.WriteLine(registerButtoníText);

        loginPage.Login("testuser", "password123");

        driver.Quit();

    }
}