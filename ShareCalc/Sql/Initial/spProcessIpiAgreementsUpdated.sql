use ShareCalc
go

create or alter procedure spProcessIpiAgreementsUpdated
as
begin try
	declare @from char(8) = (select Name from IpiLastProcessedFile)
	declare @to char(8) = (select max(name) from SocIpi..UpdFiles where Name <> 'DOMAINS')

	drop table if exists #UpdatedRh
	select distinct t1.IpBaseNr
	into #UpdatedRh
	from SocIpi..UpdTrans t1
		join SocIpi..UpdFiles t2 on t1.UpdFileId = t2.Id
	where t2.Name <> 'DOMAINS'
		and t2.Name > @from

	if (select count(*) from #UpdatedRh) = 0
		return;

	-- >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> AgreeTerrIpi
	delete t2
	--select *
	from #UpdatedRh t1
		join AgreeTerrIpi t2 on t1.IpBaseNr = t2.IpBaseNr

	insert AgreeTerrIpi
	select t1.IpAgreeNr
		, t1.IpBaseNr
		, string_agg(concat(t2.IncExcInd, t2.TisNr), ' ') within group (order by t2.IncExcInd desc, t2.TisNr) as Terr
	from SocIpi..IpiAgreement t1
		join SocIpi..IpiTerritory t2 on t1.IpAgreeNr = t2.IpAgreeNr
		join SocIpi..IpiStatus t3 on t1.IpBaseNr = t3.IpBaseNr
			and t3.SttCde in (1, 2)
			and t3.FromDt <= getdate()
		join #UpdatedRh t4 on t1.IpBaseNr = t4.IpBaseNr
	where getdate() between t1.FromDt and t1.ToDt
		and t1.CreClsCde = 'MW'
		and t1.RgtCde in ('PR', 'MR')
		and t1.RolCde in ('LY', 'MC', 'EM')
	group by t1.IpAgreeNr, t1.IpBaseNr

	-- >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> AgreeIpi
	delete t2
	--select *
	from #UpdatedRh t1
		join AgreeIpi t2 on t1.IpBaseNr = t2.IpBaseNr

	insert into AgreeIpi
	select t1.Id, t1.IpBaseNr, t1.SocCde, t1.RgtCde, t1.RolCde, t2.Terr, MediaService.dbo.ClrIsUkraine(t2.Terr) as IsUkraine
	from SocIpi..IpiAgreement t1
		join ShareCalc..AgreeTerrIpi t2 on t1.IpAgreeNr = t2.IpAgreeNr
		join #UpdatedRh t3 on t1.IpBaseNr = t3.IpBaseNr

	-- >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> REDUNDANTS
	delete t2
	from #UpdatedRh t1
		join AgreeRhIpiForUkr t2 on t1.IpBaseNr = t2.IpBaseNr
	insert AgreeRhIpiForUkr
	select distinct t1.IpBaseNr
	from ShareCalc..AgreeIpi t1
		join #UpdatedRh t2 on t1.IpBaseNr = t2.IpBaseNr
	where IsUkraine = 1
		and SocCde <> 94

	delete t2
	from #UpdatedRh t1
		join AgreeRhIpiForRao t2 on t1.IpBaseNr = t2.IpBaseNr
	insert AgreeRhIpiForRao
	select distinct t1.IpBaseNr
	from ShareCalc..AgreeIpi t1
		join #UpdatedRh t2 on t1.IpBaseNr = t2.IpBaseNr
	where SocCde = 94

	delete t2
	from #UpdatedRh t1
		join AgreeRhIpiLessUkr t2 on t1.IpBaseNr = t2.IpBaseNr
	insert AgreeRhIpiLessUkr
	select distinct t1.IpBaseNr
	from ShareCalc..AgreeIpi t1
		join #UpdatedRh t2 on t1.IpBaseNr = t2.IpBaseNr
	where IsUkraine = 0

	delete t2
	from #UpdatedRh t1
		join AgreeRhUacrr t2 on t1.IpBaseNr = t2.IpBaseNr
	insert AgreeRhUacrr
	select distinct trim(t1.InterCode) as IpBaseNr
	from MediaService..RightHolder t1
		join MediaService..AgreementAddRh t2 on t1.CustId = t2.CustId
			and t2.AgrStatus = 2
			and getdate() between t2.DateBegin and t2.DateEnd
		join #UpdatedRh t3 on trim(t1.InterCode) = t3.IpBaseNr
	where isnull(t1.InterCode, '') <> ''

	delete t2
	from #UpdatedRh t1
		join AgreeRhExtra t2 on t1.IpBaseNr = t2.IpBaseNr
	insert AgreeRhExtra
	select t1.IpBaseNr as IpBaseNr
	from ShareCalc..AgreeRhIpiLessUkr t1
		join #UpdatedRh t2 on t1.IpBaseNr = t2.IpBaseNr
	union
	select t1.IpBaseNr as IpBaseNr
	from ShareCalc..AgreeRhIpiForRao t1
		join #UpdatedRh t2 on t1.IpBaseNr = t2.IpBaseNr
		left join ShareCalc..AgreeRhIpiForUkr t3 on t1.IpBaseNr = t2.IpBaseNr
	where t2.IpBaseNr is null


	update IpiLastProcessedFile set Name = @to
end try
begin catch
	return
end catch
--select * from IpiLastProcessedFile

-- CIS                 	2118
-- EASTERN EUROPE      	2119
-- EUROPE              	2120
-- EUROPEAN CONT.      	2122
-- WORLD               	2136
-- UKRAINE				0804

go

-- exec spProcessIpiAgreements

