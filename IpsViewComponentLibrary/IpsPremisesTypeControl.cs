using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Model;

namespace IpsViewComponentLibrary
{
    public partial class IpsPremisesTypeControl : UserControl
    {
        private Customer dataTemp;
        private int _idSelectedRow;

        //id рядка приміщення закладу
        public int IdSelectedRow
        {
            get => _idSelectedRow;
        }

        public delegate void AddPremises();
        public delegate void DeletePremises();
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


        public void SetDataSource(Customer sourceData, int id)
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

            SetGridType(sourceData.Client.ClnBusinessPlace.SingleOrDefault(idItem => idItem.PlaceId == id).PlCode == 1
                ? (byte) 1
                : (byte) 2);

            rGridViewPremises.DataSource = data;
        }

        public void SetDataSource(List<ClnPlaceHoll> sourceData)
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
            rGridViewPremises.DataSource = data;
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
                    rGridViewPremises.Columns["CountPlace"].IsVisible = false;
                    rGridViewPremises.Columns["Meterage"].IsVisible = true;
                }break;

                case 2:
                {
                    rGridViewPremises.Columns["Meterage"].IsVisible = false;
                    rGridViewPremises.Columns["CountPlace"].IsVisible = true;
                }break;
            }
        }

        private void rBtnEditPremises_Click(object sender, EventArgs e)
        {
                if(rGridViewPremises.Rows.Count == 0) return;
            
            if (rGridViewPremises.CurrentRow.Cells[0].Value != null)
                _idSelectedRow = Convert.ToInt32(rGridViewPremises.CurrentRow.Cells["IdItem"].Value);
            OnBtnEditPremisesClick?.Invoke();
        }

        private void radBtnDeletePremises_Click(object sender, EventArgs e)
        {
                if (rGridViewPremises.Rows.Count == 0) return;

            if (rGridViewPremises.CurrentRow.Cells[0].Value != null)
                _idSelectedRow = Convert.ToInt32(rGridViewPremises.CurrentRow.Cells["IdItem"].Value);
            OnBtnDeletePremisesClick?.Invoke();
        }

        public List<ClnPlaceHoll> GetData(int idRowInst)
        {
            List<ClnPlaceHoll> list = new List<ClnPlaceHoll>();
            if (dataTemp != null && dataTemp.Client.ClnBusinessPlace.Select(item => item.ClnPlaceHoll).Any())
            {
                var v = dataTemp.Client.ClnBusinessPlace.Where(id=>id.PlaceId==idRowInst).Select(item => item.ClnPlaceHoll).SingleOrDefault();//
                
                if (v != null)
                    foreach (var item in v)
                    {
                        list.Add(item);
                    }
            }
            return list;
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
