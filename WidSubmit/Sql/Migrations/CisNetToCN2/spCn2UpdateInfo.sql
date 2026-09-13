use SocWidSubmitEx
go

create or alter procedure spCn2UpdateInfo
as
begin

-- delete from Z_Cn2RightHolder

-- Õ≈¬≤ƒŒÃ»… œ–¿¬Œ¬À¿—Õ» 
	declare @unknownIpBaseNr varchar(13) = 'I-007141056-3'
	declare	@unknownIpNameNr varchar(13) = '01273843143'
	declare	@unknownName     varchar(16) = 'UNKNOWN'
	declare @unknwnCustId    int         = (
		select t1.CustId 
		from MediaService..vCustomerNameDetailed t1 
			join MediaService..RightHolder t2 on t1.CustId = t2.CustId
		where FullName = 'ÌÂ‚≥‰ÓÏËÈ'
	)
	
	update MediaService..RightHolder
	set InterCode = @unknownIpBaseNr, IPIBase = @unknownIpNameNr
	where CustId = @unknwnCustId
	
	update Z_LostIpiCodes
	set IpBaseNr = @unknownIpBaseNr, IpNameNr = @unknownIpNameNr
	where CustIdCoAuthor = @unknwnCustId

-- «Õ¿…ƒ≈Õ≤ Ã≤∆Õ¿–ŒƒÕ≤  Œƒ»
	; with DistRh as (
		select distinct CustIdCoAuthor, FullNameCoAuthor, FullNameCoAuthorTr, IpBaseNr, IpNameNr
		from Z_LostIpiCodes
		where IsFinal = 1
			and IpBaseNr <> ''
	)
	update t1
	set t1.InterCode = t2.IpBaseNr, t1.IPIBase = t2.IpNameNr
	from MediaService..RightHolder t1
		join DistRh t2 on t1.CustId = t2.CustIdCoAuthor

-- ¿ “»¬Õ≤ œ–¿¬Œ¬À¿—Õ» » (ÓÁ¯Ë˛∫ÏÓ ÔÂÂÎ≥Í)
--	insert Z_Cn2RightHolder
--	select
--		  t1.CustId																							as CustId
--		, left(isnull(t1.InterCode, '')	, 13)																as IpBaseNr
--		, left(isnull(t1.IPIBase, ''), 13)																	as IpNameNr
--		, left(MediaService.dbo.ClrTranslitFromUkrToLat(t3.Name), 90)										as Name	
--		, left(MediaService.dbo.ClrTranslitFromUkrToLat(trim(concat(t3.FirstName, ' ', t3.SurName))), 45)	as FstName
--		, 1																									as IsActive
--	from MediaService..RightHolder t1
--		join MediaService..AgreementAddRH t2 on t1.CustId = t2.CustId
--		join MediaService..vCustomerNameDetailed t3 on t1.CustId = t3.CustId
--		left join Z_Cn2RightHolder t4 on t1.CustId = t4.CustId
--	where t2.AgrStatus = 2
--		and t4.CustId is null
--
--- —œ≤¬¬À¿—Õ» » (ÓÁ¯Ë˛∫ÏÓ ÔÂÂÎ≥Í)
--	; with ObjIds as (
--		select distinct t2.ObjId
--		from Z_Cn2RightHolder t1
--			join MediaService..CopyRight t2 on t1.CustId = t2.CustId
--				and getdate() between t2.BeginDate and t2.EndDate
--		where t1.IsActive = 1
--	),
--	CustIds as (
--		select distinct t2.CustId
--		from ObjIds t1
--			join MediaService..CopyRight t2 on t1.ObjId = t2.ObjId
--	)
--	insert Z_Cn2RightHolder
--	select
--		  t1.CustId																							as CustId
--		, left(isnull(t2.InterCode, '')	, 13)																as IpBaseNr
--		, left(isnull(t2.IPIBase, ''), 13)																	as IpNameNr
--		, left(MediaService.dbo.ClrTranslitFromUkrToLat(t3.Name), 90)										as Name	
--		, left(MediaService.dbo.ClrTranslitFromUkrToLat(trim(concat(t3.FirstName, ' ', t3.SurName))), 45)	as FstName
--		, 0																									as IsActive
--	from CustIds t1
--		join MediaService..RightHolder t2 on t1.CustId = t2.CustId
--		join MediaService..vCustomerNameDetailed t3 on t1.CustId = t3.CustId
--		left join Z_Cn2RightHolder t4 on t1.CustId = t4.CustId
--	where 
--		t4.CustId is null
--
--
--- œ–¿¬Œ¬À¿—Õ≤—“‹
--	truncate table Z_Cn2CopyRight
--	; with DistObjIds as (
--		select distinct t1.ObjId
--		from MediaService..CopyRight t1
--			join Z_Cn2RightHolder t2 on t1.CustId = t2.CustId
--		where getdate() between t1.BeginDate and t1.EndDate
--			and t2.IsActive = 1
--	)
--	insert Z_Cn2CopyRight
--	select t2.CrightId, t2.ObjId, t2.CustId, t2.Rate, t2.RateMech, dbo.fnGetWidRole(t3.RHolderType, t2.RoleCode), 1
--	from DistObjIds t1
--		join MediaService..CopyRight t2 on t1.ObjId = t2.ObjId
--			and getdate() between t2.BeginDate and t2.EndDate
--		join MediaService..RightHolder t3 on t2.CustId = t3.CustId
--
		-- select * from Z_Cn2CopyRight

-- Õ≈¬≤ƒŒÃ»… œ–¿¬Œ¬À¿—Õ» 
	-- ; with DistRh as (
	-- 	select distinct CustIdCoAuthor
	-- 	from Z_LostIpiCodes
	-- 	where IsFinal = 1
	-- 		and IpBaseNr = ''
	-- )
	-- update t2
	-- set t2.CustId = @unknwnCustId
	-- from DistRh t1
	-- 	join Z_Cn2CopyRight t2 on t1.CustIdCoAuthor = t2.CustId

end
go

-- exec spCn2UpdateInfo