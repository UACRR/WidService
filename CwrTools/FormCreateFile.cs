using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace CwrTools
{
    public partial class FormCreateFile : Form
    {
        private CwrFileWriter _writer;
        public FormCreateFile()
        {
            InitializeComponent();
        }
        private void FormCreateFile_Load(object sender, EventArgs e)
        {
            _writer = new CwrFileWriter();
            tbFileName.Text = _writer.FormatFileName();
            tbFolderFullName.Text = @"D:\OlegM\Sources\WidService\CwrTools\TestData\Out\";

            btnShowInFolder.Visible = false;
            labResult.Text = "Створення файлу не розпочато";
        }

        private void btnCreateFile_Click(object sender, EventArgs e)
        {
            if(!Directory.Exists(tbFolderFullName.Text))
            {
                MessageBox.Show("Фолдер не існує!", "Створення файлу", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(File.Exists(Path.Combine(tbFolderFullName.Text, tbFileName.Text)))
            {
                var res = MessageBox.Show("Файл існує, переписати?", "Створення файлу", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(res == DialogResult.No)
                    return;
            }

            btnShowInFolder.Visible = false;
            labResult.Visible = false;
            //try
            //{
                Cursor.Current = Cursors.WaitCursor;
                _writer.CreateFile(tbFolderFullName.Text);
                btnShowInFolder.Visible = true;
                labResult.Text = "Файл створено";
                labResult.ForeColor = Color.Black;
            //}
            //catch (Exception ex)
            //{
            //    btnShowInFolder.Visible = false;
            //    labResult.Text = ex.Message;
            //    labResult.ForeColor = Color.Red;
            //}
            //finally
            //{
            //    labResult.Visible = true;
            //    Cursor.Current = Cursors.Default;
            //}
        }

        private void btnCLose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnShowInFolder_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", "/select, " + Path.Combine(tbFolderFullName.Text, tbFileName.Text));
        }

    }
}
