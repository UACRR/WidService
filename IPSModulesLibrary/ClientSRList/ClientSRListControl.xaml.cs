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

namespace IPSModulesLibrary.ClientSRList
{
    /// <summary>
    /// Interaction logic for ClientSRListControl.xaml
    /// </summary>
    public partial class ClientSRListControl : UserControl
    {
        public ClientSRListControl()
        {
            InitializeComponent();
            var lang = AppLanguageLibrary.ApplicationCultureInfo.IetfLanguageTag;
            Language = XmlLanguage.GetLanguage(lang);
        }
    }
}
