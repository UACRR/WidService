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
using ipsFormsDesign.Model;

namespace IpsViewComponentLibrary
{
    public partial class MiddleControlCabinetAgent : UserControl
    {
        private Customer _customer;
        private MainGridConsumerBigRightView _bigRightView;
        public MiddleControlCabinetAgent()
        {
            InitializeComponent();
        }

        public void SetAndUpdateData(Customer customer, MainGridConsumerBigRightView bigRightView, IList<GeneralAgreementBigRightView> genAgrs)
        {
            _customer = customer;
            _bigRightView = bigRightView;
            gvGenAgrLicences.DataSource = genAgrs;
        }
    }
}
