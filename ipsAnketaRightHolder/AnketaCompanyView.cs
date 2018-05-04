using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ipsAnketaRightHolder
{
    public partial class AnketaCompanyView : Telerik.WinControls.UI.RadForm
    {
        public AnketaCompanyView()
        {
            InitializeComponent();
        }

        //public string Name
        //{
        //    get { return this.tbName.Text; }
        //    set { this.tbName.Text = value; }
        //}

        public string ShortName
        {
            get { return this.tbShortName.Text; }
            set { this.tbShortName.Text = value; }
        }

        public string FaAddress
        {
            get { return this.ipsAddressControl1.radTextBoxAddress.Text; }
            set { this.ipsAddressControl1.radTextBoxAddress.Text = value; }
        }
    }
}
