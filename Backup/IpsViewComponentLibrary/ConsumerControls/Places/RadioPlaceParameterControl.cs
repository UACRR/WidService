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

namespace IpsViewComponentLibrary.ConsumerControls.Places
{
    public partial class RadioPlaceParameterControl : UserControl, IPlacesControl
    {
        public event EventHandler SaveChanges;
        public event EventHandler CancelChanges;

        public RadioPlaceParameterControl()
        {
            InitializeComponent();
            ButtonsVisible = false;
        }

        /// <summary>
        /// Словник типу майданчиків
        /// </summary>
        public object DictionaryTypePlace
        {
            get => bsDictTypePlace.DataSource;
            set => bsDictTypePlace.DataSource = value;
        }

        public object BusinessPlaceDataSource
        {
            get => bsClnBusinessPlace.DataSource;
            set
            {
                if (value == null)
                {
                    bsClnBusinessPlace.DataSource = typeof(ClnBusinessPlace);
                    return;
                }
                bsClnBusinessPlace.DataSource = value;
                if ((value as ClnBusinessPlace)?.ClnPlaceHoll?.SingleOrDefault() is ClnPlaceHoll placeHoll)
                {
                    bsClnPlaceHoll.DataSource = placeHoll;
                }

                txtPlaceType.Text = (bsDictTypePlace.DataSource as List<TypePlace>)?.SingleOrDefault(rec => rec.CodeI == (value as ClnBusinessPlace)?.PlCode)?.Name;
            }
        }

        public MeasurementOfPlaces PlaceType { get; set; } = MeasurementOfPlaces.Other;

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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Validator())
                SaveChanges?.Invoke(sender, e);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CancelChanges?.Invoke(sender, e);
        }
    }
}
