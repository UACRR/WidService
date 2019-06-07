using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary.Extensions;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.ConsumerForms
{
    public partial class AnketaConsumerPhisForm : RadForm
    {
        private const string DefaultTitle = "Анкета користувача [фізична особа]";

        private readonly LicenseAgreement _license;
        private readonly Customer _customer;

        public AnketaConsumerPhisForm(Customer customer)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            _customer = customer;
            _license = customer.Client.LicenseAgreement.SingleOrDefault();

            ctrlTabNavigationExpanded.SetDefaultState(ctrlAnketaConsumerPhis.PageView, FLoadType.Create);
            ctrlTabNavigationExpanded.SaveClick += Save;

            ctrlAnketaConsumerPhis.SetData(_customer, ConsumerAnketeType.CreateNewAnketa);
            ctrlAnketaConsumerPhis.CustomerNameChanged += CustomerNameChanged;
        }

        private void CustomerNameChanged(string customerName)
        {
            Text = string.IsNullOrEmpty(customerName) ? DefaultTitle : string.Concat(DefaultTitle, $": {customerName}");
        }

        private void Save(object sender, bool e)
        {
            // відразу підтверджений договір?
            var status = e ? 2 : 0;
            _customer.Status = status;
            _customer.AgreementMaster.SingleOrDefault().AgrStatus = status;
            _customer.Person.AnketaPerson.SingleOrDefault().Status = status;

            _license.LicStatus = status;
            _license.Agr.AgrStatus = status;
            _license.LicenseAgrParam.SingleOrDefault().LicStatus = status;
            ctrlAnketaConsumerPhis.UpdatePlaceLicenses();
            DialogResult = DialogResult.OK;
        }
    }
}
