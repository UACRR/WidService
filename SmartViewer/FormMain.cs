using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartViewer
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void tabPanelMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabPanelMain.SelectedIndex == 1)
            {
                ucCustomerAffiliation.UpdateContent();
            }
        }

        private void ucCustomerWorks_Load(object sender, EventArgs e)
        {

        }
    }
}
