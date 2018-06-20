using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;

namespace IpsViewComponentLibrary
{
    public partial class MiddleControlAgreementAnketaType : UserControl, IMiddleCtrlAnketaConsumer
    {
        public MiddleControlAgreementAnketaType()
        {
            InitializeComponent();
        }

        public void SetDataSources(Customer cust, AnketaDictionaties dictionaties)
        {
            AnketaCompany anketa = cust?.Company?.AnketaCompany?.SingleOrDefault(rec => rec?.Version == cust?.AnkVersion);


            lblTitle.Text = anketa?.Name;
        }
    }
}
