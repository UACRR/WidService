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
        private MeasurementOfPremises _measurementOfPremises;
        private ClnBusinessPlace _place;
        
        /// <summary>
        /// Default constructor do not work
        /// </summary>
        public IpsPremisesTypeControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Конструктор з ініціалізацією типу майданчика
        /// </summary>
        /// <param name="measurementOfPremises">Тип майданчика</param>
        public IpsPremisesTypeControl(MeasurementOfPremises measurementOfPremises)
        {
            InitializeComponent();
            _measurementOfPremises = measurementOfPremises;
            SetGridColumnHeaderText(measurementOfPremises);
        }

        /// <summary>
        /// ДІЇ КНОПКИ [ДОДАТИ ПРИМІЩЕННЯ]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rBtnAddPremises_Click(object sender, EventArgs e)
        {
            AddPremisesForm addPremisesFormForm = new AddPremisesForm(new ClnPlaceHoll(), _measurementOfPremises, PremisesFormTypeInitialization.CreateNew);
            addPremisesFormForm.StartPosition = FormStartPosition.CenterScreen;
            addPremisesFormForm.OnNeedUpdateDataGrid += PremisesForm_OnNeedUpdateDataGrid;
            addPremisesFormForm.OnSaveNewClnPlaceHoll += AddPremisesFormForm_OnSaveNewClnPlaceHoll;
            addPremisesFormForm.ShowDialog();
            addPremisesFormForm.OnSaveNewClnPlaceHoll -= AddPremisesFormForm_OnSaveNewClnPlaceHoll;
            addPremisesFormForm.OnNeedUpdateDataGrid -= PremisesForm_OnNeedUpdateDataGrid;
            GC.Collect();
        }

        //додавання нового приміщення
        private void AddPremisesFormForm_OnSaveNewClnPlaceHoll(ClnPlaceHoll clnPlaceHoll)
        {
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

        /// <summary>
        /// Вибір режиму відображення (метраж / кількість місць) 
        /// </summary>
        /// <param name="measurement"></param>
        private void SetGridColumnHeaderText(MeasurementOfPremises measurement)
        {
            switch (measurement)
            {
                case MeasurementOfPremises.Number:
                    rGridViewPremises.Columns["ValuePlace"].HeaderText = "Кількість місць";
                    break;

                case MeasurementOfPremises.Area:
                    rGridViewPremises.Columns["ValuePlace"].HeaderText = "Площа";
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
            AddPremisesForm editForm = new AddPremisesForm(editItem, _measurementOfPremises, PremisesFormTypeInitialization.Edit);
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

        /// <summary>
        /// Оновлення грід
        /// </summary>
        public void RefreshGrid()
        {
            rGridViewPremises.Update();
            rGridViewPremises.MasterTemplate.Refresh();
            rGridViewPremises.Refresh();
        }
    }
}
