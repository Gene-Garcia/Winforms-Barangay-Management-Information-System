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
        public int FamilyId { get; set; }
        public int ParentOneId { get; set; }
        public int ParentTwoId { get; set; }
        public int FamilyMembers { get; set; }

        // Foreign Reference
        public Resident ParentOne { get; set; }
        public Resident ParentTwo { get; set; }

        /// <summary>
        /// Uses the FileDataContext to retrieve records of families. The calling class can 
        /// just perform lambda expression to filter data.
        /// Since a Family record has a foreign key reference of two Resident model, then this method also handles the assignment
        /// of the two Resident records.
        /// </summary>
        /// <returns>List of Family models that contains the data in the text file.</returns>
        public List<Family> Families()
        {
            List<Family> families = new FileDataContext().ReadFamilies();
            List<Resident> residents = new FileDataContext().ReadResidents();

            List<Family> invalidFamilies = new List<Family>();
            foreach (var family in families)
            {
                // A family may only have one parent
                Resident parentInfo = residents.Where(m => m.ResidentId == family.ParentOneId).FirstOrDefault();
                // if there is no parent one then skip the family record, and add to invalid families
                if (parentInfo != null)
                {
                    family.ParentOne = parentInfo;
                    parentInfo = residents.Where(m => m.ResidentId == family.ParentTwoId).FirstOrDefault();

                    if (parentInfo != null)
                        family.ParentTwo = parentInfo;
                }
                else 
                { 
                    invalidFamilies.Add(family); 
                }
            }

            // remove invalid families
            foreach (var invalidFamily in invalidFamilies)
            {
                families.Remove(invalidFamily);
            }
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
