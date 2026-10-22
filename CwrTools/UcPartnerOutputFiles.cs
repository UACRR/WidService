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
        private enum FileStatus
        {
            Planned = 1,
            Awaiting   ,
            Sent       ,
            Accepted   ,
            Rejected   ,
        }

        private string[] FileStatusTitle =
        {
            "Заплановано",
            "До передачі",
            "Передланий",
            "Прийнятий",
            "Відхилений",
        };

        private string[] PeriodTypeTitle =
        {
            "Місяць",
            "Квартал",
            "Півріччя",
            "Рік",
        };

        public class PartnerInfo
        {
            public int Id { get; set; }
            public int PartnerGroupId { get; set; }
            public string Name { get; set; }
            public int PeriodTypeId { get; set; }
        }

        public class FileInfo
        {
            public int       FileId          { get; set; }
            public int       FileStatus      { get; set; }
            public string    FileName        { get; set; }
            public DateTime? FileSentAt      { get; set; }
            public DateTime? FileAnsweredAt  { get; set; }
            public int       PeriodId        { get; set; }
            public int       PeriodYear      { get; set; }
            public int       PeriodPoint     { get; set; }
            public string    BaseFileName    { get; set; }
            public DateTime  PeriodStartDate { get; set; }
            public DateTime  PeriodEndDate   { get; set; }
        }

        private PartnerGroupInfo _groupInfo;
        private PartnerInfo _partnerInfo;
        private List<FileInfo> _fileInfoList;

        public UcPartnerOutputFiles()
        {
            InitializeComponent();
        }

        private void UcPartnerOutputFiles_Load(object sender, EventArgs e)
        {
        }

        public void RefreshData(int partnerId)
        {
            LoadPartnerInfo(partnerId);
            LoadPartnerGroupInfo();
            Configure();
            PlanPartnerDeliveries();
            UpdateNames();
            LoadPartnerFiles();
            FillPartnerFiles();
            UpdateDetails();
        }

        private void Configure()
        {
            lvFiles.FullRowSelect = true;
            lvFiles.GridLines = true;
            lvFiles.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvFiles.MultiSelect = false;
            lvFiles.View = View.Details;

            lvFiles.Columns.Clear();
            lvFiles.Columns.Add("Код", 60);
            lvFiles.Columns.Add("Рік", 60);
            if(_partnerInfo.PeriodTypeId != 4)
                lvFiles.Columns.Add("", 60);
            lvFiles.Columns.Add("Статус", 100);
        }

        private void LoadPartnerGroupInfo()
        {
            Helpers.RunSqlCwr(cmd =>
            {
                cmd.CommandText = "select * from PartnerGroups where Id = @id";
                cmd.Parameters.AddWithValue("@id", _partnerInfo.PartnerGroupId);
                using(var r = cmd.ExecuteReader())
                {
                    r.Read();
                    _groupInfo = new PartnerGroupInfo
                    {
                        Id = r.GetInt32(0),
                        Name = r.GetString(1),
                        IsStandard = r.GetBoolean(2),
                        IsV21 = r.GetBoolean(3),
                        IsV22 = r.GetBoolean(4),
                        AddNativeNames = r.GetBoolean(5),
                    };
                }
            });
        }

        private void LoadPartnerInfo(int partnerId)
        {
            Helpers.RunSqlCwr(cmd => {
                cmd.CommandText = @"
                    select t1.Id, t1.PartnerGroupId, Name, PeriodType, t2.Id
                    from Partners t1
                        join PeriodType t2 on t1.PeriodType = t2.Id
                    where t1.Id = @partnerId
                ";
                cmd.Parameters.AddWithValue("@partnerId", partnerId);
                using(var r = cmd.ExecuteReader())
                {
                    r.Read();
                    _partnerInfo = new PartnerInfo
                    {
                        Id = r.GetInt32(0),
                        PartnerGroupId = r.GetInt32(1),
                        Name = r.GetString(2),
                        PeriodTypeId = r.GetInt32(3),
                    };
                }
            });
        }

        private void PlanPartnerDeliveries()
        {
            Helpers.RunSqlCwr(cmd =>
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spPlanPartnerDeliveries";
                cmd.Parameters.AddWithValue("@partnerId", _partnerInfo.Id);
                cmd.ExecuteNonQuery();
            });
        }

        private void UpdateNames()
        {
            labTitle.Text = $"{_partnerInfo.Name} - передача файлів за розкладом РАЗ НА {PeriodTypeTitle[_partnerInfo.PeriodTypeId - 1].ToUpper()}";
            if(_partnerInfo.PeriodTypeId != 4)
                lvFiles.Columns[2].Text = PeriodTypeTitle[_partnerInfo.PeriodTypeId - 1];
        }

        private void LoadPartnerFiles()
        {
            Helpers.RunSqlCwr(cmd =>
            {
                cmd.CommandText = @"
                    select 
                          t1.Id         as FileId
                        , t1.Status     as FileStatus
                        , t1.Name       as FileName
                        , t1.SentAt     as FileSentAt
                        , t1.AnsweredAt as FileAnsweredAt
                        , t2.Id         as PeriodId
                        , t2.Year       as PeriodYear
                        , t2.Point      as PeriodPoint
                        , t3.Name       as BaseFileName
                        , t2.StartDate  as PeriodStartDate
                        , t2.EndDate    as PeriodEndDate
                    from CwrPartnerFiles t1
                        join Periods t2 on t1.PeriodId = t2.Id
                        left join CwrFiles t3 on t1.CwrFileId = t3.CwrFileId
                    where t1.PartnerId = @partnerId
                    order by t2.StartDate desc
                ";
                cmd.Parameters.AddWithValue("@partnerId", _partnerInfo.Id);
                using(var r = cmd.ExecuteReader())
                {
                    _fileInfoList = new List<FileInfo>();
                    while(r.Read())
                    {
                        var fileInfo = new FileInfo();
                        var idx = 0;
                        fileInfo.FileId          = r.GetInt32(idx); idx++;
                        fileInfo.FileStatus      = r.GetInt32(idx); idx++;
                        fileInfo.FileName        = r.IsDBNull(idx) ? "" : r.GetString(idx); idx++;
                        fileInfo.FileSentAt      = r.IsDBNull(idx) ? (DateTime?)null : r.GetDateTime(idx); idx++;
                        fileInfo.FileAnsweredAt  = r.IsDBNull(idx) ? (DateTime?)null : r.GetDateTime(idx); idx++;
                        fileInfo.PeriodId        = r.GetInt32(idx); idx++;
                        fileInfo.PeriodYear      = r.GetInt32(idx); idx++;
                        fileInfo.PeriodPoint     = r.GetInt32(idx); idx++;
                        fileInfo.BaseFileName    = r.IsDBNull(idx) ? "" : r.GetString(idx); idx++;
                        fileInfo.PeriodStartDate = r.GetDateTime(idx); idx++;
                        fileInfo.PeriodEndDate   = r.GetDateTime(idx); idx++;
                        _fileInfoList.Add(fileInfo);
                    }
                }
            });
        }

        private void FillPartnerFiles()
        {
            lvFiles.Items.Clear();
            _fileInfoList.ForEach(x =>
            {
                var item = new ListViewItem(x.FileId.ToString());
                item.SubItems.Add(x.PeriodYear.ToString());
                if(_partnerInfo.PeriodTypeId != 4)
                    item.SubItems.Add(x.PeriodPoint.ToString());
                item.SubItems.Add(FileStatusTitle[x.FileStatus - 1]);
                item.Tag = x;
                lvFiles.Items.Add(item);
            });
        }


        private void UpdateDetails()
        {
            if(lvFiles.SelectedItems.Count == 0)
            {
                panelDetails.Visible = false;
                return;
            }

            panelDetails.Visible = true;
            var fileInfo = (FileInfo)lvFiles.SelectedItems[0].Tag;
            tbFileStatus    .Text = FileStatusTitle[fileInfo.FileStatus - 1];
            tbFileName      .Text = fileInfo.FileName      ;
            tbFileSentAt    .Text = fileInfo.FileSentAt == null ? "" : ((DateTime)fileInfo.FileSentAt).ToString("yyyy-MM-dd hh:mm:ss");
            tbFileAnsweredAt.Text = fileInfo.FileAnsweredAt == null ? "" : ((DateTime)fileInfo.FileAnsweredAt).ToString("yyyy-MM-dd hh:mm:ss");
            tbBaseFileName  .Text = fileInfo.BaseFileName;
        }

        private void lvFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDetails();
        }

        private void btnApplyBaseFile_Click(object sender, EventArgs e)
        {
            var fileInfo = (FileInfo)lvFiles.SelectedItems[0].Tag;
            int? cwrFileId = null;
            var cwrFileName = "";
            Helpers.RunSqlCwr(cmd =>
            {
                cmd.CommandText = @"
                    select top 1 CwrFileId, Name
                    from CwrFiles
                    where PartnerGroupID = 1
                        and Direction = 'OUT'
                        and CreatedAt > @dateAfter
                    order by CreatedAt desc
                ";
                cmd.Parameters.AddWithValue("@dateAfter", fileInfo.PeriodStartDate);
                using(var r = cmd.ExecuteReader())
                {
                    if(!r.HasRows)
                        return;
                    r.Read();
                    cwrFileId = r.GetInt32(0);
                    cwrFileName = r.GetString(1);
                }
            });

            if(cwrFileId == null)
            {
                MessageBox.Show("Не знайдено файл, створений після початку періоду звітності. Створіть потрібний файл.", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var targetFileName = $"CW{fileInfo.BaseFileName.Substring(2,2)}.021";
        }
    }
}
