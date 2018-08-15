using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ipsFormsDesign.Model;
using Telerik.WinControls;

namespace IpsViewComponentLibrary
{
    public partial class AddCompositionForm : Telerik.WinControls.UI.RadForm
    {
        public AddCompositionForm()
        {
            InitializeComponent();
        }

        public AddCompositionForm(MusicalDesign musicalDesign)
        {
            InitializeComponent();
            DialogResult = DialogResult.None;
            bsMusicDesign.DataSource = musicalDesign;
        }
       

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
