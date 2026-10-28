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
        public class Partner
        {
            public int Id      { get; set; }
            public string Name { get; set; }
            public int PartnerGroupId { get; set; }
        }

        public class PartnerGroup
        {
            public int Id      { get; set; }
            public string Name { get; set; }
            public bool IsStandard { get; set; }
            public List<Partner> Partners { get; set; }
        }

        private List<PartnerGroup> _partnerGroups;

        public UcOutputFiles()
        {
            InitializeComponent();
        }

        private void UcOutputFiles_Load(object sender, EventArgs e)
        {
            if(Helpers.IsDesignMode())
                return;

            Configure();
            LoadPartnerGroups();
            FillPartnerGroups();
            tvPartners.SelectedNode = tvPartners.Nodes[0];
        }

        private void Configure()
        {
            ucGroupOutputFiles.Visible = false;

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
                                PartnerGroupId = grId,
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

        private bool PartnerExists(string name)
        {
             var retVal = false;
             Helpers.RunSqlCwr(cmd =>
             {
                cmd.CommandText = "select top 1 null from Partners where Name = @name";
                cmd.Parameters.AddWithValue("@name", name);
                retVal = cmd.ExecuteScalar() != null;
            });
            return retVal;
        }

        private string GetNewPartnerName()
        {
            var idx = 1;
            while(true)
            {
                var newName = $"Новий партнер {idx}";
                if(!PartnerExists(newName))
                    return newName;
                idx++;
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
            var name = GetNewPartnerName();
            Helpers.RunSqlCwr(cmd =>
            {
                cmd.CommandText = @"
                    insert Partners(
                          PartnerGroupId
                        , Name
                        , PeriodType
                        , EMail
                        , FtpUrl
                        , FtpLogin
                        , FtpPwd
                        , FtpPort
                    )
                    values(
                          @groupId
                        , @name
                        , 2
                        , ''
                        , ''
                        , ''
                        , ''
                        , 0
                    );
                    select cast(scope_identity() as int);
                ";
                cmd.Parameters.AddWithValue("@groupId", group.Id);
                cmd.Parameters.AddWithValue("@name", name);
                var newPartnerId = (int)cmd.ExecuteScalar();

                var newPartner = new Partner
                {
                    Id = newPartnerId,
                    Name = name,
                };
                group.Partners.Add(newPartner);

                var partnerNode = node.Nodes.Add(name);
                partnerNode.ImageIndex = 1;
                partnerNode.SelectedImageIndex = 1;
                partnerNode.Tag = newPartner;
                tvPartners.SelectedNode = partnerNode;
                partnerNode.BeginEdit();
            });
        }

        private string GetNewGroupName()
        {
            var idx = 1;
            while(true)
            {
                var newName = $"Нова група {idx}";
                if(!_partnerGroups.Any(x => x.Name.ToUpper() == newName.ToUpper()))
                    return newName;
                idx++;
            }
        }

        private void AddGroup()
        {
            Helpers.RunSqlCwr(cmd =>
            {
                var name = GetNewGroupName();
                cmd.CommandText = @"
                    insert PartnerGroups(Name,  IsStandard, IsV21, IsV22, AddNativeNames, AroundWorldRequired)
                    values              (@name, 0         , 1    , 0    , 0             , 1                  );
                    select cast(scope_identity() as int);
                ";
                cmd.Parameters.AddWithValue("@name", name);
                var newGrId = (int)cmd.ExecuteScalar();

                var newPg = new PartnerGroup
                {
                    Id = newGrId,
                    Name = name,
                    Partners = new List<Partner>(),
                };
                _partnerGroups.Add(newPg);

                var node = tvPartners.Nodes.Add(name);
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

            var sourceDir = CwrConfig.GetOutputGroupPath(group.Name);
            var targetDir = CwrConfig.GetOutputGroupPath(newName);
            if(Directory.Exists(sourceDir))
                Directory.Move(sourceDir, targetDir);

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
            var group = _partnerGroups.Single(x => x.Id == partner.PartnerGroupId);

            var sourceDir = CwrConfig.GetOutputPartnerPath(partner.Name);
            var targetDir = CwrConfig.GetOutputPartnerPath(newName);
            if(Directory.Exists(sourceDir))
                Directory.Move(sourceDir, targetDir);

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
                MessageBox.Show("Стандартні групи видаляти не можна", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (DialogResult.Yes !=
                MessageBox.Show($"Видалити групу {group.Name} і всю супутню інформацю?", "Питання", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                return;
            }

            var hasParters = false;
            Helpers.RunSqlCwr(cmd => {
                cmd.CommandText = @"
                    select null from Partners where PartnerGroupId = @groupId;
                ";
                cmd.Parameters.AddWithValue("@groupId", group.Id);
                hasParters = cmd.ExecuteScalar() != null;
            });
            if (DialogResult.Yes !=
                MessageBox.Show($"Група містить партнерів, видаліть партнерів сперш.", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning))
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

            var hasSentFiles = false;
            Helpers.RunSqlCwr(cmd => {
                cmd.CommandText = @"
                    select null from CwrPartnerFiles where PartnerId = @partnerId and Status not in (1, 2);
                ";
                cmd.Parameters.AddWithValue("@partnerId", partner.Id);
                hasSentFiles = cmd.ExecuteScalar() != null;
            });
            if (hasSentFiles)
            {
                MessageBox.Show($"Партнеру надіслані файли, видалити не можна.", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Helpers.RunSqlCwr(cmd => {
                cmd.CommandText = @"
                    delete from CwrPartnerFiles where PartnerId = @partnerId;
                    delete from Partners where Id = @partnerId;
                ";
                cmd.Parameters.AddWithValue("@partnerId", partner.Id);
                cmd.ExecuteNonQuery();
            });

            group.Partners.Remove(partner);
            tvPartners.Nodes.Remove(node);
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
                var group = (PartnerGroup)node.Tag;

                if(_partnerGroups.Any(x => x.Name.ToUpper() == e.Label.ToUpper()))
                {
                    e.CancelEdit = true;
                    MessageBox.Show("Група з такою назвою вже існує", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                RenameGroup(node, e.Label);
            }
            else
            {
                var partner = (Partner)node.Tag;

                if(PartnerExists(e.Label))
                {
                    e.CancelEdit = true;
                    MessageBox.Show("Партнер з такою назвою вже існує", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

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

        private void tsBtnPartnerSettings_Click(object sender, EventArgs e)
        {
            if (tvPartners.SelectedNode == null) {
                MessageBox.Show("Не обрана група або партнер", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(tvPartners.SelectedNode.Parent == null)
            {
                var group = (PartnerGroup)tvPartners.SelectedNode.Tag;
                if (group.IsStandard) {
                    MessageBox.Show("Зміни налаштувань стандартних груп не дозволені.", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                var form = new FormPartnerGroupSettings(group.Id, group.IsStandard);
                form.ShowDialog();
            }
            else
            {
                var partner = (Partner)tvPartners.SelectedNode.Tag;
                var form = new FormPartnerSettings(partner.Id);
                form.ShowDialog();
            }
        }

        private void tvPartners_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if(e.Node == null)
            {
                ucGroupOutputFiles.Visible = false;
            }
            else
            {
                var node = tvPartners.SelectedNode;
                if(node.Parent == null)
                {
                    var group = (PartnerGroup)node.Tag;
                    ucGroupOutputFiles.RefreshData(group.Id);
                    ucGroupOutputFiles.Dock = DockStyle.Fill;
                    ucGroupOutputFiles.Visible = true;
                    ucPartnerOutputFiles.Visible = false;
                }
                else
                {
                    var partner = (Partner)node.Tag;
                    ucPartnerOutputFiles.RefreshData(partner.Id);
                    ucPartnerOutputFiles.Dock = DockStyle.Fill;
                    ucGroupOutputFiles.Visible = false;
                    ucPartnerOutputFiles.Visible = true;
                }

            }
        }
    }
}
