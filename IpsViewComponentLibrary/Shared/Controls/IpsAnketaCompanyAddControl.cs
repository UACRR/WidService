using System.ComponentModel;
using System.Windows.Forms;
using ipsFormsDesign.Model;

namespace IpsViewComponentLibrary.Shared.Controls
{
    [ComplexBindingProperties("DataSource")]
    public partial class IpsAnketaCompanyAddControl : UserControl
    {
        public IpsAnketaCompanyAddControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Client Data Source
        /// </summary>
        [AttributeProvider(typeof(IListSource))]
        public object DataSource
        {
            get => bsClient.DataSource;
            set
            {
                if (value is Client)
                    bsClient.DataSource = value;
            }
        }
    }
}
