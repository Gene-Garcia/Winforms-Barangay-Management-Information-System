using MP_Garcia_GeneJoseph_BMIS.Helpers;
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
            ViewContext.ActiveForm = view;
            ViewContext.ActiveForm.ShowDialog();
        }
    }
}
