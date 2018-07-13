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
    public partial class RadTestExpandoObject : Telerik.WinControls.UI.RadForm
    {
        public RadTestExpandoObject()
        {
            InitializeComponent();
        }

        public object DataSource { set => radGridView1.DataSource = value;  }
    }
}
