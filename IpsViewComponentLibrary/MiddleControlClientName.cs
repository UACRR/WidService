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
    public partial class MiddleControlClientName : UserControl, IMiddleCtrlAnketaConsumer
    {


        private Customer _cust;
        private AnketaDictionaties _dictionaties;

        public event EventHandler OnContainPlacesChanged;

        public MiddleControlClientName()
        {
            InitializeComponent();
        }

        public void SetDataSources(Customer cust, AnketaDictionaties dictionaties)
        {
            _cust = cust;
            _dictionaties = dictionaties;
            AnketaCompany anketa = cust?.Company?.AnketaCompany?.SingleOrDefault(rec => rec.Version == cust.AnkVersion);
            ctrlAnketaCompany.DataSource = anketa;

            ctrlRegistrationsCompany.DataSource = anketa;
            ctrlRegistrationsCompany.TypesVatDataSource = dictionaties?.typeVat;
            ctrlRegistrationsCompany.TypesVatDisplayMember = "Name";
            ctrlRegistrationsCompany.TypesVatValueMember = "CodeI";

            ctrlRegistrationsCompany.NumberVatDataMember = "NumberVat";
            ctrlRegistrationsCompany.OkpoDataMember = "Okpo";
            
            ctrlRegistrationsCompany.RegisterDateDataMember = "RegistrDate";
            ctrlRegistrationsCompany.RegisterNumberDataMember = "RegistrNumber";
            ctrlRegistrationsCompany.RegisterWhoDataMember = "RegistrWho";

            checkClientName.Checked = cust != null && cust?.Client?.ClnBusinessPlace?.Count != 0;
        }

        public bool IsPlaceIn
        {
            get => checkClientName.Checked;
            set => checkClientName.Checked = value;
        }

        private void checkClientName_CheckStateChanged(object sender, EventArgs e)
        {
            OnContainPlacesChanged?.Invoke(this, e);
        }
    }
}
