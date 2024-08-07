using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Syncplicity.Pages
{
    public abstract class BasePage
    {
        protected static IWebDriver Driver;
        protected WebDriverWait Wait;

        public BasePage()
        {
            if (Driver == null)
            {
                throw new InvalidOperationException("Driver is not initialized. Please initialize the driver before using it.");
            }
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
        }

        public static void InitializeDriver(IWebDriver webDriver)
        {
            Driver = webDriver ?? throw new ArgumentNullException(nameof(webDriver), "WebDriver cannot be null");
        }

        protected IWebElement WaitForElementToBeVisible(By locator)
        {
            return Wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        protected IWebElement WaitForElementToBeClickable(By locator)
        {
            return Wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        protected void WaitForPageTitle(string title)
        {
            Wait.Until(ExpectedConditions.TitleContains(title));
        }

        public void Click(By by)
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            WaitForElementToBeClickable(by);
            GetElement(by).Click();
        }

        public void EnterText(By by, string text)
        {
            GetElement(by).SendKeys(text);
        }

        public static IWebElement GetElement(By by)
        {
            return Driver.FindElement(by);
        }

        public static bool IsElementDisplayed(By by)
        {
            try
            {
                return GetElement(by).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void RefreshPage()
        {
            Driver.Navigate().Refresh();
        }
    }
}
