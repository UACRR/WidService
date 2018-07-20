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
    public partial class MiddleControlCabinetCalculation : UserControl
    {
        private Customer _customer;
        private ConsumerBigRightView _bigRightView;
        
        private AnketaDictionaties _dictionaties;

        public MiddleControlCabinetCalculation()
        {
            InitializeComponent();
        }

        public void SetAnketaDictionary(AnketaDictionaties dictionaties)
        {
            _dictionaties = dictionaties;
        }

        public void SetAndUpdateData(Customer customer, ConsumerBigRightView bigRightView, IList<BigRightMasterGenAgr> genAgrs, IList<BigRightMoneyUndescrib> undescribs)
        {
            _customer = customer;
            _bigRightView = bigRightView;
            gvUndistribMoneys.DataSource = undescribs;

        }
    }
}
