using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
        private readonly DateTime MaxBeginDate = new DateTime(2999, 12, 31);
        private readonly List<PublishersView> _publisherList = new List<PublishersView>();
        private readonly List<PublishersView> _subPublisherList = new List<PublishersView>();

        private readonly List<PublisherAndSubpublisherView> _view;

        private readonly PublisherAndSubpublisherView _subpublisherViewCache;

        private readonly bool IsEdit = false;

        bool IsValid => IsEdit ? ValidateChangesPublisherSubpublisherLink() : ValidateNewPublisherSubpublisherLink();

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

            //dtDateBegin.MinDate = DateTime.Now;
            dtDateEnd.MinDate = DateTime.Now.AddDays(1);

            var publisherList = PublisherAndSubpublisherSevice.GetInstance().GetPublishersList();
            var subpublisherList = PublisherAndSubpublisherSevice.GetInstance().GetSubPublishersList();

            _publisherList.Clear();
            _publisherList.AddRange(publisherList);
            bsPublishers.DataSource = _publisherList;

            _subPublisherList.Clear();
            _subPublisherList.AddRange(subpublisherList);
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
        public PublisherAndSubpublisherForm(PublisherAndSubpublisherView subpublisherView, List<PublisherAndSubpublisherView> view) : this()
        {
            _view = view;

            _subpublisherViewCache = subpublisherView;
            IsEdit = true;

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

            if (IsValid)
                DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Verify changed end date of existen link
        /// </summary>
        /// <returns></returns>
        private bool ValidateChangesPublisherSubpublisherLink()
        {
            var item = bsRelSubPublish.DataSource as RelSubPublish;

            var existLinks = _view.Where(rec => rec.CustIdPub == item.CustIdPub && rec.CustIdSub != item.CustIdSub).ToList();

            // it's the same link
            if (!existLinks.Any())
                return true;

            DateTime? maxValidDate = null;
            bool isValid = true;
            foreach (var link in existLinks)
            {
                if (item.DateEnd > link.DateBegin && item.DateEnd < link.DateEnd)
                {
                    isValid = false;
                    maxValidDate = link.DateBegin.AddDays(-1);
                    break;
                }
            }

            //var isInvalid = existLinks.Any(rec => rec.DateBegin <= item.DateBegin && rec.DateEnd >= item.DateBegin
            //                           && rec.DateBegin <= item.DateBegin && rec.DateEnd >= item.DateEnd);
            //isValid = isInvalid;

            if (!isValid)
            {
                MessageShow.ShowWarning($"Дата «Дії повноважень по» пересікається з періодом іншого існуючого повноваження субвидавницта! " +
                    $"Максимальна можлива дата «Дії повноважень по» - {maxValidDate.Value:dd.MM.yyyy}!");
            }

            return isValid;
        }

        /// <summary>
        /// Verify begin date and end date of new link of publisher and subpublisher 
        /// </summary>
        /// <returns></returns>
        private bool ValidateNewPublisherSubpublisherLink()
        {
            var item = bsRelSubPublish.DataSource as RelSubPublish;

            var existLinks = _view.Where(rec => rec.CustIdPub == item.CustIdPub).ToList();

            // it's new link
            if (!existLinks.Any())
                return true;

            var validDatePairs = GetValidDatePairs(existLinks);

            //bool isValid = false;

            //foreach (var datePair in validDatePairs)
            //{
            //    bool currentPairValid = item.DateBegin >= datePair.Key && item.DateEnd <= datePair.Value;
            //    if (currentPairValid)
            //    {
            //        isValid = true;
            //        break;
            //    }
            //}

            var isInvalid = existLinks.Any(rec => rec.DateBegin <= item.DateBegin && rec.DateEnd >= item.DateBegin
                           || rec.DateBegin <= item.DateEnd && rec.DateEnd >= item.DateEnd);

            if (isInvalid)
            {
                string msg = "Обраний період пересікається з періодом іншого існуючого повноваження субвидавницта!";

                if (validDatePairs.Any())
                {
                    var values = new List<string> { $"{msg} Дія повноважень для нового субвидавництва може бути в таких діапазонах: " };
                    foreach (var pair in validDatePairs)
                    {
                        values.Add($"- від {pair.Key.Value.ToString("dd.MM.yyyy")} по {pair.Value.Value.ToString("dd.MM.yyyy")};");
                    }
                    msg = $"{string.Join("\n", values)}";
                }

                MessageShow.ShowWarning(msg);
            }

            return !isInvalid;
        }

        /// <summary>
        /// Generate a dates pairs that can be in a valid period
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        private List<KeyValuePair<DateTime?, DateTime?>> GetValidDatePairs(ICollection<PublisherAndSubpublisherView> view)
        {
            DateTime maxDate = new DateTime(3000, 01, 01);
            var pairs = new List<KeyValuePair<DateTime?, DateTime?>>();
            var list = view.OrderBy(rec => rec.DateBegin).ToList();

            /* pairs search need
             * date pair example:
             *  02.10.2015 15.10.2015
             *  16.10.2015 10.11.2015
             *   - window: 11.11.2015-19.11.2015
             *  20.11.2015 30.11.2015
             *    1)
             *     - window: 01.12.2015-01.01.3000
             *    2)
             *     - window: 01.12.2015-20.02.2016
             *  21.02.2016 01.01.3000
            */

            for (int i = 1; i <= list.Count; i++)
            {
                // isn't last item
                if (i != list.Count)
                {
                    var possibleDateBegin = list[i - 1].DateEnd.Value.AddDays(1);
                    if (possibleDateBegin == list[i].DateBegin)
                        continue;

                    var possibleDateEnd = list[i].DateBegin.AddDays(-1);

                    if (possibleDateBegin < possibleDateEnd)
                        pairs.Add(new KeyValuePair<DateTime?, DateTime?>(possibleDateBegin, possibleDateEnd));

                    continue;
                }

                // the last link may be infinite
                if (list[i - 1].DateEnd != maxDate)
                    pairs.Add(new KeyValuePair<DateTime?, DateTime?>(list[i - 1].DateEnd, maxDate));
            }

            return pairs;
        }

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
