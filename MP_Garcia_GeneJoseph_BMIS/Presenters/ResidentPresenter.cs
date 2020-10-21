using MP_Garcia_GeneJoseph_BMIS.Helpers;
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
            ViewContext.Dispose();

            ViewResidentView view = new ViewResidentView();

            ViewContext.ActiveForm = view;
            ViewContext.ActiveForm.ShowDialog();
        }

        /// <param name="newResident">Contains the complete information of the new resident, except for an residentId/param>
        public void PostAddResident(IResident newResident)
        {
            newResident.Resident.ResidentId = dbEnt.Resident.Residents().Max(m => m.ResidentId) + 1;

            bool status = dbEnt.Resident.InsertResident(newResident.Resident);

            if (status)
            {
                MessageBox.Show("Resident " + newResident.Resident.FirstName + " " + newResident.Resident.LastName + " was successfully added.", "New Resident Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ViewContext.Dispose();
                // go back to landing page
                /* Audit TRAIL RECORD and System PROMPT */
                AuditTrailHelper.RecordAction("New resident record with name: " + newResident.Resident.FirstName + " " + newResident.Resident.LastName);
                MenuHelper.MenuInput();

            }
            else
            {
                MessageBox.Show("Resident was not added.", "New Resident Record", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ViewContext.Dispose();
                // reload view
                new ResidentPresenter().GetAddResident();
            }
        }

        /// <summary>
        /// basically renders the view where the user a resident by its name
        /// </summary>
        public void GetSearchResident()
        {
            ViewContext.Dispose();

            SearchResidentView view = new SearchResidentView();
            ViewContext.ActiveForm = view;
            ViewContext.ActiveForm.ShowDialog();
        }


        /// <param name="search">Contains the search parameters to find a resident record</param>
        public void PostSearchResident(IResident searchView)
        {
            Resident searched = dbEnt.Resident.Residents().
                Where(m => 
                m.FirstName.ToUpper() == searchView.Resident.FirstName.ToUpper() &&
                m.MiddleName.ToUpper() == searchView.Resident.MiddleName.ToUpper() &&
                m.LastName.ToUpper() == searchView.Resident.LastName.ToUpper())
                .FirstOrDefault();

            if (searched != null)
            {
                ViewContext.Dispose();
                new ResidentPresenter().GetViewResident(searched.ResidentId);
            }
            else
            {
                MessageBox.Show("Resident cannot be found", "View Resident", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ViewContext.Dispose();
                new ResidentPresenter().GetDisplayResidents();
            }
        }

        /// <summary>
        /// The view dispays an action button to trigger GetViewResident(id), and PostToResidentDeceased(id)
        /// </summary>
        public void GetDisplayResidents()
        {
            ViewContext.Dispose();

            DisplayResidentsView view = new DisplayResidentsView();
            view.Residents = dbEnt.Resident.Residents().OrderBy(m=>m.Status).ToList();
            view.PopulateDataList();
            ViewContext.ActiveForm = view;
            ViewContext.ActiveForm.ShowDialog();
        }

        /// <summary>
        /// Displays a specific resident, the view allows the fields to be edited, including the status
        /// </summary>
        public void GetViewResident(int residentId)
        {
            ViewContext.Dispose();

            Resident resident = dbEnt.Resident.Residents().Where(m => m.ResidentId == residentId).FirstOrDefault();

            if (resident != null)
            {
                ViewResidentView view = new ViewResidentView();
                view.Resident = resident;
                ViewContext.ActiveForm = view;
                ViewContext.ActiveForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Resident cannot be found", "View Resident", MessageBoxButtons.OK, MessageBoxIcon.Error);
                new ResidentPresenter().GetDisplayResidents();
            }

        }

        /// <param name="view">Contains the updated resident model</param>
        public void PostUpdateResident(IResident view)
        {
            List<Resident> residents = dbEnt.Resident.Residents();
            // remove the old version resident from residents
            residents.Remove(residents.Where(m => m.ResidentId == view.Resident.ResidentId).FirstOrDefault());
            // re-insert the new version of resident to list
            residents.Add(view.Resident);
            // update text file

            bool status = dbEnt.Resident.SaveResidents(residents);

            if (status)
            {
                MessageBox.Show("Resident " + view.Resident.FirstName + " " + view.Resident.LastName + "'s record was updated successfully.", "Update Resident", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // go back to landing page
                /* Audit TRAIL RECORD and System PROMPT */
                AuditTrailHelper.RecordAction("Resident information updated with name: " + view.Resident.FirstName + " " + view.Resident.LastName);
                ViewContext.Dispose();
                MenuHelper.MenuInput();

            }
            else
            {
                MessageBox.Show("Resident " + view.Resident.FirstName + " " + view.Resident.LastName + "'s record was not updated.", "Update Resident", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // reload view
                ViewContext.Dispose();
                new ResidentPresenter().GetDisplayResidents();
            }
        }

        public void PostToResidentDeceased(int residentId)
        {
            List<Resident> residents = dbEnt.Resident.Residents();
            Resident toDeceased = residents.Where(m => m.ResidentId == residentId).FirstOrDefault();

            if (toDeceased != null)
            {
                // remove from list
                residents.Remove(toDeceased);
                // re-insert
                toDeceased.Status = SystemConstants.RESIDENT_STATUS_DECEASED;
                residents.Add(toDeceased);
                // update text file
                bool status = dbEnt.Resident.SaveResidents(residents);

                if (status)
                {
                    MessageBox.Show("Resident " + toDeceased.FirstName + " " + toDeceased.LastName + "'s status is set to as deceased.", "Deceased Resident", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // go back to landing page
                    ViewContext.Dispose();
                    /* Audit TRAIL RECORD and System PROMPT */
                    AuditTrailHelper.RecordAction("Resident " + toDeceased.FirstName + " " + toDeceased.LastName + " is set to deceased.");
                    MenuHelper.MenuInput();

                }
                else
                {
                    MessageBox.Show("Resident " + toDeceased.FirstName + " " + toDeceased.LastName + "'s status was not able to be set to deceased.", "Deceased Resident", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ViewContext.Dispose();
                    // reload view
                    new ResidentPresenter().GetViewResident(toDeceased.ResidentId);
                }
            }
            else
            {
                MessageBox.Show("Resident cannot be found.", "Deceased Resident", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ViewContext.Dispose();
                // reload view
                new ResidentPresenter().GetDisplayResidents();
            }
        }

        public void GetDisplayFamilies()
        {
            ViewContext.Dispose();

            List<Family> families = dbEnt.Family.Families().OrderBy(m=>m.FamilyMembers).ToList();
            DisplayFamiliesView view = new DisplayFamiliesView();
            view.Families = families;
            view.PopulateDataList();
            // render view
            ViewContext.ActiveForm = view;
            ViewContext.ActiveForm.ShowDialog();
        }

        public void GetAddFamily()
        {
            ViewContext.Dispose();

            List<Family> existingFamilies = dbEnt.Family.Families();
            // obtain the resident Id of those that already have family records
            List<int> idsP1 = existingFamilies.Select(m => m.ParentOneId).ToList();
            List<int> idsP2 = existingFamilies.Select(m => m.ParentTwoId).ToList();

            // filters the residents, does not display residents that already have family records
            List<Resident> parentChoices = dbEnt.Resident.Residents().Where(m=> !idsP1.Contains(m.ResidentId) && !idsP2.Contains(m.ResidentId)).ToList();

            // RENDER VIEW
            AddFamilyView view = new AddFamilyView();
            view.Residents = parentChoices;
            view.PopulateFirstDataList();
            ViewContext.ActiveForm = view;
            ViewContext.ActiveForm.ShowDialog();
        }

        /// <param name="parentOneId"></param>
        /// <param name="parentTwoId">Optional</param>
        /// <param name="familyMembers"></param>
        public void PostSaveFamily(int parentOneId, int parentTwoId, int familyMembers)
        {
            Family newFamily = new Family();
            newFamily.FamilyId = dbEnt.Family.Families().Max(m=>m.FamilyId) + 1;
            newFamily.FamilyMembers = familyMembers;
            newFamily.ParentOneId = parentOneId;

            if (parentTwoId != null || parentTwoId > 0)
                newFamily.ParentTwoId = parentTwoId;

            bool status = dbEnt.Family.InsertFamily(newFamily);

            if (status)
            {
                MessageBox.Show("Family record was successfully created.", "New Family Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ViewContext.Dispose();
                // go back to landing page
                /* Audit TRAIL RECORD and System PROMPT */
                AuditTrailHelper.RecordAction("New family recorded.");
                MenuHelper.MenuInput();

            }
            else
            {
                MessageBox.Show("Unable to create new family record.", "New Family Record", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // reload view
                new ResidentPresenter().GetAddFamily();
            }
        }

        public void PostChangeFamilySize(int familyId, int newFamilySize)
        {
            List<Family> families = dbEnt.Family.Families();
            Family family = families.Where(m => m.FamilyId == familyId).FirstOrDefault();
            // remove old record from the list
            families.Remove(family);
            // update family members
            family.FamilyMembers = newFamilySize;
            // reinsert
            families.Add(family);
            // upload to text file

            bool status = dbEnt.Family.SaveFamilies(families);
            if (status)
            {
                MessageBox.Show("Family record's family size update with primary parent " + family.ParentOne.FirstName + " " + family.ParentOne.LastName, "Change Family Size", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ViewContext.Dispose();
                // go back to landing page
                /* Audit TRAIL RECORD and System PROMPT */
                AuditTrailHelper.RecordAction("Family record's family size change with primary parent " + family.ParentOne.FirstName + " " + family.ParentOne.LastName);
                MenuHelper.MenuInput();

            }
            else
            {
                MessageBox.Show("Unable update family size.", "Family Record", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // reload view
                new ResidentPresenter().GetDisplayFamilies();
            }

        }
    }
}
