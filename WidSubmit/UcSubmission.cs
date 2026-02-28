using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WidSubmit
{
    public partial class UcSubmission : UserControl
    {
        public UcSubmission()
        {
            InitializeComponent();
        }

        public void UpdateContent()
        {
            ucSubmProcessControl.UpdateContent();
        }
    }
}
