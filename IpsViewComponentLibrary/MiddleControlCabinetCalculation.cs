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
    public partial class MiddleControlCabinetCalculation : UserControl
    {
        private Customer _customer;
        private ConsumerBigRightView _bigRightView;
        
        private AnketaDictionaties _dictionaties;

        public MiddleControlCabinetCalculation()
        {
            InitializeComponent();
        }

        public void SetAnketaDictionary(AnketaDictionaties dictionaties)
        {
            _dictionaties = dictionaties;
        }

        public void SetAndUpdateData(Customer customer, ConsumerBigRightView bigRightView, IList<BigRightMasterGenAgr> genAgrs, IList<BigRightMoneyUndescrib> undescribs)
        {
            _customer = customer;
            _bigRightView = bigRightView;
            SetBigRightHeaderData();
            gvUndistribMoneys.DataSource = undescribs;

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
    }
}
