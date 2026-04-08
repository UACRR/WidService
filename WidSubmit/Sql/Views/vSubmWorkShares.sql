use SocWidSubmitEx
go

create or alter view vSubmWorkShares
as
	select
		  t1.Id												as SubmWorkId   
		, t2.RightHolderId									as RightHolderId
		, t3.CustId											as RhCustId       
		, t3.IpBaseNr										as RhIpBaseNr     
		, t3.IpNameNr										as RhIpNameNr     
		, dbo.fnFullName(t3.Name, t3.FstName)  				as RhName
		, dbo.fnFullName(t3.NameForWid, t3.FstNameForWid)	as RhNameForWid
		, concat(t4.codeI, ' - ', t4.name)					as RhTypeName     
		, concat(t5.codeI, ' - ', t5.name)					as RhRoleName     
		, t2.RoleForWid										as RhRoleForWid   
		, t3.IsOwn											as RhIsOwn        
		, t3.IsActive										as RhIsActive     
		, t2.ShrPer											as RhShrPer       
		, t2.ShrMec											as RhShrMec       
	from SubmWork t1
		join SubmWorkShare t2 on t1.Id = t2.SubmWorkId
		join vCurRightHolder t3 on t2.RightHolderId = t3.Id
		join MediaService..RHolderType t4 on t3.RhType = t4.codeI
		join MediaService..CreativeRoleType t5 on t2.RhRole = t5.codeI
go

