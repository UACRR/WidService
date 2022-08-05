using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.Common
{
    public partial class ConfirmationView : RadForm
    {
        private bool _showAcceptButton = false;
        public bool ShowAcceptButton
        {
            get { return _showAcceptButton; }
            set
            {
                _showAcceptButton = value;
                btnAccept.Visible = _showAcceptButton;
            }
        }

        public string InformationText
        {
            get => txtInformation.Text;
            set => txtInformation.Text = value;
        }

        public ConfirmationView()
        {
            InitializeComponent();
        }
    }
}
