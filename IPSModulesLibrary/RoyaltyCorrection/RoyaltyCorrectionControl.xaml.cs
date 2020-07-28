using System.Windows.Controls;
using System.Windows.Markup;
using LanguageLibrary;

namespace IPSModulesLibrary.RoyaltyCorrection
{
    /// <summary>
    /// Interaction logic for RoyaltyCorrectionControl.xaml
    /// </summary>
    public partial class RoyaltyCorrectionControl : UserControl
    {
        public RoyaltyCorrectionControl()
        {
            InitializeComponent();
            var lang = AppLanguageLibrary.ApplicationCultureInfo.IetfLanguageTag;
            Language = XmlLanguage.GetLanguage(lang);
        }
    }
}
