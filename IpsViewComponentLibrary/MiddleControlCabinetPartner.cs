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
using IpsViewComponentLibrary.ConsumerDialogForms;

namespace IpsViewComponentLibrary
{
    public partial class MiddleControlCabinetPartner : UserControl
    {
        public event SetPartnerEventHandler OnSetPartner;
        public event SetPartnerEventHandler OnRemovePartner;
        public event ChangePartnerEventHandler OnChangePartner;

        public event GetPartnerList OnGetPartnerListNeed;
        private List<AnketaPerson> _anketaPersons;
        public MiddleControlCabinetPartner()
        {
            InitializeComponent();
        }

        public void SetPartnerData(AnketaPerson item)
        {
            lblFullName.Text = item?.LastName + " " + item?.FirstName + " " + item?.SurName;
            lblAgrDate.Text = "";
            lblAgrDateEnd.Text = "";
            lblAgrNumber.Text = "";
            lblMobile.Text = item?.PhoneMobileMain;
            lblEmail.Text = item?.EMail;
        }

        private void btnChangePartner_Click(object sender, EventArgs e)
        {
            SelectPartner selectPartner = new SelectPartner
            {
                StartPosition = FormStartPosition.CenterParent
            };
            selectPartner.SetPartnerList(OnGetPartnerListNeed?.Invoke());
            if (selectPartner.ShowDialog() == DialogResult.OK)
            {
                //TODO: зберегти
            }
        }

        private void btnset_Click(object sender, EventArgs e)
        {
            OnSetPartner?.Invoke(134,300);
        }

        private void btnUpd_Click(object sender, EventArgs e)
        {
            OnChangePartner?.Invoke(142, 302, 135);

        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            OnRemovePartner?.Invoke(142, 302);
        }
    }
}
