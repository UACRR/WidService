use MediaService
go

create or alter view  vWidWrkAuthorNames
as
	select
		  t1.Wic as Wic
		, t2.Name as LstName
		, t2.FstName as FstName
		, t1.IpRole as IpRole
 from SocWid..widIntrPty t1
	join SocIpi..IpiName t2 on t1.IpNameNr = t2.IpNameNr
go
