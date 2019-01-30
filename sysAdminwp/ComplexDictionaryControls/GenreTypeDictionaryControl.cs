using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Model;
using ipsFormsDesign.Dictionary;

namespace sysAdminwp.ComplexDictionaryControls
{
    public sealed partial class GenreTypeDictionaryControl : UserControl
    {
        public event EventHandler HideElem;

        public GenreTypeDictionaryControl(List<DictBaseTypeI> listGenreType)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            bsCategory.DataSource = listGenreType;
        }

        public object GenreTypeDataSource
        {
            get => bsGenreType.DataSource;
            set => bsGenreType.DataSource = value;
        }

        private void ddlCategory_Click(object sender, EventArgs e)
        {
            HideElem?.Invoke(sender, e);
        }
    }
}
