using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WidSubmit.FormIpCodesLost;

namespace WidSubmit
{
    public partial class FormIpCodesLost : Form
    {
        private enum IMG
        {
            EMPTY,
            QUESTION,
            CHECK,
            WARNING,
            PENDING,
            PLUS,
            MINUS,
        }

        private static string[] FoundInTxt =
        {
            "Не шукався",
            "Не знайдено",
            "В IPI",
            "В CisNet",
        };

        private static string[] IsFinalTxt =
        {
            "ні",
            "так",
        };

        public class Author
        {
            public int    CustId     {  get; set; }
            public string FullNameMs {  get; set; }
            public int    FoundIn    {  get; set; }
            public int    IsFinal    {  get; set; }
        }

        public class CoAuthor
        {
            public int    CustId      {  get; set; }
            public string FullNameMs  {  get; set; }
            public string FullNameIpi {  get; set; }
            public string IpBaseNr    {  get; set; }
            public string IpNameNr    {  get; set; }
            public int    FoundIn     {  get; set; }
            public bool   IsFinal     {  get; set; }
        }

        public class FoundInIpi
        {
            public string FullName {  get; set; }
            public string IpBaseNr {  get; set; }
            public string IpNameNr {  get; set; }
        }

        private List<Author>     _authors;
        private List<CoAuthor>   _coAuthors;
        private List<FoundInIpi> _foundInIpi;

        private bool _ignoreControlEvents;

        public FormIpCodesLost()
        {
            InitializeComponent();
        }

        private void FormIpCodesLost_Load(object sender, EventArgs e)
        {
            Configure();
            LoadAuthors();
            FillAuthors();
        }

        private void Configure()
        {
            Helpers.ConfigureListView(lvAuthors
                , "Код СМАРТ"        
                , "Назва SMART"         
            );

            Helpers.ConfigureListView(lvCoAuthors
                , "Код СМАРТ"        
                , "Назва SMART" 
                , "Назва для IPI"
                , "IpBaseNr"  
                , "IpNameNr" 
                , "Де знайдено" 
                , "Потребує перевірки" 
            );

            Helpers.ConfigureListView(lvFoundInIpi
                , "Назва" 
                , "IpBaseNr"  
                , "IpNameNr"  
            );

            lvAuthors.SmallImageList = ilStatuses;
            lvAuthors.StateImageList = ilStatuses;

            lvCoAuthors.SmallImageList = ilStatuses;
            lvCoAuthors.StateImageList = ilStatuses;

            cbSearchIpiBy.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSearchIpiBy.Items.Clear();
            cbSearchIpiBy.Items.Add("Точна назва");
            cbSearchIpiBy.Items.Add("Початок назви");
            cbSearchIpiBy.SelectedIndex = 1;

            EnableControls(false);
        }

        private void LoadAuthors()
        {
            // var extraJoin = "";
            // if(rbAuthorsShowTopRated.Checked)
            // {
            //     extraJoin = "join Z_ImportantAuthors t3 on t1.CustIdAuthor = t3.CustId";
            // }
            Helpers.RunSqlSocWidSubmitEx(cmd =>
            {
                cmd.CommandText =$@"
                    with Authors as (
                        select distinct 
                              t1.CustIdAuthor
                            , t1.FullNameAuthor
		                    , t2.Prio
                        from Z_LostIpiCodes t1
		                    join Z_AuthorPrio t2 on t1.CustIdAuthor = t2.CustId
                    )
                    select t1.CustIdAuthor, t1.FullNameAuthor, min(t2.FoundIn), min(cast(t2.IsFinal as int)), t1.Prio
                    from Authors t1
                        join Z_LostIpiCodes t2 on t1.CustIdAuthor = t2.CustIdAuthor
                    group by t1.CustIdAuthor, t1.FullNameAuthor, t1.Prio
                    order by t1.Prio
                ";
                _authors = Helpers.CreateListFromCmd<Author>(cmd);
            });
         }

        private void UpdateAuthorItem(ListViewItem item)
        {
            var author = (Author)item.Tag;
            item.StateImageIndex = author.FoundIn == 0 ? (int)IMG.EMPTY : author.IsFinal == 1 ? (int)IMG.CHECK : (int)IMG.QUESTION;
            item.ImageIndex = author.FoundIn == 0 ? (int)IMG.EMPTY : author.FoundIn == 1 ? (int)IMG.MINUS : (int)IMG.PLUS;
        }

