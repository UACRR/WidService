using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using Telerik.WinControls;
using Telerik.WinControls.UI;

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
            gcConsumerCabinet.OnGridRowSelectedChaged += GcConsumerCabinet_OnGridRowSelectedChaged;
            globalControlConsumerAnketa1.OnDocumentNeedGenerate += GlobalControlConsumerAnketa1_OnDocumentNeedGenerate;
            globalControlConsumerAnketa1.OnBtnSaveClick += GlobalControlConsumerAnketa1_OnBtnSaveClick; ;
            
        }

        private void GlobalControlConsumerAnketa1_OnBtnSaveClick(Customer cust)
        {
            var result = SaveCustomer?.Invoke(cust);
        }

        private string GlobalControlConsumerAnketa1_OnDocumentNeedGenerate(Customer customer, AnketaDictionaties dictionaties)
        {
            return PdfEngine.GetPdf(customer, dictionaties);
        }

        private Customer GcConsumerCabinet_OnGridRowSelectedChaged(int id)
        {
            _customer = GetCustomer(id);
            globalControlConsumerAnketa1.SetDataAndDictionaries(_customer, _dic);
            globalControlConsumerAnketa1.InitializeControl(false);
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
            _customer = (Customer) data;// тут
        }

        public void GetData(ICustomer data)
        {
            throw new NotImplementedException();
        }

        public void SetDictionary(AnketaDictionaties dic)
        {
            _dic = dic;
            gcConsumerCabinet.SetDictionary(_dic);
        }


    }
}
