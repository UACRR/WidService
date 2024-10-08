use SocWidSubmit
go

create or alter procedure spSelectDataForSipAndOip
	  @groupId int
	, @objId int
as
begin
	select
		  t1.Id										as Id
		, t1.custId									as IpNr
		, t1.IpNameNr								as IpNameNr
		, t2.Name									as IpName
		, t2.FstName								as IpFstName
		, case 
			when t1.RhType = 1 then
				case
					when t1.RhRole = 1 then 'A'
					when t1.RhRole = 2 then 'C'
					when t1.RhRole = 5 then 'A'
					when t1.RhRole = 6 then 'A'
					when t1.RhRole = 7 then 'C'
					when t1.RhRole = 10 then 'CA'
					else ''
				end
			when t1.RhType = 3 and (t1.RhRole = 8 or t1.RhRole = 9) then 'E'
			else ''
		  end										as IpRole
		, t1.AggrLocal								as HasAgreement
		, t1.PerShr									as PerShr
		, t1.MecShr									as MecShr
	from WidSubmGroupWorkShare t1
		join SocIpi..IpiName t2 on t1.IpNameNr = t2.IpNameNr
	where t1.WidSubmGroupId = @groupId
		and t1.ObjId = @objId
end
go

-- exec spSelectDataForSipAndOip 3, 10318
