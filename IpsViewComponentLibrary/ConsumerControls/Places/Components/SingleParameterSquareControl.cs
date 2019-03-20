using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Model;

namespace IpsViewComponentLibrary.ConsumerControls.Places.Components
{
    public partial class SingleParameterSquareControl : UserControl
    {
        public SingleParameterSquareControl()
        {
            InitializeComponent();
        }

        public object DataSource
        {
            get => bsClnPlaceHoll.DataSource;
            set
            {
                if (!(value is ClnBusinessPlace clnBusinessPlace))
                    return;
                bsClnPlaceHoll.DataSource = clnBusinessPlace.ClnPlaceHoll.FirstOrDefault();
            }
        }
    }
}
