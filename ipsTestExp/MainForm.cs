using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ipsTestExp;
using System.Windows.Forms;
using sysAdminwp;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using WebAPIConnector;


namespace ipsTestExp
{
    public partial class MainForm:RadForm
    {
        private readonly ApiConnector conn = new ApiConnector("http://localhost:54867/");


        public MainForm()
        {
            
            InitializeComponent();
            LoadControls();
        }

        private void LoadControls()
        {
            dataEditControl.InitializeConnector(conn);
            dataEditControl.Url = "api/dictionary/base/activitytype";
            dataEditControl.ViewData();
            dataEditControl.LoadOverviewCfg();

        }
    }
}
