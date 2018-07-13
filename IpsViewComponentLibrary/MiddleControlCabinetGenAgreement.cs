using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;

namespace IpsViewComponentLibrary
{
    public partial class MiddleControlCabinetGenAgreement : UserControl
    {
        private Customer _customer;
        private ConsumerBigRightView _bigRightView;
        public MiddleControlCabinetGenAgreement()
        {
            InitializeComponent();
        }

        public void SetAndUpdateData(Customer customer, ConsumerBigRightView bigRightView, IList<VbrLicense> vbrLicense)
        {
            _customer = customer;
            _bigRightView = bigRightView;
            SetBigRightHeaderData();
            gvGenAgrLicences.DataSource = new List<ConsumerBigRightView> {bigRightView};
        }

        private void SetBigRightHeaderData()
        {
            var head = _customer.Company?.RelEmployee?.SingleOrDefault(cId => cId.PositionCode == 1);
            var contactPerson = _customer.Company?.RelEmployee?.SingleOrDefault(cId => cId.PositionCode == 3);
          

            ctrlHeaderInfo.NameInfo = _bigRightView.Name;
            ctrlHeaderInfo.Edrpou = _bigRightView.Innokpo;
            ctrlHeaderInfo.PibContactPerson = contactPerson?.Empl?.FirstName + " " + contactPerson?.Empl?.LastName + " " + contactPerson?.Empl?.SurName;
            ctrlHeaderInfo.PhoneContactPerson = contactPerson?.Empl?.PhoneNumber;
            ctrlHeaderInfo.EmailContactPerson = contactPerson?.Empl?.Email;
            ctrlHeaderInfo.PibManager = head?.Empl?.FirstName + " " + head?.Empl?.LastName + " " + head?.Empl?.SurName;
            ctrlHeaderInfo.PhoneManager = head?.Empl?.PhoneNumber;
            ctrlHeaderInfo.EmailManager = head?.Empl?.Email;

        }

        private void gvGenAgrLicences_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            ctrlFooterInfo.DataSourceLicense = e.CurrentRow.DataBoundItem as ConsumerBigRightView ?? new ConsumerBigRightView();
        }
    }
}
