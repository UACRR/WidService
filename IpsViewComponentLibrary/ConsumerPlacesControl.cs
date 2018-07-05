using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using IpsViewComponentLibrary;
using Telerik.WinControls.UI;
using ipsFormsDesign.Model;
using ipsFormsDesign.Interfaces;

namespace ipsAnketaClient
{
    public partial class ConsumerPlacesControl : UserControl
    {
        #region FIELDS

        private TypeInstitution _typeInstitution = TypeInstitution.NonExistentInstitution;
        private ExistencePlaces _existencePlaces;
        private TypeOfPremises _typeOfPremises = TypeOfPremises.Number;
        private ClnBusinessPlace _clnBusinessPlace;
        private Customer _data;
        private ObservableListSource<ClnPlaceHoll> _newPlace;
        private IpsPremisesTypeControl _premisesType;
        private TypePlace _typePlace;
        private AnketaDictionaties _dic;

        #endregion

        public delegate void EnabledChangeWhenEdit();
        public event EnabledChangeWhenEdit OnEnabledChangeWhenEditOrAddPremises;

        public ConsumerPlacesControl()
        {
            InitializeComponent();
        }

        #region ALL METHODS
        // * * * PUBLICS

        /// <summary>
        /// Встановити джерело даних для Grid
        /// </summary>
        /// <param name="data"></param>
        public void SetGridDataSource(object dataSource, AnketaDictionaties dic )
        {
            _dic = dic;
            if (dataSource!=null)
            {
                rGridViewInstitution.DataSource = new List<ClnBusinessPlace>
                {
                    new ClnBusinessPlace()
                };
                rGridViewInstitution.DataSource = dataSource;
            }
            else
            {
                rGridViewInstitution.DataSource = new List<ClnBusinessPlace>();
            }

            rGridViewInstitution.Update();
            rGridViewInstitution.MasterTemplate.Refresh();
            rGridViewInstitution.Refresh();
            SetMenuItems();
        }

        private void SetMenuItems()
        {
            rDropDownBtnAddInst.Items.Clear();
            foreach (var typePlace in _dic.typePlace )
            {

                RadMenuItem item = new RadMenuItem( typePlace.Name );
                item.Click += Item_Click;
                rDropDownBtnAddInst.Items.Add(item);
            }
        }

        private void Item_Click(object sender, EventArgs e)
        {
            //
            
        }

        /// <summary>
        /// Встановити дані для контрола
        /// </summary>
        /// <param name="Data"></param>
        public void SetData(Customer Data)
        {
            if(Data != null)
                _data = Data;
        } 

        // * * * PRIVATES

        /// <summary>
        /// Створення контрола з грідом та додаванням нового типу приміщення
        /// </summary>
        private void InitializePremiseslComponent()
        {
            rTxtBoxCountOrMeters.Visible = false;
            lblLocation.Visible = false;
            lblLocation.Text = string.Empty;

            _premisesType = new IpsPremisesTypeControl(_typeOfPremises);
            
            _premisesType.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);
            _premisesType.Location = new Point(10, 155); 
            _premisesType.Width = addressControl.Width;

            // додати новий заклад
            if (_typeInstitution == TypeInstitution.NonExistentInstitution)
            {
                CreateNewPlace();

                if(_clnBusinessPlace != null)
                    _premisesType.SetDataSource(_clnBusinessPlace);
            }

            rPanelAdd.ClientSize = new Size(rPanelAdd.Width, rPanelAdd.Height + 230);//   + 240
            rPanelAdd.Controls.Add(_premisesType);
        }

        /// <summary>
        /// Створення нового закладу
        /// </summary>
        private void CreateNewPlace()
        {
            if (_typePlace.CodeI == 1 || _typePlace.CodeI == 2)
                _existencePlaces = ExistencePlaces.ManyPlaces;
            else
                _existencePlaces = ExistencePlaces.SinglePlace;

            _clnBusinessPlace = new ClnBusinessPlace
            {
                //PlaceId = 100, //id елемента, null?
                CustId = _data.Client.CustId,
                PlCode = _typePlace.CodeI, //код типу закладу,
                PlaceCountry = "804",
                FreeEntry = _typePlace.CodeI != 4, // безкоштовний/платний вхід
                PlCodeNavigation = _typePlace, //тип закладу,
                ClnPlaceHoll = _existencePlaces == ExistencePlaces.ManyPlaces ? _newPlace : new ObservableListSource<ClnPlaceHoll>{ new ClnPlaceHoll() }
            };
        }

