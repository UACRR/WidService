using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign;
using ipsFormsDesign.Data;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary.CommunityControls.InternalModel;
using IpsViewComponentLibrary.Extensions;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.CommunityControls
{
    public partial class CommunityRightLimitationControl : UserControl
    {
        private const string LimitationOfRightsQuestion = "Деякі обмеження прав належить іншому товариству! Змінити обмеження?";

        private readonly List<CopyrightKind> _copyrightKindsDictionary;
        private readonly List<CommunityInfo> _communitiesDictionary;

        private List<RightLimitationsView> _rightLimitationsViews;
        private int _communityCustId;

        public event EventHandler ValueEdit;

        public CommunityRightLimitationControl()
        {
            InitializeComponent();

            if (IpsGlobal.AnketaDictionaties != null)
            {
                _copyrightKindsDictionary = IpsGlobal.AnketaDictionaties.copyrightKind.ToList();
                _communitiesDictionary = IpsGlobal.AnketaDictionaties.communities.ToList();
            }
        }

        public List<CustCmRight> LimitRights { get; private set; } = new List<CustCmRight>();
        public List<TermsOfService> TermsOfServiceLimitRights { get; private set; } = new List<TermsOfService>();


        public void SetData(CommunityAuthorsView authorsView, List<CustCmRight> rightList, List<TermsOfService> termsOfServices, int communityCustId)
        {
            _communityCustId = communityCustId;
            bsRightLimitationsView.DataSource = GenerateDataGrid(authorsView, rightList, termsOfServices);
        }

        // оновлення даних
        private List<RightLimitationsView> GenerateDataGrid(CommunityAuthorsView authorsView, List<CustCmRight> rightList, List<TermsOfService> termsOfServices)
        {
            TermsOfServiceLimitRights = termsOfServices;

            _rightLimitationsViews = new List<RightLimitationsView>();

            foreach (var kind in _copyrightKindsDictionary)
            {
                var right = rightList?.SingleOrDefault(rec => rec.CRkindCode == kind.CodeI);
                var term = termsOfServices?.SingleOrDefault(rec => rec.CrkindCode == kind.CodeI);

                _rightLimitationsViews.Add(new RightLimitationsView
                {
                    CustId = authorsView.CustId,
                    CmCustId = GetCommunityId(right, term),
                    KindCode = kind.CodeI,
                    KindName = kind.Name,
                    CommunityName = GetCommunityName(right, term),
                    Check = IsCheck(right, term),
                    DateBegin = right?.DateBegin ?? DateTime.Today,
                    DateEnd = right?.DateEnd ?? new DateTime(3000, 1, 1)
                });
            }

            return _rightLimitationsViews;
        }

        /// <summary>
        /// Отримати ID товариства залежно з якої таблиці обмеження
        /// </summary>
        /// <param name="right"></param>
        /// <param name="term"></param>
        /// <returns></returns>
        private int? GetCommunityId(CustCmRight right, TermsOfService term)
        {
            if (right?.CmCustId is int id)
                return id;

            if (term != null && term.OurService)
                return InternalCommunity.InternalCommunityInfo.CustId;

            return null;
        }

        /// <summary>
        /// Отримати Назву товариства залежно з якої таблиці обмеження
        /// </summary>
        /// <param name="right"></param>
        /// <param name="term"></param>
        /// <returns></returns>
        private string GetCommunityName(CustCmRight right, TermsOfService term)
        {
            var rightName = _communitiesDictionary.SingleOrDefault(rec => rec.CustId == right?.CmCustId)?.Name;
            var termName = term?.OurService ?? false ? InternalCommunity.InternalCommunityInfo?.Name : string.Empty;
            return !string.IsNullOrEmpty(rightName) ? rightName : termName;
        }

        /// <summary>
        /// Вирахувати чи проставляти галочку
        /// </summary>
        /// <param name="right"></param>
        /// <param name="term"></param>
        /// <returns></returns>
        private bool IsCheck(CustCmRight right, TermsOfService term)
        {
            // якщо обмеження з табилці CustCmRight
            var checkOfCustCmRight = right?.CmCustId == _communityCustId;
            //якщо обммеження з таблиці TermsOfService 
            var checkOfTermsOfService = (term?.OurService ?? false) && (InternalCommunity.InternalCommunityInfo?.CustId == _communityCustId);
            return checkOfCustCmRight || checkOfTermsOfService;
        }

        /// <summary>
        /// Виконати оновлення даних в структурі
        /// </summary>
        public void UpdateData()
        {
            // товариство - користувач програми - таблиця TermsOfService
            if (InternalCommunity.InternalCommunityInfo?.CustId == _communityCustId)
                TermsOfServiceChangeRightLimit();
            // всі інші товариства - таблиця CustCmRight
            else
                CustCmRightChangeRightLimit();
        }

        /// <summary>
        /// Змінити обмеження прав по таблиці TermsOfService
        /// </summary>
        private void TermsOfServiceChangeRightLimit()
        {
            foreach (var rightLimitationsView in _rightLimitationsViews)
            {
                var termsOfService = TermsOfServiceLimitRights.SingleOrDefault(rec => rec.CrkindCode == rightLimitationsView.KindCode);
                // додати обмеження 
                if (rightLimitationsView.Check)
                {
                    if (termsOfService == null)
                    {
                        var newTerm = new TermsOfService
                        {
                            CrkindCode = rightLimitationsView.KindCode,
                            CustId = rightLimitationsView.CustId,
                            OurService = true
                        };
                        TermsOfServiceLimitRights.Add(newTerm);
                    }
                    else
                    {
                        termsOfService.OurService = true;
                    }
                }
                else
                {
                    if (termsOfService != null)
                        TermsOfServiceLimitRights.Remove(termsOfService);
                }
            }
        }

        /// <summary>
        /// Змінити обмеження прав по таблиці CustCmRight
        /// </summary>
        /// <param name="action">додати/видалити обмеження</param>
        private void CustCmRightChangeRightLimit()
        {
            foreach (var rightLimitationsView in _rightLimitationsViews.Where(rec => rec.Check))
            {
                LimitRights.Add(new CustCmRight
                {
                    CustId = rightLimitationsView.CustId,
                    CRkindCode = rightLimitationsView.KindCode,
                    CmCustId = _communityCustId,
                    DateBegin = rightLimitationsView.DateBegin ?? DateTime.Today,
                    DateEnd = rightLimitationsView.DateEnd ?? new DateTime(3000, 1, 1)
                });
            }
        }

        /// <summary>
        /// Попередня перевірка змін обмежень прав, запитує чи можна зберігати зміни обмежень прав з одного товариства на інше
        /// </summary>
        /// <returns></returns>
        public bool CheckCanSaveRightLimitChanges()
        {
            bool canSave = true;
            if (_rightLimitationsViews.Any())
            {
                // пошук зміни товариства з іншого на поточне
                var listForCheckChangeCommunity = _rightLimitationsViews.Where(rec => rec.Check && rec.CmCustId != _communityCustId).ToList();
                foreach (var rightLimitationsView in listForCheckChangeCommunity)
                {
                    if (!string.IsNullOrEmpty(rightLimitationsView.CommunityName))
                    {
                        canSave = MessageShow.ConfirmAction(LimitationOfRightsQuestion) == DialogResult.Yes;
                        break;
                    }
                }
            }

            return canSave;
        }

        private void gvRightLimitations_ValueChanging(object sender, ValueChangingEventArgs e)
        {
            ValueEdit?.Invoke(sender, e);
        }
    }
}