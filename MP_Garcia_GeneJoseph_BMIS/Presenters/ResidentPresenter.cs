using MP_Garcia_GeneJoseph_BMIS.Models;
using MP_Garcia_GeneJoseph_BMIS.Views;
using MP_Garcia_GeneJoseph_BMIS.Views.ResidentView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MP_Garcia_GeneJoseph_BMIS.Presenters
{
    class ResidentPresenter
    {
        private Entities dbEnt = new Entities();
        public void GetAddResident()
        {
            new AddResident().RunView();
        }

        public void PostAddResident(IResident newResident)
        {
            newResident.Resident.ResidentId = dbEnt.Resident.Residents().Max(m => m.ResidentId) + 1;

            bool status = dbEnt.Resident.InsertResident(newResident.Resident);

            if (status)
            {
                MessageBox.Show("Resident " + newResident.Resident.FirstName + " " + newResident.Resident.LastName + " was successfully added.", "New Resident Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // go back to landing page
                /* Audit TRAIL RECORD and System PROMPT */
                new DashboardPresenter().Index();

            }
            else
            {
                MessageBox.Show("Resident was not added.", "New Resident Record", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // reload view
                new ResidentPresenter().GetAddResident();
            }
        }
    }
}
