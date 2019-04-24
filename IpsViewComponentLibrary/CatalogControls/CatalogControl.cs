using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IpsViewComponentLibrary.CatalogControls.Presenters;

namespace IpsViewComponentLibrary.CatalogControls
{
    public partial class CatalogControl : UserControl
    {
        private CatalogPresenter _catalogPresenter;
        protected bool IsDesignMode => DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime;

        public CatalogControl()
        {
            InitializeComponent();

            if (!IsDesignMode)
                _catalogPresenter =new CatalogPresenter();

        }
    }
}
