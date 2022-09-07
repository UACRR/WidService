if not exists (select null FROM syscolumns where id = object_id('DdexReport') and name = 'musicRate')
  alter table DdexReport add musicRate decimal(5, 2)
go

update t1
set musicRate = cast(t2.paramValue as decimal(5, 2))
from DdexReport t1
	join AgreementParam t2 on t1.licId = t2.licId and t1.custId = t2.custId and t2.paramId = 1
where musicRate is null;
go

if not exists (select null FROM syscolumns where id = object_id('DdexReport') and name = 'geRate')
  alter table DdexReport add geRate decimal(5, 2)
go

update t1
set geRate = cast(t2.paramValue as decimal(5, 2))
from DdexReport t1
	join AgreementParam t2 on t1.licId = t2.licId and t1.custId = t2.custId and t2.paramId = 2
where geRate is null;
go

if not exists (select null FROM syscolumns where id = object_id('DdexReport') and name = 'mechSplit')
  alter table DdexReport add mechSplit decimal(5, 2)
go

update t1
set mechSplit = cast(t2.paramValue as decimal(5, 2))
from DdexReport t1
	join AgreementParam t2 on t1.licId = t2.licId and t1.custId = t2.custId and t2.paramId = 3
where mechSplit is null;
go

if not exists (select null FROM syscolumns where id = object_id('DdexReport') and name = 'perfSplit')
  alter table DdexReport add perfSplit decimal(5, 2)
go

update t1
set perfSplit = cast(t2.paramValue as decimal(5, 2))
from DdexReport t1
	join AgreementParam t2 on t1.licId = t2.licId and t1.custId = t2.custId and t2.paramId = 4
where perfSplit is null;
go

if not exists (select null FROM syscolumns where id = object_id('DdexReport') and name = 'musicPSM')
  alter table DdexReport add musicPSM decimal(5, 2)
go

update t1
set musicPSM = cast(t2.paramValue as decimal(5, 2))
from DdexReport t1
	join AgreementParam t2 on t1.licId = t2.licId and t1.custId = t2.custId and t2.paramId = 5
where musicPSM is null;
go

if not exists (select null FROM syscolumns where id = object_id('DdexReport') and name = 'gePSM')
  alter table DdexReport add gePSM decimal(5, 2)
go

update t1
set gePSM = cast(t2.paramValue as decimal(5, 2))
from DdexReport t1
	join AgreementParam t2 on t1.licId = t2.licId and t1.custId = t2.custId and t2.paramId = 6
where gePSM is null;
go

if not exists (select null FROM syscolumns where id = object_id('DdexReport') and name = 'exchRate')
  alter table DdexReport add exchRate decimal(20, 6)
go

update t1
set exchRate = cast(t3.exchRate as decimal(20, 6))
from DdexReport t1
	join DdexReportingPeriod t2 on t2.id = t1.ddexReportingPeriodId
	join CcidExchangeRate t3 on t1.licId = t3.licId 
			and t1.custId = t3.custId 
			and t2.year = t3.year
			and t3.month = 3 * t2.quarter - 2
where t1.exchRate is null; 
go

update DdexReport
set royaltyThreshold = 0
where royaltyThreshold is null;
go

drop procedure if exists spDeleteDdexReport
go

create procedure spDeleteDdexReport
	@ddexReportId int
as
/*
Удаляет отчет и связанные с ним записи, чтобы можно было повторить регистрацию,
загрузку и последующие шаги с нуля.
Не затрагивает identMw и таблицы, относящиеся к архивации
В настоящее время предназначено для тестирования, в интерфейсе пользователя не используется
*/
begin
-- отправленные Ccid
delete t1
from CcidInHeader t1
	join CcidInFile t2 on t2.fileId = t1.fileId
	join CcidInvoice t3 on t3.id = t2.ccidInvoiceId
	join DdexReport t4 on t4.id = t3.ddexReportId
where t4.id = @ddexReportId;

delete t1
from CcidInTrailer t1
	join CcidInFile t2 on t2.fileId = t1.fileId
	join CcidInvoice t3 on t3.id = t2.ccidInvoiceId
	join DdexReport t4 on t4.id = t3.ddexReportId
where t4.id = @ddexReportId;

delete t1
from CcidInDetail t1
	join CcidInFile t2 on t2.fileId = t1.fileId
	join CcidInvoice t3 on t3.id = t2.ccidInvoiceId
	join DdexReport t4 on t4.id = t3.ddexReportId
