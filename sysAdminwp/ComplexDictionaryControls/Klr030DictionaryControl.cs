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
        public Klr030DictionaryControl(KlR030 klr, List<DictBaseTypeI> listKlR030)
        {
            InitializeComponent();
            bsKlr.DataSource = klr;
            bsCountry.DataSource = listKlR030;
        }

        public Klr030DictionaryControl(List<DictBaseTypeI> countryList)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            bsCountry.DataSource = countryList;
        }

        public object KlR030DataSource
        {
            get => bsKlr.DataSource;
            set => bsKlr.DataSource = value;
        }
    }
}
