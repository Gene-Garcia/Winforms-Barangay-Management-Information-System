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

        /// <param name="newResident">Contains the complete information of the new resident, except for an residentId/param>
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

        public void GetDisplayResidents()
        {
            // DisplayResidents view = new DisplayResidents();
            // view.Residents = dbEnt.
            // view.RunView();
        }

        /// <summary>
        /// Displays a specific resident
        /// </summary>
        public void GetViewResident(int residentId)
        {
            Resident resident = dbEnt.Resident.Residents().Where(m => m.ResidentId == residentId).FirstOrDefault();

            if (resident != null)
            {
                // render view
            }
            else
            {
                MessageBox.Show("Resident cannot be found", "View Resident", MessageBoxButtons.OK, MessageBoxIcon.Error);
                new ResidentPresenter().GetDisplayResidents();
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resident">Contains the updated resident model, and the list of currenet residents</param>
        public void PostUpdateResident(IResident resident)
        {
            // remove the old version resident from residents
            resident.Residents.Remove( resident.Resident );
            // re-insert the new version of resident to list
            resident.Residents.Add( resident.Resident );
            // update text file

            bool status = dbEnt.Resident.SaveResidents(resident.Residents);

            if (status)
            {
                MessageBox.Show("Resident " + resident.Resident.FirstName + " " + resident.Resident.LastName + "'s record was updated successfully.", "Update Resident", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // go back to landing page
                /* Audit TRAIL RECORD and System PROMPT */
                new DashboardPresenter().Index();

            }
            else
            {
                MessageBox.Show("Resident " + resident.Resident.FirstName + " " + resident.Resident.LastName + "'s record was not updated.", "Update Resident", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // reload view
                new ResidentPresenter().GetDisplayResidents();
            }
        }
    }
}
