using InvoicingLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static DdexInvoicing.UcTraceRoyaltyCalc;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using static Telerik.WinControls.UI.ValueMapper;

namespace DdexInvoicing
{
    public partial class UcTraceRoyaltyCalc : UserControl
    {
        public class ReportWork
        {
            public int ObjId { get; set; }
            public string Name { get; set; }
            public string Authors { get; set; }
            public string Performers { get; set; }
        }

        public class RightHolderInfo
        {
            // Загалом
            public int          CustId { get; set; }
            public bool         HasAgreement { get; set; }
            public string       Name { get; set; }
            public bool         IsWorldWide { get; set; }
            public string       IpBaseNr { get; set; }
            public int          TypeCode { get; set; }
            public string       TypeName { get; set; }
            public DateTime     AgrStart { get; set; }
            public DateTime     AgrEnd { get; set; }
            public int          AgrStatusCode { get; set; }
            public string       AgrStatusName { get; set; }
            public int          InternetServicePer { get; set; }
            public int          InternetServiceMec { get; set; }
            public int          CommunityCustId { get; set; }
            public string       CommunityName { get; set; }

            public ForeignRightHolderInfo ForeignRhPer { get; set; }
            public ForeignRightHolderInfo ForeignRhMec { get; set; }

            // Стосовно твору
            public int CopyRightId           { get; set; }
            public int WorkCreativeRoleCode  { get; set; }
			public string WorkCreativeRoleName  { get; set; }
			public int WorkRightsStatusCode  { get; set; }
			public string WorkRightsStatusName  { get; set; }
			public DateTime WorkRightsStartDate   { get; set; }
			public DateTime WorkRightsEndDate     { get; set; }
			public decimal RightHolderPerShr			 { get; set; }
			public decimal RightHolderMecShr			 { get; set; }
            public decimal RightHolderPerShrClaimed	 { get; set; }
			public decimal RightHolderMecShrClaimed    { get; set; }

            public bool CheckAgreementStatus        { get; set; }
            public bool CheckAgreementPeriodStart        { get; set; }
            public bool CheckAgreementPeriodEnd        { get; set; }
            public bool CheckAgreementPerRights     { get; set; }
            public bool CheckAgreementMecRights     { get; set; }

            public bool CheckAgreementInGeneral        { get; set; }
            
            public bool CheckWorkRightStatus        { get; set; }
            public bool CheckWorkRightPeriodStart        { get; set; }
            public bool CheckWorkRightPeriodEnd        { get; set; }
            public bool CheckWorkRightPeriod        { get; set; }

            

            public bool CheckWorkRightFinal         { get; set; }

            public bool HasErrors                   { get; set; }
            public bool HasWarnings                 { get; set; }
            public bool IsIncluded                  { get; set; }
        }

        public class ForeignRightHolderInfo
        {
            public int          CommunityCustId        { get; set; }
            public int          CommunityInterCode     { get; set; }
            public string       CommunityName          { get; set; }
            public bool         CommunityHasAgr        { get; set; }
            public int          CommunityAgrStatusCode { get; set; }
            public string       CommunityAgrStatusName { get; set; }
            public bool         CommunityAgrHasRight   { get; set; }
            public DateTime     CommunityAgrRightStart { get; set; }
            public DateTime     CommunityAgrRightEnd   { get; set; }
            public DateTime     RhAgrStart             { get; set; }
            public DateTime     RhAgrEnd               { get; set; }

            public bool CheckCommunityHasAggr       { get; set; }
            public bool CheckCommunityAgrStatus     { get; set; }
            public bool CheckCommunityAgrHasRight     { get; set; }
            public bool CheckCommunityAgrStart      { get; set; }
            public bool CheckCommunityAgrEnd        { get; set; }
            public bool CheckRhAgrStart             { get; set; }
            public bool CheckRhAgrEnd               { get; set; }

            public bool CheckCommunityHasRight      { get; set; }
            public bool CheckIncluded               { get; set; }

            
        }

        public class WorkInfo
        {
            public int       ReportId	        { get; set; }
			public int       ReportLicId	    { get; set; }
			public string    ReportName		    { get; set; }
			public int       ReportYear		    { get; set; }
			public int       ReportQuarter	    { get; set; }
            public int       ReportMonth	    { get; set; }
			public DateTime  ReportStartDate	{ get; set; }
			public DateTime  ReportEndDate	    { get; set; }

            public string    WorkName			{ get; set; }
			public int       WorkCategoryCode	{ get; set; }
			public string    WorkCategoryName	{ get; set; }
			public int       WorkStatusCode	    { get; set; }
			public string    WorkStatusName	    { get; set; }
			public string    WorkAuthors		{ get; set; }
			public string    WorkPerformers	    { get; set; }
			public string    WorkSourceName	    { get; set; }

            public decimal WorkPerShr			 { get; set; }
			public decimal WorkMecShr			 { get; set; }
            public decimal WorkPerShrClaimed	 { get; set; }
			public decimal WorkMecShrClaimed     { get; set; }

            public bool HasErrors                { get; set; }
            public bool HasWarnings              { get; set; }

            public List<RightHolderInfo> RightHolders { get; set; }
        }

        private enum TitleItemEnum
        {
            OwnAgr,
            ForeignAgrPer,
            ForeignAgrMec,
            WorkAgr,
        }

        private int _ddexReportId;
        private WorkInfo _workInfo;

        private bool _titleOwnAgrExpanded;
        private bool _titleForeignAgrExpandedPer;
        private bool _titleForeignAgrExpandedMec;
        private bool _titleWorkAgrExpanded;

        public UcTraceRoyaltyCalc()
        {
            InitializeComponent();
        }

        private void UcTraceRoyaltyCalc_Load(object sender, EventArgs e)
        {
            Configure();

            tbFilter.Text = "329286";
        }