        private void ClearControls(bool keepLvCoAuthors = false)
        {
            if(!keepLvCoAuthors)
                lvCoAuthors       .Items.Clear();
            lvFoundInIpi          .Items.Clear();
            rbIsFinalYes          .Checked = false;
            rbIsFinalNo           .Checked = false;
            rbFoundInNs           .Checked = false;
            rbFoundInNf           .Checked = false;
            rbFoundInIpi          .Checked = false;
            rbFoundInCisNet       .Checked = false;
            tbIpBaseNr            .Text = "";
            tbIpNameNr            .Text = "";
            tbIpiSearchName       .Text = "";
            tbIpiSearchFstName    .Text = "";
            //btnApplyIpiCodes      
            //btnClearIpiCodes      
            //btnSearchIpi          
        }

        private void EnableControls(bool enable, bool keepLvCoAuthors = false)
        {
            if(!keepLvCoAuthors)
                lvCoAuthors       .Enabled = enable;
            lvFoundInIpi          .Enabled = enable;
            rbIsFinalYes          .Enabled = enable;
            rbIsFinalNo           .Enabled = enable;
            rbFoundInNs           .Enabled = enable;
            rbFoundInNf           .Enabled = enable;
            rbFoundInIpi          .Enabled = enable;
            rbFoundInCisNet       .Enabled = enable;
            tbIpBaseNr            .Enabled = enable;
            tbIpNameNr            .Enabled = enable;
            tbIpiSearchName       .Enabled = enable;
            tbIpiSearchFstName    .Enabled = enable;
            btnApplyIpiCodes      .Enabled = enable;
            btnSearchIpi          .Enabled = enable;
        }
        
        private void UpdateAuthorItems()
        {
            foreach(ListViewItem item in lvAuthors.Items)
            {
                UpdateAuthorItem(item);
            }
            lvAuthors.Columns[0].Width = 70;
        }

        private void FillAuthors()
        {
            Helpers.FillListView(_authors, lvAuthors, author =>
            {
                if(tbAuthorsFilter.Text.Trim() != "" && !author.FullNameMs.ToUpper().Contains(tbAuthorsFilter.Text.Trim().ToUpper()))
                    return true;
                return false;
            });
                   
            UpdateAuthorItems();

        }

        private void LoadCoAuthors(int custIdAuthor)
        {
            Helpers.RunSqlSocWidSubmitEx(cmd =>
            {
                cmd.CommandText = @"
                    select CustIdCoAuthor, FullNameCoAuthor, FullNameCoAuthorTr, IpBaseNr, IpNameNr, FoundIn, IsFinal
                    from Z_LostIpiCodes
                    where CustIdAuthor = @custIdAuthor
                    order by FullNameCoAuthor                
                ";
                cmd.Parameters.AddWithValue("@custIdAuthor", custIdAuthor);
                _coAuthors = Helpers.CreateListFromCmd<CoAuthor>(cmd);
            });
        }

        private void UpdateCoAuthorItem(ListViewItem item)
        {
            var coAuthor = (CoAuthor)item.Tag;
            item.SubItems[4].Text = coAuthor.IpBaseNr.ToString();
            item.SubItems[5].Text = coAuthor.IpNameNr.ToString();
            item.SubItems[6].Text = FoundInTxt[coAuthor.FoundIn];
            item.SubItems[7].Text = IsFinalTxt[coAuthor.IsFinal ? 0 : 1];
            item.StateImageIndex = coAuthor.FoundIn == 0 ? (int)IMG.EMPTY : coAuthor.IsFinal ? (int)IMG.CHECK : (int)IMG.QUESTION;
            item.ImageIndex = coAuthor.FoundIn == 0 ? (int)IMG.EMPTY : coAuthor.FoundIn == 1 ? (int)IMG.MINUS : (int)IMG.PLUS;

            var author = (Author)lvAuthors.SelectedItems[0].Tag;
            author.FoundIn = _coAuthors.Min(x => x.FoundIn);
            author.IsFinal = _coAuthors.Min(x => Convert.ToInt32(x.IsFinal));
            UpdateAuthorItem(lvAuthors.SelectedItems[0]);
        }

