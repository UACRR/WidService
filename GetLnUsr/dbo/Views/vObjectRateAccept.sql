create view vObjectRateAccept
as 
select t2.objid, sum(t2.rate) as rate, min(isnull(t2.status,0)) as isNotAccepted
  from copyright t2 
  --left join WorkRH t3 on t2.cRightId = t3.cRightId and t3.workTypeRh <> 4
  where convert(date, getdate(), 104) between t2.beginDate and t2.endDate
  group by t2.objid

