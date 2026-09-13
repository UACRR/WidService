use ShareCalc
go

create or alter procedure spImportExceptions
as
begin

delete from ExcSocPer
delete from ExcSocMec
delete from ExcRhPer
delete from ExcRhMec
delete from ExcSocAdv
delete from ExcSet

-- ExcSet >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
insert ExcSet(Name, Dsc, SrcId)
select left(SetName, 64), SetComment, SetCode
from Ddex..ExceptionSet

-- ExcSocPub >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
insert ExcSocPer(ExcSetId, SocCde, SrcId)
select t1.Id, t3.InterCode, t3.Id
from ExcSet t1
	join Ddex..ExceptionSet t2 on t1.SrcId = t2.SetCode
	join Ddex..ExceptionMember t3 on t2.SetCode = t3.SetCode
		and t3.ExcType = 1
		and t3.ForPer = 1

-- ExcSocMec >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
insert ExcSocMec(ExcSetId, SocCde, SrcId)
select t1.Id, t3.InterCode, t3.Id
from ExcSet t1
	join Ddex..ExceptionSet t2 on t1.SrcId = t2.SetCode
	join Ddex..ExceptionMember t3 on t2.SetCode = t3.SetCode
		and t3.ExcType = 1
		and t3.ForMec = 1

-- ExcRhPer >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
insert ExcRhPer(ExcSetId, IpNameNr, SrcId)
select t1.Id, t3.IPInr, t3.Id
from ExcSet t1
	join Ddex..ExceptionSet t2 on t1.SrcId = t2.SetCode
	join Ddex..ExceptionMember t3 on t2.SetCode = t3.SetCode
		and t3.ExcType in (2, 3)
		and t3.ForPer = 1

-- ExcRhMec >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
insert ExcRhMec(ExcSetId, IpNameNr, SrcId)
select t1.Id, t3.IPInr, t3.Id
from ExcSet t1
	join Ddex..ExceptionSet t2 on t1.SrcId = t2.SetCode
	join Ddex..ExceptionMember t3 on t2.SetCode = t3.SetCode
		and t3.ExcType in (2, 3)
		and t3.ForMec = 1

-- ExcSocAdv >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
insert ExcSocAdv(ExcSetId, RhIpBaseNr, SocCde, SrcId)
select t1.Id, t3.InterCode, t4.InterCode, t3.Id
from ExcSet t1
	join Ddex..ExceptionSet t2 on t1.SrcId = t2.SetCode
	join Ddex..ExceptionMember t3 on t2.SetCode = t3.SetCode
		and t3.ExcType = 3
	join Ddex..ExceptionAdd t4 on t3.Id = t4.ExcId

end
go

-- exec spImportExceptions