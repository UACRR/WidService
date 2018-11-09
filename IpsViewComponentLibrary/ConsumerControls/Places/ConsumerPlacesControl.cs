using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary.Properties;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.ConsumerControls.Places
{
    public partial class ConsumerPlacesControl : UserControl
    {
        private readonly AnketaDictionaties _dictionaties;
        private IPlacesControl _placesControl;
        private readonly SinglePlaceParameterControl _singlePlaceParameterControl;
        private readonly MultiplePlaceParameterControl _multiplePlaceParameterControl;

        private ObservableListSource<ClnBusinessPlace> _clnBusinessPlaces;
        private ClnBusinessPlace _tempPlace;

        // ReSharper disable once InconsistentNaming
        private int CurentCustomerId = default(int);
        // ReSharper disable once InconsistentNaming
        private ExistencePlaces CurentType = ExistencePlaces.None;

        protected bool IsDesignMode => DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime;
        public bool IsEditMode { get; private set; } = false;
        
        
        // конструктор
        public ConsumerPlacesControl()
        {
            InitializeComponent();
            panelHeader.PanelElement.PanelBorder.Visibility = ElementVisibility.Collapsed;
            panelParameter.PanelElement.PanelBorder.Visibility = ElementVisibility.Collapsed;


            if (!IsDesignMode)
                _dictionaties = IpsGlobal.AnketaDictionaties;

            // ініціалізація контрола з єдиним холом
            _singlePlaceParameterControl = new SinglePlaceParameterControl
            {
                DictionaryRegion = _dictionaties.region,
                DictionaryTypePlace = _dictionaties.typePlace,
                Dock = DockStyle.Fill
            };
            _singlePlaceParameterControl.SaveChanges += Save_Click;
            _singlePlaceParameterControl.CancelChanges += Cancel_Click;

            // ініціалізація контрола з декількома холами
            _multiplePlaceParameterControl = new MultiplePlaceParameterControl
            {
                DictionaryRegion = _dictionaties.region,
                DictionaryTypePlace = _dictionaties.typePlace,
                Dock = DockStyle.Fill
            };
            _multiplePlaceParameterControl.SaveChanges += Save_Click;
            _multiplePlaceParameterControl.CancelChanges += Cancel_Click;

            ddBtnAddPlace.Items.Clear();
            foreach (var typePlace in _dictionaties.typePlace)
            {
                var item = new RadMenuItem(typePlace.Name, typePlace);
                item.Click += Item_Click;
                ddBtnAddPlace.Items.Add(item);
            }
            var fromFile = new RadMenuItem("Додати з файлу", null);
            fromFile.Click += AddPlacesFromFile_Click; ;
            ddBtnAddPlace.Items.Add(fromFile);
        }


        #region ALL METHODS
        // * * * PUBLICS

        /// <summary>
        /// Встановлення даних
        /// </summary>
        /// <param name="data"></param>
        public void SetData(Customer customer)
        {
            if (!customer.Client.ClnBusinessPlace.Any())
            {
                gvPlaces.DataSource = typeof(ObservableListSource<ClnBusinessPlace>);
                _clnBusinessPlaces = null;
            }
            else
            {
                _clnBusinessPlaces = customer.Client.ClnBusinessPlace;
                gvPlaces.DataSource = _clnBusinessPlaces;
                if(CurentCustomerId != customer.CustId)
                {
                    CurentCustomerId = customer.CustId;
                    // переведення на початковий стан
                }
            }
        }

        /// <summary>
        /// Додавання нового закладу (click on drop down btn)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Item_Click(object sender, EventArgs e)
        {
            var objTag = sender as RadMenuItem;
            if(!(objTag?.Tag is TypePlace typePlace)) return;

            ddBtnAddPlace.Enabled = false;
            gvPlaces.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;


            SetupParameterPanel(typePlace);

            _tempPlace = new ClnBusinessPlace
            {
                CustId = CurentCustomerId,
                PlCode = typePlace.CodeI, //код типу закладу,
                PlaceCountry = "804",
                FreeEntry = typePlace.CodeI != 4, // безкоштовний/платний вхід
                PlCodeNavigation = typePlace, //тип закладу,
                ClnPlaceHoll = typePlace.IsHoll ?? false ? new ObservableListSource<ClnPlaceHoll>() : new ObservableListSource<ClnPlaceHoll> { new ClnPlaceHoll() }
            };

            _placesControl.ButtonsVisible = true;
            _placesControl.BusinessPlaceDataSource = _tempPlace;
        }

        private void SetupParameterPanel(TypePlace typePlace)
        {
            // тип приміщення
            var existencePlaces = typePlace.IsHoll != null && (bool)typePlace.IsHoll ? ExistencePlaces.ManyPlaces : ExistencePlaces.SinglePlace;
            
            if(existencePlaces != CurentType) // не перебудовувати якщо тип майданчика такий самий
            {
                switch (existencePlaces)
                {
                    case ExistencePlaces.SinglePlace: // форма з єдиним холом
                    {
                        _placesControl = _singlePlaceParameterControl;
                        if (panelParameter.Controls.Count != 0)
                            panelParameter.Controls.Clear();
                        panelParameter.Controls.Add(_singlePlaceParameterControl);
                    }
                        break;

                    case ExistencePlaces.ManyPlaces: // форма з декількома холами
                    {
                        _placesControl = _multiplePlaceParameterControl;
                        if (panelParameter.Controls.Count != 0)
                            panelParameter.Controls.Clear();
                        panelParameter.Controls.Add(_multiplePlaceParameterControl);
                    }
                        break;
                    case ExistencePlaces.Radio:
                        if (panelParameter.Controls.Count != 0)
                            panelParameter.Controls.Clear();
                        break;
                }

                CurentType = existencePlaces;
            }

            if (typePlace.ParamType != null)
                _placesControl.PlaceType = (MeasurementOfPlaces)typePlace.ParamType;
        }

        /// <summary>
        /// Додавання нового закладу з файлу XLS, XLSX
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddPlacesFromFile_Click(object sender, EventArgs e)
        {
            // TODO: реалізувати додавання майданчиків з файлу
        }

        // при зміні рядка грід 
        private void rGridViewInstitution_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            var visible = gvPlaces.RowCount != 0;
            btnEdit.Enabled = visible;
            btnDelete.Enabled = visible;

            // якщо вкл редагування 
            if (IsEditMode)
            {
                var item = e.CurrentRow.DataBoundItem as ClnBusinessPlace;
                var typePlace = _dictionaties.typePlace.SingleOrDefault(rec => rec.CodeI == item.PlCode);
                SetupParameterPanel(typePlace); // змінює тип форми за необхідністю
                _placesControl.BusinessPlaceDataSource = item; // binding
            }
        }

        
        #endregion


        #region * * * ALL BUTTONS * * *

        // редагування
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(gvPlaces.RowCount == 0) return;
            if (!(gvPlaces.CurrentRow.DataBoundItem is ClnBusinessPlace place)) return;

            IsEditMode = !IsEditMode;
            ddBtnAddPlace.Enabled = !IsEditMode;
            btnDelete.Enabled = !IsEditMode;

            ((RadButtonElement)btnEdit.GetChildAt(0)).Image = IsEditMode ? Resources.angle_double_up_solid : Resources.angle_double_down_solid;

            if (IsEditMode)
            {
                var typePlace = _dictionaties.typePlace.SingleOrDefault(rec => rec.CodeI == place.PlCode);
                SetupParameterPanel(typePlace);
                _placesControl.BusinessPlaceDataSource = place;
                _placesControl.ButtonsVisible = false;
            }
            else
            {
                _placesControl.BusinessPlaceDataSource = null;
                panelParameter.Controls.Clear();
                CurentType = ExistencePlaces.None;
            }
        }


        // [ВИДАЛЕННЯ] обраного закладу
        private void btnDeletePlace_Click(object sender, EventArgs e)
        {
            if(gvPlaces.Rows.Count == 0)
                return;
            if (MessageBox.Show("Ви дійсно хочете видалити обраний заклад?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var deleteItem = gvPlaces.CurrentRow.DataBoundItem as ClnBusinessPlace;
                _clnBusinessPlaces.Remove(deleteItem);
            }
        }

        // ДІЇ КНОПКИ [ЗБЕРЕГТИ]
        private void Save_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        // ДІЇ КНОПКИ [СКАСУВАТИ]
        private void Cancel_Click(object sender, EventArgs e)
        {
            _placesControl.BusinessPlaceDataSource = null;
            _placesControl = null;
            if (panelParameter.Controls.Count != 0)
                panelParameter.Controls.Clear();
            _tempPlace = null;

            ddBtnAddPlace.Enabled = true;
            gvPlaces.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;

            CurentType = ExistencePlaces.None;
            // встановити режим перегляду
        }
        
        #endregion
    }
}
