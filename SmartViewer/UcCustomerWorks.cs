using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartViewer
{
    public partial class UcCustomerWorks : UserControl
    {
        public class Customer
        {
            public int    CustId { get; set; }
            public string Name   { get; set; }
        }

        public class Work
        {
            public int    ObjId { get; set; }
            public string Name   { get; set; }
            public string Iswc   { get; set; }
            public string Wic   { get; set; }
            public DateTime? UpdatedOn   { get; set; }
        }

        public class Share
        {
            public int     CustId          { get; set; }
            public string  Name            { get; set; }
            public string  RightHolderType { get; set; }
            public string  Role            { get; set; }
            public string  IpBaseNr        { get; set; }
            public string  IpNameNr        { get; set; }
            public string  IsOwn           { get; set; }
            public decimal ShrPer          { get; set; }
            public decimal ShrMec          { get; set; }
        }

        public class ShareDetailIpi
        {
            public string RightType { get; set; }
            public string Soc       { get; set; }
            public string Rol       { get; set; }
            public string Terr      { get; set; }
            public string IncExc    { get; set; }
        }

        public class AltName
        {
            public int    Id     { get; set; }
            public string Name   { get; set; }
        }

        public class Performer
        {
            public int    Id     { get; set; }
            public string Name   { get; set; }
        }

        private List<Customer>       _customers;
        private List<Work>           _works;
        private List<Share>          _shares;
        private List<AltName>        _altNames;
        private List<Performer>      _performers;
        private List<ShareDetailIpi> _shareDetailsIpi;

        public UcCustomerWorks()
        {
            InitializeComponent();
        }

        private void UcCustomers_Load(object sender, EventArgs e)
        {
            ClearContent(0);
            Configure();
        }

        private void Configure()
        {
            tbCustomerFilterValue.Text = "тополя";

            lvCustomers.FullRowSelect = true;
            lvCustomers.GridLines = true;
            lvCustomers.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvCustomers.MultiSelect = false;
            lvCustomers.View = View.Details;

            lvCustomers.Columns.Clear();
            lvCustomers.Columns.Add("№", 60);
            lvCustomers.Columns.Add("Код СМАРТ", 80);
            lvCustomers.Columns.Add("Назва СМАРТ", 300);

            lvWorks.FullRowSelect = true;
            lvWorks.GridLines = true;
            lvWorks.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvWorks.MultiSelect = false;
            lvWorks.View = View.Details;

            lvWorks.Columns.Clear();
            lvWorks.Columns.Add("№", 60);
            lvWorks.Columns.Add("Код СМАРТ", 80);
            lvWorks.Columns.Add("Назва СМАРТ", 300);
            lvWorks.Columns.Add("ISWC", 80);
            lvWorks.Columns.Add("WIC", 80);
            lvWorks.Columns.Add("Дата зміни", 80);

            lvShares.FullRowSelect = true;
            lvShares.GridLines = true;
            lvShares.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvShares.MultiSelect = false;
            lvShares.View = View.Details;

            lvShares.Columns.Clear();
            lvShares.Columns.Add("№", 60);
            lvShares.Columns.Add("Код СМАРТ", 80);
            lvShares.Columns.Add("Назва СМАРТ", 200);
            lvShares.Columns.Add("Тип", 100);
            lvShares.Columns.Add("Роль", 100);
            lvShares.Columns.Add("Міжн. Код", 80);
            lvShares.Columns.Add("Код Назви", 80);
            lvShares.Columns.Add("Відносно тов.", 80);
            lvShares.Columns.Add("Пуб%", 60);
            lvShares.Columns.Add("Мех%", 60);

            lvAltNames.FullRowSelect = true;
            lvAltNames.GridLines = true;
            lvAltNames.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvAltNames.MultiSelect = false;
            lvAltNames.View = View.Details;

            lvAltNames.Columns.Clear();
            lvAltNames.Columns.Add("№", 60);
            lvAltNames.Columns.Add("Код СМАРТ", 80);
            lvAltNames.Columns.Add("Назва СМАРТ", 300);

            lvPerformers.FullRowSelect = true;
            lvPerformers.GridLines = true;
            lvPerformers.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvPerformers.MultiSelect = false;
            lvPerformers.View = View.Details;

            lvPerformers.Columns.Clear();
            lvPerformers.Columns.Add("№", 60);
            lvPerformers.Columns.Add("Код СМАРТ", 80);
            lvPerformers.Columns.Add("Назва СМАРТ", 300);

            lvShareDetailsIpi.FullRowSelect = true;
            lvShareDetailsIpi.GridLines = true;
            lvShareDetailsIpi.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvShareDetailsIpi.MultiSelect = false;
            lvShareDetailsIpi.View = View.Details;

            lvShareDetailsIpi.Columns.Clear();
            lvShareDetailsIpi.Columns.Add("№", 60);
            lvShareDetailsIpi.Columns.Add("Тип права", 80);
            lvShareDetailsIpi.Columns.Add("Товариство", 100);
            lvShareDetailsIpi.Columns.Add("Роль", 100);
            lvShareDetailsIpi.Columns.Add("Територія", 100);
            lvShareDetailsIpi.Columns.Add("Вкл/Викл", 600);

        }

        private void ClearContent(int level)
        {
            if(level <= 0)
            {
                lvCustomers.Items.Clear();
            }

            if(level <= 1)
            {
                lvWorks.Items.Clear();
            }

            if(level <= 2)
            {
                lvShares.Items.Clear();
                lvAltNames.Items.Clear();
                lvPerformers.Items.Clear();
            }

            if(level <= 3)
            {
                lvShareDetailsIpi.Items.Clear();
                ucShareDetailsMs.ClearContent();
            }
        }

        private void LoadCustomers()
        {
            var filter = tbCustomerFilterValue.Text;
            if(filter.Length < 3) return;
            filter = $"%{filter}%";
            Helpers.RunSqlMediaService(cmd =>
            {
                cmd.CommandText = @"
                    select CustId, Name
                    from vCustomerNames
                    where Name like @filter
                        or CustId = try_cast(@filter1 as int)
                    order by Name
                ";
                cmd.Parameters.AddWithValue("@filter", filter);
                cmd.Parameters.AddWithValue("@filter1", tbCustomerFilterValue.Text);
                
                using (var r = cmd.ExecuteReader())
                {
                    _customers = new List<Customer>();
                    while (r.Read())
                    {
                        var idx = 0;
                        var customer = new Customer();
	                    customer.CustId = r.GetInt32(idx); idx++;
	                    customer.Name   = r.GetString(idx); idx++;
                        
                        _customers.Add(customer);
                    }
                }
            });

       }

        private void FillLvCustomers()
        {
            lvCustomers.BeginUpdate();
            lvCustomers.Items.Clear();
            
            var seqNr = 1;
            _customers.ForEach(x =>
            {
                var item = new ListViewItem(seqNr.ToString());
                item.SubItems.Add(x.CustId.ToString());
                item.SubItems.Add(x.Name);
                item.Tag = x;

                lvCustomers.Items.Add(item);
                seqNr++;
            });
            lvCustomers.EndUpdate();
        }

        private void LoadWorks(int custId)
        {
            Helpers.RunSqlMediaService(cmd =>
            {
                cmd.CommandText = @"
                    select distinct 
	                      t2.ObjId
	                    , t2.Name
	                    , isnull(t2.Iswc, '') as Iswc
	                    , case 
		                    when cast(isnull(t3.Wic, '') as varchar(16)) = 0 then '' 
		                    else  cast(isnull(t3.Wic, '') as varchar(16))
		                    end as Wic
	                    , t2.ModifyDate
                    from CopyRight t1
                        join MediaTrack t2 on t1.ObjId = t2.ObjId
	                    left join RepMSWIC t3 on t1.ObjId = t3.ObjId
                    where CustId = @custId
                    order by Name
                ";
                cmd.Parameters.AddWithValue("@custId", custId);
                
                using (var r = cmd.ExecuteReader())
                {
                    _works = new List<Work>();
                    while (r.Read())
                    {
                        var idx = 0;
                        var work = new Work();
	                    work.ObjId       = r.GetInt32(idx) ; idx++;
	                    work.Name        = r.GetString(idx); idx++;
                        work.Iswc        = r.GetString(idx); idx++;
                        work.Wic         = r.GetString(idx); idx++;
                        work.UpdatedOn   = r.IsDBNull(idx) ? (DateTime?)null : r.GetDateTime(idx); idx++;
                        
                        _works.Add(work);
                    }
                }
            });

       }

        private void FillLvWorks()
        {
            lvWorks.BeginUpdate();
            lvWorks.Items.Clear();
            
            var seqNr = 1;
            _works.ForEach(x =>
            {
                var item = new ListViewItem(seqNr.ToString());
                item.SubItems.Add(x.ObjId.ToString());
                item.SubItems.Add(x.Name);
                item.SubItems.Add(x.Iswc);
                item.SubItems.Add(x.Wic);
                item.SubItems.Add(x.UpdatedOn == null ? "" : ((DateTime)x.UpdatedOn).ToString("yyyy-MM-dd"));
                item.Tag = x;

                lvWorks.Items.Add(item);
                seqNr++;
            });
            lvWorks.EndUpdate();
        }

        private void LoadShares(int objId)
        {
            Helpers.RunSqlMediaService(cmd =>
            {
                cmd.CommandText = @"
                    select
	                      t1.CustId
	                    , t2.ShortName as Name
	                    , concat(t5.CodeI, '-', t5.Name) as RightHolderType
						, concat(t6.CodeI, '-', t6.Name) as Role
	                    , cast(isnull(t4.InterCode, '') as varchar(16)) as IpBaseNr
	                    , cast(isnull(t4.IPIBase, '') as varchar(16)) as IpNameNr
	                    , case when t3.CustId is null then 'Чужий' else 'Свій' end as IsOwn
	                    , t1.Rate
	                    , t1.RateMech
                    from CopyRight t1
                        join vCustomerNamesShort t2 on t1.CustId = t2.CustId
	                    left join AgreementAddRh t3 on t1.CustId = t3.CustId
		                    and getdate() between t3.DateBegin and t3.DateEnd
		                    and t3.agrStatus = 2
	                    join RightHolder t4 on t1.CustId = t4.CustId
	                    join RHolderType t5 on t4.rHolderType = t5.CodeI
						join CreativeRoleType t6 on t1.roleCode = t6.CodeI
                    where t1.ObjId = @objId
                         and getdate() between t1.beginDate and t1.EndDate
                    order by t2.ShortName
                ";
                cmd.Parameters.AddWithValue("@objId", objId);
                
                using (var r = cmd.ExecuteReader())
                {
                    _shares = new List<Share>();
                    while (r.Read())
                    {
                        var idx = 0;
                        var share = new Share();
	                    share.CustId            = r.GetInt32(idx);      idx++;
	                    share.Name              = r.GetString(idx);     idx++;
                        share.RightHolderType   = r.GetString(idx);     idx++;
                        share.Role              = r.GetString(idx);     idx++;
                        share.IpBaseNr          = r.GetString(idx);     idx++;
                        share.IpNameNr          = r.GetString(idx);     idx++;
                        share.IsOwn             = r.GetString(idx);     idx++;
                        share.ShrPer            = r.GetDecimal(idx);    idx++;
                        share.ShrMec            = r.GetDecimal(idx);    idx++;
                        
                        _shares.Add(share);
                    }
                }
            });

       }

        private void FillLvShares()
        {
            lvShares.BeginUpdate();
            lvShares.Items.Clear();
            
            var seqNr = 1;
            _shares.ForEach(x =>
            {
                var item = new ListViewItem(seqNr.ToString());
                item.SubItems.Add(x.CustId.ToString());
                item.SubItems.Add(x.Name);
                item.SubItems.Add(x.RightHolderType);
                item.SubItems.Add(x.Role);
                item.SubItems.Add(x.IpBaseNr);
                item.SubItems.Add(x.IpNameNr);
                item.SubItems.Add(x.IsOwn);
                item.SubItems.Add(x.ShrPer.ToString());
                item.SubItems.Add(x.ShrMec.ToString());
                item.Tag = x;

                lvShares.Items.Add(item);
                seqNr++;
            });
            lvShares.EndUpdate();
        }

        private void LoadAltNames(int objId)
        {
            Helpers.RunSqlMediaService(cmd =>
            {
                cmd.CommandText = @"
                    select Id, Name 
                    from SeekObject
                    where ObjId = @objId
	                    and CodeI = 1
                    order by Name
                ";
                cmd.Parameters.AddWithValue("@objId", objId);
                
                using (var r = cmd.ExecuteReader())
                {
                    _altNames = new List<AltName>();
                    while (r.Read())
                    {
                        var idx = 0;
                        var altName = new AltName();
	                    altName.Id = r.GetInt32(idx); idx++;
	                    altName.Name   = r.GetString(idx); idx++;
                        
                        _altNames.Add(altName);
                    }
                }
            });

       }

        private void FillLvAltNames()
        {
            lvAltNames.BeginUpdate();
            lvAltNames.Items.Clear();
            
            var seqNr = 1;
            _altNames.ForEach(x =>
            {
                var item = new ListViewItem(seqNr.ToString());
                item.SubItems.Add(x.Id.ToString());
                item.SubItems.Add(x.Name);
                item.Tag = x;

                lvAltNames.Items.Add(item);
                seqNr++;
            });
            lvAltNames.EndUpdate();
        }
        
        private void LoadPerformers(int objId)
        {
            Helpers.RunSqlMediaService(cmd =>
            {
                cmd.CommandText = @"
                    select Id, Name 
                    from SeekObject
                    where ObjId = @objId
	                    and CodeI = 2
                    order by Name
                ";
                cmd.Parameters.AddWithValue("@objId", objId);
                
                using (var r = cmd.ExecuteReader())
                {
                    _performers = new List<Performer>();
                    while (r.Read())
                    {
                        var idx = 0;
                        var performer = new Performer();
	                    performer.Id = r.GetInt32(idx); idx++;
	                    performer.Name   = r.IsDBNull(idx) ? "" : r.GetString(idx); idx++;
                        
                        _performers.Add(performer);
                    }
                }
            });

       }

        private void FillLvPerformers()
        {
            lvPerformers.BeginUpdate();
            lvPerformers.Items.Clear();
            
            var seqNr = 1;
            _performers.ForEach(x =>
            {
                var item = new ListViewItem(seqNr.ToString());
                item.SubItems.Add(x.Id.ToString());
                item.SubItems.Add(x.Name);
                item.Tag = x;

                lvPerformers.Items.Add(item);
                seqNr++;
            });
            lvPerformers.EndUpdate();
        }

        private void LoadShareDetailsIpi(string ipBaseNr)
        {
            _shareDetailsIpi = new List<ShareDetailIpi>();
            if (string.IsNullOrEmpty(ipBaseNr))
            {
                return;
            }
            Helpers.RunSqlMediaService(cmd =>
            {
                cmd.CommandText = @"
                     select
	                      case when t1.RgtCde = 'PR' then 'Пуб' else 'Мех' end
	                    , trim(concat(t2.Cde, '-', t2.Name)) as Soc
	                    , t1.rolCde
	                    , t3.Tisan
	                    , t3.IncExcInd
                    from SocIpi..IpiAgreement t1
	                    join SocIpi..DicSoc t2 on t1.SocCde = t2.Cde
	                    join SocIpi..IpiTerritory t3 on t1.IpAgreeNr = t3.IpAgreeNr
                    where t1.IpBaseNr = @ipBaseNr
	                    and t1.CreClsCde = 'MW'
	                    and t1.RolCde in ('LY', 'MC', 'EM')
	                    and t1.RgtCde in ('MR', 'PR')
	                    and getdate() between t1.FromDt and t1.ToDt
                    order by t1.RgtCde desc, t2.Cde, t1.rolCde, t3.Tisan, t3.IncExcInd
                ";
                cmd.Parameters.AddWithValue("@ipBaseNr", ipBaseNr);
                
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        var idx = 0;
                        var shareDetailIpi = new ShareDetailIpi();
	                    shareDetailIpi.RightType = r.GetString(idx); idx++;
	                    shareDetailIpi.Soc       = r.GetString(idx); idx++;
                        shareDetailIpi.Rol       = r.GetString(idx); idx++;
                        shareDetailIpi.Terr      = r.GetString(idx); idx++;
                        shareDetailIpi.IncExc    = r.GetString(idx); idx++;
                        
                        _shareDetailsIpi.Add(shareDetailIpi);
                    }
                }
            });

       }

        private void FillLvShareDetailsIpi()
        {
            lvShareDetailsIpi.BeginUpdate();
            lvShareDetailsIpi.Items.Clear();
            
            var seqNr = 1;
            _shareDetailsIpi.ForEach(x =>
            {
                var item = new ListViewItem(seqNr.ToString());
                item.SubItems.Add(x.RightType.ToString()    );
                item.SubItems.Add(x.Soc                     );
                item.SubItems.Add(x.Rol                     );
                item.SubItems.Add(x.Terr                    );
                item.SubItems.Add(x.IncExc                  );
                item.Tag = x;

                lvShareDetailsIpi.Items.Add(item);
                seqNr++;
            });
            lvShareDetailsIpi.EndUpdate();
        }

        private void btnCustomerFilterApply_Click(object sender, EventArgs e)
        {
            ClearContent(0);
            LoadCustomers();
            FillLvCustomers();
        }

        private void lvCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearContent(1);
            lvWorks.Items.Clear();
            if(lvCustomers.SelectedItems.Count == 0)
            {
                panelWorkDetailsTitle.Text = "Твори правовласника (не вибрано)";
                return;
            }


            var customer = lvCustomers.SelectedItems[0].Tag as Customer;
            panelWorkDetailsTitle.Text = $"Твори правовласника {customer.Name}";
            LoadWorks(customer.CustId);
            FillLvWorks();
        }

        private void lvWorks_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearContent(2);
            lvShares.Items.Clear();
            if(lvWorks.SelectedItems.Count == 0)
            {
                labWorkDetailsTitle.Text = "Подробиці твору (не вибрано)";
                return;
            }

            var work = lvWorks.SelectedItems[0].Tag as Work;
            
            labWorkDetailsTitle.Text = $"Подробиці твору {work.Name}";
            LoadShares(work.ObjId);
            FillLvShares();
            LoadAltNames(work.ObjId);
            FillLvAltNames();
            LoadPerformers(work.ObjId);
            FillLvPerformers();
        }

        private void lvCustomers_MouseDown(object sender, MouseEventArgs e)
        {
            Helpers.CopyCellValue(e, lvCustomers);
        }

        private void lvWorks_MouseDown(object sender, MouseEventArgs e)
        {
            Helpers.CopyCellValue(e, lvWorks);
        }
        
        private void lvShares_MouseDown(object sender, MouseEventArgs e)
        {
            Helpers.CopyCellValue(e, lvShares);
        }

        private void lvShares_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearContent(3);
            lvShareDetailsIpi.Items.Clear();
            if(lvShares.SelectedItems.Count == 0) return;

            var share = lvShares.SelectedItems[0].Tag as Share;
            LoadShareDetailsIpi(share.IpBaseNr);
            FillLvShareDetailsIpi();

            ucShareDetailsMs.UpdateContent(share.CustId);
        }

        private void btnWorksExpandCollapse_Click(object sender, EventArgs e)
        {
            splitPanelMain.Panel1Collapsed = !splitPanelMain.Panel1Collapsed;
            btnWorksExpandCollapse.ImageIndex = splitPanelMain.Panel1Collapsed ? 1 : 0;
        }

        private void btnWorkDetailsExpandCollapse_Click(object sender, EventArgs e)
        {
            splitPanelWorks.Panel1Collapsed = !splitPanelWorks.Panel1Collapsed;
            btnWorkDetailsExpandCollapse.ImageIndex = splitPanelWorks.Panel1Collapsed ? 1 : 0;
        }
    }
}
