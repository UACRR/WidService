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
        public event EventHandler HideElem;
        public TypePlaceDictionaryControl(List<DictBaseTypeI> typePlace, List<DictBaseTypeI> typePlaceParam)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            bsTypePlaceList.DataSource = typePlace;
            bsTypePlaceParam.DataSource = typePlaceParam;
        }
        public object TypePlaceSource
        {
            get => bsTypePlaceList.DataSource;
            set => bsTypePlaceList.DataSource = value;
        }
        public object TypePlaceParamSource
        {
            get => bsTypePlaceParam.DataSource;
            set => bsTypePlaceParam.DataSource = value;
        }

        private void ddlTypePlace_Click(object sender, EventArgs e)
        {
            HideElem?.Invoke(sender, e);
        }

        private void radCheckBox1_Click(object sender, EventArgs e)
        {
            HideElem?.Invoke(sender, e);
        }
    }
}
