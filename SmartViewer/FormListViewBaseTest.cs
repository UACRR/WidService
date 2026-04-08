using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartViewer
{
    public partial class FormListViewBaseTest : Form
    {
        public FormListViewBaseTest()
        {
            InitializeComponent();
        }

        private void FormListViewBaseTest_Load(object sender, EventArgs e)
        {
            ucListViewBase.UpdateContent();
        }
    }
}
