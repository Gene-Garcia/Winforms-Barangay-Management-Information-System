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
        public int AccountId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int ResidentId { get; set; }
        public DateTime RegisteredDate { get; set; }

        /// <summary>
        /// Uses the FileDataContext to retrieve records of registered user accounts. The calling class can 
        /// just perform lambda expression to filter data.
        /// </summary>
        /// <returns>List of Accounts model that contains the data in the text file.</returns>
        public List<Account> Accounts()
        {
            List<Account> accounts = new FileDataContext().ReadAccounts();
            return accounts;
        }

        /// <summary>
        /// The calling class will save the current contains of the Account model.
        /// </summary>
        /// <param name="accounts">The list model that will be used to write to the file.</param>
        /// <returns>True if the write action is a success, otherwise, false.</returns>
        public bool SaveAccounts(List<Account> accounts)
        {
            return new FileDataContext().SaveAccounts(accounts);
        }
    }
}
