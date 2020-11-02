using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MP_Garcia_GeneJoseph_BMIS.Helpers
{
    /// <summary>
    /// Handles the disposing of the current running form, and
    /// holds the listner for the form close
    /// </summary>
    class ViewContext
    {
        public static Form ActiveForm { get; set; }
        public static void Dispose()
        {
            if (ActiveForm != null)
                ActiveForm.Dispose();
        }

        public static void FormOnClose(object sender, FormClosedEventArgs e)
        {
            Dispose();
            MenuHelper.MenuInput();
        }

    }
}
