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
        private IpsPremisesTypeControl premisesType;
        private bool IsNeedPremissesType = false;
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


        private void PremisesType_OnBtnAddPremisesClick()
        {
            AddPremisesForm newPremises = new AddPremisesForm();
            newPremises.ShowDialog();
            GC.Collect();
        }


        private void PremisesType_OnBtnEditPremisesClick()
        {
            AddPremisesForm editPremises = new AddPremisesForm(premisesType.GetData());
            MessageBox.Show(premisesType.IdSelectedRow.ToString());

        }

        private void PremisesType_OnBtnDeletePremisesClick()
        {
            MessageBox.Show(premisesType.IdSelectedRow.ToString());
        }

        #region [ -- Кнопки додавання нових закладів -- ]

        private void rBtnAddRestaurant_Click(object sender, EventArgs e)
        {
            rTxtBoxTypeInst.Text = rBtnAddRestaurant.Text;
            rPanelAdd.Visible = true;
            InitializeAdditionalComponents();
            rDropDownBtnAddInst.Enabled = false;
            IsNeedPremissesType = true;
            rBtnEditInst.Enabled = false;
            rGridViewInstitution.Enabled = false;
        }

        private void rBtnAddHotel_Click(object sender, EventArgs e)
        {
            rTxtBoxTypeInst.Text = rBtnAddHotel.Text;
            rPanelAdd.Visible = true;
            rDropDownBtnAddInst.Enabled = false;
            IsNeedPremissesType = true;
            rGridViewInstitution.Enabled = false;
            rBtnEditInst.Enabled = false;
            InitializeAdditionalComponents();
        }

        private void rBtnAddNightClub_Click(object sender, EventArgs e)
        {
            rTxtBoxTypeInst.Text = rBtnAddNightClub.Text;
            rPanelAdd.Visible = true;
            rTxtBoxCountOrMeters.Visible = true;
            lblLocation.Visible = true;
            lblLocation.Text = "Кількість місць";
            rDropDownBtnAddInst.Enabled = false;
            rBtnEditInst.Enabled = false;
            rGridViewInstitution.Enabled = false;
            rPanelAdd.ClientSize = new Size(rPanelAdd.Width, 215);// без додаткового гріда
        }

        private void rBtnAddNightClubFree_Click(object sender, EventArgs e)
        {
            rTxtBoxTypeInst.Text = rBtnAddNightClub.Text;
            rPanelAdd.Visible = true;
            rTxtBoxCountOrMeters.Visible = true;
            lblLocation.Visible = true;
            lblLocation.Text = "Метраж";
            rDropDownBtnAddInst.Enabled = false;
            rBtnEditInst.Enabled = false;
            rGridViewInstitution.Enabled = false;
            rPanelAdd.ClientSize = new Size(rPanelAdd.Width, 215);// без додаткового гріда
        }

        private void rBtnAddCaffeOrBar_Click(object sender, EventArgs e)
        {
            rTxtBoxTypeInst.Text = rBtnAddCaffeOrBar.Text;
            rPanelAdd.Visible = true;
            lblLocation.Visible = true;
            rTxtBoxCountOrMeters.Visible = true;
            lblLocation.Text = "Кількість місць";
            rDropDownBtnAddInst.Enabled = false;
            rBtnEditInst.Enabled = false;
            rGridViewInstitution.Enabled = false;
            rPanelAdd.ClientSize = new Size(rPanelAdd.Width, 215);// без додаткового гріда
        }

        private void rBtnAddTheaterOrOpera_Click(object sender, EventArgs e)
        {
            rTxtBoxTypeInst.Text = rBtnAddTheaterOrOpera.Text;
            rPanelAdd.Visible = true;
            lblLocation.Visible = true;
            rTxtBoxCountOrMeters.Visible = true;
            lblLocation.Text = "Кількість місць";
            rDropDownBtnAddInst.Enabled = false;
            rBtnEditInst.Enabled = false;
            rGridViewInstitution.Enabled = false;
            rPanelAdd.ClientSize = new Size(rPanelAdd.Width, 215);// без додаткового гріда
        }

        #endregion

        /// <summary>
        /// кнопка "Редагувати заклад"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rBtnEditInst_Click(object sender, EventArgs e)
        {
            if(rGridViewInstitution.CurrentRow.Cells[0].Value.GetType()!=typeof(Int32))
                return;
            IdItemOfSelectRow = (int) rGridViewInstitution.CurrentRow.Cells[0].Value;
            var typePlace = _data.Client.ClnBusinessPlace.Where(itemId => itemId.PlaceId == IdItemOfSelectRow).Select(item => item.PlCodeNavigation).SingleOrDefault();
            if(typePlace!=null)
                if (typePlace.CodeI == 1 || typePlace.CodeI == 2)
                {
                    InitializeAdditionalComponents();
                    IsNeedPremissesType = true;
                    premisesType.SetDataSource(_data, IdItemOfSelectRow);
                }

            rTxtBoxNameInst.Text = _data.Client.ClnBusinessPlace.Where(itemId=>itemId.PlaceId == IdItemOfSelectRow).Select(item=>item.PlaceName).SingleOrDefault();
            var type = _data.Client.ClnBusinessPlace.Where(itemId => itemId.PlaceId == IdItemOfSelectRow).Select(item => item.PlCodeNavigation).SingleOrDefault();
            if(type !=null)
                rTxtBoxTypeInst.Text = type.Name;
            addressControl.SetAddressForEditCustomer(_data,IdItemOfSelectRow);

            rPanelAdd.Visible = true;
            rDropDownBtnAddInst.Enabled = false;
            rGridViewInstitution.Enabled = false;
            rBtnEditInst.Enabled = false;
        }

        private void rBtnCancel_Click(object sender, EventArgs e)
        {
            rPanelAdd.Visible = false;
            rDropDownBtnAddInst.Enabled = true;
            //this.ClientSize = new System.Drawing.Size(Width, Height-rPanelAdd.Height);
            ClearTxtBoxes();

            if (premisesType != null)
            {
                rPanelAdd.Controls.Remove(premisesType);
                rPanelAdd.ClientSize = new Size(rPanelAdd.Width, rPanelAdd.Height-235);//   - 240
                rPanelAdd.Refresh();
                premisesType.OnBtnAddPremisesClick -= PremisesType_OnBtnAddPremisesClick;
                premisesType.OnBtnDeletePremisesClick -= PremisesType_OnBtnDeletePremisesClick;
                premisesType.OnBtnEditPremisesClick -= PremisesType_OnBtnEditPremisesClick;
                premisesType.Dispose();
                premisesType = null;
                GC.Collect();
            }
            DefaultColorLabels();
            rGridViewInstitution.Enabled = true;
            IsNeedPremissesType = false;
            rBtnEditInst.Enabled = true;
        }

        /// <summary>
        /// Очищення даних в txtbox
        /// </summary>
        private void ClearTxtBoxes()
        {
            rTxtBoxNameInst.Clear();
            rTxtBoxTypeInst.Clear();
            rTxtBoxCountOrMeters.Clear();
            addressControl.SetEmpty();
        }

        /// <summary>
        /// Створення контрола з грідом та додаванням нового типу приміщення
        /// </summary>
        private void InitializeAdditionalComponents()
        {
            rTxtBoxCountOrMeters.Visible = false;
            lblLocation.Visible = false;
            lblLocation.Text = string.Empty;

            premisesType = new IpsPremisesTypeControl();
            premisesType.OnBtnAddPremisesClick += PremisesType_OnBtnAddPremisesClick;
            premisesType.OnBtnDeletePremisesClick += PremisesType_OnBtnDeletePremisesClick;
            premisesType.OnBtnEditPremisesClick += PremisesType_OnBtnEditPremisesClick;
            premisesType.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);
            premisesType.Location = new Point(10, 155); ;
            premisesType.Width = addressControl.Width;
            rPanelAdd.ClientSize = new Size(rPanelAdd.Width, rPanelAdd.Height+235);//   + 240

            rPanelAdd.Controls.Add(premisesType);
        }


        private void rBtnSave_Click(object sender, EventArgs e)
        {
            addressControl.SetValues();

            if (!Validator())
                return;

            if (IsNeedPremissesType)
            {
                //some code
            }
            else
            {
                //some code
            }

            //some code

            IsNeedPremissesType = false;

            //ClearTxtBoxes();
        }

        /// <summary>
        /// Перевірка на пусті поля
        /// </summary>
        /// <returns></returns>
        private bool Validator()
        {
            bool valid = true;
            if (rTxtBoxNameInst.Text == string.Empty)
            {
                valid = false;
                rLblName.ForeColor = Color.FromArgb(180, 255, 0, 2);
            }

            if (!IsNeedPremissesType&&rTxtBoxCountOrMeters.Text == string.Empty)
            {
                valid = false;
                lblLocation.ForeColor = Color.FromArgb(180, 255, 0, 2);
            }

            if (!addressControl.ValidatorAddressCtrl())
                valid = false;
            

            if (!valid)
            {
                MessageBox.Show("Деякі поля не можуть бути пустими!", "Заповніть всі поля!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return valid;
            }

            DefaultColorLabels();
            return valid;
        }

        /// <summary>
        /// Відновлення кольору надпису за замповченням()
        /// </summary>
        private void DefaultColorLabels()
        {
            rLblName.ForeColor = Color.Black;
            lblLocation.ForeColor = Color.Black;
            addressControl.DefaultColorLabels();
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
