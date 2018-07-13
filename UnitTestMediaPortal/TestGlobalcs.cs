using ipsFormsDesign.Data;
using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnitTestMediaPortal
{
    public partial class TestGlobalcs : Form
    {
        public TestGlobalcs()
        {
            InitializeComponent();
        }

        public void SetDic( AnketaDictionaties dic )
        {
            IpsGlobal.SetAnketaDictionaties(dic);
        }
        private void testGlobalDic1_Load(object sender, EventArgs e)
        {

        }
    }
}
