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
using sysAdminwp.viewPageDictionaryControls;

namespace sysAdminwp.ComplexDictionaryControls
{
    public sealed partial class CopyRightKindDictionaryControl : UserControl, IComplexDictionary
    {
        public event EventHandler HideElements;

        public CopyRightKindDictionaryControl(List<DictBaseTypeI> list, List<DictBaseTypeI> listPortalSupportRights)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            //data source for CrkindGroup
            bsCrkindGroup.DataSource = list;
            //data source for PortalSupportRights
            bsPortalSupportRights.DataSource = listPortalSupportRights;
        }
        public object CopyrightKindDataSource
        {
            get => bsCopyrightKind.DataSource;
            set => bsCopyrightKind.DataSource = value;
        }
        public object CopyrightKindCrkindGroupDataSource
        {
            get => bsCrkindGroup.DataSource;
            set => bsCrkindGroup.DataSource = value;
        }
        public object CopyrightKindPortalSupportGroupDataSource
        {
            get => bsPortalSupportRights.DataSource;
            set => bsPortalSupportRights.DataSource = value;
        }

        public bool Validation()
        {
            bool isvalid = true;
            isvalid = ddlCrkindGroup.SelectedValue != null;

            return isvalid;
        }

        private void ddlCrkindGroup_Click(object sender, EventArgs e)
        {
            HideElements?.Invoke(sender, e);
        }
    }
}
