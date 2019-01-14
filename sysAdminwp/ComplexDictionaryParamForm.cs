using ipsFormsDesign.Data;
using ipsFormsDesign.Model;
using sysAdminwp.ComplexDictionaryControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace sysAdminwp
{
    public partial class ComplexDictionaryParamForm : Telerik.WinControls.UI.RadForm
    {
        CountryDictionaryControl countryDictionaryControl;


        public ComplexDictionaryParamForm()
        {

        }
        /// <summary>
        /// initialize for CopyrightKind
        /// </summary>
        /// <param name="copyright"></param>
        /// <param name="listCopyRight"></param>
        public ComplexDictionaryParamForm(CopyrightKind copyright, List<CrkindGroup> listCopyRight)
        {
            InitializeComponent();
            CopyRightKindDictionaryControl countryDictionaryControl = new CopyRightKindDictionaryControl(copyR: copyright, list: listCopyRight)
            { Dock = DockStyle.Fill };
            mainPanel.Controls.Add(countryDictionaryControl);
        }
        /// <summary>
        /// Country
        /// </summary>
        /// <param name="country"></param>
        /// <param name="continent"></param>
        public ComplexDictionaryParamForm(Country country, List<Continent> continent)
        {
            InitializeComponent();
            countryDictionaryControl = new CountryDictionaryControl(country, continent)
            { Dock = DockStyle.Fill };
            mainPanel.Controls.Add(countryDictionaryControl);
        }
        /// <summary>
        /// initialize CreativeRoleType
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public ComplexDictionaryParamForm(CreativeRoleType roleType, List<Category> listRoleType)
        {
            InitializeComponent();
            CreativeRoleTypeDictionaryControl creativeRolTyp = new CreativeRoleTypeDictionaryControl(creativeRole: roleType, listCreativeRole: listRoleType)
            { Dock = DockStyle.Fill };
            mainPanel.Controls.Add(countryDictionaryControl);
        }
        /// <summary>
        /// initialize Genretype
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public ComplexDictionaryParamForm(GenreType genreType, List<Category> listGenreType)
        {
            InitializeComponent();
            GenreTypeDictionaryControl countryDictionaryControl = new GenreTypeDictionaryControl(genreType: genreType, listGenreType: listGenreType)
            { Dock = DockStyle.Fill, };
        }
        /// <summary>
        /// initialize klr030
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public ComplexDictionaryParamForm(KlR030 klr030, List<Country> klr030List)
        {
            InitializeComponent();
            Klr030DictionaryControl countryDictionaryControl = new Klr030DictionaryControl(klr: klr030, listKlR030 :klr030List)
            { Dock = DockStyle.Fill };
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            CopyRightKindDictionaryControl checkObj = new CopyRightKindDictionaryControl();
            // check if all fields is not empty then
            //if(checkObj.radDropDownList1)
                // send OK
                DialogResult = DialogResult.OK;
        }
    }
}
