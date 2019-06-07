using System.ComponentModel;
using System.Windows.Forms;

namespace IpsViewComponentLibrary.Shared.Controls
{
    [ComplexBindingProperties("DataSource")]
    public partial class IpsClientGroupBrandControl : UserControl
    {
        public IpsClientGroupBrandControl()
        {
            InitializeComponent();
        }

        [Category("DataBinding")]
        [AttributeProvider(typeof(IListSource))]
        public object DataSource
        {
            get => bsClient.DataSource;
            set => bsClient.DataSource = value;
        }
    }
}
