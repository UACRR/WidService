using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CwrTools.FormRightHolderRoles;
using static CwrTools.UcProblemWorks;

namespace CwrTools
{
    public partial class FormRightHolderRoles : Form
    {
        public class RightHolderInfo
        {
            public int CustId			       { get; set; }
            public string Name	               { get; set; }
            public int RightHolderType	       { get; set; }
            public int CntA				       { get; set; }
            public int CntC				       { get; set; }
            public int CntAR				   { get; set; }
            public int CntE				       { get; set; }
            public int CntCA				   { get; set; }
            public int CntWrong			       { get; set; }
            public int? RightHolderTypeNew     { get; set; }
            public int? CopyRightRoleTypeNew   { get; set; }
            public bool IsCorrect              { get; set; }
            public bool IsApplied              { get; set; }
        }

        private List<RightHolderInfo> _rightHolderInfoList;

        private UcProblemWorks.ShowRightHolderProblemWorks _showRightHolderProblemWorks;

        public FormRightHolderRoles(UcProblemWorks.ShowRightHolderProblemWorks showRightHolderProblemWorks)
        {
            InitializeComponent();
            _showRightHolderProblemWorks = showRightHolderProblemWorks;
        }

        private void FormRightHolderRoles_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.FormRightHolderRolesSize.Width > 0 && Properties.Settings.Default.FormRightHolderRolesSize.Height > 0)
            {
                this.Location = Properties.Settings.Default.FormRightHolderRolesLocation;
                this.Size = Properties.Settings.Default.FormRightHolderRolesSize;
                this.WindowState = Properties.Settings.Default.FormRightHolderRolesState;
            }

