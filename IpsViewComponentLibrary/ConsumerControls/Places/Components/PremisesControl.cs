using System;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign;
using ipsFormsDesign.Data;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary.ConsumerControls.Places.Enums;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.ConsumerControls.Places.Components
{
    public partial class PremisesControl : UserControl
    {
        private const string FullCount = "К-сть місць";
        private const string FullArea = "Площа";
        private MeasurementOfPlaces _measurementOfPlaces = MeasurementOfPlaces.Empty;
        
        public PremisesControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Встановити тип приміщень (метраж / кількість місць / Додатковий параметр) 
        /// </summary>
        private void SetMeasurementOfPlaces(MeasurementOfPlaces measurementOfPlaces)
        {
            _measurementOfPlaces = measurementOfPlaces;
            switch (measurementOfPlaces)
            {
                case MeasurementOfPlaces.Area:
                    gvPremises.Columns["ValuePlace"].HeaderText = FullArea;
                    break;

                case MeasurementOfPlaces.Number:
                    gvPremises.Columns["ValuePlace"].HeaderText = FullCount;
                    break;

                case MeasurementOfPlaces.Other:
                    gvPremises.Columns["ValuePlace"].IsVisible = false;
                    gvPremises.Columns["ValueAdd"].IsVisible = true;
                    break;
            }
        }

        public object ClnBusinessPlaceDataSource
        {
            get => bsClnPlaceHoll.DataSource;
            set
            {
                if (!(value is ClnBusinessPlace clnBusinessPlace))
                {
                    bsClnPlaceHoll.DataSource = typeof(ClnPlaceHoll);
                    return;
                }

                var typePlace = IpsGlobal.AnketaDictionaties.typePlace.SingleOrDefault(rec => rec.CodeI == clnBusinessPlace.PlCode);
                SetMeasurementOfPlaces((MeasurementOfPlaces)(typePlace?.ParamType ?? 0));
                bsClnPlaceHoll.DataSource = clnBusinessPlace.ClnPlaceHoll;
            }
        }

        // додати приміщення
        private void btnAddPremises_Click(object sender, EventArgs e)
        {
            if (_measurementOfPlaces == MeasurementOfPlaces.Area || _measurementOfPlaces == MeasurementOfPlaces.Number)
                CreateDefaultPremises();
            else if (_measurementOfPlaces == MeasurementOfPlaces.Other)
                CreateAdditionalPremises();

            bsClnPlaceHoll.ResetBindings(false);
        }

        /// <summary>
        /// [Додати] приміщення з площею або кількістю місць
        /// </summary>
        private void CreateDefaultPremises()
        {
            var holl = new ClnPlaceHoll();
            var createPremisesForm = new PremisesDetailForm(holl, _measurementOfPlaces, PremisesFormTypeInitialization.CreateNew);

            if (createPremisesForm.ShowDialog() == DialogResult.OK)
            {
                (bsClnPlaceHoll.DataSource as ObservableListSource<ClnPlaceHoll>)?.Add(holl);
            }
        }

        /// <summary>
        /// [Додати] приміщення з додатковим параметром
        /// </summary>
        private void CreateAdditionalPremises()
        {
            var holl = new ClnPlaceHoll();
            var createPremisesForm = new PremisesAdditionalDetailForm(holl, PremisesFormTypeInitialization.CreateNew);
            if (createPremisesForm.ShowDialog() == DialogResult.OK)
            {
                (bsClnPlaceHoll.DataSource as ObservableListSource<ClnPlaceHoll>)?.Add(holl);
            }
        }

        // редагувати приміщення
        private void btnEditPremises_Click(object sender, EventArgs e)
        {
            EditPremisesCall();
        }

        // редагувати приміщення
        private void gvPremises_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            EditPremisesCall();
        }

        /// <summary>
        /// Метод редагування приміщення
        /// </summary>
        private void EditPremisesCall()
        {
            if (!(gvPremises.CurrentRow?.DataBoundItem is ClnPlaceHoll editItem))
                return;

            var temp = new ClnPlaceHoll();
            temp.SetFields(editItem);

            if (_measurementOfPlaces == MeasurementOfPlaces.Area || _measurementOfPlaces == MeasurementOfPlaces.Number)
                EditDefaultPremises(editItem, temp);
            else if (_measurementOfPlaces == MeasurementOfPlaces.Other)
                EditAdditionalPremises(editItem, temp);

            bsClnPlaceHoll.ResetBindings(false);
            gvPremises.ResetBindings();
        }

        /// <summary>
        /// [Редагувати] приміщення з площею або кількістю місць
        /// </summary>
        private void EditDefaultPremises(ClnPlaceHoll editItem, ClnPlaceHoll tempItem)
        {
            var editPremisesForm = new PremisesDetailForm(tempItem, _measurementOfPlaces, PremisesFormTypeInitialization.Edit);
            if (editPremisesForm.ShowDialog() == DialogResult.OK)
            {
                editItem.SetFields(tempItem);
            }
        }

        /// <summary>
        /// [Редагувати] приміщення з додатковим параметром
        /// </summary>
        private void EditAdditionalPremises(ClnPlaceHoll editItem, ClnPlaceHoll tempItem)
        {
            var editPremisesForm = new PremisesAdditionalDetailForm(tempItem, PremisesFormTypeInitialization.Edit);
            if (editPremisesForm.ShowDialog() == DialogResult.OK)
            {
                editItem.SetFields(tempItem);
            }
        }

        // видалити приміщення
        private void btnDeletePremises_Click(object sender, EventArgs e)
        {
            if (!(gvPremises.CurrentRow?.DataBoundItem is ClnPlaceHoll deleteItem))
                return;

            (bsClnPlaceHoll.DataSource as ObservableListSource<ClnPlaceHoll>)?.Remove(deleteItem);
            bsClnPlaceHoll.ResetBindings(false);
            gvPremises.ResetBindings();
        }

        private void bsClnPlaceHoll_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            var visible = gvPremises.Rows.Any();
            btnEditPremises.Enabled = visible;
            btnDeletePremises.Enabled = visible;
        }
    }
}
