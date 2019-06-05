using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary.Extensions;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.ConsumerControls.SmallRight.Reports
{
    public partial class ReportExtendedForm : RadForm
    {
        private const string EmptyNameWarningMsg = "Введіть назву постановки!";
        private const string NotSelectedGenreWarningMsg = "Оберіть жанр постановки!";

        private readonly Register _register;

        #region PROPERTIES

        /// <summary>
        /// Назва споживача
        /// </summary>
        public string HeaderInfoCustomerName
        {
            get => lblConsumer.Text;
            set => lblConsumer.Text = value;
        }

        /// <summary>
        /// Номер ліц. договору
        /// </summary>
        public string HeaderInfoLicenseNumberString
        {
            get => lblLicenseAgrNumber.Text;
            set => lblLicenseAgrNumber.Text = value;
        }

        /// <summary>
        /// Найменування періоду
        /// </summary>
        public string HeaderInfoPeriodName
        {
            get => lblPeriod.Text;
            set => lblPeriod.Text = value;
        }

        /// <summary>
        /// Номер розрахункового листа
        /// </summary>
        public string HeaderInfoRatedListNumber
        {
            get => lblRlNumber.Text;
            set => lblRlNumber.Text = value;
        }

        #endregion

        /// <summary>
        /// Конструктор для створення рапортички
        /// </summary>
        /// <param name="register"></param>
        public ReportExtendedForm(Register register)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            WindowState = FormWindowState.Maximized;

            bsDictCreativeRole.DataSource = IpsGlobal.AnketaDictionaties.creativeRoleType.Where(rec => rec.CategoryCode == 5 && rec.Crtype == 1);
            bsDictGenreType.DataSource = IpsGlobal.AnketaDictionaties.genreType.Where(rec => rec.CategoryCode == 5);
            bsDictRelGenrePercent.DataSource = IpsGlobal.AnketaDictionaties.relGenrePercent;
            
            _register = register;

            if (!(_register.RegisterItem.Any(rec => rec.CodeItem == 2)))
            {
                _register.RegisterItem.Add(new RegisterItem
                {
                    CodeItem = 2,
                });
            }

            bsRegister.DataSource = _register;
            // CodeItem == 2 - постановка
            bsRegisterItem.DataSource = _register.RegisterItem.SingleOrDefault(rec => rec.CodeItem == 2);

            ddlGenreType.SelectedValueChanged += ddlGenreType_SelectedValueChanged;
        }


        /// <summary>
        /// Конструктор для перегляду або редагування
        /// </summary>
        /// <param name="register">Звіт</param>
        /// <param name="isEdit">true - якщо редагування, false - якщо перегляд</param>
        public ReportExtendedForm(Register register, bool isEdit) : this(register)
        {
            MusicDesingDataSource = _register;

            btnAddRegItem.Enabled = isEdit;
            btnAddCreativeRole.Enabled = isEdit;
            ctrlSaveCancelButtons.SaveButtonEnabled = isEdit;
            txtName.ReadOnly = !isEdit;
            txtAmount.ReadOnly = !isEdit;
            txtAuthRate.ReadOnly = !isEdit;
            txtAuthAmount.ReadOnly = !isEdit;
            ddlGenreType.Enabled = isEdit;
            txtMusicalDesignRate.ReadOnly = !isEdit;
        }

        public Register MusicDesingDataSource
        {
            get => bsRegisterItemMusic.DataSource as Register;
            set
            {
                var list = value.RegisterItem.Where(rec => rec.CodeItem == 3).ToList();
                bsRegisterItemMusic.DataSource = list;
                bsRegisterItemMusic.ResetBindings(false);
                bsChildRegisterExtraMusic.ResetBindings(false);
            }
        }

        // додати автора
        private void btnAddCreativeRole_Click(object sender, EventArgs e)
        {
            var item = _register.RegisterItem.SingleOrDefault(rec => rec.CodeItem == 2);
            if (string.IsNullOrEmpty(item?.ItemName))
            {
                MessageShow.ShowWarning(EmptyNameWarningMsg);
                return;
            }

            if ((item.GenreType ?? 0) == 0)
            {
                MessageShow.ShowWarning(NotSelectedGenreWarningMsg);
                return;
            }

            gvAuthorsOfStaging.Rows.AddNew();
            gvAuthorsOfStaging.CurrentRow.Cells[0].BeginEdit();
        }

        //додати музичний твір 
        private void btnAddRegisterItem_Click(object sender, EventArgs e)
        {
            var registerItemMusicDesign = new RegisterItem
            {
                RegId = _register.RegId,
                CodeItem = 3,
                CountUse = 1,
                RegisterExtra = new ObservableListSource<RegisterExtra>()
            };

            var addAuthRole = new CompositionOfReport(registerItemMusicDesign);
            if (addAuthRole.ShowDialog() == DialogResult.OK)
            {
                _register.RegisterItem.Add(registerItemMusicDesign);
                MusicDesingDataSource = _register;
            }
        }

        private void gvMusicalDesing_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            if (!(e.Row.DataBoundItem is RegisterItem item))
                return;

            var btnName = e.Column.FieldName;
            switch (btnName)
            {
                case "btnEdit":
                    EditMusicDesignItem(item);
                    break;
                case "btnDelete":
                    _register.RegisterItem.Remove(item);
                    MusicDesingDataSource = _register;
                    break;
            }
        }

        private void gvMusicalDesing_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            if (!(e.Row.DataBoundItem is RegisterItem item))
                return;

            EditMusicDesignItem(item);
        }

        private void EditMusicDesignItem(RegisterItem item)
        {
            // todo: add sync method
            var addAuthRole = new CompositionOfReport(item);
            if (addAuthRole.ShowDialog() == DialogResult.OK)
            {
                MusicDesingDataSource = _register;
            }
        }

        private void gvStaging_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            if (!(e.Row.DataBoundItem is RegisterExtra item))
                return;

            var registerExtraList = _register.RegisterItem.SingleOrDefault(rec => rec.CodeItem == 2)?.RegisterExtra;
            registerExtraList?.Remove(item);

            bsRegisterItem.ResetBindings(false);
            bsRegisterExtra.ResetBindings(false);
        }

        private void StartCalculateNeed(object sender, EventArgs e)
        {
            decimal.TryParse(txtAmount.Text, out decimal amount);
            decimal.TryParse(txtStagingRate.Text, out decimal authRate);
            decimal.TryParse(txtMusicalDesignRate.Text, out decimal musicRate);

            _register.AuthAmount = amount / 100 * authRate;
            _register.MusicAmount = amount / 100 * musicRate;

            lblValidAuthAmount.Text = (_register.AuthAmount + _register.MusicAmount).ToString();

            decimal.TryParse(lblValidAuthAmount.Text, out decimal rightResult);
            decimal.TryParse(txtAuthAmount.Text, out decimal leftResult);
            lblValidAuthAmount.ForeColor = decimal.Round(leftResult, 2) != decimal.Round(rightResult, 2) ? Color.Red : DefaultForeColor;
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 44)
            {
                e.Handled = true;
            }
        }

        private void ddlGenreType_SelectedValueChanged(object sender, EventArgs e)
        {
            // todo: пропонований %
            //var item = _register.RegisterItem.SingleOrDefault(rec => rec.CodeItem == 2);
            //var rate = IpsGlobal.AnketaDictionaties.relGenrePercent.SingleOrDefault(rec => rec.GenreType == item?.GenreType);
            //_register.AuthRate = rate?.Rate ?? 0;
            //bsRegister.ResetBindings(false);
        }

        private void gvMusicalDesing_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            if (e.CurrentRow.DataBoundItem is RegisterItem)
                gvMusicalDesing.MasterTemplate.CollapseAll();
        }
    }
}
