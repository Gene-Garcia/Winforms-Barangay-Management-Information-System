using MP_Garcia_GeneJoseph_BMIS.Helpers;
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

        public void Login(IAccount loginCredentials)
        {
            Console.WriteLine("Logged User\n" + UserSession.User.Username);
            
        }

    }
}
