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
    public partial class InformationOfUserControl : UserControl
    {
        public bool HoldingVisible
        {
            get => groupholdingCtrl.Visible;
            set => groupholdingCtrl.Visible = value;
        }

        public bool OrganisationFormVisible
        {
            get => organisationFormCtrl.Visible;
            set => organisationFormCtrl.Visible = value;
        }

        /// <summary>
        /// Назва
        /// </summary>
        public string NameInfo
        {
            get => nameCtrl.TextValue;
            set => nameCtrl.TextValue = value;
        }
        /// <summary>
        /// Група/холднінг
        /// </summary>
        public string GroupOrHolding
        {
            get => groupholdingCtrl.TextValue;
            set => groupholdingCtrl.TextValue = value;
        }
        /// <summary>
        /// ЄДРПОУ
        /// </summary>
        public string Edrpou
        {
            get => edrpouCtrl.TextValue;
            set => edrpouCtrl.TextValue = value;
        }
        /// <summary>
        /// Організаційна форма
        /// </summary>
        public string OrganisationForm
        {
            get => organisationFormCtrl.TextValue;
            set => organisationFormCtrl.TextValue = value;
        }
        /// <summary>
        /// ПІБ контактної особи
        /// </summary>
        public string PibContactPerson
        {
            get => contactPersPibCtrl.TextValue;
            set => contactPersPibCtrl.TextValue = value;
        }
        /// <summary>
        /// Телефон контактної особи
        /// </summary>
        public string PhoneContactPerson
        {
            get => contactPersPhoneCtrl.TextValue;
            set => contactPersPhoneCtrl.TextValue = value;
        }


        /// <summary>
        /// EMail контактної особи
        /// </summary>
        public string EmailContactPerson
        {
            get => contactPersEmailCtrl.TextValue;
            set => contactPersEmailCtrl.TextValue = value;
        }
        /// <summary>
        /// ПІБ керівника
        /// </summary>
        public string PibManager
        {
            get => managerPibCtrl.TextValue;
            set => managerPibCtrl.TextValue = value;
        }
        /// <summary>
        /// Контактний телефон керівника
        /// </summary>
        public string PhoneManager
        {
            get => managerPhoneCtrl.TextValue;
            set => managerPhoneCtrl.TextValue = value;
        }
        /// <summary>
        /// Email керівника
        /// </summary>
        public string EmailManager
        {
            get => managerEmail.TextValue;
            set => managerEmail.TextValue = value;
        }

        public InformationOfUserControl()
        {
            InitializeComponent();
        }

        public void SetEmptyFields()
        {
            Edrpou = string.Empty;
            EmailContactPerson = string.Empty;
            GroupOrHolding = string.Empty;
            NameInfo = string.Empty;
            OrganisationForm = string.Empty;
            PhoneContactPerson = string.Empty;
            PhoneManager = string.Empty;
            PibContactPerson = string.Empty;
            PibManager = string.Empty;
            EmailManager = string.Empty;

            //MobilePnoneContactPerson = string.Empty;
            //FaksContactPerson = string.Empty;
        }

        /// <summary>
        /// Виведення інформації про користувача (для великих прав)
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="rightView"></param>
        public void SetHeaderInfoBigRight(Customer customer, MainGridConsumerBigRightView rightView)
        {
            var head = customer.Company?.RelEmployee?.SingleOrDefault(cId => cId.PositionCode == 1);
            var contactPerson = customer.Company?.RelEmployee?.SingleOrDefault(cId => cId.PositionCode == 3);
            NameInfo = rightView.Name;
            Edrpou = rightView.Innokpo;
            PibContactPerson = contactPerson?.Empl?.FirstName + " " + contactPerson?.Empl?.LastName + " " + contactPerson?.Empl?.SurName;
            PhoneContactPerson = contactPerson?.Empl?.PhoneNumber;
            EmailContactPerson = contactPerson?.Empl?.Email;
            PibManager = head?.Empl?.FirstName + " " + head?.Empl?.LastName + " " + head?.Empl?.SurName;
            PhoneManager = head?.Empl?.PhoneNumber;
            EmailManager = head?.Empl?.Email;
        }
    }
}
