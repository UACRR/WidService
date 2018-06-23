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
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using Telerik.WinControls;
using Telerik.WinControls.UI;


namespace ConsumerWorkplace_v_1._0
{
    public partial class ConsumerWorkplace : Telerik.WinControls.UI.RadForm, IConsumerForm
    {
        private bool nextPage = false;
        private sbyte validTabs = 0;
        private SwitchPresenter _presenter;
        private ConsumerService _service;

        public event Func<bool> Save;

        public ConsumerWorkplace()
        {
            RadTreeNode[] list = new[]
            {
                new RadTreeNode {Text = "Всі", Value = ConsumerFilterEnum.All},
                new RadTreeNode {Text = "Діючі", Value = ConsumerFilterEnum.Working},
                new RadTreeNode {Text = "На акцепті", Value = ConsumerFilterEnum.NotAccepted},
                new RadTreeNode {Text = "Для пролонгації", Value = ConsumerFilterEnum.ForProlongation},
                new RadTreeNode {Text = "Не розподіленні", Value = ConsumerFilterEnum.ForDistribution}
            };
            
            
            InitializeComponent();
            rpvConsumers.ViewElement.Visibility = ElementVisibility.Hidden; // приховання вкладок
            placesCtrlConsumerPlaces.OnEnabledChangeWhenEditOrAddPremises += PlacesCtrlConsumerPlaces_OnEnabledChangeWhenEditOrAddPremises;

            foreach (var item in list)
            {
                radTreeView1.Nodes.Add(item);
            }

            _service = new ConsumerService();
            _presenter = new SwitchPresenter( mainViewSwitcher1, _service, radTreeView1 );
            radTreeView1.SelectedNode = radTreeView1.Nodes["Всі"];

        }

        public Customer ReturnCustomer()
        {
            return _cust ?? new Customer();
        }

        public object ReturnList()
        {
            return getMainViewData().ToList();
        }


        private void PlacesCtrlConsumerPlaces_OnEnabledChangeWhenEditOrAddPremises()
        {
            //some code
        }

        /// <summary>
        /// Перехід на сторінку ДОДАВАННЯ Споживача
        /// </summary>
        private void SetConsumerPageViewAdd()
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
        /// Перехід на сторінку РЕДАГУВАННЯ Споживача
        /// </summary>
        private void SetConsumerPageViewEdit()
        {
            validTabs = 10;
            nextPage = true;
            rpvConsumers.SelectedPage = pageConsumersAnketa;
            pageAllAnketa.SelectedPage = pvConsumerLicenseType;
            pageAllAnketa.SelectedPage = pvConsumerClientName;

            foreach (var page in pageAllAnketa.Pages)
            {
                page.Item.ForeColor = DefaultForeColor;
            }

            pageAllAnketa.Pages["pvConsumerPlaces"].Item.ForeColor = !clientNameCheckBoxPlaces.Checked ? Color.DarkGray : DefaultForeColor;
        }

        /// <summary>
        /// Кнопка ДОДАВАННЯ нової анкети ЮРИДИЧНОЇ особи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddJuridicalPerson_Click(object sender, EventArgs e)
        {
            int custType = 3; // Юридична особа
            _cust = NewCustomer(custType);
            SetDataSources();
            SetConsumerPageViewAdd();
        }

        /// <summary>
        /// Кнопка ДОДАВАННЯ нової анктеи ФІЗИЧНОЇ особи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddNaturalPerson_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Кнопки * * * РЕДАГУВАННЯ * * * на  - - грід - - 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rGridViewConsumers_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            int custId = Convert.ToInt32(rGridViewConsumers.Rows[e.RowIndex].Cells["CustId"].Value);
            _cust = GetCustomer(custId);
            if (_cust?.Client?.ClnBusinessPlace != null)
                IsPlaceIn = _cust.Client.ClnBusinessPlace.Count != 0;
            SetDataSources();
            SetConsumerPageViewEdit();
        }

