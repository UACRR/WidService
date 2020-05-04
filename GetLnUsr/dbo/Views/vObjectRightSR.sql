create view vObjectRightSR as 
SELECT max(t1.categoryCode) as categoryCode, t1.objId, max(t1.name) as objName, max(t1.author) as author, 
    autorText = STUFF(
	       (select ','+authorName from  Authors t0 where roleCode = 1 and t0.objid = t1.objid FOR XML PATH ('')), 1, 1, '' 
		   ), 
    autorMusic = STUFF(
	       (select ','+authorName from  Authors t0 where roleCode = 2 and t0.objid = t1.objid FOR XML PATH ('')), 1, 1, '' 
		   )
from ObjectRight t1 
where categoryCode = 5
group by t1.objid 
