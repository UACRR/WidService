using IpsCommonTypes.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPSComponentLibrary.Forms
{
    public partial class IPSMessageBox : Form
    {
        private IPSMessageBox()
        {
            InitializeComponent();
        }

        public IPSMessageBox(string message, string details) : this()
        {
            if (!string.IsNullOrEmpty(message))
                txtMessage.AppendText(message);
            if (!string.IsNullOrEmpty(details))
                txtDetails.AppendText(details);
        }

        public IPSMessageBox(ResponseOfRequest response) : this()
        {
            if (!string.IsNullOrEmpty(response.Message))
                txtMessage.AppendText(response.Message);
            if (!string.IsNullOrEmpty(response.InnerMessage))
                txtDetails.AppendText(response.InnerMessage);
            if (response.Exception != null)
                txtDetails.AppendText(response.Exception.ToString());
        }

        private void btnSend_Click(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
