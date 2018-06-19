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

namespace IpsViewComponentLibrary
{
    [ComplexBindingProperties("DataSource", "DataMember")]
    public partial class IpsAnketaCompanyControl : UserControl
    {
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

           //if (txtShortName.Text == string.Empty)
           //{
           //    radLabel2.ForeColor = Color.FromArgb(180, 255, 0, 2);
           //    isValid = false;
           //}
           //else
           //    radLabel2.ForeColor = Color.Black;

            return isValid;
        }

        public void ClearData()
        {
            txtName.Clear();
            txtShortName.Clear();
            //ddlActivityCode
        }
        #endregion
    }
}
