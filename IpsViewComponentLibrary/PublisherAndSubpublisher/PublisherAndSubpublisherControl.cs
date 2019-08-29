using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Services;

namespace IpsViewComponentLibrary.PublisherAndSubpublisher
{
    public sealed partial class PublisherAndSubpublisherControl : UserControl
    {
        private readonly PublisherAndSubpublisherSevice _sevice;

        private bool IsDesignMode => LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode;

        public PublisherAndSubpublisherControl()
        {
            InitializeComponent();
            ctrlGridRowCount.RadGridViewDataSource = gvConsumers;
            if (!IsDesignMode)
                _sevice = PublisherAndSubpublisherSevice.GetInstance();
        }

        private void LoadData()
        {
            var list = _sevice.GetPublisherAndSubpublisherList();
            bsPublisherAndSubpublisherView.DataSource = list;
        }

        private void PublisherAndSubpublisherControl_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void gvConsumers_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {

        }
    }
}
