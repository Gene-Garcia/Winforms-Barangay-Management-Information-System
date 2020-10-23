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
        /// 
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

            data.AgeRangeCateg1 = 1;
            data.AgeRangeCateg2 = 2;
            data.AgeRangeCateg3 = 3;
            data.AgeRangeCateg4 = 2;
            data.AverageAge = (data.AgeRangeCateg4 + data.AgeRangeCateg3 + data.AgeRangeCateg2 + data.AgeRangeCateg1) / (residents.Count() != 0 ? residents.Count() : 1);

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
