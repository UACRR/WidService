use SocWidSubmitEx
go

create or alter procedure spSelectSubmWorkShareDiff
	@submWorkId int
as
begin

	declare @curSubmId int = (select SubmissionId from SubmWork where Id = @submWorkId)
	--print @curSubmId
	declare @prevSubmId int = (select dbo.fnPrevSubmIdEx(@curSubmId))
	--print @prevSubmId

	drop table if exists #CurSubmWorkShare
	select t2.ObjId, t3.CustId, t1.*
	into #CurSubmWorkShare
	from SubmWorkShare t1
		join SubmWork t2 on t1.SubmWorkId = t2.Id
		join RightHolder t3 on t1.RightHolderId = t3.Id
	where t2.Id = @submWorkId
	--select * from #CurSubmWorkShare

	drop table if exists #PrevSubmWorkShare

	; with PrevSubmWorkIds as (
		select distinct t3.Id as SubmWorkId
		from #CurSubmWorkShare t1
			join SubmWork t2 on t1.SubmWorkId = t2.Id
			join SubmWork t3 on t2.ObjId = t3.ObjId
				and t3.SubmissionId = @prevSubmId
	)
	select t2.ObjId, t4.CustId, t3.*
	into #PrevSubmWorkShare
	from PrevSubmWorkIds t1
		join SubmWork t2 on t1.SubmWorkId = t2.Id
		join SubmWorkShare t3 on t2.Id = t3.SubmWorkId
		join RightHolder t4 on t3.RightHolderId = t4.Id
	--select * from #PrevSubmWorkShare

	select           
		  t1.SubmWorkId										as CurSubmWorkId   
		, t1.RightHolderId									as CurRightHolderId
		, t3.CustId											as CurRhCustId     
		, t3.IpBaseNr										as CurRhIpBaseNr   
		, t3.IpNameNr										as CurRhIpNameNr   
		, dbo.fnFullName(t3.Name, t3.FstName)				as CurRhName       
		, dbo.fnFullName(t3.NameForWid, t3.FstNameForWid)	as CurRhNameForWid 
		, dbo.fnGetMsRightHolderTypeName(t3.RhType)			as CurRhTypeName   
		, dbo.fnGetMsRightHolderRoleName(t1.RhRole)			as CurRhRoleName   
		, t1.RoleForWid										as CurRhRoleForWid 
		, t3.IsOwn											as CurRhIsOwn      
		, t3.IsActive										as CurRhIsActive   
		, t1.ShrPer											as CurRhShrPer     
		, t1.ShrMec											as CurRhShrMec

		, t2.SubmWorkId										as PrevSubmWorkId   
		, t2.RightHolderId									as PrevRightHolderId
		, t4.CustId											as PrevRhCustId     
		, t4.IpBaseNr										as PrevRhIpBaseNr   
		, t4.IpNameNr										as PrevRhIpNameNr   
		, dbo.fnFullName(t4.Name, t4.FstName)				as PrevRhName       
		, dbo.fnFullName(t4.NameForWid, t4.FstNameForWid)	as PrevRhNameForWid 
		, dbo.fnGetMsRightHolderTypeName(t4.RhType)			as PrevRhTypeName   
		, dbo.fnGetMsRightHolderRoleName(t2.RhRole)			as PrevRhRoleName   
		, t2.RoleForWid										as PrevRhRoleForWid 
		, t4.IsOwn											as PrevRhIsOwn      
		, t4.IsActive										as PrevRhIsActive   
		, t2.ShrPer											as PrevRhShrPer     
		, t2.ShrMec											as PrevRhShrMec
	from #CurSubmWorkShare t1
		full join #PrevSubmWorkShare t2 on t1.ObjId = t2.ObjId
			and t1.CustId = t2.CustId
			and t1.RoleForWid = t2.RoleForWid
		left join RightHolder t3 on t1.RightHolderId = t3.Id
		left join RightHolder t4 on t2.RightHolderId = t4.Id
end
go 

-- exec spSelectSubmWorkShareDiff 15208

