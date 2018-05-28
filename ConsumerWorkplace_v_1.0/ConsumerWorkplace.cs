using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using Telerik.WinControls;



namespace ConsumerWorkplace_v_1._0
{
    public partial class ConsumerWorkplace : Telerik.WinControls.UI.RadForm, IConsumerForm
    {
        private bool nextPage = false;
        private sbyte validTabs = 0;


        public event Func<bool> Save;

        public ConsumerWorkplace()
        {
            InitializeComponent();
            rpvConsumers.ViewElement.Visibility = ElementVisibility.Hidden; // приховання вкладок

        }

        /// <summary>
        /// Перехід на редагування Споживача
        /// </summary>
        private void SetConsumerPageView()
        {
            rpvConsumers.SelectedPage = pageConsumersAnketa;
            pageAllAnketa.SelectedPage = pvConsumerClientName;

            foreach (var page in pageAllAnketa.Pages)
            {
                page.Item.ForeColor = Color.DarkGray;
            }
            pageAllAnketa.Pages[0].Item.ForeColor = DefaultForeColor;
        }
        /// <summary>
        /// Кнопка створення нової анкети ЮРИДИЧНОЇ особи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddJuridicalPerson_Click(object sender, EventArgs e)
        {
            int custType = 3; // Юридична особа
            _cust = NewCustomer(custType);
            SetDataSources();
            SetConsumerPageView();
        }

        /// <summary>
        /// Кнопка створення нової анктеи ФІЗИЧНОЇ особи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddNaturalPerson_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Кнопка відміни створення анктеи юр особи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnCancelAnketa_Click(object sender, EventArgs e)
        {
            nextPage = true;
            ClearDataConsumersControls();
            rpvConsumers.SelectedPage = pageConsumersGrid;
            validTabs = 0;
            nextPage = false;
        }


        #region [- - КНОПКИ НА ВКЛАДКІ ДОДАВАННЯ НОВОЇ АНКЕТИ ЮР ОСОБИ - -]

        private void rbtnNextLicType_Click(object sender, EventArgs e)
        {
            lblTabLicenseTypeClientName.Text = clientNameCtrlAnketaCompany.CompanyFullName;
            nextPage = true;
            pageAllAnketa.SelectedPage = pvConsumerLicenseType;
        }

        private void rbtnNextAnketa_Click(object sender, EventArgs e)
        {
            nextPage = true;
            anketaCtrlTitleLbl.ClientName = clientNameCtrlAnketaCompany.CompanyFullName;
            anketaCtrlTitleLbl.ContractBeginDate = licenseTypeCtrlContractConsumerMain.ContractBeginDate;
            anketaCtrlTitleLbl.ContractNumber = licenseTypeCtrlContractConsumerMain.ContractNumber;
            pageAllAnketa.SelectedPage = pvConsumerAnketa;
        }

        private void rbtnBackClientName_Click(object sender, EventArgs e)
        {
            pageAllAnketa.SelectedPage = pvConsumerClientName;
        }

        private void rbtnNextManagers_Click(object sender, EventArgs e)
        {
            nextPage = true;

            managersCtrlTitleLbl.ClientName = clientNameCtrlAnketaCompany.CompanyFullName;
            managersCtrlTitleLbl.ContractBeginDate = licenseTypeCtrlContractConsumerMain.ContractBeginDate;
            managersCtrlTitleLbl.ContractNumber = licenseTypeCtrlContractConsumerMain.ContractNumber;
            pageAllAnketa.SelectedPage = pvConsumerManagers;

        }

        private void rbtnBackLicType_Click(object sender, EventArgs e)
        {
            pageAllAnketa.SelectedPage = pvConsumerLicenseType;
        }

