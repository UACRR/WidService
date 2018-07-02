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

namespace IpsViewComponentLibrary
{
    public partial class GlobalControlConsumerAnketa : UserControl
    {
        private int _visiblePage;
        private bool isEdit = false;
        private Dictionary<int, string[]> _buttonsName = new Dictionary<int, string[]>
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

        private ButtonType _btnType = ButtonType.None;
        private byte _nextPageNumber;

        private Customer _cust;
        private AnketaDictionaties _anketaDictionaries;

        public TypeRights typeRights { get; set; } = TypeRights.SmallRights;
        //властивість наявності майданчиків
        public bool IsContainPlaces
        {
           get => ctrlClientName.IsPlaceIn;
           set => ctrlClientName.IsPlaceIn = value;
        }

        public Customer GetCustomer => _cust;

        public delegate string GeneratePdfDoc(Customer customer, AnketaDictionaties dictionaties);
        public event GeneratePdfDoc OnDocumentNeedGenerate;

        public delegate void ReturnSaveCustomer(Customer cust);
        public event ReturnSaveCustomer OnBtnSaveClick;

        public GlobalControlConsumerAnketa()
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
        public void InitializeControl(bool isNew = true)
        {

            isEdit = !isNew;
            SetTypePages(isNew);
            SetColorTabs(isNew);

            ctrlClientName.SetDataSources(_cust,_anketaDictionaries); // - - - - - - - -  Назва клієнта
            ctrlAddress.SetDataSources(_cust,_anketaDictionaries);    // - - - - - - - -  Адреса
            ctrlManagers.SetDataSources(_cust,_anketaDictionaries);   // - - - - - - - -  Керівники
            ctrlPlaces.SetData(_cust);       //  - - - - - - - - - - - - - - - - - - - -  Майданчики (source)
            ctrlPlaces.SetGridDataSource(_cust?.Client?.ClnBusinessPlace?.Count != 0// -  Майданчики (grid)
                ? _cust?.Client?.ClnBusinessPlace // - - - - - - - - - - - - - - - - - - 
                : null);                          // - - - - - - - - - - - - - - - - - -
            ctrlPlacesTitle.Text =              // - - - - - - - - - - - - - - - - - - -
                _cust?.Company?.AnketaCompany?. // - - - - - - - - - - - - - - - - - - -
                SingleOrDefault(rec => rec?.Version == _cust?.AnkVersion)?.Name; ;// - -  Майданчики (title)
            ctrlBankRequisites.SetDataSources(_cust,_anketaDictionaries); // - - - - - -  Банківські реквізити

            ctrlAgreement.typeRights = typeRights;                    // - - - - - - - -  Договір
            ctrlAgreement.SetDataSources(_cust,_anketaDictionaries);  // - - - - - - - -  Договір

            ctrlClientName.SetDefaultState();
        }

        /// <summary>
        /// Ввімкненість вкладок 'договору' та 'друку'
        /// </summary>
        /// <param name="isnew">true(default) - новий споживач, стандартна фарма, false - редагування існуючого споживача</param>
        private void SetTypePages(bool isnew)
        {
            if(isnew)
            {
                return;
            }
          
            pvAgreement.Enabled = false;
            pvPrint.Enabled = false;
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
                    //TODO: якщо не додано жодного майданчику видавати помилку
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
                    isValid = ctrlAgreement.Validator();
                }
                    break;
                case 7: // - Друк (не потребує)
                {
                    isValid = true;
                }
                    break;
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
                        if (isEdit)
                        {
                            _btnType = ButtonType.None;
                            OnBtnSaveClick?.Invoke(_cust);
                            return;
                        }
                        pageAnketaConsumer.SelectedPage = pvAgreement;
                        ctrlAgreement.SetDefaultListItem();
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
            
            if(!IsContainPlaces)
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
        private void SetColorTabs(bool isNew)
        {
            switch (isNew)
            {
                case true:
                {
                    foreach (var page in pageAnketaConsumer.Pages)
                    {
                        page.Item.ForeColor = Color.DarkGray;
                    }
                    pageAnketaConsumer.Pages[0].Item.ForeColor = DefaultForeColor;
                    _nextPageNumber = 1;
                }
                    break;

                case false:
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
            if(_nextPageNumber >= 4)
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
                                    btnBack.Visible = true;
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
                                btnBack.Visible = e.Page.TabIndex > 0;
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

        private void btnLoadPdf_Click(object sender, EventArgs e)
        {
            WordEngine wordEngine = new WordEngine(_anketaDictionaries);
            var licenseAgreement = _cust?.Client?.LicenseAgreement?.FirstOrDefault();
            int version = licenseAgreement?.LicVersion ?? default(int);
            string templateName = _anketaDictionaries?.agrLicenseType?.SingleOrDefault(rec => rec.CodeI == licenseAgreement?.LicCode)?.TemplateName ?? "F_Тестовий шаблон.docx";
            templateName = string.Concat(@"Templates\", templateName);
            
            
            wordEngine.ProcessConsumer(templateName, _cust, licenseAgreement, version);
            var pdf = wordEngine.Pdf;
            radPdfViewer.LoadDocument(pdf);
            
        }
    }

    internal enum ButtonType
    {
        None,
        Next,
        Previos
    };
}
