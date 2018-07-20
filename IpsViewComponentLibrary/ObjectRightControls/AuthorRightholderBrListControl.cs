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
            var column = gvObjectsRightsList.Columns["RoleCode"] as GridViewComboBoxColumn;
            column.ValueMember = "CodeI";
            column.DisplayMember = "Name";
            column.DataSource = IpsGlobal.ObjectRightDictionaries.creativeRoleType;

            column = gvObjectsRightsList.Columns["PrepayType"] as GridViewComboBoxColumn;
            column.ValueMember = "CodeI";
            column.DisplayMember = "Name";
            column.DataSource = IpsGlobal.AnketaDictionaties.PrePayType;

            column = gvObjectsRightsList.Columns["Currency"] as GridViewComboBoxColumn;
            column.ValueMember = "r030";
            column.DisplayMember = "a3";
            column.DataSource = IpsGlobal.AnketaDictionaties.klR030;

            column = gvObjectsRightsList.Columns["WorkTypeRh"] as GridViewComboBoxColumn;
            column.ValueMember = "CodeI";
            column.DisplayMember = "Name";
            column.DataSource = IpsGlobal.AnketaDictionaties.workType;

            column = gvObjectsRightsList.Columns["WorkTypeCl"] as GridViewComboBoxColumn;
            column.ValueMember = "CodeI";
            column.DisplayMember = "Name";
            column.DataSource = IpsGlobal.AnketaDictionaties.workType;
        }
    }
}