        private void rbtnNextPlaces_Click(object sender, EventArgs e)
        {
            nextPage = true;
            placesCtrlTitleLbl.ClientName = clientNameCtrlAnketaCompany.CompanyFullName;
            placesCtrlTitleLbl.ContractBeginDate = licenseTypeCtrlContractConsumerMain.ContractBeginDate;
            placesCtrlTitleLbl.ContractNumber = licenseTypeCtrlContractConsumerMain.ContractNumber;
            if (clientNameCheckBoxPlaces.IsChecked)
                pageAllAnketa.SelectedPage = pvConsumerPlaces;
            else
            {
                bankRequisitesCtrlTitleLbl.ClientName = clientNameCtrlAnketaCompany.CompanyFullName;
                bankRequisitesCtrlTitleLbl.ContractBeginDate = licenseTypeCtrlContractConsumerMain.ContractBeginDate;
                bankRequisitesCtrlTitleLbl.ContractNumber = licenseTypeCtrlContractConsumerMain.ContractNumber;
                pageAllAnketa.SelectedPage = pvConsumerBankRequisites;
                pageAllAnketa.Pages[4].Item.ForeColor = Color.DarkGray;
                pageAllAnketa.Pages[5].Item.ForeColor = DefaultForeColor;
                if (validTabs == 4)
                    validTabs++;
            }
        }

        private void rbtnBackAnketa_Click(object sender, EventArgs e)
        {
            pageAllAnketa.SelectedPage = pvConsumerAnketa;
        }

        private void rbtnNextBankRequisites_Click(object sender, EventArgs e)
        {
            nextPage = true;
            bankRequisitesCtrlTitleLbl.ClientName = clientNameCtrlAnketaCompany.CompanyFullName;
            bankRequisitesCtrlTitleLbl.ContractBeginDate = licenseTypeCtrlContractConsumerMain.ContractBeginDate;
            bankRequisitesCtrlTitleLbl.ContractNumber = licenseTypeCtrlContractConsumerMain.ContractNumber;
            pageAllAnketa.SelectedPage = pvConsumerBankRequisites;
        }

        private void rbtnBackManagers_Click(object sender, EventArgs e)
        {
            pageAllAnketa.SelectedPage = pvConsumerManagers;
        }

        private void rbtnNextContract_Click(object sender, EventArgs e)
        {
            nextPage = true;
            // radPdfViewer.LoadDocument("InteractiveForms.pdf");
            pageAllAnketa.SelectedPage = pvConsumerContracts;
        }

        private void rbtnBackPlaces_Click(object sender, EventArgs e)
        {
            if (IsPlaceIn)
                pageAllAnketa.SelectedPage = pvConsumerPlaces;
            else
                pageAllAnketa.SelectedPage = pvConsumerManagers;
        }

        private void rbtnBackBankRequisites_Click(object sender, EventArgs e)
        {
            pageAllAnketa.SelectedPage = pvConsumerBankRequisites;
        }

        #endregion

        /// <summary>
        /// Збереження анкети юр особи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnConsumerSave_Click(object sender, EventArgs e)
        {
            if (Validation(7) && MessageBox.Show("Do you want save data?", "Save data?", MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question) == DialogResult.Yes)
            {

                SaveCustomer?.Invoke(_cust);


                ClearDataConsumersControls();
                //



                //SetDataSources();
                rpvConsumers.SelectedPage = pageConsumersGrid;
            }
        }


        /// <summary>
        /// Перевірка на правильність ввеедених даних (Consumers) 
        /// </summary>
        /// <returns></returns>
        private bool Validation(byte type)
        {
            /*
             * 1 - назва клієнта
             * 2 - тип ліцензії
             * 3 - анкета
             * 4 - керівники
             * 5 - майданчики
             * 6 - банківські реквізити
             * 7 - договір
             */
            bool isValid = true;

            switch (type)
            {
                case 1:
                    {
                        if (!clientNameCtrlAnketaCompany.Validator())
                            isValid = false;
                        if (!clientNameCtrlRegistrationsCompany.Validator())
                            isValid = false;
                    }
                    break;

                case 2:
                    {
                        if (!licenseTypeCtrlContractConsumerMain.Validator())
                            isValid = false;
                        if (!licenseTypeCtrlContractConsumerDetail.Validator())
                            isValid = false;
                    }
                    break;

                case 3:
                    {
                        if (!anketaCtrlAddressFactual.Validator())
                            isValid = false;
                        if (!anketaCtrlAddressLegal.Validator())
                            isValid = false;
                        //додаткові поля
                    }
                    break;

                case 4:
                    {
                        if (!managersCtrlBossNameContactsBookkeeper.Validator())
                            isValid = false;
                        if (!managersCtrlBossNameContactsContactPerson.Validator())
                            isValid = false;
                        if (!managersCtrlBossNameContactsHead.Validator())
                            isValid = false;

                        //додаткові поля
                    }
                    break;

                case 5:
                    {
                        // майданчики
                    }
                    break;

                case 6:
                    {
                        if (!bankRequisitesCtrlBankAccount.Validator())
                            isValid = false;
                    }
                    break;

                case 7:
                    {
                        //друк PDF
                    }
                    break;

            }

            return isValid;
        }

