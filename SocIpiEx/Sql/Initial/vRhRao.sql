use SocIpiEx
go

create or alter view vRhRao
as
select t2.IpBaseNr, t2.Name, t2.FstName
from RhNoUkr t1
	join SocIpi..IpiName t2 on t1.IpBaseNr = t2.IpBaseNr
		and t2.NameType = 'PA'
go

-- select * from vRhNoUkr where Name = 'SHAMO'