        private void Configure()
        {
            lvReportWorks.View = View.Details;
            lvReportWorks.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvReportWorks.FullRowSelect = true;
            lvReportWorks.HideSelection = false;
            lvReportWorks.MultiSelect = false;
            lvReportWorks.GridLines = true;
            lvReportWorks.Columns.Clear();
            lvReportWorks.Columns.Add("#", 60);
            lvReportWorks.Columns.Add("Код", 60);
            lvReportWorks.Columns.Add("Назва", 200);
            lvReportWorks.Columns.Add("Автори", 200);
            lvReportWorks.Columns.Add("Виконавці", 200);

            tvCheckPlan.HideSelection = false;

            lvDetails.View = View.Details;
            lvDetails.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvDetails.FullRowSelect = true;
            lvDetails.HideSelection = false;
            lvDetails.MultiSelect = false;
            lvDetails.GridLines = true;
            lvDetails.SmallImageList = imageList1;
            lvDetails.StateImageList = imageList1;
            lvDetails.Columns.Clear();
            lvDetails.Columns.Add("Параметр", 400);
            lvDetails.Columns.Add("Значення", 200);

        }

        private void ShowError(Exception ex)
        {
            MessageBox.Show(ex.Message, "Розрахунок процентів", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void SetDdexReportId(int ddexReportId)
        {
            _ddexReportId = ddexReportId;
            _workInfo = new WorkInfo();
            Helpers.RunSqlOperationDdex(cmd =>
            {
                // ЗВІТ
                cmd.CommandText = @"
                    select 
	                      t1.Id													        as reportId			
	                    , t1.licId												        as licId			
	                    , Ddex.dbo.fnDdexReportNameFromLicId(t1.licId)			        as reportName		
	                    , t2.year												        as reportYear		
	                    , isnull(t2.quarter, 0)									        as reportQuarter
                        , isnull(t2.month, 0)									        as reportMonth   
	                    , Ddex.dbo.ft_DatePeriodStart(t2.Month, t2.Quarter, t2.Year)	as reportStartDate	
	                    , Ddex.dbo.ft_DatePeriodEnd(t2.Month, t2.Quarter, t2.Year)		as reportEndDate	
                    from Ddex..DdexReport t1
	                    join Ddex..DdexReportingPeriod t2 on t1.ddexReportingPeriodId = t2.Id
                    where t1.Id = @ddexReportId
                ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ddexReportId", _ddexReportId);
                using (var r = cmd.ExecuteReader())
                {
                    r.Read();
                    var idx = 0;
                    _workInfo.ReportId = r.GetInt32(idx++);
                    _workInfo.ReportLicId = r.GetInt32(idx++);
                    _workInfo.ReportName = r.GetString(idx++);
                    _workInfo.ReportYear = r.GetInt32(idx++);
                    _workInfo.ReportQuarter = r.GetInt32(idx++);
                    _workInfo.ReportMonth = r.GetInt32(idx++);
                    _workInfo.ReportStartDate = r.GetDateTime(idx++);
                    _workInfo.ReportEndDate = r.GetDateTime(idx++);
                }
            });
        }

        private void LoadWorkInfo(int objId)
        {
            Helpers.RunSqlOperationDdex(cmd =>
            {
              // ТВІР
                cmd.CommandText = @"
                    select 
                          t1.Name								as Name			
                        , t1.CategoryCode						as CategoryCode	
                        , t2.Name								as CategoryName	
                        , isnull(t1.Status, -1)					as StatusCode	
                        , isnull(t3.Name, '<Не визначений>')	as StatusName	
                        , isnull(t1.Author, '')					as Authors		
                        , isnull(t1.Performer, '')				as Performers	
                        , isnull(t1.SourceName, '')				as SourceName
                    from MediaService..ObjectRight t1
                        join MediaService..Category t2 on t1.categoryCode = t2.codeI
                        left join MediaService..ObjectStatus t3 on t1.status = t3.codeI
                    where ObjId = @ObjId                
                ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ObjId", objId);
                using (var r = cmd.ExecuteReader())
                {
                    r.Read();
                    var idx = 0;
                    _workInfo.WorkName		    = r.GetString(idx++);
			        _workInfo.WorkCategoryCode  = r.GetInt32 (idx++);
			        _workInfo.WorkCategoryName	= r.GetString(idx++);
			        _workInfo.WorkStatusCode	= r.GetInt32 (idx++);
			        _workInfo.WorkStatusName	= r.GetString(idx++);
			        _workInfo.WorkAuthors		= r.GetString(idx++);
			        _workInfo.WorkPerformers	= r.GetString(idx++);
                    _workInfo.WorkSourceName	= r.GetString(idx++);
                }

                LoadCopyRights(cmd, objId);
            });
            
            CalcShares();
            CalcErrors();

        }

        private void LoadCopyRights(SqlCommand cmd, int objId)
        {
            cmd.CommandText = @"
                select t1.cRightId, t1.CustId, t2.SHortName
                from MediaService..CopyRight t1
                    join MediaService..vCustomerNamesShort t2 on t1.CustId = t2.CustId
                where t1.ObjId = @ObjId
                order by t2.ShortName
            ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ObjId", objId);
            _workInfo.RightHolders = new List<RightHolderInfo>();
            using(var r = cmd.ExecuteReader())
            {
                while(r.Read())
                {
                    _workInfo.RightHolders.Add(new RightHolderInfo
                    {
                        CopyRightId = r.GetInt32(0),
                        CustId = r.GetInt32(1),
                        Name = r.GetString(2),
                    });
                }
            }

            _workInfo.RightHolders.ForEach(x =>
            {
                LoadRightHolderInfo(cmd, x);
                LoadRightHolderWorkInfo(cmd, x);
                CheckRightHolder(x);
            });
        }
        
        private void LoadRightHolderInfo(SqlCommand cmd, RightHolderInfo rightHolderInfo)
        {
            cmd.CommandText = @"
                select 
                      t4.shortName										as RhName	
		            , isnull(t2.aroundWord, 0)							as RhAroundWorld		
		            , isnull(t2.interCode, '')							as RhInterCode			
		            , t2.rHolderType									as RhTypeCode			
		            , t3.Name											as RhTypeName			
		            , isnull(t5.dateBegin, datefromparts(1900, 1, 1))	as RhAgrStart			
		            , isnull(t5.dateEnd, datefromparts(9999, 12, 31))   as RhAgrEnd				
		            , t5.agrStatus										as RhAgrStatus			
		            , t6.Name											as RhAgrStatusName		
		            --, isnull(t7.custId, 0)							as RhCommunityCustId	
		            , case when t8.custId is null then 0 else 1 end		as RhInternetServicePer
		            , case when t9.custId is null then 0 else 1 end		as RhInternetServiceMec
	            from MediaService..RightHolder t2
		            join MediaService..RHolderType t3 on t2.RHolderType = t3.codeI
		            join MediaService..vCustomerNamesShort t4 on t2.CustId = t4.CustId
		            join MediaService..AgreementAddRH t5 on t2.CustId = t5.CustId
		            join MediaService..AgreementStatus t6 on t5.agrStatus = t6.codeI
		            --left join MediaService..CustCmRight t7 on t2.custId = t7.custId
		            left join MediaService..TermsOfService t8 on t2.custId = t8.custId and t8.CRKindCode = 5 and t8.ourService = 1
		            left join MediaService..TermsOfService t9 on t2.custId = t9.custId and t9.CRKindCode = 7 and t9.ourService = 1	                
                where t2.CustId = @custId
            ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@custId", rightHolderInfo.CustId);

            var loadForeignRh = false;
            using (var r = cmd.ExecuteReader())
            {
                if (!r.HasRows)
                {
                    rightHolderInfo.HasAgreement = false;
                    loadForeignRh = true;
                }
                else
                {
                    rightHolderInfo.HasAgreement = true;

                    r.Read();

                    var idx = 0;
                    rightHolderInfo.Name = r.GetString(idx++);
                    rightHolderInfo.IsWorldWide = r.GetBoolean(idx++);
                    rightHolderInfo.IpBaseNr = r.GetString(idx++);
                    rightHolderInfo.TypeCode = r.GetInt32(idx++);
                    rightHolderInfo.TypeName = r.GetString(idx++);
                    rightHolderInfo.AgrStart = r.GetDateTime(idx++);
                    rightHolderInfo.AgrEnd = r.GetDateTime(idx++);
                    rightHolderInfo.AgrStatusCode = r.GetInt32(idx++);
                    rightHolderInfo.AgrStatusName = r.GetString(idx++);
                    rightHolderInfo.InternetServicePer = r.GetInt32(idx++);
                    rightHolderInfo.InternetServiceMec = r.GetInt32(idx++);

                }
                rightHolderInfo.CommunityCustId = 2; // НАше товариство
                rightHolderInfo.CommunityName = "ГО УААСП";
            }

            if(loadForeignRh)
            {
                LoadForeignRightHolderInfo(cmd, rightHolderInfo, true);
                LoadForeignRightHolderInfo(cmd, rightHolderInfo, false);
            }
        }

        private void LoadForeignRightHolderInfo(SqlCommand cmd, RightHolderInfo rightHolderInfo, bool isPer)
        {
            cmd.CommandText = @"
                select
                    t2.cmCustId													as CommunityCustId  
                  , cast(t2.interCode as int)									as CommunityInterCode
                  , t2.cmName													as CommunityName         
                  , case 
		                when t3.custId is null 
		                then cast(0 as bit)
		                else cast(1 as bit)
	                end															as CommunityHasAgr
                  , t2.agrStatus												as CommunityAgrStatusCode
                  , t4.Name														as CommunityAgrStatusName
                  , isnull(t3.IsPer			, 0	)								as CommunityAgrHasPer     
                  , isnull(t3.dateBeginPer	, datefromparts(1900, 1, 1))		as CommunityAgrStartPer     
                  , isnull(t3.dateEndPer	, datefromparts(1900, 1, 1)	)		as CommunityAgrEndPer
                  , isnull(t3.IsMec			, 0	)								as CommunityAgrHasMec
                  , isnull(t3.dateBeginMec	, datefromparts(1900, 1, 1)	)		as CommunityAgrStartMec
                  , isnull(t3.dateEndMec	, datefromparts(1900, 1, 1)	)		as CommunityAgrEndMec
                  , t1.dateBegin												as CustomerAgrStart              
                  , t1.dateEnd													as CustomerAgrEnd               
                from MediaService..CustCmRight					  t1
	                join MediaService..vCommunity				  t2 on t1.cmCustId = t2.cmCustId
	                left join MediaService..AgreementAddCommunity t3 on t2.cmCustId = t3.custId
	                join MediaService..AgreementStatus			  t4 on t2.agrStatus = t4.codeI                
                                where t1.cRKindCode = @cRKindCode
                                    and t1.custId = @custId
            ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@cRKindCode", isPer ? 5 : 7);
            cmd.Parameters.AddWithValue("@custId", rightHolderInfo.CustId);
            using (var r = cmd.ExecuteReader())
            {
                if (!r.HasRows)
                {
                    if (isPer)
                    {
                        rightHolderInfo.ForeignRhPer = null;
                    }
                    else
                    {
                        rightHolderInfo.ForeignRhMec = null;
                    }
                }
                else
                {
                    var foreignRh = new ForeignRightHolderInfo();

                    r.Read();

                    var idx = 0;
                    foreignRh.CommunityCustId            = r.GetInt32(idx++);
                    foreignRh.CommunityInterCode         = r.GetInt32(idx++);
                    foreignRh.CommunityName              = r.GetString(idx++);
                    foreignRh.CommunityHasAgr            = r.GetBoolean(idx++);
                    foreignRh.CommunityAgrStatusCode     = r.GetInt32(idx++);
                    foreignRh.CommunityAgrStatusName     = r.GetString(idx++);
                    if(isPer)
                    {
                        foreignRh.CommunityAgrHasRight   = r.GetBoolean(idx++);
                        foreignRh.CommunityAgrRightStart = r.GetDateTime(idx++);
                        foreignRh.CommunityAgrRightEnd   = r.GetDateTime(idx++);
                        idx += 3;
                    }
                    else
                    {
                        idx += 3;
                        foreignRh.CommunityAgrHasRight   = r.GetBoolean(idx++);
                        foreignRh.CommunityAgrRightStart = r.GetDateTime(idx++);
                        foreignRh.CommunityAgrRightEnd   = r.GetDateTime(idx++);
                    }
                    foreignRh.RhAgrStart                 = r.GetDateTime(idx++);
                    foreignRh.RhAgrEnd                   = r.GetDateTime(idx++);

                    if (isPer)
                    {
                        rightHolderInfo.ForeignRhPer = foreignRh;
                    }
                    else
                    {
                        rightHolderInfo.ForeignRhMec = foreignRh;
                    }
                }
             }
        }

        private void LoadRightHolderWorkInfo(SqlCommand cmd, RightHolderInfo rightHolderInfo)
        {
            cmd.CommandText = @"
                select 
                      t1.roleCode										as RhWorkCreativeRoleCode
                    , t3.Name											as RhWorkCreativeRoleName
                    , t1.status											as RhWorkRightsStatusCode
                    , t2.name											as RhWorkRightsStatusName
                    , isnull(t1.beginDate, datefromparts(1900, 1, 1))	as RhWorkRightsStartDate 
                    , isnull(t1.endDate, datefromparts(9999, 12, 31))	as RhWorkRightsEndDate   
                    , t1.rate											as RhWorkPerShr			
                    , t1.rateMech										as RhWorkMecShr			
                from MediaService..CopyRight t1
                    join MediaService..CRightStatus t2 on t1.status = t2.codeI
                    join MediaService..CreativeRoleType t3 on t1.roleCode = t3.codeI
                where t1.cRightId = @copyRightId            
            ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@copyRightId", rightHolderInfo.CopyRightId);
            using (var r = cmd.ExecuteReader())
            {
                if (!r.HasRows)
                {
                    //rightHolderInfo.HasAgreement = false;
                }
                else
                {
                    //rightHolderInfo.HasAgreement = true;

                    r.Read();

                    var idx = 0;
                    rightHolderInfo.WorkCreativeRoleCode = r.GetInt32(idx++);
			        rightHolderInfo.WorkCreativeRoleName = r.GetString(idx++);
			        rightHolderInfo.WorkRightsStatusCode = r.GetInt32(idx++);
			        rightHolderInfo.WorkRightsStatusName = r.GetString(idx++);
			        rightHolderInfo.WorkRightsStartDate  = r.GetDateTime(idx++);
			        rightHolderInfo.WorkRightsEndDate    = r.GetDateTime(idx++);
			        rightHolderInfo.RightHolderPerShr	 = r.GetDecimal(idx++);
                    rightHolderInfo.RightHolderMecShr    = r.GetDecimal(idx++);

                }
             }
        }

        private void CheckForeignRightHolder(ForeignRightHolderInfo foreignRh)
        {
            if (foreignRh != null)
            {
                foreignRh.CheckCommunityHasAggr = foreignRh.CommunityHasAgr;
                foreignRh.CheckCommunityAgrStatus = foreignRh.CommunityAgrStatusCode == 2;
                foreignRh.CheckCommunityAgrHasRight = foreignRh.CommunityAgrHasRight;
                foreignRh.CheckCommunityAgrStart = foreignRh.CommunityAgrRightStart <= _workInfo.ReportEndDate;
                foreignRh.CheckCommunityAgrEnd = foreignRh.CommunityAgrRightEnd >= _workInfo.ReportStartDate;
                foreignRh.CheckRhAgrStart = foreignRh.RhAgrStart <= _workInfo.ReportEndDate;
                foreignRh.CheckRhAgrEnd = foreignRh.RhAgrEnd >= _workInfo.ReportStartDate;

                foreignRh.CheckCommunityHasRight =
                    foreignRh.CheckCommunityHasAggr &&
                    foreignRh.CheckCommunityAgrStatus &&
                    foreignRh.CheckCommunityAgrHasRight &&
                    foreignRh.CheckCommunityAgrStart &&
                    foreignRh.CheckCommunityAgrEnd
                 ;
                foreignRh.CheckIncluded =
                    foreignRh.CheckCommunityHasRight &&
                    foreignRh.CheckRhAgrStart &&
                    foreignRh.CheckRhAgrEnd
                 ;
            }
        }

        private void CheckRightHolder(RightHolderInfo rightHolderInfo)
        {
            rightHolderInfo.CheckAgreementStatus    = rightHolderInfo.AgrStatusCode == 2;
            rightHolderInfo.CheckAgreementPeriodStart    = 
                rightHolderInfo.AgrStart <= _workInfo.ReportEndDate;
            rightHolderInfo.CheckAgreementPeriodEnd    = 
                rightHolderInfo.AgrEnd >= _workInfo.ReportStartDate;
            
            rightHolderInfo.CheckAgreementInGeneral    = 
                rightHolderInfo.CheckAgreementStatus &&
                rightHolderInfo.CheckAgreementPeriodStart && 
                rightHolderInfo.CheckAgreementPeriodEnd;
            
            rightHolderInfo.CheckAgreementPerRights = rightHolderInfo.InternetServicePer == 1;
            rightHolderInfo.CheckAgreementMecRights = rightHolderInfo.InternetServiceMec == 1;
            
            rightHolderInfo.CheckWorkRightStatus    = true;
            rightHolderInfo.CheckWorkRightPeriodStart    = 
                rightHolderInfo.WorkRightsStartDate <= _workInfo.ReportEndDate;
            rightHolderInfo.CheckWorkRightPeriodEnd    = 
                rightHolderInfo.WorkRightsEndDate >= _workInfo.ReportStartDate;
            rightHolderInfo.CheckWorkRightPeriod    = 
                rightHolderInfo.CheckWorkRightPeriodStart && 
                rightHolderInfo.CheckWorkRightPeriodEnd;

            CheckForeignRightHolder(rightHolderInfo.ForeignRhPer);
            CheckForeignRightHolder(rightHolderInfo.ForeignRhMec);
        }

        private void CalcShares()
        {
            _workInfo.WorkPerShr        = 0;
            _workInfo.WorkMecShr        = 0;
            _workInfo.WorkPerShrClaimed = 0;
            _workInfo.WorkMecShrClaimed = 0;

            _workInfo.RightHolders.ForEach(x =>
            {
                x.RightHolderPerShrClaimed = 0;
                x.RightHolderMecShrClaimed = 0;

                if( x.HasAgreement &&
                    x.CheckAgreementStatus &&
                    x.CheckAgreementPeriodStart &&
                    x.CheckAgreementPeriodEnd &&
                    x.CheckWorkRightPeriod &&
                    x.CheckWorkRightStatus
                )
                {
                    x.RightHolderPerShrClaimed = x.CheckAgreementPerRights ? x.RightHolderPerShr : 0;
                    x.RightHolderMecShrClaimed = x.CheckAgreementMecRights ? x.RightHolderMecShr : 0;
                }
                else
                {
                    if(x.ForeignRhPer != null && x.ForeignRhPer.CheckIncluded)
                    {
                        x.RightHolderPerShrClaimed = x.RightHolderPerShr;
                    }

                    if(x.ForeignRhMec != null && x.ForeignRhMec.CheckIncluded)
                    {
                        x.RightHolderMecShrClaimed = x.RightHolderMecShr;
                    }
                }


                _workInfo.WorkPerShr        += x.RightHolderPerShr;
                _workInfo.WorkMecShr        += x.RightHolderMecShr;
                _workInfo.WorkPerShrClaimed += x.RightHolderPerShrClaimed;
                _workInfo.WorkMecShrClaimed += x.RightHolderMecShrClaimed;
            });
        }

        private void CalcErrors()
        {
            _workInfo.HasErrors = false;
            _workInfo.HasWarnings = false;

            var hasIncluded = false;

             _workInfo.RightHolders.ForEach( x =>
            {
                x.HasErrors = false;
                x.HasWarnings = false;
                if (x.HasAgreement)
                {
                    if (!x.CheckAgreementStatus ||
                        !x.CheckWorkRightStatus ||
                        !x.CheckAgreementPeriodStart ||
                        !x.CheckAgreementPeriodEnd ||
                        !x.CheckWorkRightPeriod
                    )
                    {
                        x.HasErrors = true;
                    }
                    else if (!x.CheckAgreementPerRights ||
                        !x.CheckAgreementMecRights
                    )
                    {
                        _workInfo.HasWarnings = true;
                        x.HasWarnings = true;
                    }

                    x.IsIncluded = !x.HasErrors &&
                        (x.CheckAgreementPerRights || x.CheckAgreementMecRights);

                    if (x.IsIncluded)
                    {
                        hasIncluded = true;
                    }
                }
                else
                {
                    if(
                        !(x.ForeignRhPer != null && x.ForeignRhPer.CheckIncluded) &&
                        !(x.ForeignRhMec != null && x.ForeignRhMec.CheckIncluded)
                    )
                    {
                        x.HasErrors = true;
                    }

                    else if(
                        !(x.ForeignRhPer != null && x.ForeignRhPer.CheckIncluded) ||
                        !(x.ForeignRhMec != null && x.ForeignRhMec.CheckIncluded)
                    )
                    {
                        x.HasWarnings = true;
                        x.IsIncluded = true;
                        hasIncluded = true;
                    }
                    else
                    {
                        x.IsIncluded = true;
                        hasIncluded = true;
                    }
                }
            });

            if (
                _workInfo.WorkPerShrClaimed > 100 ||
                _workInfo.WorkMecShrClaimed > 100 ||
                !hasIncluded
            )
            {
                _workInfo.HasErrors = true;
            }
            else if (
                _workInfo.WorkPerShrClaimed +
                _workInfo.WorkMecShrClaimed < 200
            )
            {
                _workInfo.HasWarnings = true;
            }

        }

        private void FillCheckPlan()
        {
            tvCheckPlan.Nodes.Clear();
            var nodeWork = tvCheckPlan.Nodes.Add("Твір загалом");
            if (_workInfo.HasErrors)
            {
                nodeWork.ImageIndex = 2;
                nodeWork.SelectedImageIndex = 2;
            }
            else if (_workInfo.HasWarnings)
            {
                nodeWork.ImageIndex = 1;
                nodeWork.SelectedImageIndex = 1;
            }
            else if (_workInfo.WorkPerShrClaimed + _workInfo.WorkMecShrClaimed == 0)
            {
                nodeWork.ImageIndex = 2;
                nodeWork.SelectedImageIndex = 2;
            }
            else
            {
                nodeWork.ImageIndex = 0;
                nodeWork.SelectedImageIndex = 0;
            }
            nodeWork.Tag = _workInfo;

            var nodeRightHolders = tvCheckPlan.Nodes.Add("Окремі правовласники");
            nodeRightHolders.ImageIndex = 10;
            nodeRightHolders.SelectedImageIndex = 10;
            nodeRightHolders.Tag = null;
            
            _workInfo.RightHolders.ForEach(x =>
            {
                var nodeRightHolder = nodeRightHolders.Nodes.Add(x.Name);
                if (!x.IsIncluded)
                {
                    nodeRightHolder.ImageIndex = 2;
                    nodeRightHolder.SelectedImageIndex = 2;
                }
                else if (x.HasWarnings)
                {
                    nodeRightHolder.ImageIndex = 1;
                    nodeRightHolder.SelectedImageIndex = 1;
                }
                nodeRightHolder.Tag = x;
            });

            nodeRightHolders.Expand();
        }

        private void FillReportWorks()
        {
            lvReportWorks.Items.Clear();
            if(string.IsNullOrEmpty(tbFilter.Text.Trim()))
            {
                return;
            }

            var ObjId = 0;
            int.TryParse(tbFilter.Text.Trim(), out ObjId);

            var nameParamValue = tbFilter.Text;

            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.CommandText = @"
                     select distinct top 1000
                          t2.ObjId
                        , t2.Name
                        , isnull(t2.Author, '')
                        , isnull(t2.Performer, '')
                    from IdentMwObjId t1
                        join MediaService..ObjectRight t2 on t1.ObjId = t2.objId
                    where t1.DdexReportId = @DdexReportId
	                    and (t2.ObjId = @ObjId or t2.Name like @Name)
                    order by t2.Name
                ";
                cmd.Parameters.AddWithValue("@DdexReportId", _ddexReportId);
                cmd.Parameters.AddWithValue("@ObjId", ObjId);
                cmd.Parameters.AddWithValue("@Name", nameParamValue);

                using (var r = cmd.ExecuteReader())
                {
                    var idx = 1;
                    while (r.Read())
                    {
                        var reportWork = new ReportWork
                        {
                            ObjId = r.GetInt32(0),
                            Name = r.GetString(1),
                            Authors = r.GetString(2),
                            Performers = r.GetString(3)
                        };

                        var item = lvReportWorks.Items.Add(idx.ToString());
                        item.SubItems.Add(reportWork.ObjId.ToString());
                        item.SubItems.Add(reportWork.Name);
                        item.SubItems.Add(reportWork.Authors);
                        item.SubItems.Add(reportWork.Performers);
                        item.Tag = reportWork;
                        idx++;
                    }
                }
                
            });
        }

