using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Interfaces;

namespace IpsViewComponentLibrary
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
