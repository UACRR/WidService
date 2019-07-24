using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Services;
using IpsViewComponentLibrary.Extensions;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.ObjectRightControls
{
    public partial class ObjectRightSelectionExtendedView : RadForm
    {
        public ObjectRightMainView ObjectRight { get; private set; }

        public ObjectRightSelectionExtendedView()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

        }
    }
}