        private void FillWorkInfo()
        {
            AddLvDetailsItem("Назва"                , _workInfo.WorkName			);
            AddLvDetailsItem("Категорія (код-назва)", $"{_workInfo.WorkCategoryCode} - {_workInfo.WorkCategoryName}");
			AddLvDetailsItem("Статус (код-назва)"   , $"{_workInfo.WorkStatusCode} - {_workInfo.WorkStatusName}"	);
			AddLvDetailsItem("Автори"               , _workInfo.WorkAuthors		);
			AddLvDetailsItem("Виконавці"            , _workInfo.WorkPerformers	);
            AddLvDetailsItem("Походження"           , _workInfo.WorkSourceName);
        }

        private void FillForeignRightHolderInfo(ForeignRightHolderInfo foreignRh, bool isPer)
        {
            AddLvDetailsItem("", "");

            var ttl = isPer ? "ПУБЛІЧНЕ" : "МЕХАНІЧНЕ";

            var item = AddLvDetailsItem($"{ttl} ВИКОРИСТАННЯ (ДОГОВІР З ІНШИМ ТОВАРИСТВОМ)",
                    "",
                    foreignRh != null && foreignRh.CheckIncluded ? 0 : 2);
            item.Tag = isPer ? TitleItemEnum.ForeignAgrPer : TitleItemEnum.ForeignAgrMec;
            item.StateImageIndex = isPer && _titleForeignAgrExpandedPer || !isPer && _titleForeignAgrExpandedMec ? 4 : 3;
            
            if(isPer && _titleForeignAgrExpandedPer || !isPer && _titleForeignAgrExpandedMec)
            {
                InsertForeignAgrDetails(item.Index + 1, foreignRh, isPer);
            }
        }

