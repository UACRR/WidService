using System;
using System.Windows.Forms;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using IpsViewComponentLibrary.Extensions;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.ConsumerControls
{
    public partial class ConsumersViewSmallRightControl : UserControl
    {
        public event LoadCustomerCabinetSREventHandler OnLoadCustomerCabinetNeed;
        public event EventHandler OnAddNewCustomer;
        public event Action SearchOrPageChanged;

        public ConsumerSmallRightView ViewRow => gvViewConsumers.CurrentRow?.DataBoundItem as ConsumerSmallRightView;

        public ConsumersViewSmallRightControl()
        {
            InitializeComponent();
        }

        public object DataSource
        {
            get => bsConsumerSmallRightView.DataSource;
            set
            {
                bsConsumerSmallRightView.DataSource = value;
                bsConsumerSmallRightView.ResetBindings(false);
            }
        }

        public int TotalItems
        {
            set => navigatorPanel.TotalPages = (int)Math.Ceiling((double)value / navigatorPanel.PageSize);
        }

        public PaginateAndSearchQuery PaginateAndSearchQuery => new PaginateAndSearchQuery
        {
            PageSize = navigatorPanel.PageSize,
            Page = navigatorPanel.CurrentPage,
            SearchText = txtSearch.Text,
        };

        public void StartWait()
        {
            waitingBar.StartWaiting();
        }

        public void StopWait()
        {
            waitingBar.StopWaiting();
        }

        private void gvConsumers_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            OnLoadCustomerCabinetNeed?.Invoke(e.Row.DataBoundItem as ConsumerSmallRightView);
        }

        // створити споживача юридичної особи
        private void btnAddJurConsumer_Click(object sender, EventArgs e)
        {
            OnAddNewCustomer?.Invoke(3, EventArgs.Empty);
        }

        // створити споживача фізичної особи
        private void btnAddPhisConsumer_Click(object sender, EventArgs e)
        {
            OnAddNewCustomer?.Invoke(1, EventArgs.Empty);
        }

        private void gvViewConsumers_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            if (e.Column is GridViewCommandColumn)
                return;

            if (!(e.Row.DataBoundItem is ConsumerSmallRightView row))
                return;

            OnLoadCustomerCabinetNeed?.Invoke(row);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            timerSearch.Stop();
            timerSearch.Start();
        }

        private void timerSearch_Tick(object sender, EventArgs e)
        {
            timerSearch.Stop();
            navigatorPanel.CurrentPage = 1;
        }

        private void navigatorPanel_CurrentPageChanged(object sender, EventArgs e)
        {
            SearchOrPageChanged?.Invoke();
        }

        private void navigatorPanel_PageSizeChanged(object sender, EventArgs e)
        {
            SearchOrPageChanged?.Invoke();
        }
    }
}
