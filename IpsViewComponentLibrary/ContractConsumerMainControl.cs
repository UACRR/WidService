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

        public ContractConsumerMainControl()
        {
            InitializeComponent();
        }
    }
}
