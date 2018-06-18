using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
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

namespace IpsViewComponentLibrary
{
    public partial class AuthorRightholderItemView : Telerik.WinControls.UI.RadForm
    {
        private readonly ObjectRightDictionaries _dictionaries;
        //public event EventHandler<RightholderMainView> RightholderSelected;

        public AuthorRightholderItemView(BindingSource bindingSource, ObjectRightDictionaries dictionaries)
        {
            InitializeComponent();

            pvParameters.ViewElement.Visibility = ElementVisibility.Hidden;

            rdbProtected.IsChecked = true;
            pvParameters.SelectedPage = pvpProtected;
            mtxtRate_ValueChanged(this, EventArgs.Empty);

            authorsBindingSource = bindingSource;

            _dictionaries = dictionaries;
            SetDictionaries(_dictionaries);
        }

        private void SetDictionaries(ObjectRightDictionaries dictionaries)
        {
            ddlRoleCode.DataSource = dictionaries.creativeRoleType;
            ddlRoleCode.ValueMember = "CodeI";
            ddlRoleCode.DisplayMember = "Name";

            //ddlAuthorState.DataSource = new List<DictBaseTypeI>
            //{
            //    new DictBaseTypeI { CodeI = 0, Name = "Підтверджений" },
            //    new DictBaseTypeI { CodeI = 1, Name = "Народний" },
            //    new DictBaseTypeI { CodeI = 2, Name = "Невідомий" },
            //};
            //ddlAuthorState.ValueMember = "CodeI";
            //ddlAuthorState.DisplayMember = "Name";
        }

        private void btnOk_Save(object sender, EventArgs e)
        {
            SaveAndClose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            authorsBindingSource.ResetBindings(false);
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void gvRightholdersList_DoubleClick(object sender, EventArgs e)
        {
            SaveAndClose();
        }

        //private void OnRightholderSelected(RightholderMainView item)
        //{
        //    RightholderSelected?.Invoke(this, item);
        //}

        private void SaveAndClose()
        {
            //var item = gvRightholdersList.CurrentRow.DataBoundItem as RightholderMainView;

            //OnRightholderSelected(item);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void ddlRightholder_PopupOpening(object sender, CancelEventArgs e)
        {
            e.Cancel = true;

            using (var selectionView = new RightholderSelectionView())
            {
                selectionView.RightholderSelected += SelectionView_RightholderSelected;
                selectionView.ShowDialog();
            }
        }

        private void SelectionView_RightholderSelected(object sender, RightholderMainView selectedRightholder)
        {
            //var currentAuthor = authorsBindingSource.Current as Authors;
            //currentAuthor.AuthorName = item.Name;
            //currentAuthor.CustId = item.CustId;
            //currentAuthor.IsFolkOrUnknown = null;

            //authorsBindingSource.ResetBindings(false);

            ddlRightholder.Text = selectedRightholder.Name;
        }

        private void rdbProtected_CheckStateChanged(object sender, EventArgs e)
        {
            if (rdbProtected.IsChecked == true)
                pvParameters.SelectedPage = pvpProtected;
            else if (rdbNotProtected.IsChecked == true)
                pvParameters.SelectedPage = pvpNotProtected;
            else if (rdbFolk.IsChecked == true)
                pvParameters.SelectedPage = pvpFolk;
        }

        private void mtxtRate_ValueChanged(object sender, EventArgs e)
        {
            if (mtxtRate.Text == "0")
            {
                lblAuthorRightholder.Text = "Автор:";
                txtCommunity.Visible = false;
                dtBeginDate.Visible = false;
                dtEndDate.Visible = false;
            }
            else
            {
                lblAuthorRightholder.Text = "Правовласник:";
                txtCommunity.Visible = true;
                dtBeginDate.Visible = true;
                dtEndDate.Visible = true;

            }

        }
    }
}
