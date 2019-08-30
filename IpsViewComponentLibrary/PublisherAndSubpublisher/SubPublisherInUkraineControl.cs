using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Services;

namespace IpsViewComponentLibrary.PublisherAndSubpublisher
{
    public partial class SubPublisherInUkraineControl : UserControl
    {
        public SubPublisherInUkraineControl()
        {
            InitializeComponent();
        }

        public void LoadData(int custId)
        {
            var item = PublisherAndSubpublisherSevice.GetInstance().GetSubpublisherUkraine(custId);
            txtSubPublisherInUkraine.Text = item?.SubName ?? string.Empty;
        }
    }
}
