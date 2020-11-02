using MP_Garcia_GeneJoseph_BMIS.Models;
using MP_Garcia_GeneJoseph_BMIS.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_Garcia_GeneJoseph_BMIS.Helpers
{
    class LoginHelper
    {
        /// <summary>
        /// Static function that handles validating the login credentials, if password and username is correct
        /// the method will create a UserSession that will be used throughout the program.
        /// </summary>
        /// <param name="credentials"></param>
        /// <param name="activeAccounts"></param>
        public static void LoginUser(IAccount credentials, List<Account> activeAccounts)
        {
            Cryptography ceasar = new Cryptography();

            //credentials.Account.Password = HashSet(credentials.Account.Password);
            Account user = activeAccounts.Where(m => m.Username == credentials.Account.Username && m.Password == ceasar.Encrypt(credentials.Account.Password)).FirstOrDefault();
            
            if (user != null)
            {
                // create user session
                UserSession.User = user;
                UserSession.LoggedIn = true;
            }            
        } 
    }
}
