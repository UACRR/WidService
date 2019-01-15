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

namespace sysAdminwp.ComplexDictionaryControls
{
    public partial class Klr030DictionaryControl : UserControl
    {
        public Klr030DictionaryControl(KlR030 klr, List<Country> listKlR030)
        {
            InitializeComponent();
            bsKlr.DataSource = klr;
            bsCountry.DataSource = listKlR030;
        }
    }
}
