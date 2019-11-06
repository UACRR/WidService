using System;
using System.Windows;
using System.Windows.Forms;
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
