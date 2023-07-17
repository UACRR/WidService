using IPSComponentLibrary.Extensions;
using ipsFormsDesign.Data;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace IPSViewComponentLibraryWPF.Modules.Consumer.ConsumerSmallRight.Register.CreatePaidPeriod
{
    /// <summary>
    /// Interaction logic for CreatePaidPeriod.xaml
    /// </summary>
    public partial class CreatePaidPeriod : Window
    {
        public bool IsDataValid { get; set; } = true;

        public CreatePaidPeriod(LicenseAgreement licenseAgreement)
        {
            InitializeComponent();
            var context = (CreatePaidPeriodViewModel)DataContext;
            context.Init(licenseAgreement, this);
            IsDataValid = context.IsDataValid;
        }
    }
}
