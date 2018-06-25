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
    public partial class ProlongationWithPlaces : Telerik.WinControls.UI.RadForm
    {
        public ProlongationWithPlaces()
        {
            InitializeComponent();
        }
        //TODO: переробити databinding LicenseAgrParam
        public ProlongationWithPlaces(LicenseAgrParam bindAgr, AnketaDictionaties dict, AnketaCompany bindAnketaCompany, string license)
        {
            InitializeComponent();
            ctrlProlongation.Dictionaties = dict;// словник

            ctrlProlongation.DataSourceAgreement = bindAgr; 
            ctrlProlongation.DataSourceAnketaCompany = bindAnketaCompany;

            ctrlProlongation.LicenseName = license; // лбл ліцензії
            ctrlProlongation.LicenseAgrParam = bindAgr;
            
        }
    }
}
