using System;
using System.Windows.Forms;
using ipsFormsDesign;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary.Extensions;
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
        /// Тип приміщень (метраж / кількість місць) 
        /// </summary>
        public MeasurementOfPlaces PlaceType
        {
            get => _measurementOfPlaces;
            set
            {
                switch (value)
                {
                    case MeasurementOfPlaces.Number:
                        gvPremises.Columns["ValuePlace"].HeaderText = FullCount;
                        break;

                    case MeasurementOfPlaces.Area:
                        gvPremises.Columns["ValuePlace"].HeaderText = FullArea;
                        break;
                }
            }
        }

        public object PlaceHollDataSource
        {
            get => bsClnPlaceHoll.DataSource;
            set
            {
                if (value == null)
                {
                    bsClnPlaceHoll.DataSource = typeof(ClnPlaceHoll);
                    return;
                }
                bsClnPlaceHoll.DataSource = value;
            }
        }

        // додати приміщення
        private void btnAddPremises_Click(object sender, EventArgs e)
        {
            var holl = new ClnPlaceHoll();
            var createPremisesForm = new PremisesDetailForm(holl, _measurementOfPlaces, PremisesFormTypeInitialization.CreateNew);

            if (createPremisesForm.ShowDialog() == DialogResult.OK)
            {
                (bsClnPlaceHoll.DataSource as ObservableListSource<ClnPlaceHoll>)?.Add(holl);
            }

            bsClnPlaceHoll.ResetBindings(false);
        }

        // редагувати приміщення
        private void btnEditPremises_Click(object sender, EventArgs e)
        {
            if(gvPremises.Rows.Count == 0) return;

            var editItem = gvPremises.CurrentRow.DataBoundItem as ClnPlaceHoll;

            var temp = new ClnPlaceHoll();
            temp.SetFields(editItem);

            var editPremisesForm = new PremisesDetailForm(temp, _measurementOfPlaces, PremisesFormTypeInitialization.Edit);

            if (editPremisesForm.ShowDialog() == DialogResult.OK)
            {
                editItem.SetFields(temp);
            }

            bsClnPlaceHoll.ResetBindings(false);
        }

        // видалити приміщення
        private void btnDeletePremises_Click(object sender, EventArgs e)
        {
            if (!(gvPremises.CurrentRow.DataBoundItem is ClnPlaceHoll deleteItem))
                return;

            (bsClnPlaceHoll.DataSource as ObservableListSource<ClnPlaceHoll>)?.Remove(deleteItem);
            bsClnPlaceHoll.ResetBindings(false);
        }

        private void gvPremises_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            var visible = gvPremises.RowCount != 0;

            btnEditPremises.Enabled = visible;
            btnDeletePremises.Enabled = visible;
        }
    }
}
