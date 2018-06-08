using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using Telerik.WinControls;

namespace ConsumerWorkplace_v_1._0
{
    public partial class ConsumerCabinet : Telerik.WinControls.UI.RadForm, IConsumerForm
    {
        private Customer _customer;
        private AnketaDictionaties _dic;

        public Func<IList<ConsumerMainView>> GetMainViewData { get; set; }

        public ConsumerCabinet()
        {
            InitializeComponent();
            gcConsumerCabinet.SetDictionary(_dic);
            gcConsumerCabinet.OnGridRowSelectedChaged += GcConsumerCabinet_OnGridRowSelectedChaged;
        }

        private Customer GcConsumerCabinet_OnGridRowSelectedChaged(int id)
        {
            return GetCustomer(id);
        }

        public event Func<bool> Save;
        public Func<IList<ConsumerMainView>> getMainViewData { get; set; }
        public Func<int, Customer> NewCustomer { get; set; }
        public Func<int, Customer> GetCustomer { get; set; }
        public Func<Customer, bool> SaveCustomer { get; set; }
        public void EndPresenterLink()
        {
            if (getMainViewData != null)
            {
                var list = getMainViewData();
                //gvConsumerList.DataSource = list;
                gcConsumerCabinet.SetGridDataSource(list); // передати в грід джерело даних

            }
        }

        public void SetData(ICustomer data)
        {
            _customer = (Customer) data;
        }

        public void GetData(ICustomer data)
        {
            throw new NotImplementedException();
        }

        public void SetDictionary(AnketaDictionaties dic)
        {
            _dic = dic;
        }
    }
}
