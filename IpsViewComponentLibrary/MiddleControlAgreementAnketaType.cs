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

        /// <summary>
        /// Тип права
        /// </summary>
        public TypeRights typeRights { get; set; } = TypeRights.SmallRights;

        public void SetDataSources(Customer cust, AnketaDictionaties dictionaties )
        {
            AnketaCompany anketa = cust?.Company?.AnketaCompany?.SingleOrDefault(rec => rec?.Version == cust?.AnkVersion);
            var license = cust?.Client?.LicenseAgreement?.FirstOrDefault(rec => rec.LicStatus < 4);
            var licenseParam = license?.LicenseAgrParam?.SingleOrDefault(rec => rec?.LicVersion == license?.LicVersion);


            ddlLicType.DataSource = dictionaties?.agrLicenseType.Where( rec => 
            {
                switch (typeRights)
                {
                    case TypeRights.SmallRights:
                        return rec.UsesKind != 1;
                    case TypeRights.BigRights:
                        return rec.UsesKind == 1;
                }
                return true;
            });

            ddlLicType.DataBindings.Clear();
            ddlLicType.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", license, "LicCode", true));

            ddlLicType.DisplayMember = "name";
            ddlLicType.ValueMember = "codeI";
            ddlLicType.SelectedValue = license?.LicCode;
           
            

            ctrlAgreementMain.DataSource = licenseParam;
            // ctrlAgreementMain.DateDataSource = licenseParam;
            //ctrlAgreementMain.ContrNumber = "LicNum";
            //ctrlAgreementMain.AgrDateDataMember = "LicDate";
            //ctrlAgreementMain.BeginDateDataMember = "DateBegin";
            //ctrlAgreementMain.EndDateDataMember = "DateEnd";

            
            ctrlAgreementSecond.DataSourceBinding = licenseParam;
            ctrlAgreementSecond.IsAutoprolongation = licenseParam?.IsAutoprolog ?? false;
            ctrlAgreementSecond.MinPayment = "MinAmount";
            ctrlAgreementSecond.PercentPayment = "RateAmount";

            ctrlAgreementSecond.PeriodPaymentDataSource = dictionaties?.period;
            ctrlAgreementSecond.PeriodPaymentValueMember = "codeI";
            ctrlAgreementSecond.PeriodPaymentDisplayMember = "name";
            ctrlAgreementSecond.PeriodPaymentDataMember = "PeriodCode";
            ctrlAgreementSecond.PeriodPaymentSelectedValue = licenseParam?.PeriodCode;

            if (licenseParam?.AddRate == null && licenseParam?.IndxInfl != null)
                ctrlAgreementSecond.SelectedItem = 1;
            else if (licenseParam?.AddRate != null && licenseParam.IndxInfl == null)
                ctrlAgreementSecond.SelectedItem = 0;
            else
                ctrlAgreementSecond.AutoprolongationPercent = null;

            
            lblTitle.Text = anketa?.Name;
            
        }

        public bool Validator()
        {
            return ctrlAgreementMain.Validator() && ctrlAgreementSecond.Validator();
        }

        internal void SetDefaultListItem()
        {
            if (ddlLicType.Items.Count != 0)
            {
                ddlLicType.SelectedIndex = ddlLicType.Items.Last.Index;
                ddlLicType.SelectedIndex = ddlLicType.Items.First.Index;
            }

            ctrlAgreementSecond.SetDefaultState();
        }
    }
}
