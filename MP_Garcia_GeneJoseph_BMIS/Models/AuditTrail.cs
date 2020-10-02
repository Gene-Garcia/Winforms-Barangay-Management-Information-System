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
        /// 
        /// </summary>
        /// <returns></returns>
        public List<AuditTrail> AuditTrails()
        {
            return null;
        }
    }
}
