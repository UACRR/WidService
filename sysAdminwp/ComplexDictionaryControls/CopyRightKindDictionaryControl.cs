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
        public CopyRightKindDictionaryControl(CopyrightKind copyR, List<CrkindGroup> list)
        {
            InitializeComponent();
            bsCopyrightKind.DataSource = copyR;
            bsCrkindGroup.DataSource = list;

        }
    }
}
