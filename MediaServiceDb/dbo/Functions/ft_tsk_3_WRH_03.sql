CREATE function [dbo].[ft_tsk_3_WRH_03]( @custId integer = NULL)
RETURNS Table
Return 
(
select t1.cRightId, t1.custId, t2.objid, t2.name as objName, 
t4.name as genreName, t5.duration, 
t3.name as roleName, t6.name as specName, t1.rate, t2.performer, 
t7.workCommentRH, t7.workDateRH, t7.workTypeRH
from copyright t1 
join ObjectRight t2 on t1.objId = t2.objId 
join CreativeRoleType t3 on t1.roleCode = t3.codeI
join GenreType t4 on t2.genreType = t4.codeI
left join MediaTrack t5 on t2.objid = t5.objId
left join SpecType t6 on t2.specType = t6.codeI
left join WorkRH t7 on t1.cRightId = t7.cRightId
where isnull(t1.status,0) = 0 and getdate() between isnull(t1.beginDate,'1900-01-01') and isnull(t1.endDate,'3000-01-01')
 and custId = isnull(@custId, t1.custId)
)