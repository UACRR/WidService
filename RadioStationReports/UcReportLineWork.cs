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
using static RadioStationReports.UcReportLineWork;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RadioStationReports
{
    public partial class UcReportLineWork : UserControl
    {
        public class Share
        {
		    public string SmartCodeM           { get; set; } 
		    public string IpBaseNrM            { get; set; }
		    public string IpNameNrM            { get; set; }
		    public string RightHolderNameM     { get; set; }
		    public string RightStartDateM      { get; set; }
		    public string RightEndDateM        { get; set; }
		    public string ShareM               { get; set; }

            public string SmartCodeW           { get; set; }
		    public string IpBaseNrW            { get; set; }
		    public string IpNameNrW            { get; set; }
		    public string RightHolderNameW     { get; set; }
		    public string RightStartDateW      { get; set; }
		    public string RightEndDateW        { get; set; }
		    public string ShareW               { get; set; }

        }

        public class Info
        {
            public string WorkNameM { get; set; }
            public string WorkNameW { get; set; }
            public List<Share> Shares { get; set; }
        }

        private int _workId = 0;
        private int? _objId = null;   
        private int? _wic = null;
        private string _iswc = "";

        private Info _info;

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

        }

        public void Clear()
        {

        }

        private string ConvertDbInt(SqlDataReader r, int idx) => r.IsDBNull(idx) ? "" : r.GetInt32(idx).ToString();
        private string ConvertDbDec(SqlDataReader r, int idx) => r.IsDBNull(idx) ? "" : r.GetDecimal(idx).ToString();
        private string ConvertDbString(SqlDataReader r, int idx) => r.IsDBNull(idx) ? "" : r.GetString(idx);
        private string ConvertDbDate(SqlDataReader r, int idx) => r.IsDBNull(idx) ? "" : r.GetDateTime(idx).ToString("yyyy-MM-dd");

        public void Update(int reportId, int lineNr)
        {
            lvInfo.Items.Clear();
            _info = new Info();

            Helpers.RunSql(cmd =>
            {
                cmd.CommandText = @"
                    select t2.Id, t2.ObjId, t2.Wic, t2.Iswc
                    from ReportLines t1
	                    join Works t2 on t1.WorkId = t2.Id
                    where ReportId = @reportId and LineNr = @lineNr
                ";
                cmd.Parameters.AddWithValue("reportId", reportId);
                cmd.Parameters.AddWithValue("lineNr", lineNr);
                using (var r = cmd.ExecuteReader())
                {
                    r.Read();
                    _workId = r.GetInt32(0);
                    _objId = r.IsDBNull(1) ? null : r.GetInt32(1);
                    _wic = r.IsDBNull(2) ? null : r.GetInt32(2);
                    _iswc = r.IsDBNull(3) ? "" : r.GetString(3);
                }

                _info.WorkNameM = "";
                if(_objId != null)
                {
                    cmd.CommandText = @"select Name from MediaService..ObjectRight where ObjId = @objId";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@objId", _objId);
                    _info.WorkNameM = (string)cmd.ExecuteScalar();
                }

                _info.WorkNameW = "";
                if(_wic != null)
                {
                    cmd.CommandText = @"select WrkTtl from SocWid..WidTitle where Wic = @wic";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@wic", _wic);
                    var res = cmd.ExecuteScalar();
                    _info.WorkNameW = res == null ? "!!! Твір не знайдено" : (string)cmd.ExecuteScalar();
                }
                
                _info.Shares = new List<Share>();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spCompareSharesMsVsWid";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@objId", _objId == null ? DBNull.Value : _objId);
                cmd.Parameters.AddWithValue("@wic", _wic == null ? DBNull.Value : _wic);
                using (var r = cmd.ExecuteReader())
                {
                    while(r.Read())
                    {
                        var share = new Share();
                        var idx = 0;
		                share.SmartCodeM           = ConvertDbInt(r, idx++);
		                share.IpBaseNrM            = ConvertDbString(r, idx++);
		                share.IpNameNrM            = ConvertDbInt(r, idx++);
		                share.RightHolderNameM     = ConvertDbString(r, idx++);
		                share.RightStartDateM      = ConvertDbDate(r, idx++);
		                share.RightEndDateM        = ConvertDbDate(r, idx++);
		                share.ShareM               = ConvertDbDec(r, idx++);
                        idx++;
                        share.SmartCodeW           = ConvertDbInt(r, idx++);
		                share.IpBaseNrW            = ConvertDbString(r, idx++);
		                share.IpNameNrW            = ConvertDbInt(r, idx++);
		                share.RightHolderNameW     = ConvertDbString(r, idx++);
		                share.RightStartDateW      = ConvertDbDate(r, idx++);
                        share.RightEndDateW        = ConvertDbDate(r, idx++);
		                share.ShareW               = ConvertDbDec(r, idx++);
 
                        _info.Shares.Add(share);
                    }
                }
            });

            AddItem("Назва твору", _info.WorkNameM.ToString(), _info.WorkNameW.ToString());

            var item = lvInfo.Items.Add("Правовласники");
            item.Font = new Font(item.Font, FontStyle.Bold | FontStyle.Italic);

            _info.Shares.ForEach(s => AddRightHolder(s));

        }


        private void AddItem(string title, string msValue, string widValue)
        {
            var item = lvInfo.Items.Add(title);
            item.SubItems.Add(msValue);
            item.SubItems.Add(widValue);
            item.Font = new Font(item.Font, FontStyle.Regular);
        }

        private void AddRightHolder(Share s)
        {
            AddItem("    Назва"                         , s.RightHolderNameM , s.RightHolderNameW);
            AddItem("        Код СМАРТ"                 , s.SmartCodeM , s.SmartCodeW);
            AddItem("        Міжнародни код (базовий)"  , s.IpBaseNrM , s.IpBaseNrW);
            AddItem("        Міжнародни код (назва)"    , s.IpNameNrM , s.IpNameNrW);
            AddItem("        Початок правоволодіння"    , s.RightStartDateM , s.RightStartDateW);
            AddItem("        Закінчення правоволодіння" , s.RightEndDateM , s.RightEndDateW);
            AddItem("        Проценти Пуб"              , s.ShareM , s.ShareW);
        }




    }
}
