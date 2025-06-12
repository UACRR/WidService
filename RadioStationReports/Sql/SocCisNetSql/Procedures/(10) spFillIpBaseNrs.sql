use SocCisNet
go

create or alter procedure spFillIpBaseNrs
as
begin
	update t1
	set t1.IpBaseNr = t2.IpBaseNr
	--select *
	from WorkRightHolders t1
		left join SocIpi..IpiName t2 on t1.IpNameNr = t2.IpNameNr
	where isnull(t1.IpBaseNr, '') = ''
end
