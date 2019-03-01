using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IpsViewComponentLibrary
{
    public partial class ConsumerTitleControl : UserControl
    {
        public string ContractNumber
        {
            set => lblNumberContract.Text = value;
        }

        public string ContractBeginDate
        {
            set => lblDateBegin.Text = value;
        }

        public string ClientName
        {
            set => lblClientName.Text = value;
        }

        public ConsumerTitleControl()
        {
            InitializeComponent();
        }
    }
}
