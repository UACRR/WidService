  declare @minDate datetime = datefromparts(1900, 01, 01)
  declare @maxDate datetime = datefromparts(9999, 12, 31)
  declare @fileDate datetime = datefromparts(2022, 5, 26)
  declare @entityName varchar(100) = 'RecAlt'
  
  drop table if exists #recordsToAddToHistory;

  select t2.Id, t2.Wic, t2.SeqNr, t2.AltTtl, t2.LngCode, t2.TtlType
  into #recordsToAddToHistory
  from SocWidUpdates..WrkAffectedRecords t1
	join SocWid.. widAltTtl t2 on t1.Wic = t2.Wic
	left join SocWid.. widAltTtlHist t3 on t2.Id = t3.Id
  where t1.EntityName = @entityName
	and t3.Id is null

insert #recordsToAddToHistory(Id, Wic, SeqNr, AltTtl, LngCode, TtlType)
select t2.Id, t2.Wic, t2.SeqNr, t2.AltTtl, t2.LngCode, t2.TtlType
from SocWidUpdates..WrkAffectedRecords t1
	join SocWid.. widAltTtl t2 on t1.Wic = t2.Wic
	join SocWid.. widAltTtlHist t3 on t2.Id = t3.Id
where t1.EntityName = @entityName
	and t3.ValidTo = @maxDate
	and (t2.SeqNr <> t3.SeqNr or t2.AltTtl <> t3.AltTtl or t2.LngCode <> t3.LngCode or t2.TtlType <> t3.TtlType)

update t2
set t2.ValidTo = @fileDate
from #recordsToAddToHistory t1
	join SocWid.. widAltTtlHist t2 on t1.Id = t2.Id
where t2.ValidTo = @maxDate

insert SocWid.. widAltTtlHist(Id, ValidFrom, ValidTo, Wic, SeqNr, AltTtl, LngCode, TtlType)
select Id, @fileDate, @maxDate, Wic, SeqNr, AltTtl, LngCode, TtlType
from #recordsToAddToHistory

drop table if exists #recordsToAddToHistory;

delete SocWidUpdates..WrkAffectedRecords where EntityName = @entityName