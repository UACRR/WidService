using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Model;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.ConsumerForms
{
    public partial class AnketaConsumerJurForm : RadForm
    {
        private const string DefaultTitle = "Анкета користувача [юридична особа]";

        private Customer _customer;

        private readonly Func<int, Customer> _getCustomerAnketa;
        private readonly Customer _newCustomerCopy = null;

        public AnketaConsumerJurForm(Customer customer, Func<string, IList<AutoCompleteData>> getAutoCompList,
            Func<int, Customer> getCustomerAnketa, TypeRights typeRights = TypeRights.SmallRights )
        {
            InitializeComponent();
            ctrlConsumerAnketa.ctrlClientName.TextNameChanged += CtrlClientName_TextNameChanged;
            _newCustomerCopy = customer.CloneJson();

            //_getAutoCompList = getAutoCompList;
            _getCustomerAnketa = getCustomerAnketa;
            _customer = customer;
            
            ctrlTabNavigationExpanded.SetDefaultState(ctrlConsumerAnketa.GetPageView, FLoadType.Create);
            ctrlTabNavigationExpanded.SaveClick += Save;

            ctrlConsumerAnketa.TypeRights = typeRights;
            ctrlConsumerAnketa.SetDataAndDictionaries(_customer);
            ctrlConsumerAnketa.InitializeControl(getAutoCompList, GetExistsCustomer, ConsumerAnketeType.CreateNewAnketa);
        }

        private void Save(object sender, bool e)
        {
            // відразу підтверджений договір?
            var status = e ? 2 : 0;
            _customer.Status = status;
            _customer.AgreementMaster.SingleOrDefault().AgrStatus = status;
            _customer.Company.AnketaCompany.SingleOrDefault().Status = status;
            _customer.Client.LicenseAgreement.SingleOrDefault().LicStatus = status;
            _customer.Client.LicenseAgreement.SingleOrDefault().Agr.AgreementAddBr.SingleOrDefault().AgrStatus = status;
            _customer.Client.LicenseAgreement.SingleOrDefault().LicenseAgrParam.SingleOrDefault().LicStatus = status;
            
            DialogResult = DialogResult.OK;
        }

        private void CtrlClientName_TextNameChanged(object sender, string e)
        {
            Text = e.Length == 0 ? DefaultTitle : string.Concat(DefaultTitle, $": {e}");
        }

        public Customer GetExistsCustomer(int custId)
        {
            Customer retCustomer = null;
            if (custId == 0)
            {
                retCustomer = _newCustomerCopy.CloneJson();
            }
            else
            {
                retCustomer = _getCustomerAnketa(custId);
                var newLic = _newCustomerCopy.Client.LicenseAgreement.First().CloneJson();
                retCustomer.Client.LicenseAgreement.Add(newLic);
            }

            _customer = retCustomer;
            ctrlConsumerAnketa.SetDataAndDictionaries(retCustomer);
            ctrlConsumerAnketa.ReInitControl();

            return retCustomer;
        }
    }
}
