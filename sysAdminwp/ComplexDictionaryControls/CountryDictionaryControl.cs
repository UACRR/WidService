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
    public partial class CountryDictionaryControl : UserControl
    {
        public CountryDictionaryControl(Country country, List<DictBaseTypeI> continent)
        {
            InitializeComponent();
            bsContinent.DataSource = continent;
            bsCountry.DataSource = country;
        }
    }
}
