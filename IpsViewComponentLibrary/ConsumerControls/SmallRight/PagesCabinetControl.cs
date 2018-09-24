using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;

namespace IpsViewComponentLibrary
{
    public partial class PagesCabinetControl : UserControl
    {
        private Customer _customer;
        private AnketaDictionaties _dictionaties;
        private int _idItem;

        public delegate void CustomerSave(Customer customer);
        public event CustomerSave OnCustomerSave;
        public event ReturnObjectEventHandler<AnketaPerson> GetPartner;

        public event SetPartnerEventHandler OnSetPartner;
        public event SetPartnerEventHandler OnRemovePartner;
        public event ChangePartnerEventHandler OnChangePartner;
        public event GetPartnerList OnGetPartnerListNeed;

        public event LisenseStatusChangeEventHandler OnChangeLicenseStatus;
        public event UpdateCustomerDataEventHandler OnUpdateCustomerNeed;

        /// <summary>
        /// Тип прав (великі або малі права)
        /// </summary>
        public TypeRights Rights { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public PagesCabinetControl()
        {
            InitializeComponent();
            pvMain.SelectedPage = pvAnketa;
            ctrlAgrDetailInfo.OnSaveCommentNeed += OnSaveCommentNeed;
            ctrlAgrDetailInfoMore.OnSaveCommentNeed += OnSaveCommentNeed;
            ctrlPartner.OnGetPartnerListNeed += CtrlPartner_OnGetPartnerListNeed;
            ctrlPartner.OnSetPartner += CtrlPartner_OnSetPartner;
            ctrlPartner.OnChangePartner += CtrlPartner_OnChangePartner;
            ctrlPartner.OnRemovePartner += CtrlPartner_OnRemovePartner;
        }

        //присвоїти представника
        private bool CtrlPartner_OnSetPartner(int clientId, int partnerId)
        {
            return OnSetPartner?.Invoke(clientId, partnerId) ?? false;
        }

        //змінити представника
        private bool CtrlPartner_OnChangePartner(int clientId, int partnerId, int oldPartnerId)
        {
            return OnChangePartner?.Invoke(clientId, partnerId, oldPartnerId) ?? false;
        }

        //відкріптии представника
        private bool CtrlPartner_OnRemovePartner(int clientId, int partnerId)
        {
            return OnRemovePartner?.Invoke(clientId, partnerId) ?? false;
        }


        private List<AnketaPerson> CtrlPartner_OnGetPartnerListNeed()
        {
            return OnGetPartnerListNeed?.Invoke();
        }

        // * * * * * * * * * * * * * * * * * * * * * * * * //

        #region * * * PUBLIC METHODS * * *

        /// <summary>
        /// Зміна активованості та очищення даних коли анкету не обрано
        /// </summary>
        /// <param name="anketaCount">Параметр наявності анкет</param>
        public void SetStateWhenChangeAnketaCount(AnketaCount anketaCount)
        {
            switch (anketaCount)
            {
                case AnketaCount.Empty:
                {
                    ClearData();
                    pvMain.Enabled = false;
                    return;
                }
                case AnketaCount.NotEmpty:
                {
                    pvMain.Enabled = true;
                    return;
                }
            }
        }

        public void SetDictionary(AnketaDictionaties dict)
        {
            _dictionaties = dict;
        }

        /// <summary>
        /// Встановлення даних
        /// </summary>
        /// <param name="customer"></param>
        public void SetCustomerData(Customer customer)
        {
            _customer = customer;
            ctrlAnketaConsumer.SetDataAndDictionaries(_customer, _dictionaties);
            ctrlAnketaConsumer.InitializeControl(null, null, ConsumerAnketeType.EditAnketa);
            ctrlHeaderInfo.SetControlTextInfoSmallRight(_customer);
            SetLicenseAgrGridDataSource();
            SetLicenseAgrMoreGridDataSource();
            calculationCtrl.TypeRights = TypeRights.SmallRights;
            calculationCtrl.Customer = _customer;
            ctrlPaysInfo1.Customer = _customer;
            ctrlPartner.SetPartnerData(GetPartner?.Invoke(_customer.CustId), _customer.CustId);
        }

        #endregion

        //кнопка [Додати договір] (ОБИДВІ ВКЛАДКИ)
        private void btnAddAgreement_Click(object sender, EventArgs e)
        {
            _customer.Client.LicenseAgreement.Add(new LicenseAgreement
            {
                CustId = _customer.CustId,
                LicVersion = 1,
                LicStatus = 0,
                LicCode = Rights == TypeRights.SmallRights ? 1 : Rights == TypeRights.BigRights ? 10 : default(int),
                LicenseAgrParam = new ObservableListSource<LicenseAgrParam>
                {
                    new LicenseAgrParam
                    {
                        LicVersion = 1,
                        //LicDate = DateTime.Today,
                        //DateBegin = DateTime.Today,
                        //DateEnd = DateTime.Today.AddYears(1),
                        LicStatus = 0,
                    }
                }
            });
            var license = _customer?.Client?.LicenseAgreement?.LastOrDefault();
            var licenseParam = license?.LicenseAgrParam.SingleOrDefault(rec => rec.LicVersion == license.LicVersion);
            RunDialogForLicenseAgrParam(license, licenseParam, DialogGoal.forNew);
        }

        #region * * * ВКЛАДКА [АКТИВНІ ДОГОВОРИ] * * *

        // конструктор даних для грід
        private void SetLicenseAgrGridDataSource()
        {
            List<GridLicenseAgrView> source = new List<GridLicenseAgrView>();
            if (_customer?.Client.LicenseAgreement != null)
                foreach (var item in _customer.Client.LicenseAgreement.Where(rec => rec.LicStatus == 2 && rec.LicClass == 0))
                {
                    //якщо з малими правами, пропустити
                    if (Rights == TypeRights.BigRights && _dictionaties?.agrLicenseType?.SingleOrDefault(rec => rec?.CodeI == item?.LicCode)?.UsesKind != 1) continue;

                    var licenseParam = item?.LicenseAgrParam.SingleOrDefault(rec => rec.LicVersion == item.LicVersion);

                    source.Add(new GridLicenseAgrView
                    {
                        Id = item.AgrId,
                        LicId = item.LicId,
                        License = _dictionaties.agrLicenseType.SingleOrDefault(rec => rec?.CodeI == item?.LicCode)?.Name,
                        Series = string.Empty,
                        AgrNumber = licenseParam?.LicNum ?? string.Empty,
                        DateBegin = licenseParam?.DateBegin?.ToShortDateString() ?? string.Empty,
                        DateEnd = licenseParam?.DateEnd?.ToShortDateString() ?? string.Empty,
                        MinAmount = licenseParam?.MinAmount ?? default(decimal),
                        MinRate = licenseParam?.RateAmount ?? default(decimal),
                        State = _dictionaties?.agreementStatus?.SingleOrDefault(rec => rec.CodeI == licenseParam?.LicStatus)?.Name ?? string.Empty,
                        PeriodPayment = _dictionaties?.period?.SingleOrDefault(p => p.CodeI == licenseParam?.PeriodCode)?.Name ?? string.Empty,
                        DateLastPayment = "",
                        LicenseAgreement = item,
                        IsAutoprolog = licenseParam?.IsAutoprolog ?? false,
                    });
                }
            //
            gvLicenseAgr.DataSource = source;
            gvLicenseAgr.MasterTemplate.Refresh();
            gvLicenseAgr.Update();
        }

        bool inCurrentRowChanged = false;
        // при зміні рядка грід
        private void gvLicenseAgr_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            if (inCurrentRowChanged) return;
            if (!(e?.CurrentRow?.DataBoundItem is GridLicenseAgrView curRow))
            {
                ctrlAgrDetailInfo.ClearData();
                return;
            }
            inCurrentRowChanged = true;
            SetAgrInfoData(curRow.LicId, GridCallMethod.ActiveAgreementGrid);
            currentAgreementController1?.ChangeCurrentLicenseAgreement(this, curRow.LicenseAgreement);
            inCurrentRowChanged = false;

        }

