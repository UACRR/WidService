using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RadioStationReports
{
    public partial class UcReportLineWork : UserControl
    {
        public UcReportLineWork()
        {
            InitializeComponent();
        }

        private void UcReportLineWork_Load(object sender, EventArgs e)
        {
            lvInfo.MultiSelect = false;
            lvInfo.FullRowSelect = true;
            lvInfo.GridLines = true;
            lvInfo.View = View.Details;
            lvInfo.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvInfo.Font = new Font(lvInfo.Font, FontStyle.Bold);
            lvInfo.BackColor = Color.FloralWhite;
            lvInfo.Height = 10;

            lvInfo.Columns.Add("Параметри", 260);
            lvInfo.Columns.Add("За кодом СМАРТ", 150);
            lvInfo.Columns.Add("За кодом WID", 150);

            var item = lvInfo.Items.Add("Назва твору");
            item.Font = new Font(item.Font, FontStyle.Regular);

            item = lvInfo.Items.Add("Правовласники");
            item.Font = new Font(item.Font, FontStyle.Bold | FontStyle.Italic);

            AddRightHolder();
            AddRightHolder();
            AddRightHolder();

        }

        private void AddItem(string title, string msValue, string widValue)
        {
            var item = lvInfo.Items.Add(title);
            item.SubItems.Add(msValue);
            item.SubItems.Add(widValue);
            item.Font = new Font(item.Font, FontStyle.Regular);
        }

        private void AddRightHolder()
        {
            AddItem("    Назва"                         , "asfdasds dd dds" , "@@@@@@@");
            AddItem("        Код СМАРТ"                 , "1325"            , "0");
            AddItem("        Міжнародни код (базовий)"  , "2433567"         , "0");
            AddItem("        Міжнародни код (назва)"    , "2433567"         , "0");
            AddItem("        Проценти Пуб"              , "34"              , "0");
            AddItem("        Проценти Пуб"              , "0"               , "12");
        }



        public void Clear()
        {

        }

        public void Update(int reportId, int lineNr)
        {

        }

    }
}
