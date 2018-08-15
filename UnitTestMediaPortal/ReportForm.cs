using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace UnitTestMediaPortal
{
    public partial class ReportForm : Telerik.WinControls.UI.RadForm
    {
        public ReportForm()
        {
            InitializeComponent();
            reportViewer1.Refresh();
        }

    }
}
