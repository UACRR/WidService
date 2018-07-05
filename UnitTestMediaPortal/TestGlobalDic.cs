using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Data;

namespace UnitTestMediaPortal
{
    public partial class TestGlobalDic : UserControl
    {
        public TestGlobalDic()
        {
            InitializeComponent();
            radDropDownList1.DataSource = IpsGlobal.Dic?.country;
            // IpsGlobal.Dic?.country[0].CountryNameShort;
            radDropDownList1.ValueMember = "CountryCode";
            radDropDownList1.DisplayMember = "CountryNameShort";

            IpsGlobal.DicChanged += IpsGlobal_DicChanged;
        }

        private void IpsGlobal_DicChanged(object sender, EventArgs e)
        {
            radDropDownList1.DataSource = IpsGlobal.Dic?.country;
            ;
        }
    }
}