        // кнопка [Пролонгувати договір]
        private void btnProlongation_Click(object sender, EventArgs e)
        {
            LicenseAgrParam prolongLicense = null;
            var licId = (gvLicenseAgr?.CurrentRow?.DataBoundItem as GridLicenseAgrView)?.LicId;
            var license = _customer?.Client?.LicenseAgreement?.Where(rec => rec.LicId == licId).SingleOrDefault();
            if (license == null)
                return;

            //максимальна версія поточної ліцензії
            var licVersion = license?.LicenseAgrParam.Max(rec => rec.LicVersion);

            prolongLicense = license.LicenseAgrParam.SingleOrDefault(rec => rec?.LicVersion == license.ProlongVersion);

            // Кількість доп угод з версією більшою за поточну > 0 //якщо є хоча б одна угода для пролонгації
            if (prolongLicense != null)
            {
                if(MessageBox.Show("Пролонгована версія договору вже існує! Відкрити для перегляду/редагування?", "Повідомлення", MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question) == DialogResult.Yes)
                    RunDialogForLicenseAgrParam(license, prolongLicense, DialogGoal.forExistProlongation);
            }
            // Інакше == 0
            else
            {
                // -- Створити нову
                // -- Збільшити версію на 1
                var newLicense = new LicenseAgrParam();
                var licParam = license.LicenseAgrParam.SingleOrDefault(rec => rec.LicVersion == license.LicVersion);

                newLicense.SetFields(licParam);

                if (licParam?.DateEnd != null)
                {
                    newLicense.LicDate = licParam?.DateEnd.Value.AddDays(1);
                    newLicense.DateBegin = licParam?.DateEnd.Value.AddDays(1);
                    newLicense.DateEnd = new DateTime(newLicense.DateBegin.Value.Year, 12, 31);

                }

                newLicense.LicVersion = (licVersion ?? 0) + 1;
                newLicense.License = licParam?.License;
                license.ProlongVersion = newLicense.LicVersion;
                license?.LicenseAgrParam?.Add(newLicense);
                prolongLicense = license?.LicenseAgrParam.LastOrDefault();
                RunDialogForLicenseAgrParam(license, prolongLicense, DialogGoal.forProlongation);
            }
        }

