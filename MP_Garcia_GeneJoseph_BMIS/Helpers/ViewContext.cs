using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MP_Garcia_GeneJoseph_BMIS.Helpers
{
    // Handles the disposing of the current running form
    class ViewContext
    {
        public static Form ActiveForm { get; set; }
        public static void Dispose()
        {
            if (ViewContext.ActiveForm != null)
                ViewContext.ActiveForm.Dispose();
        }

        private static void FormOnClose(object sender, FormClosedEventArgs e)
        {
            ViewContext.Dispose();
            MenuHelper.MenuInput();
        }

    }
}
