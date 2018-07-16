using ipsFormsDesign.Data;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Model;

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

        public Register Register
        {
            get { return registerBindingSource.DataSource as Register; }
            set
            {
                if (registerBindingSource.DataSource != value)
                {
                    registerBindingSource.DataSource = value;
                }
            }
        }

        public object RegisterItemDataSource
        {
            get { return ctrlRegisterItemList.DataSource; }
            set
            {
                if (ctrlRegisterItemList.DataSource != value)
                {
                    ctrlRegisterItemList.DataSource = value;
                }
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

        private void ctrlRegisterItemList_FindCommandExecuted(object sender, RegisterItemViewModel selectedRegisterItem)
        {
            _presenter.SearchObjects(selectedRegisterItem);
        }
    }
}
