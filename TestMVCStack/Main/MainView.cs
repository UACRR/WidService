using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestMVCStack.Main
{
    public partial class MainView : UserControl
    {
        public MainView()
        {
            InitializeComponent();
        }

        public void SetView( Control view )
        {
            radPanel1.SuspendUpdate();
            radPanel1.Controls.Clear();
            radPanel1.Controls.Add(view);
            radPanel1.ResumeUpdate();
        }
    }
}
