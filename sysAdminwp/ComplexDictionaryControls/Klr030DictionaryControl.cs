using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Model;
using ipsFormsDesign.Dictionary;

namespace sysAdminwp.ComplexDictionaryControls
{
    public sealed partial class Klr030DictionaryControl : UserControl
    {
        public event EventHandler HideElem;

        public Klr030DictionaryControl(List<DictBaseTypeI> countryList, List<DictBaseTypeI> klr031List)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            bsCountry.DataSource = countryList;
            bsKlr031.DataSource = klr031List;
        }
        public object KlR030CountryDataSource
        {
            get => bsCountry.DataSource;
            set => bsCountry.DataSource = value;
        }

        public object KlR031DataSource
        {
            get => bsKlr031.DataSource;
            set => bsKlr031.DataSource = value;
        }
        public object KlR030DataSource
        {
            get => bsKlr.DataSource;
            set => bsKlr.DataSource = value;
        }

        private void ddlCountry_Click(object sender, EventArgs e)
        {
            HideElem?.Invoke(sender, e);
        }

        private void ddlKlr031_Click(object sender, EventArgs e)
        {
            HideElem?.Invoke(sender, e);
        }
    }
}
