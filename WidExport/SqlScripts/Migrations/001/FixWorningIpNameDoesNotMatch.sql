--select * from SocIpi..IpiName where ipbasenr = 'I-005054813-3' --IpNameNr = 364340767

select *
from RespFileErr t1
	join RecSip t2 on t1.SubmRecId = t2.Id
	join SocIpi..IpiName t3 on t2.IpNameNr = t3.IpNameNr
where RespFileErr = 2

update RespFileErr
set NeedNotFix = 1
where RespFileErr = 2