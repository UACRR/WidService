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
    public partial class UcPartnerOutputFiles : UserControl
    {
        public UcPartnerOutputFiles()
        {
            InitializeComponent();
        }

        private void UcPartnerOutputFiles_Load(object sender, EventArgs e)
        {
            Configure();
        }

        private void Configure()
        {
            lvFiles.FullRowSelect = true;
            lvFiles.GridLines = true;
            lvFiles.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvFiles.MultiSelect = false;
            lvFiles.View = View.Details;

            lvFiles.Columns.Clear();
            lvFiles.Columns.Add("Код", 100);
            lvFiles.Columns.Add("За період", 100);
            lvFiles.Columns.Add("Назва файлу", 200);
            lvFiles.Columns.Add("Статус", 200);
        }

    }
}
