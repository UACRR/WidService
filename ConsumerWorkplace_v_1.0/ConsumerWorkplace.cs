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
using ipsmedserviceapp.Model;
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

        //public void TestMehod()
        //{
        //    //
        //    List<ListConsumers> ds = new List<ListConsumers>
        //    {
        //        new ListConsumers
        //        {
        //            Name = "Ресторан",
        //            CustId = 121,
        //            CountAgree = 1,
        //            Innokpo = 58946449,
        //            Undistribamount = 154.554
        //        },
        //        new ListConsumers{
        //            Name = "Готель",
        //            CustId = 154,
        //            CountAgree = 2,
        //            Innokpo = 12313213,
        //            Undistribamount = 12.54
        //        },
        //        new ListConsumers{
        //            Name = "Забігайлівка",
        //            CustId = 101,
        //            CountAgree = 3,
        //            Innokpo = 415146465,
        //            Undistribamount = 1.0544
        //        },
        //    };

        //    // rGridViewConsumers.DataSource = ds;
        //    //
        //}

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
                pageAllAnketa.SelectedPage = pvConsumerPlaces;
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
                radPdfViewer.LoadDocument("InteractiveForms.pdf");
            pageAllAnketa.SelectedPage = pvConsumerContracts;
        }

        private void rbtnBackPlaces_Click(object sender, EventArgs e)
        {
            pageAllAnketa.SelectedPage = pvConsumerPlaces;
        }

        private void rbtnBackBankRequisites_Click(object sender, EventArgs e)
        {
            pageAllAnketa.SelectedPage = pvConsumerBankRequisites;
        }


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
                SetDataSources();
                rpvConsumers.SelectedPage = pageConsumersGrid;
                ClearDataConsumersControls();
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
            clientNameCtrlAnketaCompany.ClearData();
            clientNameCtrlRegistrationsCompany.ClearData();
            licenseTypeCtrlContractConsumerMain.ClearData();
            
        }

        public void SetDataSources()
        {
            if (_cust == null)
                return;
            if( _cust.CustType == 3) // Юр. особа
            {
                //    //1
                //    clientNameCtrlAnketaCompany.DataSource,
                //    clientNameCtrlRegistrationsCompany.DataSource,
                //    clientNameCheckBoxPlaces.Checked,
                AnketaCompany anketa = _cust.Company.AnketaCompany.Where(rec => rec.Version == _cust.AnkVersion).SingleOrDefault();
                BankAccount bankAccount = _cust.BankAccount.FirstOrDefault();
                var relBoss = _cust.Company?.RelEmployee?.Where(rec => rec.PositionCode == 1).SingleOrDefault();
                var agrMaster = _cust.AgreementMaster?.Where(rec => rec.AgrStatus < 4).FirstOrDefault();
                var licAgr = agrMaster?.LicenseAgreement.Where(rec => rec.LicStatus < 4).FirstOrDefault();


                anketaCtrlAddressFactual.CountriesDataSource = _dic.country;
                anketaCtrlAddressFactual.DataSource = this.iAnketaCompanyBindingSource;
                anketaCtrlAddressFactual.RegionsDataSource = _dic.region;
                anketaCtrlAddressLegal.CountriesDataSource = _dic.country;
                anketaCtrlAddressLegal.DataSource = this.iAnketaCompanyBindingSource;
                anketaCtrlAddressLegal.RegionsDataSource = _dic.region;
                anketaDictionatiesBindingSource.DataSource = _dic;
                bankRequisitesCtrlBankAccount.DataSource = bankAccount;
                clientNameCtrlAnketaCompany.ActivityCodeDataSource = _dic.activityType;
                clientNameCtrlAnketaCompany.ActivityCodeValueMember = "CodeI";
                clientNameCtrlAnketaCompany.ActivityCodeDisplayMember = "Name";
                clientNameCtrlAnketaCompany.DataSource = anketa;
                clientNameCtrlRegistrationsCompany.DataSource = this.iAnketaCompanyBindingSource;
                // consumerMainViewBindingSource.DataSource = typeof(ipsFormsDesign.Interfaces.ConsumerMainView);
                consumerWorkplaceBindingSource.DataSource = this;
                iAnketaCompanyBindingSource.DataSource = anketa;
                iPositionTypeBindingSource.DataSource = _dic.positionType;
                iRelEmployeeBindingSource.DataSource = relBoss;
                licenseTypeCtrlContractConsumerDetail.DataSource = _dic.licenseType;
                licenseTypeCtrlContractConsumerMain.DataSource = agrMaster;
                managersCtrlBossNameContactsBookkeeper.DataSource = relBoss?.Empl;
                managersCtrlBossNameContactsContactPerson.DataSource = relBoss?.Empl;
                managersCtrlBossNameContactsHead.DataSource = relBoss?.Empl;









                //    //2
                //    licenseTypeCtrlContractConsumerMain.DataSource,
                //    licenseTypeCtrlContractConsumerDetail.DataSource,
            }
            //List<object> objList =new List<object>
            //{
            //    //3
            //    anketaCtrlAddressFactual.DataSource,
            //    anketaCtrlAddressLegal.DataSource,
            //    //4
            //    managersCtrlBossNameContactsHead.DataSource,
            //    managersCtrlBossNameContactsBookkeeper.DataSource,
            //    managersCtrlBossNameContactsContactPerson.DataSource,
            //    //5
            //    placesCtrlConsumerPlaces.GetData(),
            //    //6
            //    bankRequisitesCtrlBankAccount.DataSource

            //};

            //var list = objList.ToList();

        }



        /// <summary>
        /// Переключати вкладки через кнопки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pageAllAnketa_SelectedPageChanging(object sender, Telerik.WinControls.UI.RadPageViewCancelEventArgs e)
        {
            if ( Validation(Convert.ToByte(pageAllAnketa.SelectedPage.TabIndex+1)))
            {
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
            MessageBox.Show(rGridViewConsumers.Rows[e.RowIndex].Cells["CustId"].Value.ToString());
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
            get { if (_cust == null || _cust.Client.ClnBusinessPlace.Count == 0)
                    return false;
                return true;
            }
        }

        public Func<IList<ConsumerMainView>> getMainViewData { get; set; }
        public Func<int, Customer> NewCustomer { get; set; }
        public Func<int, Customer> GetCustomer { get; set; }
        public Func<Customer, bool> SaveCustomer { get; set; }

        private void rpvConsumers_SelectedPageChanged(object sender, EventArgs e)
        {

        }

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
