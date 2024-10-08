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
            labParamName.Visible = false;
            tbValue.Visible = false;
            btnApply.Visible = false;
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

            labParamName.Visible = false;
            tbValue.Visible = false;
            btnApply.Visible = false;
        }

        private void FillLvWorks()
        {
            lvWorks.Items.Clear();

            AddLvWorkItem("ID"                                  , _work.Id          );
            AddLvWorkItem("Назва в звіті"                       , _work.Name        );
            AddLvWorkItem("Назва в звіті транзлітерована"       , _work.NameT       );
            AddLvWorkItem("Автори в звіті"                      , _work.Authors     );
            AddLvWorkItem("Автори в звіті транзлітеровані"      , _work.AuthorsT    );
            AddLvWorkItem("Виконавці в звіті"                   , _work.Performers  );
            AddLvWorkItem("Виконавці в звіті транзлітеровані"   , _work.PerformersT );

            var value = _work.FoundIn == "M" ? "SMART" : _work.FoundIn == "W" ? "WID" : "<Не знайдено>";
            AddLvWorkItem("База даних пов'язаного твору"    , value             );

            value = _work.FoundIn == "M" ? _work.FoundCde.ToString() : "";
            AddLvWorkItem("Код пов'язаного твору в СМАРТ"   , value    );

            value = _work.FoundIn == "W" ? _work.FoundCde.ToString() : "";
            AddLvWorkItem("Код пов'язаного твору в WID"     , value    );

            AddLvWorkItem("Код ISWC пов'язаного твору"      , _work.Iswc       );

            AddLvWorkItem("Проценти до виплати"             , _work.Share       );  
        }

        private void AddLvWorkItem(string name, object value)
        {
            lvWorks.Items.Add(name).SubItems.Add(value == null? "" : value.ToString());
        }

        private bool IsEditable(ListViewItem item)
        {
            return item.Index == 8 || item.Index == 9 || item.Index == 10;
        }

        private string SetObjId(string objId)
        {
            int objIdInt;
            if(!int.TryParse(objId, out objIdInt))
            {
                return "Невірне значення - мусить бути цілим числом.";
            }

            var res = "";
            Helpers.RunSqlT(cmd =>
            {
                cmd.CommandText = "select ObjId from MediaService..ObjectRight where ObjId = @ObjId";
                cmd.Parameters.AddWithValue("@ObjId", objIdInt);
                var foundObjId = Convert.ToInt32(cmd.ExecuteScalar());
                if(foundObjId == 0)
                {
                    res = "Невірне значення - твір з таким кодом не знайдено.";
                    return;
                }

                cmd.CommandText = @"
                    update Works set FoundIn = 'M', FoundCde = @ObjId where Id = @Id
                    update Reports set UpdatedAt = getdate() where Id = @ReportId
                ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ObjId", objIdInt);
                cmd.Parameters.AddWithValue("@Id", _work.Id);
                cmd.Parameters.AddWithValue("@ReportId", _reportId);
                cmd.ExecuteNonQuery();

                cmd.CommandText = "select Iswc from MediaService..MediaTrack where ObjId = @ObjId";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ObjId", objIdInt);
                var iswc = Convert.ToString(cmd.ExecuteScalar());
                if(string.IsNullOrEmpty(iswc))
                {
                    iswc = "";
                }

                cmd.CommandText = "update Works set Iswc = @Iswc where Id = @Id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Iswc", iswc);
                cmd.Parameters.AddWithValue("@Id", _work.Id);
                cmd.ExecuteNonQuery();

                _work.FoundIn = "M";
                _work.FoundCde = foundObjId;
                _work.Iswc = iswc;

            });
            return res;
        }

        private string SetWic(string wic)
        {
            int wicInt;
            if(!int.TryParse(wic, out wicInt))
            {
                return "Невірне значення - мусить бути цілим числом.";
            }

            var res = "";
            Helpers.RunSqlT(cmd =>
            {
                cmd.CommandText = "select Wic from SocWid..WidTitle where Wic = @Wic";
                cmd.Parameters.AddWithValue("@Wic", wicInt);
                var foundWic = Convert.ToInt32(cmd.ExecuteScalar());
                if(foundWic == 0)
                {
                    res = "Невірне значення - твір з таким кодом не знайдено.";
                    return;
                }

                cmd.CommandText = @"
                    update Works set FoundIn = 'W', FoundCde = @Wic where Id = @Id
                    update Reports set UpdatedAt = getdate() where Id = @ReportId
                ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Wic", wicInt);
                cmd.Parameters.AddWithValue("@Id", _work.Id);
                cmd.Parameters.AddWithValue("@ReportId", _reportId);
                cmd.ExecuteNonQuery();

                cmd.CommandText = "select min(PrefIswc) from SocWid..WidIswc where Wic = @Wic";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Wic", wicInt);
                var iswc = Convert.ToString(cmd.ExecuteScalar());
                if(string.IsNullOrEmpty(iswc))
                {
                    iswc = "";
                }

                cmd.CommandText = "update Works set Iswc = @Iswc where Id = @Id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Iswc", iswc);
                cmd.Parameters.AddWithValue("@Id", _work.Id);
                cmd.ExecuteNonQuery();

                _work.FoundIn = "W";
                _work.FoundCde = foundWic;
                _work.Iswc = iswc;

            });
            return res;
        }

        private string SetIswc(string iswc)
        {
            var res = "";
            iswc = iswc.Replace("-", "");
            iswc = iswc.Replace(".", "");
            Helpers.RunSqlT(cmd =>
            {
                cmd.CommandText = "select min(Wic) from SocWid..WidIswc where Iswc = @Iswc";
                cmd.Parameters.AddWithValue("@Iswc", iswc);
                var foundWic = Convert.ToInt32(cmd.ExecuteScalar());
                if(foundWic == 0)
                {
                    res = "Невірне значення - твір з таким кодом не знайдено.";
                    return;
                }

                cmd.CommandText = @"
                    update Works set FoundIn = 'W', FoundCde = @Wic where Id = @Id
                    update Reports set UpdatedAt = getdate() where Id = @ReportId
                ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Wic", foundWic);
                cmd.Parameters.AddWithValue("@Id", _work.Id);
                cmd.Parameters.AddWithValue("@ReportId", _reportId);
                cmd.ExecuteNonQuery();

                cmd.CommandText = "update Works set Iswc = @Iswc where Id = @Id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Iswc", iswc);
                cmd.Parameters.AddWithValue("@Id", _work.Id);
                cmd.ExecuteNonQuery();

                _work.FoundIn = "W";
                _work.FoundCde = foundWic;
                _work.Iswc = iswc;

            });
            return res;
        }
        private void lvWorks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lvWorks.SelectedItems.Count == 0)
            {
                labParamName.Visible = false;
                tbValue.Visible = false;
                btnApply.Visible = false;
                return;
            }

            var selectedItem = lvWorks.SelectedItems[0];

            labParamName.Visible = true;
            labParamName.Text = selectedItem.Text;
            
            tbValue.Visible = true;
            tbValue.Text = selectedItem.SubItems[1].Text;
            tbValue.ReadOnly = !IsEditable(selectedItem);

            btnApply.Visible = IsEditable(selectedItem);
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if(lvWorks.SelectedItems.Count == 0)
            {
                return;
            }

            var selectedIndex = lvWorks.SelectedItems[0].Index;
            var res = "";
            switch(selectedIndex)
            {
                case 8:
                    res = SetObjId(tbValue.Text);
                    break;
                case 9:
                    res = SetWic(tbValue.Text);
                    break;
                case 10:
                    res = SetIswc(tbValue.Text);
                    break;
            }

            if(!string.IsNullOrEmpty(res))
            {
                Helpers.ShowError(res);
            }
            else
            {
                lvWorks.SelectedItems.Clear();
                FillLvWorks();
                lvWorks.SelectedIndices.Add(selectedIndex);
                Changed?.Invoke(null, null);
            }
        }
    }
}
