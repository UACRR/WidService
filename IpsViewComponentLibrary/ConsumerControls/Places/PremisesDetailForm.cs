using System;
using System.Drawing;
using System.Windows.Forms;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary.ConsumerControls.Places.Enums;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.ConsumerControls.Places
{
    public partial class PremisesDetailForm : RadForm
    {
        private const string FullCount = "К-сть місць";
        private const string FullArea = "Площа";
        private const string TitleAdd = "Додати приміщення бізнес-точки";
        private const string TitleEdit = "Редагування приміщення бізнес-точки";

        public PremisesDetailForm(ClnPlaceHoll clnPlaceHoll, MeasurementOfPlaces measurementPlaces, PremisesFormTypeInitialization action)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            // binding
            bsClnPlaceHoll.DataSource = clnPlaceHoll;

            // назва поля
            if (measurementPlaces == MeasurementOfPlaces.Area)
                lblTitlePlace.Text = FullArea;
            else if (measurementPlaces == MeasurementOfPlaces.Number)
                lblTitlePlace.Text = FullCount;

            if (action == PremisesFormTypeInitialization.CreateNew)
                Text = TitleAdd;
            else if (action == PremisesFormTypeInitialization.Edit)
                Text = TitleEdit;
        }

        public sealed override string Text
        {
            get => base.Text;
            set => base.Text = value;
        }

        /// <summary>
        /// Перевірка правильності введення
        /// </summary>
        /// <returns></returns>
        public bool Validator()
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


            if (!int.TryParse(txtPlaceValue.Text, out int tryparse))
            {
                lblTitlePlace.ForeColor = Color.Crimson;
                isNumber = false;
            }
            else
                lblTitlePlace.ForeColor = Color.Black;

            if (isNotEmpty && isNumber)
                return true;

            if (!isNotEmpty)
            {
                MessageBox.Show("Деякі поля не можуть бути пустими!", "Заповніть всі поля!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!isNumber)
            {
                MessageBox.Show("Деякі поля повинні бути числовими!", "Заповніть всі поля правильно!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return false;
        }
    }
}
