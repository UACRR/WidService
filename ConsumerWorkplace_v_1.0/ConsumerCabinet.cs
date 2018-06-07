using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using Telerik.WinControls;

namespace ConsumerWorkplace_v_1._0
{
    public partial class ConsumerCabinet : Telerik.WinControls.UI.RadForm
    {
        private Customer _customer;

        public Func<IList<ConsumerMainView>> GetMainViewData { get; set; }

        public ConsumerCabinet()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Дані для форми
        /// </summary>
        /// <param name="obj"></param>
        public void SetData(Customer obj)
        {
            if (obj == null) return;

            _customer = obj;
        }

        public void SetDataSourceGridConsumerList(object o)
        {
            gvConsumerList.DataSource = o;

        }

        public void HelloWorld()
        {
            MessageBox.Show("Hello world!");
        }

        private void gvConsumerList_SelectionChanged(object sender, EventArgs e)
        {
            SetUserInfoData();
            gvLicenseAgr.DataSource = new object();
            SetAgrInfoData();
            
        }

        private void SetUserInfoData()
        {
            
            userInfoCtrl.Edrpou += 12;
        }

        private void SetAgrInfoData()
        {
            agreementInfoCtrl.Amount += 123;
        }

        private void SetCalculationData()
        {
            calculationCtrl.SetData(new object());
        }
    }
}
