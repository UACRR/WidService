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
    public partial class MiddleControlCabinetPayslips : UserControl
    {
        private Customer _customer;
        private ConsumerBigRightView _bigRightView;

        public delegate IList<BigRightSpectacleView> GetSpectacleView(int custId);
        public event GetSpectacleView OnSpectacleViewNeed;

        public MiddleControlCabinetPayslips()
        {
            InitializeComponent();
        }

        public void SetAndUpdateData(Customer customer, ConsumerBigRightView bigRightView, IList<BigRightRegister> registers)
        {
            _customer = customer;
            _bigRightView = bigRightView;
            ctrlHeaderInfo.DataSource = _bigRightView;
            gvViewRl.DataSource = registers;

        }

        private void btnAddNewRl_Click(object sender, EventArgs e)
        {
            BrRegister brRegister = new BrRegister
            {
                CustId = _customer.CustId,
                FullAmount = 0m,
                RAmount = 0m,
            };
            _customer.Client.BrRegister.Add(brRegister);
            
            PayslipsCrEdForm addform = new PayslipsCrEdForm(FormType.Create, _customer, OnSpectacleViewNeed?.Invoke(_customer.CustId));
            if (addform.ShowDialog() == DialogResult.OK)
            {
                ; //TODO save
                
            }
            else
                _customer.Client.BrRegister.Remove(brRegister);

        }

        private void btnToAccept_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteRl_Click(object sender, EventArgs e)
        {

        }

        private void gvViewRl_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {

        }
    }
}
