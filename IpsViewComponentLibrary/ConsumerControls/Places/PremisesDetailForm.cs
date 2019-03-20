using System;
using System.Drawing;
using System.Windows.Forms;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary.Extensions;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.ConsumerControls.Places
{
    public partial class PremisesDetailForm : RadForm
    {
        private const string FullCount = "К-сть місць";
        private const string FullArea = "Площа";
        private const string Other = "Інше";
        private const string AddHoll = "Додати приміщення";
        private const string SaveHoll = "Зберегти";
        private const string TitleAdd = "Додати приміщення закладу";
        private const string TitleEdit = "Редагування приміщення закладу";

        public PremisesDetailForm(ClnPlaceHoll clnPlaceHoll, MeasurementOfPlaces measurementPlaces, PremisesFormTypeInitialization premisesFormTypeFrom)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            // binding
            bsClnPlaceHoll.DataSource = clnPlaceHoll;

            // назва поля
            switch (measurementPlaces)
            {
                case MeasurementOfPlaces.Area:
                    lblTitlePlace.Text = FullArea;
                    break;
                case MeasurementOfPlaces.Number:
                    lblTitlePlace.Text = FullCount;
                    break;
                case MeasurementOfPlaces.Other:
                    lblTitlePlace.Text = Other;
                    break;
            }
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
