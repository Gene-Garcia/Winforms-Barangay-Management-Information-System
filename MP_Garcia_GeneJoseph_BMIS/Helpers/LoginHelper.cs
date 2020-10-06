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
        public static void LoginUser(IAccount credentials, List<Account> activeAccounts)
        {
            //credentials.Account.Password = HashSet(credentials.Account.Password);
            Account user = activeAccounts.Where(m => m.Username == credentials.Account.Username && m.Password == credentials.Account.Password).FirstOrDefault();
            
            if (user != null)
            {
                // create user session
                UserSession.User = user;
                UserSession.LoggedIn = true;
            }            
        } 
    }
}
