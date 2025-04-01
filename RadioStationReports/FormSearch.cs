using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static RadioStationReports.UcSearch;

namespace RadioStationReports
{
    public partial class FormSearch : Form
    {

        public delegate void OnWorkApplied(string code);
        private OnWorkApplied _onWorkApplied;
        public FormSearch()
        {
            InitializeComponent();
        }

        private void FormSearch_Load(object sender, EventArgs e)
        {
        }

        public void SetNamePerformer(string name, string performers, OnWorkApplied onWorkApplied)
        {
            Activate();
            ucSearch.SetNamePerformer(name, 
                performers, 
                x => onWorkApplied(x)
            );
        }

        private void ucSearch_Load(object sender, EventArgs e)
        {

        }
    }
}
