
/*==============================================================*/
/* View: vCopyRightSh                                           */
/*==============================================================*/
create view vCopyRightSh as
  select t1.categoryCode, t1.objId, t1.name, t1.author, t1.performer, t2.cRightId, t2.custId, t2.rate, t3.name as custName, 
  t2.roleCode, t4.name as roleName, t2.roleRate, t2.beginDate, t2.endDate
  from ObjectRight t1 
  join CopyRight t2 on t1.objid = t2.objid 
  join vCustomer t3 on t2.custId = t3.custId
  join CreativeRoleType t4 on t2.roleCode = t4.codeI