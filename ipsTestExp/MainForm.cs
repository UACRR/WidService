using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ipsTestExp;
using System.Windows.Forms;
using sysAdminwp;
using Telerik.WinControls;
using Telerik.WinControls.UI;


namespace ipsTestExp
{
    public partial class MainForm:RadForm
    {

        public MainForm()
        {
            InitializeComponent();
            uct.UpdateData();
            
        }

        public void Control()
        {
            uct.TreeSourse = null;
        }
    }
}
