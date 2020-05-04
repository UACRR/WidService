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

namespace IPSModulesLibrary.FinishingWorks
{
    /// <summary>
    /// Interaction logic for FinishingWorksControl.xaml
    /// </summary>
    public partial class FinishingWorksControl : UserControl
    {
        public FinishingWorksControl()
        {
            InitializeComponent();
            var lang = AppLanguageLibrary.ApplicationCultureInfo.IetfLanguageTag;
            Language = XmlLanguage.GetLanguage(lang);
        }

        private void RadDateTimePicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
