using System.Linq;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;

namespace IpsViewComponentLibrary.RightholderControls
{
    public class RightholderPresenter
    {
        private readonly RightholderView _view;
        private readonly RightholderService _rightholderService;
        private Customer _customer;

        public RightholderPresenter(RightholderView view)
        {
            _view = view;
            _view.Presenter = this;
            _rightholderService = new RightholderService();
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
    }
}