        private void FillRightHolderInfo(RightHolderInfo rightHolderInfo)
        {
            ListViewItem curItem = null;
            lvDetails.Items.Clear();
             AddLvDetailsItem("Початок звітного періоду", _workInfo.ReportStartDate.ToString("yyyy-MM-dd") );
             AddLvDetailsItem("Початок звітного періоду", _workInfo.ReportEndDate.ToString("yyyy-MM-dd") );

             AddLvDetailsItem("", "");

             AddLvDetailsItem("Код правовласника", rightHolderInfo.CustId );
             AddLvDetailsItem("Назва правовласника", rightHolderInfo.Name );

             AddLvDetailsItem("", "");

            curItem = AddLvDetailsItem("ДОГОВІР З УААСП",
                "",
                !rightHolderInfo.CheckAgreementInGeneral ? 2 :
                rightHolderInfo.CheckAgreementPerRights && !rightHolderInfo.CheckAgreementMecRights ? 1 :
                !rightHolderInfo.CheckAgreementPerRights && rightHolderInfo.CheckAgreementMecRights ? 1 :
                !rightHolderInfo.CheckAgreementPerRights && !rightHolderInfo.CheckAgreementMecRights ? 2 :
                0);
            curItem.Tag = TitleItemEnum.OwnAgr;
            curItem.StateImageIndex = _titleOwnAgrExpanded ? 4 : 3;
            if (_titleOwnAgrExpanded)
            {
                InsertOwnAgrDetails(curItem.Index + 1, rightHolderInfo);
             }

            if(!rightHolderInfo.HasAgreement)
            {
                FillForeignRightHolderInfo(rightHolderInfo.ForeignRhPer, true);
                FillForeignRightHolderInfo(rightHolderInfo.ForeignRhMec, false);
            }

            AddLvDetailsItem("", "");
            curItem = AddLvDetailsItem("ПРАВОВОЛОДІННЯ ТВОРОМ",
                "",
                rightHolderInfo.CheckWorkRightPeriod ? 0 : 2);
             curItem.Tag = TitleItemEnum.WorkAgr;
            curItem.StateImageIndex = _titleWorkAgrExpanded ? 4 : 3;

            // Стосовно твору
            if (_titleWorkAgrExpanded)
            {
                InsertWorkAgrDetails(curItem.Index + 1, rightHolderInfo);

            }
        }

