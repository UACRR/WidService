using ipsFormsDesign.Definition;
using ipsFormsDesign.Interfaces;
using ipsmedserviceapp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.Data;

namespace CustomerWizards
{
    public partial class WizardCustomerView : Telerik.WinControls.UI.RadForm, IFormCompany
    {
        private Customer _data;
        private AnketaCompany _curAnketa;
        private AgreementMaster _curAgreementMaster;
        private RelEmployee _relBoss;
        private RelEmployee _relAccountant;
        private Employee _boss;
        private Employee _accountant;
        private AnketaDictionaties _dictionaries;

        public IAnketaCompany AnketaCompany { get => _curAnketa; }
        public ICustomer Customer { get => _data; }
        public IRelEmployee RelEmployer { get => _relBoss; }
        public IEmployee Employee { get => _relBoss.Empl; }
        public IBankAccount BankAccount { get; set; }
        public IAgreementMaster AgreementMaster { get => _curAgreementMaster; }

        public event EventHandler FieldsValueChanged;
        public event Func<bool> Save;

        public WizardCustomerView()
        {
            InitializeComponent();
        }

        // Сінхронізація 
        private void SetObjectValues(object source, object dest)
        {
            if (ReferenceEquals(dest, source)) return;
            if ((dest == null) || (source == null)) return;
            if (dest.GetType() != source.GetType()) return;

            foreach (var property in dest.GetType().GetProperties())
            {

                // If nullable
                Type checkType = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;

                if (!(checkType.IsPrimitive == true
                  || checkType == typeof(string)
                  || checkType == typeof(Decimal)
                  || checkType == typeof(DateTime))
                   )
                    continue;

                var objValue = property.GetValue(dest);
                var anotherValue = property.GetValue(source);
                //Recursion
                if (anotherValue == null)
                {
                    if (objValue != null)
                        property.SetValue(dest, anotherValue, null);
                }
                else if (objValue == null || !objValue.Equals(anotherValue))
                    property.SetValue(dest, anotherValue, null);
            }
        }

        // Створити об'єкти форми
        private void CreateFormData()
        {
            _data = new Customer
            {
                Company = new Company { RelEmployee = new HashSet<RelEmployee>() },
                AnkVersion = 1
            };
            _curAnketa = new AnketaCompany { Version = 1, BanAcc = new BankAccount() };
            _boss = new Employee();
            _accountant = new Employee();
            _relBoss = new RelEmployee { Empl = _boss, PositionCode = 1 };
            _relAccountant = new RelEmployee { Empl = _accountant, PositionCode = 2 };
            _data.AnketaCompany.Add(_curAnketa);
            _data.Company.RelEmployee.Add(_relBoss);
            _data.Company.RelEmployee.Add(_relAccountant);
            //_bankAccount = new BankAccount();

            _curAgreementMaster = new AgreementMaster
            {
                AgreementAddRh = new AgreementAddRh()
            };
            _data.AgreementMaster.Add(_curAgreementMaster);
        }

        private void DataChanged(object sender, EventArgs e)
        {
            FieldsValueChanged?.Invoke(sender, e);
        }

        private void BindDictionaries()
        {
            ipsAnketaCompanyControl1.ActivityCodeDataSource = _dictionaries.activityType;
            ipsAnketaCompanyControl1.ActivityCodeValueMember = "CodeI";
            ipsAnketaCompanyControl1.ActivityCodeDisplayMember = "Name";

            ipsAddressControl1.CountriesDataSource = _dictionaries.country;
            ipsAddressControl1.CountriesValueMember = "CountryCode";
            ipsAddressControl1.CountriesDisplayMember = "CountryName";

            ipsAddressControl1.RegionsDataSource = _dictionaries.region;
            ipsAddressControl1.RegionsValueMember = "CodeI";
            ipsAddressControl1.RegionsDisplayMember = "Name";

            ipsRegistrationsCompanyControl1.TypesVatDataSource = _dictionaries.typeVat;
            ipsRegistrationsCompanyControl1.TypesVatValueMember = "CodeI";
            ipsRegistrationsCompanyControl1.TypesVatDisplayMember = "Name";
        }

