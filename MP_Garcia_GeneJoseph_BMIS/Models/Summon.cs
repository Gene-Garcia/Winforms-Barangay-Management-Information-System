using MP_Garcia_GeneJoseph_BMIS.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_Garcia_GeneJoseph_BMIS.Models
{
    class Summon
    {
        public int SummonId { get; set; }
        public DateTime IncidentDate { get; set; }
        public DateTime ReportedDate { get; set; }
        public string Summary { get; set; }
        public int AccountId { get; set; }

        /// <summary>
        /// Uses the FileDataContext to retrieve records of recorded summon reports. The calling class can 
        /// just perform lambda expression to filter data.
        /// </summary>
        /// <returns>List of Resident model that contains the data in the text file.</returns>
        public List<Summon> Summons()
        {
            List<Summon> summons = new FileDataContext().ReadSummons();
            return summons;
        }

        /// <summary>
        /// The calling class will save the current data that is stored in Summon list model.
        /// </summary>
        /// <param name="summons">The list model that will be used to write to the file.</param>
        /// <returns>True if the write action is a success, otherwise, false.</returns>
        public bool SaveSummons(List<Summon> summons)
        {
            return new FileDataContext().SaveSummons(summons);
        }
    }
}
