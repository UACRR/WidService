using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CwrTools.MetaData;

namespace CwrTools
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.FormMainSize.Width > 0 && Properties.Settings.Default.FormMainSize.Height > 0)
            {
                //this.Location = Properties.Settings.Default.FormMainLocation;
                //this.Size = Properties.Settings.Default.FormMainSize;
                //this.WindowState = Properties.Settings.Default.FormMainState;
            }

            tabMain.SelectedIndex = 0;
       }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabMain.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    ucInputFiles.RefreshData();
                    break;
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.FormMainLocation = this.Location;
            Properties.Settings.Default.FormMainSize = this.Size;
            Properties.Settings.Default.FormMainState = this.WindowState;

            Properties.Settings.Default.UcProblemWorksSplitterDistance = ucProblemWorks.GetSplitterDistance();

            Properties.Settings.Default.Save();
        }
    }
}
