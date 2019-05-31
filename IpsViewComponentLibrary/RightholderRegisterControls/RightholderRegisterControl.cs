using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IpsViewComponentLibrary.RightholderRegisterControls.Presenters;

namespace IpsViewComponentLibrary.RightholderRegisterControls
{
    public partial class RightholderRegisterControl : UserControl
    {
        private readonly RightholderRegisterPresenter _presenter;

        protected bool IsDesignMode => DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime;

        public RightholderRegisterControl()
        {
            InitializeComponent();

            if (!DesignMode)
                _presenter = new RightholderRegisterPresenter();
        }
    }
}
