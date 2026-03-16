using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WidSubmit
{
    public partial class FormTest : Form
    {
        public class Share
        {
            public int      SubmWorkId       { get; set; }
            public int      RightHolderId    { get; set; }
            public int      RhCustId         { get; set; }
            public string   RhIpBaseNr       { get; set; }
            public int?     RhIpNameNr       { get; set; }
            public string   RhName           { get; set; }
            public string   RhNameForWid     { get; set; }
            public string   RhTypeName       { get; set; }
            public string   RhRoleName       { get; set; }
            public string   RhRoleForWid     { get; set; }
            public bool     RhIsOwn          { get; set; }
            public bool     RhIsActive       { get; set; }
            public decimal  RhShrPer         { get; set; }
            public decimal  RhShrMec         { get; set; }
        }

        private int _widSubmWorkId = 16706;
        private List<Share> _shares;

        public FormTest()
        {
            InitializeComponent();
        }

        private void FormTest_Load(object sender, EventArgs e)
        {
            Configure();
            LoadShares();
            FillLvSubmWorkShares();
        }

        private void Configure()
        {
           lvSubmWorkShares.FullRowSelect = true;
           lvSubmWorkShares.GridLines = true;
           lvSubmWorkShares.HeaderStyle = ColumnHeaderStyle.Nonclickable;
           lvSubmWorkShares.MultiSelect = false;
           lvSubmWorkShares.View = View.Details;
           
           lvSubmWorkShares.Columns.Clear();
           lvSubmWorkShares.Columns.Add("Код СМАРТ", 80);
           lvSubmWorkShares.Columns.Add("Назва СМАРТ", 100);
           lvSubmWorkShares.Columns.Add("Роль WID", 70);
           lvSubmWorkShares.Columns.Add("Пуб %", 50);
           lvSubmWorkShares.Columns.Add("Мех %", 50);
        }

        private void LoadShares()
        {
            Helpers.RunSqlSocWidSubmitEx(cmd =>
            {
                cmd.CommandText = @"
                    select
                          SubmWorkId   
                        , RightHolderId
                        , RhCustId       
                        , RhIpBaseNr     
                        , RhIpNameNr     
                        , RhName      
                        , RhNameForWid
                        , RhTypeName     
                        , RhRoleName     
                        , RhRoleForWid   
                        , RhIsOwn        
                        , RhIsActive     
                        , RhShrPer       
                        , RhShrMec      
                    from vSubmWorkShares
                    where SubmWorkId = @submWorkId
                    order by RhName
                ";
                cmd.Parameters.AddWithValue("@submWorkId", _widSubmWorkId);
                using (var r = cmd.ExecuteReader())
                {
                    _shares = new List<Share>();
                    while (r.Read())
                    {
                        var idx = 0;
                        var share = new Share();
                        share.SubmWorkId    = r.GetInt32(idx);                                  idx++;
                        share.RightHolderId = r.GetInt32(idx);                                  idx++;
                        share.RhCustId      = r.GetInt32(idx);                                  idx++;
                        share.RhIpBaseNr    = r.IsDBNull(idx) ? "" : r.GetString(idx);          idx++;
                        share.RhIpNameNr    = r.IsDBNull(idx) ? (int?)null : r.GetInt32(idx);   idx++;
                        share.RhName        = r.GetString(idx);                                 idx++;
                        share.RhNameForWid  = r.GetString(idx);                                 idx++;
                        share.RhTypeName    = r.GetString(idx);                                 idx++;
                        share.RhRoleName    = r.GetString(idx);                                 idx++;
                        share.RhRoleForWid  = r.GetString(idx);                                 idx++;
                        share.RhIsOwn       = r.GetBoolean(idx);                                idx++;
                        share.RhIsActive    = r.GetBoolean(idx);                                idx++;
                        share.RhShrPer      = r.GetDecimal(idx);                                idx++;
                        share.RhShrMec      = r.GetDecimal(idx);                                idx++;

                        _shares.Add(share);
                    }
                }
            });
        }

        private void FillLvSubmWorkShares()
        {
            lvSubmWorkShares.BeginUpdate();
            lvSubmWorkShares.Items.Clear();
            _shares.ForEach(x =>
            {
                var item = new ListViewItem(x.RhCustId.ToString());
                item.SubItems.Add(x.RhName);
                item.SubItems.Add(x.RhRoleForWid);
                item.SubItems.Add(x.RhShrPer.ToString());
                item.SubItems.Add(x.RhShrMec.ToString());
                item.Tag = x;
                lvSubmWorkShares.Items.Add(item);
            });
            lvSubmWorkShares.EndUpdate();
        }

        private void lvSubmWorkShares_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Green, e.Bounds);
            TextRenderer.DrawText(e.Graphics
                , e.Header.Text
                , e.Font
                , new Point(0, 0)
                , Color.Brown);
        }

        private void lvSubmWorkShares_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();
            if (e.Item.ListView.View != View.Details)
            {
                e.DrawText();
            }
        }

        private void lvSubmWorkShares_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            if (e.ColumnIndex == 1) // Column index 1 is the "Value" column
            {
                if (e.SubItem.Text.StartsWith("-"))
                {
                    // Draw a custom background and red text
                    e.Graphics.FillRectangle(Brushes.Black, e.Bounds);
                    TextRenderer.DrawText(e.Graphics, e.SubItem.Text, 
                                          e.Item.Font, e.Bounds, Color.Red, 
                                          TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
                    return; // Return after custom drawing
                }
            }

            // Use e.DrawText() or custom Graphics methods to render the subitem's content
            e.DrawText();
        }
    }
}
