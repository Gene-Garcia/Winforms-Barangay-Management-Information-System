using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_Garcia_GeneJoseph_BMIS.Models
{
    /// <summary>
    /// A class that will hold all of the models
    /// A class can simply instantiate Entities to access records
    /// Similar to the Database Entities of the Entity Framework
    /// </summary>
    class Entities
    {
        public Account Account          = new Account();
        public Resident Resident        = new Resident();
        public Family Family            = new Family();
        public AuditTrail AuditTrail    = new AuditTrail();
        public Summon Summon            = new Summon();
    }
}
