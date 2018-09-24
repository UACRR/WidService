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
        private AnketaPerson _partner;
        private int _cientId;
        public MiddleControlCabinetPartner()
        {
            InitializeComponent();
        }

        public void SetPartnerData(AnketaPerson item, int cientId)
        {
            _partner = item;
            _cientId = cientId;
            lblFullName.Text = item?.LastName + " " + item?.FirstName + " " + item?.SurName;
            lblAgrDate.Text = "";
            lblAgrDateEnd.Text = "";
            lblAgrNumber.Text = "";
            lblMobile.Text = item?.PhoneMobileMain;
            lblEmail.Text = item?.EMail;
        }

        //змінити представника
        private void btnChangePartner_Click(object sender, EventArgs e)
        {
            SelectPartner selectPartner = new SelectPartner(_partner?.CustId)
            {
                StartPosition = FormStartPosition.CenterParent
            };
            selectPartner.SetPartnerList(OnGetPartnerListNeed?.Invoke());
            
            if (selectPartner.ShowDialog() == DialogResult.Yes)
            {
                if(selectPartner.PartnerId != null)
                {
                    if(_partner?.CustId == null) // додати
                        OnSetPartner?.Invoke(_cientId, (int)selectPartner.PartnerId);
                    if(_partner?.CustId != null) // змінити
                        OnChangePartner?.Invoke(_cientId, (int)selectPartner.PartnerId, _partner.CustId);
                }
            }
        }

        //видалити представника
        private void btnRemovePartner_Click(object sender, EventArgs e)
        {
            if (_partner?.CustId != null)
                OnRemovePartner?.Invoke(_cientId, _partner.CustId);
        }
    }
}
