using System.ComponentModel;
using System.Windows.Forms;

namespace IpsViewComponentLibrary.ConsumerControls.BigRight
{
    public partial class GeneralAgreementInfo : UserControl
    {
        public GeneralAgreementInfo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Об'єкт ConsumerBigRightView
        /// </summary>
        [Category("Data")]
        [AttributeProvider(typeof(IListSource))]
        public object DataSource
        {
            get => bsAgreementAddBR.DataSource;
            set => bsAgreementAddBR.DataSource = value;
        }
    }
}
