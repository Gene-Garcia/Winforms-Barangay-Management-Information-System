using MP_Garcia_GeneJoseph_BMIS.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_Garcia_GeneJoseph_BMIS.Models
{
    class Resident
    {
        public int ResidentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public string Sex { get; set; }
        public string Address { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Resident> Residents()
        {
            List<Resident> residents = new FileDataContext().ReadResidents();
            return residents;
        }
    }
}