        private void InsertOwnAgrDetails(int idx, RightHolderInfo rightHolderInfo)
        {
            InsertLvDetailsItem(idx++, "    Наявність договору",
                 rightHolderInfo.HasAgreement ? "Так" : "Ні",
                 rightHolderInfo.HasAgreement ? 0 : 2);
            if (rightHolderInfo.HasAgreement)
            {
                InsertLvDetailsItem(idx++, "    Поширення прав", rightHolderInfo.IsWorldWide ? "Світ" : "Україна");
                InsertLvDetailsItem(idx++, "    Міжнародний код правовласника", rightHolderInfo.IpBaseNr);
                InsertLvDetailsItem(idx++, "    Тип равовласника (код - назва)", $"{rightHolderInfo.TypeCode} - {rightHolderInfo.TypeName}");
                InsertLvDetailsItem(idx++, "    Початок договору", rightHolderInfo.AgrStart.ToString("yyyy-MM-dd"),
                    rightHolderInfo.CheckAgreementPeriodStart ? 0 : 2);
                InsertLvDetailsItem(idx++, "    Закінчення договору", rightHolderInfo.AgrEnd.ToString("yyyy-MM-dd"),
                    rightHolderInfo.CheckAgreementPeriodEnd ? 0 : 2);
                InsertLvDetailsItem(idx++, "    Статус договору (код - назва)", $"{rightHolderInfo.AgrStatusCode} - {rightHolderInfo.AgrStatusName}",
                    rightHolderInfo.CheckAgreementStatus ? 0 : 2);
                InsertLvDetailsItem(idx++, "    Наявність права на публічне відтворення в Інтернет",
                    rightHolderInfo.CheckAgreementPerRights ? "Так" : "Ні",
                    rightHolderInfo.CheckAgreementPerRights ? 0 : 2);
                InsertLvDetailsItem(idx++, "    Наявність права на механічне відтворення в Інтернет",
                    rightHolderInfo.CheckAgreementMecRights ? "Так" : "Ні",
                    rightHolderInfo.CheckAgreementMecRights ? 0 : 2);
            }
        }

