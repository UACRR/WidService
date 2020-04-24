using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Enums;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using IpsViewComponentLibrary.Extensions;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.PartnerControls
{
    public partial class CabinetPartnerForm : RadForm
    {
        private const string TitlePhis = "Кабінет представника (фізична особа)";
        private const string TitleJur = "Кабінет представника (юридична особа)";
        private const string SuccessAgrMsg = "Зміни в договорі збережено!";
        private const string ErrorAgrMsg = "Неможливо зберегти зміни в договорі!";
        private const string SuccessAnketaMsg = "Зміни в анкеті збережено!";
        private const string ErrorAnketaMsg = "Неможливо зберегти зміни в анкеті!";

        private readonly PartnerService _service;
        
        public Action UpdateDataAction { get; set; }

        private Customer _customer;
        private readonly PartnerCabinetAnketaPhisControl _phisControl = null;
        private readonly PartnerCabinetAnketaJurControl _jurControl = null;
        //public event ReturnViewEventHandler<PartnerClientListView> GetPartnerClientList;
        //public event ReturnViewEventHandler<PartnerAllFreeClientsView> GetFreeClientList;
        //public event SetPartnerEventHandler OnAddClientToPartner;
        //public event SetPartnerEventHandler OnDetachClientInPartner;
        //public event AgreementStatusChangeEventHandler ChangeStatusAgr;

        //public event SaveObjectEventHandler<AgreementAddPartner> OnSaveAgreement;
        //public event Func<AgreementAddPartner, Partner, bool> OnSaveAgreement;
        //public event GetCustomerByIdEventHandler UpdateCustomer;
        private readonly IAnketaControls _control;

        public CabinetPartnerForm(Customer customer)
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            Load += CabinetPartnerForm_Load;
            DialogResult = DialogResult.None;
            _service = PartnerService.GetInstance();
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
            _control.CancelClick += Anketa_CancelChangesClick;
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
            bsPartner.ResetBindings(false);
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
            var result = _service.SavePartner(_customer);
            MessageShow.ShowInfoByResult(SuccessAnketaMsg, ErrorAnketaMsg, result);
            UpdateDataAction?.Invoke();
        }

        private bool CtrlPartnerClients_OnDetachClientInPartner(int clientId, int partnerId)
        {
            return _service.RemovePartnerForCustomer(clientId, partnerId);
        }

        private bool CtrlPartnerClients_OnAddClientToPartner(int clientId, int partnerId)
        {
            return _service.SetPartnerForCustomer(clientId, partnerId);
        }

        private List<PartnerAllFreeClientsView> CtrlPartnerClients_GetFreeClientList(int custId)
        {
            return _service.GetView(typeof(PartnerAllFreeClientsView), "vTsk_6_ListFreeCln", null).ToListOfType<PartnerAllFreeClientsView>();
        }

        private void CabinetPartnerForm_Load(object sender, EventArgs e)
        {
            var list = _service.GetView(typeof(PartnerClientListView), "vTsk_6_ListPClient", _customer.CustId).ToListOfType<PartnerClientListView>();
            ctrlPartnerClients.SetData(list);
        }

        // підтвердити договір
        private void btnAcceptAgr_Click(object sender, EventArgs e)
        {
            var result = _service.AgreementPartnerStatusChange(_customer.CustId, CPartnerObjectStatus.Activate);
            if (result)
            {
                UpdateCustomer();
            }
        }

        private const string CloseAgreementConfirmMsg = "Ви дійсно хочете закрити договір з представником?";
        // закрити договір
        private void btnCloseAgr_Click(object sender, EventArgs e)
        {
            if (MessageShow.ConfirmAction(CloseAgreementConfirmMsg) == DialogResult.Yes)
            {
                var result = _service.AgreementPartnerStatusChange(_customer.CustId, CPartnerObjectStatus.Close);
                // use result
                UpdateCustomer();
            }
        }

        // зберегти зміни договору
        private void Save_Click(object sender, EventArgs e)
        {
            var agr = _customer.Partner.AgreementAddPartner.SingleOrDefault();

            var result = _service.UpdateAgreement(agr, _customer.Partner);
            UpdateDataAction?.Invoke();

            //var result = OnSaveAgreement?.Invoke(agr) ?? false;
            MessageShow.ShowInfoByResult(SuccessAgrMsg, ErrorAgrMsg, result);
        }

        // скасувати зміни договору
        private void Cancel_Click(object sender, EventArgs e)
        {
            UpdateCustomer();
        }

        // скасувати зміни анкети
        private void Anketa_CancelChangesClick(object sender, EventArgs e)
        {
            UpdateCustomer();
            _control.BeginBindings(_customer);
        }

        private void UpdateCustomer()
        {
            UpdateDataAction?.Invoke();
            var result = _service.GetPartner(_customer.CustId);
            _customer = result;
            BeginBinding();
        }
    }
}
