use SocIpiEx
go

create or alter procedure spUpdateAll
as

begin try

-- 
	truncate table AgreeTerrs
	insert AgreeTerrs
	select t1.IpAgreeNr
		, t1.IpBaseNr
		, string_agg(concat(t2.IncExcInd, t2.TisNr), ' ') within group (order by t2.IncExcInd desc, t2.TisNr) as Terr
	from SocIpi..IpiAgreement t1
		join SocIpi..IpiTerritory t2 on t1.IpAgreeNr = t2.IpAgreeNr
		join SocIpi..IpiStatus t3 on t1.IpBaseNr = t3.IpBaseNr
			and t3.SttCde in (1, 2)
			and t3.FromDt <= getdate()
	where getdate() between t1.FromDt and t1.ToDt
		and t1.CreClsCde = 'MW'
		and t1.RgtCde in ('PR', 'MR')
		and t1.RolCde in ('LY', 'MC', 'EM')
	group by t1.IpAgreeNr, t1.IpBaseNr

	truncate table Agree
	insert into Agree
	select t1.Id, t1.IpBaseNr, t1.SocCde, t1.RgtCde, t1.RolCde, t2.Terr, MediaService.dbo.ClrIsUkraine(t2.Terr) as IsUkraine
	from SocIpi..IpiAgreement t1
		join AgreeTerrs t2 on t1.IpAgreeNr = t2.IpAgreeNr

	truncate table RhUkr
	insert RhUkr
	select distinct IpBaseNr
	from Agree
	where IsUkraine = 1
		and SocCde <> 94

	truncate table RhRao
	insert RhRao
	select distinct IpBaseNr
	from Agree
	where SocCde = 94

	truncate table RhNoUkr
	insert RhNoUkr
	select distinct IpBaseNr
	from Agree
	where IsUkraine = 0
		or SocCde = 94

	truncate table RhExtraPay
	insert RhExtraPay
	select t1.IpBaseNr as IpBaseNr
	from RhNoUkr t1

	update LastProcessedUpdateFile set Name = format(getdate(), 'yyyyMMdd')

end try
begin catch
	return
end catch
--select * from AgreeRhIpiLessUkr

-- CIS                 	2118
-- EASTERN EUROPE      	2119
-- EUROPE              	2120
-- EUROPEAN CONT.      	2122
-- WORLD               	2136
-- UKRAINE				0804

go

-- exec spUpdateAll
-- select * from AgreeRhExtra

