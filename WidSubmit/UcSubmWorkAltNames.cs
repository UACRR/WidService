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
using static WidSubmit.UcSubmWorkAltNames;
using static WidSubmit.UcSubmWorkCheckList;

namespace WidSubmit
{
    public partial class UcSubmWorkAltNames : UserControl
    {
        public class WorkAltName
        {
           public int    SubmWorkId       { get; set; }
           public string NameForWid       { get; set; }
           public string OrigNames        { get; set; }
         }

        public delegate void Changed();
        public event Changed ChangedEvent;


        private int _submWorkId;
        private List<WorkAltName> _workAltNames;

        public UcSubmWorkAltNames()
        {
            InitializeComponent();
        }

        private void UcWidSubmNames_Load(object sender, EventArgs e)
        {
            Configure();
        }

        private void Configure()
        {
            lvNames.FullRowSelect = true;
            lvNames.GridLines = true;
            lvNames.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvNames.MultiSelect = false;
            lvNames.View = View.Details;

            lvNames.Columns.Add("Назва в WID", 200);
            lvNames.Columns.Add("Оригінальні назви", 400);
        }

         public void ClearContent()
        {
            _submWorkId = 0;
            lvNames.Items.Clear();
        }

        public void UpdateContent(int submWorkId)
        {
            _submWorkId = submWorkId;
            LoadNames();
            FillLvNames();
        }

        private void LoadNames()
        {
            Helpers.RunSqlSocWidSubmitEx(cmd =>
            {
                cmd.CommandText = @"
                    select SubmWorkId, NameForWid, OrigNames
	                from SubmWorkAltName
	                where SubmWorkId = @submWorkId
                ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@submWorkId", _submWorkId);
                
                using (var r = cmd.ExecuteReader())
                {
                    _workAltNames = new List<WorkAltName>();
                    while (r.Read())
                    {
                        var idx = 0;
                        var work = new WorkAltName();
                        work.SubmWorkId = r.GetInt32(idx);  idx++;
	                    work.NameForWid = r.GetString(idx); idx++;
	                    work.OrigNames  = r.GetString(idx); idx++;
	                    
                        _workAltNames.Add(work);
                    }
                }

                _workAltNames.OrderBy(x => x.NameForWid);
            });
        }

        private void FillLvNames()
        {
            lvNames.Items.Clear();
            _workAltNames.ForEach(x =>
            {
                var item = new ListViewItem(x.NameForWid);
                item.SubItems.Add(x.OrigNames);
                item.Tag = x;
                lvNames.Items.Add(item);
            });
         }

    }
}
