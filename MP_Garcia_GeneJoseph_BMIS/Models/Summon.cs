﻿using System;
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Summon> Summons()
        {
            return null;
        }
    }
}
