using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IpsViewComponentLibrary.ConsumerControls.Places
{
    public partial class MultiplePlaceParameterControl : UserControl, IPlacesControl
    {

        private MeasurementOfPlaces _placesType = MeasurementOfPlaces.Empty;

        public event EventHandler SaveChanges;
        public event EventHandler CancelChanges;

        public MultiplePlaceParameterControl()
        {
            InitializeComponent();
            ButtonsVisible = false;
        }

        /// <summary>
        /// Словник регіонів
        /// </summary>
        public object DictionaryRegion
        {
            get => bsDictRegion.DataSource;
            set => bsDictRegion.DataSource = value;
        }

        /// <summary>
        /// Словник типу майданчиків
        /// </summary>
        public object DictionaryTypePlace
        {
            get => bsDictTypePlace.DataSource;
            set => bsDictTypePlace.DataSource = value;
        }

        private bool Validator()
        {
            bool isValid = true;

            if (txtPlaceName.Text == string.Empty)
            {
                isValid = false;
                rLblName.ForeColor = Color.FromArgb(180, 255, 0, 2);
            }
            else
                rLblName.ForeColor = Color.Black;

            return isValid;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CancelChanges?.Invoke(sender, e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Validator())
                SaveChanges?.Invoke(sender, e);
        }

        public object BusinessPlaceDataSource { get; set; }
        public MeasurementOfPlaces PlaceType
        {
            get => _placesType;
            set
            {
                _placesType = value;
                ctrlPremises.PlaceType = value;
            }
        }

        public bool ButtonsVisible
        {
            get => btnSave.Visible && btnCancel.Visible && separatorButtons.Visible;
            set
            {
                btnSave.Visible = value;
                btnCancel.Visible = value;
                separatorButtons.Visible = value;
            }
        }
    }
}
