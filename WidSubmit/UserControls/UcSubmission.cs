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
            ucSubmProcessControl.WorksUpdated += UcSubmProcessControl_WorksUpdated;
        }

        public void UpdateContent()
        {
            ucSubmProcessControl.UpdateContent();
            ucSubmWorks.UpdateContent();
        }

        private void UcSubmProcessControl_WorksUpdated(object sender, EventArgs e)
        {
            ucSubmWorks.UpdateContent();
        }
    }
}
