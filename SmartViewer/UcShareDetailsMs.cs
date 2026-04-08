using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SmartViewer.UcShareDetailsMs;

namespace SmartViewer
{
    public partial class UcShareDetailsMs : UserControl
    {
        public class TermsOfService
        {
            public string ServiceDescription { get; set; }
            public string ControllingSoc     { get; set; }
        }

        public class ShareDetail
        {
            public string AgrStatus                      { get; set; }
            public DateTime? AgrStartDate                 { get; set; }
            public DateTime? AgrEndDate                    { get; set; }
            public string AffiliatedSoc                      { get; set; }
        }

        private ShareDetail _shareDetail;
        private List<TermsOfService> _termsOfService;
        private int _custId;

        public UcShareDetailsMs()
        {
            InitializeComponent();
        }

        private void UcShareDetailsMs_Load(object sender, EventArgs e)
        {
            Configure();
        }

        public void ClearContent()
        {
            labAgrStatus.Text      = "";
            labAgrStartDate.Text   = "";
            labAgrEndDate.Text     = "";
            labAffiliatedSoc.Text  = "";
            lvTermsOfService.Items.Clear();
        }

        public void UpdateContent(int custId)
        {
            _custId = custId;
            LoadShareDetail();
            FillShareDetail();
            LoadTermsOfService();
            FillTermsOfService();
        }

        private void Configure()
        {
            lvTermsOfService.FullRowSelect = true;
            lvTermsOfService.GridLines = true;
            lvTermsOfService.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvTermsOfService.MultiSelect = false;
            lvTermsOfService.View = View.Details;

            lvTermsOfService.Columns.Clear();
            lvTermsOfService.Columns.Add("№", 60);
            lvTermsOfService.Columns.Add("Назва сервісу", 400);
            lvTermsOfService.Columns.Add("ОКУ яке обслуговує", 140);

        }

        private void LoadShareDetail()
        {
            _shareDetail = new ShareDetail();
            Helpers.RunSqlMediaService(cmd =>
            {
                cmd.CommandText = @"
                    select
                          concat('(', t2.CodeI, ') ', t2.Name) as Status
                        , t1.DateBegin
                        , t1.DateEnd
	                    , case when t4.CustId is null then '' else concat('(', t4.CustId, ') ', t4.ShortName) end as AffiliatedSoc
                    from AgreementAddRh t1
                        join AgreementStatus t2 on t1.agrStatus = t2.codeI
	                    left join RelSubPublish t3 on t1.CustId = t3.custIdPub
	                    left join vCustomerNamesShort t4 on t3.CustIdSub = t4.CustId
                    where t1.CustId = @custId
                ";
                cmd.Parameters.AddWithValue("@custId", _custId);
                
                using (var r = cmd.ExecuteReader())
                {
                    if(!r.HasRows)
                    {
                        _shareDetail.AgrStatus = "Немає договору";
                    }
                    else {
                        r.Read();
                        var idx = 0;
                        _shareDetail.AgrStatus    = r.GetString(idx); idx++;
                        _shareDetail.AgrStartDate = r.IsDBNull(idx) ? (DateTime?)null : r.GetDateTime(idx); idx++;
                        _shareDetail.AgrEndDate   = r.IsDBNull(idx) ? (DateTime?)null : r.GetDateTime(idx); idx++;
                        _shareDetail.AffiliatedSoc    = r.GetString(idx); idx++;
                    }
                }
            });
        }

        private void FillShareDetail()
        {
            labAgrStatus.Text    = _shareDetail.AgrStatus;
            labAgrStartDate.Text = _shareDetail.AgrStartDate == null ? "" : ((DateTime)_shareDetail.AgrStartDate).ToString("yyyy-MM-dd");
            labAgrEndDate.Text   = _shareDetail.AgrEndDate == null ? "" : ((DateTime)_shareDetail.AgrEndDate).ToString("yyyy-MM-dd");
            labAffiliatedSoc.Text    = _shareDetail.AffiliatedSoc;
        }

        private void LoadTermsOfService()
        {
            _shareDetail = new ShareDetail();
            Helpers.RunSqlMediaService(cmd =>
            {
                cmd.CommandText = @"
                     select
	                      t2.codeI as CodeI
	                    , concat('(', t2.codeI, ') ', t2.Name) as Service
	                    , '(140) NGO-UACRR'					   as Soc
                    from TermsOfService t1
	                    join CopyrightKind t2 on t1.CRKindCode = t2.CodeI
                    where t1.CustId = @custId
	                    and t1.ourService = 1
                    union
                    select
	                      t4.codeI as CodeI
	                    , concat('(', t4.codeI, ') ', t4.Name)	     as Service
	                    , concat('(', t2.interCode, ') ', t6.ShortName) as Soc
                    from CustCmRight t1
	                    left join Community t2 on t1.cmCustId = t2.CustId
	                    left join TermsOfService t3 on t1.custId = t3.CustId
		                    and t1.cRKindCode = t3.cRKindCode
	                    left join CopyrightKind t4 on t3.CRKindCode = t4.CodeI
	                    join vCustomerNamesShort t6 on t2.CustId = t6.CustId
                    where t1.CustId = @custId
	                    and t2.interCode <> 99
                    order by CodeI
                ";
                cmd.Parameters.AddWithValue("@custId", _custId);
                
                using (var r = cmd.ExecuteReader())
                {
                    _termsOfService = new List<TermsOfService>();
                    while(r.Read())
                    {
                        var termsOfService = new TermsOfService();
                        var idx = 1;
                        termsOfService.ServiceDescription = r.GetString(idx); idx++;
                        termsOfService.ControllingSoc     = r.GetString(idx); idx++;

                        _termsOfService.Add(termsOfService);
                    }
                }
            });
        }

        private void FillTermsOfService()
        {
            lvTermsOfService.BeginUpdate();
            lvTermsOfService.Items.Clear();
            
            var seqNr = 1;
            _termsOfService.ForEach(x =>
            {
                var item = new ListViewItem(seqNr.ToString());
                item.SubItems.Add(x.ServiceDescription);
                item.SubItems.Add(x.ControllingSoc);
                item.Tag = x;

                lvTermsOfService.Items.Add(item);
                seqNr++;
            });
            lvTermsOfService.EndUpdate();
        }
    }
}
