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

            dtTetsDate.DateTimePickerElement.Calendar.HeaderNavigationMode = HeaderNavigationMode.Zoom;
            //dtTetsDate.DateTimePickerElement.Calendar.TodayButton.ShowBorder = true;
            dtTetsDate.DateTimePickerElement.Calendar.TodayButton.Text = "Сьогодні";
            //dtTetsDate.DateTimePickerElement.Calendar.ClearButton.Visibility = ElementVisibility.Hidden;
            dtTetsDate.DateTimePickerElement.Calendar.ClearButton.ShowBorder = false;
            dtTetsDate.DateTimePickerElement.Calendar.ShowFooter = true;
            
            dtTetsDate.DateTimePickerElement.Calendar.TodayButton.Click += TodayButton_Click;

            dtTetsDate.DateTimePickerElement.Calendar.CalendarElement.CalendarStatusElement.LabelFormat = "dd/MM/yyyy";
            dtTetsDate.DateTimePickerElement.CalendarSize = new Size(200,180);

        }

        private void TodayButton_Click(object sender, EventArgs e)
        {
            dtTetsDate.Value = DateTime.Now;
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
            gcConsumerCabinet.SetDictionary(_dic);
        }
    }
}
