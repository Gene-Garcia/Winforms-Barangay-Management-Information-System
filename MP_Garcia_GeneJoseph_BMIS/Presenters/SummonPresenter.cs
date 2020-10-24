using MP_Garcia_GeneJoseph_BMIS.Helpers;
using MP_Garcia_GeneJoseph_BMIS.Models;
using MP_Garcia_GeneJoseph_BMIS.Views;
using MP_Garcia_GeneJoseph_BMIS.Views.SummonView;
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

        /// <summary>
        /// Renders the view where the user can input information to create a summon report
        /// </summary>
        public void GetCreateSummon()
        {
            ViewContext.Dispose();

            CreateSummonView view = new CreateSummonView();
            ViewContext.ActiveForm = view;
            // render view
            ViewContext.ActiveForm.ShowDialog();
        }

        /// <summary>
        /// Handles the creation of a summon report using the field text from the view
        /// </summary>
        /// <param name="newSummon">Contains the report information given by the user</param>
        public void PostCreateSummon(ISummon newSummon)
        {
            Summon summon = newSummon.Summon;
            summon.ReportedDate = DateTime.Now.Date;

            List<Summon> summons = dbEnt.Summon.Summons();
            summon.SummonId = summons.Count > 0 ? summons.Max(m=>m.SummonId) + 1 : 1;
            summon.AccountId = UserSession.User.AccountId;

            bool status = dbEnt.Summon.InsertSummon(summon);

            if (status)
            {
                MessageBox.Show("New summon report created successfully.", "New Summon Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ViewContext.Dispose();
                // go back to landing page
                /* Audit TRAIL RECORD and System PROMPT */
                AuditTrailHelper.RecordAction("New summon created with Id " + summon.SummonId);
                MenuHelper.MenuInput();
            }
            else
            {
                MessageBox.Show("Unavailable to create new summon report.", "New Summon Report", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // reload view
                new SummonPresenter().GetCreateSummon();
            }
        }

        /// <summary>
        /// Renders the view where all the summon reports will be displayed
        /// </summary>
        public void GetDisplaySummons()
        {
            ViewContext.Dispose();

            List<Summon> summons = dbEnt.Summon.Summons().OrderBy(m => m.ReportedDate).ToList();

            DisplaySummonsView view = new DisplaySummonsView();
            view.Summons = summons;
            view.PopulateDataList();
            ViewContext.ActiveForm = view;

            // render view
            ViewContext.ActiveForm.ShowDialog();
        }

        /// <summary>
        /// Renders the view where the user can search a summon by summon id
        /// </summary>
        public void GetSearchSummon()
        {
            ViewContext.Dispose();

            SearchSummonView view = new SearchSummonView();
            ViewContext.ActiveForm = view;
            ViewContext.ActiveForm.ShowDialog();
        }

        /// <summary>
        /// Renders the view where a detailed information of the summary report using the summonId. 
        /// Calls can either be from the DisplaySummons and SearchView
        /// </summary>
        /// <param name="summonId">The summon id of the summon report to be displayed</param>
        public void GetDisplaySummon(int summonId)
        {
            ViewContext.Dispose();
            Summon summon = dbEnt.Summon.Summons().Where(m => m.SummonId == summonId).FirstOrDefault();

            if (summon != null)
            {
                ViewSummonView view = new ViewSummonView();
                view.Summon = summon;
                view.ModelToFields();
                ViewContext.ActiveForm = view;
                // render view
                ViewContext.ActiveForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Summon report cannot be found.", "Search Summon", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MenuHelper.MenuInput();
            }
        }

    }
}
