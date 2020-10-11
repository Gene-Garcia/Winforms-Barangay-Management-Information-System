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
            new LoginView().RunView();
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
                new AccountPresenter().GetLogin();
            }
            else
            {
                // load landing page, dashboard
                MessageBox.Show("Login Success.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                /* Audit TRAIL RECORD and System PROMPT */
                new DashboardPresenter().Index();
            }                
        }

        /// <summary>
        /// GET
        /// </summary>
        public void GetRegisterAccount()
        {
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
            view.RunView();
        }

        /// <summary>
        /// Registers the resident information into a user account
        /// </summary>
        /// <param name="selectedResident">Obtains the Resident model which contains the selected resident to be registered</param>
        public void PostRegisterAccount(IResident selectedResident)
        {
            Account newAccount = new Account();
            newAccount.AccountId = dbEnt.Account.Accounts().Count + 1; // only gets the number of registered accounts
            newAccount.Username = selectedResident.Resident.FirstName.ToLower() + "_" + selectedResident.Resident.LastName.ToLower();
            newAccount.Password = SystemConstants.ACCOUNT_DEFAULT_PASSWORD;
            newAccount.ResidentId = selectedResident.Resident.ResidentId;
            newAccount.RegisteredDate = DateTime.Now;
            newAccount.AccountStatus = SystemConstants.ACCOUNT_STATUS_ACTIVE;

            bool status = dbEnt.Account.InsertAccount(newAccount);

            if (status)
            {
                MessageBox.Show("Account for " + selectedResident.Resident.FirstName + " " + selectedResident.Resident.LastName + " was registered successfully.", "Register Account", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // go back to landing page
                /* Audit TRAIL RECORD and System PROMPT */
                new DashboardPresenter().Index();
                
            }
            else
            {
                MessageBox.Show("Account for " + selectedResident.Resident.FirstName + " " + selectedResident.Resident.LastName + " was not registered. Please try again", "Register Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // reload resident selection for register
                new AccountPresenter().GetRegisterAccount();
            }                
        }
    }
}
