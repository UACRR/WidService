using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CcidViewer.UcListViewBase;

namespace CcidViewer
{
    public partial class tbRevenue : Form
    {
        private int _ddexReportId;
        private DateTime _periodStart;
        private DateTime _periodEnd;

        public tbRevenue()
        {
            InitializeComponent();
            _ddexReportId = 457;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

            ucLvRightHolders.ItemSelected += UcLvRightHolders_ItemSelected;
            ucLvWorks.ItemSelected += UcLvWorks_ItemSelected;
            ucLvWorkRightHolders.ItemSelected += UcLvWorkRightHolders_ItemSelected;
            
            tbDdexReportId.Text = _ddexReportId.ToString();
        }

        private void LoadRightHoders()
        {
            ucLvRightHolders.SetSqlQuery(@"
                with ObjIds as (
	                select distinct t2.ObjId
	                from DDEX..IdentBacklog t1
		                join DDEX..IdentMw t2 on t1.MwId = t2.Id
	                where t1.DdexReportId = @ddexReportId
		                and isnull(t2.ObjId, 0) <> 0
                ),
                CustIds as (
	                select distinct t3.CustId
	                from ObjIds t1
		                join MediaService..MediaTrack t2 on t1.ObjId = t2.ObjId
		                join MediaService..CopyRight t3 on t2.ObjId = t3.ObjId
			                and getdate() between t3.beginDate and t3.endDate
                )
                select
	                    row_number() over(order by t3.shortName) as [№]
                    , t3.custId as [Код]
                    , t3.shortName as [Назва]
                from CustIds t1
	                join MediaService..AgreementAddRh t2 on t1.CustId = t2.CustId
	                join MediaService..vCustomerNamesShort t3 on t2.CustId = t3.CustId
                where t2.agrStatus = 2
                order by t3.shortName
            ");
            ucLvRightHolders.SetSqlCommandParams("@ddexReportId", _ddexReportId);
            ucLvRightHolders.UpdateContent();
        }

        private void LoadWorks(int custId)
        {
            ucLvWorks.SetSqlQuery(@"
                with ReportWorks as (
	                select distinct t2.ObjId
	                from Ddex..IdentBacklog t1
		                join Ddex..IdentMw t2 on t1.MwId = t2.Id
	                where t1.DdexReportId = @ddexReportId
		                and isnull(t2.ObjId, 0) <> 0
                ),
                RightHolderWorks as (
	                select distinct t1.ObjId
	                from MediaService..CopyRight t1
	                where getdate() between t1.beginDate and t1.EndDate
		                and t1.CustId = @custId
                )
                select 
	                  row_number() over(order by iif(t3.ObjId is null, 0, 1) desc, t2.Name) as [№]
	                , t2.ObjId as [Код твору]
                    , t2.Name as [Назва твору]
	                , case when t3.ObjId is null then 'Ні' else 'Так' end as [Знайдено у звіті]
                from RightHolderWorks t1
	                join MediaService..MediaTrack t2 on t1.ObjId = t2.ObjId
	                left join ReportWorks t3 on t1.ObjId = t3.ObjId
                order by iif(t3.ObjId is null, 0, 1) desc, t2.Name
            ");
            ucLvWorks.SetSqlCommandParams("@ddexReportId", _ddexReportId
                , "@custId", custId);
            ucLvWorks.UpdateContent();
        }

        private void LoadWorkRightHolders(int objId)
        {
            ucLvWorkRightHolders.SetSqlQuery(@"
                with Res as (
	                select distinct -- Запобігаємо дублюванню у випадку, коли правовласник присутній з різними ролями
		                  t1.cRightId                                                             as [Код права]
		                , format(isnull(t1.BeginDate, datefromparts(1900, 1, 1)), 'yyyy-MM-dd') as [Початок]
		                , format(isnull(t1.EndDate, datefromparts(3000, 12, 31)), 'yyyy-MM-dd')	as [Кінець]
		                , t1.CustId															    as [Код пвл]
		                , t2.ShortName														    as [Назва пвл]
		                , t4.Name																as [Роль у творі]
		                , t1.Rate															    as [Пуб% у творі]
		                , t1.RateMech														    as [Мех% у творі]
		                , cast(isnull(t3.PerSocShr, 0) * t1.Rate /100 as decimal(5, 2))		    as [Пуб% у CCID]
		                , cast(isnull(t3.MecSocShr, 0) * t1.RateMech / 100 as decimal(5, 2))    as [Мех% у CCID]
	                from MediaService..CopyRight t1
		                left join MediaService..vCustomerNamesShort t2 on t1.CustId = t2.CustId
		                left join Ddex..DdexReportAuthors t3 on
				                t3.DdexReportId = @ddexReportId 
			                and t1.CustId = t3.CustId
			                and t1.ObjId = t3.ObjId
		                join MediaService..CreativeRoleType t4 on t1.RoleCode = t4.CodeI
	                where t1.ObjId = @objId
		                and t1.beginDate <= @periodEnd and t1.endDate >= @periodStart
                )
                select row_number() over(order by [Назва пвл]) as [№], *
                from Res
                order by [Назва пвл]      
            ");
            ucLvWorkRightHolders.SetSqlCommandParams("@ddexReportId", _ddexReportId
                , "@objId", objId
                , "@periodStart", _periodStart
                , "@periodEnd", _periodEnd);
            ucLvWorkRightHolders.UpdateContent();
        }

        private void LoadShareDetails(int cRightId)
        {
            ucLvShareDetails.SetSqlQuery(@"
                 with SumPer as (
	                select sum(t1.rate) as Share
	                from MediaService..CopyRight t1
	                where t1.cRightId = @cRightId
		                and t1.BeginDate <= @periodEnd
		                and t1.EndDate >= @periodStart
                ),
                SumMec as (
	                select sum(t1.rateMech) as Share
	                from MediaService..CopyRight t1
	                where t1.cRightId = @cRightId
		                and t1.BeginDate <= @periodEnd
		                and t1.EndDate >= @periodStart
                )
                select
	                  1													as [#]
	                , 'Сума Пуб всіх  правовласників не більше 100%'	as [Умова]
	                , case when Share > 100 then '' else 'x' end		as [Виконана]
	                , case when Share > 100 then 'x' else '' end		as [Не виконана]
                from SumPer
                union
                select
	                  2													as [#]
	                 ,'Сума Мех всіх  правовласників не більше 100%'	as [Умова]
	                , case when Share > 100 then '' else 'x' end		as [Виконана]
	                , case when Share > 100 then 'x' else '' end		as [Не виконана]
                from SumMec
                union
                select
	                  3													as [#]
	                , 'Активний договір правовласника з УААСП'		    as [Умова]
	                , case when t2.agrId is null then '' else 'x' end	as [Виконана]
	                , case when t2.agrId is null then 'x' else '' end	as [Не виконана]
                from MediaService..CopyRight t1
	                left join MediaService..AgreementAddRH t2 on t1.CustId = t2.CustId
		                and t2.agrStatus = 2
		                and t2.DateBegin <= @periodEnd
		                and t2.DateEnd >= @periodStart
                where t1.cRightId = @cRightId
                union
                select
	                  4													as [#]
	                , 'Право на ПУБ в Інтернет з УААСП'					as [Умова]
	                , case when t2.custId is null then '' else 'x' end  as [Виконана]
	                , case when t2.custId is null then 'x' else '' end  as [Не виконана]
                from MediaService..CopyRight t1
	                left join MediaService..TermsOfService t2 on t1.CustId = t2.CustId
		                and t2.ourservice = 1
		                and t2.CRKindCode = 5
                where t1.cRightId = @cRightId
                union
                select
	                  5													as [#]
	                , 'Право на МЕХ в Інтернет з УААСП'					as [Умова]
	                , case when t2.custId is null then '' else 'x' end  as [Виконана]
	                , case when t2.custId is null then 'x' else '' end  as [Не виконана]
                from MediaService..CopyRight t1
	                left join MediaService..TermsOfService t2 on t1.CustId = t2.CustId
		                and t2.ourservice = 1
		                and t2.CRKindCode = 7
                where t1.cRightId = @cRightId
                union
                select
	                  6																											as [#]
	                , 'Право на ПУБ в Інтернет з партнером УААСП'																as [Умова]
	                , case 
			                when (select Ddex.dbo.fnInternetRightPartnerSoc(@cRightId, @periodStart, @periodEnd, 'P')) = ''
			                then ''
			                else (select Ddex.dbo.fnInternetRightPartnerSoc(@cRightId, @periodStart, @periodEnd, 'P'))
	                  end																										as [Виконана]
	                , case 
			                when (select Ddex.dbo.fnInternetRightPartnerSoc(@cRightId, @periodStart, @periodEnd, 'P)')) = ''
			                then 'x'
			                else ''
	                  end																										as [Не виконана]
                union
                select
	                  7																											as [#]
	                , 'Право на МЕХ в Інтернет з партнером УААСП'																as [Умова]
	                , case 
			                when (select Ddex.dbo.fnInternetRightPartnerSoc(@cRightId, @periodStart, @periodEnd, 'M')) = ''
			                then ''
			                else (select Ddex.dbo.fnInternetRightPartnerSoc(@cRightId, @periodStart, @periodEnd, 'M'))
	                  end																										as [Виконана]
	                , case 
			                when (select Ddex.dbo.fnInternetRightPartnerSoc(@cRightId, @periodStart, @periodEnd, 'M)')) = ''
			                then 'x'
			                else ''
	                  end																										as [Не виконана]

                order by [#]
            ");
            ucLvShareDetails.SetSqlCommandParams("@cRightId", cRightId
                , "@periodStart", _periodStart
                , "@periodEnd", _periodEnd);
            ucLvShareDetails.UpdateContent();
        }

        private void LoadReportLines(int objId)
        {
            ucLvReportLines.SetSqlQuery(@"
                select
	                  t1.DspResourceId							as [Код ресурсу]
	                , t1.SalesTransactionId						as [Код продажу]
                    , t1.ContentCategory						as [Категорія]
	                , NetRevenue								as [Отриманий прибуток]
	                , isnull(t4.amount_invoiced_total, 0)		as [Заявлена сума]
                from Ddex..IdentBacklog t1
	                join Ddex..IdentMw t2 on t1.MwId = t2.Id
	                join MediaService..MediaTrack t3 on t2.ObjId = t3.ObjId
	                left join Ddex..CcidInDetail t4 on t1.SalesTransactionId = t4.sales_transaction_id
                where t1.DdexReportId = @ddexReportId
	                and t2.ObjId = @objId
                order by t1.DspResourceId, t1.SalesTransactionId
            ");
            ucLvReportLines.SetSqlCommandParams("@ddexReportId", _ddexReportId
                , "@objId", objId);
            ucLvReportLines.UpdateContent();

            var sumRevenue = ucLvReportLines.GetSumInColDecimal(3);
            var sumInvoiced = ucLvReportLines.GetSumInColDecimal(4);

            tbSumRevenue.Text = sumRevenue.ToString();
            tbSumInvoiced.Text = sumInvoiced.ToString();
        }

        private void UcLvRightHolders_ItemSelected(object sender, EventArgs e)
        {
            ucLvWorks.ClearContent();
            ucLvWorkRightHolders.ClearContent();
            ucLvShareDetails.ClearContent();
            ucLvReportLines.ClearContent();

            if(e == null)
            {
                return;
            }

            Helpers.RunProtected ( () =>
            {
                var args = (ItemSelectedEventArgs)e;
                var custId = int.Parse(args.ListViewItem.SubItems[1].Text);
                LoadWorks(custId);
            });
        }

        private void UcLvWorks_ItemSelected(object sender, EventArgs e)
        {
            ucLvWorkRightHolders.ClearContent();
            ucLvShareDetails.ClearContent();
            ucLvReportLines.ClearContent();

            if(e == null)
            {
                return;
            }

            Helpers.RunProtected ( () =>
            {
                var args = (ItemSelectedEventArgs)e;
                var objId = int.Parse(args.ListViewItem.SubItems[1].Text);
                LoadWorkRightHolders(objId);
                LoadReportLines(objId);
            });
        }
        
        private void UcLvWorkRightHolders_ItemSelected(object sender, EventArgs e)
        {
            ucLvShareDetails.ClearContent();

            if(e == null)
            {
                return;
            }


            Helpers.RunProtected ( () =>
            {
                var args = (ItemSelectedEventArgs)e;
                var cRightId = int.Parse(args.ListViewItem.SubItems[1].Text);
                LoadShareDetails(cRightId);
            });
        }
        

        private void btnApplyReport_Click(object sender, EventArgs e)
        {
            Helpers.RunProtected ( () =>
            {
                _ddexReportId = int.Parse(tbDdexReportId.Text);
                Helpers.RunSqlMediaService(cmd =>
                {
                    cmd.Parameters.AddWithValue("@ddexReportId", _ddexReportId);
                    cmd.CommandText = "select Ddex.dbo.fnDdexReportStart(@ddexReportId)";
                    _periodStart = (DateTime)cmd.ExecuteScalar();
                    tbPeriodStart.Text = _periodStart.ToString("yyyy-MM-dd");
                    cmd.CommandText = "select Ddex.dbo.fnDdexReportEnd(@ddexReportId)";
                    _periodEnd = (DateTime)cmd.ExecuteScalar();
                    tbPeriodEnd.Text = _periodEnd.ToString("yyyy-MM-dd");
                });
                LoadRightHoders();
            });
        }

        private void tabPanelWorkDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = ucLvWorks.GetSelectedItem();
            if(item == null)
            {
                return;
            }

            var objId = int.Parse(item.SubItems[1].Text);
            switch(tabPanelWorkDetails.SelectedIndex)
            {
                case 0: LoadShareDetails(objId); break;
                case 1: LoadReportLines(objId); break;
            }
        }
    }
}
