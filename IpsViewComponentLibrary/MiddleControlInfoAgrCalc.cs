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

    public partial class MiddleControlInfoAgrCalc : UserControl
    {
        private Customer _customer;
        private AnketaDictionaties _dictionaties;
        private int _idItem;
        private ButtonFunctionAcceptLicType _licType = ButtonFunctionAcceptLicType.None;

        public delegate void CustomerSave(Customer customer);
        public event CustomerSave OnCustomerSave;
        public event LisenseStatusChangeEventHandler OnChangeLicenseStatus;


        public TypeRights Rights { get; set; }

        public MiddleControlInfoAgrCalc()
        {
            InitializeComponent();
            SetDefaultPages();
            ctrlAgrInfoMain.OnSaveCommentNeed += AgreementInfoCtrl_OnSaveCommentNeed;
        }

        private void AgreementInfoCtrl_OnSaveCommentNeed(object sender, EventArgs e)
        {
            OnCustomerSave?.Invoke(_customer);
        }

        /// <summary>
        /// Очищення даних 
        /// </summary>
        private void ClearData()
        {
            SetDefaultPages();
            userInfoCtrl.SetEmptyFields();
            ctrlAgrInfoMain.SetEmpty();
            ctrlPaysInfo1.Customer = null;
            gvLicenseAgr.DataSource = new object();
        }

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
            // calculationCtrl.SetDictionary(dict);
        }

        public void SetCustomerData(Customer cust)
        {
            _customer = cust;
            SetUserInfoData();
            gvLicenseAgr.DataSource = new object();
            //SetAgrInfoData();
            SetCalculationData();
            SetLicenseAgrGridDataSource();
            SetLicenseAgrMoreGridDataSource();
            calculationCtrl.Customer = _customer;
            ctrlPaysInfo1.Customer = _customer;
            
            //reportsControl.SetData(cust);
            // reportsControl.SetDataSourceForLicAgrGrid(calculationCtrl.DataSourceReturn);

        }

        /// <summary>
        /// Активні договора грід
        /// </summary>
        private void SetLicenseAgrGridDataSource()
        {
            List<GridLicenseAgrView> source = new List<GridLicenseAgrView>();
            if (_customer?.Client.LicenseAgreement != null)
                foreach (var item in _customer.Client.LicenseAgreement.Where(rec => rec.LicStatus == 2 && rec.LicClass != 1))
                {
                    //якщо з малими правами, пропустити
                    if(Rights == TypeRights.BigRights && _dictionaties?.agrLicenseType?.SingleOrDefault(rec => rec?.CodeI == item?.LicCode)?.UsesKind != 1) continue;

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
                        DateLastPayment = ""
                    });
                }
            //
            gvLicenseAgr.DataSource = source;
            gvLicenseAgr.MasterTemplate.Refresh();
            gvLicenseAgr.Update();
        }

        private void SetLicenseAgrMoreGridDataSource()
        {
            List<GridLicenseAgrView> source = new List<GridLicenseAgrView>();
            if (_customer?.Client.LicenseAgreement != null)
            {
                foreach (var license in _customer.Client.LicenseAgreement)
                {
                    if(license.LicenseAgrParam.Count == 1 && license.LicStatus == 2)
                        continue;

                    if(license.LicenseAgrParam.Count == 1 && license.LicStatus != 2)
                    {
                        source.Add(new GridLicenseAgrView
                        {
                            Id = license.AgrId,
                            LicVersion = license?.LicenseAgrParam?.SingleOrDefault()?.LicVersion,
                            LicId = license.LicId,
                            License = _dictionaties.agrLicenseType.SingleOrDefault(rec => rec?.CodeI == license?.LicCode)?.Name,
                            Series = string.Empty,
                            MinAmount = license.LicenseAgrParam?.SingleOrDefault()?.MinAmount ?? default(decimal),
                            MinRate = license.LicenseAgrParam?.SingleOrDefault()?.RateAmount ?? default(decimal),
                            AgrNumber = license.LicenseAgrParam?.SingleOrDefault()?.LicNum ?? string.Empty,
                            AgrMasterNumber = license.LicenseAgrParam.SingleOrDefault(rec => rec.LicVersion == license.LicVersion)?.LicNum,
                            DateBegin = license.LicenseAgrParam.SingleOrDefault()?.DateBegin?.ToShortDateString() ?? string.Empty,
                            DateEnd = license.LicenseAgrParam?.SingleOrDefault()?.DateEnd?.ToShortDateString() ?? string.Empty,
                            State = _dictionaties?.agreementStatus?.SingleOrDefault(rec => rec.CodeI == license.LicenseAgrParam?.SingleOrDefault()?.LicStatus)?.Name ?? string.Empty,
                            Status = license.LicenseAgrParam?.SingleOrDefault()?.LicStatus,
                            PeriodPayment = _dictionaties?.period?.SingleOrDefault(p => p.CodeI == license.LicenseAgrParam?.SingleOrDefault()?.PeriodCode)?.Name ?? string.Empty
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
                                LicVersion = agrParam?.LicVersion,
                                License = _dictionaties.agrLicenseType.SingleOrDefault(rec => rec?.CodeI == license?.LicCode)?.Name,
                                Series = string.Empty,
                                MinAmount = agrParam?.MinAmount ?? default(decimal),
                                MinRate = agrParam?.RateAmount ?? default(decimal),
                                AgrNumber = agrParam?.LicNum ?? string.Empty,
                                AgrMasterNumber = license.LicenseAgrParam.SingleOrDefault(rec => rec.LicVersion == license.LicVersion)?.LicNum,
                                DateBegin = agrParam?.DateBegin?.ToShortDateString() ?? string.Empty,
                                DateEnd = agrParam?.DateEnd?.ToShortDateString() ?? string.Empty,
                                State = _dictionaties?.agreementStatus?.SingleOrDefault(rec => rec.CodeI == agrParam?.LicStatus)?.Name ?? string.Empty,
                                Status = agrParam.LicStatus,
                                PeriodPayment = _dictionaties?.period?.SingleOrDefault(p => p.CodeI == agrParam?.PeriodCode)?.Name ?? string.Empty
                            });
                    }
                }
            }

            gvMoreLicenseAgr.DataSource = source;
            gvMoreLicenseAgr.MasterTemplate.Refresh();
            gvMoreLicenseAgr.Update();
        }

        /// <summary>
        /// Інформація користувача
        /// </summary>
        private void SetUserInfoData()
        {
            var userInfo = _customer?.Company?.AnketaCompany?.SingleOrDefault();
            var contactPerson = _customer?.Company?.RelEmployee.SingleOrDefault(rec => rec.PositionCode == 3);
            var manager = _customer?.Company?.RelEmployee.SingleOrDefault(rec => rec.PositionCode == 1);


            userInfoCtrl.Edrpou = userInfo?.Okpo;
            userInfoCtrl.NameInfo = userInfo?.Name;
            userInfoCtrl.PibManager = manager?.Empl?.FirstName + " " +
                                      manager?.Empl?.LastName + " " +
                                      manager?.Empl?.SurName;
            userInfoCtrl.EmailManager = manager?.Empl?.Email;

            userInfoCtrl.PhoneManager = manager?.Empl?.PhoneNumber;
            userInfoCtrl.PibContactPerson = contactPerson?.Empl?.FirstName + " " +
                                            contactPerson?.Empl?.LastName + " " +
                                            contactPerson?.Empl?.SurName;
            userInfoCtrl.PhoneContactPerson = contactPerson?.Empl?.PhoneNumber;
            userInfoCtrl.EmailContactPerson = contactPerson?.Empl?.Email;
            userInfoCtrl.OrganisationForm = "";
        }

        /// <summary>
        /// Інформація по договору
        /// </summary>
        private void SetAgrInfoData(int idItem = 0)
        {
            _idItem = idItem;
            var license = _customer?.Client?.LicenseAgreement?.Where(rec => rec.LicId == idItem).FirstOrDefault(rec => rec.LicStatus < 4);
            var licenseParam = license?.LicenseAgrParam.SingleOrDefault(rec => rec.LicVersion == license.LicVersion);

            ctrlAgrInfoMain.NumberAgr = licenseParam?.LicNum;
            ctrlAgrInfoMain.Agent = "";
            ctrlAgrInfoMain.DateAgr = licenseParam?.LicDate?.ToString("dd.MM.yyyy");


            ctrlAgrInfoMain.DateBegin = licenseParam?.DateBegin?.ToShortDateString();
            ctrlAgrInfoMain.DateEnd = licenseParam?.DateEnd?.ToShortDateString();
            ctrlAgrInfoMain.IsProlongation = licenseParam?.IsAutoprolog ?? false;
            ctrlAgrInfoMain.PeriodReportind = _dictionaties?.period?.SingleOrDefault(p => p.CodeI == licenseParam?.PeriodCode)?.Name;
            var pr = (_dictionaties?.periodStatus)?.SingleOrDefault(item => item.CodeI == licenseParam?.PeriodCode)?.Name;
            ctrlAgrInfoMain.Percent = licenseParam?.RateAmount?.ToString();
            ctrlAgrInfoMain.MinPayment = licenseParam?.MinAmount.ToString();

            ctrlAgrInfoMain.CommentDataSource = licenseParam;

            ctrlAgrInfoMain.State = _dictionaties?.agreementStatus.SingleOrDefault(rec => rec.CodeI == licenseParam?.LicStatus)?.Name;

            //TODO: заповнити відсутні дані
            ctrlAgrInfoMain.Implementation = "";//буде
            ctrlAgrInfoMain.IsPaid = true;//буде
            ctrlAgrInfoMain.Bank = "";//буде
            ctrlAgrInfoMain.Amount = "";//буде
            ctrlAgrInfoMain.DistributedAmount = "";//буде
            //ctrlAgrInfoMain.IsAttach = new Random().Next(-10, 10) > 0; // буде
        }

        private void SetAgrInfoDataMore(int idItem = 0)
        {
            _idItem = idItem;
            var license = _customer?.Client?.LicenseAgreement?.Where(rec => rec.LicId == idItem).FirstOrDefault(rec => rec.LicStatus < 4);
            var licenseParam = license?.LicenseAgrParam.SingleOrDefault(rec => rec.LicVersion == license.LicVersion);

            ctrlAgrInfoMore.NumberAgr = licenseParam?.LicNum;
            ctrlAgrInfoMore.Agent = "";
            ctrlAgrInfoMore.DateAgr = licenseParam?.LicDate?.ToString("dd.MM.yyyy");
                       
                       
            ctrlAgrInfoMore.DateBegin = licenseParam?.DateBegin?.ToShortDateString();
            ctrlAgrInfoMore.DateEnd = licenseParam?.DateEnd?.ToShortDateString();
            ctrlAgrInfoMore.IsProlongation = licenseParam?.IsAutoprolog ?? false;
            ctrlAgrInfoMore.PeriodReportind = _dictionaties?.period?.SingleOrDefault(p => p.CodeI == licenseParam?.PeriodCode)?.Name;
            var pr = (_dictionaties?.periodStatus)?.SingleOrDefault(item => item.CodeI == licenseParam?.PeriodCode)?.Name;
            ctrlAgrInfoMore.Percent = licenseParam?.RateAmount?.ToString();
            ctrlAgrInfoMore.MinPayment = licenseParam?.MinAmount.ToString();

            ctrlAgrInfoMore.CommentDataSource = licenseParam;

            ctrlAgrInfoMore.State = _dictionaties?.agreementStatus.SingleOrDefault(rec => rec.CodeI == licenseParam?.LicStatus)?.Name;

            //TODO: заповнити відсутні дані
            ctrlAgrInfoMore.Implementation = "";//буде
            ctrlAgrInfoMore.IsPaid = true;//буде
            ctrlAgrInfoMore.Bank = "";//буде
            ctrlAgrInfoMore.Amount = "";//буде
            ctrlAgrInfoMore.DistributedAmount = "";//буде
            //ctrlAgrInfoMain.IsAttach = new Random().Next(-10, 10) > 0; // буде
        }

        /// <summary>
        /// Інформація по розрахункам
        /// </summary>
        private void SetCalculationData()
        {
            // calculationCtrl.SetData(_customer);
        }

        /// <summary>
        /// Встановлення початкових вкладок
        /// </summary>
        private void SetDefaultPages()
        {
            pvSecond.SelectedPage = pvSecond.DefaultPage;
            pvMain.SelectedPage = pvMain.DefaultPage;
        }

        private void gvLicenseAgr_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            //bool isInt = Int32.TryParse(e.CurrentRow.Cells["Id"].Value.ToString(), out int result);
            //if (!isInt) return;
            //SetAgrInfoData(result);
            if (!(e.CurrentRow.DataBoundItem is GridLicenseAgrView curRow)) return;
            SetAgrInfoData(curRow.LicId);
        }
        


        /// <summary>
        /// Визом метода активації договору
        /// </summary>
        /// <param name="license"></param>
        /// <param name="licenseParam"></param>
        private void RunDialogForLicenseAgrParam(LicenseAgreement license, LicenseAgrParam licenseParam, DialogGoal goal )
        {
            var anketaCompany = _customer.Company.AnketaCompany.SingleOrDefault();
            var licenseName = _dictionaties.agrLicenseType.SingleOrDefault(rec => rec?.CodeI == license?.LicCode)?.Name;

            if (GetTypeAgrForm())
            {
                //з майданчиками * * *
                ProlongationWithPlaces prolongation = new ProlongationWithPlaces(licenseParam, anketaCompany, _dictionaties, license, 
                                                            _customer?.Client?.ClnBusinessPlace, _customer, goal, typeRights:Rights)
                {
                    Text = goal == DialogGoal.forEdit || goal == DialogGoal.forChange ? "Редагування договору" 
                         : goal == DialogGoal.forProlongation ? "Пролонгація договору" 
                         : goal == DialogGoal.forNew ? "Додавання нового договору" 
                         : string.Empty,
                    StartPosition = FormStartPosition.CenterParent
                };
                prolongation.OnSaveProlongation += Prolongation_OnSaveProlongationWithPlaces;
                prolongation.ShowDialog();
            }
            else
            {
                // без майданчиків
                ProlongationWithoutPlaces prolongation = new ProlongationWithoutPlaces(licenseParam, anketaCompany, _dictionaties, licenseName, license, _customer, goal)
                {
                    StartPosition = FormStartPosition.CenterParent
                };
                prolongation.OnSaveProlongation += Prolongation_OnSaveProlongationWithoutPlaces;
                prolongation.ShowDialog();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!(gvMoreLicenseAgr?.CurrentRow?.DataBoundItem is GridLicenseAgrView curRow)) return;

            //поточна ліцензія
            var license = _customer?.Client?.LicenseAgreement?.SingleOrDefault(rec => rec.LicId == curRow.LicId);
            if (license == null)
                return;

            //редагування нового
            if(license.LicenseAgrParam.Count == 1)
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProlongation_Click(object sender, EventArgs e)
        {
            LicenseAgrParam parametr;
            var licId = (gvLicenseAgr.CurrentRow.DataBoundItem as GridLicenseAgrView)?.LicId;
            var license = _customer?.Client?.LicenseAgreement?.Where(rec => rec.LicId == licId).SingleOrDefault();
            if (license == null)
                return;

            
            var licParam = license?.LicenseAgrParam.SingleOrDefault(rec => rec.LicVersion == license.LicVersion);

            var licVersion = license?.LicenseAgrParam.Max(rec => rec.LicVersion);
            LicenseAgrParam newLicense = null;
            var listDopAgr = license.LicenseAgrParam.Where(rec => rec.LicStatus < 4 && rec.LicVersion > license.LicVersion).ToList();
            // Кількість доп угод з версією більшою за поточну > 0 //якщо є хоча б одна угода для пролонгації
            if (listDopAgr.Any() && listDopAgr.Any(rec => rec.LicVersion == license.ProlongVersion))
            {
                parametr = license?.LicenseAgrParam.SingleOrDefault(rec => rec.LicVersion == license.ProlongVersion);
                RunDialogForLicenseAgrParam(license, parametr, DialogGoal.forExistProlongation);
            }
            // Інакше == 0
            else {
                // -- Створити нову
                // -- Збільшити версію на 1
                newLicense = new LicenseAgrParam();

                newLicense.SetFields(licParam);

                if (licParam?.DateEnd != null)
                {
                    newLicense.LicDate = licParam?.DateEnd.Value.AddDays(1);
                    newLicense.DateBegin = licParam?.DateEnd.Value.AddDays(1);
                    newLicense.DateEnd = licParam.DateEnd.Value.AddYears(1).AddDays(1);
                }

                newLicense.LicVersion = (licVersion ?? 0) + 1;
                newLicense.License = licParam?.License;
                license.ProlongVersion = newLicense.LicVersion;
                license?.LicenseAgrParam?.Add(newLicense);
                parametr = license?.LicenseAgrParam.LastOrDefault();
                RunDialogForLicenseAgrParam(license, parametr, DialogGoal.forProlongation);
            }
        }

        private void Prolongation_OnSaveProlongationWithoutPlaces(object sender, EventArgs e)
        {
            OnCustomerSave?.Invoke(_customer);
        }

        private void Prolongation_OnSaveProlongationWithPlaces(object sender, EventArgs e)
        {
            OnCustomerSave?.Invoke(_customer);
        }

        // true - з майданчиками, false - без майданчиків
        private bool GetTypeAgrForm()
        {
            if (_customer.Client.ClnBusinessPlace.Count > 0)
                return true;
            return false;
        }

        //кнопка додати договір
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

        //кнопка друк
        private void btnPrint_Click(object sender, EventArgs e)
        {
            var _lic = _customer.Client.LicenseAgreement.SingleOrDefault(rec => rec.LicId == _idItem);
            ViewAndPrintAgreement print = new ViewAndPrintAgreement(dictionaties: _dictionaties, customer: _customer, licenseAgreement: _lic)
            {
                WindowState = FormWindowState.Maximized,
                StartPosition = FormStartPosition.CenterScreen
            };
            print.ShowDialog();
        }

        private void btnDeleteAgr_Click(object sender, EventArgs e)
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

        private void gvMoreLicenseAgr_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            if (!(e?.CurrentRow?.DataBoundItem is GridLicenseAgrView curRow)) return;
            btnAccept.Enabled = (curRow.Status == 0 || curRow.Status == 1);
            btnDeleteAgr.Enabled = curRow.Status == 0;
            SetAgrInfoDataMore(curRow.LicId);
        }

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
                license?.LicenseAgrParam?.Add(changeLicense);
                parametr = license?.LicenseAgrParam.LastOrDefault();
            }

            //newLicense.LicId = 0;

            RunDialogForLicenseAgrParam(license, parametr, DialogGoal.forChange);
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if(gvMoreLicenseAgr.CurrentRow.DataBoundItem is GridLicenseAgrView item)
            {
                bool actResult = false;
                var license = _customer.Client.LicenseAgreement.SingleOrDefault(rec => rec.LicId == item.LicId);

                actResult = OnChangeLicenseStatus?.Invoke(license, license?.LicenseAgrParam?.LastOrDefault()?.LicVersion ?? 0, 2, true) ?? false;

                if(actResult)
                    ExtensionUtils.ShowInfoMessage("Ліцензійний договір переведено в статус \"Активний\"!", "Успішно",
                        MessageBoxIcon.Information);
                else
                    ExtensionUtils.ShowInfoMessage("Неможливо змінити статус ліцензійного договору!", "Помилка",
                        MessageBoxIcon.Error);
            }
        }
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
    }
}
