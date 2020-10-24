using MP_Garcia_GeneJoseph_BMIS.Helpers;
using MP_Garcia_GeneJoseph_BMIS.Models;
using MP_Garcia_GeneJoseph_BMIS.Views.DashboardView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_Garcia_GeneJoseph_BMIS.Presenters
{
    class DashboardPresenter
    {
        /// <summary>
        /// Obtains all the data that will be displayed in the rendered view
        /// </summary>
        public void Index()
        {
            ViewContext.Dispose();
            DashboardView view = new DashboardView();

            Dashboard data = new Dashboard();

            // get data
            List<Resident> residents = new Entities().Resident.Residents();
            data.TotalResidents = residents.Count();
            data.MaleResidentCount = residents.Where(m => m.Sex.ToLower() == "male").Count();
            data.FemaleResidentCount = residents.Where(m => m.Sex.ToLower() == "female").Count();
            data.AliveResidents = residents.Where(m => m.Status.ToLower() == SystemConstants.RESIDENT_STATUS_ALIVE.ToLower()).Count();
            data.DeceasedResidents = residents.Where(m => m.Status.ToLower() == SystemConstants.RESIDENT_STATUS_DECEASED.ToLower()).Count();

            // Categ 1 0 to 16
            DateTime below16 = new DateTime(DateTime.Now.Year - 16, DateTime.Now.Month, DateTime.Now.Day);
            // Categ 2 17 to 21
            DateTime seventeen = new DateTime(DateTime.Now.Year - 17, DateTime.Now.Month, DateTime.Now.Day);
            DateTime twentyone = new DateTime(DateTime.Now.Year - 21, DateTime.Now.Month, DateTime.Now.Day);
            // Categ 3 22 to 59
            DateTime twentytwo = new DateTime(DateTime.Now.Year - 22, DateTime.Now.Month, DateTime.Now.Day);
            DateTime fiftynine = new DateTime(DateTime.Now.Year - 59, DateTime.Now.Month, DateTime.Now.Day);
            // Categ 4 Above 60
            DateTime over60 = new DateTime(DateTime.Now.Year - 60, DateTime.Now.Month, DateTime.Now.Day);

            data.AgeRangeCateg1 = residents.Where(m=>m.Birthdate >= below16).Count();
            data.AgeRangeCateg2 = residents.Where(m => m.Birthdate <= seventeen && m.Birthdate >= twentyone).Count();
            data.AgeRangeCateg3 = residents.Where(m => m.Birthdate <= twentytwo && m.Birthdate >= fiftynine).Count();
            data.AgeRangeCateg4 = residents.Where(m => m.Birthdate <= over60).Count();
            data.AverageAge = (residents.Count() != 0 ? 
                ((data.AgeRangeCateg1 + data.AgeRangeCateg2 + data.AgeRangeCateg3 + data.AgeRangeCateg4) / residents.Count)
                : 0);

            List<Family> families = new Entities().Family.Families();

            data.RegisteredFamilies = families.Count();
            data.FamilyMemberCateg1 = families.Where(m => m.FamilyMembers <= 2).Count();
            data.FamilyMemberCateg2 = families.Where(m => m.FamilyMembers == 3 || m.FamilyMembers == 4).Count();
            data.FamilyMemberCateg3 = families.Where(m => m.FamilyMembers == 5 || m.FamilyMembers == 6).Count();
            data.FamilyMemberCateg4 = families.Where(m => m.FamilyMembers >= 6).Count();

            view.Dashboard = data;
            view.PopulateBoxes();

            ViewContext.ActiveForm = view;
            ViewContext.ActiveForm.ShowDialog();
        }
    }
}
