using ipsFormsDesign.Data;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;

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

        public BindingList<RegisterItemViewModel> RegisterItemList { get; private set; } = new BindingList<RegisterItemViewModel>();

        public Collection<RegisterItemViewModel> SelectedRegisterItems { get => ctrlRegisterItemList.SelectedRegisterItems; }

        public RegisterView()
        {
            InitializeComponent();

            SetDictionaries();

            ctrlRegisterItemList.DataSource = RegisterItemList;
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

        private void btnSearchAll_Click(object sender, System.EventArgs e)
        {
            _presenter.SearchObjectsForAll();
        }

        private void btnSearchNotLinked_Click(object sender, System.EventArgs e)
        {
            _presenter.SearchObjectsForNotLinked();
        }

        private void btnSearchSelected_Click(object sender, System.EventArgs e)
        {
            _presenter.SearchObjectsForSelected();
        }
    }
}
