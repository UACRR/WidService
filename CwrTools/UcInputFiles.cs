using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CwrTools
{
    public partial class UcInputFiles : UserControl
    {
        public class FileInfo
        {
                public int CwrFileId     { get; set; }
                public string Path          { get; set; }
                public string Name          { get; set; }
                public string SenderName    { get; set; }
                public DateTime CreationDate  { get; set; }
        }

        private List<FileInfo> _fileInfoList;

        public UcInputFiles()
        {
            InitializeComponent();
        }

        private void UcInputFiles_Load(object sender, EventArgs e)
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
            lvFiles.Columns.Add("Початкове розташування файлу", 300);
            lvFiles.Columns.Add("Назва", 200);
            lvFiles.Columns.Add("Відправник", 100);
            lvFiles.Columns.Add("Дата створення", 100);
        }

        public void LoadData()
        {
            return;
            _fileInfoList = new List<FileInfo>();
            Helpers.RunSqlCwr(cmd =>
            {
                cmd.CommandText = @"
                        select t1.CwrFileId, t1.Path, t1.Name, t2.SenderName, t2.CreationDate
                        from CwrFiles t1
	                        join RecHdr t2 on t1.CwrFileId = t2.CwrFileId
                        where Direction = 'IN'
                        order by CreationDate desc
                    ";
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        _fileInfoList.Add(new FileInfo
                        {
                            CwrFileId     = r.GetInt32(0),
                            Path          = r.GetString(1),
                            Name          = r.GetString(2),
                            SenderName    = r.GetString(3),
                            CreationDate  = r.GetDateTime(4),
                        });
                    }
                }
            });

        }

        public void RefreshData()
        {
            return;
            LoadData();

            lvFiles.Items.Clear();
            _fileInfoList.ForEach(x =>
            {
                var item = lvFiles.Items.Add(x.CwrFileId.ToString());
                item.SubItems.Add(x.Path);
                item.SubItems.Add(x.Name);
                item.SubItems.Add(x.SenderName);
                item.SubItems.Add(x.CreationDate.ToString("yyyy-MM-dd"));

                item.Tag = x;
            });

            RefreshControls();
        }

        public void RefreshControls()
        {
            if (lvFiles.SelectedItems.Count > 0)
            {
                btnShowInFolder.Enabled = true;
                btnDelete.Enabled = true;
            }
            else
            {
                btnShowInFolder.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.InitialDirectory = CwrConfig.InputQueuePath;
            dlg.Filter = "CWR Files|CW*.V2?";
            if(dlg.ShowDialog(this) == DialogResult.Cancel)
            {
                return;
            }

            var fileLoaded = false;
            Helpers.RunSqlCwr(cmd =>
            {
                cmd.CommandText = "select count(*) from CwrFiles where Name = @Name and Direction = 'IN'";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Name", Path.GetFileName(dlg.FileName));
                fileLoaded = (int)cmd.ExecuteScalar() > 0;
            });

            if (fileLoaded)
            {
                MessageBox.Show("Файл вже завантажений в БД", "Завантаження файлу", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var cwrFileId = 0;
            try
            {
                Cursor = Cursors.WaitCursor;
                var reader = new CwrFileReader();
                cwrFileId = reader.LoadFile(dlg.FileName, "IN", 1);
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "Завантаження файлу", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Операція завершена успішно", "Завантаження файлу", MessageBoxButtons.OK, MessageBoxIcon.Information);

            RefreshData();

            foreach(ListViewItem item in lvFiles.Items)
            {
                var fileInfo = (FileInfo)item.Tag;
                if(fileInfo.CwrFileId == cwrFileId)
                {
                    item.Selected = true;
                    item.EnsureVisible();
                    break;
                }
            }

            lvFiles.Focus();

        }

        private void lvFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshControls();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(lvFiles.SelectedItems.Count == 0) return;

            var promptText = $"Інформація для файлу буде видалени з БД, а файл переміщений в папку {CwrConfig.InputQueuePath}. Виконати?";
            var res = MessageBox.Show(promptText, "Завантаження файлу", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No) return;

            var cwrFileId = ((FileInfo)lvFiles.SelectedItems[0].Tag).CwrFileId;
            try
            {
                Cursor = Cursors.WaitCursor;
                var reader = new CwrFileReader();
                reader.UnLoadFile(cwrFileId);
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "Завантаження файлу", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Операція завершена успішно", "Завантаження файлу", MessageBoxButtons.OK, MessageBoxIcon.Information);

            RefreshData();
            RefreshControls();
        }

        private void btnShowInFolder_Click(object sender, EventArgs e)
        {
            if(lvFiles.SelectedItems.Count == 0) return;

            var fileInfo = (FileInfo)lvFiles.SelectedItems[0].Tag;

            var reader = new CwrFileReader();
            var fileFullName = reader.GetLoadedFileFullName(fileInfo.CwrFileId);
            Process.Start("explorer.exe", "/select, " + fileFullName);
        }
    }
}
