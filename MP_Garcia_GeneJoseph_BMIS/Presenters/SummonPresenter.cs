using MP_Garcia_GeneJoseph_BMIS.Helpers;
using MP_Garcia_GeneJoseph_BMIS.Models;
using MP_Garcia_GeneJoseph_BMIS.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MP_Garcia_GeneJoseph_BMIS.Presenters
{
    class SummonPresenter
    {
        private Entities dbEnt = new Entities();
        
        // display all summon
        // add new summon
        // search id
        public void GetCreateSummon()
        {
            // render view
        }

        public void PostCreateSummon(ISummon newSummon)
        {
            Summon summon = newSummon.Summon;
            summon.ReportedDate = DateTime.Now;
            summon.SummonId = dbEnt.Summon.Summons().Max(m => m.SummonId) + 1;

            bool status = dbEnt.Summon.InsertSummon(summon);

            if (status)
            {
                MessageBox.Show("New summon report created successfully.", "New Summon Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // go back to landing page
                /* Audit TRAIL RECORD and System PROMPT */
                MenuHelper.MenuInput();

            }
            else
            {
                MessageBox.Show("Unavailable to create new summon report.", "New Summon Report", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // reload view
                new SummonPresenter().GetCreateSummon();
            }
        }

        public void GetDisplaySummons()
        {
            
        }

        public void GetSearchSummon()
        {
            
        }
    }
}
