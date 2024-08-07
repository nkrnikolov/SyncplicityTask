using NUnit.Framework;
using MySeleniumTests.Tests;
using Syncplicity.Pages;
using System.Text;
using System.ComponentModel;

namespace Syncplicity.Tests
{
    public class UserAccountsTests : BaseTest
    {
        private LoginPage loginPage;
        private HomePage homePage;
        private UserAccountsPage userAccountsPage;
        private int numberOfUsers;
        private static Random random = new Random();
        private string randomEmail = GenerateRandomEmail();

        public static string GenerateRandomEmail()
        {
            string username = GenerateRandomString(10);
            string domain = GenerateRandomString(7);
            string domainSuffix = GenerateRandomString(3);

            return $"{username}@{domain}.{domainSuffix}";
        }

        private static string GenerateRandomString(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz";
            StringBuilder stringBuilder = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                stringBuilder.Append(chars[random.Next(chars.Length)]);
            }

            return stringBuilder.ToString();
        }

        [SetUp]
        public void Initialize()
        {
            loginPage = new LoginPage();
            homePage = new HomePage();
            userAccountsPage = new UserAccountsPage();
            Driver.Navigate().GoToUrl("https://eu.syncplicity.com/");
            loginPage.Login(userName, password);
            homePage.IsLoaded();
            homePage.ClickUserAccountsTab();
        }

        [Test]
        public void VerifyUserIsCreated()
        {
            numberOfUsers = userAccountsPage.GetTotalNumberOfUsers();
            userAccountsPage.CreateNewUser(randomEmail);
            homePage.ClickUserAccountsTab();
            // Wait until total number of users is refreshed
            // TODO: Check for better approach using counter or time based wait
            while (userAccountsPage.GetTotalNumberOfUsers() == numberOfUsers) userAccountsPage.RefreshPage();
            Assert.That(numberOfUsers + 1, Is.EqualTo(userAccountsPage.GetTotalNumberOfUsers()));
            userAccountsPage.EnterSearchText(randomEmail);
            userAccountsPage.ClickFirstSearchResult();
            // TODO: Improve hardcoded value
            Assert.That(userAccountsPage.GetUserManagementRole(), Is.EqualTo("Global Administrator"));
        }
    }
}