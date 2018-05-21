using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        [Category("Dictionaries")]
        [AttributeProvider(typeof(IListSource))]
        public object ActivityCodeDataSource
        {
            get { return ddlActivityCode.DataSource; }
            set
            {
                if (ddlActivityCode.DataSource != value)
                    ddlActivityCode.DataSource = value;
            }
        }

        [Category("Dictionaries")]
        public string ActivityCodeDataMember
        {
            get { return ddlActivityCode.DataMember; }
            set { ddlActivityCode.DataMember = value; }
        }

        [Category("Dictionaries")]
        public string ActivityCodeDisplayMember
        {
            get { return ddlActivityCode.DisplayMember; }
            set { ddlActivityCode.DisplayMember = value; }
        }

        [Category("Dictionaries")]
        public string ActivityCodeValueMember
        {
            get { return ddlActivityCode.ValueMember; }
            set { ddlActivityCode.ValueMember = value; }
        }

        public string CompanyFullName => txtName.Text;

        #endregion
    }
}
