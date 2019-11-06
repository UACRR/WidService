using System;
using System.Windows;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Services;
using IPSViewComponentLibraryWPF.Modules.CopyrightRequest;

namespace TestControls
{
    public sealed partial class WpfControls : Form
    {
        public WpfControls()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            MaximumSize = Size;
            MinimumSize = Size;
            var objectrightService = new ObjectRightService();
            IpsGlobal.SetObjectRightDictionaries(objectrightService.GetDictionary());

            var rightholderService = new RightholderService();
            IpsGlobal.SetAnketaDictionaties(rightholderService.GetDictionary());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Window window = new Window();
            CopyrightRequestControl control = new CopyrightRequestControl();
            window.Content = control;
            window.Show();
        }
    }
}