        /// <summary>
        /// Кнопка  * * * СКАСУВАТИ * * * створення анктеи юр особи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnCancelAnketa_Click(object sender, EventArgs e)
        {
            if(pageAllAnketa.SelectedPage.TabIndex == 4)
                placesCtrlConsumerPlaces.ClearData();
            nextPage = true;
            ClearDataConsumersControls();
            rpvConsumers.SelectedPage = pageConsumersGrid;
            validTabs = 0;
            nextPage = false;
        }


        #region [- - КНОПКИ НА ВКЛАДКІ ДОДАВАННЯ НОВОЇ АНКЕТИ ЮР ОСОБИ - -]
        /// <summary>
        /// Титулки на сторінках
        /// </summary>
        private void SetTitleText()
        {
            lblTabLicenseTypeClientName.Text = clientNameCtrlAnketaCompany.CompanyFullName;

            anketaCtrlTitleLbl.ClientName = clientNameCtrlAnketaCompany.CompanyFullName;
            anketaCtrlTitleLbl.ContractBeginDate = licenseTypeCtrlContractConsumerMain.ContractBeginDate;
            anketaCtrlTitleLbl.ContractNumber = licenseTypeCtrlContractConsumerMain.ContractNumber;

            managersCtrlTitleLbl.ClientName = clientNameCtrlAnketaCompany.CompanyFullName;
            managersCtrlTitleLbl.ContractBeginDate = licenseTypeCtrlContractConsumerMain.ContractBeginDate;
            managersCtrlTitleLbl.ContractNumber = licenseTypeCtrlContractConsumerMain.ContractNumber;

            placesCtrlTitleLbl.ClientName = clientNameCtrlAnketaCompany.CompanyFullName;
            placesCtrlTitleLbl.ContractBeginDate = licenseTypeCtrlContractConsumerMain.ContractBeginDate;
            placesCtrlTitleLbl.ContractNumber = licenseTypeCtrlContractConsumerMain.ContractNumber;

            bankRequisitesCtrlTitleLbl.ClientName = clientNameCtrlAnketaCompany.CompanyFullName;
            bankRequisitesCtrlTitleLbl.ContractBeginDate = licenseTypeCtrlContractConsumerMain.ContractBeginDate;
            bankRequisitesCtrlTitleLbl.ContractNumber = licenseTypeCtrlContractConsumerMain.ContractNumber;
            
        }

        /// <summary>
        /// НАСТУПНА  -  Тип ліцензії
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnNextLicType_Click(object sender, EventArgs e)
        {
            nextPage = true;
            pageAllAnketa.SelectedPage = pvConsumerLicenseType;
            lblTabLicenseTypeClientName.Text = clientNameCtrlAnketaCompany.CompanyFullName;
            licenseTypeDropListLicType.Select();
        }

        /// <summary>
        /// НАСТУПНА  -  Анкета
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnNextAnketa_Click(object sender, EventArgs e)
        {
            nextPage = true;
            pageAllAnketa.SelectedPage = pvConsumerAnketa;
            SetTitleText();
        }

        /// <summary>
        /// НАСТУПНА  -  Керівники
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnNextManagers_Click(object sender, EventArgs e)
        {
            nextPage = true;

                pageAllAnketa.SelectedPage = pvConsumerManagers;

        }

        /// <summary>
        /// НАСТУПНА  -  Майданчики
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnNextPlaces_Click(object sender, EventArgs e)
        {
            nextPage = true;

            if (clientNameCheckBoxPlaces.IsChecked)
                pageAllAnketa.SelectedPage = pvConsumerPlaces;
            else
            {
                pageAllAnketa.SelectedPage = pvConsumerBankRequisites;
                pageAllAnketa.Pages[4].Item.ForeColor = Color.DarkGray;
                pageAllAnketa.Pages[5].Item.ForeColor = DefaultForeColor;
                if (validTabs == 4)
                    validTabs++;
            }
        }

        /// <summary>
        /// НАСТУПНА  -  Банківські реквізити
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnNextBankRequisites_Click(object sender, EventArgs e)
        {
            nextPage = true;
            pageAllAnketa.SelectedPage = pvConsumerBankRequisites;
        }

