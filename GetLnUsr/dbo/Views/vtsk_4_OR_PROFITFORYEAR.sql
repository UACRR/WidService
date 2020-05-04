create view vtsk_4_OR_PROFITFORYEAR as 
select objId, sum(krdOborot) as proffit 
from Account t1
join SaldoDay t2 on t2.accId = t1.accId and datepart(YEAR, getdate()) between DATEPART(YEAR, t2.dateBegin) and DATEPART(YEAR, t2.dateEnd )
where objid is not null
and balsCode = 30
group by objId