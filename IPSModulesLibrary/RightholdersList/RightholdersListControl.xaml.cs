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

namespace IPSModulesLibrary.RightholdersList
{
    /// <summary>
    /// Interaction logic for RightholdersListControl.xaml
    /// </summary>
    public partial class RightholdersListControl : UserControl
    {
        public RightholdersListControl()
        {
            InitializeComponent();
            var lang = AppLanguageLibrary.ApplicationCultureInfo.IetfLanguageTag;
            Language = XmlLanguage.GetLanguage(lang);
        }
    }
}
