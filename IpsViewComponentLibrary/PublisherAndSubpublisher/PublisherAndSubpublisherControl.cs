using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using ipsFormsDesign.ViewModels.Other;
using IpsViewComponentLibrary.Extensions;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.PublisherAndSubpublisher
{
    public sealed partial class PublisherAndSubpublisherControl : UserControl
    {
        private const string CreateLinkSuccessMsg = "Додано!";
        private const string CreateLinkErrorMsg = "Неможливо додати!";

        private readonly PublisherAndSubpublisherSevice _sevice;

        private bool IsDesignMode => LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode;

        public PublisherAndSubpublisherControl()
        {
            InitializeComponent();
            ctrlGridRowCount.RadGridViewDataSource = gvPublishers;
            if (!IsDesignMode)
                _sevice = PublisherAndSubpublisherSevice.GetInstance();
        }

        private void UpdateData()
        {
            var list = _sevice.GetPublisherAndSubpublisherList();
            bsPublisherAndSubpublisherView.DataSource = list;
        }

        private void PublisherAndSubpublisherControl_Load(object sender, EventArgs e)
        {
            if (!IsDesignMode)
                UpdateData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var relSubPublish = new RelSubPublish();
            var pubsubView = (List<PublisherAndSubpublisherView>)bsPublisherAndSubpublisherView.DataSource;

            using (var form = new PublisherAndSubpublisherForm(relSubPublish, pubsubView))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var result = _sevice.CreatePublisherSubpublisherLink(relSubPublish);
                    MessageShow.ShowInfoByResult(CreateLinkSuccessMsg, CreateLinkErrorMsg, result);
                    UpdateData();
                }
            }
        }

        private void gvConsumers_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            if (!(e.Row.DataBoundItem is PublisherAndSubpublisherView row))
                return;

            var pubsubView = (List<PublisherAndSubpublisherView>)bsPublisherAndSubpublisherView.DataSource;

            using (var form = new PublisherAndSubpublisherForm(row, pubsubView))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var relSubPublish = new RelSubPublish
                    {
                        CustIdPub = row.CustIdPub,
                        CustIdSub = row.CustIdSub,
                        CreateDate = row.CreateDate,
                        DateBegin = row.DateBegin,
                        DateEnd = row.DateEnd,
                    };

                    var result = _sevice.UpdatePublisherSubpublisherLink(relSubPublish);
                    MessageShow.ShowInfoAfterChanges(result);
                    UpdateData();
                }
            }
        }
    }
}
