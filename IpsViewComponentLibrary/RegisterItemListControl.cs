using System;
using System.Linq;
using System.Windows.Forms;
using IpsViewComponentLibrary.Utilities;
using ipsFormsDesign.Model;
using Telerik.WinControls.UI;
using Telerik.WinControls.Data;

namespace IpsViewComponentLibrary
{
    public partial class RegisterItemListControl : UserControl
    {
        public object DataSource
        {
            get { return gvRegisterItemList.DataSource; }
            set
            {
                if (gvRegisterItemList.DataSource != value)
                {
                    gvRegisterItemList.DataSource = value;
                }
            }
        }

        private RegisterItem _registerItem;
        public  RegisterItem SelectedRegisterItem
        {
            get
            {
                if (gvRegisterItemList.CurrentRow == null)
                    return null;

                return gvRegisterItemList.CurrentRow.DataBoundItem as RegisterItem;
            }
            set
            {
                if (_registerItem != value)
                {
                    _registerItem = value;

                    if (_registerItem != null)
                    {
                        var row = gvRegisterItemList.Rows.FirstOrDefault(r => (int)r.Cells["RegIitemId"].Value == _registerItem.RegIitemId);
                        if (row != null)
                        {
                            gvRegisterItemList.CurrentRow = row;
                        }
                    }
                }
            }
        }

        public event EventHandler<RegisterItem> FindCommandExecuted;
        public event EventHandler<RegisterItem> LinkCommandExecuted;

        public RegisterItemListControl()
        {
            InitializeComponent();

            ddlLinkedStatus.SelectedIndex = 0;
        }

        private void gvRegisterItemList_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            var currentColumnName = e.Column.Name;

            if (currentColumnName == "FindColumn")
            {
                OnFindCommandExecuted(SelectedRegisterItem);
            }
            else if (currentColumnName == "LinkColumn")
            {
                OnLinkCommandExecuted(SelectedRegisterItem);
            }
        }

        private void gvRegisterItemList_ToolTipTextNeeded(object sender, Telerik.WinControls.ToolTipTextNeededEventArgs e)
        {
            GridViewTooltipHelper.SetTooltipTextForColumnHeader(sender, e);
        }

        private void ddlLinkedStatus_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            SetFilter(ddlLinkedStatus.SelectedIndex);
        }

        private void SetFilter(int linkedStatus)
        {
            gvRegisterItemList.FilterDescriptors.Clear();

            if (linkedStatus != 0)
            {
                FilterDescriptor filterByObjId = new FilterDescriptor();
                filterByObjId.PropertyName = "ObjId";
                filterByObjId.Operator = linkedStatus == 1 ? FilterOperator.IsNotEqualTo : FilterOperator.IsEqualTo;
                filterByObjId.Value = null;
                filterByObjId.IsFilterEditor = true;
                gvRegisterItemList.FilterDescriptors.Add(filterByObjId);
            }
        }

        private void OnFindCommandExecuted(RegisterItem selectedRegisterItem)
        {
            FindCommandExecuted?.Invoke(this, selectedRegisterItem);
        }

        private void OnLinkCommandExecuted(RegisterItem selectedRegisterItem)
        {
            LinkCommandExecuted?.Invoke(this, selectedRegisterItem);
        }
    }
}
