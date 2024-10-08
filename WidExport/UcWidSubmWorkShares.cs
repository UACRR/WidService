using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WidExport
{
    public partial class UcWidSubmWorkShares : UserControl
    {
        public class Share
        {
            public int CopyRightId { get; set; }
            public int CustId { get; set; }
            public string IpBaseNr { get; set; }
            public int? IpNameNr { get; set; }
            public int RhType { get; set; }
            public int RhRole { get; set; }
            public bool AggrLocal { get; set; }
            public bool AggrIpiPer { get; set; }
            public bool AggrIpiMec { get; set; }
            public decimal? PerShr { get; set; }
            public decimal? MecShr { get; set; }
            public string ModifiedBy { get; set; }
        }

        public delegate void Changed();

        private int? _groupId;
        private int? _objId;

        private List<Share> _shares;

        public UcWidSubmWorkShares()
        {
            InitializeComponent();
        }

        private void UcWidSubmWorkShares_Load(object sender, EventArgs e)
        {
            lvShares.Columns.Add("CustId", 55);
            lvShares.Columns.Add("IpNameNr", 80);
            lvShares.Columns.Add("Тип", 50);
            lvShares.Columns.Add("Роль", 90);
            lvShares.Columns.Add("Пуб %", 50);
            lvShares.Columns.Add("Мех %", 50);
            lvShares.Columns.Add("Дог лок", 50);
            lvShares.Columns.Add("Дог пуб IPI", 50);
            lvShares.Columns.Add("Дог мех IPI", 50);

            lvShareDetails.Columns.Add("Параметр", 100);
            lvShareDetails.Columns.Add("Значення", 200);
        }

        public void SetGroupAndObjId(int? groupId, int? objId)
        {
            _groupId = groupId;
            _objId = objId;
            FillShares();
        }

        private void FillShares()
        {
            lvShares.Items.Clear();
            lvShareDetails.Items.Clear();

            if(_groupId == null || _objId == null)
            {
                return;
            }

            Helpers.RunSqlSocWidSubmit(cmd =>
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spMsWorkSharesSelect";
                cmd.Parameters.AddWithValue("@WidSubmGroupId", _groupId);
                cmd.Parameters.AddWithValue("@objId", _objId);
                using (var r = cmd.ExecuteReader())
                {
                    _shares = new List<Share>();
                    while (r.Read())
                    {
                        _shares.Add(new Share
                        {
                            CopyRightId = r.GetInt32(0),
                            CustId = r.GetInt32(1),
                            IpBaseNr = r.IsDBNull(2) ? "" : r.GetString(2),
                            IpNameNr = r.IsDBNull(3) ? (int?)null : r.GetInt32(3),
                            RhType = r.GetInt32(4),
                            RhRole = r.GetInt32(5),
                            AggrLocal = r.GetBoolean(6),
                            AggrIpiPer = r.GetBoolean(7),
                            AggrIpiMec = r.GetBoolean(8),
                            PerShr = r.IsDBNull(9) ? (decimal?)null : r.GetDecimal(9),
                            MecShr = r.IsDBNull(10) ? (decimal?)null : r.GetDecimal(10),
                            ModifiedBy = r.GetString(11),
                        }); ;
                    }
                }
            });
            lvShares.Items.Clear();
            _shares.ForEach(x =>
            {
                var lvItem = lvShares.Items.Add(x.CustId.ToString());
                lvItem.SubItems.Add(x.IpNameNr.ToString());
                lvItem.SubItems.Add(WidSubmWorkCheckList.RhType[x.RhType]);
                lvItem.SubItems.Add(WidSubmWorkCheckList.RhRole[x.RhRole]);
                lvItem.SubItems.Add(x.PerShr.ToString());
                lvItem.SubItems.Add(x.MecShr.ToString());
                lvItem.SubItems.Add(x.AggrLocal.ToString());
                lvItem.SubItems.Add(x.AggrIpiPer.ToString());
                lvItem.SubItems.Add(x.AggrIpiMec.ToString());

                lvItem.Tag = x;
            });
        }

        private void lvShares_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvShareDetails.Items.Clear();
            if (lvShares.SelectedItems.Count == 0)
            {
                return;
            }
            var author = (Share)lvShares.SelectedItems[0].Tag;
            Helpers.RunSqlSocWidSubmit(cmd =>
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spMsWorkShareDetails";
                cmd.Parameters.AddWithValue("@widSubmGroupId", _groupId);
                cmd.Parameters.AddWithValue("@cRightId", author.CopyRightId);
                if (author == null || author.IpNameNr == null)
                {
                    cmd.Parameters.AddWithValue("@ipNameNr", 0);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ipNameNr", author.IpNameNr);
                }
                using (var r = cmd.ExecuteReader())
                {
                    r.Read();
                    var item = lvShareDetails.Items.Add("Локальне ім'я");
                    item.SubItems.Add(r.IsDBNull(4) ? "" : r.GetString(4));

                    item = lvShareDetails.Items.Add("Ім'я в базі IPI");
                    item.SubItems.Add(r.IsDBNull(5) ? "" : r.GetString(5));

                    item = lvShareDetails.Items.Add("Локальний договір");
                    item.SubItems.Add(r.GetBoolean(6) ? "Так" : "Ні");

                    item = lvShareDetails.Items.Add("Пуб договір IPI");
                    item.SubItems.Add(r.GetBoolean(7) ? "Так" : "Ні");

                    item = lvShareDetails.Items.Add("Мех договір IPI");
                    item.SubItems.Add(r.GetBoolean(8) ? "Так" : "Ні");

                }
            });
        }
    }
}
