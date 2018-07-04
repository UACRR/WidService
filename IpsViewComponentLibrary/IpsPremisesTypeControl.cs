using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsAnketaClient;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;

namespace IpsViewComponentLibrary
{
    public partial class IpsPremisesTypeControl : UserControl
    {
        //TODO REFACTOR CODE! видалти непотрібні класи, генерації
        private TypeOfPremises _typeOfPremises;

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
        

        public IpsPremisesTypeControl()
        {
            InitializeComponent();
        }

        public IpsPremisesTypeControl(TypeOfPremises typeOfPremises)
        {
            InitializeComponent();
            _typeOfPremises = typeOfPremises;
            SetGridType(typeOfPremises);
        }

        /// <summary>
        /// ДІЇ КНОПКИ [ДОДАТИ ПРИМІЩЕННЯ]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rBtnAddPremises_Click(object sender, EventArgs e)
        {
            AddPremisesForm addPremisesFormForm = new AddPremisesForm(new ClnPlaceHoll(), _typeOfPremises, TypeOfFormPremisesInitialization.CreateNew);
            addPremisesFormForm.StartPosition = FormStartPosition.CenterScreen;
            addPremisesFormForm.OnNeedUpdateDataGrid += PremisesForm_OnNeedUpdateDataGrid;
            addPremisesFormForm.OnSaveNewClnPlaceHoll += AddPremisesFormForm_OnSaveNewClnPlaceHoll;
            addPremisesFormForm.ShowDialog();
            addPremisesFormForm.OnSaveNewClnPlaceHoll -= AddPremisesFormForm_OnSaveNewClnPlaceHoll;
            addPremisesFormForm.OnNeedUpdateDataGrid -= PremisesForm_OnNeedUpdateDataGrid;
            GC.Collect();
        }

        //додає нове приміщення
        private void AddPremisesFormForm_OnSaveNewClnPlaceHoll(ClnPlaceHoll clnPlaceHoll)
        {
            //TODO якщо новий заклад
            if(_place == null)
                _place = new ClnBusinessPlace();
            if(_place.ClnPlaceHoll == null)
                _place.ClnPlaceHoll = new ObservableListSource<ClnPlaceHoll>();
            _place.ClnPlaceHoll.Add(clnPlaceHoll);
        }

        /// <summary>
        /// Джерело даних для зал майданчиків
        /// </summary>
        /// <param name="sourceData"></param>
        /// <param name="place">Заклади</param>
        public void SetDataSource(ClnBusinessPlace place)
        {
            _place = place;

            var placeList = place.ClnPlaceHoll.list;
            
            rGridViewPremises.DataSource = placeList;

        }


        public void SetGridType(TypeOfPremises type)
        {
            switch (type)
            {
                case TypeOfPremises.Meters:
                {
                    rGridViewPremises.Columns["HollNum"].IsVisible = false;
                    rGridViewPremises.Columns["SqHoll"].IsVisible = true;
                }
                    break;

                case TypeOfPremises.Number:
                {
                    rGridViewPremises.Columns["SqHoll"].IsVisible = false;
                    rGridViewPremises.Columns["HollNum"].IsVisible = true;
                }
                    break;
            }
        }

        /// <summary>
        /// ДІЇ КНОПКИ [РЕДАГУВАТИ ПРИМІЩЕННЯ]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rBtnEditPremises_Click(object sender, EventArgs e)
        {
            if(rGridViewPremises.Rows.Count == 0) return;

            var editItem = rGridViewPremises.CurrentRow.DataBoundItem as ClnPlaceHoll;
            AddPremisesForm editForm = new AddPremisesForm(editItem, _typeOfPremises, TypeOfFormPremisesInitialization.Edit);
            editForm.StartPosition = FormStartPosition.CenterScreen;
            editForm.OnNeedUpdateDataGrid += PremisesForm_OnNeedUpdateDataGrid;
            editForm.ShowDialog();
            editForm.OnNeedUpdateDataGrid -= PremisesForm_OnNeedUpdateDataGrid;
            GC.Collect();
        }

        //оновлення даних на грід
        private void PremisesForm_OnNeedUpdateDataGrid(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        /// <summary>
        /// ДІЇ КНОПКИ [ВИДАЛЕННЯ ПРИМІЩЕННЯ]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radBtnDeletePremises_Click(object sender, EventArgs e)
        {
            if (rGridViewPremises.Rows.Count == 0) return;

            var deleteItem = rGridViewPremises.CurrentRow.DataBoundItem as ClnPlaceHoll;
            var place = rGridViewPremises.DataSource as ObservableListSource<ClnPlaceHoll>;
            place?.Remove(deleteItem);
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
