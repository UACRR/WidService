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
    public sealed partial class CreativeRoleTypeDictionaryControl : UserControl
    {
        public event EventHandler HideElem;

        public CreativeRoleTypeDictionaryControl(List<DictBaseTypeI> listCategory, List<DictBaseTypeI> listCopyrightType)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            bsCategory.DataSource = listCategory;
            bsCopyrightType.DataSource = listCopyrightType;
        }

        public object CreativeRoleTypeDataSource
        {
            get => bsCreativeRoleType.DataSource;
            set => bsCreativeRoleType.DataSource = value;
        }

        private void ddlCategory_Click(object sender, EventArgs e)
        {
            HideElem?.Invoke(sender, e);
        }

        private void ddlCopyright_Click(object sender, EventArgs e)
        {
            HideElem?.Invoke(sender, e);
        }
    }
}
