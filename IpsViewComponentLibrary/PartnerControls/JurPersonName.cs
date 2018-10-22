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
    public partial class JurPersonName : UserControl, IMiddleCtrlAnketaConsumer
    {
        private AnketaDictionaties _dictionaties;

        public JurPersonName()
        {
            InitializeComponent();
            ctrlRegistrationsCompany.DtRegisterDate.MaxDate = DateTime.Now;
        }

        public void SetDataSources(Customer cust, AnketaDictionaties dictionaties )
        {
            _dictionaties = dictionaties;
            AnketaCompany anketa = cust?.Company?.AnketaCompany?.SingleOrDefault(rec => rec.Version == cust.AnkVersion);
            anketa.TypeVat = 1;
            ctrlAnketaCompany.DataSource = anketa;

            ctrlRegistrationsCompany.DataSource = anketa;
            ctrlRegistrationsCompany.TypesVatDataSource = dictionaties?.typeVat;
            ctrlRegistrationsCompany.TypesVatDisplayMember = "Name";
            ctrlRegistrationsCompany.TypesVatValueMember = "CodeI";
            ctrlRegistrationsCompany.TypeVatDataMember = "TypeVat";

            ctrlRegistrationsCompany.NumberVatDataMember = "NumberVat";

            
            ctrlRegistrationsCompany.OkpoDataMember = "Okpo";
            
            ctrlRegistrationsCompany.RegisterDateDataMember = "RegistrDate";
            ctrlRegistrationsCompany.RegisterNumberDataMember = "RegistrNumber";
            ctrlRegistrationsCompany.RegisterWhoDataMember = "RegistrWho";
            ctrlRegistrationsCompany.SetDefaultState();
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
