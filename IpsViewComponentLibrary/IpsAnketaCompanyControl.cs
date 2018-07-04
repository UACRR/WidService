using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Model;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary
{
    [ComplexBindingProperties("DataSource", "DataMember")]
    public partial class IpsAnketaCompanyControl : UserControl
    {
        private Func<string, IList<AutoCompleteData>> getAutoCompList;
        private Func<int, Customer> getCustomerAnketa;

        public IpsAnketaCompanyControl()
        {
            InitializeComponent();
        }

        [Category("Data")]
        [AttributeProvider(typeof(IListSource))]
        public object DataSource
        {
            get { return anketaCompanyBindingSource.DataSource; }
            set
            {
                if (anketaCompanyBindingSource.DataSource != value)
                    anketaCompanyBindingSource.DataSource = value;
            }
        }

        [Category("Data")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
        public string DataMember
        {
            get { return anketaCompanyBindingSource.DataMember; }
            set { anketaCompanyBindingSource.DataMember = value; }
        }

        #region Activity code dictionary

        public string CompanyFullName => txtName.Text;

        /// <summary>
        /// Перевірка на правильність введених полів
        /// </summary>
        /// <returns></returns>
        public bool Validator()
        {
            bool isValid = true;

            if (txtName.Text == string.Empty)
            {
                radLabel1.ForeColor = Color.FromArgb(180, 255, 0, 2);
                isValid = false;
            }
            else
                radLabel1.ForeColor = Color.Black;


            return isValid;
        }

        public void ClearData()
        {
            txtName.Clear();
            txtShortName.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_getAutoCompList"></param>
        /// <param name="_getCustomerAnketa"></param>
        internal void SetAutoComplete(Func<string, IList<AutoCompleteData>> _getAutoCompList, Func<int, Customer> _getCustomerAnketa)
        {
            getAutoCompList = _getAutoCompList;
            getCustomerAnketa = _getCustomerAnketa;
            txtName.ListItemSelected += TxtName_ListItemSelected;
            txtName.TextChanged += TxtName_TextChanged;
        }

        private void TxtName_ListItemSelected(object sender, Telerik.WinControls.UI.RadListDataItem e)
        {
            var getCustomer = getCustomerAnketa((int)e.Value);
            //var anketa = getCustomer.Company.AnketaCompany.Where(rec => rec.Version == getCustomer.AnkVersion).Single();
            //DataSource = anketa;
        }

        string _cacheSearch = string.Empty;
        private void TxtName_TextChanged(object sender, EventArgs e)
        {
            if (getAutoCompList == null || getCustomerAnketa == null)
                return;
            // Якщо анкета існуючого клієнту
            if (anketaCompanyBindingSource.DataSource is AnketaCompany @company && @company.CustId != 0)
                return;
            if( txtName.Text.Length > 0 )
            {
                if(_cacheSearch.Length == 0
                    || !_cacheSearch.StartsWith(txtName.Text.Substring(0,1))
                    || _cacheSearch.Length > txtName.Text.Length + 2 // видалення з пошуку по 2 символи
                    || _cacheSearch.Length + 2 < txtName.Text.Length
                    )
                {
                    _cacheSearch = txtName.Text;
                    var list = getAutoCompList(_cacheSearch).Select(rec=>new RadListDataItem(rec.DisplayValue, rec.Value));
                    txtName.AutoCompleteDataSource = list;
                }
            }
        }


        #endregion
    }
}
