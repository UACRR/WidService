using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RadioStationReports
{
    public partial class UcReportLineWork : UserControl
    {
        private int _reportId;
        private int _lineNr;
        private Work _work;

        private string _textToCopy = "";

        public event EventHandler Changed;

        public UcReportLineWork()
        {
            InitializeComponent();
        }

        private void UcReportLineWork_Load(object sender, EventArgs e)
        {
            Configure();
            Clear();
        }

        private void Configure()
        {
            lvWorks.View = View.Details;
            lvWorks.FullRowSelect = true;
            lvWorks.HeaderStyle = ColumnHeaderStyle.None;
            lvWorks.GridLines = true;
            lvWorks.MultiSelect = false;

            lvWorks.Columns.Add("Параметр", 200);
            lvWorks.Columns.Add("Значення", 200);
        }

        public void Clear()
        {
            _work = null;
            lvWorks.Items.Clear();
        }

        public void Update(int reportId, int lineNr)
        {
            _reportId = reportId;
            _lineNr = lineNr;
            Helpers.RunSql(cmd =>
            {
                _work = Work.CreateFromDb(cmd, reportId, lineNr);
            });

            FillLvWorks();

        }

        private void FillLvWorks()
        {
            lvWorks.Items.Clear();

            AddLvWorkItem("ID", _work.Id);
            AddLvWorkItem("Назва в звіті", _work.Name);
            AddLvWorkItem("Назва в звіті транзлітерована", _work.NameT);
            AddLvWorkItem("Виконавці в звіті", _work.Performers);
            AddLvWorkItem("Виконавці в звіті транзлітеровані", _work.PerformersT);



        }

        private void AddLvWorkItem(string name, object value)
        {
            lvWorks.Items.Add(name).SubItems.Add(value == null ? "" : value.ToString());
        }

        private bool IsEditable(ListViewItem item)
        {
            return false;
        }

        private void lvWorks_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var item = lvWorks.GetItemAt(e.X, e.Y);
                if (item == null)
                {
                    return;
                }
                var text = item.GetSubItemAt(e.X, e.Y).Text;
                _textToCopy = string.IsNullOrEmpty(text) ? "" : text;
                contextMenuStrip.Show(lvWorks, new Point(e.X, e.Y), ToolStripDropDownDirection.BelowRight);
            }
        }

        private void contextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (!string.IsNullOrEmpty(_textToCopy))
            {
                Clipboard.SetText(_textToCopy);
            }
            else
            {
                Clipboard.Clear();
            }
        }
    }
}
