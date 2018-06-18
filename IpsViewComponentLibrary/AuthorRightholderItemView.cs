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

        public AuthorRightholderItemView(ObjectAuthorRightholder authorRightholder, ObjectRightDictionaries dictionaries)
        {
            InitializeComponent();

            pvParameters.ViewElement.Visibility = ElementVisibility.Hidden;

            rdbAuthorRightholder.IsChecked = true;
            pvParameters.SelectedPage = pvpAuthorRightholder;

            _dictionaries = dictionaries;
            SetDictionaries(_dictionaries);

            objectAuthorRightholderBindingSource.DataSource = authorRightholder;
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
            //var item = gvRightholdersList.CurrentRow.DataBoundItem as RightholderMainView;
            //OnRightholderSelected(item);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //authorsBindingSource.ResetBindings(false);
            DialogResult = DialogResult.Cancel;
            Close();
        }

        //private void OnRightholderSelected(RightholderMainView item)
        //{
        //    RightholderSelected?.Invoke(this, item);
        //}

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
            if (rdbAuthorRightholder.IsChecked == true)
                pvParameters.SelectedPage = pvpAuthorRightholder;
            else if (rdbNotProtected.IsChecked == true)
                pvParameters.SelectedPage = pvpNotProtected;
            else if (rdbFolk.IsChecked == true)
                pvParameters.SelectedPage = pvpFolk;
        }

        private void checkIsRightholder_ToggleStateChanged(object sender, StateChangedEventArgs args)
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
    }
}
