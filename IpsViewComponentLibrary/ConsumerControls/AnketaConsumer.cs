using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using IpsViewComponentLibrary.ConsumerControls.BigRight;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.ConsumerControls
{
    public partial class AnketaConsumer : UserControl
    {
        private bool isEdit = false;

        private AgreementWithPlacesControl _ctrlAgreementSmallRights;
        private AgreementBigRight _ctrlAgreementBigRights;

        private ConsumerAnketeType _anketeType = ConsumerAnketeType.None;
        
        private readonly Point _locationAgreement = new Point(19, 5);

        private Customer _customer;
        private AnketaDictionaties _anketaDictionaries;

        public TypeRights TypeRights { get; set; } = TypeRights.SmallRights;

        public RadPageView GetPageView => pageAnketaConsumer;

        //default constructor
        public AnketaConsumer()
        {
            InitializeComponent();
            pageAnketaConsumer.SelectedPage = pvClientName;
        }

        /// <summary>
        /// Ініціалізація параметрів контрола
        /// </summary>
        /// <param name="getAutoCompList"></param>
        /// <param name="getCustomerAnketa"></param>
        /// <param name="anketeType"></param>
        public void InitializeControl(Func<string, IList<AutoCompleteData>> getAutoCompList, Func<int, Customer> getCustomerAnketa, ConsumerAnketeType anketeType)
        {
            _anketeType = anketeType;

            if (_anketeType == ConsumerAnketeType.CreateNewAnketa)
                ctrlClientName.SetAutoComplete(getAutoCompList, getCustomerAnketa);

            ReInitControl();
        }

        /// <summary>
        /// Переініціалізація за потребою (містить databinding)
        /// </summary>
        public void ReInitControl()
        {
            ctrlClientName.SetDataSources(_customer); // - - - - - - - -  Назва клієнта
            ctrlManagers.SetDataSources(_customer); // - - - - - - - - - - - - - - Керівники
            ctrlAddress.SetDataSources(_customer, _anketaDictionaries);    // - - - - - - - -  Адреса
            ctrlPlaces.SetData(_customer);  // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
            anketaCompanyBindingSource.DataSource = _customer.Company?.AnketaCompany?.// - - - - - - - - - - - -
                SingleOrDefault(rec => rec?.Version == _customer.AnkVersion); // - - - - - -  Майданчики (title)
            if (!_customer.BankAccount.Any())
                _customer.BankAccount.Add(new BankAccount { CustId = _customer.CustId });
            ctrlBankRequisites.DataSource = _customer.BankAccount; // - - - - - -  Банківські реквізити

            if(_anketeType == ConsumerAnketeType.CreateNewAnketa)
                InitAgreementType(TypeRights);
            else if (_anketeType == ConsumerAnketeType.EditAnketa)
            {
                pageAnketaConsumer.Pages["pvPrint"].Item.Visibility = ElementVisibility.Collapsed;
                pageAnketaConsumer.Pages["pvAgreement"].Item.Visibility = ElementVisibility.Collapsed;
            }
        }

        //ініціалізація контролу договору за типом прав
        private void InitAgreementType(TypeRights rights)
        {
            switch (rights)
            {
                case TypeRights.BigRights:
                {
                    if (_ctrlAgreementBigRights == null)
                    {
                        // ініціалізація контролу великих прав 
                        _ctrlAgreementBigRights = new AgreementBigRight
                        {
                            Location = _locationAgreement,
                            MaximumSize = new Size(900, 200),
                            MinimumSize = new Size(500, 200),
                            Name = "ctrlAgreementBigRights",
                            Size = new Size(596, 200),
                            TabIndex = 0
                        };
                        pvAgreement.Controls.Add(_ctrlAgreementBigRights);
                    }
                    
                    if (_customer.Client?.LicenseAgreement?.LastOrDefault()?.LicCode != null)
                    {
                        var item = _customer.Client.LicenseAgreement.LastOrDefault();
                        item.LicCode = 28;
                        item.LicClass = 1;
                        item.LicType = 1;
                        item.LicVersion = 1;
                    }

                    if(!isEdit && _customer.Client?.LicenseAgreement?.LastOrDefault()?.Agr?.AgreementAddBr.Count == 0)
                        _customer.Client.LicenseAgreement.LastOrDefault()?.Agr?.AgreementAddBr.Add(new AgreementAddBr {
                        Version = 1,
                        AgrStatus = 0,
                        AnkVersion = _customer.AnkVersion,
                        AgrNumber = string.Empty,
                        });
                    // control bindings
                    _ctrlAgreementBigRights.PaidPeriodDictionaryDataSource = _anketaDictionaries.period;// (Period)
                    var agreementData = _customer.Client?.LicenseAgreement?.SingleOrDefault(rec => rec.LicId == 0)?.Agr?.AgreementAddBr;
                    _ctrlAgreementBigRights.AgreementDataSource = agreementData; //(AgreementAddBr)

                }
                    break;

                case TypeRights.SmallRights:
                {
                    // ініціалізація контролу малих прав
                    if(_ctrlAgreementSmallRights == null)
                    {
                        _ctrlAgreementSmallRights = new AgreementWithPlacesControl
                        {
                            Location = _locationAgreement,
                            Name = "ctrlAgreementSmallRights",
                            Size = new Size(690, 390),
                            TabIndex = 0
                        };
                        pvAgreement.Controls.Add(_ctrlAgreementSmallRights);
                    }

                    _ctrlAgreementSmallRights.Rights = TypeRights;
                    // дані договору
                    var places = _customer.Client.ClnBusinessPlace;
                    var license = _customer.Client.LicenseAgreement.SingleOrDefault(rec => rec.LicId == 0);
                    var licAgr = license?.LicenseAgrParam.SingleOrDefault();
                    _ctrlAgreementSmallRights.InitializeObjects(places, license, licAgr, ConsumerAgreementInitType.AddNewAgreement);
                }
                    break;
            }
        }


        /// <summary>
        /// Встановлення даних
        /// </summary>
        /// <param name="customer">об'єкт споживач</param>
        public void SetDataAndDictionaries(Customer customer)
        {
            _customer = customer;
            if(IpsGlobal.AnketaDictionaties != null)
                _anketaDictionaries = IpsGlobal.AnketaDictionaties;
        }

        public void UpdateLicenses()
        {
            _ctrlAgreementSmallRights?.UpdateLicenses();
        }

        /// <summary>
        /// Перевірка валідності даних
        /// </summary>
        /// <param name="tabNumber">номер вкладки</param>
        /// <returns>true: дані валідні, false: помилка валідеості</returns>
        private bool Validator(byte tabNumber)
        {
            bool isValid = true;

            switch (tabNumber)
            {
                case 1: // - Назва клієнта
                    {
                        isValid = ctrlClientName.Validator();
                    }
                    break;
                case 2: // - Адреса
                    {
                        isValid = ctrlAddress.Validator();
                    }
                    break;

                case 3: // - Керівники
                    {
                        isValid = ctrlManagers.Validator();
                    }
                    break;

              //case 4: //- Майданчики

                case 5: // - Банківські реквізити
                    {
                        ctrlBankRequisites.Validator();
                    }
                    break;

                case 6: // - Договір
                    {
                        if(TypeRights == TypeRights.SmallRights)
                            isValid = _ctrlAgreementSmallRights.Validator();
                        if (TypeRights == TypeRights.BigRights)
                            isValid = _ctrlAgreementBigRights.Validator();
                    }
                    break;
                //case 7: - Друк (не потребує)
            }

            return isValid;
        }

        private async Task<WordEngine> LoadPdfDocAsync()
        {
            WordEngine wordEngine = new WordEngine(_anketaDictionaries);

            var licenseAgreement = _customer?.Client?.LicenseAgreement?.FirstOrDefault();
            int version = licenseAgreement?.LicVersion ?? default(int);
            string templateName = _anketaDictionaries?.agrLicenseType?.SingleOrDefault(rec => rec.CodeI == licenseAgreement?.LicCode)?.TemplateName ?? "F_Тестовий шаблон.docx";
            templateName = string.Concat(@"Templates\", templateName);

            return await Task.Run(() => {
                wordEngine.ProcessConsumer(templateName, _customer, licenseAgreement, version);
                return wordEngine;
            });

        }

        private void btnLoadPdf_Click(object sender, EventArgs e)
        {
            radWaitingBar1.StartWaiting();
            var task = Task.Run(() => LoadPdfDocAsync());
            task.Wait();
            var wordEngine = task.Result;
            // var wordEngine = Task.Run(()=> LoadPdfDocAsync()).GetAwaiter().GetResult();
            radWaitingBar1.StopWaiting();
            radPdfViewer.LoadDocument(wordEngine.Pdf);
        }

        private void radWaitingBar1_WaitingStarted(object sender, EventArgs e)
        {
            radWaitingBar1.Visible = true;
        }

        private void radWaitingBar1_WaitingStopped(object sender, EventArgs e)
        {
            radWaitingBar1.Visible = false;

        }
    }
}
