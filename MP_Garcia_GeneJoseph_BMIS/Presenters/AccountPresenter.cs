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

        public void Login(IAccount loginCredentials)
        {
            LoginHelper.LoginUser
                (
                    loginCredentials, 
                    dbEnt.Account.Accounts().Where(m => m.AccountStatus.ToUpper() == "ACTIVE").ToList() // filter accounts, only active accounts
                );

            if (UserSession.LoggedIn == false)
            {
                MessageBox.Show("Invalid Login credentials.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                new LoginView().RunView();
            }
            else
            {
                Console.WriteLine("Successfull login");
                new DashboardView().RunView();
            }
                
        }

    }
}
