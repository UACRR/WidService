using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace UnitTestMediaPortal
{
    public partial class FormIBindingList : Form
    {
        // public 

        public FormIBindingList()
        {
            InitializeComponent();
        }

        public object DataSource
        {
            get { return calculationInfoNewControl1.DataSource; }
            set { calculationInfoNewControl1.DataSource = value; }
        }

        public RadGridView usersMoney { get { return calculationInfoNewControl1.gvUserMoney;  } } 

    }
}
