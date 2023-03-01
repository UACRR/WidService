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
            txtMessage.AppendText(message);
            txtDetails.AppendText(details);
        }

        public IPSMessageBox(ResponseOfRequest response) : this()
        {
            txtMessage.AppendText(response.Message);
            txtDetails.AppendText(response.InnerMessage);
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
