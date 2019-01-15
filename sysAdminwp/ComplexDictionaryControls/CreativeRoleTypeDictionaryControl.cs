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
    public partial class CreativeRoleTypeDictionaryControl : UserControl
    {
        public CreativeRoleTypeDictionaryControl(CreativeRoleType creativeRole, List<Category> listCreativeRole, List<CopyrightType> copyrightTypes)
        {
            InitializeComponent();
            bsCreativeRoleType.DataSource = creativeRole;
            bsCategory.DataSource = listCreativeRole;
            bsCopyrightType.DataSource = copyrightTypes;
        }
    }
}
