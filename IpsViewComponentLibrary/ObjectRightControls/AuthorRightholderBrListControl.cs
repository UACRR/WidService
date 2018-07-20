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
            gvObjectsRightsList.SetComboboxColumnDataSource("RoleCode", IpsGlobal.ObjectRightDictionaries.creativeRoleType);
            gvObjectsRightsList.SetComboboxColumnDataSource("PrepayType", IpsGlobal.AnketaDictionaties.PrePayType);
            gvObjectsRightsList.SetComboboxColumnDataSource("Currency", IpsGlobal.AnketaDictionaties.klR030, "r030", "a3");
            gvObjectsRightsList.SetComboboxColumnDataSource("WorkTypeRh", IpsGlobal.AnketaDictionaties.workType);
            gvObjectsRightsList.SetComboboxColumnDataSource("WorkTypeCl", IpsGlobal.AnketaDictionaties.workType);
        }
    }
}
