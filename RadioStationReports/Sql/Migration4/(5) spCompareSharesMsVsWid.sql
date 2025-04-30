use RadioStationReports
go

create or alter procedure spCompareSharesMsVsWid
	@objId int, @wic int
as
begin

drop table if exists #SocPrior
select cast(Cde as int) as SocCde, 2 as Prior
into #SocPrior
from SocIpi..DicSoc

update #SocPrior set Prior = 0 where SocCde = 140

--select *
update t3
set t3.Prior = 1
from MediaService..AgreementAddCommunity t1
	join MediaService..Community t2 on t1.CustId = t2.CustId
	join #SocPrior t3 on t2.interCode = t3.SocCde
where getdate() between t1.DateBegin and t1.DateEnd
	and getdate() between t1.DateBeginPer and t1.DateEndPer
	and AgrStatus = 2

drop table if exists #InfoMs
select
	  t1.CustId					as SmartCodeM
	, t2.InterCode				as IpBaseNrM
	, cast(t2.IPIBase as int)	as IpNameNrM
	, t3.ShortName				as RightHolderNameM
	, t1.BeginDate				as RightStartDateM
	, t1.EndDate				as RightEndDateM
	, t1.Rate					as ShareM
into #InfoMs
from MediaService..CopyRight t1
	join MediaService..RightHolder t2 on t1.CustId = t2.CustId
	join MediaService..vCustomerNamesShort t3 on t1.CustId = t3.CustId
where ObjId = @objId

drop table if exists #InfoWid
; with Ordered as (
	select
		  row_number() 
			over(
				partition by t3.IpBaseNr 
				order by t5.Prior, t4.FromDt desc
		  )											as SeqNr
		, null										as SmartCodeW
		, t3.IpBaseNr								as IpBaseNrW
		, t3.IpNameNr								as IpNameNrW
		, trim(concat(t3.Name, ' ', t3.FstName))	as RightHolderNameW
		, t4.FromDt									as RightStartDateW
		, t4.ToDt									as RightEndDateW
		, t2.Shares									as ShareW
	from SocWid..widIntrPty t1
		join SocWid..WidShares t2 on t1.RolId = t2.IntrPtyRolid
			and t1.Wic = t2.Wic
		join SocIpi..IpiName t3 on t1.IpNameNr = t3.IpNameNr
		join SocIpi..IpiAgreement t4 on t3.IpBaseNr = t4.IpBaseNr
		join #SocPrior t5 on t4.SocCde = t5.SocCde
	where t1.Wic = @wic
		and t2.RightType = 'PER'
		and t4.CreClsCde = 'MW'
		and t4.RgtCde = 'PR'
		and t4.RolCde in ('LY', 'MC', 'EM')
)
select *
into #InfoWid
from Ordered 
where SeqNr = 1

select *
from #InfoMs t1
	full join #InfoWid t2 on t1.IpBaseNrM = t2.IpBaseNrW

end
go

-- exec spCompareSharesMsVsWid 936548, 41978058