        /// <summary>
        /// Встановлення початкового стану екрану та очищення даних
        /// </summary>
        private void SetDefaultState()
        {
            rPanelAdd.Visible = false;
            rDropDownBtnAddInst.Enabled = true;
            rTxtBoxNameInst.Clear();
            rTxtBoxTypeInst.Clear();
            rTxtBoxCountOrMeters.Clear();
            addressControl.SetEmpty();

            if (_premisesType != null)
            {
                rPanelAdd.Controls.Remove(_premisesType);
                rPanelAdd.ClientSize = new Size(rPanelAdd.Width, rPanelAdd.Height - 230);//   - 240
                rPanelAdd.Refresh();
                _premisesType.Dispose();
                _premisesType = null;
                GC.Collect();
            }
            rLblName.ForeColor = Color.Black;
            lblLocation.ForeColor = Color.Black;
            addressControl.DefaultColorLabels();
            rGridViewInstitution.Enabled = true;
            rBtnEditInst.Enabled = true;
            btnDeletePlace.Enabled = true;
            _newPlace = new ObservableListSource<ClnPlaceHoll>();

            if(_data?.Client?.ClnBusinessPlace?.Count != 0)
                SetGridDataSource(_data?.Client?.ClnBusinessPlace, _dic );

            _typeInstitution = TypeInstitution.NonExistentInstitution;
            _typeOfPremises = TypeOfPremises.Number;
        }

