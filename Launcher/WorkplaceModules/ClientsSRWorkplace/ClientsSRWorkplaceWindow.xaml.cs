using System.Windows;
using ipsFormsDesign.Dictionary;

namespace Launcher.WorkplaceModules.ClientsSRWorkplace
{
    /// <summary>
    /// Interaction logic for ClientsSRWorkplaceWindow.xaml
    /// </summary>
    public partial class ClientsSRWorkplaceWindow : Window
    {
        public ClientsSRWorkplaceWindow()
        {
            InitializeComponent();
            ImportDbfControl.TypeRights = TypeRights.SmallRights;
        }
    }
}
