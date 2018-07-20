using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Model;
using Telerik.WinControls.UI;
using ipsFormsDesign.Data;
using IpsViewComponentLibrary.Utilities;

namespace IpsViewComponentLibrary.ObjectRightControls
{
    public partial class AuthorRightholderBrListControl : UserControl
    {
        protected bool IsDesignMode
        {
            get { return DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime; }
        }

        public object DataSource
        {
            get { return objectAuthorRightholderBrViewModelBindingSource.DataSource; }
            set
            {
                if (objectAuthorRightholderBrViewModelBindingSource.DataSource != value)
                {
                    objectAuthorRightholderBrViewModelBindingSource.DataSource = value;
                }
            }
        }

        public AuthorRightholderBrListControl()
        {
            InitializeComponent();

            if (!IsDesignMode)
            {
                SetDictionaries();
            }
        }

        private void SetDictionaries()
        {
            gvAuthorRightholderList.SetComboboxColumnDataSource("RoleCode", IpsGlobal.ObjectRightDictionaries.creativeRoleType);
            gvAuthorRightholderList.SetComboboxColumnDataSource("PrepayType", IpsGlobal.AnketaDictionaties.PrePayType);
            gvAuthorRightholderList.SetComboboxColumnDataSource("Currency", IpsGlobal.AnketaDictionaties.klR030, "r030", "a3");
            gvAuthorRightholderList.SetComboboxColumnDataSource("WorkTypeRh", IpsGlobal.AnketaDictionaties.workType);
            gvAuthorRightholderList.SetComboboxColumnDataSource("WorkTypeCl", IpsGlobal.AnketaDictionaties.workType);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var newItem = new ObjectAuthorRightholderBrViewModel();
            objectAuthorRightholderBrViewModelBindingSource.Add(newItem);
            gvAuthorRightholderList.CurrentRow.Cells[0].BeginEdit();
        }

        private void gvObjectsRightsList_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            var currentColumnName = e.Column.Name;

            if (currentColumnName == "DeleteColumn")
            {
                gvAuthorRightholderList.Rows.Remove(gvAuthorRightholderList.CurrentRow);
            }
        }
    }
}
