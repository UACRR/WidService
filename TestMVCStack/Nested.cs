using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestMVCStack.Main;

namespace TestMVCStack
{
    public partial class Nested : UserControl
    {
        private static int index = 1;
        public Nested(PresenterMain parent)
        {
            InitializeComponent();
            radLabel1.Text = $" N {index++}";
            var presenter = new PresenterMain(new ServiceMain(), mainViewSwitcher1, parent, index );
        }
    }
}
