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
        public string Summary { get; set; }
        public DateTime ReportedDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Family> Families()
        {
            return null;
        }
    }
}
