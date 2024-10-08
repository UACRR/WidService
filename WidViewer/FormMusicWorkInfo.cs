using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WidViewer
{
    public partial class FormMusicWorkInfo : Form
    {
        private int _wic;
        private string _text;
        public FormMusicWorkInfo(int wic, string text)
        {
            _wic = wic;
            _text = text;
            InitializeComponent();
        }

        private void FormMusicWorkInfo_Load(object sender, EventArgs e)
        {
            timerLoad.Enabled = true;
            Text = $"{Text} {_text}";
        }

        private void timerLoad_Tick(object sender, EventArgs e)
        {
            timerLoad.Enabled = false;
            ucMisicWorkInfo.RefreshAll(_wic);
        }
    }
}
