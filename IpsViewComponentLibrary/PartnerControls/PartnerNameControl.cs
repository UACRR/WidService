using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using IpsViewComponentLibrary.Utilities;

namespace IpsViewComponentLibrary.PartnerControls
{
    public partial class PartnerNameControl : UserControl
    {
        private bool _birthDateSelected = false;
        public PartnerNameControl()
        {
            InitializeComponent();
            dtBirthDay.ValueChanged += dtBirthDay_ValueChanged;

            dtBirthDay.SetUserCalendarSettingsm();
        }

        [Category("Data")]
        [AttributeProvider(typeof(IListSource))]
        public object DataSourceAnketa
        {
            get => bsAnketaPerson.DataSource;
            set
            {
                if (bsAnketaPerson.DataSource != value)
                {
                    bsAnketaPerson.DataSource = value;
                }
            }
        }
        

        /// <summary>
        /// Перевірка на правильність введених даних
        /// </summary>
        /// <returns></returns>
        public bool Validator()
        {
            bool isValid = true;

            if (!_birthDateSelected)
            {
                lblBirthDate.ForeColor = Color.FromArgb(180, 255, 0, 2);
                isValid = false;
            }
            else
                lblBirthDate.ForeColor = Color.Black;

            if (rtxtBoxFirstName.Text == string.Empty)
            {
                lblFirstName.ForeColor = Color.FromArgb(180, 255, 0, 2);
                isValid = false;
            }
            else
                lblFirstName.ForeColor = Color.Black;

            if (rtxtBoxLastName.Text == string.Empty)
            {
                lblLastName.ForeColor = Color.FromArgb(180, 255, 0, 2);
                isValid = false;
            }
            else
                lblLastName.ForeColor = Color.Black;

            //if (!_sexSelected)
            //{
            //    lblSex.ForeColor = Color.FromArgb(180, 255, 0, 2);
            //    isValid = false;
            //}
            //else
            //    lblSex.ForeColor = Color.Black;

            return isValid;
        }

        private void dtBirthDay_ValueChanged(object sender, EventArgs e)
        {
            _birthDateSelected = true;
        }

        private void PartnerNameControl_Load(object sender, EventArgs e)
        {
            if (IpsGlobal.AnketaDictionaties?.sexType != null)
                ddlSexType.SetDataSource(IpsGlobal.AnketaDictionaties.sexType);
        }
    }
}
