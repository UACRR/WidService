using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ipsFormsDesign.Model;
using Telerik.WinControls;

namespace IpsViewComponentLibrary.CommunityControls
{
    public partial class CommunityForm : Telerik.WinControls.UI.RadForm
    {
        public CommunityForm(Customer customer)
        {
            InitializeComponent();
            DialogResult = DialogResult.None;
            ctrlContactPerson.UnsubscribePhoneVldt();
        }

    }
}
