using System.Threading;
using System.Windows.Controls;

namespace IPSViewComponentLibraryWPF.Modules.CatalogFileItems.Controls.PubCatalogItem
{
    /// <summary>
    /// Interaction logic for PubCatalogItemControl.xaml
    /// </summary>
    public sealed partial class PubCatalogItemControl : UserControl
    {
        public PubCatalogItemControl()
        {
            InitializeComponent();
            Language = System.Windows.Markup.XmlLanguage.GetLanguage(Thread.CurrentThread.CurrentCulture.Name);
        }
    }
}
