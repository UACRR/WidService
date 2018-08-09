using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ipsFormsDesign.Model;
using Telerik.WinControls;

namespace IpsViewComponentLibrary.ConsumerDialogForms
{
    public partial class AddAuthRoleForMusDesingBr : Telerik.WinControls.UI.RadForm
    {
        public AddAuthRoleForMusDesingBr()
        {
            InitializeComponent();
        }
        public AddAuthRoleForMusDesingBr(RegisterItem registerItem)
        {
            InitializeComponent();
        }

        private void gvAuthRole_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
