using System;
using System.Windows;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Services;
using IPSViewComponentLibraryWPF.Modules.CopyrightRequest;
using IPSViewComponentLibraryWPF.Modules.Document.DocumentViewer;

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

            DocumentViewerWindow window = new DocumentViewerWindow();
            window.Show();
        }
    }
}
