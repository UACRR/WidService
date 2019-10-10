using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using ipsFormsDesign.ViewModels.Other;
using IpsViewComponentLibrary.Extensions;
using Telerik.WinControls.UI;
using PublishersView = ipsFormsDesign.ViewModels.Other.PublishersView;

namespace IpsViewComponentLibrary.PublisherAndSubpublisher
{
    public partial class PublisherAndSubpublisherForm : RadForm
    {
        private const string DateBeginLessThanDateEndOfExistenLink = "";

        private readonly DateTime MaxBeginDate = new DateTime(2999, 12, 31);
        private readonly List<PublishersView> _publisherList = new List<PublishersView>();
        private readonly List<PublishersView> _subPublisherList = new List<PublishersView>();

        private readonly List<PublisherAndSubpublisherView> _view;

        private readonly PublisherAndSubpublisherView _subpublisherViewCache;

        private PublisherAndSubpublisherForm()
        {
            InitializeComponent();

            ctrlSaveCancelButtons.ButtonSaveDialogResult = DialogResult.None;
            ctrlSaveCancelButtons.SaveClck += CtrlSaveCancelButtons_SaveClck;

            dtDateBegin.MaxDate = new DateTime(2999, 12, 31);
            dtDateEnd.MaxDate = new DateTime(3000, 01, 01);
        }

        /// <summary>
        /// Конструктор для додавання нового зв'язку видавництва/субвидавництва
        /// </summary>
        /// <param name="relSubPublish"></param>
        public PublisherAndSubpublisherForm(RelSubPublish relSubPublish, List<PublisherAndSubpublisherView> view) : this()
        {
            _view = view;

            dtDateBegin.MinDate = DateTime.Now;
            dtDateEnd.MinDate = DateTime.Now.AddDays(1);

            var publisherList = PublisherAndSubpublisherSevice.GetInstance().GetPublishersList();

            _publisherList.Clear();
            _publisherList.AddRange(publisherList);
            bsPublishers.DataSource = _publisherList;

            _subPublisherList.Clear();
            _subPublisherList.AddRange(publisherList);
            bsSubPublishers.DataSource = _subPublisherList;

            relSubPublish.DateBegin = DateTime.Today;
            bsRelSubPublish.DataSource = relSubPublish;

            bsPublishers.MoveFirst();
            bsSubPublishers.MoveFirst();

            dtDateBegin.Leave += dtDateBegin_Leave;
            bsPublishers.CurrentItemChanged += BsSubPublishers_CurrentItemChanged;
        }

        /// <summary>
        /// Конструктор для редагування зв'язку видавництва/субвидавництва
        /// </summary>
        /// <param name="subpublisherView"></param>
        public PublisherAndSubpublisherForm(PublisherAndSubpublisherView subpublisherView) : this()
        {
            _subpublisherViewCache = subpublisherView;

            var listPub = new List<PublishersView>
            {
                new PublishersView
                {
                    CustId = _subpublisherViewCache.CustIdPub,
                    PublisherName = _subpublisherViewCache.PubName
                }
            };
            var listSubPub = new List<PublishersView>
            {
                new PublishersView
                {
                    CustId = _subpublisherViewCache.CustIdSub,
                    PublisherName = _subpublisherViewCache.SubName
                }
            };

            bsPublishers.DataSource = listPub;
            bsSubPublishers.DataSource = listSubPub;

            ddlPublisher.ReadOnly = true;
            ddlSubPublisher.ReadOnly = true;
            dtDateBegin.ReadOnly = true;
            var arrowButtonDateBegin = dtDateBegin.DateTimePickerElement.FindDescendant<RadDateTimePickerArrowButtonElement>();
            arrowButtonDateBegin.Enabled = false;
            lblInfo.Visible = true;

            var relSubPublish = new RelSubPublish
            {
                CustIdPub = _subpublisherViewCache.CustIdPub,
                CustIdSub = _subpublisherViewCache.CustIdSub,
                DateBegin = _subpublisherViewCache.DateBegin,
                DateEnd = _subpublisherViewCache.DateEnd,
            };

            bsRelSubPublish.DataSource = relSubPublish;

            if (relSubPublish.DateEnd < DateTime.Now)
                dtDateEnd.ReadOnly = true;
            else
                dtDateEnd.MinDate = DateTime.Now;
        }

        private void CtrlSaveCancelButtons_SaveClck(object sender, EventArgs e)
        {
            if (!(bsRelSubPublish.DataSource is RelSubPublish item))
                return;

            if (item.CustIdPub == 0 || item.CustIdSub == 0)
                return;

            if (item.DateEnd == null)
                item.DateEnd = new DateTime(3000, 01, 01);

            if (_subpublisherViewCache != null)
            {
                _subpublisherViewCache.CustIdPub = item.CustIdPub;
                _subpublisherViewCache.CustIdSub = item.CustIdSub;
                _subpublisherViewCache.DateBegin = item.DateBegin;
                _subpublisherViewCache.DateEnd = item.DateEnd;
            }

            if (CheckValidNewPublisherSubpublisherLink())
                DialogResult = DialogResult.OK;
        }

        private bool CheckValidNewPublisherSubpublisherLink()
        {
            var item = bsRelSubPublish.DataSource as RelSubPublish;

            var existLinks = _view.Where(rec => rec.CustIdPub == item.CustIdPub).ToList();

            // it's new link
            if (!existLinks.Any())
                return true;

            foreach (var link in existLinks)
            {
                if (item.DateBegin <= link.DateEnd)
                {
                    MessageShow.ShowWarning(DateBeginLessThanDateEndOfExistenLink);
                    return false;
                }
            }

            // else is valid
            return true;
        }

        //private bool CheckChangesPublisherSubpublisherLink()
        //{

        //}

        private void BsSubPublishers_CurrentItemChanged(object sender, EventArgs e)
        {
            if (!(((BindingSource)sender).Current is PublishersView item))
                return;

            bsSubPublishers.DataSource = _subPublisherList.Where(rec => rec.CustId != item.CustId).ToList();
            bsSubPublishers.MoveFirst();
        }

        private void dtDateBegin_Leave(object sender, EventArgs e)
        {
            if (dtDateBegin.Value >= MaxBeginDate)
                dtDateBegin.Value = DateTime.Today;

            if (dtDateBegin.Value.AddDays(1) is DateTime newDate)
                dtDateEnd.MinDate = new DateTime(newDate.Year, newDate.Month, newDate.Day);
        }
    }
}
