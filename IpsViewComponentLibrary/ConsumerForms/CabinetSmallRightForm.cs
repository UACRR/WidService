using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using IpsViewComponentLibrary.ConsumerControls.Calculation;
using IpsViewComponentLibrary.Extensions;
using Telerik.WinControls;

namespace IpsViewComponentLibrary.ConsumerForms
{
    public partial class CabinetSmallRightForm : Telerik.WinControls.UI.RadForm
    {
        private const string DefaultTitle = "Кабінет користувача";
        private Customer _customer;

        private readonly ClientSmallRightService _service;
        
        public event UpdateCustomerDataEventHandler OnUpdate;

        public CabinetSmallRightForm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            cabinet.Rights = TypeRights.SmallRights;

            cabinet.UpdateData += UpdateData;
            cabinet.SaveCustomer += (customer) => _service.Save(customer);

            var _partnerService = PartnerService.GetInstance();

            cabinet.GetPartner += (custId) => _partnerService.GetPartnerAnketa(custId);
            cabinet.OnSetPartner += (clientId, partnerId) => _partnerService.SetPartnerForCustomer(clientId, partnerId);
            cabinet.OnChangePartner += (clientId, partnerId, oldPartnerId) => _partnerService.ChangePartnerForCustomer(clientId, partnerId, oldPartnerId);
            cabinet.OnRemovePartner += (clientId, partnerId) => _partnerService.RemovePartnerForCustomer(clientId, partnerId);
            cabinet.OnGetPartnerListNeed += () => _partnerService.GetPartnerList();
            
            cabinet.OnAddNewFile += (custId, typeDocument, comment, fileName) => _service.uploadDocument(custId, typeDocument, comment, fileName);
            cabinet.OnViewCurrentFile += Cabinet_OnViewCurrentFile;
            cabinet.OnDeleteCurrentFile += (id) => _service.DeleteFileById(id);

            _service = ClientSmallRightService.GetInstance();
            new CalculationInfoControlPresenter(cabinet.calculationCtrl, _service);
        }

        public string Title
        {
            get => Text;
            set => Text = string.IsNullOrWhiteSpace(value) ? DefaultTitle : string.Concat(DefaultTitle, $": {value}");
        }

        public void SetCustomer(Customer customer)
        {
            _customer = customer;
            cabinet.SetCustomerData(_customer);
        }

        //оновлення даних
        private void UpdateData(int id)
        {
            //OnUpdate?.Invoke(id);

            var service = ClientSmallRightService.GetInstance();

            Customer mainCust = null, regCust = null;
            Task[] getCustData = new Task[2];

            getCustData[0] = Task.Run(() => { mainCust = service.GetData(id); });
            getCustData[1] = Task.Run(() => { regCust = service.GetRatedListForCust(id); });
            Task.WaitAll(getCustData);

            CloneRegisterRL(mainCust, regCust);

            ApplicationCustomerData.GetInstance().CurrentCustomer = mainCust;
            
            SetCustomer(mainCust);
            
            WindowsFormsVisible.ShowHiddenWindow(this);
        }

        public static void CloneRegisterRL(Customer mainCust, Customer regCust)
        {
            if (mainCust == null || regCust == null)
                return;

            // Прив'язати розрахункові листи до договорів
            foreach (var mainLic in mainCust.Client.LicenseAgreement)
            {
                var destLic = regCust.Client.LicenseAgreement.SingleOrDefault(rec => rec.LicId == mainLic.LicId);
                if (destLic == null) continue;

                foreach (var mainPeriod in mainLic.PaidPeriod)
                {
                    var destPeriod = destLic.PaidPeriod.SingleOrDefault(rec => rec.PeriodId == mainPeriod.PeriodId);
                    if (destPeriod == null) continue;

                    foreach (var destRl in destPeriod.RegisterRatedList)
                    {
                        var mainRl = mainPeriod.RegisterRatedList.SingleOrDefault(rec => rec.RmId == destRl.RmId);
                        if (mainRl == null)
                            mainPeriod.RegisterRatedList.Add(destRl);
                    }
                }
            }

            // sync anketa
            regCust.Company = mainCust.Company;
            regCust.Person = mainCust.Person;
        }

        private void CabinetSmallRightForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        #region EVENT HANDLERS

        private void Cabinet_OnViewCurrentFile(int custId, int typeDocument, string fileName)
        {
            // TODO: змінити підхід
            try
            {
                string fullpath = @"DocumentFiles\" + fileName;
                if (!Directory.Exists("DocumentFiles"))
                    Directory.CreateDirectory("DocumentFiles");

                using (var fileStream = File.Create(fullpath))
                {
                    using (var stream = _service.DownloadDocument(custId, typeDocument, fileName))
                    {
                        stream.CopyTo(fileStream);
                        stream.Close();
                    }
                }

                if (File.Exists(fullpath))
                {
                    System.Diagnostics.Process.Start(fullpath);
                }
            }
            catch (Exception excpt)
            {
                MessageShow.ShowError(excpt.Message);
            }
        }

        #endregion
    }
}
