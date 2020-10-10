using MP_Garcia_GeneJoseph_BMIS.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_Garcia_GeneJoseph_BMIS.Models
{
    class Account
    {
        // restriction, does not neccessarily remove the account, but set its type as ARCHIVED
        public int AccountId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int ResidentId { get; set; }
        public DateTime RegisteredDate { get; set; }
        // ARCHIVED, ACTIVE
        public string AccountStatus { get; set; }

        // Foreign Table/Model/Reference
        public Resident Resident { get; set; }

        /// <summary>
        /// Uses the FileDataContext to retrieve records of registered user accounts. The calling class can 
        /// just perform lambda expression to filter data.
        /// Since an Account record has a foreign key reference of Resident model, then this method also handles the assignment
        /// of the Resident record.
        /// </summary>
        /// <returns>List of Accounts model that contains the data in the text file.</returns>
        public List<Account> Accounts()
        {
            List<Account> accounts = new FileDataContext().ReadAccounts();
            List<Resident> residents = new FileDataContext().ReadResidents();

            List<Account> invalidAccounts = new List<Account>();
            foreach (var account in accounts)
            {
                // the account is invalid if the Account does not have Resident record, then we remove it from the list
                Resident userinfo = residents.Where(m => m.ResidentId == account.ResidentId).FirstOrDefault();
                if (userinfo != null)
                    account.Resident = userinfo;
                else
                    invalidAccounts.Add(account);
            } 

            // delete invalid account
            foreach (var invalidAccount in invalidAccounts)
            {
                accounts.Remove(invalidAccount);
            }

            return accounts;
        }

        /// <summary>
        /// The calling class will save the current data that is stored in Account model.
        /// </summary>
        /// <param name="accounts">The list model that will be used to write to the file.</param>
        /// <returns>True if the write action is a success, otherwise, false.</returns>
        public bool SaveAccounts(List<Account> accounts)
        {
            return new FileDataContext().SaveAccounts(accounts);
        }

        /// <summary>
        /// Appends the new Account model into the text file
        /// </summary>
        /// <param name="newAccount">New account record</param>
        /// <returns>True if the append action is successfull, otherwise, false</returns>
        public bool InsertAccount(Account newAccount)
        {
            return new FileDataContext().InsertAccount(newAccount);
        }
    }
}
