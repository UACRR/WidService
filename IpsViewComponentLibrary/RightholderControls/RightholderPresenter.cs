using System;
using System.Linq;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Events;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using IpsViewComponentLibrary.AppController;
using IpsViewComponentLibrary.Utilities;

namespace IpsViewComponentLibrary.RightholderControls
{
    public class RightholderPresenter
    {
        private readonly RightholderView _view;
        private readonly RightholderService _rightholderService;
        private readonly DialogService _dialogService;
        private Customer _customer;

        public RightholderPresenter(RightholderView view)
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
            _view.AgreementAddRhDataSource = _customer.AgreementMaster.FirstOrDefault()?.AgreementAddRh;
            _view.RightholderDataSource = _customer.RightHolder;
            _view.BankAccountDataSource = _customer.BankAccount;
            _view.TermsOfServiceDataSource = _customer.RightHolder.TermsOfService.Select(rec => new TermsOfServiceWrapper(rec));
        }

        internal void Save(bool accept)
        {
            if (_customer == null)
                return;

            if (accept)
                _customer.Status = 2; // Активний

            var result = _rightholderService.Save(_customer);

            if (result)
            {
                ApplicationController.Instance.EventAggregator.PublishEvent(new RightolderUpdatedEvent());
                _view.Close();
            }
            else
                _dialogService.ShowError(_view, "Не вдалося зберегти правовласника.");
        }
    }
}