where t4.id = @ddexReportId;

delete t2
from CcidInFile t2
	join CcidInvoice t3 on t3.id = t2.ccidInvoiceId
	join DdexReport t4 on t4.id = t3.ddexReportId
where t4.id = @ddexReportId;

-- принятые Ccid
delete t1
from CcidClHeader t1
	join CcidClFile t2 on t2.fileId = t1.fileId
	join CcidInvoice t3 on t3.id = t2.ccidInvoiceId
	join DdexReport t4 on t4.id = t3.ddexReportId
where t4.id = @ddexReportId;

delete t1
from CcidClTrailer t1
	join CcidClFile t2 on t2.fileId = t1.fileId
	join CcidInvoice t3 on t3.id = t2.ccidInvoiceId
	join DdexReport t4 on t4.id = t3.ddexReportId
where t4.id = @ddexReportId;

delete t1
from CcidClDetail t1
	join CcidClFile t2 on t2.fileId = t1.fileId
	join CcidInvoice t3 on t3.id = t2.ccidInvoiceId
	join DdexReport t4 on t4.id = t3.ddexReportId
where t4.id = @ddexReportId;

delete t2
from CcidClFile t2
	join CcidInvoice t3 on t3.id = t2.ccidInvoiceId
	join DdexReport t4 on t4.id = t3.ddexReportId
where t4.id = @ddexReportId;

-- Принятые отчеты
delete t1
from CrfDetail t1
	join CcidInFile t2 on t2.fileId = t1.fileId
	join CcidInvoice t3 on t3.id = t2.ccidInvoiceId
	join DdexReport t4 on t4.id = t3.ddexReportId
where t4.id = @ddexReportId;

delete t1
from DdexAdjustment t1
	join CcidInFile t2 on t2.fileId = t1.fileId
	join CcidInvoice t3 on t3.id = t2.ccidInvoiceId
	join DdexReport t4 on t4.id = t3.ddexReportId
where t4.id = @ddexReportId;

-- Инвойсы
delete t3
from  CcidInvoice t3
	join DdexReport t4 on t4.id = t3.ddexReportId
where t4.id = @ddexReportId;

-- Остальное
delete
from DdexFileErrors
where ddexReportId = @ddexReportId;

delete
from DdexIdentificationBacklog
where ddexReportId = @ddexReportId;

delete
from DdexNetRevenueDistr
where ddexReportId = @ddexReportId;

delete
from DdexRecordHead
where ddexReportId = @ddexReportId;

delete
from DdexRecordSY_04_01
where ddexReportId = @ddexReportId;

delete
from DdexRecordSY_05_02
where ddexReportId = @ddexReportId;

delete
from DdexReportArchRestoreProtocol
where ddexReportId = @ddexReportId;

delete
from DdexReportProcessingData
where ddexReportId = @ddexReportId;

delete
from IdentMWAuthor
where ddexReportId = @ddexReportId;

alter table IdentMWAuthor drop constraint if exists FK_IDENTMWA_REFERENCE_IDENTBAC

delete
from IdentBacklog
where ddexReportId = @ddexReportId;

alter table IdentMWAuthor add  constraint FK_IDENTMWA_REFERENCE_IDENTBAC foreign key(BlockId, DdexReportId, SalesTransactionId)
references IdentBacklog (BlockId, DdexReportId, SalesTransactionId)


delete t3
from  IdentProgressByBlock t3
	join IdentProgress t4 on t4.id = t3.IdentProgressId
where t4.id = @ddexReportId;

delete
from IdentProgress
where ddexReportId = @ddexReportId;

delete
from IdentReportMwRecords
where ddexReportId = @ddexReportId;

-- удалить очет
delete
from DdexReport
where id = @ddexReportId;

end
go

drop procedure if exists spCreateCcidParamsForSubscr
go

create procedure spCreateCcidParamsForSubscr
	  @ddexReportId int
	
	, @musicRate float output
	, @geRate float output
	, @mechSplit float output
	, @perfSplit float output
	, @totalRevSharePayable float output
	, @totalPSMPayable float output
	, @constantGrossRevenueValue float output
	, @constantPSMRoyaltyValue float output
	, @blendedRevshareRate float output
as
begin
/*
Процедура вычисляет параметры необходимые для расчета позиций по инвойсу для подписки.
Расчеты основаны на документе SWOD от Гугл. 
*/

