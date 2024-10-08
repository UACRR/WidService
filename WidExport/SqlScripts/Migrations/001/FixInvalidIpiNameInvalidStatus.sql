select t2.*, t3.*
from WidSubmGroupWorkShare t1
	join SocIpi..IpiName t2 on t1.IpNameNr = t2.IpNameNr
	join SocIpi..IpiStatus t3 on t2.IpBaseNr = t3.IpBaseNr
where sttcde <> 1

select * from SocIpi..IpiName where IpBaseNr = 'I-004310922-2'

/*
DOSENKO YEVHEN IVANOVYCH: I-001994319-0/421803000 => I-000294820-9/818251148
ZHOLTIKOV OLEH VALENTYNOVICH: I-004407165-8/813288635 => I-004310922-2/798359564
*/

--select * from SocIpi..IpiStatus where IpBaseNr = 'I-004310922-2'

select * 
from WidSubmGroupWorkShare where IpBaseNr = 'I-001994319-0' and IpNameNr = 421803000

update WidSubmGroupWorkShare
set IpBaseNr = 'I-000294820-9', IpNameNr = 818251148
where IpBaseNr = 'I-001994319-0' and IpNameNr = 421803000

update WidSubmGroupWorkShare
set IpBaseNr = 'I-004310922-2', IpNameNr = 798359564
where IpBaseNr = 'I-004407165-8' and IpNameNr = 813288635

update RespFileErr
set IsFixed = 1
where RespFileErr = 12