        /// <summary>
        /// НАСТУПНА  -  Договір
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnNextContract_Click(object sender, EventArgs e)
        {
            nextPage = true;
            //var pdfDoc = PdfEngine.GetPdf(_cust, _dic);
            //radPdfViewer.LoadDocument(pdfDoc);
            pageAllAnketa.SelectedPage = pvConsumerContracts;
        }

        /// <summary>
        /// ПОПЕРЕДНЯ  -  Назва клієнта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnBackClientName_Click(object sender, EventArgs e)
        {
            pageAllAnketa.SelectedPage = pvConsumerClientName;
        }

        /// <summary>
        /// ПОПЕРЕДНЯ  -  Тип ліцензції
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnBackLicType_Click(object sender, EventArgs e)
        {
            pageAllAnketa.SelectedPage = pvConsumerLicenseType;
        }

        /// <summary>
        /// ПОПЕРЕДНЯ  -  Анкета
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnBackAnketa_Click(object sender, EventArgs e)
        {
            pageAllAnketa.SelectedPage = pvConsumerAnketa;
        }

        /// <summary>
        /// ПОПЕРЕДНЯ  -  Керівники
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnBackManagers_Click(object sender, EventArgs e)
        {
            pageAllAnketa.SelectedPage = pvConsumerManagers;
        }

        /// <summary>
        /// ПОПЕРЕДНЯ  -  Майданчики
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnBackPlaces_Click(object sender, EventArgs e)
        {
            if (IsPlaceIn)
                pageAllAnketa.SelectedPage = pvConsumerPlaces;
            else
                pageAllAnketa.SelectedPage = pvConsumerManagers;
        }

        /// <summary>
        /// ПОПЕРЕДНЯ  -  Банківські реквізити
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnBackBankRequisites_Click(object sender, EventArgs e)
        {
            pageAllAnketa.SelectedPage = pvConsumerBankRequisites;
        }

