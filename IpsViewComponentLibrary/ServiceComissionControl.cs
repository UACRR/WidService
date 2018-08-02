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
    public partial class ServiceComissionControl : UserControl
    {
        public ServiceComissionControl()
        {
            InitializeComponent();
        }

        [Category("Data")]
        [AttributeProvider(typeof(IListSource))]
        public object DataSource
        {
            get { return agreementAddRhBindingSource.DataSource; }
            set
            {
                if (agreementAddRhBindingSource.DataSource != value)
                    agreementAddRhBindingSource.DataSource = value;
            }
        }

        [Category("Data")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
        public string DataMember
        {
            get { return agreementAddRhBindingSource.DataMember; }
            set { agreementAddRhBindingSource.DataMember = value; }
        }

        #region Edit controls

        public RadMaskedEditBox TxtRateCommission
        {
            get
            {
                return mtxtRateCommission;
            }
        }

        public RadMaskedEditBox TxtRateCourt
        {
            get
            {
                return mtxtRateCourt;
            }
        }

        #endregion
    }
}
