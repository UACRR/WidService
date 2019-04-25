using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IpsViewComponentLibrary.CatalogControls
{
    public partial class CatalogCombine : UserControl
    {
        private CatalogControl _catalogFiles;
        private CatalogShowEdition _catalogShowDetail;
        public CatalogCombine()
        {
            InitializeComponent();

            //when action file detail
            _catalogFiles.command += SwapControl;
            _catalogShowDetail.back += BackToFiles;
        }

        /// <summary>
        /// change active controls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SwapControl(object sender, EventArgs e)
        {
            //clear control - before initialize CatalogShowEdition control 
            Controls.Clear();
            _catalogShowDetail = new CatalogShowEdition();
            Controls.Add(_catalogShowDetail);
        }

        private void BackToFiles(object sender, EventArgs e)
        {
            Controls.Clear();
            _catalogFiles = new CatalogControl();
            Controls.Add(_catalogFiles);
        }
    }
}
