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
            _curAnketa = new AnketaCompany { Version = 1 };
            _relBoss = new RelEmployee { Empl = new Employee(), PositionCode = 1 };
            _data.AnketaCompany.Add(_curAnketa);
            _data.Company.RelEmployee.Add(_relBoss);
        }

        private void DataChanged(object sender, EventArgs e)
        {
            FieldsValueChanged?.Invoke(sender, e);
        }

        private void BindDictionaries()
        {
            //ddlActivityCode.DataSource = _dictionaries.activityType;
            //ddlActivityCode.ValueMember = "CodeI";
            //ddlActivityCode.DisplayMember = "name";

            //ipsAddressControlJa.radDropDownListCountry.DataSource = _dictionaries.country;
            //ipsAddressControlJa.radDropDownListCountry.ValueMember = "CountryCode";
            //ipsAddressControlJa.radDropDownListCountry.DisplayMember = "CountryName";

            //ipsAddressControlFa.radDropDownListCountry.DataSource = _dictionaries.country;
            //ipsAddressControlFa.radDropDownListCountry.ValueMember = "CountryCode";
            //ipsAddressControlFa.radDropDownListCountry.DisplayMember = "CountryName";

            //ipsAddressControlJa.radDropDownListRegion.DataSource = _dictionaries.region;
            //ipsAddressControlJa.radDropDownListRegion.ValueMember = "CodeI";
            //ipsAddressControlJa.radDropDownListRegion.DisplayMember = "Name";

            //ipsAddressControlFa.radDropDownListRegion.DataSource = _dictionaries.region;
            //ipsAddressControlFa.radDropDownListRegion.ValueMember = "CodeI";
            //ipsAddressControlFa.radDropDownListRegion.DisplayMember = "Name";

            //ddlDirectorPositionType.DataSource = _dictionaries.positionType;
            //ddlDirectorPositionType.ValueMember = "CodeI";
            //ddlDirectorPositionType.DisplayMember = "Name";
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
                SetObjectValues(anketa, _curAnketa);
            else
                _data.AnkVersion = 1;

            var relEmpl = data.Company.RelEmployee.Where(item => item.PositionCode == 1).SingleOrDefault();
            if (relEmpl != null)
            {
                SetObjectValues(relEmpl, _relBoss);
                SetObjectValues(relEmpl.Empl, _relBoss.Empl);
            }

            AnketaCompanySource.DataSource = _curAnketa;
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
