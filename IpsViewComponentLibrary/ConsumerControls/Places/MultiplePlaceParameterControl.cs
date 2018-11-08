using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IpsViewComponentLibrary.ConsumerControls.Places
{
    public partial class MultiplePlaceParameterControl : UserControl
    {
        public MultiplePlaceParameterControl()
        {
            InitializeComponent();
        }



        /// <summary>
        /// Словник регіонів
        /// </summary>
        public object DictionaryRegion
        {
            get => bsDictRegion.DataSource;
            set => bsDictRegion.DataSource = value;
        }

        /// <summary>
        /// Словник типу майданчиків
        /// </summary>
        public object DictionaryTypePlace
        {
            get => bsDictTypePlace.DataSource;
            set => bsDictTypePlace.DataSource = value;
        }
    }
}
