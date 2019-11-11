using System.Windows;
using ipsFormsDesign.Data;
using ipsFormsDesign.Services;

namespace TestWPFControls.Controls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var objectrightService = new ObjectRightService();
            IpsGlobal.SetObjectRightDictionaries(objectrightService.GetDictionary());

            var rightholderService = new RightholderService();
            IpsGlobal.SetAnketaDictionaties(rightholderService.GetDictionary());
        }
    }
}
