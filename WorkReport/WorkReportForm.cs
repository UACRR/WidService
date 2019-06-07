using ipsFormsDesign.Data;
using ipsFormsDesign.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace workReport
{
    public partial class WorkReportForm : Telerik.WinControls.UI.RadForm
    {
        public WorkReportForm()
        {
            var objectrightService = new ObjectRightService();
            IpsGlobal.SetObjectRightDictionaries(objectrightService.GetDictionary());

            var rightholderService = new RightholderService();
            IpsGlobal.SetAnketaDictionaties(rightholderService.GetDictionary());
            InitializeComponent();
            ThemeResolutionService.ApplicationThemeName = "Office2013Light";

        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
