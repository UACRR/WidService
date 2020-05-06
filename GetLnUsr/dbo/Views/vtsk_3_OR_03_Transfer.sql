create view [dbo].[vtsk_3_OR_03_Transfer] as
-- % підтверджених прав по об'єкту
with CPR as 
(
	select t2.objid
		 , sum(t2.rate) as rate
	from copyright t2 
	where getdate() between t2.beginDate and t2.endDate and t2.status = 1
	--and custId = 146
	group by t2.objid
)
--% прав по правовласнику 
, CPRH as 
(
	select custId
		 , objid
		 , sum(rate) as ratePer
		 , sum(rateMech) as rateMech
		 , t1.roleCode
		 , t1.crightid
	from CopyRight t1 
	where getdate() between t1.beginDate and t1.endDate
	-- and t1.status = 1
	--and t1.custId = 146
	group by t1.custId, t1.objid, t1.roleCode, t1.crightid
)
select t7.custId
	 , t1.objid
	 , t7.crightid
	 , t1.name
	 --, (Case When t1.categoryCode = 5 Then 'M' else 'B' end) as Category
	 , t1.genreType
	 --, t2.name as genreName
	 --, t3.duration
	 , t7.roleCode
	 --, t7.roleName
	 --, t1.specType
	 --, t4.name as specName
	 , isnull(t5.rate,0) as rateTotal
	 , t7.ratePer
	 , t7.rateMech
	 , isnull(t1.author, '') as author
	 , isnull(t1.performer, '') as performer
	 --, isnull(t6.proffit,0) as profit
from ObjectRight t1 
--left join MediaTrack t3 on t1.objid = t3.objId
--left join GenreType t2 on t1.genreType = t2.codeI
--left join specType t4 on t1.specType = t4.codeI
left join CPR t5 on t5.objId = t1.objid
--left join vtsk_4_OR_PROFITFORYEAR t6 on t6.objid = t1.objId
left join CPRH t7 on t7.objId = t1.objId
--left join CPR t5 on t5.objId = t1.objid

--left join vCustomer t8 on t8.custId = t7.custId
where t1.categoryCode = 5 
--and t7.custId = 146