        // кнопка [Змінити договір]
        private void btnChangeAgreement_Click(object sender, EventArgs e)
        {
            LicenseAgrParam parametr;
            var licId = (gvLicenseAgr.CurrentRow.DataBoundItem as GridLicenseAgrView)?.LicId;
            var license = _customer?.Client?.LicenseAgreement?.Where(rec => rec.LicId == licId).SingleOrDefault();
            if (license == null)
                return;


            LicenseAgrParam changeLicense = null;
            var listDopAgr = license.LicenseAgrParam.Where(rec => rec.LicStatus < 4 && rec.LicVersion > license.LicVersion).ToList();
            // Кількість доп угод з версією більшою за поточну > 0 //якщо є хоча б одна угода для пролонгації
            if (listDopAgr.Any(rec => rec.LicVersion != license.ProlongVersion))
            {
                parametr = listDopAgr.SingleOrDefault(rec => rec.LicVersion != license.ProlongVersion);
            }
            // Інакше == 0
            else
            {
                // -- Створити нову
                changeLicense = new LicenseAgrParam();

                //поточна версія
                var licParam = license?.LicenseAgrParam.SingleOrDefault(rec => rec.LicVersion == license.LicVersion);
                //номер версії

                changeLicense.SetFields(licParam);

                if (licParam?.DateEnd != null)
                {
                    changeLicense.LicDate = DateTime.Today;
                    changeLicense.DateBegin = DateTime.Today;
                    changeLicense.DateEnd = licParam.DateEnd;
                    changeLicense.LicStatus = 0;
                }

                // -- Збільшити версію на 1
                var licVersion = license?.LicenseAgrParam.Max(rec => rec.LicVersion);
                changeLicense.LicVersion = (licVersion ?? 0) + 1;
                changeLicense.License = licParam?.License;
                license.LicenseAgrParam?.Add(changeLicense);
                parametr = license.LicenseAgrParam.LastOrDefault();
            }

            //newLicense.LicId = 0;

            RunDialogForLicenseAgrParam(license, parametr, DialogGoal.forChange);
        }