            Configure();
            FillRightHolderInfoList();
            UpdateRightHolderControls();
        }

        private void Configure()
        {
            lvRightHolders.FullRowSelect = true;
            lvRightHolders.GridLines = true;
            lvRightHolders.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvRightHolders.MultiSelect = false;
            lvRightHolders.View = View.Details;
            lvRightHolders.SmallImageList = ilStatuses;

            lvRightHolders.Columns.Clear();
            lvRightHolders.Columns.Add("№ з/п", 50);
            lvRightHolders.Columns.Add("Код", 60);
            lvRightHolders.Columns.Add("Назва", 300);
            lvRightHolders.Columns.Add("Тип", 60).TextAlign = HorizontalAlignment.Center;
            lvRightHolders.Columns.Add("Новий тип", 70).TextAlign = HorizontalAlignment.Center;
            lvRightHolders.Columns.Add("Спільна роль", 80).TextAlign = HorizontalAlignment.Center;
            //lvRightHolders.Columns.Add("К-ть A",  60).TextAlign = HorizontalAlignment.Center;
            //lvRightHolders.Columns.Add("К-ть C",  60).TextAlign = HorizontalAlignment.Center;
            //lvRightHolders.Columns.Add("К-ть AR", 60).TextAlign = HorizontalAlignment.Center;
            //lvRightHolders.Columns.Add("К-ть E",  60).TextAlign = HorizontalAlignment.Center;
            //lvRightHolders.Columns.Add("К-ть CA", 60).TextAlign = HorizontalAlignment.Center;
            //lvRightHolders.Columns.Add("К-ть ERR", 60).TextAlign = HorizontalAlignment.Center;

            rbFilterAll.Checked = true;

        }

        private void FillRightHolderInfoList()
        {
            Helpers.RunSqlCwr(cmd =>
            {
                cmd.CommandText = @"
                    select t2.*, t1.*
                    from TmpRightHolderRoleCorrections t1
	                    join MediaService..vCustomerNamesShort t2 on t1.CustId = t2.CustId
                    order by t2.ShortName
                ";
                using (var r = cmd.ExecuteReader())
                {
                    _rightHolderInfoList = new List<RightHolderInfo>();
                    while (r.Read())
                    {
                        var rhi = new RightHolderInfo();
                        rhi.CustId			       = r.GetInt32(0);
                        rhi.Name	               = r.GetString(1);
                        rhi.RightHolderType	       = r.GetInt32(3);
                        rhi.CntA				   = r.GetInt32(4);
                        rhi.CntC				   = r.GetInt32(5);
                        rhi.CntAR				   = r.GetInt32(6);
                        rhi.CntE				   = r.GetInt32(7);
                        rhi.CntCA				   = r.GetInt32(8);
                        rhi.CntWrong			   = r.GetInt32(9);
                        rhi.RightHolderTypeNew     = r.IsDBNull(10) ? (int?)null : r.GetInt32(10);
                        rhi.CopyRightRoleTypeNew   = r.IsDBNull(11) ? (int?)null : r.GetInt32(11);
                        rhi.IsCorrect			   = r.GetBoolean(12);
                        rhi.IsApplied			   = r.GetBoolean(13);

                        _rightHolderInfoList.Add(rhi);
                    }
                }
            });
        }

        private int GetImageIndex(RightHolderInfo rhi)
        {
            return rhi.IsCorrect ? 1 : 2;
        }

        private void ApplyFilter()
        {
            if(_rightHolderInfoList == null)
            {
                FillRightHolderInfoList();
            }

            lvRightHolders.Items.Clear();
            var itemIdx = 1;
            _rightHolderInfoList.ForEach(rhi =>
            {
                if (
                    (
                        rbFilterAll.Checked || 
                        rbFilterAuthors.Checked && rhi.RightHolderType == 1 ||
                        rbFilterPublishers.Checked && rhi.RightHolderType == 3
                    )
                    && 
                    (
                        tbFilterNameText.Text.Trim() == "" ||
                        rhi.Name.ToLower().Contains(tbFilterNameText.Text.ToLower())
                    )
                )
                {
                    var item = lvRightHolders.Items.Add(itemIdx.ToString());
                    var rightHolderTypeTxt = GetRightHolderTypeSymb(rhi.RightHolderType);
                    var rightHolderTypeNewTxt = GetRightHolderTypeSymb((int)rhi.RightHolderTypeNew);

                    item.SubItems.Add(rhi.CustId.ToString());
                    item.SubItems.Add(rhi.Name);
                    item.SubItems.Add(rightHolderTypeTxt);
                    item.SubItems.Add(rightHolderTypeNewTxt);
                    item.SubItems.Add(GetCopyRightRoleSymb((int)rhi.CopyRightRoleTypeNew));
                    //item.SubItems.Add(rhi.CntA.ToString());
                    //item.SubItems.Add(rhi.CntC.ToString());
                    //item.SubItems.Add(rhi.CntAR.ToString());
                    //item.SubItems.Add(rhi.CntE.ToString());
                    //item.SubItems.Add(rhi.CntCA.ToString());
                    //item.SubItems.Add(rhi.CntWrong.ToString());

                    item.ImageIndex = GetImageIndex(rhi);
                    item.Tag = rhi;

                    itemIdx++;
                }
            });
        }

        private void CreateInfoInDb()
        {
            Helpers.RunSqlCwr(cmd =>
            {
                cmd.CommandTimeout = 0;
                cmd.CommandText = @"
                    truncate table TmpRightHolderRoleCorrections
                    insert TmpRightHolderRoleCorrections
                    select
	                      CustId			
	                    , rHolderType	
	                    , CntA				
	                    , CntC				
	                    , CntAR				
	                    , CntE				
	                    , CntCA				
	                    , CntWrong			
	                    , rHolderType
	                    , 0
                        , 0
                        , 0
                    from vWrongRoleAuthorsStat
                ";
                cmd.ExecuteNonQuery();
            });

            FillRightHolderInfoList();
            UpdateRightHolderControls();
        }

        private string GetRightHolderTypeSymb(int rightHolderType)
        {
            return rightHolderType == 1 ? "A" : "E";
        }
        
        private string GetCopyRightRoleSymb(int roleType)
        {
            return roleType == 1 ? "A" :
                roleType == 2 ? "C" :
                roleType == 7 ? "AR" :
                roleType == 8 ? "E" :
                roleType == 10 ? "CA" : "U";
        }

        private void ToggleRightHolderType()
        {
            if (lvRightHolders.SelectedItems.Count == 0)
            {
                return;
            }

            var rightHolderItem = lvRightHolders.SelectedItems[0];
            var rightHolderInfo = (RightHolderInfo)rightHolderItem.Tag;
            var custId = rightHolderInfo.CustId;
            var newRightHolderType = rightHolderInfo.RightHolderTypeNew == 1 ? 3 : 1;
            try
            {
                Cursor = Cursors.WaitCursor;
                Helpers.RunSqlCwrT(cmd =>
                {
                    cmd.CommandText = @"
                        update TmpRightHolderRoleCorrections
                        set RightHolderTypeNew = @rightHolderType, CopyRightRoleTypeNew = 8
                        where CustId = @CustId

                        update TmpRightHolderRoleCorrections
                        set IsCorrect = dbo.fnCheckRoleDefined(RightHolderTypeNew, CopyRightRoleTypeNew)
                        where CustId = @CustId

                        update TmpRightHolderRoleCorrections
                        set IsApplied = case when dbo.fnCheckRoleDefined(RightHolderTypeNew, CopyRightRoleTypeNew) = 0 then 0 else IsApplied end 
                        where CustId = @CustId

                        select RightHolderTypeNew
	                        , CopyRightRoleTypeNew
	                        , IsCorrect
	                        , IsApplied
                        from TmpRightHolderRoleCorrections
                        where CustId = @CustId  
                    ";
                    cmd.Parameters.AddWithValue("@rightHolderType", newRightHolderType);
                    cmd.Parameters.AddWithValue("@custId", custId);
                    using (var r = cmd.ExecuteReader())
                    {
                        r.Read();

                        rightHolderInfo.RightHolderTypeNew = r.GetInt32(0);
                        rightHolderInfo.CopyRightRoleTypeNew = r.GetInt32(1);
                        rightHolderInfo.IsCorrect = r.GetBoolean(2);
                        rightHolderInfo.IsApplied = r.GetBoolean(3);

                        rightHolderItem.SubItems[4].Text = GetRightHolderTypeSymb((int)rightHolderInfo.RightHolderTypeNew);
                        rightHolderItem.SubItems[5].Text = GetCopyRightRoleSymb((int)rightHolderInfo.CopyRightRoleTypeNew);

                        rightHolderItem.ImageIndex = GetImageIndex(rightHolderInfo);
                   }
                    
                });

                UpdateRightHolderControls();
                lvRightHolders.Focus();
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "Обробка проблемних творів", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetCopyRightRole(int copyRightRoleTypeNew)
        {
            if (lvRightHolders.SelectedItems.Count == 0)
            {
                return;
            }

            var rightHolderItem = lvRightHolders.SelectedItems[0];
            var rightHolderInfo = (RightHolderInfo)rightHolderItem.Tag;
            var custId = rightHolderInfo.CustId;
            var newRightHolderType = rightHolderInfo.RightHolderTypeNew == 1 ? 3 : 1;
            try
            {
                Cursor = Cursors.WaitCursor;
                Helpers.RunSqlCwrT(cmd =>
                {
                    cmd.CommandText = @"
                        update TmpRightHolderRoleCorrections
                        set CopyRightRoleTypeNew = @copyRightRoleTypeNew
                        where CustId = @CustId

                        update TmpRightHolderRoleCorrections
                        set IsCorrect = dbo.fnCheckRoleDefined(RightHolderTypeNew, CopyRightRoleTypeNew)
                        where CustId = @CustId

                        update TmpRightHolderRoleCorrections
                        set IsApplied = case when dbo.fnCheckRoleDefined(RightHolderTypeNew, CopyRightRoleTypeNew) = 0 then 0 else IsApplied end 
                        where CustId = @CustId

                        select RightHolderTypeNew
	                        , CopyRightRoleTypeNew
	                        , IsCorrect
	                        , IsApplied
                        from TmpRightHolderRoleCorrections
                        where CustId = @CustId  
                    ";
                    cmd.Parameters.AddWithValue("@CopyRightRoleTypeNew", copyRightRoleTypeNew);
                    cmd.Parameters.AddWithValue("@custId", custId);
                    using (var r = cmd.ExecuteReader())
                    {
                        r.Read();

                        rightHolderInfo.RightHolderTypeNew = r.GetInt32(0);
                        rightHolderInfo.CopyRightRoleTypeNew = r.GetInt32(1);
                        rightHolderInfo.IsCorrect = r.GetBoolean(2);
                        rightHolderInfo.IsApplied = r.GetBoolean(3);

                        rightHolderItem.SubItems[4].Text = GetRightHolderTypeSymb((int)rightHolderInfo.RightHolderTypeNew);
                        rightHolderItem.SubItems[5].Text = GetCopyRightRoleSymb((int)rightHolderInfo.CopyRightRoleTypeNew);

                        rightHolderItem.ImageIndex = GetImageIndex(rightHolderInfo);
                   }
                    
                });

                UpdateRightHolderControls();
                lvRightHolders.Focus();
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "Обробка проблемних творів", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateRightHolderControls()
        {
            if (lvRightHolders.SelectedItems.Count == 0)
            {
                btnSetRightHolderType.Enabled = 
                btnSetRoleU.Enabled           = 
                btnSetRoleA.Enabled           = 
                btnSetRoleC.Enabled           = 
                btnSetRoleAR.Enabled          = 
                btnSetRoleE.Enabled           = 
                btnSetRoleCA.Enabled          = false;

                tbCntU.Text           = 
                tbCntA.Text           = 
                tbCntC.Text           = 
                tbCntAR.Text          = 
                tbCntE.Text           = 
                tbCntCA.Text          = 
                tbCntERR.Text         = "";

                return;
            }

            var rightHolderItem = lvRightHolders.SelectedItems[0];
            var rightHolderInfo = (RightHolderInfo)rightHolderItem.Tag;

            btnSetRightHolderType.Enabled = true;
            btnSetRightHolderType.Text = rightHolderInfo.RightHolderTypeNew == 1 ? "E" : "A";
            
            btnSetRoleU.Enabled           = true;

            btnSetRoleA.Enabled           = true;
            btnSetRoleC.Enabled           = true;
            btnSetRoleAR.Enabled          = true;
            btnSetRoleE.Enabled           = true;
            btnSetRoleCA.Enabled          = true;

            tbCntU.Text     = "";
            tbCntA.Text     = rightHolderInfo.CntA.ToString();
            tbCntC.Text     = rightHolderInfo.CntC.ToString();
            tbCntAR.Text    = rightHolderInfo.CntAR.ToString();
            tbCntE.Text     = rightHolderInfo.CntE.ToString();
            tbCntCA.Text    = rightHolderInfo.CntCA.ToString();
            tbCntERR.Text   = rightHolderInfo.CntWrong.ToString();

        }

        private void btnCreateInfoInDb_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                CreateInfoInDb();
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "Обробка проблемних творів", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                ApplyFilter();
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "Обробка проблемних творів", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void setRightHolderType_Click(object sender, EventArgs e)
        {
            ToggleRightHolderType();
        }

        private void btnSetRoleU_Click(object sender, EventArgs e)
        {
            SetCopyRightRole(0);
        }

        private void btnSetRoleA_Click(object sender, EventArgs e)
        {
            SetCopyRightRole(1);
        }

        private void btnSetRoleC_Click(object sender, EventArgs e)
        {
            SetCopyRightRole(2);
        }

        private void btnSetRoleAR_Click(object sender, EventArgs e)
        {
            SetCopyRightRole(7);
        }

        private void btnSetRoleE_Click(object sender, EventArgs e)
        {
            SetCopyRightRole(8);
        }

        private void btnSetRoleCA_Click(object sender, EventArgs e)
        {
            SetCopyRightRole(10);
        }

        private void lvRightHolders_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateRightHolderControls();
        }

        private void btnShowRightHolderProblemWorks_Click(object sender, EventArgs e)
        {
            if (lvRightHolders.SelectedItems.Count == 0)
            {
                return;
            }

            var rightHolderItem = lvRightHolders.SelectedItems[0];
            var rightHolderInfo = (RightHolderInfo)rightHolderItem.Tag;
            var custId = rightHolderInfo.CustId;
            _showRightHolderProblemWorks(custId);
        }

        private void FormRightHolderRoles_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.FormRightHolderRolesLocation = this.Location;
            Properties.Settings.Default.FormRightHolderRolesSize = this.Size;
            Properties.Settings.Default.FormRightHolderRolesState = this.WindowState;

            Properties.Settings.Default.Save();
        }
    }
}
