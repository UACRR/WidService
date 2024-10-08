use MediaService
go

create or alter view  vWidWrkForWObjectAuthor
as
	select
		  t1.Wic as Wic
		, t1.Rolid as SeqNr
		, t2.IpBaseNr as IP_BASE_NR
		, format(t1.IpNameNr, 'd11') as IPINr
		, t2.Name as LstName
		, t2.FstName as FstName
		, t1.IpRole as IntrPtyRol
		, t1.sharePer as ratePER
		, t1.shareMec as rateMEC
 from vWidWrkSharesPerAuthor t1
	join SocIpi..IpiName t2 on t1.IpNameNr = t2.IpNameNr
go
