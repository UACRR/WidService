using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Model;
using ipsFormsDesign.Dictionary;

namespace sysAdminwp.ComplexDictionaryControls
{
    public partial class CopyRightKindDictionaryControl : UserControl, IComplexDictionary
    {
        public CopyRightKindDictionaryControl(CopyrightKind copyR, List<DictBaseTypeI> list)
        {
            InitializeComponent();
            bsCopyrightKind.DataSource = copyR;
            bsCrkindGroup.DataSource = list;
        }

        public bool Validation()
        {
            bool isvalid = true;
            isvalid = ddlKindShototam.SelectedValue != null;

            return isvalid;
        }
    }
}
