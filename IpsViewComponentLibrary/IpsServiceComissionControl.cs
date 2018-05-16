using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary
{
    public partial class IpsServiceComissionControl : UserControl
    {
        public IpsServiceComissionControl()
        {
            InitializeComponent();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RadMaskedEditBox TxtRateCommission
        {
            get
            {
                return mtxtRateCommission;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RadMaskedEditBox TxtRateCourt
        {
            get
            {
                return mtxtRateCourt;
            }
        }
    }
}
