using MP_Garcia_GeneJoseph_BMIS.Helpers;
using MP_Garcia_GeneJoseph_BMIS.Models;
using MP_Garcia_GeneJoseph_BMIS.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_Garcia_GeneJoseph_BMIS.Presenters
{
    class AccountPresenter
    {
        private Entities dbEnt = new Entities();

        public void Login(IAccount loginCredentials)
        {
            Console.WriteLine("Logged User\n" + UserSession.User.Username);
            Account loggedIn = LoginHelper.LoginUser
                (
                    loginCredentials, 
                    dbEnt.Account.Accounts().Where(m => m.AccountStatus.ToUpper() == "ACTIVE").ToList() // filter accounts, only active accounts
                );
        }

    }
}
