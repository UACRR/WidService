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
using IPSViewComponentLibraryWPF.Modules.Consumer.ConsumerSmallRight.Register.Model;

namespace IPSViewComponentLibraryWPF.Modules.Consumer.ConsumerSmallRight.Register.CurrencyChange
{
    /// <summary>
    /// Interaction logic for CurrencyChangeWindow.xaml
    /// </summary>
    public partial class CurrencyChangeWindow : Window
    {
        public CurrencyChangeWindow(RegisterModel registerModel)
        {
            InitializeComponent();
            ((CurrencyChangeViewModel) DataContext).RegisterModel = registerModel;
        }
    }
}
