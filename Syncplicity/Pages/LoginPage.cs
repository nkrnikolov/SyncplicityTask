using OpenQA.Selenium;

namespace Syncplicity.Pages
{
    public class LoginPage : BasePage
    {
        private static readonly By EmailField = By.Id("MainContent_login_UserName");
        private static readonly By PasswordField = By.Id("MainContent_login_txtPassword");
        private static readonly By NextButton = By.Id("MainContent_login_btnNext");
        private static readonly By LoginButton = By.Id("MainContent_login_btnLogin");
        private static readonly By InvalidEmailErrorMessage = By.Id("MainContent_login_UserName-error");
        private static readonly By InvalidPasswordErrorMessage = By.Id("MainContent_login_txtPassword-error");
        private static readonly By InvalidEmailOrPasswordWarningMessage = By.CssSelector("div#SystemMessageContent_statusMessage li");

        public LoginPage() : base(){}

        public void Login(string email, string password)
        {
            EnterEmail(email);
            ClickNextButton();
            EnterPassword(password);
            ClickLoginButton();
        }

        public void EnterEmail(string email)
        {
            EnterText(EmailField, email);
        }

        public void EnterPassword(string password)
        {
            EnterText(PasswordField, password);
        }

        public void ClickNextButton()
        {
            Click(NextButton);
        }

        public void ClickLoginButton()
        {
            Click(LoginButton);
        }

        public bool IsPasswordFieldDisplayed()
        {
            return IsElementDisplayed(PasswordField);
        }

        public bool IsEmailErrorMessageDisplayed()
        {
            return IsElementDisplayed(InvalidEmailErrorMessage);
        }

        public bool IsPasswordErrorMessageDisplayed()
        {
            return IsElementDisplayed(InvalidPasswordErrorMessage);
        }

        public bool IsEmailOrPasswordErrorMessageDisplayed()
        {
            return IsElementDisplayed(InvalidEmailOrPasswordWarningMessage);
        }
    }
}