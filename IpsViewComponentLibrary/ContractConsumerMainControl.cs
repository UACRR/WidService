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
    public partial class ContractConsumerMainControl : UserControl
    {
        [Category("Data")]
        [AttributeProvider(typeof(IListSource))]
        public object DataSource
        {
            get => iAgreementMasterBindingSource.DataSource;
            set => iAgreementMasterBindingSource.DataSource = value;
        }

        public string ContractNumber
        {
            get => rtxtBoxContrNumber.Text;
        }

        public string ContractBeginDate
        {
            get => rdtPickerAgrDate.Value.ToString("dd.MM.yyyy");
        }

        public ContractConsumerMainControl()
        {
            InitializeComponent();
        }

        public bool Validator()
        {
            bool isValid = true;

            if (rtxtBoxContrNumber.Text == string.Empty)
            {
                lblContrNumb.ForeColor = Color.FromArgb(180, 255, 0, 2);
                isValid = false;
            }
            else
                lblContrNumb.ForeColor = Color.Black;

            return isValid;
        }

        public void ClearData()
        {
            rtxtBoxContrNumber.Text = string.Empty;
            rdtPickerAgrDate.Text = string.Empty;
            rdtPickerDateBegin.Text = string.Empty;
            rdtPickerDateEnd.Text = string.Empty;
        }
    }
}
