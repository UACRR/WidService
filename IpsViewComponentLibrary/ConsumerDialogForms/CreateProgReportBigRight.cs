using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace IpsViewComponentLibrary.ConsumerDialogForms
{
    public partial class CreateProgReportBigRight : Telerik.WinControls.UI.RadForm
    {
        public CreateProgReportBigRight()
        {
            InitializeComponent();
        }

        private void btnAddCreativeRole_Click(object sender, EventArgs e)
        {

        }

        private void btnAddRegItem_Click(object sender, EventArgs e)
        {
            AddAuthRoleForMusDesingBr addAuthRole = new AddAuthRoleForMusDesingBr();
            if (addAuthRole.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
