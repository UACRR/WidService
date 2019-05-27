using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Model;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.ConsumerControls.SmallRight.Reports
{
    public partial class ReportExtendedForm : RadForm
    {
        private Register _register = null;
        private RegisterItem _registerItemCreation = null, _registerItemMusDesign = null;
        private Dictionary<int, CreativeRoleType> creativeDic;

        #region PROPERTIES

        public object RegisterDataSource
        {
            get => bsRegister.DataSource;
            private set => bsRegister.DataSource = value;
        }

        public object CreativeRoleDataSource
        {
            get => bsDictCreativeRole.DataSource;
            private set => bsDictCreativeRole.DataSource = value;
        }

        public object RegisterItemDataSource
        {
            get => bsRegisterItem.DataSource;
            private set => bsRegisterItem.DataSource = value;
        }

        public object ParentRegisterItemDataSource
        {
            get => registerItemBindingSource.DataSource;
            private set => registerItemBindingSource.DataSource = value;
        }

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
            _register = register;
            _registerItemCreation = new RegisterItem
            {
                CodeItem = 2,
            };
            _register.RegisterItem.Add(_registerItemCreation);
            RegisterItemDataSource = _registerItemCreation;
            RegisterDataSource = _register;
            CreativeRoleDataSource = IpsGlobal.AnketaDictionaties.creativeRoleType.Where(rec => rec.CategoryCode == 5 && rec.Crtype == 1);
            creativeDic = IpsGlobal.AnketaDictionaties.creativeRoleType.Where(rec => rec.CategoryCode == 5 && rec.Crtype == 1).ToDictionary(rec => rec.CodeI);
        }

        /// <summary>
        /// Конструктор для перегляду або редагування
        /// </summary>
        /// <param name="register">Звіт</param>
        /// <param name="isEdit">true - якщо редагування, false - якщо перегляд</param>
        public ReportExtendedForm(Register register, bool isEdit)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            creativeDic = IpsGlobal.AnketaDictionaties.creativeRoleType.Where(rec => rec.CategoryCode == 5 && rec.Crtype == 1).ToDictionary(rec => rec.CodeI);
            _register = register;
            NormalizeData(_register);
            _registerItemCreation = _register.RegisterItem.SingleOrDefault(rec => rec.CodeItem == 2);

            RegisterItemDataSource = (object)_registerItemCreation ?? (object)typeof(RegisterItem);

            RegisterDataSource = _register;
            CreativeRoleDataSource = IpsGlobal.AnketaDictionaties.creativeRoleType.Where(rec => rec.CategoryCode == 5 && rec.Crtype == 1);

            btnAddRegItem.Enabled = isEdit;
            btnAddCreativeRole.Enabled = isEdit;
            ctrlSaveCancelButtons.SaveButtonEnabled = isEdit;
            txtName.ReadOnly = !isEdit;
            txtAuthName.Enabled = isEdit;
            txtAmount.ReadOnly = !isEdit;
            txtAuthRate.ReadOnly = !isEdit;
            txtAuthAmount.ReadOnly = !isEdit;
            ddlCreativeRole.Enabled = isEdit;
            txtMusicalDesignRate.ReadOnly = !isEdit;

            CreateDataForHierarchyView();
        }

        private void NormalizeData(Register register)
        {
            foreach (var item in register.RegisterItem)
                foreach (var extra in item.RegisterExtra)
                    extra.RoleCodeNavigation = creativeDic[extra.RoleCode];
        }

        private void CalculateAmounts()
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

        private void CreateDataForHierarchyView()
        {
            var items = _register.RegisterItem.Where(rec => rec.CodeItem == 3).ToList();
            if (!items.Any()) return;
            foreach (var registerItem in items)
            {
                foreach (var registerExtra in registerItem.RegisterExtra)
                {
                    registerExtra.RoleCodeNavigation = creativeDic[registerExtra.RoleCode];
                }
            }

            ParentRegisterItemDataSource = items;
        }

        //додати творчу роль
        private void btnAddCreativeRole_Click(object sender, EventArgs e)
        {
            if (txtAuthName.Text != string.Empty)
            {
                int roleCode = Convert.ToInt32(ddlCreativeRole.SelectedItem.Value ?? "0");
                var addItem = new RegisterExtra
                {
                    Name = txtAuthName.Text,
                    RoleCode = roleCode,
                    RoleCodeNavigation = creativeDic[roleCode],
                };
                _registerItemCreation.RegisterExtra.Add(addItem);
                bindingRegExtraCode2.ResetBindings(false);
            }
            else
                MessageBox.Show("ПІБ автора не може бути пустим!", "Пусте поле", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        //додати музичний твір 
        private void btnAddRegItem_Click(object sender, EventArgs e)
        {
            _registerItemMusDesign = new RegisterItem
            {
                CodeItem = 3,
                CountUse = 1,
            };

            var addAuthRole = new CompositionOfReport(_registerItemMusDesign)
            {
                CreativeRoleDataSource = IpsGlobal.AnketaDictionaties.creativeRoleType.Where(rec => rec.CategoryCode == 5 && rec.Crtype == 1),
            };
            if (addAuthRole.ShowDialog() == DialogResult.OK)
            {
                registerItemBindingSource.Add(_registerItemMusDesign);
                _register.RegisterItem.Add(_registerItemMusDesign);
            }
        }

        private void gvMusicalDesing_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            var rec = e.Row.DataBoundItem as RegisterItem;
            registerItemBindingSource.Remove(rec);
            _register.RegisterItem.Remove(rec);
        }

        private void gvStaging_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            if (e.Row.DataBoundItem is RegisterExtra item)
            {

                bindingRegExtraCode2.Remove(item);
                _registerItemCreation.RegisterExtra.Remove(item);
            }
        }

        private void StartCalculateNeed(object sender, EventArgs e)
        {
            CalculateAmounts();
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 44)
            {
                e.Handled = true;
            }
        }
    }
}
