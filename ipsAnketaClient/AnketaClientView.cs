using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IpsViewComponentLibrary;
using Telerik.WinControls.UI;
using ipsFormsDesign.Definition;
using ipsFormsDesign.Interfaces;
using ipsmedserviceapp.Model;

namespace ipsAnketaClient
{
    public partial class AnketaClientView : Telerik.WinControls.UI.RadForm, IFormConsumerComany
    {
        private Customer _data;
        private AnketaCompany _curAnketa;
        private RelEmployee _relBoss;

        public IAnketaCompany AnketaCompany => _curAnketa;

        public ICustomer Customer => _data;
        public IRelEmployee RelEmployer => _relBoss;
        public IEmployee Employee => _relBoss.Empl;
        public IClient Client => _data.Client;
        private AnketaDictionaties _dictionaries;
        private List<IClnBusinessPlace> listBisPlace;
        private List<IClnPlaceHoll> listPlaceHole;

        public IList<IClnBusinessPlace> clnBusinessPlaceList
        {
            get => clnBusinessPlaceList;
            set => clnBusinessPlaceList = (List<IClnBusinessPlace>)value;
        }
        public IList<IClnPlaceHoll> clnPlaceHoll
        {
            get => listPlaceHole;
            set => listPlaceHole = (List<IClnPlaceHoll>)value;
        }
        public IList<ILicPlaceHoll> licPlaceHoll { get; set; }
        public event Func<bool> Save;

        public int IdItemOfSelectRow { get; set; }
        public AnketaClientView()
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

                if (!(source.GetType().IsPrimitive
                      || checkType == typeof(string)
                      || checkType == typeof(Decimal)
                      || checkType == typeof(DateTime)
                      //|| checkType == typeof(Int32)
                      || checkType.IsPrimitive))//+числові значення
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
                AnkVersion = 1,
                Client = new Client { ClnBusinessPlace = new HashSet<ClnBusinessPlace>() }
            };
            _curAnketa = new AnketaCompany { Version = 1 };
            _relBoss = new RelEmployee { Empl = new Employee() };
            _data.AnketaCompany.Add(_curAnketa);
            _data.Company.RelEmployee.Add(_relBoss);


        }

        public void SetData(Customer data)
        {

            createFormData();
            SetObjectValues(data, _data);
            SetObjectValues(data.Company, _data.Company);
            SetObjectValues(data.Client, _data.Client);

            var anketa = data.AnketaCompany.SingleOrDefault(row => row.Version == data.AnkVersion);
            if (anketa != null)
                SetObjectValues(anketa, _curAnketa);
            else
                _data.AnkVersion = 1;

            var relEmpl = data.Company.RelEmployee.SingleOrDefault(item => item.PositionCode == 1);
            if (relEmpl != null)
            {
                SetObjectValues(relEmpl, _relBoss);
                SetObjectValues(relEmpl.Empl, _relBoss.Empl);
            }

            foreach (var clnBusinessPlace in data.Client.ClnBusinessPlace)
            {
                ClnBusinessPlace place = new ClnBusinessPlace { ClnPlaceHoll = new HashSet<ClnPlaceHoll>()};
                place.PlCodeNavigation = new TypePlace();
                SetObjectValues(clnBusinessPlace.PlCodeNavigation, place.PlCodeNavigation);
                SetObjectValues(clnBusinessPlace, place);
                foreach (var holle in clnBusinessPlace.ClnPlaceHoll)
                {
                    ClnPlaceHoll newHolle = new ClnPlaceHoll();
                    SetObjectValues( holle, newHolle);
                    place.ClnPlaceHoll.Add( newHolle );
                }
                _data.Client.ClnBusinessPlace.Add(place);
            }

            iClnBusinessPlaceBindingSource.DataSource = _data.Client.ClnBusinessPlace;
            consumerPlacesCtrl.SetGridDataSource(iClnBusinessPlaceBindingSource.DataSource);
            consumerPlacesCtrl.SetData(_data);
        }

        
        public void getData(Customer data)
        {
            throw new NotImplementedException();
        }

        public void SetDictionary(AnketaDictionaties dic)
        {
            _dictionaries = dic;
        }
    }
}
