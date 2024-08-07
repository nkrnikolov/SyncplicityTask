using OpenQA.Selenium;

namespace Syncplicity.Pages
{
    public class UserAccountsPage : BasePage
    {
        private static readonly By AddUserButton = By.LinkText("Add a User");
        private static readonly By TotalUsersNumber = By.Id("simpleTotalItems");
        private static readonly By EmailAddressesField = By.Id("txtUserEmails");
        private static readonly By RoleDropdown = By.Id("roleselect");
        private static readonly By UserEmailsNextButton = By.Id("nextButtonUserEmails");
        private static readonly By GroupMembershipNextButton = By.Id("nextButtonGroupMembership");
        private static readonly By FoldersNextButton = By.Id("nextButtonUserFolders");
        private static readonly By UserSearchBox = By.CssSelector(".jqfilter-input-email");
        // TODO: Improve locator generalization
        private static readonly By FirstSearchResult = By.CssSelector("table#results  .item > .name > a:nth-of-type(1)");
        private static readonly By UserManagementRole = By.CssSelector("li:nth-of-type(1) .user-property");
        private static readonly By GlobalAdministratorRole = By.CssSelector(".dropdown-menu.roles-selector > li:nth-of-type(4)");
        private static readonly By DesktopCheckbox = By.CssSelector("p:nth-of-type(1) > label");

        public UserAccountsPage() : base() { }

        public void CreateNewUser(string randomEmail)
        {
            ClickAddUserButton();
            EnterEmailAddresses(randomEmail);
            ClickRoleDropdown();
            ClickGlobalAdministratorRole();
            ClickUserEmailsNextButton();
            ClickGroupMembershipNextButton();
            ClickDesktopCheckBox();
            ClickFoldersNextButton();
        }

        public void EnterEmailAddresses(string emails)
        {
            EnterText(EmailAddressesField, emails);
        }

        public void ClickAddUserButton()
        {
            Click(AddUserButton);
        }

        public void ClickRoleDropdown()
        {
            Click(RoleDropdown);
        }

        public void ClickGlobalAdministratorRole()
        {
            WaitForElementToBeClickable(GlobalAdministratorRole);
            Click(GlobalAdministratorRole);
        }

        public void ClickUserEmailsNextButton()
        {
            Click(UserEmailsNextButton);
        }

        public void ClickGroupMembershipNextButton()
        {
            Click(GroupMembershipNextButton);
        }

        public void ClickDesktopCheckBox()
        {
            Click(DesktopCheckbox);
        }

        public void ClickFoldersNextButton()
        {
            WaitForElementToBeClickable(FoldersNextButton);
            Click(FoldersNextButton);
        }

        public void ClickFirstSearchResult()
        {
            WaitForElementToBeClickable(FirstSearchResult);
            Click(FirstSearchResult);
        }

        public int GetTotalNumberOfUsers()
        {
            return int.Parse(GetElement(TotalUsersNumber).Text.Split(" ")[0]);
        }

        public void EnterSearchText(string searchText)
        {
            EnterText(UserSearchBox, searchText);
            GetElement(UserSearchBox).SendKeys(Keys.Enter);
        }

        public string GetUserManagementRole()
        {
            return GetElement(UserManagementRole).Text;
        }
    }
}