using MP_Garcia_GeneJoseph_BMIS.Helpers;
using MP_Garcia_GeneJoseph_BMIS.Models;
using MP_Garcia_GeneJoseph_BMIS.Views.AuditTrailView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_Garcia_GeneJoseph_BMIS.Presenters
{
    class AuditTrailPresenter
    {
        private Entities dbEnt = new Entities();

        /// <summary>
        /// Renders the view to display all the audit trails
        /// </summary>
        public void DisplayAuditTrails()
        {
            ViewContext.Dispose();
            List<AuditTrail> auditTrails = dbEnt.AuditTrail.AuditTrails().OrderBy(m=>m.ActionDate).ToList();

            DisplayAuditTrailView view = new DisplayAuditTrailView();
            view.AuditTrails = auditTrails;
            view.PopulateDataList();
            ViewContext.ActiveForm = view;
            // render view
            ViewContext.ActiveForm.ShowDialog();
        }
    }
}
