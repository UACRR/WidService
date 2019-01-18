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
        public CreativeRoleTypeDictionaryControl(CreativeRoleType creativeRole, List<DictBaseTypeI> listCreativeRole, List<DictBaseTypeI> copyrightTypes)
        {
            InitializeComponent();
            bsCreativeRoleType.DataSource = creativeRole;
            bsCategory.DataSource = listCreativeRole;
            bsCopyrightType.DataSource = copyrightTypes;
        }

        public CreativeRoleTypeDictionaryControl(List<DictBaseTypeI> listCreativeRole, List<DictBaseTypeI> copyrightTypes)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            bsCategory.DataSource = listCreativeRole;
            bsCopyrightType.DataSource = copyrightTypes;
        }

        public object CreativeRoleTypeDataSource
        {
            get => bsCreativeRoleType.DataSource;
            set => bsCreativeRoleType.DataSource = value;
        }
    }
}
