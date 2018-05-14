using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsmedserviceapp.Model;

namespace IpsViewComponentLibrary
{
    public partial class IpsAddressExpandedControl : UserControl
    {
        private string _nameTown;
        private string _nameRegion;
        private string _nameDistrict;
        private string _streetAddress;
        private string _nubmerBuild;
        private string _numberOffice;
        private int _regionCode;

        public string TownName => _nameTown;
        public string RegionName => _nameRegion;
        public int RegionCode => _regionCode;
        public string DistrictName => _nameDistrict;
        public string StreetName => _streetAddress;
        public string BuildNumber => _nubmerBuild;
        public string OfficeNumber => _numberOffice;

        public IpsAddressExpandedControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Встановлення значень
        /// </summary>
        public void SetValues()
        {
            _nameTown = rTxtBoxTownName.Text;
            _nameDistrict = rTxtBoxDistrict.Text;
            _streetAddress = rTxtBoxNameStreet.Text;
        }

        /// <summary>
        /// Очищення тестбоксів
        /// </summary>
        public void SetEmpty()
        {
            rTxtBoxTownName.Clear();
            rDropListRegion.SelectedItem = rDropListRegion.Items[0];
            rTxtBoxDistrict.Clear();
            rTxtBoxNameStreet.Clear();
        }

        /// <summary>
        /// Перевіряє чи введені всі необхідні дані
        /// </summary>
        /// <returns></returns>
        public bool ValidatorAddressCtrl()
        {
            bool valid = true;
            if (rTxtBoxTownName.Text == string.Empty)
            {
                lblTown.ForeColor = Color.FromArgb(180, 255, 0, 2);
                valid = false;
            }

            if (rDropListRegion.SelectedItem == null||rDropListRegion.SelectedItem.Index == 0)
            {
                lblRegion.ForeColor = Color.FromArgb(180, 255, 0, 2);
                valid = false;
            }

            if (rTxtBoxNameStreet.Text == string.Empty)
            {
                lblStreet.ForeColor = Color.FromArgb(180, 255, 0, 2);
                valid = false;
            }


            if (valid)
                DefaultColorLabels();

            return valid;
        }

        public void DefaultColorLabels()
        {
            lblTown.ForeColor = Color.Black;
            lblRegion.ForeColor = Color.Black;
            lblStreet.ForeColor = Color.Black;
        }

        public void SetAddressForEditCustomer(Customer data, int id)
        {
           _nameTown = data.Client.ClnBusinessPlace.Where(itemId => itemId.PlaceId == id).Select(item => item.PlaceCity).SingleOrDefault();
           _regionCode = (int)data.Client.ClnBusinessPlace.Where(itemId => itemId.PlaceId == id).Select(item=>item.PlaceRegion).SingleOrDefault();
            rDropListRegion.SelectedIndex = _regionCode;
            _nameRegion = rDropListRegion.SelectedItem.Text;
            _streetAddress = data.Client.ClnBusinessPlace.Where(itemId => itemId.PlaceId == id).Select(item => item.PlaceAddress).SingleOrDefault();


            //_nubmerBuild;
            //_numberOffice;

            rTxtBoxTownName.Text = _nameTown;
            rTxtBoxNameStreet.Text = _streetAddress;
        }

        private void rDropListRegion_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            _regionCode = rDropListRegion.SelectedItem.Index;
            _nameRegion = rDropListRegion.SelectedItem.Text;
        }
    }
}
