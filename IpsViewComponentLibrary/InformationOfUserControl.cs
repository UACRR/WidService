using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IpsViewComponentLibrary
{
    public partial class InformationOfUserControl : UserControl
    {
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
        /// Посада контактної особи
        /// </summary>
        public string WorkPositionContactPerson
        {
            get => contactPersWorkPositionCtrl.TextValue;
            set => contactPersWorkPositionCtrl.TextValue = value;
        }
        /// <summary>
        /// Телефон контактної особи
        /// </summary>
        public string PhoneContactPerson
        {
            get => contactPersPhoneCtrl.TextValue;
            set => contactPersPhoneCtrl.TextValue = value;
        }
        ///// <summary>
        ///// Мобільний телефон контактної особи
        ///// </summary>
        //public string MobilePnoneContactPerson
        //{
        //    get => contactPersMobilePhoneCtrl.TextValue;
        //    set => contactPersMobilePhoneCtrl.TextValue = value;
        //}
        ///// <summary>
        ///// Факс контактної особи
        ///// </summary>
        //public string FaksContactPerson
        //{
        //    get => contactPersFaksCtrl.TextValue;
        //    set => contactPersFaksCtrl.TextValue = value;
        //}
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
        /// Посада керівника
        /// </summary>
        public string WorkPositionManager
        {
            get => managerWorkPositionCtrl.TextValue;
            set => managerWorkPositionCtrl.TextValue = value;
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
            WorkPositionContactPerson = string.Empty;
            WorkPositionManager = string.Empty;
            PibManager = string.Empty;
            EmailManager = string.Empty;

            //MobilePnoneContactPerson = string.Empty;
            //FaksContactPerson = string.Empty;
        }
    }
}
