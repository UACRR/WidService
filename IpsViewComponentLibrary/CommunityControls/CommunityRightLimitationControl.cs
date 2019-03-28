using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        private const string LimitationOfRightsQuestion = "Обмеження прав належить іншому товариству! Змінити обмеження?";
        private const string ExceptionMsg = "Ідентифікатор 'CustId' не може бути NULL!";

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

        public List<CustCmRight> LimitRights { get; } = new List<CustCmRight>();

        public void SetData(CommunityAuthorsView authorsView, List<CustCmRight> rightList, int communityCustId)
        {
            _communityCustId = communityCustId;
            bsRightLimitationsView.DataSource = GenerateDataGrid(authorsView, rightList);
        }

        // оновлення даних
        private List<RightLimitationsView> GenerateDataGrid(CommunityAuthorsView authorsView, List<CustCmRight> rightList)
        {
            _rightLimitationsViews = new List<RightLimitationsView>();
            var items = rightList?.Where(rec => rec?.CmCustId == _communityCustId).ToList();

            if (items != null && items.Any())
            {
                LimitRights.Clear();
                LimitRights.AddRange(items);
            }

            foreach (var kind in _copyrightKindsDictionary)
            {
                var right = rightList?.SingleOrDefault(rec => rec.CRkindCode == kind.CodeI);
                _rightLimitationsViews.Add(new RightLimitationsView
                {
                    CustId = authorsView.CustId,
                    CmCustId = right?.CmCustId,
                    KindCode = kind.CodeI,
                    KindName = kind.Name,
                    CommunityName = _communitiesDictionary.SingleOrDefault(rec => rec?.CustId == right?.CmCustId)?.Name,
                    Check = right?.CmCustId == _communityCustId,
                    DateBegin = right?.DateBegin ?? DateTime.Today,
                    DateEnd = right?.DateEnd ?? new DateTime(3000, 1, 1)
                });
            }

            return _rightLimitationsViews;
        }


        // зміна обмеження
        private void gvRightLimitations_ValueChanging(object sender, ValueChangingEventArgs e)
        {
            if (!(gvRightLimitations.CurrentRow.DataBoundItem is RightLimitationsView row) || string.IsNullOrEmpty(row.CommunityName) || row.Check || row.CmCustId == _communityCustId)
            {
                ChangeRightLimitList((bool) e.NewValue);
                return;
            }

            if (MessageShow.ConfirmAction(LimitationOfRightsQuestion) == DialogResult.Yes)
                ChangeRightLimitList((bool) e.NewValue);
            else
                e.Cancel = true;
        }

        /// <summary>
        /// Змінити обмеження прав автора
        /// </summary>
        /// <param name="action">додати/видалити обмеження</param>
        private void ChangeRightLimitList(bool action)
        {
            if (!(gvRightLimitations.CurrentRow.DataBoundItem is RightLimitationsView currentRow))
                throw new ArgumentNullException(ExceptionMsg);

            ValueEdit?.Invoke(new object(), EventArgs.Empty);

            if (action)
            {
                LimitRights.Add(new CustCmRight
                {
                    CustId = currentRow.CustId,
                    CRkindCode = currentRow.KindCode,
                    CmCustId = currentRow.CmCustId ?? 0,
                    DateBegin = currentRow.DateBegin ?? DateTime.Today,
                    DateEnd = currentRow.DateEnd ?? new DateTime(3000, 1, 1)
                });
            }
            else
            {
                var item = LimitRights.SingleOrDefault(r =>
                    r.CustId == currentRow.CustId && r.CRkindCode == currentRow.KindCode);
                LimitRights.Remove(item);
            }
        }
    }
}