-- BirthState

drop table if exists Wrong_IpiBaseNr_BirthState
select t1.IpBaseNr, t1.BirthState CurValue, t2.BirthState NewValue
into Wrong_IpiBaseNr_BirthState
from IpiBaseCur t1
	join IpiBase t2 on t1.IpBaseNr = t2.IpBaseNr
where t1.BirthState <> t2.BirthState

-- Records that were not updated from daily updates
select *
from Wrong_IpiBaseNr_BirthState t1
	left join vUpdTransCur t2 on t1.IpBaseNr = t2.IpBaseNr
where t2.IpBaseNr is null

select count(*) from Wrong_IpiBaseNr_BirthState
select count(*) from SocIpi..UpdTrans where RecType = 'IPA'
