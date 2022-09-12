USE [DDEX]
GO

/****** Object:  StoredProcedure [dbo].[spUpdateIdentProgress]    Script Date: 12.09.2022 13:10:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER procedure [dbo].[spUpdateIdentProgress] @ddexReportId int
as
begin

declare @Id int;

select @Id = id 
from IdentProgress 
where ddexReportId in (select id from ft_AgreementReportIds(@ddexReportId))
	and UpdatedOn = cast(getdate() as date)

if @id is not null
begin
	delete from IdentProgressByBlock where IdentProgressId = @id
	delete from IdentProgress where Id = @id
end

;with stat as (
--declare @ddexReportId int = 5;
select 
	  @ddexReportId ddexReportId
	, getdate() UpdatedOn
	
	, sum(1) MwCntToProcess
	, sum(t2.NetRevenue) MwNetRevenueToProcess

	, sum(case when status = 0 then 1 else 0 end) MwCnt0
	, sum(case when status = 0 then t2.NetRevenue else 0 end) MwNetRevenue0

	, sum(case when status = 1 then 1 else 0 end) MwCnt1
	, sum(case when status = 1 then t2.NetRevenue else 0 end) MwNetRevenue1

	, sum(case when status = 2 then 1 else 0 end) MwCnt2
	, sum(case when status = 2 then t2.NetRevenue else 0 end) MwNetRevenue2
	
	, sum(case when status = 3 then 1 else 0 end) MwCnt3
	, sum(case when status = 3 then t2.NetRevenue else 0 end) MwNetRevenue3

	, sum(case when status = 10 then 1 else 0 end) MwCnt10
	, sum(case when status = 10 then t2.NetRevenue else 0 end) MwNetRevenue10

	, sum(case when status = 20 then 1 else 0 end) MwCnt20
	, sum(case when status = 20 then t2.NetRevenue else 0 end) MwNetRevenue20

	, sum(case when status = 21 then 1 else 0 end) MwCnt21
	, sum(case when status = 21 then t2.NetRevenue else 0 end) MwNetRevenue21

	, sum(case when status = 22 then 1 else 0 end) MwCnt22
	, sum(case when status = 22 then t2.NetRevenue else 0 end) MwNetRevenue22

	, sum(case when status = 30 then 1 else 0 end) MwCnt30
	, sum(case when status = 30 then t2.NetRevenue else 0 end) MwNetRevenue30

	, sum(case when status = 31 then 1 else 0 end) MwCnt31
	, sum(case when status = 31 then t2.NetRevenue else 0 end) MwNetRevenue31

	, sum(case when status = 32 then 1 else 0 end) MwCnt32
	, sum(case when status = 32 then t2.NetRevenue else 0 end) MwNetRevenue32

from IdentMw t1 
	join IdentReportMwRecords t2 on t1.Id = t2.mwId
where t2.ddexReportId in (select id from ft_AgreementReportIds(@ddexReportId))
	and t2.PriorityIndex is not null-- not (ISWC <> '' and status = 2)
)
insert IdentProgress(
	ddexReportId,
	UpdatedOn,
	MwCntToProcess,
	MwNetRevenueToProcess,
	MwCnt0,
	MwNetRevenue0,
	MwCnt1,
	MwNetRevenue1,
	MwCnt2,
	MwNetRevenue2,
	MwCnt3,
	MwNetRevenue3,
	MwCnt10,
	MwNetRevenue10,
	MwCnt20,
	MwNetRevenue20,
	MwCnt21,
	MwNetRevenue21,
	MwCnt22,
	MwNetRevenue22,
	MwCnt30,
	MwNetRevenue30,
	MwCnt31,
	MwNetRevenue31,
	MwCnt32,
	MwNetRevenue32)
select ddexReportId,
	UpdatedOn,
	MwCntToProcess,
	MwNetRevenueToProcess,
	MwCnt0,
	MwNetRevenue0,
	MwCnt1,
	MwNetRevenue1,
	MwCnt2,
	MwNetRevenue2,
	MwCnt3,
	MwNetRevenue3,
	MwCnt10,
	MwNetRevenue10,
	MwCnt20,
	MwNetRevenue20,
	MwCnt21,
	MwNetRevenue21,
	MwCnt22,
	MwNetRevenue22,
	MwCnt30,
	MwNetRevenue30,
	MwCnt31,
	MwNetRevenue31,
	MwCnt32,
	MwNetRevenue32
from stat;

set @Id = SCOPE_IDENTITY();

declare @blockCount int;
declare @curBlock int = 0;
declare @netRevenue decimal(20,6);
declare @status int = 0;

declare @MwCnt0 int = 0;
declare @MwNetRevenue0 decimal(20,6) = 0;

declare @MwCnt1 int = 0;
declare @MwNetRevenue1 decimal(20,6) = 0;

declare @MwCnt2 int = 0;
declare @MwNetRevenue2 decimal(20,6) = 0;
	
declare @MwCnt3 int = 0;
declare @MwNetRevenue3 decimal(20,6) = 0;

declare @MwCnt10 int = 0;
declare @MwNetRevenue10 decimal(20,6) = 0;

declare @MwCnt20 int = 0;
declare @MwNetRevenue20 decimal(20,6) = 0;

declare @MwCnt21 int = 0;
declare @MwNetRevenue21 decimal(20,6) = 0;

declare @MwCnt22 int = 0;
declare @MwNetRevenue22 decimal(20,6) = 0;

declare @MwCnt30 int = 0;
declare @MwNetRevenue30 decimal(20,6) = 0;

declare @MwCnt31 int = 0;
declare @MwNetRevenue31 decimal(20,6) = 0;

declare @MwCnt32 int = 0;
declare @MwNetRevenue32 decimal(20,6) = 0;

select @blockCount = count(*) - 1
from DdexNetRevenueDistr
where ddexReportId  in (select id from ft_AgreementReportIds(@ddexReportId))


DECLARE cMwRecors CURSOR 
LOCAL STATIC READ_ONLY FORWARD_ONLY
FOR     
select t2.NetRevenue, t1.Status
from IdentMw t1 join IdentReportMwRecords t2 on t1.Id = t2.mwId
where t2.ddexReportId in (select id from ft_AgreementReportIds(@ddexReportId))
	and t2.PriorityIndex is not null
order by t2.PriorityIndex
 
OPEN cMwRecors    
  
FETCH NEXT FROM cMwRecors INTO @netRevenue, @status;

declare @blockRecCount int = 0;
  
WHILE @@FETCH_STATUS = 0 and @curBlock < @blockCount
BEGIN    
    set @blockRecCount = @blockRecCount + 1;
	set @MwCnt0  = @MwCnt0 + case when @status = 0 then 1 else 0 end;
	set @MwNetRevenue0 = @MwNetRevenue0 + case when @status = 0 then @NetRevenue else 0 end;

	set @MwCnt1  = @MwCnt1 + case when @status = 1 then 1 else 0 end 
	set @MwNetRevenue1 = @MwNetRevenue1 + case when @status = 1 then @NetRevenue else 0 end 

	set @MwCnt2 = @MwCnt2 + case when @status = 2 then 1 else 0 end 
	set @MwNetRevenue2 = @MwNetRevenue2 + case when @status = 2 then @NetRevenue else 0 end 

	set @MwCnt3 = @MwCnt3 + case when @status = 3 then 1 else 0 end 
	set @MwNetRevenue3 = @MwNetRevenue3 + case when @status = 3 then @NetRevenue else 0 end 

	set @MwCnt10 = @MwCnt10 + case when @status = 10 then 1 else 0 end 
	set @MwNetRevenue10 = @MwNetRevenue10 + case when @status = 10 then @NetRevenue else 0 end 

	set @MwCnt20 = @MwCnt20 + case when @status = 20 then 1 else 0 end 
	set @MwNetRevenue20 = @MwNetRevenue20 + case when @status = 20 then @NetRevenue else 0 end 

	set @MwCnt21 = @MwCnt21 + case when @status = 21 then 1 else 0 end 
	set @MwNetRevenue21 = @MwNetRevenue21 + case when @status = 21 then @NetRevenue else 0 end 

	set @MwCnt22 = @MwCnt22 + case when @status = 22 then 1 else 0 end 
	set @MwNetRevenue22 = @MwNetRevenue22 + case when @status = 22 then @NetRevenue else 0 end 

	set @MwCnt30 = @MwCnt30 + case when @status = 30 then 1 else 0 end 
	set @MwNetRevenue30 = @MwNetRevenue30 + case when @status = 30 then @NetRevenue else 0 end 

	set @MwCnt31 = @MwCnt31 + case when @status = 31 then 1 else 0 end 
	set @MwNetRevenue31 = @MwNetRevenue31 + case when @status = 31 then @NetRevenue else 0 end 

	set @MwCnt32 = @MwCnt32 + case when @status = 32 then 1 else 0 end 
	set @MwNetRevenue32 = @MwNetRevenue32 + case when @status = 32 then @NetRevenue else 0 end 

	if @blockRecCount = 1000
	begin
		insert IdentProgressByBlock
		select
		@Id
		, @curBlock * 1000 + 1
		, @curBlock * 1000 + 1000
		, @MwCnt0, @MwNetRevenue0
		, @MwCnt1, @MwNetRevenue1
		, @MwCnt2, @MwNetRevenue2
		, @MwCnt3, @MwNetRevenue3
		, @MwCnt10, @MwNetRevenue10
		, @MwCnt20, @MwNetRevenue20
		, @MwCnt21, @MwNetRevenue21
		, @MwCnt22, @MwNetRevenue22
		, @MwCnt30, @MwNetRevenue30
		, @MwCnt31, @MwNetRevenue31
		, @MwCnt32, @MwNetRevenue32

		set @MwCnt0  = 0;
		set @MwNetRevenue0  = 0;

		set @MwCnt1  = 0;
		set @MwNetRevenue1  = 0;

		set @MwCnt2  = 0;
		set @MwNetRevenue2  = 0;
	
		set @MwCnt3  = 0;
		set @MwNetRevenue3  = 0;

		set @MwCnt10  = 0;
		set @MwNetRevenue10  = 0;

		set @MwCnt20  = 0;
		set @MwNetRevenue20  = 0;

		set @MwCnt21  = 0;
		set @MwNetRevenue21  = 0;

		set @MwCnt22  = 0;
		set @MwNetRevenue22  = 0;

		set @MwCnt30  = 0;
		set @MwNetRevenue30  = 0;

		set @MwCnt31  = 0;
		set @MwNetRevenue31  = 0;

		set @MwCnt32  = 0;
		set @MwNetRevenue32  = 0;


		set @blockRecCount = 0;
		set @curBlock = @curBlock + 1;
	end
	FETCH NEXT FROM cMwRecors INTO @netRevenue, @status;

END     
CLOSE cMwRecors;    
DEALLOCATE cMwRecors;  

end
GO

