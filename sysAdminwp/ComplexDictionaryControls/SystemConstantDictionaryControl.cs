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
    public partial class SystemConstantDictionaryControl : UserControl
    {
        public SystemConstantDictionaryControl(List<DictBaseTypeI> systemConstant)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            bsSystemConstant.DataSource = systemConstant;
        }
        public object SystemConstantSource
        {
            get => bsSystemConstant.DataSource;
            set => bsSystemConstant.DataSource = value;
        }
    }
}