        private void UpdateCoAuthorControls(CoAuthor coAuthor)
        {
            _ignoreControlEvents = true;

            rbIsFinalYes.Checked = coAuthor.IsFinal ? false  : true;
            rbIsFinalNo .Checked = coAuthor.IsFinal ? true : false;

            rbFoundInNs    .Checked = coAuthor.FoundIn == 0 ? true : false;
            rbFoundInNf    .Checked = coAuthor.FoundIn == 1 ? true : false;
            rbFoundInIpi   .Checked = coAuthor.FoundIn == 2 ? true : false;
            rbFoundInCisNet.Checked = coAuthor.FoundIn == 3 ? true : false;

            rbFoundInNs    .Enabled = true;
            rbFoundInNf    .Enabled = true;
            rbFoundInIpi   .Enabled = coAuthor.IpBaseNr != "";
            rbFoundInCisNet.Enabled = coAuthor.IpBaseNr != "";

            var parts = coAuthor.FullNameIpi.Split(' ');
            lvFoundInIpi.Items.Clear();
            tbIpBaseNr.Text = "";
            tbIpNameNr.Text = "";
            tbIpiSearchName.Text = parts[0];
            if (parts.Length > 1)
            {
                tbIpiSearchFstName.Text = parts[1].Substring(0, Math.Min(2, parts[1].Length));
            }

            _ignoreControlEvents = false;
        }

        private void FillCoAuthors()
        {
            Helpers.FillListView(_coAuthors, lvCoAuthors, coAuthor =>
            {
                return false;
            });

            lvCoAuthors.BeginUpdate();

            foreach(ListViewItem item in lvCoAuthors.Items)
            {
                UpdateCoAuthorItem(item);
            }

            lvCoAuthors.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvCoAuthors.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            lvCoAuthors.Columns[2].Width = 200;
            lvCoAuthors.Columns[3].Width = 100;
            lvCoAuthors.Columns[4].Width = 100;
            lvCoAuthors.Columns[5].Width = 100;
            lvCoAuthors.EndUpdate();
        }
        
        private void LoadFoundInIpi()
        {
            if(tbIpiSearchName.Text.Trim() == "")
                return;

            var oper = cbSearchIpiBy.SelectedIndex == 0 ? " = " : " like ";
            var addFilter = "";
            if(tbIpiSearchFstName.Text.Trim() != "")
                addFilter = " and FstName like @fstName";

            Helpers.RunSqlSocWidSubmitEx(cmd =>
            {
                cmd.CommandText = $@"
                    select top 10 trim(concat(Name, ' ', FstName) ), IpBaseNr, cast(IpNameNr as varchar(16))
                    from SocIpi..IpiName
                    where Name {oper} @name
                        {addFilter}
                ";
                cmd.Parameters.AddWithValue("@name", 
                    cbSearchIpiBy.SelectedIndex == 0 ? tbIpiSearchName.Text.Trim() : $"{tbIpiSearchName.Text.Trim()}%");
                cmd.Parameters.AddWithValue("@fstName", $"{tbIpiSearchFstName.Text.Trim()}%");
                _foundInIpi = Helpers.CreateListFromCmd<FoundInIpi>(cmd);
            });
        }

        private void FillFoundInIpi()
        {
            Helpers.FillListView(_foundInIpi, lvFoundInIpi, foundInIpi =>
            {
                return false;
            });
        }

