using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CwrTools
{
    public partial class FormEditText : Form
    {
        private string _title;
        private string _inputText;
        public string OutputText { get; private set;}

        public FormEditText(string title, string inputText)
        {
            InitializeComponent();

            _title = title;
            _inputText = inputText;
        }

        private void FormEditText_Load(object sender, EventArgs e)
        {
            labTitle.Text = _title;
            tbText.Text = _inputText;

            btnApply.Enabled = false;
        }

        private void tbText_TextChanged(object sender, EventArgs e)
        {
            btnApply.Enabled = true;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            OutputText= tbText.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
