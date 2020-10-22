using MP_Garcia_GeneJoseph_BMIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_Garcia_GeneJoseph_BMIS.Views
{
    interface IAuditTrail
    {
        AuditTrail AuditTrail { get; set; }
        List<AuditTrail> AuditTrails { get; set; }
    }
}
