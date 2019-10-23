using System.Windows;
using ipsFormsDesign.Model;
using IPSViewComponentLibraryWPF.Modules.CatalogFileItems.Enums;
using Telerik.Windows.Controls;

namespace IPSViewComponentLibraryWPF.Modules.CatalogFileItems
{
    /// <summary>
    /// Interaction logic for CatalogFileItemsWindow.xaml
    /// </summary>
    public sealed partial class CatalogFileItemsWindow : RadWindow
    {
        public CatalogFileItemsWindow(CatalogFile catalogFile, CatalogFileType catalogFileType)
        {
            InitializeComponent();

            if (catalogFileType == CatalogFileType.PublisherCatalog)
            {
                var ctrlPubCatalogItemList = new PubCatalogItemListControl
                {
                    DataContext = this.DataContext,
                    Margin = new Thickness(1, 3, 1, 3),
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Stretch,
                    Name = "ctrlPubCatalogItemList",
                };
                gridPanel.Children.Add(ctrlPubCatalogItemList);
                gridPanel.LastChildFill = true;

            }
            else if (catalogFileType == CatalogFileType.RightholderRegister)
            {
                // some code
            }

            ((CatalogFileItemsViewModel) DataContext).CatalogFileType = catalogFileType;
            ((CatalogFileItemsViewModel) DataContext).CatalogFile = catalogFile;
        }
    }
}
