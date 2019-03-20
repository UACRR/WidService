using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Model;

namespace IpsViewComponentLibrary.ConsumerControls.Places.Components
{
    public partial class SingleParameterCountControl : UserControl
    {
        public SingleParameterCountControl()
        {
            InitializeComponent();
        }

        public object DataSource
        {
            get => bsClnPlaceHoll.DataSource;
            set
            {
                if (value is ClnBusinessPlace clnBusinessPlace)
                    bsClnPlaceHoll.DataSource = clnBusinessPlace.ClnPlaceHoll.FirstOrDefault();
            }
        }
    }
}
