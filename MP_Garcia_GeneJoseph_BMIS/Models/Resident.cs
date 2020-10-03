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
        public string Sex { get; set; }
        public DateTime Birthdate { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }

        /// <summary>
        /// Uses the FileDataContext to retrieve records of registered residents. The calling class can 
        /// just perform lambda expression to filter data.
        /// </summary>
        /// <returns>List of Resident model that contains the data in the text file.</returns>
        public List<Resident> Residents()
        {
            List<Resident> residents = new FileDataContext().ReadResidents();
            return residents;
        }

        /// <summary>
        /// The calling class will save the current contains of the Resident model.
        /// </summary>
        /// <param name="residents">The list model that will be used to write to the file.</param>
        /// <returns>True if the write action is a success, otherwise, false.</returns>
        public bool SaveResidents(List<Resident> residents)
        {
            return new FileDataContext().SaveResidents(residents);
        }
    }
}