        /// <summary>
        /// Очищення даних на контролах розділу споживачів
        /// </summary>
        private void ClearDataConsumersControls()
        {
            //clientNameCtrlAnketaCompany.ClearData();
            //clientNameCtrlRegistrationsCompany.ClearData();
            //licenseTypeCtrlContractConsumerMain.ClearData();
        }

        public void SetDataSources()
        {
            if (_cust == null)
                return;

            // bindingSourceBankAccount;
            if (_cust.BankAccount.Count == 0)
                _cust.BankAccount.Add(new BankAccount { CustId = _cust.CustId });

            var agreeMaster = _cust.AgreementMaster.Where(rec => rec.AgrStatus < 4).FirstOrDefault();
            if (agreeMaster == null)
            {
                agreeMaster = new AgreementMaster { AgrStatus = 0 };
                agreeMaster.LicenseAgreement.Add(new LicenseAgreement { LicCode = 25, LicStatus = 0 });
                _cust.AgreementMaster.Add(agreeMaster);
            }

            // bindingSourceAgreementMaster;
            bindingSourceAgreementMaster.DataSource = agreeMaster;
            var licAgreement = agreeMaster.LicenseAgreement.Where(rec => rec.LicStatus < 4).FirstOrDefault();
            if (licAgreement == null)
            {
                licAgreement = new LicenseAgreement { LicStatus = 0, LicCode = 25 };
                agreeMaster.LicenseAgreement.Add(licAgreement);
            }
            // bindingSourceLicenseAgreement;
            bindingSourceLicenseAgreement.DataSource = licAgreement;
            if (_cust.CustType == 3) // Юр. особа
            {

                // bindingSourceAnketaCompany;
                AnketaCompany anketa = _cust.Company.AnketaCompany.Where(rec => rec.Version == _cust.AnkVersion).SingleOrDefault();
                bindingSourceAnketaCompany.DataSource = anketa;

                // bindingSourceBoss;
                // bindingSourceBossRel;
                var relItem = _cust.Company.RelEmployee.Where(rec => rec.PositionCode == 1).FirstOrDefault();
                if(relItem == null)
                {
                    Employee empl = new Employee();
                    relItem = new RelEmployee { Empl = empl, PositionCode = 1 };
                    _cust.Company.RelEmployee.Add(relItem);
                }
                bindingSourceBossRel.DataSource = relItem;
                bindingSourceBoss.DataSource = relItem.Empl;

                relItem = _cust.Company.RelEmployee.Where(rec => rec.PositionCode == 2).FirstOrDefault();
                if (relItem == null)
                {
                    Employee empl = new Employee();
                    relItem = new RelEmployee { Empl = empl, PositionCode = 2 };
                    _cust.Company.RelEmployee.Add(relItem);
                }
                bindingSourceBuhRel.DataSource = relItem;
                bindingSourceBuh.DataSource = relItem.Empl;

                relItem = _cust.Company.RelEmployee.Where(rec => rec.PositionCode == 3).FirstOrDefault();
                if (relItem == null)
                {
                    Employee empl = new Employee();
                    relItem = new RelEmployee { Empl = empl, PositionCode = 3 };
                    _cust.Company.RelEmployee.Add(relItem);
                }
                bindingSourceContactRel.DataSource = relItem;
                bindingSourceContactPerson.DataSource = relItem.Empl;

            }

            anketaCtrlAddressFactual.CountriesDataSource = _dic.country;
            anketaCtrlAddressFactual.CountriesValueMember = "countryCode";
            anketaCtrlAddressFactual.CountriesDisplayMember = "countryName";

            anketaCtrlAddressFactual.RegionsDataSource = _dic.region;
            anketaCtrlAddressFactual.RegionsValueMember = "codeI";
            anketaCtrlAddressFactual.RegionsDisplayMember = "name";

            anketaCtrlAddressLegal.CountriesDataSource = _dic.country;
            anketaCtrlAddressLegal.RegionsDataSource = _dic.region;
            anketaCtrlAddressLegal.CountriesValueMember = "countryCode";
            anketaCtrlAddressLegal.CountriesDisplayMember = "countryName";
            anketaCtrlAddressLegal.RegionsValueMember = "codeI";
            anketaCtrlAddressLegal.RegionsDisplayMember = "name";

            BindingSourceAnketaDictionaties.DataSource = _dic;

            clientNameCtrlAnketaCompany.ActivityCodeDataSource = _dic.activityType;
            clientNameCtrlAnketaCompany.ActivityCodeValueMember = "codeI";
            clientNameCtrlAnketaCompany.ActivityCodeDisplayMember = "name";

            clientNameCtrlRegistrationsCompany.TypesVatDataSource = _dic.typeVat;
            clientNameCtrlRegistrationsCompany.TypesVatValueMember = "codeI";
            clientNameCtrlRegistrationsCompany.TypesVatDisplayMember = "name";

            consumerWorkplaceBindingSource.DataSource = this;

            /*  - - -      BIND DATASOURCE      - - -  */

            placesCtrlConsumerPlaces.SetData(_cust);
            if (_cust.Client.ClnBusinessPlace.Count != 0)
                placesCtrlConsumerPlaces.SetGridDataSource(_cust.Client.ClnBusinessPlace);
            else
                placesCtrlConsumerPlaces.SetGridDataSource(new List<ClnBusinessPlace>());



        }

