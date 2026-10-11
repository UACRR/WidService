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
    public partial class UcOutputFiles : UserControl
    {
        public enum FileStatusEnum
        {
            New, Approved, Sent
        }

        public string[] StatusName = new string[3] {"Новий", "До передачі", "Переданий" };

        public class Partner
        {
            public int Id      { get; set; }
            public string Name { get; set; }
        }

        public class PartnerGroup
        {
            public int Id      { get; set; }
            public string Name { get; set; }
            public bool IsStandard { get; set; }
            public List<Partner> Partners { get; set; }
        }

        public class FileInfo
        {
                public int CwrFileId     { get; set; }
                public string Path          { get; set; }
                public string Name          { get; set; }
                public string SenderName    { get; set; }
                public DateTime CreationDate  { get; set; }
                public int Status  { get; set; }
        }

        private List<FileInfo> _fileInfoList;
        private List<PartnerGroup> _partnerGroups;
        private FileInfo _newFileInfo;

        public UcOutputFiles()
        {
            InitializeComponent();
        }

        private void UcOutputFiles_Load(object sender, EventArgs e)
        {
            Configure();
            LoadPartnerGroups();
            FillPartnerGroups();
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
            lvFiles.Columns.Add("Статус", 100);

            tvPartners.ImageList = ilPartnerGroups;
            tvPartners.HideSelection = false;
            tvPartners.LabelEdit = true;
            tvPartners.AllowDrop = true;
        }

        private void LoadPartnerGroups()
        {
            Helpers.RunSqlCwr(cmd =>
            {
                cmd.CommandText = @"
                    select t1.Id as GroupId
                        , t1.Name as GroupName
                        , t1.IsStandard
                        , t2.Id as PartnerId
                        , t2.Name as PartnerName
                    from PartnerGroups t1
                        left join Partners t2 on t1.Id = t2.PartnerGroupId
                ";
                using(var r = cmd.ExecuteReader())
                {
                    _partnerGroups = new List<PartnerGroup>();
                    var curGrId = 0;
                    PartnerGroup curPg = null;
                    while (r.Read())
                    {
                        var grId = r.GetInt32(0);
                        if(grId != curGrId)
                        {
                            curGrId = grId;
                            curPg = new PartnerGroup
                            {
                                Id = curGrId,
                                Name = r.GetString(1),
                                IsStandard = r.GetBoolean(2),
                                Partners = new List<Partner>(),
                            };
                            _partnerGroups.Add(curPg);
                        }

                        if(!r.IsDBNull(3))
                        {
                            curPg.Partners.Add(new Partner
                            {
                                Id = r.GetInt32(3),
                                Name = r.GetString(4),
                            });
                        }
                    }
                }
            });
        }

        private void FillPartnerGroups()
        {
            tvPartners.Nodes.Clear();
            _partnerGroups.ForEach(gr => {
                var pNode = tvPartners.Nodes.Add(gr.Name);
                pNode.ImageIndex = 0;
                pNode.SelectedImageIndex = 0;
                pNode.Tag = gr;
                gr.Partners.ForEach(p =>
                {
                    var cNode = pNode.Nodes.Add(p.Name);
                    cNode.ImageIndex = 1;
                    cNode.SelectedImageIndex = 1;
                    cNode.Tag = p;
                });
            });
        }

        public void LoadData()
        {
            _fileInfoList = new List<FileInfo>();
            _newFileInfo = null;
            Helpers.RunSqlCwr(cmd =>
            {
                cmd.CommandText = @"
                        select t1.CwrFileId, t1.Path, t1.Name, t2.SenderName, t2.CreationDate, t1.Status
                        from CwrFiles t1
	                        join RecHdr t2 on t1.CwrFileId = t2.CwrFileId
                        where Direction = 'OUT'
                        order by CreationDate desc
                    ";
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        var fileInfo = new FileInfo
                        {
                            CwrFileId = r.GetInt32(0),
                            Path = r.GetString(1),
                            Name = r.GetString(2),
                            SenderName = r.GetString(3),
                            CreationDate = r.GetDateTime(4),
                            Status = r.GetInt32(5),
                        };
                        _fileInfoList.Add(fileInfo);

                        if(fileInfo.Status == (int)FileStatusEnum.New || fileInfo.Status == (int)FileStatusEnum.Approved)
                        {
                            _newFileInfo = fileInfo;
                        }
                    }
                }
            });

        }
        
        public void RefreshData()
        {
            LoadData();

            lvFiles.Items.Clear();
            _fileInfoList.ForEach(x =>
            {
                var item = lvFiles.Items.Add(x.CwrFileId.ToString());
                item.SubItems.Add(x.Path);
                item.SubItems.Add(x.Name);
                item.SubItems.Add(x.SenderName);
                item.SubItems.Add(x.CreationDate.ToString("yyyy-MM-dd"));
                item.SubItems.Add(StatusName[x.Status]);

                item.Tag = x;
            });

            tbNewFileFullName.Text = _newFileInfo == null ? "" : _newFileInfo.Name;

            RefreshControls();
        }

        public void RefreshControls()
        {
            if (lvFiles.SelectedItems.Count > 0)
            {
                btnShowInFolder.Enabled = true;
            }
            else
            {
                btnShowInFolder.Enabled = false;
            }

            if (_newFileInfo == null)
            {
                btnCreateFile.Visible = true;
                btnChangeStatus.Visible = false;

                btnCreateFile.Text = "Створити новий файл";
            }
            else
            {
                btnCreateFile.Visible = _newFileInfo.Status == (int)FileStatusEnum.New;
                btnChangeStatus.Visible = true;

                btnCreateFile.Text = "Оновити новий файл";
                btnChangeStatus.Text = _newFileInfo.Status == (int)FileStatusEnum.New ? "До передачі" : "Позначити як переданий";
            }
        }

        private void AddPartner()
        {
            var node = tvPartners.SelectedNode;
            if(node == null || node.Parent != null)
            {
                MessageBox.Show("Не обрано групу для додавання партнера", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var group = (PartnerGroup)node.Tag;
            Helpers.RunSqlCwr(cmd =>
            {
                cmd.CommandText = @"
                    insert Partners(PartnerGroupId, Name) values(@groupId, 'Новий партнер');
                    select cast(scope_identity() as int);
                ";
                cmd.Parameters.AddWithValue("@groupId", group.Id);
                var newPartnerId = (int)cmd.ExecuteScalar();

                var newPartner = new Partner
                {
                    Id = newPartnerId,
                    Name = "Новий партнер",
                };
                group.Partners.Add(newPartner);

                var partnerNode = node.Nodes.Add("Новий партнер");
                partnerNode.ImageIndex = 1;
                partnerNode.SelectedImageIndex = 1;
                partnerNode.Tag = newPartner;
                tvPartners.SelectedNode = partnerNode;
                partnerNode.BeginEdit();
            });
        }

        private void AddGroup()
        {
            Helpers.RunSqlCwr(cmd =>
            {
                cmd.CommandText = @"
                    insert PartnerGroups(Name, IsStandard) values('Нова група', 0);
                    select cast(scope_identity() as int);
                ";
                var newGrId = (int)cmd.ExecuteScalar();

                var newPg = new PartnerGroup
                {
                    Id = newGrId,
                    Name = "Нова група",
                    Partners = new List<Partner>(),
                };
                _partnerGroups.Add(newPg);

                var node = tvPartners.Nodes.Add("Нова група");
                node.ImageIndex = 0;
                node.SelectedImageIndex = 0;
                node.Tag = newPg;
                tvPartners.SelectedNode = node;
                node.BeginEdit();
            });
        }

        private void RenameGroup(TreeNode node, string newName)
        {
            var group = (PartnerGroup)node.Tag;
            Helpers.RunSqlCwr(cmd => {
                cmd.CommandText = @"
                    update PartnerGroups set Name = @name where Id = @groupId;
                ";
                cmd.Parameters.AddWithValue("@groupId", group.Id);
                cmd.Parameters.AddWithValue("@name", newName);
                cmd.ExecuteNonQuery();
            });

            group.Name = newName;
            node.Text = newName;
        }

        private void RenamePartner(TreeNode node, string newName)
        {
            var partner = (Partner)node.Tag;
            Helpers.RunSqlCwr(cmd => {
                cmd.CommandText = @"
                    update Partners set Name = @name where Id = @partnerId;
                ";
                cmd.Parameters.AddWithValue("@partnerId", partner.Id);
                cmd.Parameters.AddWithValue("@name", newName);
                cmd.ExecuteNonQuery();
            });

            partner.Name = newName;
            node.Text = newName;
        }

        private void DeleteGroup(TreeNode node)
        {
            var group = (PartnerGroup)node.Tag;
            if (group.IsStandard) {
                MessageBox.Show("Загальні групи видаляти не можна", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (DialogResult.Yes !=
                MessageBox.Show($"Видалити групу {group.Name} і всю супутню інформацю?", "Питання", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                return;
            }

            Helpers.RunSqlCwr(cmd => {
                cmd.CommandText = @"
                    delete from Partners where PartnerGroupId = @groupId;
                    delete from PartnerGroups where Id = @groupId;
                ";
                cmd.Parameters.AddWithValue("@groupId", group.Id);
                cmd.ExecuteNonQuery();
            });

            _partnerGroups.Remove(group);
            tvPartners.Nodes.Remove(node);
        }

        private void DeletePartner(TreeNode node)
        {
            var partner = (Partner)node.Tag;
            var group = (PartnerGroup)node.Parent.Tag;
            if (DialogResult.Yes !=
                MessageBox.Show($"Видалити партнера {partner.Name} і всю супутню інформацю?", "Питання", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                return;
            }

            Helpers.RunSqlCwr(cmd => {
                cmd.CommandText = @"
                    delete from Partners where Id = @partnerId;
                ";
                cmd.Parameters.AddWithValue("@partnerId", partner.Id);
                cmd.ExecuteNonQuery();
            });

            group.Partners.Remove(partner);
            tvPartners.Nodes.Remove(node);
        }

        private void lvFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshControls();
        }

        private void btnShowInFolder_Click(object sender, EventArgs e)
        {
            if(lvFiles.SelectedItems.Count == 0) return;

            var fileInfo = (FileInfo)lvFiles.SelectedItems[0].Tag;

            var reader = new CwrFileReader();
            var fileFullName = Path.Combine(fileInfo.Path, fileInfo.Name);
            Process.Start("explorer.exe", "/select, " + fileFullName);
        }

        private void btnCreateFile_Click(object sender, EventArgs e)
        {
            var reader = new CwrFileReader();
                
            try
            {
                Cursor = Cursors.WaitCursor;

                if(_newFileInfo != null)
                {
                    reader.UnLoadFile(_newFileInfo.CwrFileId);
                }

                Directory.CreateDirectory(CwrConfig.OutputFilesPath);
                var writer = new CwrFileWriter();
                var fileFullName = writer.CreateFile(CwrConfig.OutputFilesPath);

                var fileName = Path.GetFileName(fileFullName);
                int? cwrFileId = null;
                Helpers.RunSqlCwr(cmd =>
                {
                    cmd.CommandText = "select CwrFileId from CwrFiles where Status is null and Direction = 'OUT'";
                    cwrFileId = (int?)cmd.ExecuteScalar();
                });

                if (cwrFileId != null)
                {
                    reader.UnLoadFile((int)cwrFileId);
                }

                cwrFileId = reader.LoadFile(fileFullName, "OUT");

                Cursor = Cursors.Default;

                LoadData();

                var fs = new CwrFileSplitter(fileFullName, 10000);
                fs.SplitFile();

                RefreshData();

            }
            catch(Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "Створення файлу", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnChangeStatus_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                Helpers.RunSqlCwr(cmd =>
                {
                    cmd.CommandText = "update CwrFiles set Status = Status + 1 where CwrFileId = @CwrFileId";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@CwrFileId", _newFileInfo.CwrFileId);
                    cmd.ExecuteNonQuery();
                });

                if (_newFileInfo.Status == (int)FileStatusEnum.New)
                {
                    Directory.CreateDirectory(CwrConfig.OutputQueuePath);
                    var sourceFileFullName = Path.Combine(CwrConfig.OutputFilesPath, _newFileInfo.Name);
                    var targetFileFullName = Path.Combine(CwrConfig.OutputQueuePath, _newFileInfo.Name);
                    File.Copy(sourceFileFullName, targetFileFullName, true);
                }
                else if (_newFileInfo.Status == (int)FileStatusEnum.Approved)
                {
                    var sourceFileFullName = Path.Combine(CwrConfig.OutputQueuePath, _newFileInfo.Name);
                    File.Delete(sourceFileFullName);
                }

                RefreshData(); 
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "Створення файлу", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void tvPartners_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            var node = e.Node;
            if(node.Parent == null)
            {
                var group = (PartnerGroup)e.Node.Tag;
                if(group.IsStandard)
                    e.CancelEdit = true;
            }
        }

        private void tvPartners_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if(e.Label == null)
                return;
            var node = e.Node;
            if(node.Parent == null)
            {
                RenameGroup(node, e.Label);
            }
            else
            {
                RenamePartner(node, e.Label);
            }
        }

        private void tvPartners_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if(((TreeNode)e.Item).Parent == null)
                return;

            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void tvPartners_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(TreeNode)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void tvPartners_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(TreeNode)))
            {
                Point targetPoint = tvPartners.PointToClient(new Point(e.X, e.Y));
                TreeNode targetNode = tvPartners.GetNodeAt(targetPoint);
                TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));

                var targetGroup = (PartnerGroup)targetNode.Tag;
                var draggedGroup = (PartnerGroup)draggedNode.Parent.Tag;
                var draggedPartner = (Partner)draggedNode.Tag;

                Helpers.RunSqlCwr(cmd =>
                {
                    cmd.CommandText = "update Partners set PartnerGroupId = @partnerGroupId where Id = @id";
                    cmd.Parameters.AddWithValue("@id", draggedPartner.Id);
                    cmd.Parameters.AddWithValue("@partnerGroupId", targetGroup.Id);
                    cmd.ExecuteNonQuery();
                });

                targetGroup.Partners.Add(draggedPartner);
                draggedGroup.Partners.Remove(draggedPartner);

                draggedNode.Remove();
                targetNode.Nodes.Add(draggedNode);

                targetNode.Expand();
                tvPartners.SelectedNode = draggedNode;
            }
        }

        private void tvPartners_DragOver(object sender, DragEventArgs e)
        {
            Point targetPoint = tvPartners.PointToClient(new Point(e.X, e.Y));
            TreeNode targetNode = tvPartners.GetNodeAt(targetPoint);
            TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));

            if(targetNode == null || targetNode.Parent != null)
            {
                e.Effect = DragDropEffects.None;
                return;
            }

            var targetGroup = (PartnerGroup)targetNode.Tag;
            var draggedGroup = (PartnerGroup)draggedNode.Parent.Tag;
            var draggedPartner = (Partner)draggedNode.Tag;

            if (!targetGroup.Partners.Contains(draggedPartner))
            {
                if (e.Data.GetDataPresent(typeof(TreeNode)))
                {
                    e.Effect = DragDropEffects.Move;

                    if (tvPartners.SelectedNode != targetNode)
                    {
                        tvPartners.SelectedNode = targetNode;
                    }
                }
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void tsbtnAddGroup_Click(object sender, EventArgs e)
        {
            AddGroup();
        }

        private void tsbtnAddPartner_Click(object sender, EventArgs e)
        {
            AddPartner();
        }

        private void tsbtnDelete_Click(object sender, EventArgs e)
        {
            if(tvPartners.SelectedNode == null)
                return;

            var node = tvPartners.SelectedNode;
            if(node.Parent == null)
            {
                DeleteGroup(node);
            }
            else
            {
                DeletePartner(node);
            }
        }
    }
}
