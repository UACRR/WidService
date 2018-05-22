using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ipsFormsDesign.Interfaces;
using ipsmedserviceapp.Model;

namespace DebugFormForControls
{
    public partial class DebugOrTestForm : Telerik.WinControls.UI.RadForm
    {
        AnketaPerson anketaPerson = new AnketaPerson
        {
            FirstName = "NameTest",
            LastName = "LastNameTest",
            SurName = "SurNameTest",
            BirthDate = new DateTime(1995,05,24),
            Sex = 1,

            NikName = "nickname",

            PhoneMobileMain = "+38031156789",
            PhoneMobileExtra = "+380676542233",
            PhoneHome = "+380441112233",
            EMail = "gesha@gmail.com",

            PUseries = "HE",
            PUnumber = "123456",
            PUissuedWho = "звідктсь там його може колись і видали ",
            PUissuedWhen = new DateTime(2013,10,21),

            Citizenship = "804",
            Residency = 2,
            Inn = "3484225416",
        };

        AgreementMaster agreementMaster = new AgreementMaster
        {
            AgrNumber = "CM-139",
            AgrDate = new DateTime(2012,01,03),
            DateBegin = new DateTime(2012,01,05),
            DateEnd = new DateTime(2025,11,21)
        };

        public DebugOrTestForm()
        {
            InitializeComponent();
        }

        private void BtnActionOne_Click(object sender, EventArgs e)
        {
            
            //anketaPersonControl1.Validator();
            //anketaPersonRightHolderControl1.Validator();

            contactsPersonControl1.DataSource = anketaPerson;
            anketaPersonControl1.DataSource = anketaPerson;
            anketaPersonRightHolderControl1.DataSource = anketaPerson;
            contractConsumerMainControl1.DataSource = agreementMaster;
            passportControl1.DataSource = anketaPerson;
            registrationPersonsControl1.DataSource = anketaPerson;
            //contractConsumerMainControl1.DataSource = agreementMaster;

            //MessageBox.Show(contractControl1.Number + " || " + contractControl1.NumberFromDate.ToString("dd.MM.yyyy"));

            //MessageBox.Show(anketaPersonRightHolderControl1.LastName + " || " +
            //                anketaPersonRightHolderControl1.FirstName + " || " +
            //                anketaPersonRightHolderControl1.MidleName + " || " +
            //                anketaPersonRightHolderControl1.Pseudonym + " || " +
            //                anketaPersonRightHolderControl1.Sex + " || " +
            //                anketaPersonRightHolderControl1.BirthDate.ToString("dd.MM.yyyy"));

        }  

        private void BtnActionSecond_Click(object sender, EventArgs e)
        {
            //anketaPersonRightHolderControl1.Validator();
            //anketaPersonControl1.Validator();
            //anketaPersonRightHolderControl1.DataSourceDropList = anketaPersonRightHolderControl1.DataSourceDropList == 1? 2 : 1;
            registrationPersonsControl1.Validator();
        }
    }
}
