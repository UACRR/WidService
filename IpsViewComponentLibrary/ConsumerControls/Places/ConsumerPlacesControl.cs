using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using IpsViewComponentLibrary;
using Telerik.WinControls.UI;
using ipsFormsDesign.Model;
using ipsFormsDesign.Interfaces;
using IpsViewComponentLibrary.ConsumerControls.Places;

namespace ipsAnketaClient
{
    public partial class ConsumerPlacesControl : UserControl
    {
        private SinglePlaceParameterControl _singlePlaceParameterControl;
        private MultiplePlaceParameterControl _multiplePlaceParameterControl;

        protected bool IsDesignMode => DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime;

        #region FIELDS
        private readonly Size _defaultValueSize = new Size(96,20);
        private TypeInstitution _typeInstitution = TypeInstitution.NonExistentInstitution;
        private ExistencePlaces _existencePlaces;
        private MeasurementOfPlaces _measurementOfPlaces = MeasurementOfPlaces.Area;
        private ClnBusinessPlace _clnBusinessPlace;
        private Customer _data;
        private ObservableListSource<ClnPlaceHoll> _newPlace;
        private IpsPremisesTypeControl _premisesType;
        private TypePlace _typePlace;
        private AnketaDictionaties _dictionaties;

        #endregion

        public delegate void EnabledChangeWhenEdit();
        public event EnabledChangeWhenEdit OnEnabledChangeWhenEditOrAddPremises;

        public ConsumerPlacesControl()
        {
            InitializeComponent();

            if (!IsDesignMode)
                _dictionaties = IpsGlobal.AnketaDictionaties;

            // ініціалізація контрола з єдиним холом
            _singlePlaceParameterControl = new SinglePlaceParameterControl
            {
                DictionaryRegion = _dictionaties.region,
                DictionaryTypePlace = _dictionaties.typePlace,
            };

            // ініціалізація контрола з декількома холами
            _multiplePlaceParameterControl = new MultiplePlaceParameterControl
            {
                DictionaryRegion = _dictionaties.region,
                DictionaryTypePlace = _dictionaties.typePlace
            };
        }

        #region ALL METHODS
        // * * * PUBLICS

        /// <summary>
        /// Встановити джерело даних для Grid
        /// </summary>
        /// <param name="data"></param>
        public void SetGridDataSource(object dataSource, AnketaDictionaties dic )
        {
            _dictionaties = dic;
            if (dataSource!=null)
            {
                gvPlaces.DataSource = new List<ClnBusinessPlace>
                {
                    new ClnBusinessPlace()
                };
                gvPlaces.DataSource = dataSource;
            }
            else
            {
                gvPlaces.DataSource = new List<ClnBusinessPlace>();
            }

            gvPlaces.Update();
            gvPlaces.MasterTemplate.Refresh();
            gvPlaces.Refresh();
            SetMenuItems();
        }

        /// <summary>
        /// Встановити випадаючі кнопки
        /// </summary>
        private void SetMenuItems()
        {
            ddBtnAddPlace.Items.Clear();
            foreach (var typePlace in _dictionaties.typePlace )
            {
                var item = new RadMenuItem( typePlace.Name, typePlace );
                item.Click += Item_Click;
                ddBtnAddPlace.Items.Add(item);
            }
        }