        private void RemoveOwnAgrDetails(int idx, RightHolderInfo rightHolderInfo)
        {
            lvDetails.Items.RemoveAt(idx);
            if (rightHolderInfo.HasAgreement)
            {
                for (int i = 0; i < 8; i++)
                {
                    lvDetails.Items.RemoveAt(idx);
                }
            }
        }

        private void InsertForeignAgrDetails(int idx, ForeignRightHolderInfo foreignRh, bool isPer)
        {
            var ttl = isPer ? "публічне" : "механічне";

            InsertLvDetailsItem(idx++, "    Наявність договору",
                    foreignRh != null ? "Так": "Ні",
                    foreignRh != null ? 0 : 2);

            if (foreignRh != null)
            {
                InsertLvDetailsItem(idx++, "    Код товариства в СМАРТ", foreignRh.CommunityCustId);
                InsertLvDetailsItem(idx++, "    Міжнародний код товариства", foreignRh.CommunityInterCode.ToString());
                InsertLvDetailsItem(idx++, "    Назва товариства", foreignRh.CommunityName);
                InsertLvDetailsItem(idx++, "    Початок дії договора",
                    foreignRh.RhAgrStart.ToString("yyyy-MM-dd"),
                    foreignRh.CheckRhAgrStart ? 0 : 2);
                InsertLvDetailsItem(idx++, "    Завершення дії договора",
                    foreignRh.RhAgrEnd.ToString("yyyy-MM-dd"),
                    foreignRh.CheckRhAgrEnd ? 0 : 2);
                InsertLvDetailsItem(idx++, "    ДОГОВІРНІ ВІДНОСИНИ ТОВАРИСТВА З УААСП",
                    "",
                    foreignRh.CheckCommunityHasRight ? 0 : 2);
                InsertLvDetailsItem(idx++, "        Наявність договору",
                    foreignRh.CommunityHasAgr ? "Так" : "Ні",
                    foreignRh.CheckCommunityHasAggr ? 0 : 2);
                InsertLvDetailsItem(idx++, "        Статус договору (код)",
                    foreignRh.CommunityAgrStatusCode);
                InsertLvDetailsItem(idx++, "        Статус договору (назва)",
                    foreignRh.CommunityAgrStatusName,
                    foreignRh.CheckCommunityAgrStatus ? 0 : 2);
                InsertLvDetailsItem(idx++, $"        Включає права на {ttl.ToLower()} використання",
                    foreignRh.CommunityAgrHasRight ? "Так" : "Ні",
                    foreignRh.CheckCommunityAgrHasRight ? 0 : 2);
                InsertLvDetailsItem(idx++, "        Початок дії прав",
                    foreignRh.CommunityAgrRightStart.ToString("yyyy-MM-dd"),
                    foreignRh.CheckCommunityAgrStart ? 0 : 2);
                InsertLvDetailsItem(idx++, "        Закінчення дії прав",
                    foreignRh.CommunityAgrRightEnd.ToString("yyyy-MM-dd"),
                    foreignRh.CheckCommunityAgrEnd ? 0 : 2);
            }
        }

