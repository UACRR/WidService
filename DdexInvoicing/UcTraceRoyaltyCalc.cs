using InvoicingLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
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
            public bool CheckAgreementPeriod        { get; set; }
            public bool CheckAgreementPerRights     { get; set; }
            public bool CheckAgreementMecRights     { get; set; }
            public bool CheckWorkRightStatus        { get; set; }
            public bool CheckWorkRightPeriod        { get; set; }

            public bool HasErrors                   { get; set; }
            public bool HasWarnings                 { get; set; }
            public bool IsIncluded                  { get; set; }
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

        private int _ddexReportId;
        private WorkInfo _workInfo;

        public UcTraceRoyaltyCalc()
        {
            InitializeComponent();
        }

        private void UcTraceRoyaltyCalc_Load(object sender, EventArgs e)
        {
            Configure();

            tbFilter.Text = "%з твоїх%";
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
            lvDetails.Columns.Clear();
            lvDetails.Columns.Add("Параметр", 400);
            lvDetails.Columns.Add("Значення", 200);

            lvChecks.View = View.Details;
            lvChecks.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvChecks.FullRowSelect = true;
            lvChecks.HideSelection = false;
            lvChecks.MultiSelect = false;
            lvChecks.GridLines = true;
            lvChecks.Columns.Clear();
            lvChecks.Columns.Add("Назва", 400);
            lvChecks.Columns.Add("Так", 60);
            lvChecks.Columns.Add("Ні", 60);
            lvChecks.Columns.Add("Не перевіряється", 160);
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
		            , isnull(t5.dateEnd, datefromparts(1900, 1, 1))		as RhAgrEnd				
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
            using (var r = cmd.ExecuteReader())
            {
                if (!r.HasRows)
                {
                    rightHolderInfo.HasAgreement = false;
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

        private void CheckRightHolder(RightHolderInfo rightHolderInfo)
        {
            rightHolderInfo.CheckAgreementStatus    = rightHolderInfo.AgrStatusCode == 2;
            rightHolderInfo.CheckAgreementPeriod    = 
                rightHolderInfo.AgrStart <= _workInfo.ReportEndDate && 
                rightHolderInfo.AgrEnd >= _workInfo.ReportStartDate;
            rightHolderInfo.CheckAgreementPerRights = rightHolderInfo.InternetServicePer == 1;
            rightHolderInfo.CheckAgreementMecRights = rightHolderInfo.InternetServiceMec == 1;
            rightHolderInfo.CheckWorkRightStatus    = rightHolderInfo.WorkRightsStatusCode == 1;
            rightHolderInfo.CheckWorkRightPeriod    = 
                rightHolderInfo.WorkRightsStartDate <= _workInfo.ReportEndDate && 
                rightHolderInfo.WorkRightsEndDate >= _workInfo.ReportStartDate;
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

                if(x.CheckAgreementStatus &&
                    x.CheckAgreementPeriod &&
                    x.CheckWorkRightPeriod &&
                    x.CheckWorkRightStatus
                )
                {
                    x.RightHolderPerShrClaimed = x.CheckAgreementPerRights ? x.RightHolderPerShr : 0;
                    x.RightHolderMecShrClaimed = x.CheckAgreementMecRights ? x.RightHolderMecShr : 0;
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
            _workInfo.RightHolders.ForEach( x =>
            {
                x.HasErrors = false;
                x.HasWarnings = false;
                if (!x.CheckAgreementStatus ||
                    !x.CheckWorkRightStatus ||
                    !x.CheckAgreementPeriod ||
                    !x.CheckWorkRightPeriod
                )
                {
                    _workInfo.HasErrors = true;
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
            });
        }

        private void FillCheckPlan()
        {
            tvCheckPlan.Nodes.Clear();
            var nodeWork = tvCheckPlan.Nodes.Add("Твір загалом");
            if (_workInfo.WorkPerShrClaimed + _workInfo.WorkMecShrClaimed == 0)
            {
                nodeWork.ImageIndex = 2;
                nodeWork.SelectedImageIndex = 2;
            }
            else if (_workInfo.HasErrors || _workInfo.HasWarnings)
            {
                nodeWork.ImageIndex = 1;
                nodeWork.SelectedImageIndex = 1;
            }
            else
            {
                nodeWork.ImageIndex = 0;
                nodeWork.SelectedImageIndex = 0;
            }
            nodeWork.Tag = _workInfo;

            var nodeRightHolders = tvCheckPlan.Nodes.Add("Окремі правовласники");
            nodeRightHolders.ImageIndex = 3;
            nodeRightHolders.SelectedImageIndex = 3;
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
                     select distinct top 100
	                      t3.ObjId
	                    , t3.Name
	                    , isnull(t3.Author, '')
	                    , isnull(t3.Performer, '')
                    from Ddex..IdentBacklog t1
	                    join Ddex..IdentMw t2 on t1.mwId = t2.Id
	                    join MediaService..ObjectRight t3 on t2.ObjId = t3.objId
                    where t1.DdexReportId = @DdexReportId
	                    and t2.ObjId is not null
	                    and (t3.ObjId = @ObjId or Name like @Name)
                ";
                cmd.Parameters.AddWithValue("@DdexReportId", _ddexReportId);
                cmd.Parameters.AddWithValue("@ObjId", ObjId);
                cmd.Parameters.AddWithValue("@Name", nameParamValue);

                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        var reportWork = new ReportWork
                        {
                            ObjId = r.GetInt32(0),
                            Name = r.GetString(1),
                            Authors = r.GetString(2),
                            Performers = r.GetString(3)
                        };

                        var item = lvReportWorks.Items.Add(reportWork.ObjId.ToString());
                        item.SubItems.Add(reportWork.Name);
                        item.SubItems.Add(reportWork.Authors);
                        item.SubItems.Add(reportWork.Performers);
                        item.Tag = reportWork;
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

        private void FillWorkCheckInfo()
        {
            AddLvChecksItem("Категорія твору відповідає вимогам", false, true);
            AddLvChecksItem("Статус твору відповідає вимогам", false, true);
        }

        private void FillRightHolderInfo(RightHolderInfo RightHolderInfo)
        {
             AddLvDetailsItem("Початок звітного періоду", _workInfo.ReportStartDate );
             AddLvDetailsItem("Початок звітного періоду", _workInfo.ReportEndDate );

             AddLvDetailsItem("", "");

             AddLvDetailsItem("Код правовласника", RightHolderInfo.CustId );
             AddLvDetailsItem("Наявність договору з УААСП", 
                 RightHolderInfo.HasAgreement ? "Так" : "Ні",
                 RightHolderInfo.HasAgreement ? 0 : 2);
             AddLvDetailsItem("Назва правовласника", RightHolderInfo.Name );
             AddLvDetailsItem("Поширення прав", RightHolderInfo.IsWorldWide ? "Світ" : "Україна" );
             AddLvDetailsItem("Міжнародний код правовласника", RightHolderInfo.IpBaseNr );
             AddLvDetailsItem("Тип равовласника (код - назва)", $"{RightHolderInfo.TypeCode} - {RightHolderInfo.TypeName}" );
             AddLvDetailsItem("Початок договору", RightHolderInfo.AgrStart, 
                 RightHolderInfo.CheckAgreementPeriod ? 0 : 2);
             AddLvDetailsItem("Закінчення договору", RightHolderInfo.AgrEnd,
                 RightHolderInfo.CheckAgreementPeriod ? 0 : 2);
             AddLvDetailsItem("Статус договору (код - назва)", $"{RightHolderInfo.AgrStatusCode} - {RightHolderInfo.AgrStatusName}",
                 RightHolderInfo.CheckAgreementStatus ? 0 : 2);
             AddLvDetailsItem("Наявність права на публічне відтворення в Інтернет", 
                 RightHolderInfo.InternetServicePer == 1 ? "Так" : "Ні",
                 RightHolderInfo.CheckAgreementPerRights ? 0 : 1);
             AddLvDetailsItem("Наявність права на механічне відтворення в Інтернет", 
                 RightHolderInfo.InternetServiceMec == 1 ? "Так" : "Ні",
                 RightHolderInfo.CheckAgreementMecRights ? 0 : 1);
             //AddLvDetailsItem("", RightHolderInfo.CommunityCustId );
             //AddLvDetailsItem("", RightHolderInfo.CommunityName );


            AddLvDetailsItem("", "");

            // Стосовно твору
            AddLvDetailsItem("Код правоволодіння твором", RightHolderInfo.CopyRightId           );
            AddLvDetailsItem("Роль у створенні твору (код - назва)", 
                $"{RightHolderInfo.WorkCreativeRoleCode} - {RightHolderInfo.WorkCreativeRoleName}");
			AddLvDetailsItem("Статус правоволодіння (код - назва)", 
                $"{RightHolderInfo.WorkRightsStatusCode} - {RightHolderInfo.WorkRightsStatusName}",
                RightHolderInfo.CheckWorkRightStatus ? 0 : 2);
			AddLvDetailsItem("Початок правоволодіння", RightHolderInfo.WorkRightsStartDate  ,
                RightHolderInfo.CheckWorkRightPeriod ? 0 : 2);
			AddLvDetailsItem("Закінчення правоволодіння", RightHolderInfo.WorkRightsEndDate,
                RightHolderInfo.CheckWorkRightPeriod ? 0 : 2);
			AddLvDetailsItem("Проценти Пуб", RightHolderInfo.RightHolderPerShr			 );
			AddLvDetailsItem("Проценти Мех", RightHolderInfo.RightHolderMecShr			 );
            AddLvDetailsItem("Заявлені проценти Пуб", RightHolderInfo.RightHolderPerShrClaimed	 );
			AddLvDetailsItem("Заявлені проценти Мех", RightHolderInfo.RightHolderMecShrClaimed    );
        }

        private void FillRightHolderCheckInfo(RightHolderInfo RightHolderInfo)
        {
            AddLvChecksItem("Договір з товариством активний", RightHolderInfo.CheckAgreementStatus, false);
            AddLvChecksItem("Період дії договору перетинається з періодом звіту", RightHolderInfo.CheckAgreementPeriod, false);
            AddLvChecksItem("Наявні права на відтворення в інтернеті (пуб)", RightHolderInfo.CheckAgreementPerRights, false);
            AddLvChecksItem("Наявні права на відтворення в інтернеті (мех)", RightHolderInfo.CheckAgreementMecRights, false);
            AddLvChecksItem("Правоволодіння твором затверджене", RightHolderInfo.CheckWorkRightStatus, false);
            AddLvChecksItem("Період правоволодіння на твір перетинається з періодом звіту", RightHolderInfo.CheckWorkRightPeriod, false);
        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            tvCheckPlan.Nodes.Clear();
            lvDetails.Items.Clear();
            lvChecks.Items.Clear();
            tbPerShrTotal.Text = "";
            tbMecShrTotal.Text = "";
            FillReportWorks();
        }

        private void AddLvDetailsItem(string caption, object value, int imageIndex = -1)
        {
            var item = lvDetails.Items.Add(caption);
            item.SubItems.Add(value == null ? "" : value.ToString());
            item.ImageIndex = imageIndex;
        }

        private void AddLvChecksItem(string caption, bool isOk, bool skip)
        {
            var item = lvChecks.Items.Add(caption);
            if (skip)
            {
                item.SubItems.Add("");
                item.SubItems.Add("");
            }
            else
            {
                item.SubItems.Add(isOk ? "x" : "");
                item.SubItems.Add(isOk ? "" : "x");
            }
            item.SubItems.Add(skip ? "x" : "");
            
        }

        private void lvReportWorks_SelectedIndexChanged(object sender, EventArgs e)
        {
            tvCheckPlan.Nodes.Clear();
            lvDetails.Items.Clear();
            lvChecks.Items.Clear();
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
            lvDetails.Items.Clear();
            lvChecks.Items.Clear();

            var selectedNode = e.Node;

            if(selectedNode.Tag == null)
            {
                return;
            }

            var type = selectedNode.Tag.GetType();
            if (type == typeof(WorkInfo))
            {
                FillWorkInfo();
                FillWorkCheckInfo();
            }
            else if (type == typeof(RightHolderInfo))
            {
                FillRightHolderInfo((RightHolderInfo)selectedNode.Tag);
                FillRightHolderCheckInfo((RightHolderInfo)selectedNode.Tag);
            }
        }
    }
}