        /// <summary>
        /// Винекнення події додавання нового закладу (click on drop down btn)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Item_Click(object sender, EventArgs e)
        {
            var objTag = sender as RadMenuItem;
            if(!(objTag?.Tag is TypePlace typePlace)) return;

            //тип вимірювання майданчика
            _measurementOfPlaces = typePlace.ParamType == 1 ? MeasurementOfPlaces.Area 
                                   : typePlace.ParamType == 2 ? MeasurementOfPlaces.Number
                                   : typePlace.ParamType == 3 ? MeasurementOfPlaces.Other
                                   : MeasurementOfPlaces.Empty;

            //багато чи один майданчик
            _existencePlaces = typePlace.IsHoll != null && (bool)typePlace.IsHoll ? ExistencePlaces.ManyPlaces : ExistencePlaces.SinglePlace;
            //if (typePlace.CodeI == 1 || typePlace.CodeI == 2)
            //    _existencePlaces = ExistencePlaces.ManyPlaces;
            //else
            //    _existencePlaces = ExistencePlaces.SinglePlace;

            //ініціалізація об'єктів
            _typePlace = typePlace;
            _newPlace = new ObservableListSource<ClnPlaceHoll>();
            txtPlaceType.Text = typePlace.Name;
            rPanelAdd.Visible = true;
            ddBtnAddPlace.Enabled = false;
            gvPlaces.Enabled = false;
            btnEdit.Enabled = false;
            //конструювання типу додавання приміщень: заклад з холами / заклад з single холом
            switch (_existencePlaces)
            {
                case ExistencePlaces.SinglePlace:
                {
                    txtPlaceValue.Visible = true;
                    lblLocation.Visible = true;
                    lblLocation.Text = _measurementOfPlaces == MeasurementOfPlaces.Area ? "Площа"
                                     : _measurementOfPlaces == MeasurementOfPlaces.Number ? "Кількість місць"
                                     : _measurementOfPlaces == MeasurementOfPlaces.Other ? "Інше"
                                     : string.Empty;
                    if(_measurementOfPlaces == MeasurementOfPlaces.Other)
                        txtPlaceValue.Size = txtPlaceValue.MaximumSize;
                    rPanelAdd.ClientSize = new Size(rPanelAdd.Width, 215);// без додаткового гріда
                    CreateNewPlace();
                }
                    break;

                case ExistencePlaces.ManyPlaces:
                {
                    InitializePremiseslComponent();
                }
                    break;
            }
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
            txtPlaceValue.Visible = false;
            lblLocation.Visible = false;
            lblLocation.Text = string.Empty;

            _premisesType = new IpsPremisesTypeControl(_measurementOfPlaces);
            
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
            ddBtnAddPlace.Enabled = true;
            txtPlaceName.Clear();
            txtPlaceType.Clear();
            txtPlaceValue.Clear();
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
            gvPlaces.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            _newPlace = new ObservableListSource<ClnPlaceHoll>();

            if(_data?.Client?.ClnBusinessPlace?.Count != 0)
                SetGridDataSource(_data?.Client?.ClnBusinessPlace, _dictionaties );

            txtPlaceValue.Size = _defaultValueSize;
            _typeInstitution = TypeInstitution.NonExistentInstitution;
            _measurementOfPlaces = MeasurementOfPlaces.Area;
        }

