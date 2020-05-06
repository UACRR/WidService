
CREATE FUNCTION [dbo].[ft_tsk_3_OR_01]  (@strSeek varchar(254) )
--Ф-я для отображения грида ОП с поиском
RETURNS @RT TABLE
(	
 objid integer, 
 name varchar(254), 
 Category char(1), 
 genreType integer, 
 genreName varchar(100), 
 duration time, 
 specName varchar(100), 
 rateTotal numeric(5,2), 
 author	varchar(254), 
 performer varchar(254), 
 profit money, 
 rest money, 
 statusActive smallint, 
 statusNoActive smallint, 
 statusNoRelate smallint, 
 statusUnDistrib smallint, 
 categoryCode integer, 
 innerCode varchar(100)
)
AS
BEGIN

IF isnull(@strSeek,'') = ''
BEGIN  
--спільний процент володіння
with TabCPR as 
(select t2.objid, sum(t2.rate) as rate, min(isnull(t2.status,0)) as isNotAccepted
  from copyright t2 
  --left join WorkRH t3 on t2.cRightId = t3.cRightId and t3.workTypeRh <> 4
  where getdate() between t2.beginDate and t2.endDate
  group by t2.objid
)
,
--Остатки на 30-м и 31-м счете
TabSDay as 
(select t1.objid, sum(t3.rest) as rest
 from ObjectRight t1 
 join Account t2 on t2.balsCode in (30,31) and  t1.objid = t2.objid 
 join SaldoDay t3 on t2.accId = t3.accId and getdate() between t3.dateBegin and t3.dateEnd and t3.rest <> 0
 group by t1.objId
)
insert into @RT ( objid, name, Category, genreType, genreName, duration, specName, rateTotal, 
 author, performer, profit, rest, statusActive, statusNoActive, statusNoRelate, 
 statusUnDistrib, categoryCode, innerCode)
 select t1.objid, t1.name, 
(Case When t1.categoryCode = 5 Then 'M' else 'B' end) as Category, 
 t1.genreType, t2.name as genreName, 
 t3.duration, t4.name as specName, isnull(t5.rate,0) as rateTotal, 
 isnull(t1.author, '') as author , -- Патлякевич додав для відображення автора при прив'язці
 (CASE When t1.categoryCode = 5 THEN isnull(t1.performer, '') ELSE t14.name END) as performer, 
 isnull(t6.proffit,0) as profit
,rest --залишок на рахунку
,(Case When t1.status = 1 Then 1 Else 0 end ) as statusActive -- Діючі
,(Case When t5.isNotAccepted = 0 Then 1 Else 0 end ) as statusNoActive -- Якщо є копірайт без підтвердження
,(Case When isnull(t5.rate,0) <100 Then 1 Else 0 end ) as statusNoRelate -- Не прив"язані
--,(Case When t5.workTypeRh = 1 Then 1 Else 0 end ) as statusWokrRq -- Сформовані запити
,(Case When isnull(t11.Rest,0) <> 0 Then 1 Else 0 end ) statusUnDistrib -- Не розподілені
,t1.categoryCode
, isnull(t1.innerCode, cast(t1.objid as varchar(25))) as innerCode
from objectRight t1 
left join MediaTrack t3 on t1.objid = t3.objId
left join GenreType t2 on t1.genreType = t2.codeI
left join specType t4 on t1.specType = t4.codeI
left join TabCPR t5 on t1.objid = t5.objId
left join vtsk_4_OR_PROFITFORYEAR t6 on t1.objId = t6.objid
left Join TabSDay t11 on t11.objid = t1.objId
left join LicenseBigR t12 on t12.objId = t1.objId
left join LicenseAgreement t13 on t13.licId = t12.licId 
left join vCustomerRHolder t14 on t14.custId = t13.custId
END

ELSE 

BEGIN --ELSE

declare  @TmpObjectId table
(objid integer not null primary key)

insert into @TmpObjectId 
(objid)
select distinct t1.objid
  from objectRight t1 
  cross apply (SELECT rtrim(ltrim(value)) as value FROM STRING_SPLIT(@strSeek, '/')) as t2 
  where name like '%'+t2.value+'%' 
      or author like '%'+t2.value+'%' 
	  or performer like '%'+t2.value+'%' ;

--спільний процент володіння
with TabCPR as 
(select t2.objid, sum(t2.rate) as rate, min(isnull(t2.status,0)) as isNotAccepted
  from @TmpObjectId t0
  join copyright t2 on t0.objid = t2.objid 
  --left join WorkRH t3 on t2.cRightId = t3.cRightId and t3.workTypeRh <> 4
  where getdate() between t2.beginDate and t2.endDate
  group by t2.objid
)
,
--Остатки на 30-м и 31-м счете
TabSDay as 
(select t0.objid, sum(t3.rest) as rest
 from @TmpObjectId t0 
 join Account t2 on t2.balsCode in (30,31) and  t0.objid = t2.objid 
 join SaldoDay t3 on t2.accId = t3.accId and getdate() between t3.dateBegin and t3.dateEnd and t3.rest <> 0
 group by t0.objId
)
insert into @RT ( objid, name, Category, genreType, genreName, duration, specName, rateTotal, 
 author, performer, profit, rest, statusActive, statusNoActive, statusNoRelate, 
 statusUnDistrib, categoryCode, innerCode)
 select t1.objid, t1.name, 
(Case When t1.categoryCode = 5 Then 'M' else 'B' end) as Category, 
 t1.genreType, t2.name as genreName, 
 t3.duration, t4.name as specName, isnull(t5.rate,0) as rateTotal, 
 isnull(t1.author, '') as author , -- Патлякевич додав для відображення автора при прив'язці
 (CASE When t1.categoryCode = 5 THEN isnull(t1.performer, '') ELSE t14.name END) as performer, 
 isnull(t6.proffit,0) as profit
,rest --залишок на рахунку
,(Case When t1.status = 1 Then 1 Else 0 end ) as statusActive -- Діючі
,(Case When t5.isNotAccepted = 0 Then 1 Else 0 end ) as statusNoActive -- Якщо є копірайт без підтвердження
,(Case When isnull(t5.rate,0) <100 Then 1 Else 0 end ) as statusNoRelate -- Не прив"язані
--,(Case When t5.workTypeRh = 1 Then 1 Else 0 end ) as statusWokrRq -- Сформовані запити
,(Case When isnull(t11.Rest,0) <> 0 Then 1 Else 0 end ) statusUnDistrib -- Не розподілені
,t1.categoryCode
, isnull(t1.innerCode, cast(t1.objid as varchar(25))) as innerCode
from @TmpObjectId t0 
join objectRight t1 on t0.objid = t1.objId
left join MediaTrack t3 on t1.objid = t3.objId
left join GenreType t2 on t1.genreType = t2.codeI
left join specType t4 on t1.specType = t4.codeI
left join TabCPR t5 on t1.objid = t5.objId
left join vtsk_4_OR_PROFITFORYEAR t6 on t1.objId = t6.objid
left Join TabSDay t11 on t11.objid = t1.objId
left join LicenseBigR t12 on t12.objId = t1.objId
left join LicenseAgreement t13 on t13.licId = t12.licId 
left join vCustomerRHolder t14 on t14.custId = t13.custId


END --ELSE

RETURN
END

--select * from [dbo].[ft_tsk_3_OR_01]  ('рибч')
