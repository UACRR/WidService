select *
from RespFileErr t1
	join RecSip t2 on t1.SubmRecId = t2.Id
	join SocIpi..IpiName t3 on t2.IpNameNr = t3.IpNameNr
where RespFileErr = 12

select * from SocIpi..IpiBase t1 join SocIpi..IpiName t2 on t1.IpBaseNr = t2.IpBaseNr
where t1.IpBaseNr = 'I-004407165-8'