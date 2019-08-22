using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Services;
using IpsCommonTypes.ClassesForSearchQuery;
using IpsCommonTypes.Views;
using IpsCommonTypes.Wrappers;
using IpsViewComponentLibrary.Extensions;
using IpsViewComponentLibrary.Utilities;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.ObjectRightControls
{
    public partial class ObjectRightSelectionExtendedView : RadForm
    {
        private const string WID = "wid";
        private const string Local = "local";
        private readonly RegisterWIDService _service;

        private string _dbSearch = Local;

        private bool searchParamsChanged = false;

        public ObjectRightWithWID ObjectRight => gvObjectsRightsList.CurrentRow?.DataBoundItem as ObjectRightWithWID;

        public object RegisterItemViewModel
        {
            get => bsRegisterItemViewModel.DataSource;
            set => bsRegisterItemViewModel.DataSource = value;
        }

        public ObjectRightSelectionExtendedView()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            gvObjectsRightsList.SubscribeToolTipTextNeeded();
            Load += Form_Load;
            navigatorPanel.CurrentPageChanged += NavigatorPanel_CurrentPageChanged;
            navigatorPanel.PageSizeChanged += NavigatorPanel_PageSizeChanged;
            _service = RegisterWIDService.GetInstance();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            UpdateList();
        }

        public async void UpdateList()
        {
            waitingBar.StartWaiting();
            SearchObjectRightQuery query = null;
            ItemListResponse<ObjectRightWithWID> result = null;
            await Task.Factory.StartNew(() =>
            {
                query = new SearchObjectRightQuery
                {
                    DBSearch = _dbSearch,
                    Page = navigatorPanel.CurrentPage,
                    PageSize = navigatorPanel.PageSize,
                    ObjectName = !string.IsNullOrWhiteSpace(txtObjectName.Text) ? txtObjectName.Text : string.Empty,
                    Performer = !string.IsNullOrWhiteSpace(txtPerformer.Text) ? txtPerformer.Text : string.Empty,
                    Author = !string.IsNullOrWhiteSpace(txtAuthorOrRightholder.Text) ? txtAuthorOrRightholder.Text : string.Empty
                };

                result = _service.GetObjectRightListBySearch(query);
            });

            bsObjectRightsView.DataSource = result.List;

            if (searchParamsChanged)
            {
                navigatorPanel.CurrentPageChanged -= NavigatorPanel_CurrentPageChanged;
                navigatorPanel.CurrentPage = 1;
                navigatorPanel.CurrentPageChanged += NavigatorPanel_CurrentPageChanged;
                searchParamsChanged = false;
            }

            navigatorPanel.TotalPages = (int)Math.Ceiling((double)result.TotalItems / query.PageSize);

            waitingBar.StopWaiting();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnSearchLocal_Click(object sender, EventArgs e)
        {
            if (!CheckValidCountSymbol())
                return;

            _dbSearch = Local;
            UpdateList();
        }

        private void btnSearchWID_Click(object sender, EventArgs e)
        {
            if (!CheckValidCountSymbol())
                return;
            
            //MessageShow.ShowInfo("Процес пошуку в зовнішній базі даних WID може тривати довго! Дочекайтеся завершення процесу!");
            _dbSearch = WID;
            UpdateList();
        }

        private bool CheckValidCountSymbol()
        {
            string msg = string.Empty;
            lblName.SetDefaultLabelColor();
            lblAuthor.SetDefaultLabelColor();
            lblPerformer.SetDefaultLabelColor();

            if (!string.IsNullOrEmpty(txtObjectName.Text) && txtObjectName.Text.Length < 3)
            {
                msg += $"Для пошуку поле \"{lblName.Text}\" повинно мати мінімум 3 символи! ";
                lblName.SetWarningLabelColor();
            }

            if (!string.IsNullOrEmpty(txtAuthorOrRightholder.Text) && txtAuthorOrRightholder.Text.Length < 3)
            {
                msg += $"Для пошуку поле \"{lblAuthor.Text}\" повинно мати мінімум 3 символи! ";
                lblAuthor.SetWarningLabelColor();
            }

            if (!string.IsNullOrEmpty(txtPerformer.Text) && txtPerformer.Text.Length < 3)
            {
                msg += $"Для пошуку поле \"{lblPerformer.Text}\" повинно мати мінімум 3 символи! ";
                lblPerformer.SetWarningLabelColor();
            }

            if (!string.IsNullOrEmpty(msg))
            {
                MessageShow.ShowWarning(msg);
                return false;
            }

            return true;
        }

        private void NavigatorPanel_PageSizeChanged(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void NavigatorPanel_CurrentPageChanged(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void gvObjectsRightsList_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            var row = e.Row.DataBoundItem as ObjectRightWithWID;
            // local object
            if (row?.ObjId != null)
            {
                using (var view = new ObjectRightSrView())
                {
                    var presenter = new ObjectRightSrPresenter(view);
                    presenter.Show((int)row.ObjId);
                }
            }
            // wid-ipi object
            else if (row?.Wic != null)
            {

            }
        }

        private void SearchParams_TextChanged(object sender, EventArgs e)
        {
            searchParamsChanged = true;
        }
    }
}
