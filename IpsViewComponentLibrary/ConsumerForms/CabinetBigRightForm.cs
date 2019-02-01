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
        private const string DefaultTitle = "Кабінет користувача";
        public CabinetBigRightForm()
        {
            InitializeComponent();
            cabinet.SetDictionaries(IpsGlobal.AnketaDictionaties);
        }

        public string Title
        {
            get => Text;
            set => Text = value.Length == 0 ? DefaultTitle : string.Concat(DefaultTitle, $": {value}");
        }

        public bool IsInit { get; set; } = false;

        private void CabinetBigRightForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
