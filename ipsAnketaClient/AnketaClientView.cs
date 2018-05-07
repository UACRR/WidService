using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace ipsAnketaClient
{
    public partial class AnketaClientView : Telerik.WinControls.UI.RadForm
    {
        public AnketaClientView()
        {
            InitializeComponent();
        }

        private void rBtnAddRestaurant_Click(object sender, EventArgs e)
        {
            rTxtBoxTypeInst.Text = rBtnAddRestaurant.Text;
            rPanelAdd.Visible = true;
            InitializeAdditionalComponents();

        }

        private void rBtnAddHotel_Click(object sender, EventArgs e)
        {
            rTxtBoxTypeInst.Text = rBtnAddHotel.Text;
            rPanelAdd.Visible = true;

        }

        private void rBtnAddNightClub_Click(object sender, EventArgs e)
        {
            rTxtBoxTypeInst.Text = rBtnAddNightClub.Text;
            rPanelAdd.Visible = true;

        }

        private void rBtnAddCaffeOrBar_Click(object sender, EventArgs e)
        {
            rTxtBoxTypeInst.Text = rBtnAddCaffeOrBar.Text;
            rPanelAdd.Visible = true;
        }

        private void rBtnCancel_Click(object sender, EventArgs e)
        {
            rPanelAdd.Visible = false;
            this.ClientSize = new System.Drawing.Size(Width, Height-330);
            ClearTxtBoxes();
        }

        private void ClearTxtBoxes()
        {
            rTxtBoxTypeInst.Clear();
        }

        private void InitializeAdditionalComponents()
        {
            RadGridView premisesInstGridView = new RadGridView();
            this.ClientSize = new System.Drawing.Size(Width,Height+330);
        }

        private void rBtnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
