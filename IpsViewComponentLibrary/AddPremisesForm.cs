using ipsFormsDesign.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ipsFormsDesign.Interfaces;
using IpsViewComponentLibrary;
using Telerik.WinControls;

namespace ipsAnketaClient
{
    public partial class AddPremisesForm : Telerik.WinControls.UI.RadForm
    {

        private ClnPlaceHoll _clnPlaceHoll;
        private PremisesFormTypeInitialization _premisesFormTypeFromInitialization = PremisesFormTypeInitialization.CreateNew;
        private MeasurementOfPremises _measurementPremises;

        public event EventHandler OnNeedUpdateDataGrid;

        public delegate void SaveNewClnPlaceHoll(ClnPlaceHoll clnPlaceHoll);
        public event SaveNewClnPlaceHoll OnSaveNewClnPlaceHoll;
        //***
        private ObservableListSource<ClnPlaceHoll> _data;
        private bool _isEdit = false;
        

        /// <summary>
        /// Default constructor do not work
        /// </summary>
        public AddPremisesForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Конструктор для редагування або додавання приміщення закладу
        /// </summary>
        /// <param name="clnPlaceHoll">Дані майданчиків</param>
        /// <param name="measurementPremises">Тип вимірювання майданчика</param>
        /// <param name="premisesFormTypeFrom">Тип ініціалізованої форми приміщення закладу</param>
        public AddPremisesForm(ClnPlaceHoll clnPlaceHoll, MeasurementOfPremises measurementPremises, PremisesFormTypeInitialization premisesFormTypeFrom)
        {
            InitializeComponent();
            _clnPlaceHoll = clnPlaceHoll;
            _measurementPremises = measurementPremises;
            _premisesFormTypeFromInitialization = premisesFormTypeFrom;
            if (premisesFormTypeFrom == PremisesFormTypeInitialization.Edit)
            {
                rBtnAdd.Text = "Зберегти";
                this.Text = "Редагувати приміщення закладу";
            }
            SetTypePremises();
            SetEditData();
            
        }

        /// <summary>
        ///  ДІЇ КНОПКИ [ДОДАТИ ПРИМІЩЕННЯ]/[ЗБЕРЕГТИ]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rBtnAdd_Click(object sender, EventArgs e)
        {
            if (Validator())
            {
                switch (_premisesFormTypeFromInitialization)
                {
                    case PremisesFormTypeInitialization.CreateNew:
                    {
                        OnSaveNewClnPlaceHoll?.Invoke(GetClnPlaceHoll());
                    }
                        break;
                    case PremisesFormTypeInitialization.Edit:
                    {
                        GetClnPlaceHoll();
                    }
                        break;
                }

                OnNeedUpdateDataGrid?.Invoke(sender,e);
                Close();
            }
        }

        /// <summary>
        /// ДІЇ КНОПКИ [СКАСУВАТИ]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rBtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Встановити тип приміщення: з метражом або кількістю місць
        /// </summary>
        private void SetTypePremises()
        {
            lblTitlePlace.Text = _measurementPremises == MeasurementOfPremises.Area ? "Площа"
                : _measurementPremises == MeasurementOfPremises.Number ? "Кількість місць" : string.Empty;
        }

        /// <summary>
        /// Перевірка правильності введення
        /// </summary>
        /// <returns></returns>
        private bool Validator()
        {
            byte count = 0;
            bool isNumber = true;
            bool isNotEmpty = true;
            Int32 tryparse;
            if (txtPlaceName.Text == string.Empty)
            {
                isNotEmpty = false;
                lblTypePremisses.ForeColor = Color.Crimson;
            }
            else
                lblTypePremisses.ForeColor = Color.Black;

            if (txtPlaceValue.Text == string.Empty)
            {
                isNotEmpty = false;
                lblTitlePlace.ForeColor = Color.Crimson;
            }
            else
                lblTitlePlace.ForeColor = Color.Black;


            if (!Int32.TryParse(txtPlaceValue.Text, out tryparse))
            {
                lblTitlePlace.ForeColor = Color.Crimson;
                isNumber = false;
            }
            else
                lblTitlePlace.ForeColor = Color.Black;

            if (isNotEmpty&&isNumber)
                return true;
            else if(!isNotEmpty)
            {
                MessageBox.Show("Деякі поля не можуть бути пустими!", "Заповніть всі поля!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if(!isNumber)
            {
                MessageBox.Show("Деякі поля повинні бути числовими!", "Заповніть всі поля правильно!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return false;
        }

        /// <summary>
        /// Встановити дані для редагування
        /// </summary>
        private void SetEditData()
        {
            txtPlaceName.Text = _clnPlaceHoll.HollName;
            txtPlaceValue.Text = _measurementPremises == MeasurementOfPremises.Other ? _clnPlaceHoll.ValueAdd : _clnPlaceHoll.ValuePlace;
        }

        /// <summary>
        /// Отримати редановані/створені дані
        /// </summary>
        /// <returns>Приміщення закладу</returns>
        public ClnPlaceHoll GetClnPlaceHoll()
        {
            _clnPlaceHoll.HollName = txtPlaceName.Text;

            switch (_measurementPremises)
            {
                case MeasurementOfPremises.Other:
                    _clnPlaceHoll.ValueAdd = txtPlaceValue.Text;
                    break;

                case MeasurementOfPremises.Area:
                    _clnPlaceHoll.ValuePlace = txtPlaceValue.Text;
                    break;

                case MeasurementOfPremises.Number:
                    _clnPlaceHoll.ValuePlace = txtPlaceValue.Text;
                    break;
            }

            return _clnPlaceHoll;
        }
    }
}
