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
                dbEnt.Account.Accounts().Where(m => m.AccountStatus.ToUpper() == "ACTIVE").ToList() // filter accounts, only active accounts
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
                new DashboardPresenter().Index();
            }                
        }

        /// <summary>
        /// GET
        /// </summary>
        public void GetRegisterAccount()
        {
            RegisterAccountView view = new RegisterAccountView();
            view.Residents = dbEnt.Resident.Residents();
            view.RunView();
        }

        public void PostRegisterAccount(IResident selectedResident)
        {
            Account newAccount = new Account();
            newAccount.AccountId = selectedResident.Residents.Count() + 1;
            newAccount.Username = selectedResident.Resident.FirstName.ToLower() + "_" + selectedResident.Resident.LastName.ToLower();
            newAccount.Password = "qwertypad360";
            newAccount.ResidentId = selectedResident.Resident.ResidentId;
            newAccount.RegisteredDate = DateTime.Now;
            newAccount.AccountStatus = "ACTIVE";

            // append to accounts
            // stopped here -- implement in model entities to just append records in the text file
            // save to text file

            // go back to landing page
            new DashboardPresenter().Index();
        }
    }
}
