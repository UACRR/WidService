using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign;
using ipsFormsDesign.Data;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary.Extensions;
using IpsViewComponentLibrary.InternalControlsModel;
using IpsViewComponentLibrary.Properties;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.ConsumerControls.Places
{
    public partial class ConsumerPlacesControl : UserControl
    {
        private const string AddFromFile = "Додати з файлу";
        private const string DeletePlaceQuestion = "Ви дійсно хочете видалити обрану бізнес-точку?";

        private readonly AnketaDictionaties _dictionaties;

        private ObservableListSource<ClnBusinessPlace> _clnBusinessPlaces;
        private int _placeIdNegativeCounter = default(int);

        private int CustomerId = default(int);

        protected bool IsDesignMode => DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime;
        
        // конструктор
        public ConsumerPlacesControl()
        {
            InitializeComponent();
            if (!IsDesignMode)
                _dictionaties = IpsGlobal.AnketaDictionaties;

            InitializeDropDownButtons();
        }

        /// <summary>
        /// Створити список випадаючих кнопок з довідника для бізнес-точок
        /// </summary>
        private void InitializeDropDownButtons()
        {
            ddBtnAddPlace.Items.Clear();
            if (_dictionaties != null)
                foreach (var typePlace in _dictionaties.typePlace)
                {
                    var item = new RadMenuItem(typePlace.Name, typePlace);
                    item.Click += Item_Click;
                    ddBtnAddPlace.Items.Add(item);
                }
            var fromFile = new RadMenuItem(AddFromFile, null);
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
            bsPlacesForAgreement.DataSource = PlacesForAgreement.Convert(_clnBusinessPlaces);
            bsPlacesForAgreement.ResetBindings(false);
            CustomerId = customer.CustId;
        }

        // Додавання нового майданчика (click on drop down btn)
        private void Item_Click(object sender, EventArgs e)
        {
            var objTag = sender as RadMenuItem;
            if(!(objTag?.Tag is TypePlace typePlace)) return;

            var tempPlace = new ClnBusinessPlace
            {
                // TODO: переробити костиль з ID
                PlaceId = --_placeIdNegativeCounter,
                CustId = CustomerId,
                PlCode = typePlace.CodeI, //код типу закладу,
                PlaceCountry = "804",
                //FreeEntry = typePlace.CodeI != 4, // безкоштовний/платний вхід
                FreeEntry = null,
                PlCodeNavigation = typePlace, //тип закладу,
                ClnPlaceHoll = typePlace.IsHoll ?? false ? new ObservableListSource<ClnPlaceHoll>() : new ObservableListSource<ClnPlaceHoll> { new ClnPlaceHoll() }
            };

            OpenCreatePlaceDetailForm(tempPlace);
        }

        /// <summary>
        /// Відкрити форму [СТВОРЕННЯ] бізнес-точки
        /// </summary>
        /// <param name="businessPlace"></param>
        private void OpenCreatePlaceDetailForm(ClnBusinessPlace businessPlace)
        {
            var placeDetailForm = new PlaceDetailForm(businessPlace);
            if (placeDetailForm.ShowDialog() == DialogResult.OK)
            {
                _clnBusinessPlaces.Add(businessPlace);
                bsPlacesForAgreement.DataSource = PlacesForAgreement.Convert(_clnBusinessPlaces);
                bsPlacesForAgreement.ResetBindings(false);
            }
        }

        // Додавання нового майданчика з файлу XLS, XLSX
        private void AddPlacesFromFile_Click(object sender, EventArgs e)
        {
            // TODO: реалізувати додавання майданчиків з файлу
        }

        // * * * РЕДАГУВАННЯ бізнес-точки
        private void btnEdit_Click(object sender, EventArgs e)
        {
            OpenEditPlaceDetailForm();
        }

        // * * * РЕДАГУВАННЯ бізнес-точки
        private void gvPlaces_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            OpenEditPlaceDetailForm();
        }

        /// <summary>
        /// Відкрити форму [РЕДАГУВАННЯ] бізнес-точки
        /// </summary>
        private void OpenEditPlaceDetailForm()
        {
            if (!(gvPlaces.CurrentRow?.DataBoundItem is ClnBusinessPlace row))
                return;
            var place = _clnBusinessPlaces.SingleOrDefault(rec => rec.PlaceId == row.PlaceId);
            // створення допоміжного об'єкта (binding зберігає зміни в будь-якому випадку) б-т . . .
            var tempPlace = new ClnBusinessPlace
            {
                ClnPlaceHoll = new ObservableListSource<ClnPlaceHoll>
                {
                    new ClnPlaceHoll()
                }
            };
            // . . . та синхронізація
            SyncClnBusinessPlace(tempPlace, place);

            var placeDetailForm = new PlaceDetailForm(tempPlace);
            if (placeDetailForm.ShowDialog() == DialogResult.OK)
            {
                SyncClnBusinessPlace(place, tempPlace);
                bsPlacesForAgreement.DataSource = PlacesForAgreement.Convert(_clnBusinessPlaces);
                bsPlacesForAgreement.ResetBindings(false);
            }
        }

        /// <summary>
        /// Синхронізація об'єктів бізнес-точки з одним холом (приміщенням)
        /// </summary>
        /// <param name="destination"></param>
        /// <param name="source"></param>
        private void SyncClnBusinessPlace(ClnBusinessPlace destination, ClnBusinessPlace source)
        {
            destination.SetFields(source);
            var typePlace = _dictionaties.typePlace.SingleOrDefault(rec => rec.CodeI == source.PlCode);

            if (typePlace?.IsHoll ?? false)
            {
                destination.ClnPlaceHoll.Clear();
                foreach (var placeHoll in source.ClnPlaceHoll)
                {
                    var place = new ClnPlaceHoll();
                    place.SetFields(placeHoll);
                    destination.ClnPlaceHoll.Add(place);
                }
            }
            else if (destination.ClnPlaceHoll.Count == 1)
                destination.ClnPlaceHoll.SingleOrDefault().SetFields(source.ClnPlaceHoll.SingleOrDefault());
        }

        //  * * * ВИДАЛЕННЯ МАЙДАНЧИКА
        private void btnDeletePlace_Click(object sender, EventArgs e)
        {
            if (!(gvPlaces.CurrentRow?.DataBoundItem is ClnBusinessPlace row))
                return;

            if (MessageShow.ConfirmAction(DeletePlaceQuestion) == DialogResult.Yes)
            {
                var removePlace = _clnBusinessPlaces.SingleOrDefault(rec => rec.PlaceId == row.PlaceId);
                _clnBusinessPlaces.Remove(removePlace);
                bsPlacesForAgreement.DataSource = PlacesForAgreement.Convert(_clnBusinessPlaces);
                bsPlacesForAgreement.ResetBindings(false);
            }
        }

    }
}
