using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.ConsumerForms
{
    public partial class CabinetBigRightForm : RadForm
    {
        private const string DefaultTitle = "Кабінет користувача";
        public CabinetBigRightForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            WindowState = FormWindowState.Maximized;
        }

        public string Title
        {
            get => Text;
            set => Text = string.IsNullOrWhiteSpace(value) ? DefaultTitle : string.Concat(DefaultTitle, $": {value}");
        }

        public bool IsInit { get; set; } = false;

        private void CabinetBigRightForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