        // кнопка [Закрити договір]
        private void btnCloseAgr_Click(object sender, EventArgs e)
        {
            if (!(gvLicenseAgr?.CurrentRow?.DataBoundItem is GridLicenseAgrView curRow)) return;
            var license = _customer?.Client?.LicenseAgreement?.SingleOrDefault(rec => rec.LicId == curRow.LicId);
            if (license == null) return;

            if (MessageBox.Show("Ліцензійний договір буде закритий та автоматично видалений. Підтвердити дію?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (OnChangeLicenseStatus?.Invoke(license, license.LicVersion ?? default(int), 4, false) ?? false)
                    ExtensionUtils.ShowInfoMessage("Ліцензію закрито!", "Успішно", MessageBoxIcon.Information);
                else
                    ExtensionUtils.ShowInfoMessage("Не можливо закрити ліцензію", "Помилка", MessageBoxIcon.Error);
            }
        }

        // кнопка [Друкувати договір]
        private void PrintAgreement(int licId)
        {
            var lic = _customer.Client.LicenseAgreement.SingleOrDefault(rec => rec.LicId == licId);
            ViewAndPrintAgreement print = new ViewAndPrintAgreement(dictionaties: _dictionaties, customer: _customer, licenseAgreement: lic)
            {
                WindowState = FormWindowState.Maximized,
                StartPosition = FormStartPosition.CenterScreen
            };
            print.ShowDialog();
        }

        #endregion

        // * * * * * * * * * * * * * * * * * * * * * * * * //

        #region * * * ВКЛАДКА [НЕ ПІДТВЕРДЖЕНІ ДОГОВОРИ] * * *
        
        // конструктор даних для грід
        private void SetLicenseAgrMoreGridDataSource()
        {
            List<GridLicenseAgrView> source = new List<GridLicenseAgrView>();
            if (_customer?.Client.LicenseAgreement != null)
            {
                foreach (var license in _customer.Client.LicenseAgreement.Where(rec => rec.LicClass == 0).ToList())
                {
                    if (license.LicenseAgrParam.Count == 1 && license.LicStatus == 2)
                        continue;

                    if (license.LicenseAgrParam.Count == 1 && license.LicStatus != 2)
                    {
                        var agrParam = license.LicenseAgrParam?.SingleOrDefault();
                        source.Add(new GridLicenseAgrView
                        {
                            Id = license.AgrId,
                            LicVersion = agrParam?.LicVersion,
                            LicId = license.LicId,
                            License = _dictionaties.agrLicenseType.SingleOrDefault(rec => rec?.CodeI == license?.LicCode)?.Name,
                            Series = string.Empty,
                            MinAmount = agrParam?.MinAmount ?? default(decimal),
                            MinRate = agrParam?.RateAmount ?? default(decimal),
                            AgrNumber = agrParam?.LicNum ?? string.Empty,
                            AgrMasterNumber = license.LicenseAgrParam.SingleOrDefault(rec => rec.LicVersion == license.LicVersion)?.LicNum,
                            DateBegin = agrParam?.DateBegin?.ToShortDateString() ?? string.Empty,
                            DateEnd = agrParam?.DateEnd?.ToShortDateString() ?? string.Empty,
                            State = _dictionaties?.agreementStatus?.SingleOrDefault(rec => rec.CodeI == license.LicenseAgrParam?.SingleOrDefault()?.LicStatus)?.Name ?? string.Empty,
                            Status = agrParam?.LicStatus,
                            PeriodPayment = _dictionaties?.period?.SingleOrDefault(p => p.CodeI == license.LicenseAgrParam?.SingleOrDefault()?.PeriodCode)?.Name ?? string.Empty,
                            IsAutoprolog = agrParam?.IsAutoprolog ?? false,

                        });
                        continue;
                    }

                    foreach (var agrParam in license.LicenseAgrParam)
                    {
                        if (agrParam.LicVersion > license.LicVersion)
                            source.Add(new GridLicenseAgrView
                            {
                                Id = license.AgrId,
                                LicId = license.LicId,
                                LicVersion = agrParam.LicVersion,
                                License = _dictionaties.agrLicenseType.SingleOrDefault(rec => rec?.CodeI == license?.LicCode)?.Name,
                                Series = string.Empty,
                                MinAmount = agrParam.MinAmount ?? default(decimal),
                                MinRate = agrParam.RateAmount ?? default(decimal),
                                AgrNumber = agrParam.LicNum ?? string.Empty,
                                AgrMasterNumber = license.LicenseAgrParam.SingleOrDefault(rec => rec.LicVersion == license.LicVersion)?.LicNum,
                                DateBegin = agrParam.DateBegin?.ToShortDateString() ?? string.Empty,
                                DateEnd = agrParam.DateEnd?.ToShortDateString() ?? string.Empty,
                                State = _dictionaties?.agreementStatus?.SingleOrDefault(rec => rec.CodeI == agrParam?.LicStatus)?.Name ?? string.Empty,
                                Status = agrParam.LicStatus,
                                PeriodPayment = _dictionaties?.period?.SingleOrDefault(p => p.CodeI == agrParam?.PeriodCode)?.Name ?? string.Empty,
                                IsAutoprolog = agrParam.IsAutoprolog ?? false,
                            });
                    }
                }
            }

            gvMoreLicenseAgr.DataSource = source;
            gvMoreLicenseAgr.MasterTemplate.Refresh();
            gvMoreLicenseAgr.Update();
        }
        // при зміні рядка грід
        private void gvMoreLicenseAgr_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            if (!(e?.CurrentRow?.DataBoundItem is GridLicenseAgrView curRow))
            {
                ctrlAgrDetailInfoMore.ClearData();
                return;
            }

            btnDenied.Enabled = curRow.Status == 1;
            btnAccept.Enabled = (curRow.Status == 0 || curRow.Status == 1);
            SetAgrInfoData(curRow.LicId, GridCallMethod.NotActiveAgreementGrid);
        }

