using MP_Garcia_GeneJoseph_BMIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_Garcia_GeneJoseph_BMIS.Views
{
    interface ISummon
    {
        Summon Summon { get; set; }
        List<Summon> Summons { get; set; }
    }
}