        /// <summary>
        /// Встановити дані форми
        /// </summary>
        /// <param name="data"></param>
        public void SetData(Customer data)
        {
            CreateFormData();
            SetObjectValues(data, _data);
            SetObjectValues(data.Company, _data.Company);
            var anketa = data.AnketaCompany.Where(row => row.Version == data.AnkVersion).SingleOrDefault();
            if (anketa != null)
            {
                SetObjectValues(anketa, _curAnketa);

                if (anketa.BanAcc != null)
                {
                    SetObjectValues(anketa.BanAcc, _curAnketa.BanAcc);
                }
            }
            else
                _data.AnkVersion = 1;

            var relEmplB = data.Company.RelEmployee.Where(item => item.PositionCode == 1).SingleOrDefault();
            if (relEmplB != null)
            {
                SetObjectValues(relEmplB, _relBoss);
                SetObjectValues(relEmplB.Empl, _relBoss.Empl);
                _boss = _relBoss.Empl;
            }

            var relEmplA = data.Company.RelEmployee.Where(item => item.PositionCode == 2).SingleOrDefault();
            if (relEmplA != null)
            {
                SetObjectValues(relEmplA, _relAccountant);
                SetObjectValues(relEmplA.Empl, _relAccountant.Empl);
                _accountant = _relAccountant.Empl;
            }

            var agreement = data.AgreementMaster.FirstOrDefault();
            if (agreement != null)
            {
                SetObjectValues(agreement, _curAgreementMaster);

                if (agreement.AgreementAddRh != null)
                {
                    SetObjectValues(agreement.AgreementAddRh, _curAgreementMaster.AgreementAddRh);
                }
            }

            AnketaCompanySource.DataSource = _curAnketa;
            //BankAccountSource.DataSource = _bankAccount;
     
            //_curAnketa.BanAcc = _bankAccount;
            //ipsBankAccountControl.TxtMfoName.DataBindings.Add("Text", AnketaCompanySource.DataSource, "BanAcc.MfoName");

            ipsBankAccountControl.DataSource = AnketaCompanySource;
            ipsBankAccountControl.DataMember = "BanAcc";

            ipsServiceComissionControl1.DataSource = _curAgreementMaster.AgreementAddRh;

            ipsBossNameContactsControl1.DataSource = _boss;

            SetDataForExlusionsLlimitationsTest();
        }

        private void SetDataForExlusionsLlimitationsTest()
        {
            var copyrightKinds = new List<CopyrightKind>
            {
                new CopyrightKind { CodeI = 1, Name = "Copyright kind 1", CrGroupCode = 1 },
                new CopyrightKind { CodeI = 2, Name = "Copyright kind 2", CrGroupCode = 1 },
                new CopyrightKind { CodeI = 3, Name = "Copyright kind 3", CrGroupCode = 1 },
                new CopyrightKind { CodeI = 3, Name = "Copyright kind 4", CrGroupCode = 2 },
            };

            ipsExclusionsLimitations.GridExclusionsLimitations.DataSource = copyrightKinds;
            ipsExclusionsLimitations.GridExclusionsLimitations.Columns["column1"].FieldName = "Name";

            var descriptor = new GroupDescriptor();
            descriptor.GroupNames.Add("CrGroupCode", ListSortDirection.Ascending);
            ipsExclusionsLimitations.GridExclusionsLimitations.GroupDescriptors.Add(descriptor);
        }

        public void getData(Customer data)
        {
            throw new NotImplementedException();
        }

        public void SetDictionary(AnketaDictionaties dic)
        {
            _dictionaries = dic;
            if (_dictionaries != null)
                BindDictionaries();
        }
    }
}
