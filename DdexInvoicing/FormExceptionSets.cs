using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DdexInvoicing
{
    public partial class FormExceptionSets : Form
    {
        public int setCode;

        public FormExceptionSets()
        {
            InitializeComponent();
        }

        private void FormExceptionSets_Load(object sender, EventArgs e)
        {
            ucExceptionSets.Init(UcExceptionSets.Mode.Assign);
        }

        private void radBtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void radBtnOk_Click(object sender, EventArgs e)
        {
            setCode = ucExceptionSets.GetSetCode();
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
