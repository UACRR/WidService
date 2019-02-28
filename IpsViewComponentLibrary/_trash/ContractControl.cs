using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IpsViewComponentLibrary;
using IpsViewComponentLibrary.Extensions;

namespace DebugFormForControls
{
    public partial class ContractControl : UserControl
    {
        public string Number => txtAgrNumber.Text;
        public DateTime NumberFromDate => dtAgrDate.Value;

        [Category("Data")]
        [AttributeProvider(typeof(IListSource))]
        public object DataSource
        {
            get => agreementMasterBindingSource.DataSource;
            set
            {
                if (agreementMasterBindingSource.DataSource != value)
                {
                    agreementMasterBindingSource.DataSource = value;

                    dtAgrDate.DataBindings.Clear();
                    dtAgrDate.DataBindings.Add("Value", agreementMasterBindingSource, "AgrDate", true);

                    txtAgrNumber.DataBindings.Clear();
                    txtAgrNumber.DataBindings.Add("Text", agreementMasterBindingSource, "AgrNumber");
                }
            }
        }

        public ContractControl()
        {
            InitializeComponent();
            dtAgrDate.SetUserCalendarSettingsm();
        }

        /// <summary>
        /// Очищення введених даних
        /// </summary>
        public void ClearData()
        {
            txtAgrNumber.Clear();
            dtAgrDate.SetToNullValue();
        }
    }
}
