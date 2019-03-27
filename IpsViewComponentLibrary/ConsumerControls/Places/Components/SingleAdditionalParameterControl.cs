using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Model;

namespace IpsViewComponentLibrary.ConsumerControls.Places.Components
{
    public partial class SingleAdditionalParameterControl : UserControl
    {
        public SingleAdditionalParameterControl()
        {
            InitializeComponent();
        }

        public object DataSource
        {
            get => bsClnPlaceHoll.DataSource;
            set
            {
                if (value is ClnBusinessPlace clnBusinessPlace)
                    bsClnPlaceHoll.DataSource = clnBusinessPlace.ClnPlaceHoll.SingleOrDefault();
                else if (value is ClnPlaceHoll clnPlaceHoll)
                    bsClnPlaceHoll.DataSource = clnPlaceHoll;
            }
        }
    }
}
