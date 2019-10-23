using System.Threading;
using System.Windows.Controls;

namespace IPSViewComponentLibraryWPF
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public sealed partial class PubCatalogItemListControl : UserControl
    {
        public PubCatalogItemListControl()
        {
            InitializeComponent();
            Language = System.Windows.Markup.XmlLanguage.GetLanguage(Thread.CurrentThread.CurrentCulture.Name);
        }
    }
}
