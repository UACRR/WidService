use SocWidSubmitEx
go

create or alter view vSubmWorkShareErrors
as
select
      t1.Id as SubmWorkShareId
	, t1.SubmWorkId as SubmWorkId
	, t6.CustId as RhCustId    
	, t6.IpBaseNr as RhIpBaseNr  
	, t6.IpNameNr as RhIpNameNr  
	, trim(concat(t6.Name, ' ', t6.FstName)) as RhName      
	, trim(concat(t6.NameForWid, ' ', t6.FstNameForWid)) as RhNameForWid
	, t6.IsOwn as RhIsOwn
	, t1.RoleForWid as RhRoleForWid
	, t1.ShrPer as RhShrPer    
	, t1.ShrMec as RhShrMec
	, t5.MsgTxt
from SubmWorkShare t1
	join RecSipOip t2 on t1.Id = t2.SubmWorkShareId
	left join MsgMapRecSipOip t3 on t2.Id = t3.RecSipOipId
	left join RecMsg t4 on t3.RecMsgId = t4.Id
	left join RecMsgType t5 on t4.RecMsgTypeId = t5.Id
	join RightHolder t6 on t1.RightHolderId = t6.Id

union

select
      t1.Id as SubmWorkShareId
	, t1.SubmWorkId as SubmWorkId
	, t7.CustId as RhCustId    
	, t7.IpBaseNr as RhIpBaseNr  
	, t7.IpNameNr as RhIpNameNr  
	, trim(concat(t7.Name, ' ', t7.FstName)) as RhName      
	, trim(concat(t7.NameForWid, ' ', t7.FstNameForWid)) as RhNameForWid
	, t7.IsOwn as RhIsOwn
	, t1.RoleForWid as RhRoleForWid
	, t1.ShrPer as RhShrPer    
	, t1.ShrMec as RhShrMec
	, t6.MsgTxt
from SubmWorkShare t1
	join RecSipOip t2 on t1.Id = t2.SubmWorkShareId
	join RecSsrOsr t3 on t2.Id = t3.RecSipOipId
	left join MsgMapRecSsrOsr t4 on t3.Id = t4.RecSsrOsrId
	left join RecMsg t5 on t4.RecMsgId = t5.Id
	left join RecMsgType t6 on t5.RecMsgTypeId = t6.Id
	join RightHolder t7 on t1.RightHolderId = t7.Id
go

