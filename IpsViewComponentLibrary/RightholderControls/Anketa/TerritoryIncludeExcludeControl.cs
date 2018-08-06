using IpsViewComponentLibrary.Utilities;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using ipsFormsDesign.Data;

namespace IpsViewComponentLibrary.RightholderControls.Anketa
{
    public partial class TerritoryIncludeExcludeControl : UserControl
    {
        protected bool IsDesignMode
        {
            get { return DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime; }
        }

        [Category("Data")]
        [AttributeProvider(typeof(IListSource))]
        public object DataSource
        {
            get => rightHolderBindingSource.DataSource;
            set
            {
                if (rightHolderBindingSource.DataSource != value)
                {
                    rightHolderBindingSource.DataSource = value;
                }
            }
        }

        public TerritoryIncludeExcludeControl()
        {
            InitializeComponent();

            if (!IsDesignMode)
            {
                gvCountries.SetComboboxColumnDataSource("CountryCode", IpsGlobal.AnketaDictionaties.country, "CountryCode", "CountryName");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            gvCountries.Rows.AddNew();

            var currentCell = gvCountries.CurrentRow.Cells[0];
            currentCell.IsSelected = true;
            currentCell.BeginEdit();
            var dropDownEditor = gvCountries.ActiveEditor as RadDropDownListEditor;
            if (dropDownEditor != null)
            {
                var element = dropDownEditor.EditorElement as RadDropDownListEditorElement;
                element.ShowPopup();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            gvCountries.Rows.Remove(gvCountries.CurrentRow);
        }

        private void checkAroundWorld_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            SetIncludeExcludeLabelText(checkAroundWorld.Checked);

            SetIncludeExcludeBinding(checkAroundWorld.Checked);
        }

        private void SetIncludeExcludeLabelText(bool aroundWorld)
        {
            if (aroundWorld)
            {
                lblIncludeExclude.Text = "Обмежується на території";
            }
            else
            {
                lblIncludeExclude.Text = "Розповсюджується на території";
            }
        }

        private void SetIncludeExcludeBinding(bool aroundWorld)
        {
            if (aroundWorld)
            {
                gvCountries.DataSource = rightHolderBindingSource;
                gvCountries.DataMember = "TerritoryExclude";
            }
            else
            {
                gvCountries.DataSource = rightHolderBindingSource;
                gvCountries.DataMember = "TerritoryInclude";
            }
        }
    }
}
