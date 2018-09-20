using System;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Events;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using ipsFormsDesign.Utilities;
using IpsViewComponentLibrary.AppController;
using IpsViewComponentLibrary.ObjectRightControls;
using IpsViewComponentLibrary.Utilities;

namespace IpsViewComponentLibrary.RightholderControls
{
    public class RightholderPresenter : IRightholderPresenter
    {
        private readonly IRightholderView _view;
        private readonly RightholderService _rightholderService;
        private readonly ObjectRightService _objectRightService;
        private readonly DialogService _dialogService;
        private Customer _customer;
        private AgreementAddRh _agreementAddRh;
        private AnketaPerson _anketaPerson;
        private bool _canClose;

        public RightholderPresenter(IRightholderView view)
        {
            _view = view;
            _view.Presenter = this;

            _rightholderService = new RightholderService();
            _objectRightService = new ObjectRightService();
            _dialogService = new DialogService();
        }

        public void ShowNew(int customerType)
        {
            _customer = _rightholderService.NewCustomer(customerType);
            SetViewData();
            _view.SetHeader("(Новий)");
            _view.Run();
        }

        public void Show(int custId)
        {
            _customer = _rightholderService.GetData(custId);
            SetViewData();
            _view.SetHeader(String.Format("{0} {1} {2}", _anketaPerson.LastName, _anketaPerson.FirstName, _anketaPerson.SurName));
            _view.Run();
        }

        private void SetViewData()
        {
            _view.CustomerDataSource = _customer;
            _anketaPerson = _customer.Person.AnketaPerson.FirstOrDefault();
            _view.AnketaPersonDataSource = _anketaPerson;
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

        public void CopyAddressFactToRegister()
        {
            _anketaPerson.ReAddress = _anketaPerson.FaAddress;
            _anketaPerson.ReCity = _anketaPerson.FaCity;
            _anketaPerson.ReCountry = _anketaPerson.FaCountry;
            _anketaPerson.ReRegion = _anketaPerson.FaRegion;
        }

        public void CopyAddressFactToLetter()
        {
            _anketaPerson.LeAddress = _anketaPerson.FaAddress;
            _anketaPerson.LeCity = _anketaPerson.FaCity;
            _anketaPerson.LeCountry = _anketaPerson.FaCountry;
            _anketaPerson.LeRegion = _anketaPerson.FaRegion;
        }

        public void CopyAddressRegisterToLetter()
        {
            _anketaPerson.LeAddress = _anketaPerson.ReAddress;
            _anketaPerson.LeCity = _anketaPerson.ReCity;
            _anketaPerson.LeCountry = _anketaPerson.ReCountry;
            _anketaPerson.LeRegion = _anketaPerson.ReRegion;
        }

        public void AddNewObject(int category)
        {
            if (category == 0)
                return;

            using (var view = new ObjectRightSrView())
            {
                var presenter = new ObjectRightSrPresenter(view);
                presenter.DefaultRightholder = new RightholderMainView { CustId = _customer.CustId, Name = String.Format("{0} {1} {2}", _anketaPerson.FirstName, _anketaPerson.SurName, _anketaPerson.LastName) };
                presenter.ShowNew(category);
            }
        }

        public void AddExistingObject()
        {
            using (var selectionView = new ObjectRightSelectionView())
            {
                selectionView.ObjectSelected += SelectionView_ObjectSelected;
                selectionView.ShowDialog();
            }
        }

        private void SelectionView_ObjectSelected(object sender, ObjectRightMainView selectedObject)
        {
            var selectedRightholder = new RightholderMainView { CustId = _customer.CustId, Name = String.Format("{0} {1} {2}", _anketaPerson.FirstName, _anketaPerson.SurName, _anketaPerson.LastName) }; ;
            var objectRightContainer = _objectRightService.GetData(selectedObject.ObjId);
            var objectRight = objectRightContainer.objectRight;

            if (objectRight.CopyRight.GetTotalRate() >= 100)
            {
                MessageBox.Show("Спільний відсоток володіння для вибраного об'єкта вже становить 100%.");
                return;
            }

            var objectAuthorRightholder = new ObjectAuthorRightholder(selectedRightholder);

            DialogResult dialogResult;
            using (var authorRightholderItemView = new AuthorRightholderItemView(objectAuthorRightholder, _objectRightService.GetDictionary(), objectRight.CategoryCode))
            {
                dialogResult = authorRightholderItemView.ShowDialog();
            }

            if (dialogResult == DialogResult.OK)
            {
                objectRight.AddObjectAuthorRightholder(objectAuthorRightholder);

                if (objectRight.CopyRight.GetTotalRate() > 100)
                {
                    MessageBox.Show("Спільний відсоток володіння з врахуванням доданого перевищує 100%. Об'єкт не доданий.");
                    return;
                }

                var result = _objectRightService.Save(objectRight);

                ApplicationController.Instance.EventAggregator.PublishEvent(new RightholderUpdatedEvent());
                ApplicationController.Instance.EventAggregator.PublishEvent(new ObjectRightUpdatedEvent());

                if (!result)
                    MessageBox.Show("Не вдалося зберегти зміни. Об'єкт не доданий.", "Помилка");
            }
        }
    }
}
