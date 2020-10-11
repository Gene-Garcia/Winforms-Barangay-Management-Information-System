using MP_Garcia_GeneJoseph_BMIS.Helpers;
using MP_Garcia_GeneJoseph_BMIS.Models;
using MP_Garcia_GeneJoseph_BMIS.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_Garcia_GeneJoseph_BMIS.Views.AccountView
{
    class DisplayAccounts : IAccount
    {
        public Account Account { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private List<Account> accounts = new List<Account>();
        public List<Account> Accounts
        {
            get
            {
                // get views text
                return accounts;
            }
            set
            {
                accounts = value;
                // set views text
            }
        }

        public void RunView()
        {
            int toDeleteId = 0;

            Console.WriteLine("\n\n\t\tDISPLAY ACCOUNTS");
            foreach (var acc in accounts)
            {
                Console.WriteLine("\tAccount Id {0}", acc.AccountId);
                Console.WriteLine("\tUsername {0}", acc.Username);
                Console.WriteLine("\tAccount Status {0}\n", acc.AccountStatus);
            }

            do
            {
                Console.Write("\tAccount to delete/archived >>");
                toDeleteId = int.Parse(Console.ReadLine());

                // the should also be active, to be archived
                Account toDelete = this.accounts.Where(m => m.AccountId == toDeleteId && m.AccountStatus == SystemConstants.ACCOUNT_STATUS_ACTIVE).FirstOrDefault();

                if (toDelete != null)
                    break;
                else
                    Console.WriteLine("\tAccount not found or account is already archived.\n");

            } while (true);

            new AccountPresenter().DeleteAccount(this, toDeleteId);
        }
    }
}