        private void ApplyIpCodes()
        {
            if(lvCoAuthors.SelectedItems.Count == 0)
            {
                Helpers.ShowErrMsg("Не обрано співавтора");
                return;
            }

            var ipBaseNr = tbIpBaseNr.Text;
            var ipNameNr = tbIpNameNr.Text;

            if(!Helpers.IsValidIpBaseNr(ipBaseNr))
            {
                Helpers.ShowErrMsg("Невірний формат базового коду");
                return;
            }
            if(!Helpers.IsValidIpNameNr(ipNameNr))
            {
                Helpers.ShowErrMsg("Невірний формат коду назви");
                return;
            }

            var item = lvCoAuthors.SelectedItems[0];
            var coAuthor = (CoAuthor)item.Tag;
            Helpers.RunSqlSocWidSubmitEx(cmd =>
            {
                cmd.CommandText = $@"
                    update Z_LostIpiCodes
                    set
                          IpBaseNr = @ipBaseNr
                        , IpNameNr = @ipNameNr
                        , FoundIn = 2
                        , IsFinal = 1
                    where CustIdCoAuthor = @custId
                ";
                cmd.Parameters.AddWithValue("@ipBaseNr", ipBaseNr);
                cmd.Parameters.AddWithValue("@ipNameNr", ipNameNr);
                cmd.Parameters.AddWithValue("@custId", coAuthor.CustId);
                cmd.ExecuteNonQuery();
            });

            coAuthor.IpBaseNr = ipBaseNr;
            coAuthor.IpNameNr = ipNameNr;
            coAuthor.FoundIn = 2;
            coAuthor.IsFinal = true;
            UpdateCoAuthorItem(item);
            UpdateCoAuthorControls(coAuthor);
        }

        private void ClearIpCodes()
        {
            if(lvCoAuthors.SelectedItems.Count == 0)
            {
                Helpers.ShowErrMsg("Не обрано співавтора");
                return;
            }

            var item = lvCoAuthors.SelectedItems[0];
            var coAuthor = (CoAuthor)item.Tag;
            Helpers.RunSqlSocWidSubmitEx(cmd =>
            {
                cmd.CommandText = $@"
                    update Z_LostIpiCodes
                    set
                          IpBaseNr = ''
                        , IpNameNr = '' 
                        , FoundIn = 1
                    where CustIdCoAuthor = @custId
                ";
                cmd.Parameters.AddWithValue("@custId", coAuthor.CustId);
                cmd.ExecuteNonQuery();
            });

            coAuthor.IpBaseNr = "";
            coAuthor.IpNameNr = "";
            coAuthor.FoundIn = 1;
            UpdateCoAuthorItem(item);
            UpdateCoAuthorControls(coAuthor);
        }

        private void ApplyFoundIn(int newValue)
        {
            if(lvCoAuthors.SelectedItems.Count == 0)
            {
                Helpers.ShowErrMsg("Не обрано співавтора");
                return;
            }

            var item = lvCoAuthors.SelectedItems[0];
            var coAuthor = (CoAuthor)item.Tag;
            var extraSetValue = newValue == 0 || newValue == 1 ? ", IpBaseNr = '', IpNameNr = '' " : "";
            Helpers.RunSqlSocWidSubmitEx(cmd =>
            {
                cmd.CommandText = $@"
                    update Z_LostIpiCodes
                    set FoundIn = @foundIn
                        , IsFinal = 1
                        {extraSetValue}
                    where CustIdCoAuthor = @custId
                ";
                cmd.Parameters.AddWithValue("@custId", coAuthor.CustId);
                cmd.Parameters.AddWithValue("@foundIn", newValue);
                cmd.ExecuteNonQuery();
            });

            if(newValue == 0 || newValue == 1)
            {
                coAuthor.IpBaseNr = "";
                coAuthor.IpNameNr = "";
            }
            coAuthor.FoundIn = newValue;
            coAuthor.IsFinal = true;
            UpdateCoAuthorItem(item);
            UpdateCoAuthorControls(coAuthor);
        }

        private void ApplyIsFinal(bool newValue)
        {
            if(lvCoAuthors.SelectedItems.Count == 0)
            {
                Helpers.ShowErrMsg("Не обрано співавтора");
                return;
            }

            var item = lvCoAuthors.SelectedItems[0];
            var coAuthor = (CoAuthor)item.Tag;
            Helpers.RunSqlSocWidSubmitEx(cmd =>
            {
                cmd.CommandText = $@"
                    update Z_LostIpiCodes set IsFinal = @isFinal where CustIdCoAuthor = @custId
                ";
                cmd.Parameters.AddWithValue("@custId", coAuthor.CustId);
                cmd.Parameters.AddWithValue("@isFinal", newValue);
                cmd.ExecuteNonQuery();
            });

            coAuthor.IsFinal = newValue;
            UpdateCoAuthorItem(item);
            UpdateCoAuthorControls(coAuthor);
        }

        private void tbAuthorsFilter_TextChanged(object sender, EventArgs e)
        {
            EnableControls(false);
            ClearControls();
            FillAuthors();
        }

