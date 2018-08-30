using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Model;
using Telerik.WinControls;

namespace IpsViewComponentLibrary.ConsumerForms
{
    public partial class CabinetBigRightForm : Telerik.WinControls.UI.RadForm
    {
        public CabinetBigRightForm()
        {
            InitializeComponent();
            cabinet.SetDictionaries(IpsGlobal.AnketaDictionaties);
        }

        private void CabinetBigRightForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