-- agreement parameters
declare @licId int
	  , @custId int;
select @licId = licId
	 , @custId = custId
from DdexReport 
where id = @ddexReportId;

declare @exchRate float = (select cast(exchRate as float) from DdexReport where id = @ddexReportId);


set @musicRate = (select cast(musicRate as float) * 0.01 from DdexReport where id = @ddexReportId);
set @geRate = (select cast(geRate as float) * 0.01 from DdexReport where id = @ddexReportId);
set @mechSplit = (select cast(mechSplit as float) * 0.01 from DdexReport where id = @ddexReportId);
set @perfSplit = (select cast(perfSplit as float) * 0.01 from DdexReport where id = @ddexReportId);
declare @musicPSM float = (select cast(musicPSM as float) from DdexReport where id = @ddexReportId);
declare @gePSM float = (select cast(gePSM as float) * @exchRate from DdexReport where id = @ddexReportId);

-- ============ Calc base data
declare @perfMS float = 1;
declare @mechMS float = 1;

declare @marketShareCombined float = @perfSplit * @perfMS + @mechSplit * @mechMS;
declare @musicShareCombined float = @musicRate * @marketShareCombined;
declare @geShareCombined float = @geRate * @marketShareCombined;

declare @totalRevenue float = (
	select sum(netrevenue) 
	from DdexRecordSY_04_01 
	where ddexReportId = @ddexReportId 
		and SubscriberType = 'all');
declare @musicPlusGEMusicViews int = (
	select sum(TotalUsages) 
	from DdexRecordSY_05_02 
	where ddexReportId = @ddexReportId 
		and ContentCategory in ('Music', 'GEMusic'));
declare @musicViews int = (
	select sum(TotalUsages) 
	from DdexRecordSY_05_02 
	where ddexReportId = @ddexReportId 
		and ContentCategory = 'Music');
declare @musicRatio float = (
	select @musicViews / sum(TotalUsages) 
	from DdexRecordSY_05_02 
	where ddexReportId = @ddexReportId);
declare @geRatio float = 1 - @musicRatio;
declare @subscriberCount int = (
	select sum(Subscribers) from DdexRecordSY_04_01 where ddexReportId = @ddexReportId and SubscriberType = 'all');
declare @musicPSMPool float = @subscriberCount * @musicPSM;
declare @gePSMPool float = @subscriberCount * @gePSM;
declare @blendedPSMPool float = @musicRatio * @musicPSMPool + @geRatio * @gePSMPool;
set @constantPSMRoyaltyValue = @blendedPSMPool / @musicPlusGEMusicViews;
set @constantGrossRevenueValue = @totalRevenue / @musicPlusGEMusicViews;
set @totalRevSharePayable = @totalRevenue * (@musicShareCombined * @musicRatio + @geShareCombined * @geRatio)
set @totalPSMPayable = @subscriberCount * (@MusicRatio * @MusicPSM + @geRatio * @gePsm);
set @blendedRevshareRate = @musicRatio * @musicRate + @geRatio * @geRate;

/*
select 
	  @musicRate musicRate
	, @geRate geRate
	, @mechSplit mechSplit
	, @perfSplit perfSplit
	, @totalRevSharePayable TotalRevSharePayable 
	, @totalPSMPayable TotalPSMPayable 
	, @constantGrossRevenueValue ConstantGrossRevenueValue
	, @constantPSMRoyaltyValue constantPSMRoyaltyValue
	, @blendedRevshareRate blendedRevshareRate*/
end
go

drop procedure if exists spCreateInitialInvoice
go

create procedure spCreateInitialInvoice @ddexReportId int, @fileId int
as
begin
/*
Данная процедура формирует данные для инвойса гуглу для отчетов типа реклама.
Поскольку все файлы инвойса (отосланные-принятые) объединяются под одной записью CcidInvoice
предусмотрено два режима. если @fileId - null, создается новая строка в CcidInvoice, и к ней
прикрепляются записи CcidInFile, CcidHeader, CcidDetail, CcidTrailer.
Если @fileId не null, то только переформировуются только строки таблиц CcidHeader, CcidDetail, CcidTrailer.
*/
declare @invoiceId int;
declare @inInstanceIndex int;
--declare @sum_amount_licensor numeric(30, 6)
declare @RecipientName varchar(100), @SenderName varchar(100), @UsageStartDate date, @UsageEndDate date
--declare @invoiceId int;

