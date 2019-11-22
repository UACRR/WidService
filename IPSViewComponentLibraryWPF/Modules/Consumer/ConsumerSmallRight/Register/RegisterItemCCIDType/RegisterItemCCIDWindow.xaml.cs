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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace IPSViewComponentLibraryWPF.Modules.Consumer.ConsumerSmallRight.Register.RegisterItemCCIDType
{
    /// <summary>
    /// Interaction logic for RegisterItemCCIDWindow.xaml
    /// </summary>
    public partial class RegisterItemCCIDWindow : Window
    {
        public RegisterItemCCIDWindow(ICollection<object[]> collection, string registerName = null)
        {
            InitializeComponent();
            ((RegisterItemCCIDViewModel) DataContext).Title = registerName;
            ((RegisterItemCCIDViewModel)DataContext).ConvertToInternalModel(collection);
        }
    }
}
