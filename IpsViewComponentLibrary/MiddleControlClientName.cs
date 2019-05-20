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

namespace IpsViewComponentLibrary
{
    public partial class MiddleControlClientName : UserControl
    {
        public event EventHandler<string> TextNameChanged;

        public MiddleControlClientName()
        {
            InitializeComponent();
            ctrlAnketaCompany.TextNameChanged += CtrlAnketaCompany_TextNameChanged;
            ctrlRegistrationsCompany.MaxDate = DateTime.Now;
        }

        private void CtrlAnketaCompany_TextNameChanged(object sender, string e)
        {
            TextNameChanged?.Invoke(sender, e);
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

        internal void SetAutoComplete(Func<string, IList<AutoCompleteData>> _getAutoCompList, Func<int, Customer> _getCustomerAnketa)
        {
            ctrlAnketaCompany.SetAutoComplete(_getAutoCompList, _getCustomerAnketa);
        }
    }
}
