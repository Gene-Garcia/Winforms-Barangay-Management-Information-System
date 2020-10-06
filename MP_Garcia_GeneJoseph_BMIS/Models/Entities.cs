using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_Garcia_GeneJoseph_BMIS.Models
{
    class Entities
    {
        public Account Account { get; set; }
        public Resident Resident { get; set; }
        public Family Family { get; set; }
        public AuditTrail AuditTrail { get; set; }
        public Summon Summon { get; set; }
    }
}
