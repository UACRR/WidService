using System;
using System.Drawing;
using System.Windows.Forms;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary.Extensions;

namespace IpsViewComponentLibrary.ConsumerControls.Places
{
    public partial class PremisesActionsForm : Telerik.WinControls.UI.RadForm
    {
        private const string FullCount = "К-сть місць";
        private const string FullArea = "Площа";
        private const string AddHoll = "Додати приміщення";
        private const string SaveHoll = "Зберегти";
        private const string TitleAdd = "Додати приміщення закладу";
        private const string TitleEdit = "Редагування приміщення закладу";

        public PremisesActionsForm(ClnPlaceHoll clnPlaceHoll, MeasurementOfPlaces measurementPlaces, PremisesFormTypeInitialization premisesFormTypeFrom)
        {
            InitializeComponent();
            // binding
            bsClnPlaceHoll.DataSource = clnPlaceHoll;

            // назва кнопки та вікна
            switch (premisesFormTypeFrom)
            {
                case PremisesFormTypeInitialization.Edit:
                    btnSave.Text = SaveHoll;
                    Text = TitleEdit;
                    break;
                case PremisesFormTypeInitialization.CreateNew:
                    btnSave.Text = AddHoll;
                    Text = TitleAdd;
                    break;
            }

            // назва поля
            switch (measurementPlaces)
            {
                case MeasurementOfPlaces.Area:
                    lblTitlePlace.Text = FullArea;
                    break;
                case MeasurementOfPlaces.Number:
                    lblTitlePlace.Text = FullCount;
                    break;
            }
        }

        public sealed override string Text
        {
            get => base.Text;
            set => base.Text = value;
        }

        // Збереження
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Validator())
                DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Перевірка правильності введення
        /// </summary>
        /// <returns></returns>
        private bool Validator()
        {
            bool isNumber = true;
            bool isNotEmpty = true;

            if (txtPlaceName.Text == string.Empty)
            {
                isNotEmpty = false;
                lblTypePremisses.ForeColor = Color.Crimson;
            }
            else
                lblTypePremisses.ForeColor = Color.Black;

            if (txtPlaceValue.Text == string.Empty)
            {
                isNotEmpty = false;
                lblTitlePlace.ForeColor = Color.Crimson;
            }
            else
                lblTitlePlace.ForeColor = Color.Black;


            if (!Int32.TryParse(txtPlaceValue.Text, out var tryparse))
            {
                lblTitlePlace.ForeColor = Color.Crimson;
                isNumber = false;
            }
            else
                lblTitlePlace.ForeColor = Color.Black;

            if (isNotEmpty&&isNumber)
                return true;
            else if(!isNotEmpty)
            {
                MessageBox.Show("Деякі поля не можуть бути пустими!", "Заповніть всі поля!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if(!isNumber)
            {
                MessageBox.Show("Деякі поля повинні бути числовими!", "Заповніть всі поля правильно!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return false;
        }
    }
}
