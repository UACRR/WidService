using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Enums;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using IpsCommonTypes.Enums;
using IpsViewComponentLibrary;
using IpsViewComponentLibrary.ConsumerControls;
using IpsViewComponentLibrary.ConsumerControls.Calculation;
using IpsViewComponentLibrary.ConsumerControls.SmallRight;
using IpsViewComponentLibrary.ConsumerForms;
using IpsViewComponentLibrary.Extensions;
using Telerik.WinControls.UI;
using WordApplication = Microsoft.Office.Interop.Word.Application;
using ExcelApplication = Microsoft.Office.Interop.Excel.Application;

namespace ConsumerBigRightWorkplace.Presenters
{
    class BigRightPresenter : IUpdateProviderBigRight
    {
        private const string AddNewConsumerSuccess = "Нового користувача додано!";
        private const string AddNewConsumerError = "Не вдалося додати нового користувача!";

        private CabinetBigRightForm _localcabinetBigRightForm;
        private CabinetBigRightForm _cabinetBigRightForm => _localcabinetBigRightForm ?? ( _localcabinetBigRightForm = new CabinetBigRightForm());

        private readonly ConsumerBigRightService _service;
        private readonly PartnerService _partnerService;
        private readonly ConsumersViewBigRightControl _mainGrid;

        private ConsumersBigRightFilter _currentNodeValue = ConsumersBigRightFilter.None;
        private ConsumersBigRightCategoryFilter _currentNodeDocType = ConsumersBigRightCategoryFilter.None;

        public BigRightPresenter(RadTreeView treeView, ConsumersViewBigRightControl mainGrid)
        {
            _service = ConsumerBigRightService.GetInstance();
            _partnerService = PartnerService.GetInstance();
            _mainGrid = mainGrid;
            treeView.SelectedNodeChanged += TreeView_SelectedNodeChanged;
            SubscribeEvents();
        }

        //всі підписки на події в контролах
        private void SubscribeEvents()
        {
            _mainGrid.OnAddNewCustomer += CreateNewCustomer;
            _mainGrid.OnLoadCustomerCabinetNeed += LoadCustomerCabinet;
        }

        //зміна даних по фільтру
        private void TreeView_SelectedNodeChanged(object sender, RadTreeViewEventArgs e)
        {
            if (e.Node.Value is ConsumersBigRightFilter @curEnum)
            {
                _currentNodeDocType = e.Node.Parent?.Value is ConsumersBigRightCategoryFilter @element ? @element : ConsumersBigRightCategoryFilter.All;
                _currentNodeValue = @curEnum;
            }
            else
            {
                _currentNodeDocType = e.Node.Value is ConsumersBigRightCategoryFilter @element ? @element : ConsumersBigRightCategoryFilter.GenAgreement;
                _currentNodeValue = ConsumersBigRightFilter.All;
            }
            // _currentNodeValue = (e.Node.Value is ConsumerFilterEnum @enum ? @enum : ConsumerFilterEnum.None);
            // Передати в поточний контрол зміну фільтра ???
            _mainGrid.DataSource = _service.GetMainBigRightView(_currentNodeDocType, _currentNodeValue);
        }

        //створити нового користувача
        private void CreateNewCustomer(object sender, EventArgs e)
        {
            int custType = 3; // Юридична особа
            var customer = _service.NewCustomer(custType);
            using (var form = new AnketaConsumerJurForm(customer, _service.GetAutoCompleteList, _service.GetData, TypeRights.BigRights))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var relust = _service.Save(customer);
                    MessageShow.ShowInfoByResult(AddNewConsumerSuccess, AddNewConsumerError, relust);
                }
            }
            UpdateDataGrid();
        }

        /// <summary>
        /// Відкрити кабінет користувача великих прав
        /// </summary>
        /// <param name="item"></param>
        private void LoadCustomerCabinet(ConsumerBigRightView item)
        {
            ViewsSingleton.SetConsumerBigRightView(item);
            if (!_cabinetBigRightForm.IsInit)
            {
                _cabinetBigRightForm.cabinet.UpdateDatAction = UpdateDataGrid;
                _cabinetBigRightForm.IsInit = true;
            }

            // завантаження даних
            _cabinetBigRightForm.cabinet.LoadData(item.CustId);
            _cabinetBigRightForm.Title = item.Name;

            WindowsFormsVisible.ShowHiddenWindow(_cabinetBigRightForm);
        }

        public void UpdateDataGrid()
        {
            var viewList = _service.GetMainBigRightView(_currentNodeDocType, _currentNodeValue);
            _mainGrid.DataSource = viewList;

            if (viewList == null || ViewsSingleton.ConsumerBigRightView == null)
                return;

            var item = viewList.SingleOrDefault(rec => rec.CustId == ViewsSingleton.ConsumerBigRightView.CustId);
            ViewsSingleton.SetConsumerBigRightView(item);
            _cabinetBigRightForm.Title = item?.Name;
        }
    }
}
