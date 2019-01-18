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
    public partial class MiddleControlClientName : UserControl, IMiddleCtrlAnketaConsumer
    {
        private Customer _cust;
        private AnketaDictionaties _dictionaties;

        public MiddleControlClientName()
        {
            InitializeComponent();
            ctrlRegistrationsCompany.DtRegisterDate.MaxDate = DateTime.Now;
        }

        private AnketaCompany anketa;
        public void SetDataSources(Customer cust, AnketaDictionaties dictionaties )
        {
            _cust = cust;
            _dictionaties = dictionaties;
            anketa = _cust?.Company?.AnketaCompany?.SingleOrDefault(rec => rec.Version == _cust.AnkVersion);
            
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
