using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Dictionary;

namespace sysAdminwp.ComplexDictionaryControls
{
    public partial class TaxRateDictionaryControl : UserControl
    {
        public TaxRateDictionaryControl(List<DictBaseTypeI> taxRate)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            bsTaxRate.DataSource = taxRate;
        }
    }
}
