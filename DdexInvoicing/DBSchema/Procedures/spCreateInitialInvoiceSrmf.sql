USE [DDEX]
GO

/****** Object:  StoredProcedure [dbo].[spCreateInitialInvoiceSrmf]    Script Date: 12.09.2022 13:06:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER procedure [dbo].[spCreateInitialInvoiceSrmf]
		@ddexReportId int
	  , @fileId int
	  , @setCode int
as

begin
set nocount on;

--declare @ddexReportId int = 25;
declare @startDate date = (select UsageStartDate from DdexRecordHead where DdexReportId = @ddexReportId);
declare @endDate date = (select UsageEndDate from DdexRecordHead where DdexReportId = @ddexReportId);

begin -- Add missing assets from the report to the map
raiserror ('Add missing assets from the report to the map', 0, 1) with nowait 
merge PreClaimMappings as tgt
using (
	select  
		  t1.DspReleaseId
		, t1.mwId
		, t2.wic
		, t2.objId
	from IdentBacklog t1 
		join IdentMW t2 on t1.mwId = t2.id
	where t1.ddexReportId = @ddexReportId
) as src (DspReleaseId, mwId, wic, objId)
on tgt.DspReleaseId = src.DspReleaseId
when not matched then
insert values(
	  src.DspReleaseId
	, src.mwId
	, src.wic
	, src.objId
	, null
	, null
);
end

begin -- Update identification information in assets map (add newly identified works)
raiserror ('Update identification information in assets map', 0, 1) with nowait 
update t1
set 
	  t1.wic = t2.wic
	, t1.objId = t2.objId
from PreClaimMappings t1
	join IdentMw t2 on t1.mwId = t2.id
where (isnull(t1.wic, 0) + isnull(t2.objId, 0) = 0)
	and isnull(t2.wic, 0) + isnull(t2.objId, 0) <> 0
end

-- Identify authors
begin --Авторы с процентами по WID

-- Restrict works to serch authors for
drop table if exists #tmpIdentifiedWidMw
select distinct mwId, wic
into #tmpIdentifiedWidMw
from PreClaimMappings
where isnull(wic, 0) > 0

raiserror ('Авторы с процентами по WID', 0, 1) with nowait 
drop table if exists #TmpAuthorWid
create table #TmpAuthorWid ( 
   mwId					int					 not null,		
   wic                  int                  not null,
   objId                int                  not null,
   IP_BASE_NR           varchar(13)          null,
   custId               int                  null,
   IPInr                varchar(13)          null,
   ratePER              decimal(5,2)         null,
   rateMEC              decimal(5,2)         null,
   cmCodePER            varchar(3)           null,
   cmCodeMEC            varchar(3)           null,
   rateCmPER            decimal(5,2)         null,
   rateCmMEC            decimal(5,2)         null,
   validityPeriodStart  date                 null,
   validityPeriodEnd	date                 null,
   roleCode             int                  not null
)

declare @WidAuthorShares tblTypeWidAuthorShares

insert @WidAuthorShares
exec spGetWidAuthorShares 
	  @DdexReportId
	, @startDate
	, @endDate
	, @setCode


insert into #TmpAuthorWid
select  
	   t1.mwId			mwId
	 , t1.wic			wic
	 , 0				objId
	 , t2.IpBaseNr	    IP_BASE_NR
	 , null				custId
	 , t2.IpNameNr		IPInr
	 , t2.PerWidShr		ratePER
	 , t2.MecWidShr		rateMEC
	 , t2.PerSoc		cmCodePER
	 , t2.MecSoc		cmCodeMEC
	 , t2.PerSocShr		rateCmPER
	 , t2.MecSocShr		rateCmMEC
	 , @startDate		validityPeriodStart
	 , @endDate			validityPeriodEnd
	 , 0				roleCode
from #tmpIdentifiedWidMw t1
	join @WidAuthorShares t2 on t1.wic = t2.wic

update #TmpAuthorWid 
set 
	  cmCodePER = t2.SOC_CDE
	, rateCmPER = convert(decimal(5, 2), t2.MBR_SHARE / 100)
from #TmpAuthorWid t1 
    join WID_IPI..wCmAuthor t2 on t1.IP_BASE_NR = t2.IP_BASE_NR and t2.RGT_CDE = 'PR'
update #TmpAuthorWid 
set 
	  cmCodeMEC = t3.SOC_CDE
	, rateCmMEC = convert(decimal(5, 2), t3.MBR_SHARE / 100)   
from #TmpAuthorWid t1 
	join WID_IPI..wCmAuthor t3 on t1.IP_BASE_NR = t3.IP_BASE_NR and t3.RGT_CDE = 'MR'

delete from @WidAuthorShares

end

begin --Авторы с процентами по MS
raiserror ('Авторы с процентами по MS', 0, 1) with nowait 

drop table if exists #tmpIdentifiedMsMw
select distinct mwId, objId
into #tmpIdentifiedMsMw
from PreClaimMappings
where isnull(objId, 0) > 0

drop table if exists #TmpCRightId
create table  #TmpCRightId (
	cRightId integer not null primary key, 
	objId integer, 
	custId integer, 
	roleCode integer 
)
insert into #TmpCRightId (
	  cRightId
	, objId
	, custId
	, roleCode
) 
select 
	  max(t2.cRightId)
	, t2.objId
	, t2.custId
	, isnull(t2.roleCode, 0)
from #tmpIdentifiedMsMw t1  
    join MEDIASERVICE..copyright t2 on t1.objId = t2.objId 
where 
	isnull(t2.rate, 0) + isnull(t2.rateMECH, 0) <> 0 
	and
    ( 
			@startDate between t2.beginDate and t2.endDate
		or  @endDate between t2.beginDate and t2.endDate
		or  t2.beginDate between @startDate and @endDate
		or  t2.endDate between @startDate and  @endDate 
   	)
group by t2.objId, t2.custId, t2.roleCode

drop table if exists #TmpAuthorMS
create table #TmpAuthorMS ( 
   mwId					int					 not null,
   wic                  int                  null,
   objId                int                  null,
   IP_BASE_NR           varchar(13)          null,
   custId               int                  null,
   IPInr                varchar(13)          null,
   ratePER              decimal(5,2)         null,
   rateMEC              decimal(5,2)         null,
   cmCodePER            varchar(3)           null,
   cmCodeMEC            varchar(3)           null,
   rateCmPER            decimal(5,2)         null,
   rateCmMEC            decimal(5,2)         null,
   validityPeriodStart  date                 null,
   validityPeriodEnd	date                 null,
   roleCode             int					 not null
)
insert into #TmpAuthorMS
select 
	   t1.mwId					mwId
	 , 0						wic
	 , t1.objId					objId
	 , left(t3.interCode,13)	IP_BASE_NR
	 , t2.custId				custId
	 , left(t3.IPIbase,13)		IPInr
	 , t2.rate					ratePER
	 , t2.rate					rateMEC
	 , null						cmCodePER
	 , null						cmCodeMEC
	 , null						rateCmPER
	 , null						rateCmMEC
	 , @startDate				validityPeriodStart
	 , @endDate					validityPeriodEnd
	 , isnull(t7.roleCode, 0)  	roleCode
from #tmpIdentifiedMsMw t1 
	join MEDIASERVICE..copyright	t2	on t1.objId		= t2.objId 
	join #TmpCRightId				t7	on t2.cRightId	= t7.cRightId
	join MEDIASERVICE..RightHolder	 t3	on t2.custId	= t3.custId 

drop table if exists #vCustCmService -- replacement of view for performance increase
select t1.custId custId
	, t3.crGroupCode crGroupCode
	, isnull((Case When t2.ourService = 0 Then t4.cmCustId Else (select min(custId) from MediaService..vMyAnk) end),-1) as cmCustId
into #vCustCmService
from MediaService..RightHolder t1
	left join MediaService..TermsOfService t2 on t1.custId = t2.custId
	join MediaService..CopyrightKind t3 on t2.CRKindCode = t3.codeI
	left join MediaService..CustCmRight t4 on t4.custId = t2.custId and t4.cRKindCode = t2.CRKindCode

drop table if exists #CustCmGroup
select t1.custId
	, t1.crGroupCode
	, max(t1.cmCustId) as cmCustId
	, max(t2.interCode) as interCode
into #CustCmGroup
from #vCustCmService t1
	join MediaService..community t2 on t1.cmCustId = t2.custId
group by  t1.custId, t1.crGroupCode

drop table #vCustCmService

update #TmpAuthorMS 
set	CmCodePER = t2.interCode
from #TmpAuthorMS t1 
    join #CustCmGroup t2 on t1.custId = t2.custId and crGroupCode = 1 
where t1.objId is not null
update #TmpAuthorMS 
set cmCodeMEC = t2.interCode
from #TmpAuthorMS t1 
    join #CustCmGroup t2 on t1.custId = t2.custId and crGroupCode = 2
where t1.objId is not null
drop table #CustCmGroup

end

begin --Авторы с процентами по WID и MS
raiserror ('Авторы с процентами по WID и MS', 0, 1) with nowait 
drop table if exists #TmpAuthorBoth
create table #TmpAuthorBoth ( 
   mwId					int					 not null,
   wic                  int                  null,
   objId                int                  null,
   IP_BASE_NR           varchar(13)          null,
   custId               int                  null,
   IPInr                varchar(13)          null,
   ratePER              decimal(5,2)         null,
   rateMEC              decimal(5,2)         null,
   cmCodePER            varchar(3)           null,
   cmCodeMEC            varchar(3)           null,
   rateCmPER            decimal(5,2)         null,
   rateCmMEC            decimal(5,2)         null,
   validityPeriodStart  date                 null,
   validityPeriodEnd	date                 null,
   roleCode             int					 not null
)
insert into #TmpAuthorBoth 
select *
from #TmpAuthorWid
union
select *
from #TmpAuthorMs
end


begin -- drop intermediate tables
raiserror ('drop intermediate tables', 0, 1) with nowait 
drop table #TmpAuthorWid;
drop table #TmpAuthorMs;
drop table #TmpCRightId;
drop table #tmpIdentifiedWidMw;
drop table #tmpIdentifiedMsMw;
end

begin -- ОБРАБОТКА ИСКЛЮЧЕНИЙ
raiserror ('ОБРАБОТКА ИСКЛЮЧЕНИЙ', 0, 1) with nowait 
declare @setId int = (select SetCode from DdexReport where Id = @ddexReportId);; 

-- Fill-in table #TmpAuthor
raiserror ('Fill-in table #TmpAuthor', 0, 1) with nowait 
drop table if exists #TmpAuthor;
create table #TmpAuthor (
	mwId				 int			  not null,
	IP_BASE_NR           varchar(13)	  null,
	IPInr                varchar(13)	  null,
	cmCodePER            varchar(3)		  null,
	cmCodeMEC            varchar(3)		  null,
	excIdPER             int			  null,
	excStatusPER         int			  null,
	excIdMEC             int			  null,
	excStatusMEC         int		      null,
	roleCode             int		      not null,
	ratePer	             decimal(5,2)	  null,
	rateMec	             decimal(5,2)	  null, 
	includPER            bit			  null,
	includMEC            bit			  null, 
	custId               int		      null
)
create index i_1 on #TmpAuthor(IP_Base_NR)
create index i_2 on #TmpAuthor(IPInr)

--Отбираю идентификаторы для работы
raiserror ('Отбираю идентификаторы для работы', 0, 1) with nowait 
 insert into #TmpAuthor  
 select 
	  mwId
	, IP_Base_Nr
	, IPInr
	, cmCodePer
	, cmCodeMec
	, null excIdPER
	, case when cmCodePER is null then 2 else 1 end excStatusPER
	, null excIdMEC
	, case when cmCodeMEC is null then 2 else 1 end excStatusMEC
	, roleCode
	, ratePer
	, rateMEC
	, null includPER
	, null includMEC
	, custId
from #TmpAuthorBoth

--Исключаю ПУБЛИЧКА и МЕХАНИКА отдельно
raiserror ('Исключаю ПУБЛИЧКА и МЕХАНИКА отдельно', 0, 1) with nowait 
update #TmpAuthor 
set 
	  excIdPER = t2.id
	, excStatusPER = 2
from #TmpAuthor t1 
    join ExceptionMember t2 on t2.IPInr = t1.IPInr and excType = 3 and t1.roleCode = 8 
where isnull(t1.excIdPER, 0) = 0 
    and t2.setCode = @setId 
    and exists (
		select  1 
	    from #TmpAuthor t5 
			join ExceptionAdd t3 on t3.excId = t2.id and t3.interCode = isnull(t1.cmCodePER, t3.interCode)
		where t1.mwId = t5.mwId 
			and t5.IP_BASE_NR <> t1.IP_BASE_NR 
			and isnull(t5.ratePER, 0) <> 0 ) 

raiserror ('update #TmpAuthor', 0, 1) with nowait 
update #TmpAuthor 
set  
	  excIdMEC = t2.id
	, excStatusMEC = 2
from #TmpAuthor t1 
    join  ExceptionMember t2 on t2.IPInr = t1.IPInr and excType = 3 and t1.roleCode = 8 
where isnull(t1.excIdMEC, 0) = 0 
    and t2.setCode = @setId 
    and exists (
		select  1 
	    from #TmpAuthor t5 
			join ExceptionAdd t3 on  t3.excId = t2.id and t3.interCode = isnull(t1.cmCodeMEC, t3.interCode)
		where t1.mwId = t5.mwId 
			and t5.IP_BASE_NR <> t1.IP_BASE_NR 
			and isnull(t5.rateMec, 0) <> 0 ) 

--Исключаются Общества ПУБЛИЧКА и МЕХАНИКА
raiserror ('Исключаются Общества ПУБЛИЧКА и МЕХАНИКА', 0, 1) with nowait 
update #TmpAuthor 
set  
	  excIdPER = t2.id
	, excStatusPER = 2
from #TmpAuthor t1 
    join ExceptionMember t2 on t2.interCode = t1.CmCodePER and t2.excType = 1 
where isnull(t1.excIdPER, 0) = 0
    and t2.setCode = @setId

update #TmpAuthor 
set  
	  excIdMEC = t2.id
	, excStatusMEC = 2
from #TmpAuthor t1 
    join  ExceptionMember t2 on t2.interCode = t1.cmCodeMEC and t2.excType = 1 
where isnull(t1.excIdMEC, 0) = 0
    and t2.setCode = @setId

--Исключаются Правообладатели ПУБЛИЧКА и МЕХАНИКА
raiserror ('Исключаются Правообладатели ПУБЛИЧКА и МЕХАНИКА', 0, 1) with nowait 
update #TmpAuthor 
set  
	  excIdPER = t2.id
	, excStatusPER = 2
	, excIdMEC = t2.id
	, excStatusMEC = 2
from #TmpAuthor t1 
    join  ExceptionMember t2 on t1.IPInr = t2.IPInr  and excType = 2 
where isnull(t1.excIdPER,0) = 0
	and t2.setCode = @setId

--Исключаются Правообладатели с custId <> 0, если нет активного договора
raiserror ('Исключаются Правообладатели с custId <> 0, если нет активного договора', 0, 1) with nowait 
update #TmpAuthor 
set  
	  includPER = 0
	, includMEC = 0
from #TmpAuthor t1 
    join vMSCustomerRHolder t2 on t1.custId = t2.custId  and t2.agrStatus <> 2 
where t1.custId is not null 

--Исключения по договорам Community
--Если даты по мех/перф попадают в период - беру, если нет - не беру, includPER = 1/0 или inclusMec = 1/0
--Определяю даты периода, чтобы права брать только за этот период (хоть одна дата периода пересекается с правами)

--Только для проверенніх (excStatusMEC = 1 - проверен)
raiserror ('Только для проверенніх (excStatusMEC = 1 - проверен)', 0, 1) with nowait 
update #TmpAuthor 
set 
	  includPER = (case when t1.excStatusPER = 1 and isnull(t2.isPER, 0) = 1 then 1 else 0 end)
	, includMEC = (case when t1.excStatusMEC = 1 and isnull(t3.isMEC, 0) = 1 then 1 else 0 end)
from #TmpAuthor t1 
	left join vMSCommunity t2 on t1.cmCodePER = t2.interCode 
		and (@startDate between t2.dateBeginPER and t2.dateEndPER or @endDate between t2.dateBeginPER and t2.dateEndPER )
	left join vMSCommunity t3 on t1.cmCodeMEC = t3.interCode 
		and (@startDate between t2.dateBeginMEC and t2.dateEndMEC or @endDate between t2.dateBeginMEC and t2.dateEndMEC )

---Поправочки по Оле
--временно, пока не откажится  --18-10-2019
raiserror ('Поправочки по Оле', 0, 1) with nowait 
update #TmpAuthor 
set 
	  cmCodeMEC = 140
	, cmCodePER = 140
	, IncludMEC = 1
	, IncludPER = 1
where IP_BASE_NR = 'i-003577688-4'

update #TmpAuthor 
set 
	  cmCodeMEC = 140
	, cmCodePER = 140
	, IncludMEC = 1
	, IncludPER = 1
where IP_BASE_NR = 'i-003842830-5'

update #TmpAuthor 
set 
	  cmCodeMEC = '094'
	, IncludMEC = IncludPER
where cmCodePER = '094' 
	and cmCodeMEC is null

end

begin -- FINALIZE
raiserror ('FINALIZE', 0, 1) with nowait
-- Make TmpNewRates persistent for use in spCreateInitialInvoiceSrmf
drop table if exists #TmpNewRates
create table #TmpNewRates (  
	mwId					int					not null,
	rateTotalPER			decimal(5,2)		 not null, 
	rateTotalMEC			decimal(5,2)		 not null,
	primary key (mwId)
)

insert into #TmpNewRates
select
	  mwId
	, isnull(sum(ratePER * includPER), 0) as rateTotalPER
	, isnull(sum(rateMEC * includMEC), 0) as rateTotalMEC
from #TmpAuthor
where excStatusPer > 0  --прошло исключения
group by mwId

update #TmpNewRates set rateTotalMEC = 0  where rateTotalMEC > 100
update #TmpNewRates set rateTotalPER = 0  where rateTotalPER > 100

end

drop table #TmpAuthor

begin -- СОЗДАНИЕ ЗАПИСЕЙ ДЛЯ CCID

declare @invoiceId int;

-- get date from Ddex header record for the report
declare
	  @UsageStartDate date
	, @UsageEndDate date
select 
	  @UsageStartDate = UsageStartDate
	, @UsageEndDate   = UsageEndDate
from  DdexRecordHead
where DdexReportId = @ddexReportId

if @fileId is null
begin
	insert into CcidInvoice (
		  ddexReportId
		, createdDate
		, status
		, recordCount
		, netRevenueExcluded
		, netRevenueClaimed
	)
	values (
		  @ddexReportId -- ddexReportId
		, getdate()		-- createdDate
		, 0				-- status
		, null			-- recordCount
		, null			-- netRevenueExcluded
		, null			-- netRevenueClaimed
	);
	select @invoiceId = SCOPE_IDENTITY();
end
else
begin
	select 
		@invoiceId = ccidInvoiceId 
	from  CcidInFile 
	where fileId = @fileId;
end

-- cleanup CCID records for invoice
if @fileId is not null
begin
	delete from CcidInDetail  where fileId = @fileId
	delete from CcidInTrailer where fileId = @fileId
	delete from CcidInHeader  where fileId = @fileId
end
else
begin
	insert into CcidInFile (
		  ccidInvoiceId
		, InstanceIndex
		, status
		, Name
		, TargetFolder
	)
	values ( 
		  @invoiceId --ccidInvoiceId
		, 1			 --InstanceIndex
		, 0			 --status
		, ''		 --Name
		, ''		 --TargetFolder
	);
	set @fileId = scope_identity();
end

-- Create CcidInHeader Record 
insert into CcidInHeader(
		fileId
	, record_type
	, version
	, date
	, sender
	, receiver
	, ccid_id
	, territory
	, start_date
	, end_date
	, royalty_currency
	, original_revenue_basis_currency
	, conversion_rate
	, work_code_type
	, ccid_id_correction_reference
	, type_of_claim
	, commercial_model
	, service_description
	, use_type
	, mech_perc_split
	, perf_perc_split
	, aux
)
values (
		@fileId						--fileId
	, 'HD'							--record_type
	, '14.1'						--version
	, GetDate()						--date
	, 'UACRR-CS'					--sender
	, 'YouTube'						--receiver
	, cast(@fileId as varchar)		--ccid_id
	, 'UA'							--territory
	, @UsageStartDate				--start_date
	, @UsageEndDate					--end_date
	, 'USD'							--royalty_currency
	, 'USD'							--original_revenue_basis_currency
	, 0.00000						--conversion_rate
	, null							--work_code_type
	, null							--ccid_id_correction_reference
	, 'IN'							--type_of_claim
	, 'AdvertisementSupportedModel'	--commercial_model
	, 'Usage-AdSupport-Music'		--service_description
	, 'OnDemandStream'				--use_type
	, 0								--mech_perc_split
	, 0								--perf_perc_split
	, null							--aux
)

-- Select unique iswcs
drop table if exists #tmpIswcs
select Wic, min(Iswc) iswc
into #tmpIswcs
from SocWid..WidIswc
group by Wic


-- Create detail records
insert into CcidInDetail (
	  fileId
	, record_type
	, transaction_type
	-- , ref_id (skip identity key)
	, correction_reference
	, sales_transaction_id
	, work_id
	, release_id
	, resource_id
	, isrc
	, iswc
	, workcode
	, work_title
	, use_quantity
	, applied_tariff
	, royalty_type
	, revenue_basis
	, original_release_revenue_basis
	, original_resource_revenue_basis
	, royalty
	, resource_share
	, restrictions
	, claim_licensor_combined
	, claim_copcon_combined
	, claim_unmatched_combined
	, claim_pd_combined
	, claim_not_collected_combined
	, amount_invoiced_total
	, claim_licensor_mech
	, claim_licensor_perf
	, amount_licensor_mech
	, amount_licensor_perf
	, amount_copcon_mech
	, amount_copcon_perf
	, amount_pd_mech
	, amount_pd_perf
	, amount_not_collected_mech
	, amount_not_collected_perf
	, amount_unmatched_mech
	, amount_unmatched_perf
	, claim_copcon_mech
	, claim_copcon_perf
	, claim_pd_mech
	, claim_pd_perf
	, claim_not_collected_mech
	, claim_not_collected_perf
	, claim_unmatched_mech
	, claim_unmatched_perf
)
select
	  @fileId														fileId
	, 'ID'															record_type
	, 'ORI'															transaction_type
	-- , ref_id (skip identity key)									ref_id
	, null															correction_reference
	, null															sales_transaction_id
	, null															work_id
	, left(t1.dspReleaseId, 60)										release_id
	, left(t1.dspReleaseId, 60)										resource_id
	, null															isrc
	, isnull(t5.ISWC, '')  										iswc
	, left(
		case 
		when 
			t3.Wic is null 
		then 
			case
				when
					 t4.[ObjId] is null
				then 
					''
				else 
					'ObjId:' + cast(t4.[ObjId] as varchar(100)) 
			end
		else 
			'Wic:' + cast(t3.Wic as varchar(100)) 
		end
		, 39)														workcode
	, left(
		case 
		when 
			t3.Wic is null 
		then case
				when t4.[name] is null
				then 
					''
				else 
					t4.[name] 
			end
		else 
			t3.WrkTtl 
		end
		, 60)														work_title
	, 0																use_quantity
	, null															applied_tariff
	, null															royalty_type
	, 0																revenue_basis
	, 0																original_release_revenue_basis
	, 0																original_resource_revenue_basis
	, 0																royalty
	, null															resource_share
	, null															restrictions
	, 0																claim_licensor_combined
	, null															claim_copcon_combined
	, null															claim_unmatched_combined
	, null															claim_pd_combined
	, null															claim_not_collected_combined
	, 0																amount_invoiced_total
	, t2.rateTotalMEC												claim_licensor_mech
	, t2.rateTotalPER												claim_licensor_perf
	, 0																amount_licensor_mech
	, 0																amount_licensor_perf
	, 0																amount_copcon_perf
	, 0																amount_copcon_perf
	, 0																amount_pd_mech
	, 0																amount_pd_perf
	, 0																amount_not_collected_mech
	, 0																amount_not_collected_perf
	, 0																amount_unmatched_mech
	, 0																amount_unmatched_perf
	, null															claim_copcon_mech
	, null															claim_copcon_perf
	, null															claim_pd_mech
	, null															claim_pd_perf
	, null															claim_not_collected_mech
	, null															claim_not_collected_perf
	, null															claim_unmatched_mech
	, null															claim_unmatched_perf

from PreClaimMappings t1
	inner join #TmpNewRates t2					on t1.mwId			= t2.mwId
	left  join SocWid..WidTitle t3			    on t3.Wic			= t1.Wic
	left  join MediaService.dbo.ObjectRight t4	on t4.[ObjId]		= t1.ObjId
	left join #tmpIswcs t5						on t5.WIC			= t3.wic
where t1.rateTotalPER <> t2.rateTotalPER
	or t1.rateTotalMEC <> t2.rateTotalMEC
	or t1.rateTotalPER is null
	or t1.rateTotalMEC is null

-- delete temp table
drop table #tmpIswcs

-- вставляем trailer

insert into CcidInTrailer(
	  fileId
	, record_type
	, id_records
	, dl_records
	, sum_amount_licensor
	, sum_amount_copcon
	, sum_amount_unmatched
)
select
	  @fileId				fileId
	, 'TR'					record_type
	, isnull(count(*), 0)	id_records
	, 0						dl_records
	, 0						sum_amount_licensor
	, 0						sum_amount_copcon
	, 0						sum_amount_unmatched
from  CcidInDetail
where fileId = @fileId

end


end

-- exec spCreateInitialInvoiceSrmf 50, 99
-- select * from CcidInDetail where fileid = 99 and claim_licensor_mech + claim_licensor_perf > 0
/*
select * 
from TmpNewRates
where rateTotalPer + rateTotalMec > 0
*/
GO

