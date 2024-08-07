using MySeleniumTests.Tests;
using Syncplicity.Pages;

namespace Syncplicity.Tests
{
    public class LoginPageTests : BaseTest
    {
        private LoginPage loginPage; 
        private HomePage homePage;

        [SetUp]
        public void Initialize()
        {
            loginPage = new LoginPage();
            homePage = new HomePage();
            Driver.Navigate().GoToUrl("https://eu.syncplicity.com/");
        }

        [Test]
        public void SuccessfulLoginTest()
        {
            loginPage.Login(userName, password);

            Assert.That(homePage.IsLoaded(), "Password field is incorrectly shown before valid email is entered");
        }

        [Test]
        [TestCase("invalidEmail")]
        [TestCase(" ")]
        public void VerifyEmailErrorMessageIsDisplayed(string email)
        {
            loginPage.EnterEmail(email);
            loginPage.ClickNextButton();
            Assert.That(loginPage.IsEmailErrorMessageDisplayed(), "Invalid email error message is not displayed");
        }

        [Test]
        [TestCase("validEmail@email.com", "")]
        public void VerifyPasswordErrorMessageIsDisplayed(string email, string password)
        {
            loginPage.Login(email, password);
            Assert.That(loginPage.IsPasswordErrorMessageDisplayed(), "Invalid password error message is not displayed");
        }

        [Test]
        [TestCase("validEmail@email.com", "validPassword")]
        public void VerifyWrongEmailOrPasswordErrorMessageIsDisplayed(string email, string password)
        {
            loginPage.Login(email, password);
            Assert.That(loginPage.IsEmailOrPasswordErrorMessageDisplayed(), "Invalid email or password error message is not displayed");
        }

        [Test]
        [TestCase("invalidEmail")]
        public void VerifyPasswordFieldIsNotDisplayedBeforeValidEmail(string email)
        {
            loginPage.EnterEmail(email);
            loginPage.ClickNextButton();
            Assert.That(!loginPage.IsPasswordFieldDisplayed(), "Password field is incorrectly shown before valid email is entered");
        }
    }
}