--declare @ddexReportId int = 31;

-- agreement parameters
declare @licId int, @custId int;
select @licId = licId, @custId = custId
from DdexReport 
where id = @ddexReportId;

/*
declare @musicRate float = (select cast(paramValue as float) * 0.01 from AgreementParam where paramId = 1 and licId = @licId and custId = @custId);
declare @geRate float = (select cast(paramValue as float) * 0.01 from AgreementParam where paramId = 2 and licId = @licId and custId = @custId);
declare @mechSplit float = (select cast(paramValue as float) * 0.01 from AgreementParam where paramId = 3 and licId = @licId and custId = @custId);
declare @perfSplit float = (select cast(paramValue as float) * 0.01 from AgreementParam where paramId = 4 and licId = @licId and custId = @custId);
*/

-- Используем информацию из строки отчета
declare @musicRate float = (select cast(musicRate as float) * 0.01 from DdexReport where id = @ddexReportId);
declare @geRate float = (select cast(geRate as float) * 0.01 from DdexReport where id = @ddexReportId);
declare @mechSplit float = (select cast(mechSplit as float) * 0.01 from DdexReport where id = @ddexReportId);
declare @perfSplit float = (select cast(perfSplit as float) * 0.01 from DdexReport where id = @ddexReportId);

--select @musicRate, @geRate, @mechSplit, @perfSplit

if @musicRate is null or @geRate is null or @mechSplit is null or @perfSplit is null
begin
	raiserror('Відсутня інформація із догоіору, необхідна для розрахунків', 0, 0);
	return;
end

-- Add record to CCID Invoice
--select @invoiceId = id
--from CcidInvoice 
--where ddexReportId = @ddexReportId;

-- get date from Ddex header record for the report
select @RecipientName = RecipientName
	, @SenderName = SenderName
	, @UsageStartDate = UsageStartDate
	, @UsageEndDate = UsageEndDate
from DdexRecordHead
where DdexReportId = @ddexReportId

if @fileId is null
begin
	insert into CcidInvoice(ddexReportId, createdDate, [status], recordCount, netRevenueExcluded, netRevenueClaimed)
	values (@ddexReportId, getdate(), 0, null, null, null);
	select @invoiceId = SCOPE_IDENTITY();
end
else
begin
	select @invoiceId = ccidInvoiceId from CcidInFile where fileId = @fileId;
end


-- cleanup CCID records for invoice
if @fileId is not null
begin
	delete from CcidInDetail where fileId = @fileId
	delete from CcidInTrailer where fileId = @fileId
	delete from CcidInHeader where fileId = @fileId
end
else
begin
	insert into CcidInFile(ccidInvoiceId, InstanceIndex, [status], [Name], TargetFolder)
	values (@invoiceId, 1, 0, '', '');
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
		@fileId
		, 'HD'
		, '14.1'
		, GetDate()
		, 'UACRR-CS'
		, 'Google'
		, cast(@fileId as varchar) -- ccid_id
		, 'UA'
		, @UsageStartDate
		, @UsageEndDate
		, 'USD'
		, 'USD'
		, 1.00000
		, null
		, null
		, 'IN'
		, 'AdvertisementSupportedModel'
		, 'YouTube'
		, 'OnDemandStream'
		, @mechSplit * 100
		, @perfSplit * 100
		, cast(@musicRate * 100 as varchar) + '|' + cast(@geRate * 100 as varchar)
)

