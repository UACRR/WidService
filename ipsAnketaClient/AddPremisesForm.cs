using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ipsmedserviceapp.Model;
using Telerik.WinControls;

namespace ipsAnketaClient
{
    public partial class AddPremisesForm : Telerik.WinControls.UI.RadForm
    {
        private List<ClnPlaceHoll> _data;
        private int _idEditItem;
        private int _idPlace;
        private bool _isEdit = false;

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

        public AddPremisesForm(List<ClnPlaceHoll> data, int id, int placeId)
        {
            InitializeComponent();
            _data = data;
            _isEdit = true;
            _idEditItem = id;
            _idPlace = placeId;
            rBtnAdd.Text = "Зберегти";
            this.Text = "Редагувати приміщення закладу";
            try
            {
                SetEditData();
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, e.HResult.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (MessageBox.Show("Дані додано!","",MessageBoxButtons.OK,MessageBoxIcon.Asterisk) == DialogResult.OK)
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

            if (rtxtBoxCountPlaces.Text == string.Empty)
            {
                isNotEmpty = false;
                lblCountPlaces.ForeColor = Color.Crimson;
            }
            else
                lblCountPlaces.ForeColor = Color.Black;


            if (rtxtBoxMeterage.Text == string.Empty)
            {
                isNotEmpty = false;
                lblMeterage.ForeColor = Color.Crimson;
            }
            else
                lblMeterage.ForeColor = Color.Black;


            if (!Int32.TryParse(rtxtBoxMeterage.Text, out tryparse))
            {
                lblMeterage.ForeColor = Color.Crimson;
                isNumber = false;
            }
            else
                lblMeterage.ForeColor = Color.Black;


            if (!Int32.TryParse(rtxtBoxCountPlaces.Text, out tryparse))
            {
                lblCountPlaces.ForeColor = Color.Crimson;
                isNumber = false;
            }
            else
                lblCountPlaces.ForeColor = Color.Black;



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
            rtxtBoxTypePremisses.Text = _data.Where(idItem => idItem.HollId == _idEditItem).Select(item =>item.HollName).SingleOrDefault();
            rtxtBoxMeterage.Text = _data.Where(idItem => idItem.HollId == _idEditItem).Select(item => item.SqHoll).SingleOrDefault().ToString();
            rtxtBoxCountPlaces.Text = _data.Where(idItem=>idItem.HollId == _idEditItem).Select(item=>item.HollNum).SingleOrDefault().ToString();
        }

        public List<ClnPlaceHoll> DataFotInsert()
        {
            var data = new ClnPlaceHoll
            {
                //HollId = автоінкримент
                HollName = rtxtBoxTypePremisses.Text,
                HollNum = Convert.ToInt32(rtxtBoxCountPlaces.Text),
                SqHoll = Convert.ToInt32(rtxtBoxMeterage.Text),
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
            var editRow = _data.SingleOrDefault(id => id.HollId == _idEditItem);
            if (editRow!=null)
            {
                editRow.HollName = rtxtBoxTypePremisses.Text;
                editRow.HollNum = Convert.ToInt32(rtxtBoxCountPlaces.Text);
                editRow.SqHoll = Convert.ToInt32(rtxtBoxMeterage.Text);
            }
            return _data;
        }
    }
}
