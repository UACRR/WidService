using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Model;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.Shared.Controls
{
    [ComplexBindingProperties("DataSource")]
    public partial class IpsAnketaCompanyControl : UserControl
    {
        private Func<string, IList<AutoCompleteData>> getAutoCompList;
        private Func<int, Customer> getCustomerAnketa;

        public event EventHandler<string> TextNameChanged;

        public IpsAnketaCompanyControl()
        {
            InitializeComponent();
        }

        public void SetLabelName(string fullName)
        {
            lblFullName.Text = fullName;
        }

        [Category("Data")]
        [AttributeProvider(typeof(IListSource))]
        public object DataSource
        {
            get => anketaCompanyBindingSource.DataSource;
            set
            {
                if (anketaCompanyBindingSource.DataSource != value)
                    anketaCompanyBindingSource.DataSource = value;
            }
        }

        #region Activity code dictionary

        /// <summary>
        /// Перевірка на правильність введених полів
        /// </summary>
        /// <returns></returns>
        public bool Validator()
        {
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                lblFullName.ForeColor = Color.FromArgb(180, 255, 0, 2);
                isValid = false;
            }
            else
                lblFullName.ForeColor = Color.Black;

            return isValid;
        }

        internal void SetAutoComplete(Func<string, IList<AutoCompleteData>> _getAutoCompList, Func<int, Customer> _getCustomerAnketa)
        {
            getAutoCompList = _getAutoCompList;
            getCustomerAnketa = _getCustomerAnketa;
            txtName.ListItemSelected += TxtName_ListItemSelected;
            txtName.TextChanged += TxtName_TextChanged;
            txtName.AutoCompleteMode = AutoCompleteMode.Suggest;
        }

        bool inProcess = false;
        private void TxtName_ListItemSelected(object sender, RadListDataItem e)
        {
            inProcess = true;
            RadListDataItem curItem = e;
            var getCustomer = getCustomerAnketa((int)curItem.Value);
            txtName.Text = (DataSource as AnketaCompany).Name;
            //var anketa = getCustomer.Company.AnketaCompany.Where(rec => rec.Version == getCustomer.AnkVersion).Single();
            //DataSource = anketa;
            inProcess = false;
        }

        string _savedSearch = string.Empty;
        private void TxtName_TextChanged(object sender, EventArgs e)
        {
            if (inProcess || getAutoCompList == null || getCustomerAnketa == null)
                return;
            // Якщо анкета існуючого клієнту
            if (anketaCompanyBindingSource.DataSource is AnketaCompany @company && @company.CustId != 0)
                return;

            string txtName_Text = txtName.Text.Trim();
            if (txtName_Text.Length > 0)
            {
                if (_savedSearch.Length == 0 || !txtName_Text.ToUpper().StartsWith( _savedSearch.ToUpper()))
                {
                    inProcess = true;
                    var _cacheSearch = txtName.Text.Trim();
                    _savedSearch = _cacheSearch;
                    if (!char.IsLetterOrDigit(_cacheSearch[0]))
                    {
                        _cacheSearch = string.Concat("%", _cacheSearch);
                    }

                    var list = getAutoCompList(_cacheSearch).Select(rec => new RadListDataItem(rec.DisplayValue, rec.Value)).ToArray();
                    var tmpText = txtName.Text;
                    //txtName.Clear();

                    txtName.AutoCompleteItems.Clear();
                    txtName.AutoCompleteItems.AddRange(list);
                    // txtName.AutoCompleteDataSource = list;
                    txtName.Text = tmpText;
                    inProcess = false;
                }
            }
        }

        private void TxtName_Leave(object sender, EventArgs e)
        {
            TextNameChanged?.Invoke(sender, txtName.Text);
        }

        #endregion
    }
}
