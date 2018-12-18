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
        private readonly RadioPlaceParameterControl _radioPlaceParameterControl;

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
            if (!IsDesignMode)
            {
                _dictionaties = IpsGlobal.AnketaDictionaties;
            }

            panelHeader.PanelElement.PanelBorder.Visibility = ElementVisibility.Collapsed;
            panelParameter.PanelElement.PanelBorder.Visibility = ElementVisibility.Collapsed;

            // ініціалізація контрола з єдиним холом
            _singlePlaceParameterControl = new SinglePlaceParameterControl
            {
                Dock = DockStyle.Fill
            };
            if(_dictionaties != null)
            {
                _singlePlaceParameterControl.DictionaryRegion = _dictionaties.region;
                _singlePlaceParameterControl.DictionaryTypePlace = _dictionaties.typePlace;
            }
            _singlePlaceParameterControl.SaveChanges += Save_Click;
            _singlePlaceParameterControl.CancelChanges += Cancel_Click;

            // ініціалізація контрола з декількома холами
            _multiplePlaceParameterControl = new MultiplePlaceParameterControl
            {
                Dock = DockStyle.Fill
            };
            if (_dictionaties != null)
            {
                _multiplePlaceParameterControl.DictionaryRegion = _dictionaties.region;
                _multiplePlaceParameterControl.DictionaryTypePlace = _dictionaties.typePlace;
            }
            _multiplePlaceParameterControl.SaveChanges += Save_Click;
            _multiplePlaceParameterControl.CancelChanges += Cancel_Click;

            _radioPlaceParameterControl = new RadioPlaceParameterControl
            {
                Dock = DockStyle.Fill
            };
            if (_dictionaties != null)
            {
                _radioPlaceParameterControl.DictionaryTypePlace = _dictionaties.typePlace;
            }
            _radioPlaceParameterControl.SaveChanges += Save_Click;
            _radioPlaceParameterControl.CancelChanges += Cancel_Click;

            ddBtnAddPlace.Items.Clear();
            if(_dictionaties != null)
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


        /// <summary>
        /// Встановлення даних
        /// </summary>
        /// <param name="data"></param>
        /// <param name="customer"></param>
        public void SetData(Customer customer)
        {
            _clnBusinessPlaces = customer.Client.ClnBusinessPlace;
            gvPlaces.DataSource = _clnBusinessPlaces;
            if (CurentCustomerId != customer.CustId)
            {
                CurentCustomerId = customer.CustId;
                // переведення на початковий стан
            }
        }

        // Додавання нового майданчика (click on drop down btn)
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

        // перемикання панелі параметрів майданчика
        private void SetupParameterPanel(TypePlace typePlace)
        {
            // тип приміщення
            var existencePlaces = ExistencePlaces.None;
            if (typePlace.ParamType != 3)
                existencePlaces = typePlace.IsHoll != null && (bool) typePlace.IsHoll
                    ? ExistencePlaces.ManyPlaces
                    : ExistencePlaces.SinglePlace;
            else
                existencePlaces = ExistencePlaces.Radio;

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
                    case ExistencePlaces.Radio: // радіо
                        _placesControl = _radioPlaceParameterControl;
                        if (panelParameter.Controls.Count != 0)
                            panelParameter.Controls.Clear();
                        panelParameter.Controls.Add(_radioPlaceParameterControl);
                        break;
                }

                CurentType = existencePlaces;
            }

            if (typePlace.ParamType != null)
                _placesControl.PlaceType = (MeasurementOfPlaces)typePlace.ParamType;
        }

        // Додавання нового майданчика з файлу XLS, XLSX
        private void AddPlacesFromFile_Click(object sender, EventArgs e)
        {
            // TODO: реалізувати додавання майданчиків з файлу
        }

        // при зміні рядка грід 
        private void rGridViewInstitution_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            var visible = gvPlaces.RowCount != 0;
            btnEdit.Enabled = visible;
            btnDelete.Enabled = !IsEditMode && visible;

            // якщо вкл редагування 
            if (IsEditMode)
            {
                var item = e.CurrentRow.DataBoundItem as ClnBusinessPlace;
                var typePlace = _dictionaties.typePlace.SingleOrDefault(rec => rec.CodeI == item.PlCode);
                SetupParameterPanel(typePlace); // змінює тип форми за необхідністю
                _placesControl.BusinessPlaceDataSource = item; // binding
            }
        }


        #region * * * ALL BUTTONS * * *

        // * * * РЕДАГУВАННЯ МАЙДАНЧИКА
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


        //  * * * ВИДАЛЕННЯ МАЙДАНЧИКА
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

        // * * * ЗБЕРЕЖЕННЯ НОВОГО
        private void Save_Click(object sender, EventArgs e)
        {

            _clnBusinessPlaces.Add(_tempPlace);
            _placesControl.BusinessPlaceDataSource = null;
            _placesControl = null;
            if (panelParameter.Controls.Count != 0)
                panelParameter.Controls.Clear();

            _tempPlace = null;

            CurentType = ExistencePlaces.None;
            ddBtnAddPlace.Enabled = true;
            gvPlaces.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
        }

        // * * * СКАСУВАТИ СТВОРЕННЯ НОВОГО
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
