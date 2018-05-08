using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IpsViewComponentLibrary;
using Telerik.WinControls.UI;

namespace ipsAnketaClient
{
    public partial class AnketaClientView : Telerik.WinControls.UI.RadForm
    {
        private IpsPremisesTypeControl premisesType;
        private bool IsNeedPremissesType = false;

        public AnketaClientView()
        {
            InitializeComponent();
        }

        #region Кнопки додавання нових закладів

        private void rBtnAddRestaurant_Click(object sender, EventArgs e)
        {
            rTxtBoxTypeInst.Text = rBtnAddRestaurant.Text;
            rPanelAdd.Visible = true;
            InitializeAdditionalComponents();
            rDropDownBtnAddInst.Enabled = false;
            IsNeedPremissesType = true;
        }

        private void rBtnAddHotel_Click(object sender, EventArgs e)
        {
            rTxtBoxTypeInst.Text = rBtnAddHotel.Text;
            rPanelAdd.Visible = true;
            rDropDownBtnAddInst.Enabled = false;
            IsNeedPremissesType = true;
            InitializeAdditionalComponents();
        }

        private void rBtnAddNightClub_Click(object sender, EventArgs e)
        {
            rTxtBoxTypeInst.Text = rBtnAddNightClub.Text;
            rPanelAdd.Visible = true;
            rTxtBoxCountOrMeters.Visible = true;
            lblLocation.Visible = true;
            lblLocation.Text = "Кількість місць";
            rDropDownBtnAddInst.Enabled = false;
            rPanelAdd.ClientSize = new Size(rPanelAdd.Width, 215);// без додаткового гріда
        }

        private void rBtnAddNightClubFree_Click(object sender, EventArgs e)
        {
            rTxtBoxTypeInst.Text = rBtnAddNightClub.Text;
            rPanelAdd.Visible = true;
            rTxtBoxCountOrMeters.Visible = true;
            lblLocation.Visible = true;
            lblLocation.Text = "Метраж";
            rDropDownBtnAddInst.Enabled = false;
            rPanelAdd.ClientSize = new Size(rPanelAdd.Width, 215);// без додаткового гріда
        }

        private void rBtnAddCaffeOrBar_Click(object sender, EventArgs e)
        {
            rTxtBoxTypeInst.Text = rBtnAddCaffeOrBar.Text;
            rPanelAdd.Visible = true;
            lblLocation.Visible = true;
            rTxtBoxCountOrMeters.Visible = true;
            lblLocation.Text = "Кількість місць";
            rDropDownBtnAddInst.Enabled = false;
            rPanelAdd.ClientSize = new Size(rPanelAdd.Width, 215);// без додаткового гріда
        }



        private void rBtnAddTheaterOrOpera_Click(object sender, EventArgs e)
        {
            rTxtBoxTypeInst.Text = rBtnAddCaffeOrBar.Text;
            rPanelAdd.Visible = true;
            lblLocation.Visible = true;
            rTxtBoxCountOrMeters.Visible = true;
            lblLocation.Text = "Кількість місць";
            rDropDownBtnAddInst.Enabled = false;
            rPanelAdd.ClientSize = new Size(rPanelAdd.Width, 215);// без додаткового гріда

        }

        #endregion


        private void rBtnCancel_Click(object sender, EventArgs e)
        {
            rPanelAdd.Visible = false;
            rDropDownBtnAddInst.Enabled = true;
            //this.ClientSize = new System.Drawing.Size(Width, Height-rPanelAdd.Height);
            ClearTxtBoxes();

            if (premisesType != null)
            {
                rPanelAdd.Controls.Remove(premisesType);
                rPanelAdd.Refresh();
                premisesType.Dispose();
                premisesType = null;
                GC.Collect();
            }

            IsNeedPremissesType = false;
        }

        private void ClearTxtBoxes()
        {
            rTxtBoxNameInst.Clear();
            rTxtBoxTypeInst.Clear();
            addressControl.SetEmpty();
        }

        private void InitializeAdditionalComponents()
        {
            rTxtBoxCountOrMeters.Visible = false;
            lblLocation.Visible = false;
            rTxtBoxCountOrMeters.Visible = false;
            lblLocation.Text = string.Empty;

            premisesType = new IpsPremisesTypeControl();
            premisesType.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);
            premisesType.Location = new Point(10, 155); ;
            premisesType.Width = addressControl.Width;
            rPanelAdd.ClientSize = new Size(rPanelAdd.Width, 340);//215
            
            rPanelAdd.Controls.Add(premisesType);
        }

        private void rBtnSave_Click(object sender, EventArgs e)
        {
            addressControl.SetValues();

            if (!Validator())
                return;

            if (IsNeedPremissesType)
            {
                //some code
            }
            else
            {
                //some code
            }

            string s = "  ||  ";
            MessageBox.Show(addressControl.TownName + s +
                            addressControl.StreetName + s +
                            addressControl.BuildNumber + s +
                            addressControl.OfficeNumber + s +
                            addressControl.RegionCode + s +
                            addressControl.RegionName);
        }

        private bool Validator()
        {
            bool empty = false;
            if (rTxtBoxNameInst.Text == string.Empty)
            {
                empty = true;
                rLblName.ForeColor = Color.FromArgb(180, 255, 0, 2);
            }

            if (rTxtBoxCountOrMeters.Text == string.Empty)
            {
                empty = true;
                lblLocation.ForeColor = Color.FromArgb(180, 255, 0, 2);
            }

            if (empty)
            {
                MessageBox.Show("Деякі поля не можуть бути пустими!", "Заповніть всі поля!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            rLblName.ForeColor = Color.Black;
            lblLocation.ForeColor = Color.Black;

            return true;
        }


    }
}
