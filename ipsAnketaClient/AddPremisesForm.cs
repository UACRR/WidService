using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ipsmedserviceapp.Model;
using Telerik.WinControls;

namespace ipsAnketaClient
{
    public partial class AddPremisesForm : Telerik.WinControls.UI.RadForm
    {
        public List<ClnPlaceHoll> _data;

        public AddPremisesForm()
        {
            InitializeComponent();
        }

        public AddPremisesForm(List<ClnPlaceHoll> data)
        {
            InitializeComponent();
            _data = data;
            rBtnAdd.Text = "Зберегти";
        }

        private void rBtnAdd_Click(object sender, EventArgs e)
        {
            if (Validator())
            {
                if (MessageBox.Show("ADD") == DialogResult.OK)
                    Close();
            }
        }

        private void rBtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Перевірка правильності введення
        /// </summary>
        /// <returns></returns>
        private bool Validator()
        {
            bool isValid = true;
            if (rtxtBoxTypePremisses.Text == string.Empty)
            {
                lblTypePremisses.ForeColor = Color.Crimson;
                isValid = false;
            }
            if (rtxtBoxCountOrMeterage.Text == string.Empty)
            {
                lblCountPlaces.ForeColor = Color.Crimson;
                isValid = false;
            }

            if (isValid)
            {
                lblTypePremisses.ForeColor = Color.Black;
                lblCountPlaces.ForeColor = Color.Black;
            }
            else
            {
                    MessageBox.Show("Деякі поля не можуть бути пустими!", "Заповніть всі поля!",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return isValid;
        }


    }
}
