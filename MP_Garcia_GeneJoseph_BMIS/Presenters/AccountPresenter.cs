using MP_Garcia_GeneJoseph_BMIS.Helpers;
using MP_Garcia_GeneJoseph_BMIS.Models;
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

    }
}