-- Create detail records
insert into CcidInDetail (
		  fileId
		, record_type
		, transaction_type
		--, correction_reference
		, sales_transaction_id
		--, work_id
		, release_id
		, resource_id
		--, isrc
		--, iswc
		, workcode
		, work_title
		, use_quantity
		, applied_tariff
		, royalty_type
		, revenue_basis
		, original_release_revenue_basis
		, original_resource_revenue_basis
		--, royalty
		, resource_share
		--, restrictions
		, claim_licensor_combined
		--, claim_copcon_combined
		, claim_unmatched_combined
		--, claim_pd_combined
		--, claim_not_collected_combined
		, amount_invoiced_total
		, claim_licensor_mech
		, claim_licensor_perf
		, amount_licensor_mech
		, amount_licensor_perf
		/*
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
		*/
)
select 
		  @fileId
		, 'ID'
		, 'ORI'
		, t1.salestransactionid sales_transaction_id
		, left(t1.dspreleaseid, 60) release_id
		, left(t1.dspreleaseid, 60) resource_id
		, left(case 
			when t3.Wic is null 
			then case
					when t4.[ObjId] is null
					then ''
					else 'ObjId:' + cast(t4.[ObjId] as varchar(100)) 
				end
			else 'Wic:' + cast(t3.Wic as varchar(100)) 
			end
		  , 39) workcode
		, left(case 
			when t3.Wic is null 
			then case
					when t4.[name] is null
					then ''
					else t4.[name] 
				end
			else t3.ttl 
			end
			, 60) work_title
		, t1.usages use_quantity
		, case when t1.ContentCategory = 'Music' then @musicRate * 100 else @geRate * 100 end applied_tariff
		, 'P' royalty_type
		, t1.netrevenue revenue_basis
		, t1.netrevenue original_release_revenue_basis
		, t1.netrevenue original_resource_revenue_basis
		--, case when t1.usages > 0 then cast(t1.netrevenue as float) / t1.usages else null end royalty
		, 100 resource_share
		, (
				cast(t1.rateTotalMEC as float) * @mechSplit
				+  
				cast(t1.rateTotalPER as float) * @perfSplit
			) 
				as claim_licensor_combined
		, (case when t2.[status] = 1 then 100 else 0 end) claim_unmatched_combined
		, 0.01
			* (
				cast(t1.rateTotalMEC as float) * @mechSplit
				+  
				cast(t1.rateTotalPER as float) * @perfSplit
			)
			* (case when t1.ContentCategory = 'Music' then @musicRate else @geRate end)
			* t1.netrevenue 
				as amount_invoiced_total
		, t1.rateTotalMEC claim_licensor_mech
		, t1.rateTotalPER claim_licensor_perf
		, 0.01
			* cast(t1.rateTotalMEC as float) 
			* @mechSplit
			* (case when t1.ContentCategory = 'Music' then @musicRate else @geRate end)
			* t1.netrevenue 
				as amount_licensor_mech
		, 0.01
			* cast(t1.rateTotalPER as float) 
			* @perfSplit
			* (case when t1.ContentCategory = 'Music' then @musicRate else @geRate end)
			* t1.netrevenue 
				as amount_licensor_perf
from IdentBacklog t1 
	inner join IdentMW t2 on t2.id = t1.mwid
	left join WID_IPI.dbo.TblTitle t3 on t3.Wic = t2.Wic
	left join MediaService.dbo.ObjectRight t4 on t4.[ObjId] = t2.[ObjId]
where t1.DdexReportId = @ddexReportId
	and (t1.IncludedInCcid is null or t1.IncludedInCcid = @invoiceId)
	and (t2.[Status] = 1 or t2.[Status] = 2)

-- Удаляем записи с малой прибылью
exec spRemoveLowRoyaltyFromCcidDetail @fileId;

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
		@fileId
		, 'TR'
		, isnull(count(*), 0) id_records
		, 0 dl_records
		, isnull(sum(amount_invoiced_total), 0) sum_amount_licensor
		, 0 sum_amount_copcon
		, 0 sum_amount_unmatched
from CcidInDetail
where fileId = @fileId

-- mark records as included into invoice
update t1
set t1.IncludedInCcid = @invoiceId
from IdentBacklog t1 
	inner join IdentMW t2 on t2.id = t1.mwid
where t1.DdexReportId = @ddexReportId
	and (t1.IncludedInCcid is null or t1.IncludedInCcid = @invoiceId)
	and (t2.[Status] = 1 or t2.[Status] = 2)

end
go

drop procedure if exists spCreateInitialInvoiceSubscr
go

create procedure spCreateInitialInvoiceSubscr @ddexReportId int, @fileId int
as
begin
/*
Данная процедура формирует данные для инвойса гуглу для отчетов типа подписка.
Поскольку все файлы инвойса (отосланные-принятые) объединяются под одной записью CcidInvoice
предусмотрено два режима. если @fileId - null, создается новая строка в CcidInvoice, и к ней
прикрепляются записи CcidInFile, CcidHeader, CcidDetail, CcidTrailer.
Если @fileId не null, то только переформировуются только строки таблиц CcidHeader, CcidDetail, CcidTrailer.
*/

declare @inInstanceIndex int;
declare @invoiceId int;

