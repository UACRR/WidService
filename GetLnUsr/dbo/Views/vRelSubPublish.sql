create view vRelSubPublish as 
select t1.custIdPub, t2.name as custIdPubName, t1.custIdSUb, t3.name as custIdSUbName, t1.dateBegin, t1.dateEnd, t1.createDate, t1.modifyDate 
  from RelSubPublish t1 
  join vCustomer t2 on t1.custIdPub = t2.custId
  join vCustomer t3 on t1.custIdSub = t3.custId
