using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ipsFormsDesign;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary
{
    public partial class AnketaConsumerForm : RadForm
    {
        private Customer _customer;
        
        private readonly Func<int, Customer> _getCustomerAnketa;
        private readonly Customer _newCustomerCopy = null;

        //private readonly Func<string, IList<AutoCompleteData>> _getAutoCompList;

        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="customer">Споживач</param>
        /// <param name="dictionaties">Словник</param>
        /// <param name="getAutoCompList"></param>
        /// <param name="getCustomerAnketa"></param>
        /// <param name="isNew"></param>
        /// <param name="typeRights"></param>
        public AnketaConsumerForm(Customer customer, Func<string, IList<AutoCompleteData>> getAutoCompList,
            Func<int, Customer> getCustomerAnketa, TypeRights typeRights = TypeRights.SmallRights )
        {
            InitializeComponent();

            _newCustomerCopy = customer.CloneJson();

            //_getAutoCompList = getAutoCompList;
            _getCustomerAnketa = getCustomerAnketa;
            _customer = customer;

            ctrlTabNavigation.SetDefaultState(ctrlConsumerAnketa.GetPageView, FLoadType.Create);
            ctrlTabNavigation.SaveClick += Save;

            ctrlConsumerAnketa.TypeRights = typeRights;
            ctrlConsumerAnketa.SetDataAndDictionaries(_customer);
            ctrlConsumerAnketa.InitializeControl(getAutoCompList, GetExistsCustomer, ConsumerAnketeType.CreateNewAnketa);
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

        private void Save(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