-- agreement parameters
declare @licId int
	, @custId int
	, @ddexReportingPeriodId int;
select @licId = licId
	, @custId = custId
	, @ddexReportingPeriodId = ddexReportingPeriodId
from DdexReport 
where id = @ddexReportId;

declare @year int, @quarter int;
select @year = year
	, @quarter = quarter 
from DdexReportingPeriod 
where id = @ddexReportingPeriodId

declare @month int = 3 * @quarter - 2;

/*
Информация извлекается из отчета
declare @exchRate float = (select exchRate 
	from CcidExchangeRate 
	where year = @year 
		and month = @month 
		and licId = @licId 
		and custId = @custId);
if @exchRate is null
begin
	raiserror('Відсутня інформація із договору, необхідна для розрахунків', 0, 0);
	return;
end
*/

/*
Проверка не нужна, поскольку обеспецивается наличие параметров о записи отчета
if exists (select 
	paramValue 
	from AgreementParam
	where paramId <=6
		and licId = @licId 
		and custId = @custId
		and paramValue is null
)
begin
	raiserror('Відсутня інформація із догвору, необхідна для розрахунків', 0, 0);
	return;
end
*/

-- get data from Ddex header record for the report
declare @RecipientName varchar(100)
	, @SenderName varchar(100)
	, @UsageStartDate date
	, @UsageEndDate date
select @RecipientName = RecipientName
	, @SenderName = SenderName
	, @UsageStartDate = UsageStartDate
	, @UsageEndDate = UsageEndDate
from DdexRecordHead
where DdexReportId = @ddexReportId

-- Get file type from DdexReport
declare @fileType as varchar(100) = (
			select fileType from DdexReport where Id = @ddexReportId
		)

-- ============ Calc base data
declare  @musicRate float 
	, @geRate float 
	, @mechSplit float 
	, @perfSplit float 
	, @totalRevSharePayable float 
	, @totalPSMPayable float 
	, @constantGrossRevenueValue float 
	, @constantPSMRoyaltyValue float 
	, @blendedRevshareRate float
exec spCreateCcidParamsForSubscr @ddexReportId
	, @musicRate  output
	, @geRate  output
	, @mechSplit  output
	, @perfSplit  output
	, @totalRevSharePayable  output
	, @totalPSMPayable  output
	, @constantGrossRevenueValue  output
	, @constantPSMRoyaltyValue  output
	, @blendedRevshareRate output

-- make sure ccid file is created
if @fileId is null
begin
	insert into CcidInvoice(ddexReportId, createdDate, [status], recordCount, netRevenueExcluded, netRevenueClaimed)
	values (@ddexReportId, getdate(), 0, null, null, null);
	select @invoiceId = SCOPE_IDENTITY();
end
else
begin
	select @invoiceId = ccidInvoiceId from CcidInFile where fileId = @fileId;
end


-- cleanup CCID records for invoice
if @fileId is not null
begin
	delete from CcidInDetail where fileId = @fileId
	delete from CcidInTrailer where fileId = @fileId
	delete from CcidInHeader where fileId = @fileId
end
else
begin
	insert into CcidInFile(ccidInvoiceId, InstanceIndex, Status, [Name], TargetFolder)
	values (@invoiceId, 1, 0, '', '');
	set @fileId = scope_identity();
end

-- Fill in header record
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
		@fileId
		, 'HD'
		, '14.1'
		, GetDate()
		, 'UACRR-CS'
		, 'Google'
		, cast(@fileId as varchar) -- ccid_id
		, 'UA'
		, @UsageStartDate
		, @UsageEndDate
		, 'USD'
		, 'USD'
		, 1.00000
		, null
		, null
		, 'IN'
		, 'SubscriptionModel' -- commercial_model
		, case when @fileType = 'Subscription-Music' then 'YouTubeMusic' else 'YouTubePremium' end -- service_description
		, 'Stream' -- use_type
		, @mechSplit * 100 -- mech_perc_split
		, @perfSplit * 100 -- perf_perc_split
		, cast(@musicRate * 100 as varchar) + '|' + cast(@geRate * 100 as varchar) -- aux
)

-- Create detail records

