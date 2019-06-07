using ipsFormsDesign.Model;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.CatalogControls
{
    public partial class CatalogDetailForm : RadForm
    {
        public CatalogDetailForm(CatalogFile file)
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            Text = file.FileName;
            ctrlCatalogShowEdition.DataSource = file;
        }

        public sealed override string Text
        {
            get => base.Text;
            set => base.Text = value;
        }
    }
}
