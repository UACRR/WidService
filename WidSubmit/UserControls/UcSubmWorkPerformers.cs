using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WidSubmit;
using static WidSubmit.UcSubmWorkPerformers;
using static WidSubmit.UcSubmWorkCheckList;

namespace WidSubmit
{
    public partial class UcSubmWorkPerformers : UserControl
    {
        public class WorkPerformer
        {
           public int    SubmWorkId       { get; set; }
           public string NameForWid       { get; set; }
           public string OrigNames        { get; set; }
         }

        public delegate void Changed();
        public event Changed ChangedEvent;


        private int _submWorkId;
        private List<WorkPerformer> _workPerformers;

        public UcSubmWorkPerformers()
        {
            InitializeComponent();
        }

        private void UcSubmWorkPerformers_Load(object sender, EventArgs e)
        {
            Configure();
        }

        private void Configure()
        {
            lvPerformers.FullRowSelect = true;
            lvPerformers.GridLines = true;
            lvPerformers.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvPerformers.MultiSelect = false;
            lvPerformers.View = View.Details;

            lvPerformers.Columns.Add("Назва в WID", 200);
            lvPerformers.Columns.Add("Оригінальні назви", 400);
        }

         public void ClearContent()
        {
            _submWorkId = 0;
            lvPerformers.Items.Clear();
        }

        public void UpdateContent(int submWorkId)
        {
            _submWorkId = submWorkId;
            LoadNames();
            FilllvPerformers();
        }

        private void LoadNames()
        {
            Helpers.RunSqlSocWidSubmitEx(cmd =>
            {
                cmd.CommandText = @"
                    select SubmWorkId, NameForWid, OrigNames
	                from SubmWorkPerformer
	                where SubmWorkId = @submWorkId
                ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@submWorkId", _submWorkId);
                
                using (var r = cmd.ExecuteReader())
                {
                    _workPerformers = new List<WorkPerformer>();
                    while (r.Read())
                    {
                        var idx = 0;
                        var work = new WorkPerformer();
                        work.SubmWorkId = r.GetInt32(idx);  idx++;
	                    work.NameForWid = r.GetString(idx); idx++;
	                    work.OrigNames  = r.GetString(idx); idx++;
	                    
                        _workPerformers.Add(work);
                    }
                }

                _workPerformers.OrderBy(x => x.NameForWid);
            });
        }

        private void FilllvPerformers()
        {
            lvPerformers.Items.Clear();
            _workPerformers.ForEach(x =>
            {
                var item = new ListViewItem(x.NameForWid);
                item.SubItems.Add(x.OrigNames);
                item.Tag = x;
                lvPerformers.Items.Add(item);
            });
         }

    }
}
