use ShareCalc
go

create or alter procedure spProcessIpiAgreementsAll
as

begin try
	truncate table AgreeTerrIpi
	insert AgreeTerrIpi
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

	truncate table AgreeIpi
	insert into AgreeIpi
	select t1.Id, t1.IpBaseNr, t1.SocCde, t1.RgtCde, t1.RolCde, t2.Terr, MediaService.dbo.ClrIsUkraine(t2.Terr) as IsUkraine
	from SocIpi..IpiAgreement t1
		join ShareCalc..AgreeTerrIpi t2 on t1.IpAgreeNr = t2.IpAgreeNr

	truncate table AgreeRhIpiForUkr
	insert AgreeRhIpiForUkr
	select distinct IpBaseNr
	from ShareCalc..AgreeIpi
	where IsUkraine = 1
		and SocCde <> 94

	truncate table AgreeRhIpiForRao
	insert AgreeRhIpiForRao
	select distinct IpBaseNr
	from ShareCalc..AgreeIpi
	where SocCde = 94

	truncate table AgreeRhIpiLessUkr
	insert AgreeRhIpiLessUkr
	select distinct IpBaseNr
	from ShareCalc..AgreeIpi
	where IsUkraine = 0

	truncate table AgreeRhUacrr
	insert AgreeRhUacrr
	select distinct trim(t1.InterCode) as IpBaseNr
	from MediaService..RightHolder t1
		join MediaService..AgreementAddRh t2 on t1.CustId = t2.CustId
			and t2.AgrStatus = 2
			and getdate() between t2.DateBegin and t2.DateEnd
	where isnull(t1.InterCode, '') <> ''

	-- truncate table AgreeRhExtra
	-- insert AgreeRhExtra
	-- select t1.IpBaseNr as IpBaseNr
	-- from ShareCalc..AgreeRhIpiForRao t1
	-- 	left join ShareCalc..AgreeRhIpiForUkr t2 on t1.IpBaseNr = t2.IpBaseNr
	-- where t2.IpBaseNr is null

	truncate table AgreeRhExtra
	insert AgreeRhExtra
	select t1.IpBaseNr as IpBaseNr
	from ShareCalc..AgreeRhIpiLessUkr t1
	union
	select t1.IpBaseNr as IpBaseNr
	from ShareCalc..AgreeRhIpiForRao t1
		left join ShareCalc..AgreeRhIpiForUkr t2 on t1.IpBaseNr = t2.IpBaseNr
	where t2.IpBaseNr is null

	update IpiLastProcessedFile set Name = format(getdate(), 'yyyyMMdd')

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

-- exec spProcessIpiAgreementsAll
-- select * from AgreeRhExtra

