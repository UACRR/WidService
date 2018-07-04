using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;

namespace IpsViewComponentLibrary
{
    public partial class IpsPremisesTypeControl : UserControl
    {
        //TODO REFACTOR CODE! видалти непотрібні класи, генерації

        private Customer dataTemp;
        private ClnBusinessPlace _place;
        private int _idSelectedRow;
        private string _idSelectedRowString;

        //id рядка приміщення закладу
        public int IdSelectedRow
        {
            get => _idSelectedRow;
        }
        public string IdSelectedRowStr
        {
            get => _idSelectedRowString;
        }

        public delegate void AddPremises();
        public delegate void DeletePremises(ClnPlaceHoll deleteHoll);
        public delegate void EditPremises();

        public event AddPremises OnBtnAddPremisesClick;
        public event DeletePremises OnBtnDeletePremisesClick;
        public event EditPremises OnBtnEditPremisesClick;

        public IpsPremisesTypeControl()
        {
            InitializeComponent();
        }
        
        private void rBtnAddPremises_Click(object sender, EventArgs e)
        {
            OnBtnAddPremisesClick?.Invoke();
        }


        public void SetDataSource(Customer sourceData, int id, byte prem = 0)
        {
            dataTemp = sourceData;
            List<PremisesInstitution> data = new List<PremisesInstitution>();
            PremisesInstitution temp;
            var places = sourceData.Client.ClnBusinessPlace.Where(itemId => itemId.PlaceId == id).Select(item => item.ClnPlaceHoll).SingleOrDefault();
            if (places != null)
                foreach (var item in places)
                {
                    temp = new PremisesInstitution
                    {
                        IdItem = item.HollId,
                        TypePremisesName = item.HollName,
                        CountPlace = item.HollNum,
                        Meterage = item.SqHoll
                    };
                    data.Add(temp);
                }

            byte? type = (byte?) sourceData.Client.ClnBusinessPlace.SingleOrDefault(idItem => idItem.PlaceId == id)?.PlCode;
            SetGridType(type ?? prem);
                if(prem == 0)
            //rGridViewPremises.DataSource = data;
            rGridViewPremises.DataSource = places;

        }

        /// <summary>
        /// Джерело даних для зал майданчиків
        /// </summary>
        /// <param name="sourceData"></param>
        /// <param name="place"></param>
        public void SetDataSource(Customer sourceData, ClnBusinessPlace place)
        {
            dataTemp = sourceData;
            _place = place;

            var placeList = place.ClnPlaceHoll.list;

            byte? type = (byte?)place?.PlCode;
            SetGridType(type ?? 0);
            rGridViewPremises.DataSource = placeList;

        }

        public void SetDataSource(ObservableListSource<ClnPlaceHoll> sourceData)
        {
            List<PremisesInstitution> data = new List<PremisesInstitution>();
            PremisesInstitution temp;
            foreach (var item in sourceData)
            {
                temp = new PremisesInstitution
                {
                    IdItem = item.HollId,
                    TypePremisesName = item.HollName,
                    CountPlace = item.HollNum,
                    Meterage = item.SqHoll
                };
                data.Add(temp);
            }
            rGridViewPremises.DataSource = sourceData;
            //rGridViewPremises.DataSource = data;
        }


        /// <summary>
        /// Вибір типу гріда: 1 - готель, 2 - ресторан
        /// </summary>
        /// <param name="type"></param>
        public void SetGridType(byte type)
        {
            switch (type)
            {
                case 1:
                {
                    rGridViewPremises.Columns["HollNum"].IsVisible = false;
                    rGridViewPremises.Columns["SqHoll"].IsVisible = true;
                }break;

                case 2:
                {
                    rGridViewPremises.Columns["SqHoll"].IsVisible = false;
                    rGridViewPremises.Columns["HollNum"].IsVisible = true;
                }break;
            }
        }

        private void rBtnEditPremises_Click(object sender, EventArgs e)
        {
                if(rGridViewPremises.Rows.Count == 0) return;
            
            if (rGridViewPremises.CurrentRow.Cells[0].Value != null)
                _idSelectedRow = Convert.ToInt32(rGridViewPremises.CurrentRow.Cells["HollId"].Value);
            if(_idSelectedRow == 0)
               _idSelectedRowString = rGridViewPremises.CurrentRow.Cells["HollName"].Value.ToString();
            OnBtnEditPremisesClick?.Invoke();
        }

        private void radBtnDeletePremises_Click(object sender, EventArgs e)
        {
            if (rGridViewPremises.Rows.Count == 0) return;

            var deleteItem = rGridViewPremises.CurrentRow.DataBoundItem as ClnPlaceHoll;
            var place = rGridViewPremises.DataSource as ObservableListSource<ClnPlaceHoll>;
            place.Remove(deleteItem);
            //OnBtnDeletePremisesClick?.Invoke(deleteItem);
        }

        public ObservableListSource<ClnPlaceHoll> GetData(int idRowInst)
        {
            ObservableListSource<ClnPlaceHoll> list = new ObservableListSource<ClnPlaceHoll>();
            if (idRowInst != 0)
                
            if (dataTemp != null && dataTemp.Client.ClnBusinessPlace.Select(item => item.ClnPlaceHoll).Any())
            {
                var v = dataTemp.Client.ClnBusinessPlace.Where(id=>id.PlaceId==idRowInst).Select(item => item.ClnPlaceHoll).SingleOrDefault();//
                if (v != null)
                    foreach (var clnPlaceHoll in v)
                        list.Add(clnPlaceHoll);
                    
                return list;
            }
            return new ObservableListSource<ClnPlaceHoll>();
        }

        public void RefreshGrid()
        {
            rGridViewPremises.Update();
            rGridViewPremises.MasterTemplate.Refresh();
            rGridViewPremises.Refresh();
            
        }
    }

    internal class PremisesInstitution
    {
        public int? IdItem { get; set; }
        public string TypePremisesName { get; set; }
        public int? CountPlace { get; set; }
        public decimal? Meterage { get; set; }
    }
}
