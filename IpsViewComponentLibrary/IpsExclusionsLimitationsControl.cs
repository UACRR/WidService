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
    public partial class IpsExclusionsLimitationsControl : UserControl
    {
        public IpsExclusionsLimitationsControl()
        {
            InitializeComponent();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RadGridView GridExclusionsLimitations
        {
            get
            {
                return gvExlusionsLimitations;
            }
        }
    }
}
