using ipsFormsDesign.Data;
using ipsFormsDesign.Model;
using sysAdminwp.ComplexDictionaryControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace sysAdminwp
{
    public partial class ComplexDictionaryParamForm : Telerik.WinControls.UI.RadForm
    {
        CountryDictionaryControl countryDictionaryControl;

        /// <summary>
        /// Country
        /// </summary>
        /// <param name="country"></param>
        /// <param name="continent"></param>
        public ComplexDictionaryParamForm(Country country, List<Continent> continent)
        {
            InitializeComponent();
            countryDictionaryControl = new CountryDictionaryControl(country, continent)
            {
                Dock = DockStyle.Fill,
            };
            mainPanel.Controls.Add(countryDictionaryControl);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
