using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CwrTools.UcOutputFiles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CwrTools
{
    public partial class UcGroupOutputFiles : UserControl
    {
        public class FileInfo
        {
            public int CwrFileId { get; set; }
            public string Name   { get; set; }
            public bool IsUsed   { get; set; }
        }

        private List<FileInfo> _fileInfoList;
        private FileInfo _lastFileInfo;

        private PartnerGroupInfo _groupInfo;

        public UcGroupOutputFiles()
        {
            InitializeComponent();
        }

        private void UcOutputFiles_Load(object sender, EventArgs e)
        {
            Configure();
        }

        private void Configure()
        {
            lvFiles.FullRowSelect = true;
            lvFiles.GridLines = true;
            lvFiles.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvFiles.MultiSelect = false;
            lvFiles.View = View.Details;

            lvFiles.Columns.Clear();
            lvFiles.Columns.Add("Код", 100);
            lvFiles.Columns.Add("Назва", 200);
            lvFiles.Columns.Add("Використовується", 200);
        }

        public void LoadData()
        {
            _fileInfoList = new List<FileInfo>();
            Helpers.RunSqlCwr(cmd =>
            {
                cmd.CommandText = @"
                        select distinct t1.CwrFileId, t1.Name, case when t2.Id is null then 0 else 1 end
                        from CwrFiles t1
                            left join CwrPartnerFiles t2 on t1.CwrFileId = t2.CwrFileId
                        where t1.Direction = 'OUT'
                            and t1.PartnerGroupId = @groupId
                        order by t1.Name desc
                ";
                cmd.Parameters.AddWithValue("@groupId", _groupInfo.Id);
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        var fileInfo = new FileInfo
                        {
                            CwrFileId = r.GetInt32(0),
                            Name = r.GetString(1),
                            IsUsed = r.GetInt32(2) == 1 ? true : false,
                        };
                        _fileInfoList.Add(fileInfo);
                    }
                }
            });

        }
        
        public void RefreshData(int groupId)
        {
            Helpers.RunSqlCwr(cmd =>
            {
                cmd.CommandText = "select * from PartnerGroups where Id = @id";
                cmd.Parameters.AddWithValue("@id", groupId);
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

            labTitle.Text = $"Файли групи {_groupInfo.Name}";

            LoadData();

            lvFiles.Items.Clear();
            _fileInfoList.ForEach(x =>
            {
                var item = lvFiles.Items.Add(x.CwrFileId.ToString());
                item.SubItems.Add(x.Name);
                item.SubItems.Add(x.IsUsed ? "ТАК" : "");

                item.Tag = x;
            });

            RefreshControls();
        }

        public void RefreshControls()
        {
        }

        private bool IsUsedByPartner(int cwrFileId)
        {
            var isUsedByPartner = false;
            Helpers.RunSqlCwr(cmd =>
            {
                cmd.CommandText = "select top 1 null from CwrPartnerFiles where CwrFileId = @cwrFileId";
                cmd.Parameters.AddWithValue("@cwrFileId", cwrFileId);
                var res = cmd.ExecuteScalar();
                isUsedByPartner = res != null;
            });
            return isUsedByPartner;
        }

        private void CreateFile()
        {
            var reader = new CwrFileReader();

            try
            {
                Cursor = Cursors.WaitCursor;

                var lastFileInfo = _fileInfoList.OrderByDescending(x => x.Name).FirstOrDefault();
                var isUsedByPartner = lastFileInfo == null || lastFileInfo.IsUsed;
                if(lastFileInfo != null)
                {
                    if(!isUsedByPartner)
                    {
                        MessageBox.Show("Останній файл не використовується партнерами. Він буде оновлений.", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        reader.UnLoadFile(lastFileInfo.CwrFileId);
                    }
                }

                var path = CwrConfig.GetOutputGroupPath(_groupInfo.Name);
                Directory.CreateDirectory(path);
                var writer = new CwrFileWriter();
                var fileFullName = writer.CreateFile(path, _groupInfo);

                int cwrFileId = reader.LoadFile(fileFullName, "OUT", _groupInfo.Id);

                Cursor = Cursors.Default;

                LoadData();

                //var fs = new CwrFileSplitter(fileFullName, 10000);
                //fs.SplitFile();

                RefreshData(_groupInfo.Id);

                if(isUsedByPartner)
                {
                    MessageBox.Show("Файл створено.", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Файл оновлено.", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch(Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "Створення файлу", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void DeleteFile()
        {
            if(lvFiles.SelectedItems.Count == 0)
            {
                MessageBox.Show("Не обраний файл для видалення", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var item = lvFiles.SelectedItems[0];
            var fileInfo = (FileInfo)item.Tag;

            if(fileInfo.IsUsed)
            {
                MessageBox.Show("Файл використовується партнерами і не може бути видалений.", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            File.Delete(CwrConfig.GetOutputGroupFullFileName(_groupInfo.Name, fileInfo.Name));

            Helpers.RunSqlCwr(cmd =>
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spDeleteFile";
                cmd.Parameters.AddWithValue("CwrFileId", fileInfo.CwrFileId);
                cmd.ExecuteNonQuery();
            });

            _fileInfoList.Remove(fileInfo);
            lvFiles.Items.Remove(item);

            MessageBox.Show("Файл видалено.", "Повідомлення", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowInFolder()
        {
            if(lvFiles.SelectedItems.Count == 0)
            {
                MessageBox.Show("Не обраний файл", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var fileInfo = (FileInfo)lvFiles.SelectedItems[0].Tag;

            var reader = new CwrFileReader();
            var fileFullName = CwrConfig.GetOutputGroupFullFileName(_groupInfo.Name, fileInfo.Name);
            Process.Start("explorer.exe", "/select, " + fileFullName);
        }

        private void tsbtnCreateFile_Click(object sender, EventArgs e)
        {
            CreateFile();
        }

        private void tsbtnDeleteFile_Click(object sender, EventArgs e)
        {
            DeleteFile();
        }

        private void tsbtnShowFile_Click(object sender, EventArgs e)
        {
            ShowInFolder();
        }

        private void lvFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshControls();
        }

    }
}
