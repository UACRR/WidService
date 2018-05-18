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
        private RelEmployee _relBoss;
        private AnketaDictionaties _dictionaries;

        public IAnketaCompany AnketaCompany { get => _curAnketa; }
        public ICustomer Customer { get => _data; }
        public IRelEmployee RelEmployer { get => _relBoss; }
        public IEmployee Employee { get => _relBoss.Empl; }
        public IClient Client { get; }
        public IBankAccount BankAccount { get; set; }

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
                AnketaCompany = new HashSet<AnketaCompany>(),
                AnkVersion = 1
            };
            _curAnketa = new AnketaCompany { Version = 1, BanAcc = new BankAccount() };
            _relBoss = new RelEmployee { Empl = new Employee(), PositionCode = 1 };
            _data.AnketaCompany.Add(_curAnketa);
            _data.Company.RelEmployee.Add(_relBoss);
            //_bankAccount = new BankAccount();
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

            var relEmpl = data.Company.RelEmployee.Where(item => item.PositionCode == 1).SingleOrDefault();
            if (relEmpl != null)
            {
                SetObjectValues(relEmpl, _relBoss);
                SetObjectValues(relEmpl.Empl, _relBoss.Empl);
            }

            AnketaCompanySource.DataSource = _curAnketa;
            //BankAccountSource.DataSource = _bankAccount;
     
            //_curAnketa.BanAcc = _bankAccount;
            //ipsBankAccountControl.TxtMfoName.DataBindings.Add("Text", AnketaCompanySource.DataSource, "BanAcc.MfoName");

            ipsBankAccountControl.DataSource = AnketaCompanySource;
            ipsBankAccountControl.DataMember = "BanAcc";

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