        /// <summary>
        /// Перевірка на правильність полів
        /// </summary>
        /// <returns></returns>
        private bool Validator()
        {
            bool valid = true;
            if (txtPlaceName.Text == string.Empty)
            {
                valid = false;
                rLblName.ForeColor = Color.FromArgb(180, 255, 0, 2);
            }
            else
                rLblName.ForeColor = Color.Black;

            //if (_existencePlaces == ExistencePlaces.SinglePlace && txtPlaceValue.Text == string.Empty)
            //{
            //    valid = false;
            //    lblLocation.ForeColor = Color.FromArgb(180, 255, 0, 2);
            //}
            //else
            //    lblLocation.ForeColor = Color.Black;

            if (!addressControl.ValidatorAddressCtrl())
                valid = false;

            if (!valid)
            {
                MessageBox.Show("Деякі поля не можуть бути пустими!", "Заповніть всі поля!",
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

        /// <summary>
        /// ДІЇ КНОПКИ [РЕДАГУВАТИ ЗАКЛАД]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(gvPlaces.RowCount == 0)
                return;
            _typeInstitution = TypeInstitution.ExistingInstitution;

            if(gvPlaces.CurrentRow.DataBoundItem is ClnBusinessPlace cln)
            {
                if (cln.PlCodeNavigation.CodeI == 1 || cln.PlCodeNavigation.CodeI == 2)
                    _existencePlaces = ExistencePlaces.ManyPlaces;
                else
                    _existencePlaces = ExistencePlaces.SinglePlace;

                _measurementOfPlaces = cln.PlCodeNavigation.ParamType == 1 ? MeasurementOfPlaces.Area
                                       : cln.PlCodeNavigation.ParamType == 2 ? MeasurementOfPlaces.Number 
                                       : cln.PlCodeNavigation.ParamType == 3 ? MeasurementOfPlaces.Other
                                       : MeasurementOfPlaces.Empty;
            }
            
            ClnBusinessPlace localBusinessPlace = new ClnBusinessPlace();

            switch (gvPlaces.CurrentRow.DataBoundItem)
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

                    switch (_measurementOfPlaces)
                    {
                        case MeasurementOfPlaces.Area:
                        {
                            txtPlaceValue.Text = businessPlace?.ClnPlaceHoll?.SingleOrDefault()?.ValuePlace;
                            lblLocation.Text = "Площа";
                        }
                            break;

                        case MeasurementOfPlaces.Number:
                        {
                            txtPlaceValue.Text = businessPlace?.ClnPlaceHoll?.SingleOrDefault()?.ValuePlace;
                            lblLocation.Text = "Кількість місць";
                        }
                            break;

                        case MeasurementOfPlaces.Other:
                        {
                            txtPlaceValue.Text = businessPlace?.ClnPlaceHoll?.SingleOrDefault()?.ValueAdd;
                            txtPlaceValue.Size = txtPlaceValue.MaximumSize;
                            lblLocation.Text = "Інше";
                        }
                            break;
                    }
                    txtPlaceValue.Visible = true;
                    lblLocation.Visible = true;
                } break;
            }

            txtPlaceName.Text = localBusinessPlace.PlaceName;
            txtPlaceType.Text = localBusinessPlace.PlCodeNavigation.Name;

            addressControl.SetAddressForEditCustomer(localBusinessPlace);

            rPanelAdd.Visible = true;
            ddBtnAddPlace.Enabled = false;
            gvPlaces.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;

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

                _clnBusinessPlace.PlaceName = txtPlaceName.Text;
                _clnBusinessPlace.PlaceRegion = addressControl.RegionCode;
                _clnBusinessPlace.PlaceCity = addressControl.TownName;
                _clnBusinessPlace.PlaceAddress = addressControl.StreetName;
                TrySetSinglePlaceValues(_clnBusinessPlace);

                _data.Client.ClnBusinessPlace.Add(_clnBusinessPlace);
            }
            else if (_typeInstitution == TypeInstitution.ExistingInstitution) // існуючий заклад
            {
                if (gvPlaces.CurrentRow.DataBoundItem is ClnBusinessPlace item)
                {
                    item.PlaceName = txtPlaceName.Text;
                    item.PlaceRegion = addressControl.RegionCode;
                    item.PlaceCity = addressControl.TownName;
                    item.PlaceAddress = addressControl.StreetName;
                    TrySetSinglePlaceValues(item);
                }
            }
            SetDefaultState();
        }

        /// <summary>
        /// Присвоїти дані у випадку якщо майданчики не додаються
        /// </summary>
        /// <param name="itemPlace"></param>
        private void TrySetSinglePlaceValues(ClnBusinessPlace itemPlace)
        {
            if (_existencePlaces == ExistencePlaces.SinglePlace)
            {
                var place = itemPlace.ClnPlaceHoll.SingleOrDefault();
                if (place != null)
                {
                    switch (_measurementOfPlaces)
                    {
                        case MeasurementOfPlaces.Area:
                            place.ValuePlace = txtPlaceValue.Text;
                            break;
                        case MeasurementOfPlaces.Number:
                            place.ValuePlace = txtPlaceValue.Text;
                            break;
                        case MeasurementOfPlaces.Other:
                            place.ValueAdd = txtPlaceValue.Text;
                            break;
                    }
                    place.HollName = txtPlaceName.Text;
                }
            }
        }

        /// <summary>
        /// ДІЇ КНОПКИ [ВИДАЛЕННЯ] обраного закладу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeletePlace_Click(object sender, EventArgs e)
        {
            if(gvPlaces.Rows.Count == 0)
                return;
            if (MessageBox.Show("Ви дійсно хочете видалити обраний заклад?", "Підтвердження",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            {
                var deleteItem = gvPlaces.CurrentRow.DataBoundItem as ClnBusinessPlace;
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

        // при зміні рядка грід 
        private void rGridViewInstitution_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            var visible = gvPlaces.RowCount != 0;
            btnEdit.Enabled = visible;
            btnDelete.Enabled = visible;
        }
    }
}
