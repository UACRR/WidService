using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IpsViewComponentLibrary.PublisherAndSubpublisher
{
    public partial class PublisherAndSubpublisherControl : UserControl
    {
        public PublisherAndSubpublisherControl()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void LoadData()
        {
            bsPublishers.DataSource = new List<object>();
        }
    }
}
