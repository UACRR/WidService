using ipsFormsDesign.Dictionary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace sysAdminwp.ComplexParamForms
{
    public partial class SystemConstantParams : Telerik.WinControls.UI.RadForm
    {
        public SystemConstantParams(List<DictBaseTypeI> list)
        {
            InitializeComponent();
        }
    }
}
