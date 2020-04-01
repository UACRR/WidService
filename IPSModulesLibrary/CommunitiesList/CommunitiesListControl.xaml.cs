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

namespace IPSModulesLibrary.CommunitiesList
{
    /// <summary>
    /// Interaction logic for CommunitiesListControl.xaml
    /// </summary>
    public partial class CommunitiesListControl : UserControl
    {
        public CommunitiesListControl()
        {
            InitializeComponent();
            var lang = AppLanguageLibrary.ApplicationCultureInfo.IetfLanguageTag;
            Language = XmlLanguage.GetLanguage(lang);
        }
    }
}
