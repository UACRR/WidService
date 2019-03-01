using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ipsFormsDesign;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary.Extensions;

namespace IpsViewComponentLibrary.ConsumerControls.Places
{
    public partial class PremisesControl : UserControl
    {
        private const string FullCount = "К-сть місць";
        private const string FullArea = "Площа";
        private PremisesActionsForm _premisesActionsForm;
        private MeasurementOfPlaces _measurementOfPlaces = MeasurementOfPlaces.Empty;
        
        public PremisesControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Тип приміщень (метраж / кількість місць) 
        /// </summary>
        /// <param name="measurement"></param>
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
            _premisesActionsForm = new PremisesActionsForm(holl, _measurementOfPlaces, PremisesFormTypeInitialization.CreateNew)
            {
                StartPosition = FormStartPosition.CenterScreen
            };

            if (_premisesActionsForm.ShowDialog() == DialogResult.OK)
            {
                (bsClnPlaceHoll.DataSource as ObservableListSource<ClnPlaceHoll>)?.Add(holl);
            }

            bsClnPlaceHoll.ResetBindings(true);
            gvPremises.Refresh();

            GC.Collect();
        }

        // редагувати приміщення
        private void btnEditPremises_Click(object sender, EventArgs e)
        {
            if(gvPremises.Rows.Count == 0) return;

            var editItem = gvPremises.CurrentRow.DataBoundItem as ClnPlaceHoll;

            var temp = new ClnPlaceHoll();
            temp.SetFields(editItem);

            _premisesActionsForm = new PremisesActionsForm(temp, _measurementOfPlaces, PremisesFormTypeInitialization.Edit)
            {
                StartPosition = FormStartPosition.CenterScreen
            };

            if (_premisesActionsForm.ShowDialog() == DialogResult.OK)
            {
                editItem.SetFields(temp);
            }

            gvPremises.MasterTemplate.Refresh();
            GC.Collect();
        }

        // видалити приміщення
        private void btnDeletePremises_Click(object sender, EventArgs e)
        {
            if (gvPremises.Rows.Count == 0) return;

            var deleteItem = gvPremises.CurrentRow.DataBoundItem as ClnPlaceHoll;
            (bsClnPlaceHoll.DataSource as ObservableListSource<ClnPlaceHoll>)?.Remove(deleteItem);
            
            bsClnPlaceHoll.ResetBindings(true);
            gvPremises.Refresh();
        }

        private void gvPremises_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            var visible = gvPremises.RowCount != 0;

            btnEditPremises.Enabled = visible;
            btnDeletePremises.Enabled = visible;
        }
    }
}