        /*      *       *       *    КНОПКА ЗБЕРЕГТИ   *       *       *       */
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
                EndPresenterLink();
                rpvConsumers.SelectedPage = pageConsumersGrid;
                validTabs = 0;
            }
        }

        #endregion

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
                    if(!clientNameCtrlRegistrationsCompany.Validator())
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


        /// <summary>
        ///   - - -      BIND DATASOURCE      - - -  
        /// </summary>
        public void SetDataSources()
        {
            if (_cust == null)
                return;
            if( _cust.CustType == 3) // Юр. особа
            {

                AnketaCompany anketa = _cust.Company.AnketaCompany.Where(rec => rec.Version == _cust.AnkVersion).SingleOrDefault();
                iAnketaCompanyBindingSource.DataSource = anketa;

                if (_cust.BankAccount.Count == 0)
                    _cust.BankAccount.Add(new BankAccount{CustId = _cust.CustId});
                var bankAccount = _cust.BankAccount.FirstOrDefault();

                bankRequisitesCtrlBankAccount.DataSource = bankAccount;

                RelEmployee relEmpl = _cust.Company.RelEmployee.FirstOrDefault(rec => rec.PositionCode == 1);
                if(relEmpl == null)
                {
                    relEmpl = new RelEmployee { Empl = new Employee(), PositionCode = 1 };
                    _cust.Company.RelEmployee.Add(relEmpl);
                }

                iRelEmployeeBindingSource.DataSource = relEmpl;

                iEmployeeBindingSource.DataSource = relEmpl.Empl;

                relEmpl = _cust.Company.RelEmployee.FirstOrDefault(rec => rec.PositionCode == 2);
                if (relEmpl == null)
                {
                    relEmpl = new RelEmployee { Empl = new Employee(), PositionCode = 2 };
                    _cust.Company.RelEmployee.Add(relEmpl);
                }
                iEmployeeBindingSourceBuh.DataSource = relEmpl.Empl;

                relEmpl = _cust.Company.RelEmployee.Where(rec => rec.PositionCode == 3).FirstOrDefault();
                if (relEmpl == null)
                {
                    relEmpl = new RelEmployee { Empl = new Employee(), PositionCode = 3 };
                    _cust.Company.RelEmployee.Add(relEmpl);
                }
                bindingSourceContact.DataSource = relEmpl.Empl;

                
                var license = _cust.Client.LicenseAgreement.Where(rec => rec.LicStatus < 4).FirstOrDefault();
                
                var licenseParam = license.LicenseAgrParam.Where(rec => rec.LicVersion == license.LicVersion).SingleOrDefault();
                


                //iAgreementMasterBindingSource.DataSource = agrMaster;
                //licenseTypeCtrlContractConsumerMain.DataSource = agrMaster;
                
                iAgreementMasterBindingSource.DataSource = licenseParam;

                iLicenseAgreementBindingSource.DataSource = license;
                

                anketaCtrlAddressFactual.CountriesDataSource = _dic.country;
                anketaCtrlAddressFactual.CountriesValueMember = "countryCode";
                anketaCtrlAddressFactual.CountriesDisplayMember = "countryName";

                anketaCtrlAddressFactual.RegionsDataSource = _dic.region;
                anketaCtrlAddressFactual.RegionsValueMember = "codeI";
                anketaCtrlAddressFactual.RegionsDisplayMember = "name";

                anketaCtrlAddressLegal.CountriesDataSource = _dic.country;
                anketaCtrlAddressLegal.CountriesValueMember = "countryCode";
                anketaCtrlAddressLegal.CountriesDisplayMember = "countryName";

                anketaCtrlAddressLegal.RegionsDataSource = _dic.region;
                anketaCtrlAddressLegal.RegionsValueMember = "codeI";
                anketaCtrlAddressLegal.RegionsDisplayMember = "name";

                anketaDictionatiesBindingSource.DataSource = _dic;


                clientNameCtrlAnketaCompany.DataSource = anketa;

                clientNameCtrlRegistrationsCompany.TypesVatDataSource = _dic.typeVat;

                iAgrLicenseTypeBindingSource.DataSource = _dic.agrLicenseType;

                licenseAgrParamBindingSource.DataSource = licenseParam;
                licenseTypeCtrlContractConsumerMain.DataSource = licenseParam;


                licenseTypeCtrlContractConsumerDetail.DataSourceBinding = licenseParam;
                licenseTypeCtrlContractConsumerDetail.PeriodPaymentDataSource = _dic.period;
                licenseTypeCtrlContractConsumerDetail.PeriodPaymentValueMember = "codeI";
                licenseTypeCtrlContractConsumerDetail.PeriodPaymentDisplayMember = "name";
                licenseTypeCtrlContractConsumerDetail.IsAutoprolongation = licenseParam?.IsAutoprolog ?? false;
                licenseTypeCtrlContractConsumerDetail.MinPayment = "MinAmount";
                licenseTypeCtrlContractConsumerDetail.PercentPayment = "RateAmount";
                

                licenseTypeDropListLicType.DisplayMember = "Name";
                licenseTypeDropListLicType.ValueMember = "CodeI";
                licenseTypeDropListLicType.SelectedValue = license.LicCode;

                //licenseTypeCtrlContractConsumerDetail.PercentAutoprolongation = "AddRate";
                if (licenseParam?.AddRate == null && licenseParam?.IndxInfl != null)
                    licenseTypeCtrlContractConsumerDetail.SelectedItem = 1;
                else if (licenseParam?.AddRate != null && licenseParam.IndxInfl == null)
                    licenseTypeCtrlContractConsumerDetail.SelectedItem = 0;


                    consumerWorkplaceBindingSource.DataSource = this;
                
                iPositionTypeBindingSource.DataSource = _dic.positionType;

                placesCtrlConsumerPlaces.SetData(_cust);
                placesCtrlConsumerPlaces.SetGridDataSource(_cust.Client.ClnBusinessPlace.Count != 0
                    ? _cust.Client.ClnBusinessPlace
                    : null);

                //placesCtrlConsumerPlaces.RegionsPlacesCtrlDataSource = _dic.region;
                //placesCtrlConsumerPlaces.RegionsPlacesCtrlDisplayMember = "name";
                //placesCtrlConsumerPlaces.RegionsPlacesCtrlValueMember = "codeI";
                //var regionId = _cust.Client?.ClnBusinessPlace?.FirstOrDefault();
                //if(regionId!=null)
                //    placesCtrlConsumerPlaces.RegionSelectedValue = regionId.PlaceRegion;

                //managersRddListPositionHead.DataSource
                clientNameCheckBoxPlaces.Checked = IsPlaceIn;

            }
        }



        /// <summary>
        /// Переключати вкладки через кнопки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pageAllAnketa_SelectedPageChanging(object sender, Telerik.WinControls.UI.RadPageViewCancelEventArgs e)
        {
            if (e.Page.TabIndex <= pageAllAnketa.SelectedPage.TabIndex)
            {
                if (pageAllAnketa.SelectedPage.TabIndex == 4)
                    placesCtrlConsumerPlaces.ClearData();
                e.Cancel = false;
                nextPage = false;
            }
            else if ( Validation(Convert.ToByte(pageAllAnketa.SelectedPage.TabIndex+1)))
            {

                if (pageAllAnketa.SelectedPage.TabIndex == 4)
                    placesCtrlConsumerPlaces.ClearData();

                if (!clientNameCheckBoxPlaces.IsChecked && e.Page.TabIndex == 4)
                {
                    e.Cancel = true;
                    return;
                }
                if (e.Page.TabIndex <= validTabs)
                {
                    e.Cancel = false;
                    nextPage = false;
                    if (pageAllAnketa.SelectedPage.TabIndex == 0 || pageAllAnketa.SelectedPage.TabIndex == 1)
                        SetTitleText();
                    if (e.Page.TabIndex != 6) return;
                    var pdfDoc = PdfEngine.GetPdf(_cust, _dic);
                    radPdfViewer.LoadDocument(pdfDoc);
                    return;
                }
                if (pageAllAnketa.SelectedPage.TabIndex == validTabs && nextPage)
                {
                    validTabs++;
                    pageAllAnketa.Pages[validTabs].Item.ForeColor = DefaultForeColor;
                    e.Cancel = false;
                    nextPage = false;
                    if (e.Page.TabIndex != 6) return;
                    var pdfDoc = PdfEngine.GetPdf(_cust, _dic);
                    radPdfViewer.LoadDocument(pdfDoc);
                    return;
                }

                e.Cancel = true;
            }
            else
                e.Cancel = true;
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
            get => _cust != null && _cust.Client.ClnBusinessPlace.Count != 0;
            set {  }
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

        /// <summary>
        /// зміна наявності майданчиків 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clientNameCheckBoxPlaces_CheckStateChanged(object sender, EventArgs e)
        {
            if (!clientNameCheckBoxPlaces.Checked)
            {
                pageAllAnketa.Pages["pvConsumerPlaces"].Item.ForeColor = Color.DarkGray;
                rbtnNextPlaces.Text = rbtnNextBankRequisites.Text;
                rbtnBackPlaces.Text = rbtnBackManagers.Text;
            }
            else if (validTabs >= 3)
            {
                pageAllAnketa.Pages["pvConsumerPlaces"].Item.ForeColor = DefaultForeColor;
                rbtnNextPlaces.Text = "Майданчики >";
                rbtnBackPlaces.Text = "Майданчики >";
            }
        }

        /// <summary>
        /// копіювання фактичної адреси в юридичну
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCopyFromJAtoFa_Click(object sender, EventArgs e)
        {
            anketaCtrlAddressFactual.DdlCountry.SelectedValue = anketaCtrlAddressLegal.DdlCountry.SelectedValue;
            anketaCtrlAddressFactual.DdlRegion.SelectedIndex = anketaCtrlAddressLegal.DdlRegion.SelectedIndex;
            anketaCtrlAddressFactual.TxtCity.Text = anketaCtrlAddressLegal.TxtCity.Text;
            anketaCtrlAddressFactual.TxtAddress.Text = anketaCtrlAddressLegal.TxtAddress.Text;
            anketaCtrlAddressFactual.TxtAddress.Select();
        }
    }


}
