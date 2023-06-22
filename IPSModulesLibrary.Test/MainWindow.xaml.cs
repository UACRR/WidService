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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ipsFormsDesign.Data;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using IPSViewComponentLibraryWPF.Modules.Consumer.ConsumerSmallRight.Register.CreatePaidPeriod;

namespace IPSModulesLibrary.Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var objectrightService = ObjectRightService.GetInstance();
            IpsGlobal.SetObjectRightDictionaries(objectrightService.GetDictionary());

            var rightholderService = new RightholderService();
            IpsGlobal.SetAnketaDictionaties(rightholderService.GetDictionary());
        }

        private void RadButton_Click(object sender, RoutedEventArgs e)
        {
            CreatePaidPeriod p = new CreatePaidPeriod(new LicenseAgreement
            {
                CustId = 1,
                LicClass = 2,
                LicVersion = 1,
                LicenseAgrParam = new ObservableListSource<LicenseAgrParam>
                {
                    new LicenseAgrParam
                    {
                        LicVersion = 1,
                        PeriodCode = 3,
                    }
                },
                LicCode = 12,
                LicCodeNavigation = IpsGlobal.AnketaDictionaties.agrLicenseType.FirstOrDefault(i => i.CodeI == 12),
            });
            p.Show();
        }
    }
}
