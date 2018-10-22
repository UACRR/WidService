using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using IpsViewComponentLibrary.Extensions;
using IpsViewComponentLibrary.PartnerControls;
using Telerik.WinControls;

namespace IpsViewComponentLibrary.ConsumerForms
{
    public partial class CabinetPartnerForm : Telerik.WinControls.UI.RadForm
    {
        private const string TitlePhis = "Кабінет представника (фізична особа)";
        private const string TitleJur = "Кабінет представника (юридична особа)";

        private Customer _customer;
        private PartnerCabinetAnketaPhisControl _phisControl = null;
        private PartnerCabinetAnketaJurControl _jurControl = null;
        public event ReturnViewEventHandler<PartnerClientListView> GetPartnerClientList;
        public event ReturnViewEventHandler<PartnerAllFreeClientsView> GetFreeClientList;
        public event SetPartnerEventHandler OnAddClientToPartner;
        public event SetPartnerEventHandler OnDetachClientInPartner;
        public event AgreementStatusChangeEventHandler ChangeStatusAgr;
        public event SaveCustomerEventHandler OnSaveCustomer;
        public event GetCustomerByIdEventHandler UpdateCustomer;
        public IAnketaControls control;

        public CabinetPartnerForm(Customer customer)
        {
            InitializeComponent();
            Load += CabinetPartnerForm_Load;
            DialogResult = DialogResult.None;
            _customer = customer;

            switch (_customer.CustType)
            {
                case 1: // фіз особа
                    control = Architector.IncludeInstanceWhithReturn(pvAnketa, _phisControl);
                    ctrlPartnerClients.ClientName = _customer.Person.AnketaPerson.SingleOrDefault(); //найменування клієнта
                    Text = TitlePhis;
                    break; 
                case 3: // юр особа
                    control = Architector.IncludeInstanceWhithReturn(pvAnketa, _jurControl);
                    ctrlPartnerClients.ClientName = _customer.Company.AnketaCompany.SingleOrDefault(); //найменування клієнта
                    Text = TitleJur;
                    break;
            }
            control.BeginBindings(_customer);
            control.SaveClick += SaveClick;

            BeginBinding();
            SubscribeEvents();
        }

        public sealed override string Text
        {
            get => base.Text;
            set => base.Text = value;
        }

        private void BeginBinding()
        {
            // договір
            ctrlAgreement.AgreementDataSource = _customer?.Partner?.AgreementAddPartner?.SingleOrDefault();
            // статус договору
            var statusid = _customer?.Partner?.AgreementAddPartner?.SingleOrDefault()?.AgrStatus;
            lblStatusName.Text = IpsGlobal.AnketaDictionaties.agreementStatus.SingleOrDefault(rec => rec.CodeI == statusid)?.Name;

            // умови договору
            ctrlConditions.AgreementAddPartnerDataSource = _customer?.Partner?.AgreementAddPartner?.SingleOrDefault();
        }

        private void SubscribeEvents()
        {
            ctrlPartnerClients.GetFreeClientList += CtrlPartnerClients_GetFreeClientList;
            ctrlPartnerClients.OnAddClientToPartner += CtrlPartnerClients_OnAddClientToPartner;
            ctrlPartnerClients.OnDetachClientInPartner += CtrlPartnerClients_OnDetachClientInPartner;
            ctrlPartnerClients.UpdateData += CabinetPartnerForm_Load;
        }

        private void SaveClick(object sender, bool e)
        {
            OnSaveCustomer?.Invoke(_customer);
        }

        private bool CtrlPartnerClients_OnDetachClientInPartner(int clientId, int partnerId)
        {
            return OnDetachClientInPartner?.Invoke(clientId, partnerId) ?? false;
        }

        private bool CtrlPartnerClients_OnAddClientToPartner(int clientId, int partnerId)
        {
            return OnAddClientToPartner?.Invoke(clientId, partnerId) ?? false;
        }

        private List<PartnerAllFreeClientsView> CtrlPartnerClients_GetFreeClientList(int custId)
        {
            return GetFreeClientList?.Invoke(custId);
        }

        private void CabinetPartnerForm_Load(object sender, EventArgs e)
        {
            var list = GetPartnerClientList?.Invoke(_customer.CustId);
            ctrlPartnerClients.SetData(list);
        }

        // підтвердити
        private void btnAcceptAgr_Click(object sender, EventArgs e)
        {
            var result = ChangeStatusAgr?.Invoke(_customer.CustId, CPartnerObjectStatus.Activate);
            if (result ?? false)
            {
                _customer = UpdateCustomer?.Invoke(_customer.CustId);
                BeginBinding();
            }
        }

        // закрити
        private void btnCloseAgr_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ви дійсно хочете закрити договір з представником?", "Підтверження", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var result = ChangeStatusAgr?.Invoke(_customer.CustId, CPartnerObjectStatus.Close);
                if (result ?? false)
                {
                    _customer = UpdateCustomer?.Invoke(_customer.CustId);
                    BeginBinding();
                }
            }
        }

        
    }
}
