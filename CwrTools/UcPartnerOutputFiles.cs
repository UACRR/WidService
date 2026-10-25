using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
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
            "Переданий",
            "Прийнятий",
            "Відхилений",
            "Скасований",
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
            public int?      BaseFileId      { get; set; }
            public string    BaseFileName    { get; set; }
            public DateTime  PeriodStartDate { get; set; }
            public DateTime  PeriodEndDate   { get; set; }

            public string    Comment         { get; set; }

            public bool      IsPending       { get; set; }
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
            UpdatePartnerFiles();
        }

        public void UpdatePartnerFiles()
        {
            LoadPartnerFiles();
            FillPartnerFiles();

            foreach (ListViewItem item in lvFiles.Items)
            {
                var fileInfo = (FileInfo)item.Tag;
                if(fileInfo.IsPending)
                {
                    item.EnsureVisible();
                    item.Selected = true;
                    break;
                }
            }

            UpdateDetails();
            UpdateButtons();

        }

        private void Configure()
        {
            lvFiles.FullRowSelect = true;
            lvFiles.GridLines = true;
            lvFiles.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvFiles.MultiSelect = false;
            lvFiles.View = View.Details;
            lvFiles.SmallImageList = ilStatuses;
            lvFiles.StateImageList = ilStatuses;

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
                          t1.Id                 as FileId
                        , t1.Status             as FileStatus
                        , t1.Name               as FileName
                        , t1.SentAt             as FileSentAt
                        , t1.AnsweredAt         as FileAnsweredAt
                        , t2.Id                 as PeriodId
                        , t2.Year               as PeriodYear
                        , t2.Point              as PeriodPoint
                        , t3.CwrFileId          as BaseFileId
                        , t3.Name               as BaseFileName
                        , t2.StartDate          as PeriodStartDate
                        , t2.EndDate            as PeriodEndDate
                        , isnull(t4.Text, '')   as Comment
                    from CwrPartnerFiles t1
                        join Periods t2 on t1.PeriodId = t2.Id
                        left join CwrFiles t3 on t1.CwrFileId = t3.CwrFileId
                        left join CwrPartnerFileComments t4 on t1.Id = t4.CwrPartnerFileId
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
                        fileInfo.BaseFileId      = r.IsDBNull(idx) ? (int?)null : r.GetInt32(idx); idx++;
                        fileInfo.BaseFileName    = r.IsDBNull(idx) ? "" : r.GetString(idx); idx++;
                        fileInfo.PeriodStartDate = r.GetDateTime(idx); idx++;
                        fileInfo.PeriodEndDate   = r.GetDateTime(idx); idx++;
                        fileInfo.Comment         = r.GetString(idx); idx++;
                        fileInfo.IsPending       = false;
                        _fileInfoList.Add(fileInfo);
                    }
                }
            });

            _fileInfoList
                .OrderByDescending(x => x.PeriodEndDate)
                .First(x => x.PeriodEndDate < DateTime.Now)
                .IsPending = true;
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
                item.ImageIndex = x.FileStatus;
                item.StateImageIndex = x.IsPending ? 0 : -1;
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
            tbComment       .Text = fileInfo.Comment;
        }

        private void UpdateButtons()
        {
            if(lvFiles.SelectedItems.Count == 0)
            {
                panelDetails.Visible = false;
                return;
            }

            var fileInfo = (FileInfo)lvFiles.SelectedItems[0].Tag;
            switch((FileStatus)fileInfo.FileStatus)
            {
                case FileStatus.Planned  :
                    btnSetStatus        .Visible = false;
                    btnShowFile         .Visible = false;
                    btnShowBaseFile     .Visible = false;
                    btnSetCanceled      .Visible = false;
                    btnEditComment      .Visible = false;
                    break;
                case FileStatus.Awaiting :
                    btnSetStatus        .Visible = true;
                    btnShowFile         .Visible = true;
                    btnShowBaseFile     .Visible = true;
                    btnSetCanceled      .Visible = false;
                    btnEditComment      .Visible = false;

                    btnSetStatus.Text = "Передати";
                    break;
                case FileStatus.Sent     :
                    btnSetStatus        .Visible = true;
                    btnShowFile         .Visible = true;
                    btnShowBaseFile     .Visible = true;
                    btnSetCanceled      .Visible = true;
                    btnEditComment      .Visible = false;

                    btnSetStatus.Text = "Файл прийнятий";
                    break;
                case FileStatus.Accepted :
                    btnSetStatus        .Visible = false;
                    btnShowFile         .Visible = true;
                    btnShowBaseFile     .Visible = true;
                    btnSetCanceled      .Visible = true;
                    btnEditComment      .Visible = true;
                    break;
                case FileStatus.Rejected :
                    btnSetStatus        .Visible = true;
                    btnShowFile         .Visible = true;
                    btnShowBaseFile     .Visible = true;
                    btnSetCanceled      .Visible = true;
                    btnEditComment      .Visible = true;

                    btnSetStatus.Text = "Файл прийнятий";
                    break;
            }
        }

        private void lvFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDetails();
            UpdateButtons();
        }

        private void btnApplyBaseFile_Click(object sender, EventArgs e)
        {
            // var item = lvFiles.SelectedItems[0];
            // var fileInfo = (FileInfo)item.Tag;
            // 
            // int? baseFileId = null;
            // var baseFileName = "";
            // DateTime? baseFileCreatedAt = null;
            // 
            // // Обираємо базовий файл із групи (створений після кінцевої дати запланованого періоду)
            // Helpers.RunSqlCwr(cmd =>
            // {
            //     cmd.CommandText = @"
            //         select top 1 CwrFileId, Name, CreatedAt
            //         from CwrFiles
            //         where PartnerGroupID = @partnerGroupId
            //             and Direction = 'OUT'
            //             and CreatedAt > @dateAfter
            //         order by CreatedAt desc
            //     ";
            //     cmd.Parameters.AddWithValue("@partnerGroupId", _groupInfo.Id);
            //     cmd.Parameters.AddWithValue("@dateAfter", fileInfo.PeriodEndDate);
            //     using(var r = cmd.ExecuteReader())
            //     {
            //         if(!r.HasRows)
            //             return;
            //         r.Read();
            //         baseFileId = r.GetInt32(0);
            //         baseFileName = r.GetString(1);
            //         baseFileCreatedAt = r.GetDateTime(2);
            //     }
            // });
            // 
            // // Якщо немає
            // if(baseFileId == null)
            // {
            //     MessageBox.Show("Не знайдено файл, створений після кінцевої дати обраного періоду звітності. Створіть потрібний файл.", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //     return;
            // }
            // 
            // // Індекс останнього надісланого фалу за поточний рік
            // var lastSentSeqNr = 0;
            // Helpers.RunSqlCwr(cmd =>
            // {
            //     cmd.CommandText = "select max(SentFileSeqNr) from CwrPartnerFiles where PartnerId = @partnerId";
            //     cmd.Parameters.AddWithValue("@partnerId", _partnerInfo.Id);
            //     using(var r = cmd.ExecuteReader())
            //     {
            //         r.Read();
            //         if(!r.IsDBNull(0))
            //         {
            //             lastSentSeqNr = r.GetInt32(0);
            //         }
            //     }
            // });
            // 
            // // Назви файлів для надсилання
            // var targetFileName = $"CW{baseFileCreatedAt:yy}{lastSentSeqNr + 1:D4}140_000.V21";
            // var targetFileNamePacked = $"CW{baseFileCreatedAt:yy}{lastSentSeqNr + 1:D4}140_000.zip";
            // 
            // // Копіюємо базовий файл з потрібною назвою, пакуємо і видаляємо не запакований
            // var targetFilePath = Path.Combine(CwrConfig.OutputQueuePath, _groupInfo.Name, _partnerInfo.Name);
            // Directory.CreateDirectory(targetFilePath);
            // 
            // var sourceFileNameFull = Path.Combine(CwrConfig.OutputQueuePath, _groupInfo.Name, baseFileName);
            // var targetFileNameFull = Path.Combine(targetFilePath, targetFileName);
            // File.Copy(sourceFileNameFull, targetFileNameFull, true);
            // 
            // var targetFileNamePackedFull = Path.Combine(targetFilePath, targetFileNamePacked);
            // File.Delete(targetFileNamePackedFull);
            // using (ZipArchive archive = ZipFile.Open(targetFileNamePackedFull, ZipArchiveMode.Create))
            // {
            //     archive.CreateEntryFromFile(sourceFileNameFull, targetFileName, CompressionLevel.Optimal);
            // }
            // 
            // File.Delete(targetFileNameFull);
            // 
            // // Заносимо інформацію в БД
            // Helpers.RunSqlCwr(cmd =>
            // {
            //     cmd.CommandText = @"
            //         update CwrPartnerFiles
            //         set
            //               CwrFileId = @cwrFileId
            //             , Name = @name
            //             , Status = @status
            //         where Id = @fileId
            //     ";
            //     cmd.Parameters.AddWithValue("@fileId", fileInfo.FileId);
            //     cmd.Parameters.AddWithValue("@cwrFileId", baseFileId);
            //     cmd.Parameters.AddWithValue("@name", targetFileNamePacked);
            //     cmd.Parameters.AddWithValue("@status", (int)FileStatus.Awaiting);
            //     cmd.ExecuteNonQuery();
            // });
            // 
            // // Заносимо в память
            // fileInfo.BaseFileName = baseFileName;
            // fileInfo.FileName = targetFileNamePacked;
            // fileInfo.FileStatus = (int)FileStatus.Awaiting;
            // 
            // // Відобржаємо на формі
            // item.SubItems[3].Text = FileStatusTitle[(int)FileStatus.Awaiting - 1];
            // tbFileName.Text = targetFileNamePacked;
            // tbBaseFileName.Text = baseFileName;
            // tbFileStatus.Text = FileStatusTitle[(int)FileStatus.Awaiting - 1];
            // 
            // 
            // UpdateButtons();
        }

        private void btnShowFile_Click(object sender, EventArgs e)
        {
            if(lvFiles.SelectedItems.Count == 0)
            {
                panelDetails.Visible = false;
                return;
            }

            var fileInfo = (FileInfo)lvFiles.SelectedItems[0].Tag;
            var filePath = Path.Combine(CwrConfig.OutputQueuePath, _groupInfo.Name, fileInfo.BaseFileName);
            Process.Start("explorer.exe", $"/select,\"{filePath}\"");
        }

        private void btnShowBaseFile_Click(object sender, EventArgs e)
        {
            if(lvFiles.SelectedItems.Count == 0)
            {
                panelDetails.Visible = false;
                return;
            }

            var fileInfo = (FileInfo)lvFiles.SelectedItems[0].Tag;
            var filePath = Path.Combine(CwrConfig.OutputQueuePath, _groupInfo.Name,_partnerInfo.Name, fileInfo.FileName);
            Process.Start("explorer.exe", $"/select,\"{filePath}\"");
        }

        private void btnSetStatus_Click(object sender, EventArgs e)
        {
            if(lvFiles.SelectedItems.Count == 0)
            {
                panelDetails.Visible = false;
                return;
            }

            var item = lvFiles.SelectedItems[0];
            var fileInfo = (FileInfo)item.Tag;
            var nextStatus = fileInfo.FileStatus - 1 == (int)FileStatus.Planned ? FileStatus.Sent : FileStatus.Accepted;

            #region // Зміна статусу
            Helpers.RunSqlCwr(cmd =>
            {
                cmd.CommandText = @"update CwrPartnerFiles set
                      Status = @status
                    , SentAt = getdate()
                    where Id = @fileId
                ";
                cmd.Parameters.AddWithValue("@fileId", fileInfo.FileId);
                cmd.Parameters.AddWithValue("@status", (int)nextStatus);
                cmd.ExecuteNonQuery();

            });

            UpdatePartnerFiles();
            #endregion // Зміна статусу

            #region // Зміна дати НАДІСЛАНО
            if(nextStatus == FileStatus.Sent)
            {
                Helpers.RunSqlCwr(cmd =>
                {
                    cmd.CommandText = @"update CwrPartnerFiles set
                            SentAt = getdate()
                        where Id = @fileId
                    ";
                    cmd.Parameters.AddWithValue("@fileId", fileInfo.FileId);
                    cmd.ExecuteNonQuery();

                });

                UpdatePartnerFiles();
            }
            #endregion /// Зміна дати НАДІСЛАНО

            #region // Скасовуємо надсилання файлів для попереднх періодів
            if(nextStatus == FileStatus.Sent)
            {
                Helpers.RunSqlCwr(cmd =>
                {
                    cmd.CommandText = @"update CwrPartnerFiles set Status = 6 where Id = @fileId";
                    cmd.Parameters.AddWithValue("@fileId", fileInfo.FileId);
                    cmd.ExecuteNonQuery();
               });
            }
            #endregion /// Скасовуємо надсилання файлів для попереднх періодів

            #region // Зміна дати ПРИЙНЯТО
            if(nextStatus == FileStatus.Accepted)
            {
                Helpers.RunSqlCwr(cmd =>
                {
                    cmd.CommandText = @"update CwrPartnerFiles set
                            AnsweredAt = getdate()
                        where Id = @fileId
                    ";
                    cmd.Parameters.AddWithValue("@fileId", fileInfo.FileId);
                    cmd.ExecuteNonQuery();

                });

                UpdatePartnerFiles();
            }
            #endregion /// Зміна дати ПРИЙНЯТО

        }

        private void btnSetCanceled_Click(object sender, EventArgs e)
        {
            if(lvFiles.SelectedItems.Count == 0)
            {
                panelDetails.Visible = false;
                return;
            }

            var item = lvFiles.SelectedItems[0];
            var fileInfo = (FileInfo)item.Tag;
            var nextStatus = FileStatus.Rejected;


            Helpers.RunSqlCwr(cmd =>
            {
                cmd.CommandText = "update CwrPartnerFiles set Status = @status, AnsweredAt = getdate() where Id = @fileId";
                cmd.Parameters.AddWithValue("@fileId", fileInfo.FileId);
                cmd.Parameters.AddWithValue("@status", (int)nextStatus);
                cmd.ExecuteNonQuery();
            });

            UpdatePartnerFiles();
        }

        private void btnEditComment_Click(object sender, EventArgs e)
        {
            if(lvFiles.SelectedItems.Count == 0)
            {
                panelDetails.Visible = false;
                return;
            }

            var item = lvFiles.SelectedItems[0];
            var fileInfo = (FileInfo)item.Tag;

            int? commentId = null;
            string comment = "";
            Helpers.RunSqlCwr(cmd =>
            {
                cmd.CommandText = "select Id, Text from CwrPartnerFileComments where CwrPartnerFileId = @fileId";
                cmd.Parameters.AddWithValue("@fileId", fileInfo.FileId);
                using(var r = cmd.ExecuteReader())
                {
                    if(!r.HasRows)
                    {
                        return;
                    }
                    r.Read();
                    commentId = r.GetInt32(0);
                    comment = r.GetString(1);
                }
            });

            var form = new FormEditText("Коментар стосовно відповіді для надісланого файлу", comment);
            var res = form.ShowDialog();

            if(res != DialogResult.OK)
                return;

            Helpers.RunSqlCwr(cmd =>
            {
                if(commentId == null)
                {
                    cmd.CommandText = "insert CwrPartnerFileComments values( @fileId, @text)";
                }
                else
                {
                    cmd.CommandText = "update CwrPartnerFileComments set Text = @text where Id = @commentId";
                    cmd.Parameters.AddWithValue("@commentId", commentId);
                }
                cmd.Parameters.AddWithValue("@fileId", fileInfo.FileId);
                cmd.Parameters.AddWithValue("@text", form.OutputText);
                cmd.ExecuteNonQuery();
            });

            fileInfo.Comment = form.OutputText;
            tbComment.Text = form.OutputText;


        }

        private void btnSetPendingBaseFile_Click(object sender, EventArgs e)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> Якщо для надісланого раніше файлу не отримана відповідь нічого не робимо
            var hasNotRespondedFiles = false;
            Helpers.RunSqlCwr(cmd =>
            {
                cmd.CommandText = "select top 1 null from CwrPartnerFiles where PartnerId = @partnerId and Status= 3";
                cmd.Parameters.AddWithValue("@partnerId", _partnerInfo.Id);
                using(var r = cmd.ExecuteReader())
                {
                    hasNotRespondedFiles = r.HasRows;
                }
            });
            // Якщо немає
            if(hasNotRespondedFiles)
            {
                MessageBox.Show("Не вказана відповідь для раніш надійсланого файл. Передача нового файлу не планується.", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> Файл партнера який слід передати станом на поточну дату
            var pendingFileInfo = _fileInfoList
                .OrderByDescending(x => x.PeriodEndDate)
                .First(x => x.PeriodEndDate < DateTime.Now);

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> Базовий файл для передачі
            int? baseFileId = null;
            var baseFileName = "";
            DateTime? baseFileCreatedAt = null;

            Helpers.RunSqlCwr(cmd =>
            {
                cmd.CommandText = @"
                   select top 1 CwrFileId, Name, CreatedAt
                    from CwrFiles
                    where PartnerGroupID = @partnerGroupID
                        and CreatedAt > @createdAfter
                    order by CreatedAt desc
                ";
                cmd.Parameters.AddWithValue("@partnerGroupID", _groupInfo.Id);
                cmd.Parameters.AddWithValue("@createdAfter", pendingFileInfo.PeriodEndDate);
                using(var r = cmd.ExecuteReader())
                {
                    if(!r.HasRows)
                        return;
                    r.Read();
                    baseFileId = r.GetInt32(0);
                    baseFileName = r.GetString(1);
                    baseFileCreatedAt = r.GetDateTime(2);
                }
            });

            if(baseFileId == null)
            {
                MessageBox.Show("Не знайдено файл, створений після кінцевої дати останнього періоду звітності. Створіть потрібний файл.", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> Перевіряємо, що обраний файл не було надіслано і прийнято
            var isAccepted = false;
            Helpers.RunSqlCwr(cmd =>
            {
                cmd.CommandText = @"
                    select null
                    from CwrPartnerFiles
                    where CwrFileId = @cwrFileId
                        and PartnerId = @partnerId
                        and Status = 4
                ";
                cmd.Parameters.AddWithValue("@cwrFileId", baseFileId);
                cmd.Parameters.AddWithValue("@partnerId", _partnerInfo.Id);
                using(var r = cmd.ExecuteReader())
                {
                    if(r.HasRows)
                        isAccepted = true;
                }
            });

            // Якщо було надіслано і прийнято
            if(isAccepted)
            {
                MessageBox.Show("Файл вже отриманий партнером.", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Індекс останнього надісланого фалу за поточний рік
            var lastSentSeqNr = 0;
            Helpers.RunSqlCwr(cmd =>
            {
                cmd.CommandText = "select max(SentFileSeqNr) from CwrPartnerFiles where PartnerId = @partnerId";
                cmd.Parameters.AddWithValue("@partnerId", _partnerInfo.Id);
                using(var r = cmd.ExecuteReader())
                {
                    r.Read();
                    if(!r.IsDBNull(0))
                    {
                        lastSentSeqNr = r.GetInt32(0);
                    }
                }
            });

            // Назви файлів для надсилання
            var targetFileName = $"CW{baseFileCreatedAt:yy}{lastSentSeqNr + 1:D4}140_000.V21";
            var targetFileNamePacked = $"CW{baseFileCreatedAt:yy}{lastSentSeqNr + 1:D4}140_000.zip";

            // Копіюємо базовий файл з потрібною назвою, пакуємо і видаляємо не запакований
            var targetFilePath = Path.Combine(CwrConfig.OutputQueuePath, _groupInfo.Name, _partnerInfo.Name);
            Directory.CreateDirectory(targetFilePath);

            var sourceFileNameFull = Path.Combine(CwrConfig.OutputQueuePath, _groupInfo.Name, baseFileName);
            var targetFileNameFull = Path.Combine(targetFilePath, targetFileName);
            File.Copy(sourceFileNameFull, targetFileNameFull, true);

            var targetFileNamePackedFull = Path.Combine(targetFilePath, targetFileNamePacked);
            File.Delete(targetFileNamePackedFull);
            using (ZipArchive archive = ZipFile.Open(targetFileNamePackedFull, ZipArchiveMode.Create))
            {
                archive.CreateEntryFromFile(sourceFileNameFull, targetFileName, CompressionLevel.Optimal);
            }

            File.Delete(targetFileNameFull);

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> Заносимо інформацію в БД
            Helpers.RunSqlCwr(cmd =>
            {
                cmd.CommandText = @"
                    update CwrPartnerFiles
                    set
                          CwrFileId = @cwrFileId
                        , Name = @name
                        , Status = @status
                    where Id = @fileId
                ";
                cmd.Parameters.AddWithValue("@fileId", pendingFileInfo.FileId);
                cmd.Parameters.AddWithValue("@cwrFileId", baseFileId);
                cmd.Parameters.AddWithValue("@name", targetFileNamePacked);
                cmd.Parameters.AddWithValue("@status", (int)FileStatus.Awaiting);
                cmd.ExecuteNonQuery();

                cmd.CommandText = @"
                    update CwrPartnerFiles
                    set Status = 6 -- Canceled
                    from CwrPartnerFiles t1
                        join Periods t2 on t1.PeriodId = t2.Id
                    where t1.PartnerId = @partnerId
                        and t1.Id <> @fileId
                        and t1.Status in (1, 2)
                        and t2.EndDate < @dateLimit
                ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@fileId", pendingFileInfo.FileId);
                cmd.Parameters.AddWithValue("@partnerId", _partnerInfo.Id);
                cmd.Parameters.AddWithValue("@dateLimit", pendingFileInfo.PeriodStartDate);
                cmd.ExecuteNonQuery();
            });

            // Відобржаємо на формі
            UpdatePartnerFiles();
        }
    }
}
