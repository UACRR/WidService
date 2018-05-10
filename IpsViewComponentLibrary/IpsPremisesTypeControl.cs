using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsmedserviceapp.Model;

namespace IpsViewComponentLibrary
{
    public partial class IpsPremisesTypeControl : UserControl
    {
        private Customer dataTemp;
        private int _idSelectedRow;

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

            rGridViewPremises.DataSource = data;
        }

        private void rBtnEditPremises_Click(object sender, EventArgs e)
        {
            OnBtnEditPremisesClick?.Invoke();
        }

        private void radBtnDeletePremises_Click(object sender, EventArgs e)
        {
            if (rGridViewPremises.CurrentRow.Cells[0].Value != null)
                _idSelectedRow = Convert.ToInt32(rGridViewPremises.CurrentRow.Cells["IdItem"].Value);
            OnBtnDeletePremisesClick?.Invoke();
        }

        public List<ClnPlaceHoll> GetData()
        {
            List<ClnPlaceHoll> list = new List<ClnPlaceHoll>();
            var v = dataTemp.Client.ClnBusinessPlace.Select(item => item.ClnPlaceHoll).SingleOrDefault();
            list = (List<ClnPlaceHoll>)v;

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
