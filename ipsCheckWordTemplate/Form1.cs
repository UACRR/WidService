using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ipsCheckWordTemplate
{
    public partial class Form1 : Form
    {
        private ManagerCheck _managerCheck;
        public Form1()
        {
            InitializeComponent();
            _managerCheck = new ManagerCheck();

            string initTags = Path.Combine( Directory.GetCurrentDirectory(), "Tag.txt" );
            if( File.Exists(initTags ) )
            {
                labelFileNameTag.Text = initTags;
                _managerCheck.OpenValidTag(initTags);
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text file (*.txt)|*.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                labelFileNameTag.Text = openFileDialog1.FileName;
                _managerCheck.OpenValidTag(openFileDialog1.FileName);
                if (_managerCheck.IsInit)
                    bindingSourceForTag.DataSource = _managerCheck.CheckTag();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Word file (*.docx)|*.docx";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                labelFileNameWord.Text = openFileDialog1.FileName;
                _managerCheck.OpenWord(openFileDialog1.FileName);
                bindingSourceForTag.DataSource = _managerCheck.CheckTag();
            }
        }
    }
}
