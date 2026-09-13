use ShareCalc
go

create or alter procedure spCalcReportExtras
as
-- !!! Перед виконанням процедури слід заповнити таблиці Z_ReportObjIds і Z_ReportWics даними із потрібного репорту
begin
	drop table if exists #ExtraMsShares
	drop table if exists #ExtraWidSharesPer
	drop table if exists #ExtraWidSharesMec
	drop table if exists #ExtraWidShares

	select t2.ObjId, t2.CustId, t3.InterCode as IpBaseNr, t2.Rate as PerShr, t2.RateMech as MecShr
	into #ExtraMsShares
	from Z_ReportObjIds t1
		join MediaService..CopyRight t2 on t1.ObjId = t2.ObjId
		join MediaService..RightHolder t3 on t2.CustId = t3.CustId
		join SocIpiEx..RhExtraPay t4 on t3.InterCode = t4.IpBaseNr
	where getdate() between t2.BeginDate and t2.EndDate

	drop table if exists #ExtraWidSharesPer
	select t2.Wic, t4.IpBaseNr, sum(t3.Shares) as Shares
	into #ExtraWidSharesPer
	from Z_ReportWics t1
		join SocWid..WidIntrPty t2 on t1.Wic = t2.Wic
			join SocWid..widShares t3 on t2.Wic = t3.Wic
				and t2.RolId = t3.IntrPtyRolid
				and t3.RightType = 'PER'
		join SocIpi..IpiName t4 on t2.IpNameNr = t4.IpNameNr
		join SocIpiEx..RhExtraPay t5 on t5.IpBaseNr = t4.IpBaseNr
	group by t2.Wic, t4.IpBaseNr

		-- select distinct  Wic, IpBaseNr from #ExtraWidSharesPer

	drop table if exists #ExtraWidSharesMec
	select t2.Wic, t4.IpBaseNr, sum(t3.Shares) as Shares
	into #ExtraWidSharesMec
	from Z_ReportWics t1
		join SocWid..WidIntrPty t2 on t1.Wic = t2.Wic
			join SocWid..widShares t3 on t2.Wic = t3.Wic
				and t2.RolId = t3.IntrPtyRolid
				and t3.RightType = 'MEC'
		join SocIpi..IpiName t4 on t2.IpNameNr = t4.IpNameNr
		join SocIpiEx..RhExtraPay t5 on t5.IpBaseNr = t4.IpBaseNr
	group by t2.Wic, t4.IpBaseNr

	drop table if exists #ExtraWidShares
	select 
		  isnull(t1.Wic, t2.Wic) as Wic
		, isnull(t1.IpBaseNr, t2.IpBaseNr) as IpBaseNr
		, isnull(t1.Shares, 0) as PerShr
		, isnull(t2.Shares, 0) as MecShr
	into #ExtraWidShares
	from #ExtraWidSharesPer t1
		full join #ExtraWidSharesMec t2 on t1.Wic = t2.Wic
			and t1.IpBaseNr = t2.IpBaseNr
	order by t1.Wic, t1.IpBaseNr

	declare @custId int = (select custId from MediaService..Customer where custType = 7)
	drop table if exists ShareCalc..Z_DdexReportExtras
	select
		  null							as Wic
		, ObjId							as ObjId
		, null							as IpBaseNr
		, @custId						as CustId
		, null							as IpNameNr
		, cast(PerShr as decimal(5, 2))	as PerShr
		, cast(MecShr as decimal(5, 2))	as MecShr
		, 100							as PerSocShr
		, 100							as MecSocShr
		, 140							as PerSoc
		, 140							as MecSoc
	into ShareCalc..Z_DdexReportExtras
	from #ExtraMsShares
	union
	select
		  Wic							as Wic
		, null							as ObjId
		, null							as IpBaseNr
		, @custId						as CustId
		, null							as IpNameNr
		, cast(PerShr as decimal(5, 2))	as PerShr
		, cast(MecShr as decimal(5, 2))	as MecShr
		, 100							as PerSocShr
		, 100							as MecSocShr
		, 140							as PerSoc
		, 140							as MecSoc
	from #ExtraWidShares
			
	drop table if exists #ExtraMsShares
	drop table if exists #ExtraWidSharesPer
	drop table if exists #ExtraWidSharesMec
	drop table if exists #ExtraWidShares
end
go

-- exec spCalcReportExtras
-- select * from ShareCalc..Z_DdexReportAuthors