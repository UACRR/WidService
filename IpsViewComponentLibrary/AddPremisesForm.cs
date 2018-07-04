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
        private int _idEditItem;
        private int _idPlace;
        private byte typePremises;
        private bool _isEdit = false;
        private string _stringId;

        public delegate void SaveDataForUpdate();
        public delegate void SaveDataForInsert();

        public event SaveDataForUpdate OnUpdateData;
        public event SaveDataForInsert OnInsertData;

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
        /// <param name="clnPlaceHoll">Дані майданчика</param>
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

            if(_data != null)
            foreach (var clnPlaceHoll in _data)
            {
                if (clnPlaceHoll.HollName == rtxtBoxTypePremisses.Text && clnPlaceHoll.HollId == 0)
                    count++;
            }

            if (count >= 2 && _isEdit)
            {
                MessageBox.Show("Зала з таким ім'ям вже існує!", "Повтор найменування!", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                lblTypePremisses.ForeColor = Color.Crimson;
                return false;
            }
            else if (count >= 1 && !_isEdit)
            {
                MessageBox.Show("Зала з таким ім'ям вже існує!", "Повтор найменування!", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                lblTypePremisses.ForeColor = Color.Crimson;
                return false;
            }



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




        public ObservableListSource<ClnPlaceHoll> DataFotInsert()
        {
            var data = new ClnPlaceHoll
            {
                //HollId = автоінкримент
                HollName = rtxtBoxTypePremisses.Text,
                HollNum = typePremises == 2 ? Convert.ToInt32(rtxtBoxMetersPlaces.Text) : 0,
                SqHoll = typePremises == 1 ? Convert.ToInt32(rtxtBoxMetersPlaces.Text) : 0,
                PlaceId = _idPlace
            };
            if (_data!=null)
                _data.Add(data);
            else
                _data = new ObservableListSource<ClnPlaceHoll>
                {
                    data
                };
            
            return _data;
        }

        public ObservableListSource<ClnPlaceHoll> DataForUpdate()
        {
            ClnPlaceHoll editRow = null;
            if (_idEditItem != 0)
                editRow = _data.SingleOrDefault(id => id.HollId == _idEditItem);
            
            if (_stringId != null)
                editRow = _data.SingleOrDefault(idStr => idStr.HollName == _stringId);
            

            if (editRow != null)
            {
                editRow.HollName = rtxtBoxTypePremisses.Text;
                editRow.HollNum = typePremises == 2 ? Convert.ToInt32(rtxtBoxMetersPlaces.Text) : 0;
                editRow.SqHoll = typePremises == 1 ? Convert.ToInt32(rtxtBoxMetersPlaces.Text) : 0;
            }
            return _data;
        }

        public void SetTypePremises(byte type)
        {
            if (type != 0)
                switch (type)
                {
                    case 1:
                    {
                        lblMetrsPlaceTxt.Text = "Метраж";
                        typePremises = 1;
                    }
                        break;

                    case 2:
                    {
                        lblMetrsPlaceTxt.Text = "Кількість місць";
                        typePremises = 2;
                    }
                        break;
                }
        }

        public AddPremisesForm(ObservableListSource<ClnPlaceHoll> data, int placeId)
        {
            InitializeComponent();
            _data = data;
            _idPlace = placeId;
        }

        public AddPremisesForm(ObservableListSource<ClnPlaceHoll> data, int id, int placeId, string stringId = null)
        {
            InitializeComponent();
            _data = data;
            _isEdit = true;
            _idEditItem = id;
            _idPlace = placeId;
            rBtnAdd.Text = "Зберегти";
            this.Text = "Редагувати приміщення закладу";
            _stringId = stringId;
            try
            {
                SetEditData();
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, e.HResult.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
