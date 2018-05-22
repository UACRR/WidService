using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using Telerik.WinControls.Data;

namespace IpsViewComponentLibrary
{
    [ComplexBindingProperties("DataSource", "DataMember")]
    public partial class IpsExclusionsLimitationsControl : UserControl
    {
        public IpsExclusionsLimitationsControl()
        {
            InitializeComponent();
        }

        [Category("Data")]
        [AttributeProvider(typeof(IListSource))]
        public object DataSource
        {
            get { return termsOfServiceWrapperBindingSource.DataSource; }
            set
            {
                if (termsOfServiceWrapperBindingSource.DataSource != value)
                    termsOfServiceWrapperBindingSource.DataSource = value;
            }
        }

        [Category("Data")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
        public string DataMember
        {
            get { return termsOfServiceWrapperBindingSource.DataMember; }
            set { termsOfServiceWrapperBindingSource.DataMember = value; }
        }

        #region Community dictionary

        [Category("Dictionaries")]
        [AttributeProvider(typeof(IListSource))]
        public object CommunitiesDataSource
        {
            get { return communityInfoBindingSource.DataSource; }
            set
            {
                if (communityInfoBindingSource.DataSource != value)
                    communityInfoBindingSource.DataSource = value;
            }
        }

        [Category("Dictionaries")]
        public string CommunitiesDataMember
        {
            get { return communityInfoBindingSource.DataMember; }
            set { communityInfoBindingSource.DataMember = value; }
        }

        #endregion

        public RadGridView GridExclusionsLimitations
        {
            get
            {
                return gvExlusionsLimitations;
            }
        }

        private void IpsExclusionsLimitationsControl_Load(object sender, EventArgs e)
        {
            var groupDescriptor = new GroupDescriptor();
            groupDescriptor.GroupNames.Add("GroupCode", ListSortDirection.Ascending);
            groupDescriptor.GroupNames.Add("GroupName", ListSortDirection.Ascending);
            groupDescriptor.Format = "{1}";
            gvExlusionsLimitations.GroupDescriptors.Add(groupDescriptor);
        }

        private void gvExlusionsLimitations_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.Column.FieldName == "DateEnd" && e.CellElement.Text == DateTime.MinValue.ToShortDateString())
            {
                e.CellElement.Text = string.Empty;
            }
        }

        private void gvExlusionsLimitations_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            if (e.Column.FieldName == "OurService")
            {
                SetRowParams(e.Row);
            }
        }

        private void gvExlusionsLimitations_DataBindingComplete(object sender, GridViewBindingCompleteEventArgs e)
        {
            foreach (var row in gvExlusionsLimitations.Rows)
            {
                SetRowParams(row);
            }
        }

        private void SetRowParams(GridViewRowInfo row)
        {
            var value = (bool)row.Cells["OurService"].Value;

            row.Cells["CommunityCustId"].ReadOnly = value;
            row.Cells["DateEnd"].ReadOnly = value;

            if (value)
            {
                row.Cells["CommunityCustId"].Value = null;
                row.Cells["DateEnd"].Value = null;
            }
        }
    }
}
