using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WidExport
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //var builder = new WidTransBuilder();
            //builder.LoadRespFiles();

        }
        private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(tabMain.SelectedIndex)
            {
                case 0:
                    ucMainWorkGroups.RefreshStatistics();
                    break;
                case 1:
                    ucFileExchange.RefreshControls();
                    break;
                 case 2:
                    ucWidSubmWorksChanges.RefreshControls();
                    break;
                case 3:
                    //ucAuthors.RefreshControls();
                    break;
                case 4:
                    //ucWorks.RefreshControls();
                    break;
                case 5:
                    ucPublishedWorks.RefreshControls();
                    break;
                case 6:
                    ucStatistics.RefreshControls();
                    break;
            }
        }
    }
}
