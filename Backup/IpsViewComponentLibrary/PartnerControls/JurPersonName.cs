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
using ipsFormsDesign.Dictionary;
using IpsViewComponentLibrary.Extensions;

namespace IpsViewComponentLibrary
{
    public partial class JurPersonName : UserControl
    {
        public JurPersonName()
        {
            InitializeComponent();
            ctrlRegistrationsCompany.DtRegisterDate.MaxDate = DateTime.Now;
        }

        public void SetDataSources(Customer customer)
        {
            var anketa = customer?.Company?.AnketaCompany?.SingleOrDefault(rec => rec.Version == customer.AnkVersion);
            
            ctrlAnketaCompany.DataSource = anketa;
            ctrlRegistrationsCompany.DataSource = anketa;   
        }

        public bool Validator()
        {
            bool isvalid = true;

            if(!ctrlAnketaCompany.Validator())
                isvalid = false;
            if (!ctrlRegistrationsCompany.Validator())
                isvalid = false;

            return isvalid;

        }
    }
}
