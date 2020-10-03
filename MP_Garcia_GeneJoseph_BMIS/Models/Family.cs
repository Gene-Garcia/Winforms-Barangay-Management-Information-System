using MP_Garcia_GeneJoseph_BMIS.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_Garcia_GeneJoseph_BMIS.Models
{
    class Family
    {
        public int ParentOneId { get; set; }
        public int ParentTwoId { get; set; }
        public int FamilyMembers { get; set; }

        /// <summary>
        /// Uses the FileDataContext to retrieve records of families. The calling class can 
        /// just perform lambda expression to filter data.
        /// </summary>
        /// <returns>List of Family models that contains the data in the text file.</returns>
        public List<Family> Families()
        {
            List<Family> families = new FileDataContext().ReadFamilies();
            return families;
        }

        /// <summary>
        /// The calling class will save the current data that is stored in Family list model.
        /// </summary>
        /// <param name="families">The list model that will be used to write to the file.</param>
        /// <returns>True if the write action is a success, otherwise, false.</returns>
        public bool SaveFamilies(List<Family> families)
        {
            return new FileDataContext().SaveFamilies(families);
        }
    }
}