        private void lvAuthors_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ignoreControlEvents = true;

            if(lvAuthors.SelectedItems.Count == 0)
            {
                EnableControls(false);
                ClearControls();
            }
            else
            {
                EnableControls(true);
                var item = lvAuthors.SelectedItems[0];
                var author = (Author)item.Tag;
                LoadCoAuthors(author.CustId);
                FillCoAuthors();
                EnableControls(false, true);
            }
            
            _ignoreControlEvents = false;
        }

        private void lvCoAuthors_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ignoreControlEvents = true;
                
            if(lvCoAuthors.SelectedItems.Count == 0)
            {
                EnableControls(false, true);
                ClearControls(true);
            }
            else
            {
                EnableControls(true);

                var item = lvCoAuthors.SelectedItems[0];
                var coAuthor = (CoAuthor)item.Tag;

                btnSearchIpi.Enabled = true;

                UpdateCoAuthorControls(coAuthor);

            }

            _ignoreControlEvents = false;
        }

        private void lvFoundInIpi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lvFoundInIpi.SelectedItems.Count == 0)
            {
                tbIpBaseNr.Text = "";
                tbIpNameNr.Text = "";
                return;
            }

            var item = lvFoundInIpi.SelectedItems[0];
            var foundInIpi = (FoundInIpi)item.Tag;
            tbIpBaseNr.Text = foundInIpi.IpBaseNr;
            tbIpNameNr.Text = foundInIpi.IpNameNr;
        }

        private void btnApplyIpiCodes_Click(object sender, EventArgs e)
        {
            Helpers.RunProtected( () =>
            {
                ApplyIpCodes();
            });
        }

        private void btnClearIpiCodes_Click(object sender, EventArgs e)
        {
           //Helpers.RunProtected( () =>
           //{
           //    //ClearIpCodes();
           //});
        }

        private void btnSearchIpi_Click(object sender, EventArgs e)
        {
            Helpers.RunProtected( () =>
            {
                LoadFoundInIpi();
                FillFoundInIpi();
            });
        }

        private void btnApply_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void rbAuthorsShowAll_CheckedChanged(object sender, EventArgs e)
        {
            _ignoreControlEvents = true;
            EnableControls(false);
            ClearControls();
            Helpers.RunProtected ( () =>
            {
                LoadAuthors();
                FillAuthors();
            });
            _ignoreControlEvents = false;
        }

        private void rbAuthorsShowTopRated_CheckedChanged(object sender, EventArgs e)
        {
            _ignoreControlEvents = true;
            EnableControls(false);
            ClearControls();
            Helpers.RunProtected ( () =>
            {
                LoadAuthors();
                FillAuthors();
            });
            _ignoreControlEvents = false;
        }

        private void rbIsFinalYes_CheckedChanged(object sender, EventArgs e)
        {
            if(_ignoreControlEvents)
                return;

            Helpers.RunProtected ( () =>
            {
                ApplyIsFinal(false);
            });
        }

        private void rbIsFinalNo_CheckedChanged(object sender, EventArgs e)
        {
             if(_ignoreControlEvents)
                return;
            
            Helpers.RunProtected ( () =>
            {
                ApplyIsFinal(true);
            });
        }

        private void rbFoundInNs_CheckedChanged(object sender, EventArgs e)
        {
            if(_ignoreControlEvents)
                return;
            
            Helpers.RunProtected ( () =>
            {
                ApplyFoundIn(0);
            });
        }

        private void rbFoundInNf_CheckedChanged(object sender, EventArgs e)
        {
            if(_ignoreControlEvents)
                return;
            
            Helpers.RunProtected ( () =>
            {
                ApplyFoundIn(1);
            });
        }

        private void rbFoundInIpi_CheckedChanged(object sender, EventArgs e)
        {
            if(_ignoreControlEvents)
                return;
            
            Helpers.RunProtected ( () =>
            {
                ApplyFoundIn(2);
            });
        }

        private void rbFoundInCisNet_CheckedChanged(object sender, EventArgs e)
        {
            if(_ignoreControlEvents)
                return;
            
            Helpers.RunProtected ( () =>
            {
                ApplyFoundIn(3);
            });
        }
    }
}
