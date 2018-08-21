using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using Telerik.WinControls;

namespace IpsViewComponentLibrary.ConsumerDialogForms
{
    public partial class CreateProgReportBigRight : Telerik.WinControls.UI.RadForm
    {
        private BindingSource _bindingSourceChild = new BindingSource();
        private Register _register = null;
        private ObservableListSource<RegisterExtra> _gridSource = new ObservableListSource<RegisterExtra>();
        private RegisterItem _registerItemCreation = null, _registerItemMusDesign = null;
        private Dictionary<int, CreativeRoleType> creativeDic;
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

        public object ChildRegisterExtraDataSource
        {
            get => _bindingSourceChild.DataSource;
            private set => _bindingSourceChild.DataSource = value;
        }

        /// <summary>
        /// Default NOT usable constructor
        /// </summary>
        public CreateProgReportBigRight()
        {
            InitializeComponent();
            creativeDic = IpsGlobal.AnketaDictionaties.creativeRoleType.Where(rec => rec.CategoryCode == 5 && rec.Crtype == 1).ToDictionary(rec => rec.CodeI);
        }

        /// <summary>
        /// Конструктор для створення рапортички
        /// </summary>
        /// <param name="register"></param>
        public CreateProgReportBigRight(Register register)
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
        public CreateProgReportBigRight(Register register, bool isEdit)
        {
            InitializeComponent();
            creativeDic = IpsGlobal.AnketaDictionaties.creativeRoleType.Where(rec => rec.CategoryCode == 5 && rec.Crtype == 1).ToDictionary(rec => rec.CodeI);
            _register = register;
            NormalizeData(_register);
            _registerItemCreation = _register.RegisterItem.SingleOrDefault(rec => rec.CodeItem == 2);
            RegisterItemDataSource = _registerItemCreation;

            RegisterDataSource = _register;
            CreativeRoleDataSource = IpsGlobal.AnketaDictionaties.creativeRoleType.Where(rec => rec.CategoryCode == 5 && rec.Crtype == 1);

            btnAddRegItem.Enabled = isEdit;
            btnAddCreativeRole.Enabled = isEdit;
            btnSave.Enabled = isEdit;
            txtName.ReadOnly = !isEdit;
            txtAuthName.Enabled = isEdit;
            txtAmount.ReadOnly = !isEdit;
            txtAuthRate.ReadOnly = !isEdit;
            txtAuthAmount.ReadOnly = !isEdit;
            ddlCreativeRole.Enabled = isEdit;
            txtMusicalDesignRate.ReadOnly = !isEdit;
            txtMusicalDesignAmount.ReadOnly = !isEdit;

            CreateDataForHierarchyView();

        }

        private void NormalizeData(Register register)
        {
            foreach (var item in register.RegisterItem)
                foreach (var extra in item.RegisterExtra)
                    extra.RoleCodeNavigation = creativeDic[extra.RoleCode];
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
                bindingRegExtraCode2.Add(addItem);
                // gvStaging.DataSource = _gridSource;
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
            };

            AddAuthRoleForMusDesingBr addAuthRole = new AddAuthRoleForMusDesingBr(_registerItemMusDesign)
            {
                CreativeRoleDataSource = IpsGlobal.AnketaDictionaties.creativeRoleType.Where(rec => rec.CategoryCode == 5 && rec.Crtype == 1)
            };
            if (addAuthRole.ShowDialog() == DialogResult.OK)
            {
                registerItemBindingSource.Add(_registerItemMusDesign);
                _register.RegisterItem.Add(_registerItemMusDesign);
            }
        }

        private void gvMusicalDesing_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            var rec = e.Row.DataBoundItem as RegisterItem;
            registerItemBindingSource.Remove(rec);
            _register.RegisterItem.Remove(rec);
        }

        private void gvStaging_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.Row.DataBoundItem is RegisterExtra item)
            {

                bindingRegExtraCode2.Remove(item);
                _registerItemCreation.RegisterExtra.Remove(item);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {


            DialogResult = DialogResult.OK;
        }


    }

    //internal class RegisterExtraGridSource : RegisterExtra
    //{
    //    public string RoleName { get => RoleCodeNavigation.Name; }
    //}
}
