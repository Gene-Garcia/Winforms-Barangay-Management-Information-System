using MP_Garcia_GeneJoseph_BMIS.Models;
using MP_Garcia_GeneJoseph_BMIS.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_Garcia_GeneJoseph_BMIS.Views.AccountView
{
    class LoginView : IAccount
    {
        private Account account = new Account();
        public Account Account { get { return account; } set { account = value; } }
        public List<Account> Accounts { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void RunView()
        {
            Console.WriteLine("\n\n\t\tLOGIN");
            Console.Write("\tUsername >>");
            account.Username = Console.ReadLine();
            Console.Write("\tPassword >>");
            account.Password = Console.ReadLine();

            new AccountPresenter().PostLogin(this);
        }
    }
}
