select *
from SocWid..widIntrPty t1
	join SocWid..widShares t2 on t1.Wic = t2.Wic and t1.RolId = t2.IntrPtyRolid
	join SocIpi..IpiName t3 on t1.IpNameNr = t3.IpNameNr
where t1.Wic = 39177276  --43202455 --

select *
from SocIpiDump..IpiName
where IpBaseNr = 
--'I-007398196-9' 
'I-001631070-4'

select *
from SocIpi..IpiName
where IpNameNr = 216156786

select *
from SocIpi..IpiName
where IpBaseNr = 
--'I-007398196-9' 
'I-001631070-4'

select *
from SocIpi..IpiName
where IpNameNr = 1312448286


select * from Socipi..IpiStatus where IpBaseNr = 'I-007398196-9'
select * from Socipi..IpiBase where IpBaseNr = 'I-007398196-9'

select *
from SocIpiDump..IpiName
where IpNameNr = 288936892

select *
from SocIpi..IpiName
where IpNameNr = 288936892



select *
from SocIpi..IpiName t1
		--join SocIpi..IpiBase t2 on t1.IpBaseNr = t2.IpBaseNr
		join SocIpi..IpiStatus t3 on t1.IpBaseNr = t3.IpBaseNr
where t1.IpBaseNr in (
--'I-001631070-4'
--, 
--'I-007398196-9'
--, 
'I-001635620-8'
)

-- Dulicate IpNameNr = 288936892

; with Numbered as
(
	select
		  t1.IpBaseNr
		, t2.SttCde
		, row_number() over (partition by t2.IpBaseNr order by t2.AmdDt desc) as SeqNr
	from SocIpi..IpiName t1
		join SocIpi..IpiStatus t2 on t1.IpBaseNr = t2.IpBaseNr
	where t1.IpNameNr in (288936892)
		and getdate() between t2.FromDt and t2.ToDt
)
select min(IpBaseNr)
from Numbered
where SeqNr = 1
	and SttCde = 1

select * from SocIpi..IpiName where IpBaseNr = 'I-007398196-9' --'I-001631070-4'


select t2.*, t3.*, t4.*
from MediaTrack t1
	join CopyRight t2 on t1.ObjId = t2.ObjId
	join RightHolder t3 on t2.CustId = t3.CustId
	join CustCmRight t4 on t2.CustId = t4.CustId
where t1.Iswc = 'T3141052797'

select * from AnketaExternal

