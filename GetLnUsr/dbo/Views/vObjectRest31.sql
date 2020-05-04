
create view vObjectRest31 
as 
select t1.objid, sum(t3.rest) as rest
 from ObjectRight t1 
 join Account t2 on t1.objid = t2.objid 
 join SaldoDay t3 on t2.accId = t3.accId and convert(date, getdate(), 104) between t3.dateBegin and t3.dateEnd and t3.rest <> 0
 group by t1.objId