        /// <summary>
        /// Перевірка на правильність полів
        /// </summary>
        /// <returns></returns>
        private bool Validator()
        {
            bool valid = true;
            bool isInt = true;
            if (rTxtBoxNameInst.Text == string.Empty)
            {
                valid = false;
                rLblName.ForeColor = Color.FromArgb(180, 255, 0, 2);
            }
            else
                rLblName.ForeColor = Color.Black;

            if (_existencePlaces == ExistencePlaces.SinglePlace && rTxtBoxCountOrMeters.Text == string.Empty)
            {
                valid = false;
                lblLocation.ForeColor = Color.FromArgb(180, 255, 0, 2);
            }
            else if (_existencePlaces == ExistencePlaces.SinglePlace && rTxtBoxCountOrMeters.Text != string.Empty && !Int32.TryParse(rTxtBoxCountOrMeters.Text, out int parse))
            {
                isInt = false;
                lblLocation.ForeColor = Color.FromArgb(180, 255, 0, 2);
            }
            else
                lblLocation.ForeColor = Color.Black;

            if (!addressControl.ValidatorAddressCtrl())
                valid = false;

            if (!valid)
            {
                MessageBox.Show("Деякі поля не можуть бути пустими!", "Заповніть всі поля!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (valid && !isInt)
            {
                MessageBox.Show("Деякі поля повинні бути числовими!", "Заповніть всі поля правильно!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            rLblName.ForeColor = Color.Black;
            lblLocation.ForeColor = Color.Black;
            addressControl.DefaultColorLabels();
            return true;
        }

        #endregion


#region ALL BUTTONS

        #region ДОДАТИ ЗАКЛАД

        //  ГОТЕЛЬ
        private void rBtnAddHotel_Click(object sender, EventArgs e)
        {
            _typePlace = new TypePlace
                {
                    CodeI = 1,
                    Name = "Готель",
                    ClnBusinessPlace = null
                };
            _newPlace = new ObservableListSource<ClnPlaceHoll>();
            rTxtBoxTypeInst.Text = rBtnAddHotel.Text;
            rPanelAdd.Visible = true;
            rDropDownBtnAddInst.Enabled = false;
            rGridViewInstitution.Enabled = false;
            rBtnEditInst.Enabled = false;
            _typeOfPremises = TypeOfPremises.Meters;
            InitializePremiseslComponent();
            _premisesType.SetGridType(_typeOfPremises);
        }
        
        //  РЕСТОРАН
        private void rBtnAddRestaurant_Click(object sender, EventArgs e)
        {
            _typePlace = new TypePlace
            {
                CodeI = 2,
                Name = "Ресторан",
                ClnBusinessPlace = null
            };
            _newPlace = new ObservableListSource<ClnPlaceHoll>();
            rTxtBoxTypeInst.Text = rBtnAddRestaurant.Text;
            rPanelAdd.Visible = true;
            rDropDownBtnAddInst.Enabled = false;
            rBtnEditInst.Enabled = false;
            rGridViewInstitution.Enabled = false;
            _typeOfPremises = TypeOfPremises.Number;
            InitializePremiseslComponent();
            _premisesType.SetGridType(_typeOfPremises);
        }
        
        //  НІЧНИЙ КЛУБ
        private void rBtnAddNightClub_Click(object sender, EventArgs e)
        {
            _typePlace = new TypePlace
            {
                CodeI = 4,
                Name = "Нічні клуби/Платний вхід",
                ClnBusinessPlace = null,
            };
            rTxtBoxTypeInst.Text = rBtnAddNightClub.Text;
            rPanelAdd.Visible = true;
            rTxtBoxCountOrMeters.Visible = true;
            lblLocation.Visible = true;
            lblLocation.Text = "Кількість місць";
            rDropDownBtnAddInst.Enabled = false;
            rBtnEditInst.Enabled = false;
            rGridViewInstitution.Enabled = false;
            rPanelAdd.ClientSize = new Size(rPanelAdd.Width, 215);// без додаткового гріда
            CreateNewPlace();
        }
        
        //  НІЧНИЙ КЛУБ БЕЗКОШТОВНИЙ ВХІД
        private void rBtnAddNightClubFree_Click(object sender, EventArgs e)
        {
            _typePlace = new TypePlace
            {
                CodeI = 3,
                Name = "Нічні клуби/Безкоштовний вхід",
                ClnBusinessPlace = null
            };
            rTxtBoxTypeInst.Text = rBtnAddNightClubFree.Text;
            rPanelAdd.Visible = true;
            rTxtBoxCountOrMeters.Visible = true;
            lblLocation.Visible = true;
            lblLocation.Text = "Метраж";
            _typeOfPremises = TypeOfPremises.Meters;
            rDropDownBtnAddInst.Enabled = false;
            rBtnEditInst.Enabled = false;
            rGridViewInstitution.Enabled = false;
            rPanelAdd.ClientSize = new Size(rPanelAdd.Width, 215);// без додаткового гріда
            CreateNewPlace();
        }
        
        //  КАФЕ-БАР-ЇДАЛЬНЯ
        private void rBtnAddCaffeOrBar_Click(object sender, EventArgs e)
        {
            _typePlace = new TypePlace
            {
                CodeI = 5,
                Name = "Кафе/Бар - Їдальня",
                ClnBusinessPlace = null
            };
            rTxtBoxTypeInst.Text = rBtnAddCaffeOrBar.Text;
            rPanelAdd.Visible = true;
            lblLocation.Visible = true;
            rTxtBoxCountOrMeters.Visible = true;
            lblLocation.Text = "Кількість місць";
            rDropDownBtnAddInst.Enabled = false;
            rBtnEditInst.Enabled = false;
            rGridViewInstitution.Enabled = false;
            rPanelAdd.ClientSize = new Size(rPanelAdd.Width, 215);// без додаткового гріда
            CreateNewPlace();
        }
        
        //  ТЕАТР-ОПЕРА
        private void rBtnAddTheaterOrOpera_Click(object sender, EventArgs e)
        {
            _typePlace = new TypePlace
            {
                CodeI = 6,
                Name = "Театр/Оперета",
                ClnBusinessPlace = null
            };
            rTxtBoxTypeInst.Text = rBtnAddTheaterOrOpera.Text;
            rPanelAdd.Visible = true;
            lblLocation.Visible = true;
            rTxtBoxCountOrMeters.Visible = true;
            lblLocation.Text = "Кількість місць";
            rDropDownBtnAddInst.Enabled = false;
            rBtnEditInst.Enabled = false;
            rGridViewInstitution.Enabled = false;
            rPanelAdd.ClientSize = new Size(rPanelAdd.Width, 215);// без додаткового гріда
            CreateNewPlace();
        }
        
        #endregion


        /// <summary>
        /// ДІЇ КНОПКИ [РЕДАГУВАТИ ЗАКЛАД]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rBtnEditInst_Click(object sender, EventArgs e)
        {
            if(rGridViewInstitution.RowCount == 0)
                return;
            _typeInstitution = TypeInstitution.ExistingInstitution;
            if(rGridViewInstitution.CurrentRow.DataBoundItem is ClnBusinessPlace cln)
            {
                if (cln.PlCodeNavigation.CodeI == 1 || cln.PlCodeNavigation.CodeI == 2)
                    _existencePlaces = ExistencePlaces.ManyPlaces;
                else
                    _existencePlaces = ExistencePlaces.SinglePlace;

                _typeOfPremises = cln.PlCode == 1 || cln.PlCode == 4 ? TypeOfPremises.Meters : TypeOfPremises.Number;
            }
            
            ClnBusinessPlace localBusinessPlace = new ClnBusinessPlace();
            switch (rGridViewInstitution.CurrentRow.DataBoundItem)
            {
                case ClnBusinessPlace businessPlace when (businessPlace.PlCodeNavigation.CodeI == 1 || businessPlace.PlCodeNavigation.CodeI == 2):
                {
                    localBusinessPlace = businessPlace;
                    InitializePremiseslComponent();
                    _premisesType.SetDataSource(localBusinessPlace);
                } break;

                case ClnBusinessPlace businessPlace when (businessPlace.PlCodeNavigation.CodeI > 2):
                {
                    localBusinessPlace = businessPlace;
                    var countOrMeters = businessPlace.ClnPlaceHoll.SingleOrDefault();
                    var count = countOrMeters?.HollNum;
                    rTxtBoxCountOrMeters.Text = (countOrMeters?.HollNum ?? countOrMeters?.SqHoll)?.ToString();
                    lblLocation.Text = count != null ? "Кількість місць" : "Метраж";
                    rTxtBoxCountOrMeters.Visible = true;
                    lblLocation.Visible = true;
                } break;
            }

            rTxtBoxNameInst.Text = localBusinessPlace.PlaceName;
            rTxtBoxTypeInst.Text = localBusinessPlace.PlCodeNavigation.Name;

            addressControl.SetAddressForEditCustomer(localBusinessPlace);

            rPanelAdd.Visible = true;
            rDropDownBtnAddInst.Enabled = false;
            rGridViewInstitution.Enabled = false;
            rBtnEditInst.Enabled = false;
            btnDeletePlace.Enabled = false;

            OnEnabledChangeWhenEditOrAddPremises?.Invoke();
        }

        /// <summary>
        /// ДІЇ КНОПКИ [ЗБЕРЕГТИ]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rBtnSave_Click(object sender, EventArgs e)
        {
            addressControl.SetValues();

            if (!Validator())
                return;

            if (_typeInstitution == TypeInstitution.NonExistentInstitution) // новий заклад
            {
                //додати створений заклад

                _clnBusinessPlace.PlaceName = rTxtBoxNameInst.Text;
                _clnBusinessPlace.PlaceRegion = addressControl.RegionCode;
                _clnBusinessPlace.PlaceCity = addressControl.TownName;
                _clnBusinessPlace.PlaceAddress = addressControl.StreetName;

                if (_existencePlaces == ExistencePlaces.SinglePlace)
                {
                    var place = _clnBusinessPlace.ClnPlaceHoll.SingleOrDefault();
                    if (place != null)
                    {
                        place.HollNum = _typeOfPremises == TypeOfPremises.Number
                            ? new int?(Convert.ToInt32(rTxtBoxCountOrMeters.Text))
                            : null;
                        place.SqHoll = _typeOfPremises == TypeOfPremises.Meters
                            ? new int?(Convert.ToInt32(rTxtBoxCountOrMeters.Text))
                            : null;
                    }
                }

                _data.Client.ClnBusinessPlace.Add(_clnBusinessPlace);
            }
            else if (_typeInstitution == TypeInstitution.ExistingInstitution) // існуючий заклад
            {
                if (rGridViewInstitution.CurrentRow.DataBoundItem is ClnBusinessPlace item)
                {
                    item.PlaceName = rTxtBoxNameInst.Text;
                    item.PlaceRegion = addressControl.RegionCode;
                    item.PlaceCity = addressControl.TownName;
                    item.PlaceAddress = addressControl.StreetName;
                    if (_existencePlaces == ExistencePlaces.SinglePlace)
                    {
                        var place = item.ClnPlaceHoll.SingleOrDefault();
                        if (place != null)
                        {
                            place.HollNum = _typeOfPremises == TypeOfPremises.Number
                                ? new int?(Convert.ToInt32(rTxtBoxCountOrMeters.Text))
                                : null;
                            place.SqHoll = _typeOfPremises == TypeOfPremises.Meters
                                ? new int?(Convert.ToInt32(rTxtBoxCountOrMeters.Text))
                                : null;
                        }
                    }
                }
            }
            SetDefaultState();
        }

        /// <summary>
        /// ДІЇ КНОПКИ [ВИДАЛЕННЯ] обраного закладу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeletePlace_Click(object sender, EventArgs e)
        {
            if(rGridViewInstitution.Rows.Count == 0)
                return;
            if (MessageBox.Show("Ви дійсно хочете видалити обраний заклад?", "Підтвердження",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            {
                var deleteItem = rGridViewInstitution.CurrentRow.DataBoundItem as ClnBusinessPlace;
                _data.Client.ClnBusinessPlace.Remove(deleteItem);
            }
        }

        /// <summary>
        /// ДІЇ КНОПКИ [СКАСУВАТИ]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rBtnCancel_Click(object sender, EventArgs e)
        {
            SetDefaultState();
        }

#endregion
    }
}
