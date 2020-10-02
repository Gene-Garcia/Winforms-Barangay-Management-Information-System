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
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Account> Accounts()
        {
            return null;
        }
    }
}
