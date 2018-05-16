using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DebugFormForControls
{
    public partial class ContactsPersonControl : UserControl
    {
        public string MobilePhone => rtxtBoxMobPhone.Text;
        public string MobilePhoneSecond => rtxtBoxMobPhoneSecond.Text;
        public string HomePhone => rtxtBoxHomePhone.Text;
        public string Email => rtxtBoxEmail.Text;

        public ContactsPersonControl()
        {
            InitializeComponent();
            rtxtBoxMobPhone.MaxLength = 13;
            rtxtBoxMobPhoneSecond.MaxLength = 13;
            rtxtBoxHomePhone.MaxLength = 14;
        }

        public bool Validator()
        {
            bool isValid = true;

            if (rtxtBoxMobPhone.Text == string.Empty)
            {
                lblMobPhone.ForeColor = Color.FromArgb(180, 255, 0, 2);
                isValid = false;
            }
            else
                lblMobPhone.ForeColor = Color.Black;

            return isValid;
        }
    }
}
