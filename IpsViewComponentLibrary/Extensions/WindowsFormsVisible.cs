using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.Extensions
{
    public class WindowsFormsVisible
    {
        /// <summary>
        /// Показати приховану, мінімізовану або на задньому плані форму
        /// </summary>
        /// <param name="form">Telerik RadForm</param>
        public static void ShowHiddenWindow(RadForm form)
        {
            if(form == null)
                return;

            if (!form.Visible)
                form.Show();

            if (form.WindowState == FormWindowState.Minimized)
                form.WindowState = FormWindowState.Maximized;

            form.BringToFront();
        }

        public static void ShowHiddenDialogWindow(RadForm form)
        {
            if (form == null)
                return;

            if (!form.Visible)
                form.ShowDialog();

            if (form.WindowState == FormWindowState.Minimized)
                form.WindowState = FormWindowState.Maximized;

            form.BringToFront();
        }
    }
}
