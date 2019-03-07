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
    public partial class SystemConstantParamsForm : Telerik.WinControls.UI.RadForm
    {
        public SystemConstantParamsForm(List<DictBaseTypeI> list)
        {
            InitializeComponent();
        }
    }
}
