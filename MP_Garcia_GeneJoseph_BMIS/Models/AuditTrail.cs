using MP_Garcia_GeneJoseph_BMIS.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_Garcia_GeneJoseph_BMIS.Models
{
    class AuditTrail
    {
        public int TrailId { get; set; }
        public string Message { get; set; }
        public int AccountId { get; set; }
        public DateTime ActionDate { get; set; }

        /// <summary>
        /// Uses the FileDataContext to retrieve records of recorded audit trails. The calling class can 
        /// just perform lambda expression to filter data.
        /// </summary>
        /// <returns>List of AuditTrail model that contains the data in the text file.</returns>
        public List<AuditTrail> AuditTrails()
        {
            List<AuditTrail> auditTrails = new FileDataContext().ReadAuditTrails();
            return auditTrails;
        }

        /// <summary>
        /// The calling class will save the current data that is stored in AuditTrail list model.
        /// </summary>
        /// <param name="auditTrails">The list model that will be used to write to the file.</param>
        /// <returns>True if the write action is a success, otherwise, false.</returns>
        public bool SaveAuditTrails(List<AuditTrail> auditTrails)
        {
            return new FileDataContext().SaveAuditTrails(auditTrails);
        }
    }
}
