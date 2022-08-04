using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ExportImport.EntityManager;

namespace ExportImport
{
    public partial class FormProgressLog : Form
    {
        public delegate void Run(ProcessingPropress processingPropress);
        private Run _run;

        public FormProgressLog(Run run)
        {
            InitializeComponent();
            _run = run;
        }

        private void FormProgressLog_Load(object sender, EventArgs e)
        {
            radBtnClose.Enabled = false;
            _run(ProcessingPropress);
        }

        private void ProcessingPropress(string progressMessage, bool isFinal)
        {
            radTbLog.AppendText(progressMessage + "\r\n");
            if(isFinal)
            {
                radBtnClose.Enabled = true;
            }
        }

        private void radBtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
