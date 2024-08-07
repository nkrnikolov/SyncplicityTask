using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Syncplicity.Pages;

namespace MySeleniumTests.Tests
{
    public class BaseTest
    {
        protected static IWebDriver Driver;
        protected static readonly string userName = "syncplicity-technical-interview@dispostable.com";
        protected static readonly string password = "s7ncplicit@Y";

        [SetUp]
        public void SetUp()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("start-maximized"); // Open Browser in maximized mode
            chromeOptions.AddArguments("--disable-search-engine-choice-screen"); // Remove search engine choice screen
            chromeOptions.AddArguments("--incognito"); // Open Chrome in incognito mode

            Driver = new ChromeDriver(chromeOptions);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            BasePage.InitializeDriver(Driver);
        }

        [TearDown]
        public void TearDown()
        {
            if (Driver != null)
            {
                Driver.Quit();
                Driver.Dispose();
            }
        }
    }
}