        /// <summary>
        /// Переключати вкладки через кнопки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pageAllAnketa_SelectedPageChanging(object sender, Telerik.WinControls.UI.RadPageViewCancelEventArgs e)
        {
            if (Validation(Convert.ToByte(pageAllAnketa.SelectedPage.TabIndex + 1)))
            {
                if (!clientNameCheckBoxPlaces.IsChecked && e.Page.TabIndex == 4)
                {
                    e.Cancel = true;
                    return;
                }
                if (e.Page.TabIndex <= validTabs)
                {
                    e.Cancel = false;
                    nextPage = false;
                }
                else if (pageAllAnketa.SelectedPage.TabIndex == validTabs && nextPage)
                {
                    validTabs++;
                    pageAllAnketa.Pages[validTabs].Item.ForeColor = DefaultForeColor;
                    e.Cancel = false;
                    nextPage = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
                e.Cancel = true;
        }

        /// <summary>
        /// Натискання по кнопкі редагування в грід
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rGridViewConsumers_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            //MessageBox.Show(rGridViewConsumers.Rows[e.RowIndex].Cells["CustId"].Value.ToString());
            int custId = Convert.ToInt32(rGridViewConsumers.Rows[e.RowIndex].Cells["CustId"].Value);
            _cust = GetCustomer(custId);
            SetDataSources();
            SetConsumerPageView();
        }

        Customer _cust = null;
        public void SetData(ICustomer data)
        {
            _cust = (Customer)data;
        }

        public void GetData(ICustomer data)
        {
            throw new NotImplementedException();
        }

        private AnketaDictionaties _dic = null;
        public void SetDictionary(AnketaDictionaties dic)
        {
            _dic = dic;
        }

        /// <summary>
        /// Признак, що є майданчик
        /// </summary>
        public bool IsPlaceIn
        {
            get
            {
                if (_cust == null || _cust.Client.ClnBusinessPlace.Count == 0)
                    return false;
                return true;
            }
        }

        public Func<IList<ConsumerMainView>> getMainViewData { get; set; }
        public Func<int, Customer> NewCustomer { get; set; }
        public Func<int, Customer> GetCustomer { get; set; }
        public Func<Customer, bool> SaveCustomer { get; set; }

        public void EndPresenterLink()
        {
            if (getMainViewData != null)
            {
                var list = getMainViewData();
                consumerMainViewBindingSource.DataSource = list;
            }
        }

    }


}
