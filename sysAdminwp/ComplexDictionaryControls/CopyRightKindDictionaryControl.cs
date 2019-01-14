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

namespace sysAdminwp.ComplexDictionaryControls
{
    public partial class CopyRightKindDictionaryControl : UserControl
    {
        public delegate void delCheckValidData(TextBox text);
        public CopyRightKindDictionaryControl()
        {

        }
        public CopyRightKindDictionaryControl(CopyrightKind copyR, List<CrkindGroup> list)
        {
            InitializeComponent();
            bsCopyrightKind.DataSource = copyR;
            bsCrkindGroup.DataSource = list;

        }

        private void CopyRightKindDictionaryControl_Click(object sender, EventArgs e)
        {
            ComplexDictionaryParamForm complexDictionary = new ComplexDictionaryParamForm();
            delCheckValidData del = new delCheckValidData();
        }
    }
}