        //зміна статусу договору
        private void ChangeStatusAgreement(int status)
        {
            if (gvMoreLicenseAgr.CurrentRow.DataBoundItem is GridLicenseAgrView item)
            {
                bool actResult = false;
                var license = _customer.Client.LicenseAgreement.SingleOrDefault(rec => rec.LicId == item.LicId);
                if(status == 2)
                {
                    actResult = OnChangeLicenseStatus?.Invoke(license, license?.LicenseAgrParam?.LastOrDefault()?.LicVersion ?? 0, status, true) ?? false;
                    if (actResult)
                        ExtensionUtils.ShowInfoMessage("Ліцензійний договір переведено в статус \"Активний\"!", "Успішно",
                            MessageBoxIcon.Information);
                    else
                        ExtensionUtils.ShowInfoMessage("Неможливо змінити статус ліцензійного договору!", "Помилка",
                            MessageBoxIcon.Error);
                }
                else if(status == 5)
                {
                    actResult = OnChangeLicenseStatus?.Invoke(license, license?.LicenseAgrParam?.LastOrDefault()?.LicVersion ?? 0, status, false) ?? false;
                    if (actResult)
                        ExtensionUtils.ShowInfoMessage("Ліцензійний договір переведено в статус \"Відхилений\"!", "Успішно",
                            MessageBoxIcon.Exclamation);
                    else
                        ExtensionUtils.ShowInfoMessage("Неможливо змінити статус ліцензійного договору!", "Помилка",
                            MessageBoxIcon.Error);
                }
            }
        }

        // кнопка [Підтвердити договір]
        private void btnAccept_Click(object sender, EventArgs e)
        {
            ChangeStatusAgreement(2);
        }

        // кнопка [Відхилити договір]
        private void btnDenied_Click(object sender, EventArgs e)
        {
            ChangeStatusAgreement(5);
        }

        #endregion

        // * * * * * * * * * * * * * * * * * * * * * * * * //

        #region * * * PRIVATE METHODS * * * 

