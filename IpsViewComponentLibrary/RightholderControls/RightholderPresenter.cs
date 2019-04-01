using System;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Events;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Presenters;
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
        private AgreementMaster _agreementMaster;
        private AgreementAddRh _agreementAddRh;
        private AnketaPerson _anketaPerson;
        //define Anketa Exteral
        private AnketaExternal _anketaExternal;
        private AnketaCompany _anketaCompany;
        private bool _isCompany;
        private bool _canClose;
        public IUniqueChecker UniquChecker { get; private set; }


        public RightholderPresenter(IRightholderView view)
        {
            _view = view;
            _view.Presenter = this;

            _rightholderService = new RightholderService();
            _objectRightService = new ObjectRightService();
            _dialogService = new DialogService();

            if (!IpsGlobal.Instances.Keys.Contains(typeof(IUniqueChecker)))
            {
                UniquChecker = new UniqueCheckerPresenter(_rightholderService);
                IpsGlobal.addInstance(typeof(IUniqueChecker), UniquChecker);
            }
        }

        ~RightholderPresenter()
        {
            if (UniquChecker != null)
                IpsGlobal.removeInstance(typeof(IUniqueChecker));
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

            if (_customer.CustType == 3)
                _view.SetHeader(_anketaCompany.Name);
            else if (_customer.CustType == 5)
            {
                //set title name for Current Action
                _view.SetHeader(_anketaExternal.Name);
            } else
                _view.SetHeader(String.Format("{0} {1} {2}", _anketaPerson.LastName, _anketaPerson.FirstName, _anketaPerson.SurName));

            _view.Run();
        }

        private void SetViewData()
        {
            _view.CustomerDataSource = _customer;
            _agreementMaster = _customer.AgreementMaster.FirstOrDefault();
            _agreementAddRh = _agreementMaster?.AgreementAddRh?.FirstOrDefault();
            _view.AgreementAddRhDataSource = _agreementAddRh;
            _view.RightholderDataSource = _customer.RightHolder;
            _view.BankAccountDataSource = _customer.BankAccount;
            _view.TermsOfServiceDataSource = _customer.RightHolder.TermsOfService.Select(rec => new TermsOfServiceWrapper(rec));
            

            //add condition for ignore External anketa
            //_isCompany = _customer.CustType == 3 && _customer.CustType != 5;

            if (_customer.CustType == 3)
            {
                _anketaCompany = _customer.Company.AnketaCompany.FirstOrDefault();
                _view.AnketaCompanyDataSource = _anketaCompany;
            } else if (_customer.CustType == 5)
            {
                //get data for Exteral Anketa
                _anketaExternal = _customer.AnketaExternal;
                //set data to data source
                _view.AnketaExternalDataSource = _anketaExternal;
                //set data for term of service of the external anketa
                _view.TermsOfServiceExternalAnketaDataSource = _customer.RightHolder.TermsOfService.Select(rec => new TermsOfServiceWrapper(rec));
            }
            else
            {
                _anketaPerson = _customer.Person.AnketaPerson.FirstOrDefault();
                _view.AnketaPersonDataSource = _anketaPerson;
            }
        }

        public void SetAgreementRightholderStatus(AgreementStatuses newStatus)
        {
            _agreementMaster.AgrStatus = (int)newStatus;
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
            {
                SetAgreementRightholderStatus(AgreementStatuses.Active);
            }

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

        public void UploadFromExcel()
        {
            var openDialog = new OpenFileDialog { AddExtension = true, DefaultExt = "xlsx", Filter = "Excel Files(*.xlsx;*xls)|*.xls;*.xlsx" };
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                var _uploader = new ObjectRightLoaderFacade();
                _uploader.UploadFromExcel(openDialog.FileName);
            }
        }

        public void SetAgreementNumber()
        {
            if (string.IsNullOrEmpty(_agreementAddRh.AgrNumber))
                _agreementAddRh.AgrNumber = _customer.RightHolder.InnerCode;
        }

        private void SelectionView_ObjectSelected(object sender, ObjectRightMainView selectedObject)
        {
            var selectedRightholder = new RightholderMainView { CustId = _customer.CustId, Name = String.Format("{0} {1} {2}", _anketaPerson.FirstName, _anketaPerson.SurName, _anketaPerson.LastName) }; ;

            var objectAuthorRightholder = new ObjectAuthorRightholder(selectedRightholder);

            DialogResult dialogResult;
            using (var authorRightholderItemView = new AuthorRightholderItemView(objectAuthorRightholder, _objectRightService.GetDictionary(), selectedObject.CategoryCode))
            {
                dialogResult = authorRightholderItemView.ShowDialog();
            }

            if (dialogResult == DialogResult.OK)
            {
                var result = _objectRightService.AddAuthorRightholderForObject(selectedObject.ObjId, objectAuthorRightholder, out string error);

                if (result)
                {
                    ApplicationController.Instance.EventAggregator.PublishEvent(new RightholderUpdatedEvent());
                    ApplicationController.Instance.EventAggregator.PublishEvent(new ObjectRightUpdatedEvent());
                }
                else
                {
                    _dialogService.ShowError((IWin32Window)_view, error);
                }
            }
        }
    }
}
