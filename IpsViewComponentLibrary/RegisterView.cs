using ipsFormsDesign.Data;
using ipsFormsDesign.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace IpsViewComponentLibrary
{
    public partial class RegisterView : Telerik.WinControls.UI.RadForm
    {
        private RegisterPresenter _presenter;
        public RegisterPresenter Presenter
        {
            set
            {
                if (_presenter == null)
                    _presenter = value;
            }
        }

        private Register _register;
        public Register Register
        {
            get { return _register; }
            set
            {
                _register = value;

                UpdateRegisterDataSources(_register);
            }
        }

        public RegisterView()
        {
            InitializeComponent();

            SetDictionaries();
        }

        public void Run()
        {
            ShowDialog();
        }

        private void SetDictionaries()
        {
            ddlStatus.ValueMember = "CodeI";
            ddlStatus.DisplayMember = "Name";
            ddlStatus.DataSource = IpsGlobal.ObjectRightDictionaries.RegisterStatuses;
        }

        private void UpdateRegisterDataSources(Register register)
        {
            registerBindingSource.DataSource = register;
            ctrlRegisterItemList.DataSource = register.RegisterItem;
        }
    }
}
