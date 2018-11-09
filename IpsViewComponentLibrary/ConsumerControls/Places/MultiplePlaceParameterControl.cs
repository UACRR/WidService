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
    public partial class MultiplePlaceParameterControl : UserControl, IPlacesControl
    {

        public event EventHandler SaveChanges;
        public event EventHandler CancelChanges;

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

        private bool Validator()
        {
            bool isValid = true;

            if (txtPlaceName.Text == string.Empty)
            {
                isValid = false;
                rLblName.ForeColor = Color.FromArgb(180, 255, 0, 2);
            }
            else
                rLblName.ForeColor = Color.Black;

            return isValid;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if(Validator())
                SaveChanges?.Invoke(sender, e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CancelChanges?.Invoke(sender, e);
        }

        public void BeginBindings()
        {
            throw new NotImplementedException();
        }

        public Size GetSize()
        {
            return new Size(Size.Width, Size.Width + 5);
        }
    }
}
