using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace RightholderWorkplace
{
    public partial class RightholderSelectionView : Telerik.WinControls.UI.RadForm
    {
        public event EventHandler<RightholderMainView> RightholderSelected;

        public RightholderSelectionView()
        {
            InitializeComponent();
        }

        private void RightholderSelectionView_Load(object sender, EventArgs e)
        {
            var service = new RightholderService();
            var list = service.GetMainView();
            rightholderMainViewBindingSource.DataSource = list;
            //btnOk.Focus();

            //GridSearchCellElement searchCell = gvRightholdersList.TableElement.GetCellElement(gvRightholdersList.MasterView.TableSearchRow, null) as GridSearchCellElement;
            //if (searchCell != null)
            //{
            //    searchCell.SearchTextBox.Focus();
            //}

            //searchCell.SearchTextBox.Focus();
            //searchCell.SearchTextBox.Text = "1";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            SelectAndClose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void gvRightholdersList_DoubleClick(object sender, EventArgs e)
        {
            SelectAndClose();
        }

        private void OnRightholderSelected(RightholderMainView item)
        {
            RightholderSelected?.Invoke(this, item);
        }

        private void SelectAndClose()
        {
            var item = gvRightholdersList.CurrentRow.DataBoundItem as RightholderMainView;

            OnRightholderSelected(item);

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
