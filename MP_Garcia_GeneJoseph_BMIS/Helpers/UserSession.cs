using MP_Garcia_GeneJoseph_BMIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MP_Garcia_GeneJoseph_BMIS.Helpers
{
    /// <summary>
    /// A static class that is similar to Session in web applications
    /// </summary>
    class UserSession
    {
        public static Account User { get; set; }
        public static bool LoggedIn = false;
    }
}
