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

        /// <param name="loginCredentials">
        /// The values from the login view
        /// </param>
        public void Login(IAccount loginCredentials)
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
                LoginView view = new LoginView();
                view.Account = loginCredentials.Account; // reload login information
                view.RunView();
            }
            else
            {
                // load landing page, dashboard
                MessageBox.Show("Login Success.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                new DashboardView().RunView();
            }                
        }

    }
}
