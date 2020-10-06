using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_Garcia_GeneJoseph_BMIS.Models
{
    class Entities
    {
        public Account Account          = new Account();
        public Resident Resident        = new Resident();
        public Family Family            = new Family();
        public AuditTrail AuditTrail    = new AuditTrail();
        public Summon Summon            = new Summon();
    }
}
