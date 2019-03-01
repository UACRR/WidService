using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using IpsViewComponentLibrary.Extensions;

namespace IpsViewComponentLibrary.PartnerControls
{
    public partial class CabinetPartnerForm : Telerik.WinControls.UI.RadForm
    {
        private const string TitlePhis = "Кабінет представника (фізична особа)";
        private const string TitleJur = "Кабінет представника (юридична особа)";
        private const string SuccessAgrMsg = "Зміни в договорі збережено!";
        private const string ErrorAgrMsg = "Неможливо зберегти зміни в договорі!";
        private const string SuccessAnketaMsg = "Зміни в анкеті збережено!";
        private const string ErrorAnketaMsg = "Неможливо зберегти зміни в анкеті!";

        private Customer _customer;
        private readonly PartnerCabinetAnketaPhisControl _phisControl = null;
        private readonly PartnerCabinetAnketaJurControl _jurControl = null;
        public event ReturnViewEventHandler<PartnerClientListView> GetPartnerClientList;
        public event ReturnViewEventHandler<PartnerAllFreeClientsView> GetFreeClientList;
        public event SetPartnerEventHandler OnAddClientToPartner;
        public event SetPartnerEventHandler OnDetachClientInPartner;
        public event AgreementStatusChangeEventHandler ChangeStatusAgr;
        public event SaveCustomerEventHandler OnSaveCustomer;
        public event SaveObjectEventHandler<AgreementAddPartner> OnSaveAgreement;
        public event GetCustomerByIdEventHandler UpdateCustomer;
        private IAnketaControls _control;

        public CabinetPartnerForm(Customer customer)
        {
            InitializeComponent();
            Load += CabinetPartnerForm_Load;
            DialogResult = DialogResult.None;
            _customer = customer;

            switch (_customer.CustType)
            {
                case 1: // фіз особа
                    _control = Architector.IncludeInstanceWhithReturn(pvAnketa, _phisControl);
                    ctrlPartnerClients.ClientName = _customer.Person.AnketaPerson.SingleOrDefault(); //найменування клієнта
                    Text = TitlePhis;
                    break; 
                case 3: // юр особа
                    _control = Architector.IncludeInstanceWhithReturn(pvAnketa, _jurControl);
                    ctrlPartnerClients.ClientName = _customer.Company.AnketaCompany.SingleOrDefault(); //найменування клієнта
                    Text = TitleJur;
                    checkPartnerInternal.Visible = false;
                    break;
            }
            _control.BeginBindings(_customer);
            _control.SaveClick += SaveClick;
            ctrlSaveCancelButtons.SaveClck += Save_Click;
            ctrlSaveCancelButtons.CancelClick += Cancel_Click;
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
            var agrStatus = _customer?.Partner?.AgreementAddPartner?.SingleOrDefault()?.AgrStatus;
            lblStatusName.Text = IpsGlobal.AnketaDictionaties.agreementStatus.SingleOrDefault(rec => rec.CodeI == agrStatus)?.Name;
            // можливість змінювати договір
            btnAcceptAgr.Enabled = agrStatus != 2;
            ctrlSaveCancelButtons.Enabled = agrStatus != 2;
            ctrlAgreement.IsReadOnly = agrStatus == 2;
            // умови договору
            ctrlConditions.AgreementAddPartnerDataSource = _customer?.Partner?.AgreementAddPartner?.SingleOrDefault();
            ctrlConditions.IsReadOnly = agrStatus == 2;

            bsPartner.DataSource = _customer?.Partner;
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
            var result = OnSaveCustomer?.Invoke(_customer) ?? false;
            MessageShow.ShowInfoByResult(SuccessAnketaMsg, ErrorAnketaMsg, result);
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

        // підтвердити договір
        private void btnAcceptAgr_Click(object sender, EventArgs e)
        {
            var result = ChangeStatusAgr?.Invoke(_customer.CustId, CPartnerObjectStatus.Activate);
            if (result ?? false)
            {
                _customer = UpdateCustomer?.Invoke(_customer.CustId);
                BeginBinding();
            }
        }

        // закрити договір
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

        // зберегти зміни договору
        private void Save_Click(object sender, EventArgs e)
        {
            var result = OnSaveAgreement?.Invoke(_customer.Partner.AgreementAddPartner.SingleOrDefault()) ?? false;
            MessageShow.ShowInfoByResult(SuccessAgrMsg, ErrorAgrMsg, result);
        }

        // скасувати зміни договору
        private void Cancel_Click(object sender, EventArgs e)
        {
            _customer = UpdateCustomer?.Invoke(_customer.CustId);
            BeginBinding();
        }
    }
}
