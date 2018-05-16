using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DebugFormForControls
{
    public partial class DebugOrTestForm : Telerik.WinControls.UI.RadForm
    {
        public DebugOrTestForm()
        {
            InitializeComponent();
        }

        private void BtnActionOne_Click(object sender, EventArgs e)
        {
            if(!anketaPersonRightHolderControl1.Validator()) return;
            //MessageBox.Show(contractControl1.Number + " || " + contractControl1.NumberFromDate.ToString("dd.MM.yyyy"));

           //MessageBox.Show(anketaPersonRightHolderControl1.LastName + " || " +
           //                anketaPersonRightHolderControl1.FirstName + " || " +
           //                anketaPersonRightHolderControl1.MidleName + " || " +
           //                anketaPersonRightHolderControl1.Pseudonym + " || " +
           //                anketaPersonRightHolderControl1.Sex + " || " +
           //                anketaPersonRightHolderControl1.BirthDate.ToString("dd.MM.yyyy"));

            MessageBox.Show(contactsPersonControl1.MobilePhone + " || " +
                            contactsPersonControl1.MobilePhoneSecond + " || " +
                            contactsPersonControl1.HomePhone + " || " +
                            contactsPersonControl1.Email);
        }  

        private void BtnActionSecond_Click(object sender, EventArgs e)
        {
            anketaPersonRightHolderControl1.ClearData();
        }
    }
}
