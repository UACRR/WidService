using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using ipsFormsDesign.Dictionary;
using IpsViewComponentLibrary.ConsumerControls.BigRight;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary
{
    public partial class AnketaConsumer : UserControl
    {
        private int _visiblePage;
        private bool isEdit = false;
        private readonly Dictionary<int, string[]> _buttonsName = new Dictionary<int, string[]>
        {
            {1, new []{"","Адреса >"} },
            {2, new []{"< Назва","Керівники >"} },
            {3, new []{"< Адреса","Майданчики >"} },
            {4, new []{"< Керівники","Реквізити >"} },
            {5, new []{"< Майданчики","Договір >"} },
            {6, new []{"< Реквізити","Друк >"} },
            {7, new []{"< Договір","Зберегти"} },
            {11, new []{ "< Адреса", "Реквізити >" } },
            {12, new []{ "< Керівники", "Договір >" } }
        };
        private RadDropDownButton btnsSave = null;
        private RadMenuItem _btnSave = null;
        private RadMenuItem _btnSaveAndAccept = null;

        private MiddleControlAgreementAnketaType ctrlAgreementSmallRights;
        
        private AgreementBigRight _ctrlAgreementBigRights;

        private ConsumerAnketeType _anketeType = ConsumerAnketeType.None;

        private ButtonType _btnType = ButtonType.None;
        private byte _nextPageNumber;
        private readonly Point _locationPoint = new Point(4, 35);

        private Customer _cust;
        private AnketaDictionaties _anketaDictionaries;

        public TypeRights TypeRights { get; set; } = TypeRights.SmallRights;
        //властивість наявності майданчиків
        public bool IsContainPlaces
        {
            get => ctrlClientName.IsPlaceIn;
            set => ctrlClientName.IsPlaceIn = value;
        }

        public Customer GetCustomer => _cust;

        public delegate void ReturnSaveCustomer(Customer cust);
        public event ReturnSaveCustomer OnBtnSaveClick;

        //default constructor
        public AnketaConsumer()
        {
            InitializeComponent();
            pageAnketaConsumer.SelectedPage = pvClientName;
            _visiblePage = 1;
            ChangeButtonsName(_visiblePage);
            btnBack.Visible = false;
            ctrlClientName.OnContainPlacesChanged += CtrlClientName_OnContainPlacesChanged; // при зміні наявності майданчиків
        }

        /// <summary>
        /// Ініціалізація даних для контрола (DATABINDING)
        /// </summary>
        /// <param name="isNew">Тип: true для нового користувача, false для редагуавння існуючого</param>
        public void InitializeControl(Func<string, IList<AutoCompleteData>> getAutoCompList, Func<int, Customer> getCustomerAnketa, ConsumerAnketeType anketeType)
        {
            _anketeType = anketeType;
            ctrlClientName.CheckPlace = TypeRights == TypeRights.BigRights;

            if (_anketeType == ConsumerAnketeType.CreateNewAnketa)
                ctrlClientName.SetAutoComplete(getAutoCompList, getCustomerAnketa);

            ReInitControl();
        }


        public void ReInitControl()
        {
            SetColorTabs(_anketeType);
            ctrlClientName.SetDataSources(_cust, _anketaDictionaries); // - - - - - - - -  Назва клієнта
            ctrlAddress.SetDataSources(_cust, _anketaDictionaries);    // - - - - - - - -  Адреса
            ctrlManagers.SetDataSources(_cust, _anketaDictionaries);   // - - - - - - - -  Керівники
            ctrlPlaces.SetData(_cust);  // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
            anketaCompanyBindingSource.DataSource = _cust?.Company?.AnketaCompany?.// - - - - - - - - - - - -
                SingleOrDefault(rec => rec?.Version == _cust?.AnkVersion); // - - - - - -  Майданчики (title)
            ctrlBankRequisites.SetDataSources(_cust, _anketaDictionaries); // - - - - - -  Банківські реквізити

            if(_anketeType == ConsumerAnketeType.CreateNewAnketa)
                InitAgreementType(TypeRights);

            if(TypeRights == TypeRights.BigRights)
                ctrlClientName.CheckPlace = true;

            //ctrlClientName.SetDefaultState();
            if (_anketeType == ConsumerAnketeType.EditAnketa)
            {
                pageAnketaConsumer.Pages["pvPrint"].Item.Visibility = ElementVisibility.Collapsed;
                pageAnketaConsumer.Pages["pvAgreement"].Item.Visibility = ElementVisibility.Collapsed;
                btnBack.Visible = false;
                btnNext.Visible = false;
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
                            Location = _locationPoint,
                            MaximumSize = new Size(900, 200),
                            MinimumSize = new Size(500, 200),
                            Name = "ctrlAgreementBigRights",
                            Size = new Size(596, 200),
                            TabIndex = 0
                        };
                        pvAgreement.Controls.Add(_ctrlAgreementBigRights);
                    }
                    
                    if (_cust?.Client?.LicenseAgreement?.LastOrDefault()?.LicCode != null)
                    {
                        var item = _cust.Client.LicenseAgreement.LastOrDefault();
                        item.LicCode = 28;
                        item.LicClass = 1;
                        item.LicType = 1;
                        item.LicVersion = 1;
                    }

                    if(!isEdit && _cust?.Client?.LicenseAgreement?.LastOrDefault()?.Agr?.AgreementAddBr.Count == 0)
                        _cust.Client.LicenseAgreement.LastOrDefault()?.Agr?.AgreementAddBr.Add(new AgreementAddBr {
                        Version = 1,
                        AgrStatus = 0,
                        AnkVersion = _cust.AnkVersion,
                        AgrNumber = string.Empty,
                        });
                    // control bindings
                    _ctrlAgreementBigRights.PaidPeriodDictionaryDataSource = _anketaDictionaries.period;// (Period)
                    _ctrlAgreementBigRights.AnketaCompanyDataSource = _cust.Company.AnketaCompany;// (AnketaCompany);
                    _ctrlAgreementBigRights.AgreementDataSource = _cust?.Client?.LicenseAgreement?.LastOrDefault()?.Agr?.AgreementAddBr; //(AgreementAddBr)

                }
                    break;

                case TypeRights.SmallRights:
                {
                    // ініціалізація контролу малих прав
                    if(ctrlAgreementSmallRights == null)
                    {
                        ctrlAgreementSmallRights = new MiddleControlAgreementAnketaType
                        {
                            Location = _locationPoint,
                            MinimumSize = new Size(490, 218),
                            Name = "ctrlAgreementSmallRights",
                            Size = new Size(690, 469),
                            TabIndex = 0
                        };
                        pvAgreement.Controls.Add(ctrlAgreementSmallRights);
                    }

                    ctrlAgreementSmallRights.typeRights = TypeRights; // - - - - - - - - - - - - - - - - - - - - - - - -  Договір
                    ctrlAgreementSmallRights.SetDataSources(_cust, _anketaDictionaries, _anketeType); // - - - - - - - -  Договір
                }
                    break;
            }
        }


        /// <summary>
        /// Обов'язковий метод 
        /// </summary>
        /// <param name="cust"></param>
        /// <param name="dict"></param>
        public void SetDataAndDictionaries(Customer cust, AnketaDictionaties dict)
        {
            _cust = cust;
            _anketaDictionaries = dict;
        }


        /// <summary>
        /// Перевірка на валідність даних
        /// </summary>
        /// <returns></returns>
        private bool Validator(byte type)
        {

            bool isValid = true;

            switch (type)
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

                case 4: //- Майданчики
                    {
                        isValid = true;
                    }
                    break;

                case 5: // - Банківські реквізити
                    {
                        ctrlBankRequisites.Validator();
                    }
                    break;

                case 6: // - Договір
                    {
                        if(TypeRights == TypeRights.SmallRights)
                            isValid = ctrlAgreementSmallRights.Validator();
                        if (TypeRights == TypeRights.BigRights)
                            isValid = _ctrlAgreementBigRights.Validator();
                    }
                    break;
                //case 7: - Друк (не потребує)
            }

            return isValid;
        }

        #region BUTTONS NAVIGATION
        // * * * BUTTON NEXT
        private void btnNext_Click(object sender, EventArgs e)
        {
            _btnType = ButtonType.Next;
            switch (_visiblePage)
            {
                case 1:
                    {
                        pageAnketaConsumer.SelectedPage = pvAddress;
                        ctrlAddress.SetDefaultState();
                    }
                    break;
                case 2:
                    {
                        pageAnketaConsumer.SelectedPage = pvManagers;

                    }
                    break;
                case 3:
                    {
                        pageAnketaConsumer.SelectedPage = pvPlaces;
                    }
                    break;
                case 4:
                    {
                        pageAnketaConsumer.SelectedPage = pvBankRequisites;
                    }
                    break;
                case 5:
                    {
                        pageAnketaConsumer.SelectedPage = pvAgreement;

                        if(TypeRights == TypeRights.SmallRights)
                            ctrlAgreementSmallRights.SetDefaultListItem();
                        if (TypeRights == TypeRights.BigRights) ;
                        //ctrlAgreementBigRights.SetBigRightsLicenseAgrType();
                    }
                    break;
                case 6:
                    {
                        pageAnketaConsumer.SelectedPage = pvPrint;
                    }
                    break;
                case 7:
                    {
                        _btnType = ButtonType.None;
                        OnBtnSaveClick?.Invoke(_cust);
                    }
                    break;
            }
        }

        private void CreateDropDownButton()
        {
            if(btnsSave != null) return;

            _btnSave = new RadMenuItem
            {
                Name = "btnSave",
                Text = "Зберегти"
            };
            _btnSaveAndAccept = new RadMenuItem
            {
                Name = "btnSaveAndAccept",
                Text = "Зберегти та підтвердити договір"
            };
            btnsSave = new RadDropDownButton
            {
                Location = btnNext.Location,
                Name = "btnsSave",
                Size = new Size(175, 24),
                Text = "Зберегти",
                ThemeName = "Office2013Light",
                Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)))
            };
            btnsSave.Items.AddRange(_btnSave, _btnSaveAndAccept);
            Controls.Add(btnsSave);
            _btnSave.Click += BtnSave_Click;
            _btnSaveAndAccept.Click += BtnSave_Click;
            btnsSave.BringToFront();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            _btnType = ButtonType.None;
            if(_cust?.Client?.LicenseAgreement?.LastOrDefault()?.LicStatus != null)
            {
                if ((Telerik.WinControls.RadElement) sender == _btnSave) // зберегти з статусом не підтверджений
                {
                    _cust.Client.LicenseAgreement.LastOrDefault().LicStatus = 0;
                }
                else if ((Telerik.WinControls.RadElement) sender == _btnSaveAndAccept) // зберегти з статусом активний
                {
                    _cust.Client.LicenseAgreement.LastOrDefault().LicStatus = 2;
                }

                if (TypeRights == TypeRights.BigRights)
                {
                    _cust.Client.LicenseAgreement.LastOrDefault().Agr.AgreementAddBr.SingleOrDefault().AgrStatus =
                        _cust.Client.LicenseAgreement.LastOrDefault().LicStatus;

                    _cust.Client.LicenseAgreement.LastOrDefault().Agr.AgrStatus =
                        _cust.Client.LicenseAgreement.LastOrDefault().LicStatus;
                }
                else if(TypeRights == TypeRights.SmallRights)
                {
                    _cust.Client.LicenseAgreement.LastOrDefault().LicenseAgrParam.SingleOrDefault().LicStatus = _cust.Client.LicenseAgreement.LastOrDefault().LicStatus;
                    _cust.Client.LicenseAgreement.LastOrDefault().Agr.AgrStatus = _cust.Client.LicenseAgreement.LastOrDefault().LicStatus;
                }
            }

            OnBtnSaveClick?.Invoke(_cust);
        }

        // * * * BUTTON BACK
        private void btnBack_Click(object sender, EventArgs e)
        {
            _btnType = ButtonType.Previos;
            switch (_visiblePage)
            {
                case 1:
                    {
                        //nothing action
                    }
                    break;
                case 2:
                    {
                        pageAnketaConsumer.SelectedPage = pvClientName;
                    }
                    break;
                case 3:
                    {
                        pageAnketaConsumer.SelectedPage = pvAddress;
                    }
                    break;
                case 4:
                    {
                        pageAnketaConsumer.SelectedPage = pvManagers;
                    }
                    break;
                case 5:
                    {
                        pageAnketaConsumer.SelectedPage = pvPlaces;
                    }
                    break;
                case 6:
                    {
                        pageAnketaConsumer.SelectedPage = pvBankRequisites;
                    }
                    break;
                case 7:
                    {
                        pageAnketaConsumer.SelectedPage = pvAgreement;
                    }
                    break;
            }
        }

        // * * * Зміна написів на кнопках при здійсненні навігації
        private void ChangeButtonsName(int key)
        {

            string[] names = _buttonsName[key];
            btnBack.Text = names[0];
            btnNext.Text = names[1];

            if (!IsContainPlaces)
            {
                if (key == 3)
                {
                    string[] namess = _buttonsName[11];
                    btnBack.Text = namess[0];
                    btnNext.Text = namess[1];
                }
                else if (key == 5)
                {
                    string[] namess = _buttonsName[12];
                    btnBack.Text = namess[0];
                    btnNext.Text = namess[1];
                }
            }
        }


        /// <summary>
        /// Set color page view tabs
        /// </summary>
        /// <param name="isNew">If new item set 'true' - set gray color, else 'false' - set default color</param>
        private void SetColorTabs(ConsumerAnketeType anketeType)
        {
            switch (anketeType)
            {
                case ConsumerAnketeType.CreateNewAnketa:
                    {
                        foreach (var page in pageAnketaConsumer.Pages)
                        {
                            page.Item.ForeColor = Color.DarkGray;
                        }
                        pageAnketaConsumer.Pages[0].Item.ForeColor = DefaultForeColor;
                        _nextPageNumber = 1;
                    }
                    break;

                case ConsumerAnketeType.EditAnketa:
                    {
                        foreach (var page in pageAnketaConsumer.Pages)
                        {
                            page.Item.ForeColor = DefaultForeColor;
                        }
                        _nextPageNumber = 5;
                    }
                    break;
            }
        }

        //зміна кольору вкладки з майданчиками при виборі чекбокса
        private void CtrlClientName_OnContainPlacesChanged(object sender, EventArgs e)
        {
            if (_nextPageNumber >= 4)
                pageAnketaConsumer.Pages[3].Item.ForeColor = IsContainPlaces ? DefaultForeColor : Color.DarkGray;
        }

        //переходи по вкладкам (кнопки та кліки)
        private void pageAnketaConsumer_SelectedPageChanging(object sender, Telerik.WinControls.UI.RadPageViewCancelEventArgs e)
        {
            //перехід на вкладку майданчиків за умови що їх немає

            switch (_btnType)
            {
                case ButtonType.Next:
                    {
                        if (Validator((byte)_visiblePage))
                        {
                            if (isEdit && e.Page.TabIndex == 4)
                            {
                                btnNext.Enabled = false;
                            }
                            else if (btnNext.Enabled == false)
                                btnNext.Enabled = true;

                            if (e.Page.TabIndex == 3 && !IsContainPlaces)
                            {
                                _visiblePage++;
                                pageAnketaConsumer.SelectedPage = pvBankRequisites;
                                e.Cancel = true;
                                pageAnketaConsumer.Pages[e.Page.TabIndex + 1].Item.ForeColor = DefaultForeColor;
                                if (_nextPageNumber == e.Page.TabIndex)
                                    _nextPageNumber += 2;
                            }
                            else
                            {
                                ChangeButtonsName(_visiblePage + 1);
                                if (_visiblePage == 1)
                                    btnBack.Visible = true && _anketeType == ConsumerAnketeType.CreateNewAnketa;
                                if (_visiblePage != 7)
                                    _visiblePage++;
                                _btnType = ButtonType.None;
                                if (_nextPageNumber == e.Page.TabIndex)
                                    _nextPageNumber++;
                                pageAnketaConsumer.Pages[e.Page.TabIndex].Item.ForeColor = DefaultForeColor;
                            }
                        }
                        else
                            e.Cancel = true;
                    }
                    break;

                case ButtonType.Previos:
                    {
                        if (btnNext.Enabled == false)
                            btnNext.Enabled = true;

                        if (e.Page.TabIndex == 3 && !IsContainPlaces)
                        {
                            _visiblePage--;
                            pageAnketaConsumer.SelectedPage = pvManagers;
                            e.Cancel = true;
                        }
                        else
                        {
                            ChangeButtonsName(_visiblePage - 1);
                            if (_visiblePage == 2)
                                btnBack.Visible = false;
                            _visiblePage--;
                            _btnType = ButtonType.None;
                        }
                    }
                    break;

                case ButtonType.None:
                    {
                        if (isEdit && e.Page.TabIndex == 4)
                        {
                            btnNext.Enabled = false;
                        }
                        else if (btnNext.Enabled == false)
                            btnNext.Enabled = true;

                        if (e.Page.TabIndex == 3 && !IsContainPlaces)
                        {
                            e.Cancel = true;
                        }
                        else
                        {
                            if (e.Page.TabIndex < _nextPageNumber && Validator((byte)_visiblePage))
                            {
                                _visiblePage = e.Page.TabIndex + 1;
                                ChangeButtonsName(_visiblePage);
                                btnBack.Visible = e.Page.TabIndex > 0 && _anketeType == ConsumerAnketeType.CreateNewAnketa;
                            }
                            else
                            {
                                e.Cancel = true;
                            }
                        }

                    }
                    break;
            }
        }

        #endregion

        private async Task<WordEngine> LoadPdfDocAsync()
        {
            WordEngine wordEngine = new WordEngine(_anketaDictionaries);

            var licenseAgreement = _cust?.Client?.LicenseAgreement?.FirstOrDefault();
            int version = licenseAgreement?.LicVersion ?? default(int);
            string templateName = _anketaDictionaries?.agrLicenseType?.SingleOrDefault(rec => rec.CodeI == licenseAgreement?.LicCode)?.TemplateName ?? "F_Тестовий шаблон.docx";
            templateName = string.Concat(@"Templates\", templateName);

            return await Task.Run(() => {
                wordEngine.ProcessConsumer(templateName, _cust, licenseAgreement, version);
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

        private void pageAnketaConsumer_SelectedPageChanged(object sender, EventArgs e)
        {
            if (pageAnketaConsumer.SelectedPage == pvPrint)
            {
                btnNext.Enabled = false;
                btnNext.Visible = false;
                CreateDropDownButton();
                btnsSave.Enabled = true;
                btnsSave.Visible = true;
            }
            else
            {
                if (btnsSave == null) return;
                btnsSave.Enabled = false;
                btnsSave.Visible = false;
                btnNext.Enabled = true;
                btnNext.Visible = true;
            }
        }
    }

    internal enum ButtonType
    {
        None,
        Next,
        Previos
    }
}
