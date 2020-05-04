
/*==============================================================*/
/* View: vtsk_3_WRH_02                                          */
/*==============================================================*/
create view dbo.vtsk_3_WRH_02 as
select t6.custid, t2.objId, t6.name as clName, t3.name as objName, t4.name as genreName, convert(char(8), t5.duration) as duration, 
t7.name as roleName, t8.name as specName, t2.rate, isnull(t3.performer, t5.performers) as performer
 from workRh t1 
 join CopyRight t2 on t1.cRightId = t2.cRightId 
 join ObjectRight t3 on t2.objid = t3.objId 
 join GenreType t4 on t3.genreType = t4.codeI 
 join MediaTrack t5 on t3.objid = t5.objId
 join vCustomer t6 on t2.custId = t6.custId
 join CreativeRoleType t7 on t2.roleCode = t7.codeI
 join SpecType t8 on t3.specType = t8.codeI 
where t1.workTypeRH = 1