        private void RemoveForeignAgrDetails(int idx, ForeignRightHolderInfo foreignRh)
        {
            lvDetails.Items.RemoveAt(idx);
            if (foreignRh != null)
            {
                for (int i = 0; i < 12; i++)
                {
                    lvDetails.Items.RemoveAt(idx);
                }
            }
        }

        private void InsertWorkAgrDetails(int idx, RightHolderInfo rightHolderInfo)
        {
            InsertLvDetailsItem(idx++, "    Код правоволодіння твором", rightHolderInfo.CopyRightId);
            InsertLvDetailsItem(idx++, "    Роль у створенні твору (код - назва)",
                $"{rightHolderInfo.WorkCreativeRoleCode} - {rightHolderInfo.WorkCreativeRoleName}");
            InsertLvDetailsItem(idx++, "    Статус правоволодіння (код - назва)",
                $"{rightHolderInfo.WorkRightsStatusCode} - {rightHolderInfo.WorkRightsStatusName}");
            InsertLvDetailsItem(idx++, "    Початок правоволодіння",
                rightHolderInfo.WorkRightsStartDate.ToString("yyyy-MM-dd"),
                rightHolderInfo.CheckWorkRightPeriod ? 0 : 2);
            InsertLvDetailsItem(idx++, "    Закінчення правоволодіння",
                rightHolderInfo.WorkRightsEndDate.ToString("yyyy-MM-dd"),
                rightHolderInfo.CheckWorkRightPeriod ? 0 : 2);
            InsertLvDetailsItem(idx++, "    Проценти Пуб", rightHolderInfo.RightHolderPerShr);
            InsertLvDetailsItem(idx++, "    Проценти Мех", rightHolderInfo.RightHolderMecShr);
            InsertLvDetailsItem(idx++, "    Заявлені проценти Пуб", rightHolderInfo.RightHolderPerShrClaimed);
            InsertLvDetailsItem(idx++, "    Заявлені проценти Мех", rightHolderInfo.RightHolderMecShrClaimed);
        }

