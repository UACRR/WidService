using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace IpsViewComponentLibrary
{
    public partial class AddFileDialogForm : Telerik.WinControls.UI.RadForm
    {
        public AddFileDialogForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnOpenFileDialog_Click(object sender, EventArgs e)
        {
            FileDialog fileDialog = new OpenFileDialog();
            
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFileName.Text = fileDialog.FileName;
            }
        }
    }
}
