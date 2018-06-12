using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary
{
    public partial class TerritoryIncludeExcludeControl : UserControl
    {
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

        #region Country dictionary

        [Category("Dictionaries")]
        [AttributeProvider(typeof(IListSource))]
        public object CountriesDataSource
        {
            get { return countryBindingSource.DataSource; }
            set
            {
                if (countryBindingSource.DataSource != value)
                    countryBindingSource.DataSource = value;
            }
        }

        #endregion

        public TerritoryIncludeExcludeControl()
        {
            InitializeComponent();
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
