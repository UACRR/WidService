
CREATE FUNCTION [dbo].[ft_Tsk_3_Report_CCID]  (@regId int )
--Автопривязка по внешней базе с витринами
--Версия 3 улучшенная c шагом
RETURNS @RT TABLE
(	
	regId int
	--,regIItemId int
    ,objId int
	,WIC int
	--,rmId int
	,reportName varchar(254) null
	,reportAuthorMusic varchar(254) null
	,reportAuthorText varchar(254) null
	,reportPerformers varchar(254) null
	,countUse integer
	,objectName varchar(254) null
	,objectAuthors varchar(254) null
	,objectPerformers varchar(254) null
	,objectSourth varchar (200)
)
AS
BEGIN

insert into @RT  
(	regId, 
	--regIItemId, 
	objId, 
	WIC, 
	--rmId, 
	reportName, 
	reportPerformers, 
	reportAuthorMusic,
	reportAuthorText, 
	countUse, 
    objectName, 
	objectAuthors, 
	objectPerformers, 
	objectSourth
)
select  t1.regId, 
		--t4.regIItemId,
		t4.objid, 
		t4.WIC, 
		--t1.rmId, 
		t4.ItemName, 
		t4.performer, 
		t4.authorMusic, 
		t4.authorText, 
		t4.countUse, 
		t6.name, 
		t6.author, 
		t6.performer, 
		t6.sourceName
  from register t1 
  join RegisterCCID t2 on t1.regid = t2.regId
  join registerItem t4 on t4.regid = t1.regId
  join registerCCIDMW t5 on t5.regid = t4.regid and t5.regIItemId = t4.regIItemId
  left join objectRight t6 on t6.objid = t4.objid 
 where t1.regId = @regId

/*
 update @RT set objectName = t2.name, objectAuthors = t2.author, objectPerformers = t2.performer, objectSourth = 'Mediaservice'
 from @RT t1 
   join ObjectRight t2 on t1.objId = t2.objid 
*/

 update @RT set objectName = t2.name, objectAuthors = t2.authors, objectPerformers = t2.performers, objectSourth = 'WID_IPI'
 from @RT t1 
   join WID_IPI..wObject t2 on t1.WIC = t2.WIC 
 where isnull(objid,0) = 0

RETURN
END
--select * from ft_Tsk_3_Report_CCID (7431)

