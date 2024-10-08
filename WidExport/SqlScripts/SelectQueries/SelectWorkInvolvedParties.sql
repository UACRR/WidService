drop table if exists #InvolvedParties

-- бхапю╙лн юбрнп╡б рбнп╡б (бя╡у аегб╡дмнямн рбнп╡б) 
select distinct 
	  t1.custId		as custId 
	, t1.authorName as AuthorName
	, t2.interCode  as IpBaseNr
	, t2.IPIBase	as IpNameNr
into #InvolvedParties
from MediaService..Authors t1
	join MediaService..RightHolder t2 on t1.custId = t2.custId
where t1.custId is not null
	and (   t2.interCode is not null and trim(t2.interCode) <> ''
			or 
			t2.IPIBase is not null and trim(t2.IPIBase) <> ''
		)

-- днюдю╙лн опюбнбкюямхй╡б, ъйх онйх мелю╙ яепед опхверм╡у оепянм
insert #InvolvedParties
select 
	  custId    as custId
	, ''	    as AuthorName
	, InterCode as IpBaseNr
	, IPIBase	as IpNameNr
from MediaService..RightHolder
where custId not in (select custId from #InvolvedParties)

-- гюл╡мч╙лн IpNameNr (бйкчвючвх мскх) мю йндх оюрпнм╡л╡б (де бдюярэяъ)
update t1
set
	t1.IpNameNr = t3.IpNameNr
from #InvolvedParties t1
	join SocIpi..IpiBase t2 on t1.IpBaseNr = t2.IpBaseNr
	join SocIpi..IpiName t3 on t2.IpBaseNr = t3.IpBaseNr and t3.NameType = 'PA'

-- бхдюкъ╙лн рху, дкъ йнцн IPI ╡лъ ме бдюкняэ гюмюирх
delete #InvolvedParties
where IpNameNr is null

-- бхдюкъ╙лн рху, дкъ йнцн опндсакэнбюмю ╡мтнплюж╡ъ
; with Duplicates as (
	select 
		  IpBaseNr
		, IpNameNr
	from #InvolvedParties
	group by IpBaseNr, IpNameNr
	having count(*) > 1
)
delete t1
from  #InvolvedParties t1
	join Duplicates t2 on t1.IpBaseNr = t2.IpBaseNr and t1.IpNameNr = t2.IpNameNr

-- гюоебмч╙лняэ ын реоеп custId ме дсакччрэяъ (же рюй)
select custId
from  #InvolvedParties
group by custId
having count(*) > 1

-- он╙дмс╙лн опхвермху оепянм г рбнпюлх
-- онвхмю╙лн г опюбнбкюямхй╡б
drop table if exists #WorkInvolvedParties

select
	  objId					as ObjId
	, custId				as CustId
	, rate					as	PerShr
	, rateMech				as	MecShr
	, case roleCode
	  when 1 then 'A'
	  when 2 then 'C'
	  when 8 then 'E'
	  when 10 then 'CA'
	  end					as Role
    , 0						as HasMsAgreement
	, 0						as HasIpiAgreement
into #WorkInvolvedParties
from CopyRight
where status in (1 /*оЁДРБЕПДФЕМХИ*/) -- МЕ ПНГЦКЮДЮ╨ЛН 0 - МЕ ОЁДРБПЕДФЕМХИ, Ё 2 - ГЮЙПХРХИ
	and roleCode in (1, 2, 8, 10)
	and beginDate <= getdate()
	and endDate >= getdate()

-- реоеп дндю╙лн юбрнп╡б, ъй╡ ме нохмхкхяэ яепед опюбнбкюямхй╡б
insert #WorkInvolvedParties (
	  ObjId
	, CustId
	, PerShr
	, MecShr
	, Role
	, HasMsAgreement
	, HasIpiAgreement
)
select
	  t1.objId					as ObjId
	, t1.custId					as CustId
	, 0							as PerShr
	, 0							as MecShr
	, case roleCode
	  when 1 then 'A'
	  when 2 then 'C'
	  when 8 then 'E'
	  when 10 then 'CA'
	  end						as Role
    , 0							as HasMsAgreement
	, 0							as HasIpiAgreement
from Authors t1
	join #InvolvedParties t2 on t1.custId = t2.custId
where t1.custId not in (select custId from #WorkInvolvedParties)
	and roleCode in (1, 2, 8, 10)

declare @IpNameNr int = 153257678

select *
from #InvolvedParties
where IpNameNr = @IpNameNr