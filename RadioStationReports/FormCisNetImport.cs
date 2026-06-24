using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RadioStationReports
{
    public partial class FormCisNetImport : Form
    {
        public int ObjId { get; set; }

        public FormCisNetImport()
        {
            InitializeComponent();
        }

        private void btnGetWork_Click(object sender, EventArgs e)
        {
            ucCisNetImport.GetWork();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            ObjId = ucCisNetImport.ApplyWork();
            if( ObjId != 0)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
