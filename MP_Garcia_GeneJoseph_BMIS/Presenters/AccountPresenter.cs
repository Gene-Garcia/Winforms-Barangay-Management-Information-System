using MP_Garcia_GeneJoseph_BMIS.Helpers;
using MP_Garcia_GeneJoseph_BMIS.Models;
using MP_Garcia_GeneJoseph_BMIS.Models.Repository;
using MP_Garcia_GeneJoseph_BMIS.Views;
using MP_Garcia_GeneJoseph_BMIS.Views.AccountView;
using MP_Garcia_GeneJoseph_BMIS.Views.DashboardView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MP_Garcia_GeneJoseph_BMIS.Presenters
{
    class AccountPresenter
    {
        private Entities dbEnt = new Entities();

        /// <summary>
        /// Handles only calls to display login view
        /// </summary>
        public void GetLogin()
        {
            ViewContext.ActiveForm = new LoginView();
            ViewContext.ActiveForm.ShowDialog();
        }

        /// <param name="loginCredentials">
        /// The values from the login view
        /// </param>
        public void PostLogin(IAccount loginCredentials)
        {
            LoginHelper.LoginUser
            (
                loginCredentials, 
                dbEnt.Account.Accounts().Where(m => m.AccountStatus == SystemConstants.ACCOUNT_STATUS_ACTIVE).ToList() // filter accounts, only active accounts
            );

            // uses the session to determine if there is a logged in user
            if (UserSession.LoggedIn == false)
            {
                // load view again
                MessageBox.Show("Invalid Login credentials.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ViewContext.Dispose();
                new AccountPresenter().GetLogin();
            }
            else
            {
                // load landing page, dashboard
                MessageBox.Show("Login Success.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ViewContext.Dispose();
                /* Audit TRAIL RECORD and System PROMPT */
                AuditTrailHelper.RecordAction("User logged in.");
                MenuHelper.MenuInput();
            }                
        }

        /// <summary>
        /// GET
        /// </summary>
        public void GetRegisterAccount()
        {
            ViewContext.Dispose();

            RegisterAccountView view = new RegisterAccountView();

            var residents = dbEnt.Resident.Residents();
            // filter resilts
            // legal age and not deceased
            residents = residents.Where(m => m.Status == SystemConstants.RESIDENT_STATUS_ALIVE).ToList();
            // not registered already
            List<int> existingResidentIds = dbEnt.Account.Accounts().Select(m => m.ResidentId).ToList();
            // the residents must NOT CONTAIN any id in the existingResidentIds
            residents = residents.Where(m => !existingResidentIds.Contains(m.ResidentId) ).ToList();

            view.Residents = residents;
            view.PopulateDataList();
            ViewContext.ActiveForm = view;
            ViewContext.ActiveForm.ShowDialog();
        }

        /// <summary>
        /// Registers the resident information into a user account
        /// </summary>
        /// <param name="selectedResident">Obtains the Resident model which contains the selected resident to be registered</param>
        public void PostRegisterAccount(IResident selectedResident)
        {
            Account newAccount = new Account();
            newAccount.AccountId = dbEnt.Account.Accounts().Max(m=>m.AccountId) + 1; // only gets the highest Id number for increment
            newAccount.Username = selectedResident.Resident.FirstName.ToLower() + "_" + selectedResident.Resident.LastName.ToLower();
            newAccount.Password = SystemConstants.ACCOUNT_DEFAULT_PASSWORD;
            newAccount.ResidentId = selectedResident.Resident.ResidentId;
            newAccount.RegisteredDate = DateTime.Now;
            newAccount.AccountStatus = SystemConstants.ACCOUNT_STATUS_ACTIVE;

            bool status = dbEnt.Account.InsertAccount(newAccount);

            if (status)
            {
                MessageBox.Show("Account for " + selectedResident.Resident.FirstName + " " + selectedResident.Resident.LastName + " was registered successfully.", "Register Account", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ViewContext.Dispose();
                // go back to landing page
                /* Audit TRAIL RECORD and System PROMPT */
                MenuHelper.MenuInput();

            }
            else
            {
                MessageBox.Show("Account for " + selectedResident.Resident.FirstName + " " + selectedResident.Resident.LastName + " was not registered. Please try again", "Register Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ViewContext.Dispose();
                // reload resident selection for register
                new AccountPresenter().GetRegisterAccount();
            }                
        }

        public void GetDisplayAccounts()
        {
            ViewContext.Dispose();

            DisplayAccountsView view = new DisplayAccountsView();
            // the current logged in user will not be displayed
            view.Accounts = dbEnt.Account.Accounts().Where(m=>m.AccountId != UserSession.User.AccountId).OrderBy(m => m.AccountStatus).ToList();
            ViewContext.ActiveForm = view;
            view.PopulateDataList();
            view.ShowDialog();
        }


        /// <param name="accountId">The account Id of the user that will be archived</param>
        public void DeleteAccount(int accountId)
        {
            Account toDelete = dbEnt.Account.Accounts().Where(m => m.AccountId == accountId).FirstOrDefault();
            List<Account> accounts = dbEnt.Account.Accounts();

            // removes the old record
            accounts.Remove( accounts.Where(m=>m.AccountId == toDelete.AccountId).FirstOrDefault() );
            // re-insert the modified account
            toDelete.AccountStatus = SystemConstants.ACCOUNT_STATUS_ARCHIVED;
            accounts.Add(toDelete);

            // updates the account 
            bool status = dbEnt.Account.SaveAccounts(accounts);

            if (status)
            {
                MessageBox.Show("Account was archived successfully.", "Delete/Archived Account", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ViewContext.Dispose();
                /* Audit TRAIL RECORD and System PROMPT */
                MenuHelper.MenuInput();

            }
            else
            {
                MessageBox.Show("Account was not able to be archived.", "Delete/Archived Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ViewContext.Dispose();
                // reload resident selection for register
                new AccountPresenter().GetDisplayAccounts();
            }
        }
    }
}
