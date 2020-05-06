using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DdexInvoicing
{
    public partial class FormLongOperation : Form
    {
        public FormLongOperation(string message)
        {
            InitializeComponent();
            radTbMessage.Text = message;
        }
    }
}
