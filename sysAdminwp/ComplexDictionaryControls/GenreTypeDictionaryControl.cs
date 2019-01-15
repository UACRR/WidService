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

namespace sysAdminwp.ComplexDictionaryControls
{
    public partial class GenreTypeDictionaryControl : UserControl
    {
        public GenreTypeDictionaryControl(GenreType genreType, List<Category> listGenreType)
        {
            InitializeComponent();
            bsGenreType.DataSource = genreType;
            bsCategory.DataSource = listGenreType;
        }
    }
}
