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
            txtConsumerName.Text = userInfo?.Name ?? string.Empty;
            txtConsumerInnokpo.Text = userInfo?.Okpo ?? string.Empty;

            var head = customer.Company?.RelEmployee?.SingleOrDefault(cId => cId.PositionCode == 1);
            txtHeadName.Text = $"{head?.Empl?.LastName} {head?.Empl?.FirstName} {head?.Empl?.SurName}";
            txtHeadPhone.Text = head?.Empl?.PhoneNumber ?? string.Empty;
            txtHeadEmail.Text = head?.Empl?.Email ?? string.Empty;

            var contactPerson = customer.Company?.RelEmployee?.SingleOrDefault(cId => cId.PositionCode == 3);
            txtContactName.Text = $"{contactPerson?.Empl?.LastName} {contactPerson?.Empl?.FirstName} {contactPerson?.Empl?.SurName}";
            txtContactPhone.Text = contactPerson?.Empl?.PhoneNumber ?? string.Empty;
            txtContactEmail.Text = contactPerson?.Empl?.Email ?? string.Empty;
        }

        /// <summary>
        /// Встановити інформацію про користувача Великих прав
        /// </summary>
        /// <param name="customer"></param>
        public void SetControlTextInfoBigRight(Customer customer)
        {
            var view = ViewsSingleton.ConsumerBigRightView;
            txtConsumerName.Text = view?.Name ?? string.Empty;
            txtConsumerInnokpo.Text = view?.Innokpo ?? string.Empty;

            var headEmployee = customer.Company?.RelEmployee?.SingleOrDefault(cId => cId.PositionCode == 1)?.Empl;
            if (headEmployee != null)
            {
                txtHeadName.Text = $"{headEmployee.LastName} {headEmployee.FirstName} {headEmployee.SurName}";
                txtHeadPhone.Text = headEmployee.PhoneNumber ?? string.Empty;
                txtHeadEmail.Text = headEmployee.Email ?? string.Empty;
            }

            var contactPersonEmployee = customer.Company?.RelEmployee?.SingleOrDefault(cId => cId.PositionCode == 3)?.Empl;
            if (contactPersonEmployee != null)
            {
                txtContactName.Text = $"{contactPersonEmployee.LastName} {contactPersonEmployee.FirstName} {contactPersonEmployee.SurName}";
                txtContactPhone.Text = contactPersonEmployee.PhoneNumber ?? string.Empty;
                txtContactEmail.Text = contactPersonEmployee.Email ?? string.Empty;
            }
        }
    }
}
