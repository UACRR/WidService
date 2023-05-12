using ipsFormsDesign.Model;
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

namespace IPSViewComponentLibraryWPF.Modules.Consumer.ConsumerSmallRight.Register.EditPaidPeriod
{
    /// <summary>
    /// Interaction logic for EditPaidPeriod.xaml
    /// </summary>
    public partial class EditPaidPeriod : Window
    {
        public EditPaidPeriod(PaidPeriod period)
        {
            InitializeComponent();
            ((EditPaidPeriodViewModel)DataContext).Period = period;
        }
    }
}