        private void RemoveWorkAgrDetails(int idx)
        {
            for (int i = 0; i < 9; i++)
            { 
                lvDetails.Items.RemoveAt(idx); 
            }
        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            tvCheckPlan.Nodes.Clear();
            lvDetails.Items.Clear();
            tbPerShrTotal.Text = "";
            tbMecShrTotal.Text = "";
            FillReportWorks();
        }

        private ListViewItem AddLvDetailsItem(string caption, object value, int imageIndex = -1)
        {
            var item = lvDetails.Items.Add(caption);
            item.SubItems.Add(value == null ? "" : value.ToString());
            item.ImageIndex = imageIndex;
            return item;
        }

        private ListViewItem InsertLvDetailsItem(int idx, string caption, object value, int imageIndex = -1)
        {
            var item = lvDetails.Items.Insert(idx, caption);
            item.SubItems.Add(value == null ? "" : value.ToString());
            item.ImageIndex = imageIndex;
            return item;
        }

        private void lvReportWorks_SelectedIndexChanged(object sender, EventArgs e)
        {
            _titleOwnAgrExpanded            = false;
            _titleForeignAgrExpandedPer     = false;
            _titleForeignAgrExpandedMec     = false;
            _titleWorkAgrExpanded           = false;

            tvCheckPlan.Nodes.Clear();
            lvDetails.Items.Clear();
            tbPerShrTotal.Text = "";
            tbMecShrTotal.Text = "";

            if (lvReportWorks.SelectedItems.Count == 0)
            {
                return;
            }

            var reportWork = (ReportWork)lvReportWorks.SelectedItems[0].Tag;
            LoadWorkInfo(reportWork.ObjId);
            FillCheckPlan();
            
            tbPerShrTotal.Text = _workInfo.WorkPerShrClaimed.ToString();
            tbMecShrTotal.Text = _workInfo.WorkMecShrClaimed.ToString();

        }

        private void tvCheckPlan_AfterSelect(object sender, TreeViewEventArgs e)
        {
            _titleOwnAgrExpanded            = false;
            _titleForeignAgrExpandedPer     = false;
            _titleForeignAgrExpandedMec     = false;
            _titleWorkAgrExpanded           = false;

            lvDetails.Items.Clear();

            var selectedNode = e.Node;

            if(selectedNode.Tag == null)
            {
                return;
            }

            var type = selectedNode.Tag.GetType();
            if (type == typeof(WorkInfo))
            {
                FillWorkInfo();
            }
            else if (type == typeof(RightHolderInfo))
            {
                FillRightHolderInfo((RightHolderInfo)selectedNode.Tag);
            }
        }

        private void lvDetails_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void lvDetails_Click(object sender, EventArgs e)
        {
            Point mousePos = lvDetails.PointToClient(MousePosition);
            ListViewHitTestInfo hitTest = lvDetails.HitTest(mousePos);
            var location = hitTest.Location;
            var item = hitTest.Item;
            int columnIndex = hitTest.Item.SubItems.IndexOf(hitTest.SubItem);
            var rightHolderInfo = (RightHolderInfo)tvCheckPlan.SelectedNode.Tag;
            if (item.Tag != null && location == ListViewHitTestLocations.StateImage)
            {
                switch((TitleItemEnum)item.Tag)
                {
                    case TitleItemEnum.OwnAgr:
                        _titleOwnAgrExpanded = !_titleOwnAgrExpanded;
                        if (_titleOwnAgrExpanded)
                        { 
                            InsertOwnAgrDetails(item.Index + 1, rightHolderInfo);
                            item.StateImageIndex = 4;
                        }
                        else
                        {
                            RemoveOwnAgrDetails(item.Index + 1, rightHolderInfo);
                            item.StateImageIndex = 3;
                        }
                        break;
                    case TitleItemEnum.ForeignAgrPer:
                        _titleForeignAgrExpandedPer = !_titleForeignAgrExpandedPer;
                        if (_titleForeignAgrExpandedPer)
                        { 
                            InsertForeignAgrDetails(item.Index + 1, rightHolderInfo.ForeignRhPer, true);
                            item.StateImageIndex = 4;
                        }
                        else
                        {
                            RemoveForeignAgrDetails(item.Index + 1, rightHolderInfo.ForeignRhPer);
                            item.StateImageIndex = 3;
                        }
                        break;
                    case TitleItemEnum.ForeignAgrMec:
                        _titleForeignAgrExpandedMec = !_titleForeignAgrExpandedMec;
                        if (_titleForeignAgrExpandedMec)
                        {
                            InsertForeignAgrDetails(item.Index + 1, rightHolderInfo.ForeignRhMec, false);
                            item.StateImageIndex = 4;
                        }
                        else
                        {
                            RemoveForeignAgrDetails(item.Index + 1, rightHolderInfo.ForeignRhMec);
                            item.StateImageIndex = 3;
                        }
                        break;
                    case TitleItemEnum.WorkAgr:
                        _titleWorkAgrExpanded = !_titleWorkAgrExpanded;
                        if (_titleWorkAgrExpanded)
                        { 
                            InsertWorkAgrDetails(item.Index + 1, rightHolderInfo);
                            item.StateImageIndex = 4;
                        }
                        else
                        {
                            RemoveWorkAgrDetails(item.Index + 1);
                            item.StateImageIndex = 3;
                        }
                        break;
                }
                //FillRightHolderInfo(rightHolderInfo);
            }
        }
    }
}
