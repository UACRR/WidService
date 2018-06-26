using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using Telerik.WinControls;

namespace IpsViewComponentLibrary
{
    public partial class ProlongationWithPlaces : Telerik.WinControls.UI.RadForm
    {
        private bool _changesSaved = false;
        private LicenseAgreement _lic;
        private LicenseAgrParam _licAgr;
        public ProlongationWithPlaces()
        {
            InitializeComponent();
        }

        public ProlongationWithPlaces(LicenseAgrParam bindAgr, AnketaCompany bindAnketaCompany, AnketaDictionaties dict,  string license, LicenseAgreement lic, ObservableListSource<ClnBusinessPlace> places)
        {
            _lic = lic;
            _licAgr = bindAgr;
            InitializeComponent(); // * * * 
            this.FormClosing += ProlongationWithPlaces_FormClosing;
            ctrlProlongation.DataSourceGrid = places;

            ctrlProlongation.Dictionaties = dict;// словник

            ctrlProlongation.DataSourceAgreement = bindAgr;
            ctrlProlongation.DataSourceAnketaCompany = bindAnketaCompany;

            ctrlProlongation.LicenseName = license; // лбл ліцензії
            ctrlProlongation.LicenseAgrParam = bindAgr;
        }

        private void ProlongationWithPlaces_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            if(_changesSaved)
                return;

            _lic.LicenseAgrParam.Remove(_licAgr);
        }
    }
}