-- >> FIX: Изменение в связи с замечанием от гугла 2020.04.09 - Payment Computation Method Differs from Reports
-- Пока что всегда будем использовать процентовку, получим разъяснения - введем коррекции
--if @TotalRevSharePayable > @TotalPSMPayable
if @TotalRevSharePayable > @TotalPSMPayable or @TotalRevSharePayable <= @TotalPSMPayable
-- <<
begin
	insert into CcidInDetail (
			  fileId
			, record_type
			, transaction_type
			--, correction_reference
			, sales_transaction_id
			--, work_id
			, release_id
			, resource_id
			--, isrc
			--, iswc
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
			--, restrictions
			, claim_licensor_combined
			--, claim_copcon_combined
			, claim_unmatched_combined
			--, claim_pd_combined
			--, claim_not_collected_combined
			, amount_invoiced_total
			, claim_licensor_mech
			, claim_licensor_perf
			, amount_licensor_mech
			, amount_licensor_perf
			/*
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
			*/
	)
	select 
			  @fileId
			, 'ID'
			, 'ORI'
			, t1.salestransactionid sales_transaction_id
			, left(t1.dspreleaseid, 60) release_id
			, left(t1.dspreleaseid, 60) resource_id
			, left(case 
				when t3.Wic is null 
				then case
						when t4.[ObjId] is null
						then ''
						else 'ObjId:' + cast(t4.[ObjId] as varchar(100)) 
					end
				else 'Wic:' + cast(t3.Wic as varchar(100)) 
				end
			  , 39) workcode
			, left(case 
				when t3.Wic is null 
				then case
						when t4.[name] is null
						then ''
						else t4.[name] 
					end
				else t3.ttl 
				end
				, 60) work_title
			, t1.usages use_quantity
			, @BlendedRevshareRate applied_tariff
			, 'P' royalty_type
			, t1.Usages * @ConstantGrossRevenueValue revenue_basis
			, t1.Usages * @ConstantGrossRevenueValue original_release_revenue_basis
			, t1.Usages * @ConstantGrossRevenueValue original_resource_revenue_basis
-- >> FIX: Изменение в связи с замечанием от гугла 2020.04.09 - Decimal Placement Error
-- Похоже, что причина в другом - ненужное деление на t1.usages, документация от Гугл содержит неясности
-- Текущее понимание - royalty это то, что должны авторам в целом, amount_invoiced_total - та сумма, которая отдается нам
-- (меньше или равно royalty c учетом нашей рыночной доли)
			/*
			, case when t1.usages > 0 then 
				@BlendedRevshareRate
						* t1.Usages * @ConstantGrossRevenueValue  / t1.usages 
				else 0 
				end royalty
				*/
			, @BlendedRevshareRate	* t1.Usages * @ConstantGrossRevenueValue royalty
-- <<
			, 100 resource_share
			, (
					cast(t1.rateTotalMEC as float) * @mechSplit
					+  
					cast(t1.rateTotalPER as float) * @perfSplit
				) 
					as claim_licensor_combined
			, (case when t2.[status] = 1 then 100 else 0 end) claim_unmatched_combined
			, 0.01
				* (
					cast(t1.rateTotalMEC as float) * @mechSplit
					+  
					cast(t1.rateTotalPER as float) * @perfSplit
				)
				* @BlendedRevshareRate
				* t1.Usages * @ConstantGrossRevenueValue 
					as amount_invoiced_total
			, cast(t1.rateTotalMEC as float) claim_licensor_mech
			, cast(t1.rateTotalPER as float) claim_licensor_perf
			, 0.01
				* cast(t1.rateTotalMEC as float) * @mechSplit
				* @BlendedRevshareRate
				* t1.Usages * @ConstantGrossRevenueValue
					as amount_licensor_mech
			, 0.01
				* cast(t1.rateTotalPER as float) * @perfSplit
				* @BlendedRevshareRate
				* t1.Usages * @ConstantGrossRevenueValue
					as amount_licensor_perf
	from IdentBacklog t1 
		inner join IdentMW t2 on t2.id = t1.mwid
		left join WID_IPI.dbo.TblTitle t3 on t3.Wic = t2.Wic
		left join MediaService.dbo.ObjectRight t4 on t4.[ObjId] = t2.[ObjId]
	where t1.DdexReportId = @ddexReportId
		and (t1.IncludedInCcid is null or t1.IncludedInCcid = @invoiceId)
		and (t2.[Status] = 1 or t2.[Status] = 2)
