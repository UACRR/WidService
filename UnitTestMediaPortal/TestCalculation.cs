using ipsFormsDesign;
using ipsFormsDesign.Data;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnitTestMediaPortal
{
    public partial class TestCalculation : Form
    {

        private readonly ConsumerService _service = null;
        public TestCalculation(ConsumerService service)
        {
            _service = service;
            IpsGlobal.SetAnketaDictionaties(_service.GetDictionary());
            InitializeComponent();
            initControls();
        }

        private void initControls()
        {

            reportsControl1.SaveRegisterRatedListExecuted += ReportsControl1_SaveRegisterRatedListExecuted;
            reportsControl1.GetRegisterItems = _service.GetRegisterItems;
            reportsControl1.DeleteRegisterExecuted += ReportsControl1_DeleteRegisterExecuted;


        }

        private Customer _customer;
        public Customer Customer {
            get { return _customer;  }
            set { _customer = value;
                reportsControl1.Customer = _customer; }
        }


        private void ReportsControl1_DeleteRegisterExecuted(object sender, Register e)
        {
            _service.DeleteRegister(e);
        }

        private void ReportsControl1_SaveRegisterRatedListExecuted(object sender, RegisterRatedList e)
        {
            RegisterRatedList ratedList = null;
            if (_service.SaveRegisterRatedList(e, out ratedList) == true)
            {
                var dic = ratedList.Register.ToDictionary(rec => rec.FileName);
                e.SetFields(ratedList);
                foreach (var item in e.Register)
                {
                    var sors = dic[item.FileName];
                    item.SetFields(sors);
                    item.RegisterItem.Clear();
                    foreach (var sorsItem in sors.RegisterItem)
                        item.RegisterItem.Add(sorsItem);
                }
            }
        }
    }
}
