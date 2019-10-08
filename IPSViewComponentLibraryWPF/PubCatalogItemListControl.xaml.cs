using ipsFormsDesign.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Documents.SpreadsheetStreaming;
using Telerik.Windows.Documents.Spreadsheet.Model;
using Telerik.Windows.Controls.GridView.SpreadsheetStreamingExport;
using System.Threading.Tasks;
using System.ComponentModel;

namespace IPSViewComponentLibraryWPF
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class PubCatalogItemListControl : UserControl
    {
        private readonly PubCatalogItemListControlViewModel _model;

        public PubCatalogItemListControl()
        {
            InitializeComponent();
            _model = new PubCatalogItemListControlViewModel();
            DataContext = _model;
            this.Language = System.Windows.Markup.XmlLanguage.GetLanguage(Thread.CurrentThread.CurrentCulture.Name);
        }

        public void LoadData(ICollection<object[]> items)
        {
            _model.LoadData(items);
        }

        public void Export(string fileName)
        {
            _model.Export(fileName);
        }
    }
}
