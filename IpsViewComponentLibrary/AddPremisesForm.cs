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
        private TypeOfFormPremisesInitialization _typeFromOfFormPremisesInitialization = TypeOfFormPremisesInitialization.CreateNew;
        private TypeOfPremises _typePremises;

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
        /// <param name="typePremises">Тип майданчика</param>
        /// <param name="typeFrom">Тип ініціалізованої форми приміщення закладу</param>
        public AddPremisesForm(ClnPlaceHoll clnPlaceHoll, TypeOfPremises typePremises, TypeOfFormPremisesInitialization typeFrom)
        {
            InitializeComponent();
            _clnPlaceHoll = clnPlaceHoll;
            _typePremises = typePremises;
            _typeFromOfFormPremisesInitialization = typeFrom;
            if (typeFrom == TypeOfFormPremisesInitialization.Edit)
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
                switch (_typeFromOfFormPremisesInitialization)
                {
                    case TypeOfFormPremisesInitialization.CreateNew:
                    {
                        OnSaveNewClnPlaceHoll?.Invoke(GetClnPlaceHoll());
                    }
                        break;
                    case TypeOfFormPremisesInitialization.Edit:
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
            lblMetrsPlaceTxt.Text = _typePremises == TypeOfPremises.Number ? "Кількість місць"
                : _typePremises == TypeOfPremises.Meters ? "Метраж" : string.Empty;
        }

        //TODO: тестувати валідатор / реконструювати
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
            if (rtxtBoxTypePremisses.Text == string.Empty)
            {
                isNotEmpty = false;
                lblTypePremisses.ForeColor = Color.Crimson;
            }
            else
                lblTypePremisses.ForeColor = Color.Black;

            if (rtxtBoxMetersPlaces.Text == string.Empty)
            {
                isNotEmpty = false;
                lblMetrsPlaceTxt.ForeColor = Color.Crimson;
            }
            else
                lblMetrsPlaceTxt.ForeColor = Color.Black;


            if (!Int32.TryParse(rtxtBoxMetersPlaces.Text, out tryparse))
            {
                lblMetrsPlaceTxt.ForeColor = Color.Crimson;
                isNumber = false;
            }
            else
                lblMetrsPlaceTxt.ForeColor = Color.Black;
            
            //if (count >= 2 && _isEdit)
            //{
            //    MessageBox.Show("Зала з таким ім'ям вже існує!", "Повтор найменування!", MessageBoxButtons.OK,
            //        MessageBoxIcon.Warning);
            //    lblTypePremisses.ForeColor = Color.Crimson;
            //    return false;
            //}
            //else if (count >= 1 && !_isEdit)
            //{
            //    MessageBox.Show("Зала з таким ім'ям вже існує!", "Повтор найменування!", MessageBoxButtons.OK,
            //        MessageBoxIcon.Warning);
            //    lblTypePremisses.ForeColor = Color.Crimson;
            //    return false;
            //}

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
            rtxtBoxTypePremisses.Text = _clnPlaceHoll.HollName;
            rtxtBoxMetersPlaces.Text = _typePremises == TypeOfPremises.Meters ? _clnPlaceHoll.SqHoll.ToString() 
                                     : _typePremises == TypeOfPremises.Number ? _clnPlaceHoll.HollNum.ToString()
                                     : string.Empty; //throw new Exception("Неможливо визначити тип приміщення!");
        }

        /// <summary>
        /// Отримати редановані/створені дані
        /// </summary>
        /// <returns>Приміщення закладу</returns>
        public ClnPlaceHoll GetClnPlaceHoll()
        {
            _clnPlaceHoll.HollName = rtxtBoxTypePremisses.Text;
            switch (_typePremises)
            {
                case TypeOfPremises.Meters:
                {
                    _clnPlaceHoll.SqHoll = Convert.ToInt32(rtxtBoxMetersPlaces.Text);
                    return _clnPlaceHoll;
                }
                case TypeOfPremises.Number:
                {
                    _clnPlaceHoll.HollNum = Convert.ToInt32(rtxtBoxMetersPlaces.Text);
                    return _clnPlaceHoll;
                }
            }
            return _clnPlaceHoll;
        }
    }
}
