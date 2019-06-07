using System;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Model;

namespace IpsViewComponentLibrary.PartnerControls
{
    public partial class JurPersonName : UserControl
    {
        public JurPersonName()
        {
            InitializeComponent();
            ctrlRegistrationsCompany.MaxDate = DateTime.Now;
        }

        /// <summary>
        /// AnketaCompany Data Source
        /// </summary>
        public object DataSource
        {
            get => bsAnketaCompany.DataSource;
            set
            {
                if (value is AnketaCompany)
                    bsAnketaCompany.DataSource = value;
            }
        }

        public bool Validator()
        {
            bool isvalid = true;

            if(!ctrlAnketaCompany.Validator())
                isvalid = false;
            if (!ctrlRegistrationsCompany.Validator())
                isvalid = false;

            return isvalid;

        }
    }
}
