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

        public event EventHandler FieldsValueChanged;
        public event Func<bool> Save;

        // Сінхронізація 
        private void SetObjectValues( object sors, object dest )
        {
            // Поля цілі
            var destProperties = dest.GetType().GetProperties().ToDictionary(rec => rec.Name);
            // Для кожного поля джерела
            sors.GetType().GetProperties().ToList().ForEach(sorsItem => {
                if (sorsItem.PropertyType.IsAbstract) // для примитивних полів
                {
                    // Получить поле цілі
                    var destItem = destProperties[sorsItem.Name];
                    // Получити значення поля цілі
                    var destValue = destItem.GetValue(destItem);
                    // Получити значення джерела
                    var sorsValue = sorsItem.GetValue(sorsItem);
                    // Якщо значення не співпадають
                    if (destValue != sorsValue)
                        destItem.SetValue(destItem, sorsValue);

                }
            });
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

            SetObjectValues(data, _data);
            SetObjectValues(data.Company, _data.Company);
            var anketa = data.AnketaCompany.Where(row => row.Version == data.AnkVersion).SingleOrDefault();
            if (anketa != null)
                SetObjectValues(_curAnketa, anketa);
            else
                _data.AnkVersion = 1;

            var relEmpl = data.Company.RelEmployee.Where(item => item.PositionCode == 1).SingleOrDefault();
            if( relEmpl != null )
            {
                SetObjectValues(relEmpl, _relBoss);
                SetObjectValues(relEmpl.Empl, _relBoss.Empl);
            }

        }

        public void getData(Customer data)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Завантаження контролів
        /// </summary>


    }

}
