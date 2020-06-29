using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.ConsumerForms
{
    public partial class PrepaysLinkForm : RadForm
    {
        public PrepaysLinkForm()
        {
            InitializeComponent();

            if (string.IsNullOrWhiteSpace(txtAmount.Text))
                errorProvider.SetError(txtAmount, "Необхідно заповнити сума авансу в грн!");
        }

        private void txtAmount_Click(object sender, EventArgs e)
        {

        }
    }
}
