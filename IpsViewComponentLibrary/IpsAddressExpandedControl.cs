using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            _nubmerBuild = rTxtBoxNumberBldng.Text;
            _numberOffice = rTxtBoxNumberOffice.Text;
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
            rTxtBoxNumberBldng.Clear();
            rTxtBoxNumberOffice.Clear();
        }

        /// <summary>
        /// Перевіряє чи введені всі необхідні дані
        /// </summary>
        /// <returns></returns>
        public bool ValidatorAddressCtrl()
        {
            if (rTxtBoxTownName.Text == string.Empty)
            {
                
                return false;
            }

            if (rDropListRegion.SelectedItem.Index == 0)
            {

                return false;
            }

            if (rTxtBoxNameStreet.Text == string.Empty)
            {
                
                return false;
            }

            if (rTxtBoxNumberBldng.Text == string.Empty)
            {

                return false;
            }

            return true;
        }

        private void rDropListRegion_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            _regionCode = rDropListRegion.SelectedItem.Index;
            _nameRegion = rDropListRegion.SelectedItem.Text;
        }
    }
}
