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
        public CountryDictionaryControl(Country country, List<DictBaseTypeI> continent, List<DictBaseTypeI> countryCode, List<DictBaseTypeI> countryName, List<DictBaseTypeI> kod_lit, List<DictBaseTypeI> shortChoice, List<DictBaseTypeI> orderBy)
        {
            InitializeComponent();
            bsContinent.DataSource = continent;
            bsCountry.DataSource = country;
            //bind for CountryCode
            bsCountryCode.DataSource = countryCode;
            //bind for CountryName
            bsCountryName.DataSource = countryName;
            //bind for kod_lit
            bsKodLit.DataSource = kod_lit;
            //bind for shortChoise
            bsShortChoice.DataSource = shortChoice;
            //bind for orderBy
            bsOrderBy.DataSource = orderBy;
        }

        public CountryDictionaryControl(List<DictBaseTypeI> continent, List<DictBaseTypeI> countryCode, List<DictBaseTypeI> countryName, List<DictBaseTypeI> kod_lit, List<DictBaseTypeI> shortChoice, List<DictBaseTypeI> orderBy)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            bsContinent.DataSource = continent;
            //bind for CountryCode
            bsCountryCode.DataSource = countryCode;
            //bind for CountryName
            bsCountryName.DataSource = countryName;
            //bind for kod_lit
            bsKodLit.DataSource = kod_lit;
            //bind for shortChoise
            bsShortChoice.DataSource = shortChoice;
            //bind for orderBy
            bsOrderBy.DataSource = orderBy;
        }

        public object CountryDataSource
        {
            get => bsCountry.DataSource;
            set => bsCountry.DataSource = value;
        }
    }
}
