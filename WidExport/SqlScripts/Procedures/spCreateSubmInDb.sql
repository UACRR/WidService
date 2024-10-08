use SocWidSubmit
go

create or alter procedure spCreateSubmInDb
	@groupId int
as
begin
	declare @StatusAccepted int = 3
	
	-- Вхідна інформація, повязання за ObjId
	
	-- WORKS
	drop table if exists #Works
	select 
		  t1.ObjId
		, t2.WidName
	into #Works
	from WidSubmGroupWork t1
		join WidSubmGroupWorkName t2 on t1.WidSubmGroupId = t2.WidSubmGroupId
			and t1.ObjId = t2.ObjId
			and t2.IsMain = 1
	where t1.WidSubmGroupId = @groupId
		and t1.Status = @StatusAccepted

	-- SHARES
	drop table if exists #Shares
	select 
		  t1.ObjId
		, t2.CustId
		, t2.IpNameNr
		, t2.RhType
		, t2.RhRole
		, PerShr
		, MecShr
	into #Shares
	from #Works t1
		join WidSubmGroupWorkShare t2 on t1.ObjId = t2.ObjId
	where t2.WidSubmGroupId = @groupId


	-- Спочатку заповнюємо інформацією тимчасові таблиці, для цього створюємо їх на основі схеми постійних таблиць
	drop table if exists #RecHdr; select * into #RecHdr from RecHdr where Id = 0;
	drop table if exists #RecGrh; select * into #RecGrh from RecGrh where Id = 0;
	drop table if exists #RecWia; select * into #RecWia from RecWia where Id = 0;
	drop table if exists #RecSip; select * into #RecSip from RecSip where Id = 0;
	drop table if exists #RecSsr; select * into #RecSsr from RecSsr where Id = 0;
	drop table if exists #RecOip; select * into #RecOip from RecOip where Id = 0;
	drop table if exists #RecOsr; select * into #RecOsr from RecOsr where Id = 0;
	drop table if exists #RecAlt; select * into #RecAlt from RecAlt where Id = 0;
	drop table if exists #RecPer; select * into #RecPer from RecPer where Id = 0;
	drop table if exists #RecGrt; select * into #RecGrt from RecGrt where Id = 0;
	drop table if exists #RecTrl; select * into #RecTrl from RecTrl where Id = 0;

	-- В тимчасових таблицях посилання на SubmFile буде 0

	-- HDR
	insert #RecHdr (
		  Id
		, SubmFileId
		, RecType		
		, SenderType
		, SenderId	
		, SenderName
		, StdVerNr	
		, CreD		
		, CreT		
		, TransmitD
	)
	select
		  0								as Id
		, 0								as SubmFileId
		, 'HDR'							as RecType		
		, 'SO'							as SenderType
		, '000000140'					as SenderId	
		, 'UACRR'						as SenderName
		, '02.10'						as StdVerNr	
		, format(getdate(), 'yyyyMMdd') as CreD		
		, format(getdate(), 'hhmmss')	as CreT		
		, format(getdate(), 'yyyyMMdd')	as TransmitD
	
	-- GRH
	insert #RecGrh (
		  Id
		, SubmFileId
        , RecType		
        , TransType
        , GrId		
        , VerNr		
	)
	select
		  0 as Id
		, 0 as SubmFileId	
		, 'GRH' as RecType		
		, 'WIA' as TransType	
		, '0' as GrId		
		, '01.30' as VerNr		

	-- WIA
	

end
go

--select format(getdate(), 'hhmmss')

-- exec spIpiPartySelect 'KHARCHYSH'
