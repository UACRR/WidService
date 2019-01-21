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
    public partial class TypePlaceDictionaryControl : UserControl
    {
        public TypePlaceDictionaryControl(List<DictBaseTypeI> typePlace)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            bsTypePlace.DataSource = typePlace;
        }
        public object TypePlaceSource
        {
            get => bsTypePlace.DataSource;
            set => bsTypePlace.DataSource = value;
        }
    }
}
