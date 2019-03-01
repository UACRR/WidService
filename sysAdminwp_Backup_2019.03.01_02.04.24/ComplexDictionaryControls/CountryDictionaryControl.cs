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
    public sealed partial class CountryDictionaryControl : UserControl
    {
        public event EventHandler HideElem;

        public CountryDictionaryControl(List<DictBaseTypeI> continent)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            //data source for Continent
            bsContinent.DataSource = continent;
        }

        public object CountryDataSource
        {
            get => bsCountry.DataSource;
            set => bsCountry.DataSource = value;
        }

        private void ddlContinent_Click(object sender, EventArgs e)
        {
            HideElem?.Invoke(sender, e);
        }

        private void tbCountryCode_Click(object sender, EventArgs e)
        {
            HideElem?.Invoke(sender, e);
        }

        private void tbCountryName_Click(object sender, EventArgs e)
        {
            HideElem?.Invoke(sender, e);
        }

        private void tbKod_lit_Click(object sender, EventArgs e)
        {
            HideElem?.Invoke(sender, e);
        }

        private void tbShortChoice_Click(object sender, EventArgs e)
        {
            HideElem?.Invoke(sender, e);
        }

        private void tbOrderBy_Click(object sender, EventArgs e)
        {
            HideElem?.Invoke(sender, e);
        }
    }
}
