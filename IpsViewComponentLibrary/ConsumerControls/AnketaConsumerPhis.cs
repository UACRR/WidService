using System;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary.ConsumerForms;
using IpsViewComponentLibrary.Extensions;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.ConsumerControls
{
    public partial class AnketaConsumerPhis : UserControl
    {
        private Customer _customer;
        private LicenseAgreement _licenseAgreement;
        public event Action<string> CustomerNameChanged;

        public AnketaConsumerPhis()
        {
            InitializeComponent();
            ctrlConsumerName.CustomerNameChanged += OnCustomerNameChanged;
        }

        public RadPageView PageView => pageAnketaConsumer;

        public void UpdatePlaceLicenses()
        {
            ctrlAgreementPhis.UpdatePlaceLicenses();
        }

        public void SetData(Customer customer, ConsumerAnketeType anketeType)
        {
            _customer = customer;

            if (anketeType == ConsumerAnketeType.EditAnketa)
                pageAnketaConsumer.Pages["pvAgreement"].Item.Visibility = Telerik.WinControls.ElementVisibility.Collapsed;

            // agreement
            if (anketeType == ConsumerAnketeType.CreateNewAnketa)
            {
                var places = customer.Client.ClnBusinessPlace;
                _licenseAgreement = customer.Client.LicenseAgreement.SingleOrDefault();
                var licAgr = _licenseAgreement?.LicenseAgrParam.SingleOrDefault();
                ctrlAgreementPhis.Rights = TypeRights.SmallRights;
                ctrlAgreementPhis.InitializeObjects(places, _licenseAgreement, licAgr, ConsumerAgreementInitType.AddNewAgreement);
            }

            bsClient.DataSource = customer.Client;

            // anketaPerson
            var anketaPerson = customer.Person.AnketaPerson.SingleOrDefault();
            bsAnketaPerson.DataSource = anketaPerson;

            ctrlConsumerName.DataSourceAnketa = anketaPerson;

            // контакти
            ctrlContacts.SetDataSource(customer);

            // паспортні дані
            ctrlConsumerPassport.DataSource = anketaPerson;

            // банківські реквізити
            if (!customer.BankAccount.Any())
            {
                customer.BankAccount.Add(new BankAccount());
            }
            ctrlBankAccount.DataSource = customer.BankAccount.FirstOrDefault();

            // майданчики
            ctrlPlaces.SetData(customer);
        }

        private void btnLoadPdf_Click(object sender, EventArgs e)
        {
            var printForm = new ViewAndPrintAgreementForm(_customer, _licenseAgreement);
            if (printForm.ValidTemplate)
                printForm.ShowDialog();
        }

        private void OnCustomerNameChanged(string customerName)
        {
            CustomerNameChanged?.Invoke(customerName);
        }
    }
}
