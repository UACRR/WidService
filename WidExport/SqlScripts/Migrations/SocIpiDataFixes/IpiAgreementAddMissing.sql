use SocIpi
go

drop table if exists #NewRecs

select
	  concat(t1.IpBaseNr, '-', t2.SocCde, '-', t2.CreClsCde, '-', t2.RolCde, '-', t2.RgtCde) as IpAgreeNr
	, t1.IpBaseNr 
	, t2.SocCde    
	, t2.CreClsCde
	, t2.RolCde
	, t2.RgtCde
	, (case when t2.ValidFromD < '19000101' then '19000101' else t2.ValidFromD end) as ValidFromD
	, t2.ValidFromT
	, t2.ValidToD
	, t2.ValidToT
	, (case when t2.SignD < '19000101' then '19000101' else t2.SignD end) as SignD
	, t2.Shr
	, t2.AmdD
	, t2.AmdT
	, 0 as IsDeleted
	, t1.UpdFileId
	, t1.GrId
	, t2.TransSeqNr
	, t2.RecSeqNr
into #NewRecs
from UpdTrans t1
	join RecMan t2 on t1.UpdFileId = t2.UpdFileId
		and t1.GrId = t2.GrId
		and t1.TransSeqNr = t2.TransSeqNr
	left join IpiAgreement t3 on 
			t1.IpBaseNr			= t3.IpBaseNr 
        and t2.SocCde			= t3.SocCde
        and t2.CreClsCde		= t3.CreClsCde 
        and t2.RolCde			= t3.RolCde 
        and t2.RgtCde			= t3.RgtCde 
        and (case when t2.ValidFromD < '19000101' then '19000101' else t2.ValidFromD end) = convert(varchar, cast(t3.FromDt as date), 112)
        and (case when t2.ValidToD < '19000101' then '19000101' else t2.ValidToD end) = convert(varchar, cast(t3.ToDt as date), 112)
where t1.RecType = 'MAA'
	and t3.Id is null

drop table if exists #AffectedMaa
select distinct UpdFileId, GrId, TransSeqNr, IpBaseNr
into #AffectedMaa
from #NewRecs

drop table if exists #NewManGrouped
select
	  row_number() over(partition by t2.UpdFileId, t2.GrId, t2.TransSeqNr order by t2.RecSeqNr) as SeqNr
	, t2.UpdFileId
	, t2.GrId
	, t2.TransSeqNr
	, cast(t2.RecSeqNr as int) as RecSeqNr
	, 1000000 as NextRecSqNr
	, t1.IpBaseNr
into #NewManGrouped
from #AffectedMaa t1
	join RecMan t2 on t1.UpdFileId = t2.UpdFileId
		and t1.GrId = t2.GrId
		and t1.TransSeqNr = t2.TransSeqNr

update t1
set t1.NextRecSqNr = t2.RecSeqNr
from #NewManGrouped t1
	join #NewManGrouped t2 on t1.UpdFileId = t2.UpdFileId
		and t1.GrId = t2.GrId
		and t1.TransSeqNr = t2.TransSeqNr
		and t1.SeqNr + 1 = t2.SeqNr

drop table if exists #AffectedTma
select 
	  t1.UpdFileId
	, t1.GrId
	, t1.TransSeqNr
	, t1.RecSeqNr as ManRecSeqNr
	, t2.TisNr
	, (case when t2.TisNrValidFrom < '19000101' then '19000101' else t2.TisNrValidFrom end) as TisNrValidFrom
	, t2.Tisan
	, (case when t2.TisanValidFrom < '19000101' then '19000101' else t2.TisanValidFrom end) as TisanValidFrom
	, t2.IncExcInd
	, t1.IpBaseNr
into #AffectedTma
from #NewManGrouped t1
	join RecTma t2 on t1.UpdFileId = t2.UpdFileId
		and t1.GrId = t2.GrId
		and t1.TransSeqNr = t2.TransSeqNr
		and t2.RecSeqNr between t1.RecSeqNr + 1 and t1.NextRecSqNr - 1

begin try
	begin tran
	
	insert IpiAgreement(
			  IpAgreeNr
			, IpBaseNr 
			, SocCde
			, CreClsCde
			, RolCde
			, RgtCde
			, FromDt
			, ToDt
			, SignD
			, Shr
			, AmdDt
			, IsDeleted
	)

	select
			  IpAgreeNr
			, IpBaseNr 
			, SocCde    
			, CreClsCde
			, RolCde
			, RgtCde
			, datetimefromparts(
				  substring(ValidFromD, 1, 4)
				, substring(ValidFromD, 5, 2)
				, substring(ValidFromD, 7, 2)
				, substring(ValidFromT, 1, 2)
				, substring(ValidFromT, 3, 2)
				, substring(ValidFromT, 5, 2)
				, 0
			  )
			, datetimefromparts(
				  substring(ValidToD, 1, 4)
				, substring(ValidToD, 5, 2)
				, substring(ValidToD, 7, 2)
				, substring(ValidToT, 1, 2)
				, substring(ValidToT, 3, 2)
				, substring(ValidToT, 5, 2)
				, 0
			  )
			, datefromparts(
				  substring(SignD, 1, 4)
				, substring(SignD, 5, 2)
				, substring(SignD, 7, 2)
			  )
			, cast(Shr as int) * 0.01
			, datetimefromparts(
				  substring(AmdD, 1, 4)
				, substring(AmdD, 5, 2)
				, substring(AmdD, 7, 2)
				, substring(AmdT, 1, 2)
				, substring(AmdT, 3, 2)
				, substring(AmdT, 5, 2)
				, 0
			  )
			, 0
	from #NewRecs -- Order by IpAgreeNr

	insert IpiTerritory(
			  IpAgreeNr
			, TisNr 
			, TisNrFromD
			, Tisan
			, TisanFromD
			, IncExcInd
	)
	select 
		  concat(t1.IpBaseNr, '-', t2.SocCde, '-', t2.CreClsCde, '-', t2.RolCde, '-', t2.RgtCde) as IpAgreeNr
		, t1.TisNr
		, datefromparts(
				  substring(TisNrValidFrom, 1, 4)
				, substring(TisNrValidFrom, 5, 2)
				, substring(TisNrValidFrom, 7, 2)
			  )
		, t1.Tisan
		, datefromparts(
				  substring(TisanValidFrom, 1, 4)
				, substring(TisanValidFrom, 5, 2)
				, substring(TisanValidFrom, 7, 2)
			  )
		, t1.IncExcInd
	from #AffectedTma t1
		join RecMan t2 on t1.UpdFileId = t2.UpdFileId
			and t1.GrId = t2.GrId
			and t1.TransSeqNr = t2.TransSeqNr
			and t2.RecSeqNr = t1.ManRecSeqNr
	order by t1.UpdFileId, t1.GrId, t1.TransSeqNr, t1.ManRecSeqNr

	commit tran
end try
begin catch
	rollback tran
end catch
