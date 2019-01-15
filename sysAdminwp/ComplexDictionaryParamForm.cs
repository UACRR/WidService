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
        private IComplexDictionary _complexDictionary;

        /// <summary>
        /// initialize for CopyrightKind
        /// </summary>
        /// <param name="copyright"></param>
        /// <param name="listCopyRight"></param>
        public ComplexDictionaryParamForm(CopyrightKind copyright, List<CrkindGroup> listCopyRight)
        {
            InitializeComponent();
            var countryDictionaryControl = new CopyRightKindDictionaryControl(copyright, listCopyRight)
            { Dock = DockStyle.Fill };
            mainPanel.Controls.Add(countryDictionaryControl);
            _complexDictionary = countryDictionaryControl;
        }
        /// <summary>
        /// Country
        /// </summary>
        /// <param name="country"></param>
        /// <param name="continent"></param>
        public ComplexDictionaryParamForm(Country country, List<Continent> continent)
        {
            InitializeComponent();
            var countryDictionaryControl = new CountryDictionaryControl(country, continent)
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
            CreativeRoleTypeDictionaryControl creativeRolTyp = new CreativeRoleTypeDictionaryControl(roleType, listRoleType, new List<CopyrightType>())
            { Dock = DockStyle.Fill };
            mainPanel.Controls.Add(creativeRolTyp);
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
            if(_complexDictionary?.Validation() ?? true)
                DialogResult = DialogResult.OK;
            else
                MessageBox.Show("Не всі поля заповнені", "Повіжомлення", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
    }
}
