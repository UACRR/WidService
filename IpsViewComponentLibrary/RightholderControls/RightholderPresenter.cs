using System;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Events;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using IpsViewComponentLibrary.AppController;
using IpsViewComponentLibrary.Utilities;

namespace IpsViewComponentLibrary.RightholderControls
{
    public class RightholderPresenter : IRightholderPresenter
    {
        private readonly IRightholderView _view;
        private readonly RightholderService _rightholderService;
        private readonly DialogService _dialogService;
        private Customer _customer;
        private AgreementAddRh _agreementAddRh;
        private bool _canClose;

        public RightholderPresenter(IRightholderView view)
        {
            _view = view;
            _view.Presenter = this;

            _rightholderService = new RightholderService();
            _dialogService = new DialogService();
        }

        public void ShowNew(int customerType)
        {
            _customer = _rightholderService.NewCustomer(customerType);
            SetViewData();
            _view.Run();
        }

        public void Show(int custId)
        {
            _customer = _rightholderService.GetData(custId);
            SetViewData();
            _view.Run();
        }

        private void SetViewData()
        {
            _view.CustomerDataSource = _customer;
            _view.AnketaPersonDataSource = _customer.Person.AnketaPerson;
            _agreementAddRh = _customer.AgreementMaster.FirstOrDefault()?.AgreementAddRh?.FirstOrDefault();
            _view.AgreementAddRhDataSource = _agreementAddRh;
            _view.RightholderDataSource = _customer.RightHolder;
            _view.BankAccountDataSource = _customer.BankAccount;
            _view.TermsOfServiceDataSource = _customer.RightHolder.TermsOfService.Select(rec => new TermsOfServiceWrapper(rec));
        }

        public void SetAgreementRightholderStatus(AgreementStatuses newStatus)
        {
            _agreementAddRh.AgrStatus = (int)newStatus;

            if (newStatus == AgreementStatuses.Closed)
                _customer.Status = (int)RightholderStatusType.Closed;
            else
                _customer.Status = (int)((RightholderStatusType)newStatus);
        }

        public void Save(bool accept)
        {
            if (_customer == null)
                return;

            // TODO: fix it. temporarily disable validation on saving rightholder.
            // the controls doesn't update data until the controls are made visible.
            // so if control is situated on invisible tabs, the text property = ""
            // and _view.IsValid returns a false, though it is valid.
            //if (!_view.IsValid)
            //{
            //    _dialogService.ShowError((IWin32Window)_view, "Не корректно введені дані.");
            //    return;
            //}

            _canClose = true;

            if (accept)
                _customer.Status = 2; // Активний

            var result = _rightholderService.Save(_customer);

            if (result)
            {
                ApplicationController.Instance.EventAggregator.PublishEvent(new RightholderUpdatedEvent());
                _view.Hide();
            }
            else
                _dialogService.ShowError((IWin32Window)_view, "Не вдалося зберегти правовласника.");
        }

        public void Close()
        {
            if (!_canClose)
                _canClose = _dialogService.ClosingIsConfirmed((IWin32Window)_view);
            
            if (_canClose)
                _view.Hide();
        }
    }
}
