using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using Telerik.WinControls;

namespace IpsViewComponentLibrary
{
    public partial class ProlongationWithoutPlaces : Telerik.WinControls.UI.RadForm
    {
        private bool _changesSaved = false;
        private LicenseAgreement _lic;
        private LicenseAgrParam _licAgr;

        public ProlongationWithoutPlaces()
        {
            InitializeComponent();
        }

        //TODO: переробити databinding LicenseAgrParam
        public ProlongationWithoutPlaces(LicenseAgrParam bindAgr, AnketaCompany bindAnketaCompany, AnketaDictionaties dict, string license, LicenseAgreement lic = null)
        {
            _lic = lic;
            _licAgr = bindAgr;
            InitializeComponent();
            this.FormClosing += ProlongationWithoutPlaces_FormClosing;
            ctrlProlongation.OnSaveChangesClick += CtrlProlongation_OnSaveChangesClick;
            ctrlProlongation.OnPrintClick += CtrlProlongation_OnPrintClick;

            ctrlProlongation.Dictionaties = dict;// словник

            ctrlProlongation.DataSourceAgreement = bindAgr; 
            ctrlProlongation.DataSourceAnketaCompany = bindAnketaCompany;

            ctrlProlongation.LicenseName = license; // лбл ліцензії
            ctrlProlongation.LicenseAgrParam = bindAgr;
            
        }

        private void CtrlProlongation_OnPrintClick()
        {
            //TODO друк договору з без майданчиків
        }

        private void CtrlProlongation_OnSaveChangesClick()
        {
            _changesSaved = true;
            //TODO зберігання даних
            Close();
        }

        private void ProlongationWithoutPlaces_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_changesSaved)
                return;

            _lic.LicenseAgrParam.Remove(_licAgr);
        }
    }
}
