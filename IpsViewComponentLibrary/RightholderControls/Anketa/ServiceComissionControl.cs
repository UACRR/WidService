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
using ipsFormsDesign.Data;

namespace IpsViewComponentLibrary.RightholderControls.Anketa
{
    public partial class ServiceComissionControl : UserControl
    {
        private void setupObjects()
        {
            var nameOwner = IpsGlobal.GetProperty("OwnerName");

            var lbl1Text =  $"збір за управління, необхідний для покриття витрат на забезпечення діяльності {nameOwner ?? "Підприємства"}";
            var lbl3Text = $"від сум, зібраних {nameOwner ?? "Підприємством"} для Правовласника";

            radLabel1.Text = lbl1Text;
            radLabel3.Text = lbl3Text;
        }

        public ServiceComissionControl()
        {
            InitializeComponent();
            setupObjects();
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

        #region Validation

        private void mtxtRateCommission_Validating(object sender, CancelEventArgs e)
        {
            if (decimal.TryParse(mtxtRateCommission.Text, out decimal value))
            {
                if (value > 100)
                {
                    errorProvider.SetError(mtxtRateCommission, "Відсоток комісії не може бути більше 100%.");
                    e.Cancel = true;
                }
                else
                    errorProvider.SetError(mtxtRateCommission, "");
            }
        }

        private void mtxtRateCourt_Validating(object sender, CancelEventArgs e)
        {
            if (decimal.TryParse(mtxtRateCourt.Text, out decimal value))
            {
                if (value > 100)
                {
                    errorProvider.SetError(mtxtRateCourt, "Відсоток комісії не може бути більше 100%.");
                    e.Cancel = true;
                }
                else
                    errorProvider.SetError(mtxtRateCourt, "");
            }
        }

        #endregion
    }
}
