using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IpsViewComponentLibrary.ExtensionControls
{
    public partial class SaveCancelButtonsControl : UserControl
    {
        public SaveCancelButtonsControl()
        {
            InitializeComponent();
            btnSave.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;
        }
    }
}
