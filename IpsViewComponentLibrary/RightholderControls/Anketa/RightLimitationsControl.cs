using IpsViewComponentLibrary.Utilities;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using Telerik.WinControls.Data;
using ipsFormsDesign.Data;

namespace IpsViewComponentLibrary.RightholderControls.Anketa
{
    [ComplexBindingProperties("DataSource")]
    public partial class RightLimitationsControl : UserControl
    {
        protected bool IsDesignMode => DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime;

        public RightLimitationsControl()
        {
            InitializeComponent();

            if (!IsDesignMode)
            {
                var groupDescriptor = new GroupDescriptor();
                groupDescriptor.GroupNames.Add("GroupCode", ListSortDirection.Ascending);
                groupDescriptor.GroupNames.Add("GroupName", ListSortDirection.Ascending);
                groupDescriptor.Format = "{1}";
                gvRightLimitations.GroupDescriptors.Add(groupDescriptor);

                gvRightLimitations.SetComboboxColumnDataSource("CommunityCustId", IpsGlobal.AnketaDictionaties.communities, "CustId", "Name");
            }
        }

        public bool IsExternalRightHolder
        {
            get => !gvRightLimitations.Columns["OurService"].IsVisible;
            set => gvRightLimitations.Columns["OurService"].IsVisible = !value;
        }

        [Category("Data")]
        [AttributeProvider(typeof(IListSource))]
        public object DataSource
        {
            get => bsTermsOfServiceWrapper.DataSource;
            set
            {
                if (bsTermsOfServiceWrapper.DataSource != value)
                    bsTermsOfServiceWrapper.DataSource = value;
            }
        }

        private void gvRightLimitations_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.Column.FieldName == "DateEnd")
            {
                if (e.CellElement.Text == DateTime.MinValue.ToShortDateString())
                    e.CellElement.Text = "";

                if (e.CellElement.Text == (new DateTime(3000, 1, 1)).ToShortDateString())
                    e.CellElement.Text = "Не обмежено";
            }
        }

        private void gvRightLimitations_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            if (e.Column.FieldName == "OurService")
            {
                SetRowParams(e.Row);
            }
        }

        private void gvRightLimitations_DataBindingComplete(object sender, GridViewBindingCompleteEventArgs e)
        {
            foreach (var row in gvRightLimitations.Rows)
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
            else
            {
                row.Cells["DateEnd"].Value = new DateTime(3000,1,1);
            }
        }
    }
}
