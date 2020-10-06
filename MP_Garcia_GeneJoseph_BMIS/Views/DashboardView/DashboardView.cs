using MP_Garcia_GeneJoseph_BMIS.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_Garcia_GeneJoseph_BMIS.Views.DashboardView
{
    class DashboardView
    {
        public void RunView()
        {
            Console.WriteLine("Welcome {0}!", UserSession.User.Username);
        }
    }
}
