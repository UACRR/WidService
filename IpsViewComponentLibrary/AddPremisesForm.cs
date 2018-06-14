using ipsFormsDesign.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace ipsAnketaClient
{
    public partial class AddPremisesForm : Telerik.WinControls.UI.RadForm
    {
        private List<ClnPlaceHoll> _data;
        private int _idEditItem;
        private int _idPlace;
        private byte typePremises;
        private bool _isEdit = false;
        private string _stringId;

        public delegate void SaveDataForUpdate();

        public delegate void SaveDataForInsert();

        public event SaveDataForUpdate OnUpdateData;
        public event SaveDataForInsert OnInsertData;

        public AddPremisesForm()
        {
            InitializeComponent();
            //_data = new List<ClnPlaceHoll>();
        }

        public AddPremisesForm(List<ClnPlaceHoll> data, int placeId)
        {
            InitializeComponent();
            _data = data;
            _idPlace = placeId;
        }

        public AddPremisesForm(List<ClnPlaceHoll> data, int id, int placeId, string stringId = null)
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

        public void SetTypePremises(byte type)
        {
            if(type!=0)
            switch (type)
            {
                case 1:
                {
                    lblMetrsPlaceTxt.Text = "Метраж";
                    typePremises = 1;
                }break;

                case 2:
                {
                    lblMetrsPlaceTxt.Text = "Кількість місць";
                    typePremises = 2;
                }break;
            }
        }

        private void rBtnAdd_Click(object sender, EventArgs e)
        {
            if (Validator())
            {
                if (_isEdit)
                {
                    DataForUpdate();
                    OnUpdateData?.Invoke();
                    
                }
                else // inserted
                {
                    //DataFotInsert();
                    OnInsertData?.Invoke();
                    
                }
                //if (MessageBox.Show("Дані додано!","",MessageBoxButtons.OK, MessageBoxIcon.Asterisk) == DialogResult.OK)
                    Close();
            }
        }

        private void rBtnCancel_Click(object sender, EventArgs e)
        {
            Close();
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

        private void SetEditData()
        {
            if(_idEditItem != 0)
            {
                    rtxtBoxTypePremisses.Text = _data.Where(idItem => idItem.HollId == _idEditItem).Select(item =>item.HollName).SingleOrDefault();
                var numeric = _data.Where(idItem => idItem.HollId == _idEditItem).Select(item => item.HollNum).SingleOrDefault();
                if(numeric != 0)
                    rtxtBoxMetersPlaces.Text = _data.Where(idItem=>idItem.HollId == _idEditItem).Select(item=>item.HollNum).SingleOrDefault().ToString();
                else
                    rtxtBoxMetersPlaces.Text = _data.Where(idItem => idItem.HollId == _idEditItem).Select(item => item.SqHoll).SingleOrDefault().ToString();
            }
            else
            {
                SetEditDataZeroId(_stringId);
            }

        }

        private void SetEditDataZeroId(string hollname)
        {
            if (hollname == null) return;
            
            var edItem = _data.SingleOrDefault(item => item.HollName == hollname);
            
            rtxtBoxTypePremisses.Text = edItem?.HollName;
            var holl = edItem?.HollNum;
            var places = edItem?.SqHoll;
            if (holl != null && holl != 0)
                rtxtBoxMetersPlaces.Text = holl.ToString();
            else if (places != null && places != 0)
                rtxtBoxMetersPlaces.Text = places.ToString();
        }

        public List<ClnPlaceHoll> DataFotInsert()
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
                _data = new List<ClnPlaceHoll>
                {
                    data
                };
            
            return _data;
        }

        public List<ClnPlaceHoll> DataForUpdate()
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
    }
}