        // кнопка на гріду [Видалити договір]
        private void ColumnDeleteClick()
        {
            if (!(gvMoreLicenseAgr?.CurrentRow?.DataBoundItem is GridLicenseAgrView curRow)) return;
            var license = _customer?.Client?.LicenseAgreement?.SingleOrDefault(rec => rec.LicId == curRow.LicId);
            if (license == null) return;

            if (MessageBox.Show("Ліцензія буде закрита та автоматично видалена. Підтвердити дію?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (OnChangeLicenseStatus?.Invoke(license, curRow?.LicVersion ?? default(int), 4, false) ?? false)
                    ExtensionUtils.ShowInfoMessage("Ліцензію закрито!", "Успішно", MessageBoxIcon.Information);
                else
                    ExtensionUtils.ShowInfoMessage("Не можливо закрити ліцензію", "Помилка", MessageBoxIcon.Error);
            }
        }

        // кнопка [Редагувати договір]
        private void ColumnEditClick()
        {
            if (!(gvMoreLicenseAgr?.CurrentRow?.DataBoundItem is GridLicenseAgrView curRow)) return;

            //поточна ліцензія
            var license = _customer?.Client?.LicenseAgreement?.SingleOrDefault(rec => rec.LicId == curRow.LicId);
            if (license == null)
                return;

            //редагування нового
            if (license.LicenseAgrParam.Count == 1)
            {
                RunDialogForLicenseAgrParam(license, license.LicenseAgrParam.SingleOrDefault(), DialogGoal.forEdit);
                return;
            }

            var listDopAgr = license.LicenseAgrParam.Where(rec => rec.LicStatus < 4 && rec.LicVersion > license.LicVersion).ToList();
            //редагування зміненого
            if (listDopAgr.Any(rec => rec.LicVersion == curRow.LicVersion && rec.LicVersion != license.ProlongVersion))
            {
                var licAgrParam = license.LicenseAgrParam.Where(rec => rec.LicVersion > license.LicVersion).SingleOrDefault(rec => rec.LicVersion != license.ProlongVersion);
                RunDialogForLicenseAgrParam(license, licAgrParam, DialogGoal.forChange);
                return;
            }
            //редагування пролонгованого
            if (listDopAgr.Any(rec => rec.LicVersion == curRow.LicVersion && rec.LicVersion == license.ProlongVersion))
            {
                var licAgrParam = license?.LicenseAgrParam.SingleOrDefault(rec => rec.LicVersion == license.ProlongVersion);
                RunDialogForLicenseAgrParam(license, licAgrParam, DialogGoal.forProlongation);
            }
        }

        // оновити дані коли рядок на грід ліцензій змінено / Інформація по договору
        private void SetAgrInfoData(int? idItem, GridCallMethod methodType)
        {
            if (idItem == null) return;

            _idItem = (int)idItem;
            var license = _customer?.Client?.LicenseAgreement?.Where(rec => rec.LicId == idItem).FirstOrDefault(rec => rec.LicStatus < 4);
            var licenseParam = license?.LicenseAgrParam.SingleOrDefault(rec => rec.LicVersion == license.LicVersion);
            switch (methodType)
            {
                case GridCallMethod.ActiveAgreementGrid:
                    ctrlAgrDetailInfo.SetDataInfo(licenseParam);
                    break;
                case GridCallMethod.NotActiveAgreementGrid:
                    ctrlAgrDetailInfoMore.SetDataInfo(licenseParam);
                    break;
            }
        }

        //Встановлення початкових вкладок
        private void SetDefaultPages()
        {
            pvSecond.SelectedPage = pvSecond.DefaultPage;
            pvMain.SelectedPage = pvMain.DefaultPage;
        }
        // Очищення даних 
        private void ClearData()
        {
            SetDefaultPages();
            ctrlPaysInfo1.Customer = null;
            gvLicenseAgr.DataSource = new object();
        }

        //збереження Customer
        private void OnSaveCommentNeed(object sender, EventArgs e)
        {
            OnCustomerSave?.Invoke(_customer);
        }

        /// <summary>
        /// Визов метода активації договору
        /// </summary>
        /// <param name="license"></param>
        /// <param name="licenseParam"></param>
        private void RunDialogForLicenseAgrParam(LicenseAgreement license, LicenseAgrParam licenseParam, DialogGoal goal)
        {
            var anketaCompany = _customer.Company.AnketaCompany.SingleOrDefault();
            var licenseName = _dictionaties.agrLicenseType.SingleOrDefault(rec => rec?.CodeI == license?.LicCode)?.Name;

            ProlongationWithPlaces prolongation = new ProlongationWithPlaces(licenseParam, anketaCompany, _dictionaties, license,
                _customer?.Client?.ClnBusinessPlace, _customer, goal, Rights)
            {
                Text = goal == DialogGoal.forEdit ? "Редагування договору"
                    : goal == DialogGoal.forProlongation ? "Пролонгація договору"
                    : goal == DialogGoal.forNew ? "Додавання нового договору"
                    : goal == DialogGoal.forExistProlongation ? "Перегляд/редагування пролонгованого договору"
                    : goal == DialogGoal.forChange || goal == DialogGoal.forExistChange ? "Внесення змін до активного договору"
                    : string.Empty,
                StartPosition = FormStartPosition.CenterParent
            };
            prolongation.OnSaveProlongation += OnSaveCommentNeed;
            prolongation.ShowDialog();
        }

        #endregion

        // * * * * * * * * * * * * * * * * * * * * * * * * //

        #region * * * ENUMS * * *

        /// <summary>
        /// Тип гріда, який викликає метод оновлення даних
        /// </summary>
        private enum GridCallMethod
        {
            /// <summary>
            /// Активні договори
            /// </summary>
            ActiveAgreementGrid,
            /// <summary>
            /// Не підтверджені договори
            /// </summary>
            NotActiveAgreementGrid
        }

        /// <summary>
        /// Кількість анкет користувачів
        /// </summary>
        public enum AnketaCount
        {
            /// <summary>
            /// Немає жодної анкети
            /// </summary>
            Empty,
            /// <summary>
            /// Присутня принаймні одна анкета
            /// </summary>
            NotEmpty
        }

        #endregion

        private void currentAgreementController1_CurrentLicenseAgreementChanged(object sender, LicenseAgreement e)
        {
            if (inCurrentRowChanged) return;
            inCurrentRowChanged = true;

            var row = gvLicenseAgr.Rows.FirstOrDefault(rec => (rec.DataBoundItem as GridLicenseAgrView)?.LicId == e.LicId);
            if (row != null && row.IsCurrent != true)
                row.IsCurrent = true;

            inCurrentRowChanged = false;
        }

        private void gvMoreLicenseAgr_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            switch (e.Column.FieldName)
            {
                case "printBtn":
                    int licId = (e?.Row?.DataBoundItem as GridLicenseAgrView)?.LicId ?? 0;
                    PrintAgreement(licId);
                    break;
                case "editBtn":
                    ColumnEditClick();
                    break;
                case "deleteBtn":
                    ColumnDeleteClick();
                    break;
            }
        }

        private void gvLicenseAgr_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            int licId = (e?.Row?.DataBoundItem as GridLicenseAgrView)?.LicId ?? 0;
            PrintAgreement(licId);
        }
    }

    /// <summary>
    /// Intermediate class for grid DataSource
    /// </summary>
    public class GridLicenseAgrView
    {
        public int Id { get; set; }
        public int? LicVersion { get; set; }
        public string License { get; set; }
        public string Series { get; set; }
        public string AgrNumber { get; set; }
        public string AgrMasterNumber { get; set; }
        public string DateBegin { get; set; }
        public string DateEnd { get; set; }
        public decimal MinAmount { get; set; }
        public decimal MinRate { get; set; }
        public string State { get; set; }
        public int? Status { get; set; }
        public string PeriodPayment { get; set; }
        public string DateLastPayment { get; set; }
        public int LicId { get; set;  }
        public bool IsAutoprolog { get; set; }
        public LicenseAgreement LicenseAgreement;
    }
}