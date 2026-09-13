use ShareCalc
go

create or alter view vRhIpiForRao
as
	select t2.IpBaseNr, trim(concat(t2.Name, ' ', t2.FstName)) as Name
	from AgreeRhIpiForRao t1
		join SocIpi..IpiName t2 on t1.IpBaseNr = t2.IpBaseNr
			and t2.NameType = 'PA'
go

-- select * from vRhIpiForRao order by Name