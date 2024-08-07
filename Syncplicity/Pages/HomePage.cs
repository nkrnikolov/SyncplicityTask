using OpenQA.Selenium;

namespace Syncplicity.Pages
{

    public class HomePage : BasePage
    {
        private static readonly By UserAccountsTab = By.CssSelector(".sub-menu > li:nth-of-type(3)");
        public HomePage() : base() { }

        public bool IsLoaded()
        {
            return IsElementDisplayed(UserAccountsTab);
        }

        public void ClickUserAccountsTab()
        {
            Click(UserAccountsTab);
        }
    }
}
