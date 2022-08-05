using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LanguageLibrary;
using Telerik.Windows.Controls.GridView;

namespace IPSModulesLibrary.ReportsBRList
{
    /// <summary>
    /// Interaction logic for LicenseBRListControl.xaml
    /// </summary>
    public partial class LicenseBRListControl : UserControl
    {
        public LicenseBRListControl()
        {
            InitializeComponent();
            var lang = AppLanguageLibrary.ApplicationCultureInfo.IetfLanguageTag;
            Language = XmlLanguage.GetLanguage(lang);
        }

        private void GridView_OnDistinctValuesLoading(object sender, GridViewDistinctValuesLoadingEventArgs e)
        {
            // This will make the grid display absolutely all distinct values for 
            // each column regardless of what filters might exist on other columns.
            var filterDistinctValues = false;
            e.ItemsSource = gridView.GetDistinctValues(e.Column, filterDistinctValues);
        }
    }
}
