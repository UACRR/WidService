using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ipsTestExp;
using System.Windows.Forms;
using sysAdminwp;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using WebAPIConnector;
using ipsmedserviceapp;
using ipsmedserviceapp.Model;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Definition;

namespace ipsTestExp
{

    public partial class MainForm : RadForm, IFormCompany
    {
        private Customer _data;
        private AnketaCompany _curAnketa;
        private RelEmployee _relBoss;

        public IAnketaCompany AnketaCompany => _curAnketa;

        public ICustomer Customer => _data;
        public IRelEmployee RelEmployer => _relBoss;
        public IEmployee Employee => _relBoss.Empl;
        private AnketaDictionaties _dictionaries;


        public event EventHandler FieldsValueChanged;
        public event Func<bool> Save;


        // Сінхронізація 
        private void SetObjectValues( object source, object dest )
        {
            if (ReferenceEquals(dest, source)) return;
            if ((dest == null) || (source == null)) return;
            if (dest.GetType() != source.GetType()) return;

            foreach (var property in dest.GetType().GetProperties())
            {

                // If nullable
                Type checkType = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;

                if (!(source.GetType().IsPrimitive == true
                  || checkType == typeof(string)
                  || checkType == typeof(Decimal)
                  || checkType == typeof(DateTime)))
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
        private void createFormData()
        {
            _data = new Customer
            {
                Company = new Company { RelEmployee = new HashSet<RelEmployee>() },
                AnketaCompany = new HashSet<AnketaCompany>(),
                AnkVersion = 1
            };
            _curAnketa = new AnketaCompany { Version = 1 };
            _relBoss = new RelEmployee { Empl = new Employee() };
            _data.AnketaCompany.Add(_curAnketa);
            _data.Company.RelEmployee.Add(_relBoss);

        }
        public MainForm()
        {
            InitializeComponent();
        }


        private void data_changed( object sender, EventArgs e)
        {
            FieldsValueChanged?.Invoke(sender, e);
        }

        /// <summary>
        /// Встановити дані форми
        /// </summary>
        /// <param name="data"></param>
        public void SetData(Customer data)
        {

            createFormData();
            SetObjectValues(data, _data);
            SetObjectValues(data.Company, _data.Company);
            var anketa = data.AnketaCompany.Where(row => row.Version == data.AnkVersion).SingleOrDefault();
            if (anketa != null)
                SetObjectValues(anketa,_curAnketa);
            else
                _data.AnkVersion = 1;

            var relEmpl = data.Company.RelEmployee.Where(item => item.PositionCode == 1).SingleOrDefault();
            if( relEmpl != null )
            {
                SetObjectValues(relEmpl, _relBoss);
                SetObjectValues(relEmpl.Empl, _relBoss.Empl);
            }

            iAnketaCompanyBindingSource.DataSource = _curAnketa;    
        }

        public void getData(Customer data)
        {
            throw new NotImplementedException();
        }

        private void bindDictionaries()
        {
            ddl.DataSource = _dictionaries.activityType;
            // ddl.DataMember = "CodeI";
            ddl.ValueMember = "CodeI";
            ddl.DisplayMember = "name";
        }
        public void SetDictionary(AnketaDictionaties dic)
        {
            _dictionaries = dic;
            if (_dictionaries != null)
                bindDictionaries();
        }

        /// <summary>
        /// Завантаження контролів
        /// </summary>


    }

}
