using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ipsFormsDesign;
using ipsFormsDesign.Data;
using ipsFormsDesign.Model;
using Telerik.WinControls;

namespace IpsViewComponentLibrary
{
    public partial class AddFileDialogForm : Telerik.WinControls.UI.RadForm
    {
        public string FileName => txtFileName.Text;
        public string Comment => txtComment.Text;
        public int DocumentType => Convert.ToInt32(ddlDocType.SelectedItem.Value);

        public AddFileDialogForm()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.None;
            fileTypeBindingSource.DataSource = IpsGlobal.AnketaDictionaties.fileType;
            var val = ddlDocType.SelectedValue;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void btnOpenFileDialog_Click(object sender, EventArgs e)
        {
            FileDialog fileDialog = new OpenFileDialog();
            
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFileName.Text = fileDialog.FileName;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