end
else
begin
	insert into CcidInDetail (
			  fileId
			, record_type
			, transaction_type
			--, correction_reference
			, sales_transaction_id
			--, work_id
			, release_id
			, resource_id
			--, isrc
			--, iswc
			, workcode
			, work_title
			, use_quantity
			--, applied_tariff
			, royalty_type
			, revenue_basis
			, original_release_revenue_basis
			, original_resource_revenue_basis
			, royalty
			, resource_share
			--, restrictions
			, claim_licensor_combined
			--, claim_copcon_combined
			, claim_unmatched_combined
			--, claim_pd_combined
			--, claim_not_collected_combined
			, amount_invoiced_total
			, claim_licensor_mech
			, claim_licensor_perf
			, amount_licensor_mech
			, amount_licensor_perf
			/*
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
			*/
	)
	select 
			  @fileId
			, 'ID'
			, 'ORI'
			, t1.salestransactionid sales_transaction_id
			, left(t1.dspreleaseid, 60) release_id
			, left(t1.dspreleaseid, 60) resource_id
			, left(case 
				when t3.Wic is null 
				then case
						when t4.[ObjId] is null
						then ''
						else 'ObjId:' + cast(t4.[ObjId] as varchar(100)) 
					end
				else 'Wic:' + cast(t3.Wic as varchar(100)) 
				end
			  , 39) workcode
			, left(case 
				when t3.Wic is null 
				then case
						when t4.[name] is null
						then ''
						else t4.[name] 
					end
				else t3.ttl 
				end
				, 60) work_title
			, t1.usages use_quantity
			--, case when t1.ContentCategory = 'Music' then @musicRate else @geRate end applied_tariff
			, 'M' royalty_type
			, t1.Usages * @ConstantGrossRevenueValue revenue_basis
			, t1.Usages * @ConstantGrossRevenueValue original_release_revenue_basis
			, t1.Usages * @ConstantGrossRevenueValue original_resource_revenue_basis
			, @constantPSMRoyaltyValue royalty
			, 100 resource_share
			,  (
					cast(t1.rateTotalMEC as float) * @mechSplit
					+  
					cast(t1.rateTotalPER as float) * @perfSplit
				) 
					as claim_licensor_combined
			, (case when t2.[status] = 1 then 100 else 0 end) claim_unmatched_combined
			, 0.01 
				* 
				(
					cast(t1.rateTotalMEC as float) * @mechSplit
					+  
					cast(t1.rateTotalPER as float) * @perfSplit
				)
				*
				@constantPSMRoyaltyValue 
				*
				t1.Usages  
					as amount_invoiced_total
			, cast(t1.rateTotalMEC as float) claim_licensor_mech
			, cast(t1.rateTotalPER as float) claim_licensor_perf
			, 0.01 
				* 
				cast(t1.rateTotalMEC as float) * @mechSplit
				*
				@constantPSMRoyaltyValue 
				*
				t1.Usages 
					as amount_licensor_mech
			, 0.01 
				* 
				cast(t1.rateTotalPER as float) * @perfSplit
				*
				@constantPSMRoyaltyValue 
				*
				t1.Usages 
					as amount_licensor_perf
	from IdentBacklog t1 
		inner join IdentMW t2 on t2.id = t1.mwid
		left join WID_IPI.dbo.TblTitle t3 on t3.Wic = t2.Wic
		left join MediaService.dbo.ObjectRight t4 on t4.[ObjId] = t2.[ObjId]
	where t1.DdexReportId = @ddexReportId
		and (t1.IncludedInCcid is null or t1.IncludedInCcid = @invoiceId)
		and (t2.[Status] = 1 or t2.[Status] = 2)
end

-- Удаляем записи с малой прибылью
exec spRemoveLowRoyaltyFromCcidDetail @fileId;

-- insert trailer record
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
		@fileId
		, 'TR'
		, isnull(count(*), 0) id_records
		, 0 dl_records
		, isnull(sum(amount_invoiced_total), 0) sum_amount_licensor
		, 0 sum_amount_copcon
		, 0 sum_amount_unmatched
from CcidInDetail
where fileId = @fileId

-- mark records as included into invoice
update t1
set t1.IncludedInCcid = @invoiceId
from IdentBacklog t1 
	inner join IdentMW t2 on t2.id = t1.mwid
where t1.DdexReportId = @ddexReportId
	and (t1.IncludedInCcid is null or t1.IncludedInCcid = @invoiceId)
	and (t2.[Status] = 1 or t2.[Status] = 2)
end
go