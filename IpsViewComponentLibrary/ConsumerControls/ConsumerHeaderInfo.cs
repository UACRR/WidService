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

namespace IpsViewComponentLibrary.ConsumerControls
{
    public partial class ConsumerHeaderInfo : UserControl
    {
        public ConsumerHeaderInfo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Встановити інформацію про користувача Малих прав
        /// </summary>
        /// <param name="customer"></param>
        public void SetControlTextInfoSmallRight(Customer customer)
        {
            var userInfo = customer.Company?.AnketaCompany?.SingleOrDefault();
            var head = customer.Company?.RelEmployee?.SingleOrDefault(cId => cId.PositionCode == 1);
            var contactPerson = customer.Company?.RelEmployee?.SingleOrDefault(cId => cId.PositionCode == 3);
            txtConsumerName.Text = userInfo?.Name ?? string.Empty;
            txtConsumerInnokpo.Text = userInfo?.Okpo ?? string.Empty;
            txtContactName.Text = contactPerson?.Empl?.FirstName + " " + contactPerson?.Empl?.LastName + " " + contactPerson?.Empl?.SurName;
            txtContactPhone.Text = contactPerson?.Empl?.PhoneNumber ?? string.Empty;
            txtContactEmail.Text = contactPerson?.Empl?.Email ?? string.Empty;
            txtHeadName.Text = head?.Empl?.FirstName + " " + head?.Empl?.LastName + " " + head?.Empl?.SurName;
            txtHeadPhone.Text = head?.Empl?.PhoneNumber ?? string.Empty;
            txtHeadEmail.Text = head?.Empl?.Email ?? string.Empty;
        }

        /// <summary>
        /// Встановити інформацію про користувача Великих прав
        /// </summary>
        /// <param name="customer"></param>
        public void SetControlTextInfoBigRight(Customer customer)
        {
            var head = customer.Company?.RelEmployee?.SingleOrDefault(cId => cId.PositionCode == 1);
            var contactPerson = customer.Company?.RelEmployee?.SingleOrDefault(cId => cId.PositionCode == 3);
            var view = ViewsSingleton.ConsumerBigRightView;

            txtConsumerName.Text = view?.Name ?? string.Empty;
            txtConsumerInnokpo.Text = view?.Innokpo ?? string.Empty;
            txtContactName.Text = contactPerson?.Empl?.FirstName + " " + contactPerson?.Empl?.LastName + " " + contactPerson?.Empl?.SurName;
            txtContactPhone.Text = contactPerson?.Empl?.PhoneNumber ?? string.Empty;
            txtContactEmail.Text = contactPerson?.Empl?.Email ?? string.Empty;
            txtHeadName.Text = head?.Empl?.FirstName + " " + head?.Empl?.LastName + " " + head?.Empl?.SurName;
            txtHeadPhone.Text = head?.Empl?.PhoneNumber ?? string.Empty;
            txtHeadEmail.Text = head?.Empl?.Email ?? string.Empty;
        }
    }
}
