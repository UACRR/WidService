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
        private readonly Size _defaultValueSize = new Size(96,20);
        private TypeInstitution _typeInstitution = TypeInstitution.NonExistentInstitution;
        private ExistencePlaces _existencePlaces;
        private MeasurementOfPremises _measurementOfPremises = MeasurementOfPremises.Area;
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

        /// <summary>
        /// Встановити випадаючі кнопки
        /// </summary>
        private void SetMenuItems()
        {
            rDropDownBtnAddInst.Items.Clear();
            foreach (var typePlace in _dic.typePlace )
            {

                RadMenuItem item = new RadMenuItem( typePlace.Name, typePlace );
                item.Click += Item_Click;
                rDropDownBtnAddInst.Items.Add(item);
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
            _measurementOfPremises = typePlace.ParamType == 1 ? MeasurementOfPremises.Area 
                                   : typePlace.ParamType == 2 ? MeasurementOfPremises.Number
                                   : typePlace.ParamType == 3 ? MeasurementOfPremises.Other
                                   : MeasurementOfPremises.Empty;

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
            rDropDownBtnAddInst.Enabled = false;
            rGridViewInstitution.Enabled = false;
            rBtnEditInst.Enabled = false;
            //конструювання типу додавання приміщень: заклад з холами / заклад з single холом
            switch (_existencePlaces)
            {
                case ExistencePlaces.SinglePlace:
                {
                    txtPlaceValue.Visible = true;
                    lblLocation.Visible = true;
                    lblLocation.Text = _measurementOfPremises == MeasurementOfPremises.Area ? "Площа"
                                     : _measurementOfPremises == MeasurementOfPremises.Number ? "Кількість місць"
                                     : _measurementOfPremises == MeasurementOfPremises.Other ? "Інше"
                                     : string.Empty;
                    if(_measurementOfPremises == MeasurementOfPremises.Other)
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

            _premisesType = new IpsPremisesTypeControl(_measurementOfPremises);
            
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
            rDropDownBtnAddInst.Enabled = true;
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
            rGridViewInstitution.Enabled = true;
            rBtnEditInst.Enabled = true;
            btnDeletePlace.Enabled = true;
            _newPlace = new ObservableListSource<ClnPlaceHoll>();

            if(_data?.Client?.ClnBusinessPlace?.Count != 0)
                SetGridDataSource(_data?.Client?.ClnBusinessPlace, _dic );

            txtPlaceValue.Size = _defaultValueSize;
            _typeInstitution = TypeInstitution.NonExistentInstitution;
            _measurementOfPremises = MeasurementOfPremises.Area;
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

            if (_existencePlaces == ExistencePlaces.SinglePlace && txtPlaceValue.Text == string.Empty)
            {
                valid = false;
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

                _measurementOfPremises = cln.PlCodeNavigation.ParamType == 1 ? MeasurementOfPremises.Area
                                       : cln.PlCodeNavigation.ParamType == 2 ? MeasurementOfPremises.Number 
                                       : cln.PlCodeNavigation.ParamType == 3 ? MeasurementOfPremises.Other
                                       : MeasurementOfPremises.Empty;
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

                    switch (_measurementOfPremises)
                    {
                        case MeasurementOfPremises.Area:
                        {
                            txtPlaceValue.Text = businessPlace?.ClnPlaceHoll?.SingleOrDefault()?.ValuePlace;
                            lblLocation.Text = "Площа";
                        }
                            break;

                        case MeasurementOfPremises.Number:
                        {
                            txtPlaceValue.Text = businessPlace?.ClnPlaceHoll?.SingleOrDefault()?.ValuePlace;
                            lblLocation.Text = "Кількість місць";
                        }
                            break;

                        case MeasurementOfPremises.Other:
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

                _clnBusinessPlace.PlaceName = txtPlaceName.Text;
                _clnBusinessPlace.PlaceRegion = addressControl.RegionCode;
                _clnBusinessPlace.PlaceCity = addressControl.TownName;
                _clnBusinessPlace.PlaceAddress = addressControl.StreetName;
                TrySetSinglePlaceValues(_clnBusinessPlace);

                _data.Client.ClnBusinessPlace.Add(_clnBusinessPlace);
            }
            else if (_typeInstitution == TypeInstitution.ExistingInstitution) // існуючий заклад
            {
                if (rGridViewInstitution.CurrentRow.DataBoundItem is ClnBusinessPlace item)
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
                    switch (_measurementOfPremises)
                    {
                        case MeasurementOfPremises.Area:
                            place.ValuePlace = txtPlaceValue.Text;
                            break;
                        case MeasurementOfPremises.Number:
                            place.ValuePlace = txtPlaceValue.Text;
                            break;
                        case MeasurementOfPremises.Other:
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
