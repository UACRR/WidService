using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using ipsFormsDesign.Model;
using IPSViewComponentLibraryWPF.Modules.CatalogFileItems.Enums;

namespace IPSViewComponentLibraryWPF.Modules.CatalogFileItems
{
    /// <summary>
    /// Interaction logic for CatalogFileItemsListWindow.xaml
    /// </summary>
    public partial class CatalogFileItemsListWindow
    {
        public CatalogFileItemsListWindow(CatalogFile catalogFile, CatalogFileType catalogFileType)
        {
            InitializeComponent();
            if (catalogFileType == CatalogFileType.PublisherCatalog)
            {
                var ctrlPubCatalogItemList = new Controls.PubCatalogItem.PubCatalogItemListControl
                {
                    DataContext = this.DataContext,
                    Margin = new Thickness(1, 3, 1, 3),
                    HorizontalContentAlignment = HorizontalAlignment.Stretch,
                    VerticalContentAlignment = VerticalAlignment.Stretch,
                    Name = "ctrlPubCatalogItemList",
                };

                panelForControls.Children.Add(ctrlPubCatalogItemList);

            }
            else if (catalogFileType == CatalogFileType.RightholderRegister)
            {
                // some code
            }

            ((CatalogFileItemsListViewModel)DataContext).CatalogFileType = catalogFileType;
            ((CatalogFileItemsListViewModel)DataContext).CatalogFile = catalogFile;
        }
    }
}
