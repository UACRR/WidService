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
        private bool _saved;

        public RightholderPresenter(IRightholderView view)
        {
            _view = view;
            _view.Presenter = this;

            //_view.FormClosing += View_FormClosing; // to fix

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

        public void Save(bool accept)
        {
            if (_customer == null)
                return;

            _saved = true;

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
            if (!_saved && !_dialogService.ClosingIsConfirmed((IWin32Window)_view))
                return;

            _view.Hide();
        }
    }
}
