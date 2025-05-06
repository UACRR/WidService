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
    public partial class FormRoyaltyDistribution : Form
    {
        public FormRoyaltyDistribution(int ddexReportId, string initialFileFullName)
        {
            InitializeComponent();
            UcRoyaltyDistribution.Init(ddexReportId, initialFileFullName);
        }

        private void btnCLose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UcRoyaltyDistribution_Load(object sender, EventArgs e)
        {

        }
    }
}
