using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using IpsViewComponentLibrary.RightholderControls;
using IpsViewComponentLibrary.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.ObjectRightControls
{
    public partial class AuthorRightholderItemView : Telerik.WinControls.UI.RadForm
    {
        private readonly ObjectAuthorRightholder _authorRightholder;
        private readonly ObjectRightDictionaries _dictionaries;
        private readonly int _category;
        private readonly RightholderService _rightholderService;
        private readonly DialogService _dialogService;

        public AuthorRightholderItemView(ObjectAuthorRightholder authorRightholder, ObjectRightDictionaries dictionaries, int category)
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterParent;

            _rightholderService = new RightholderService();
            _dialogService = new DialogService();

            _authorRightholder = authorRightholder;
            _authorRightholder.BeginEdit();

            pvParameters.ViewElement.Visibility = ElementVisibility.Hidden;

            rpanelFolkType.SelectedValue = _authorRightholder.FolkType;

            _dictionaries = dictionaries;
            _category = category;
            SetDictionaries();

            objectAuthorRightholderBindingSource.DataSource = _authorRightholder;
        }

        private void SetDictionaries()
        {
            ddlRoleCode.DataSource = _dictionaries.creativeRoleType.Where(cr => cr.CategoryCode == _category && cr.Crtype == 1);
            ddlRoleCode.ValueMember = "CodeI";
            ddlRoleCode.DisplayMember = "Name";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                _dialogService.ShowError(this, "Не вірно введені дані. Об'єкт не записаний.");
                DialogResult = DialogResult.None;
                return;
            }

            _authorRightholder.EndEdit();

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _authorRightholder.CancelEdit();
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ddlRightholder_PopupOpening(object sender, CancelEventArgs e)
        {
            e.Cancel = true;

            using (var selectionView = new RightholderSelectionView())
            {
                if (_authorRightholder.CustId.HasValue)
                    selectionView.SelectedRightholder = new RightholderMainView { CustId = _authorRightholder.CustId.Value };
                else if (!string.IsNullOrEmpty(_authorRightholder.OldAuthorName))
                    selectionView.SearchText = _authorRightholder.OldAuthorName;

                selectionView.RightholderSelected += SelectionView_RightholderSelected;
                selectionView.ShowDialog();
            }
        }

        private void SelectionView_RightholderSelected(object sender, RightholderMainView selectedRightholder)
        {
            _authorRightholder.AuthorName = selectedRightholder.Name;

            if (_authorRightholder.IsRightholder)
            {
                _authorRightholder.CustId = selectedRightholder.CustId;
                _authorRightholder.CommunityName = selectedRightholder.Community_Name;
            }

            objectAuthorRightholderBindingSource.ResetBindings(false);
        }

        private void rpanelFolkType_SelectedValueChanged(object sender, EventArgs e)
        {
            _authorRightholder.FolkType = rpanelFolkType.SelectedValue;

            if (_authorRightholder.FolkType == 1)
                pvParameters.SelectedPage = pvpAuthorRightholder;
            else if (_authorRightholder.FolkType == 2)
                pvParameters.SelectedPage = pvpNotProtected;
            else if (_authorRightholder.FolkType == 3)
                pvParameters.SelectedPage = pvpFolk;
        }

        private void checkIsRightholder_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkIsRightholder.CheckState == CheckState.Checked)
            {
                lblAuthorRightholder.Text = "Правовласник:";
                ddlRightholder.Text = "";
                ddlRightholder.ReadOnly = true;
                panelRightholderInfo.Visible = true;
            }
            else
            {
                lblAuthorRightholder.Text = "Автор:";
                ddlRightholder.ReadOnly = false;
                panelRightholderInfo.Visible = false;
            }
        }

        #region Autocomplite

        private void GetAuthors(string filter)
        {
            var authors = _rightholderService.getAuthorsByFilter(filter).Select(a => a.AuthorName).ToArray();

            txtAuthorName.AutoCompleteCustomSource.AddRange(authors);
        }

        private void txtAuthorName_TextChanged(object sender, EventArgs e)
        {
            if (txtAuthorName.Text.Length >= 1 && txtAuthorName.AutoCompleteCustomSource.Count == 0)
            {
                GetAuthors(txtAuthorName.Text);
            }

            if (txtAuthorName.Text == string.Empty && txtAuthorName.AutoCompleteCustomSource.Count != 0)
            {
                txtAuthorName.AutoCompleteCustomSource.Clear();
            }
        }

        #endregion

        #region Validation

        private void ddlRoleCode_Validating(object sender, CancelEventArgs e)
        {
            if (ddlRoleCode.SelectedValue == null)
            {
                errorProvider.SetError(ddlRoleCode, "Оберіть творчу роль.");
                e.Cancel = true;
            }
            else
                errorProvider.SetError(ddlRoleCode, "");
        }

        private void mtxtRate_Validating(object sender, CancelEventArgs e)
        {
            var value = decimal.Parse(mtxtRate.Text);

            if (value > 100)
            {
                errorProvider.SetError(mtxtRate, "Відсоток володіння не може бути більше 100%.");
                e.Cancel = true;
            }
            else
                errorProvider.SetError(mtxtRate, "");
        }

        #endregion
    }
}
