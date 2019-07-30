using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Services;
using ipsFormsDesign.ViewModels.ObjectsRight;
using IpsCommonTypes.ClassesForSearchQuery;
using IpsCommonTypes.Types;
using IpsCommonTypes.Views;
using IpsCommonTypes.Wrappers;
using IpsViewComponentLibrary.Extensions;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.ObjectRightControls
{
    public partial class ObjectRightSelectionExtendedView : RadForm
    {
        private const string WID = "wid";
        private const string Local = "local";
        private readonly RegisterWIDService _service;

        private string _dbSearch = Local;

        public ObjectRightWithWID ObjectRight => gvObjectsRightsList.CurrentRow?.DataBoundItem as ObjectRightWithWID;

        public ObjectRightSelectionExtendedView()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            Load += Form_Load;
            navigatorPanel.CurrentPageChanged += NavigatorPanel_CurrentPageChanged;
            navigatorPanel.PageSizeChanged += NavigatorPanel_PageSizeChanged;
            UpdateList();
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
                    Iswc = !string.IsNullOrWhiteSpace(txtISWC.Text) ? txtISWC.Text : string.Empty,
                    ObjectName = !string.IsNullOrWhiteSpace(txtObjectName.Text) ? txtObjectName.Text : string.Empty,
                    Performer = !string.IsNullOrWhiteSpace(txtPerformer.Text) ? txtPerformer.Text : string.Empty,
                    Author = !string.IsNullOrWhiteSpace(txtAuthorOrRightholder.Text) ? txtAuthorOrRightholder.Text : string.Empty
                };

                result = _service.GetObjectRightListBySearch(query);
            });

            bsObjectRightsView.DataSource = result.List;

            navigatorPanel.TotalPages = (int)Math.Ceiling((double)result.TotalItems / query.PageSize);

            waitingBar.StopWaiting();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnSearchLocal_Click(object sender, EventArgs e)
        {
            _dbSearch = Local;
            UpdateList();
        }

        private void btnSearchWID_Click(object sender, EventArgs e)
        {
            _dbSearch = WID;
            UpdateList();
        }

        private void NavigatorPanel_PageSizeChanged(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void NavigatorPanel_CurrentPageChanged(object sender, EventArgs e)
        {
            UpdateList();
        }
    }
}
