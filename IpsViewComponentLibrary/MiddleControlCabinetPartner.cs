using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary.ConsumerDialogForms;

namespace IpsViewComponentLibrary
{
    public partial class MiddleControlCabinetPartner : UserControl
    {
        public event SetPartnerEventHandler OnSetPartner;
        public event SetPartnerEventHandler OnRemovePartner;
        public event ChangePartnerEventHandler OnChangePartner;

        public event GetPartnerList OnGetPartnerListNeed;
        private List<AnketaPerson> _anketaPersons;
        private Customer _customer;
        private int _cientId;
        public MiddleControlCabinetPartner()
        {
            InitializeComponent();
        }

        public void SetPartnerData(Customer customer, int cientId)
        {
            var item = customer?.Person?.AnketaPerson?.SingleOrDefault();
            var agreement = customer?.Partner?.AgreementAddPartner?.SingleOrDefault();
            _customer = customer;
            _cientId = cientId;
            lblFullName.Text = item?.LastName + " " + item?.FirstName + " " + item?.SurName;
            lblAgrDate.Text = agreement?.AgrDate?.ToString("d");
            lblAgrStatus.Text = IpsGlobal.AnketaDictionaties?.agreementStatus?.SingleOrDefault(r => r?.CodeI == agreement?.AgrStatus)?.Name;
            lblAgrNumber.Text = agreement?.AgrNumber;
            lblMobile.Text = item?.PhoneMobileMain;
            lblEmail.Text = item?.EMail;
        }

        //змінити представника
        private void btnChangePartner_Click(object sender, EventArgs e)
        {
            SelectPartner selectPartner = new SelectPartner(_customer?.CustId)
            {
                StartPosition = FormStartPosition.CenterParent
            };
            selectPartner.SetPartnerList(OnGetPartnerListNeed?.Invoke());
            
            if (selectPartner.ShowDialog() == DialogResult.Yes)
            {
                if(selectPartner.PartnerId != null)
                {
                    if(_customer?.CustId == null) // додати
                        OnSetPartner?.Invoke(_cientId, (int)selectPartner.PartnerId);
                    if(_customer?.CustId != null) // змінити
                        OnChangePartner?.Invoke(_cientId, (int)selectPartner.PartnerId, _customer.CustId);
                }
            }
        }

        //видалити представника
        private void btnRemovePartner_Click(object sender, EventArgs e)
        {
            if (_customer?.CustId != null)
                OnRemovePartner?.Invoke(_cientId, _customer.CustId);
        }
    }
}
