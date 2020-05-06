
CREATE FUNCTION [dbo].[ft_Tsk_3_AutoLink_FULL]  (@regId int )
--Автопривязка с учтом внешней базы
RETURNS @RT TABLE
(	
	regId int
	,regIItemId int
    ,objid int
	,WIC int
	,objectName varchar(254) null
	,objectAuthors varchar(254) null
	,objectPerformers varchar(254) null
	,sumAllTogether float
)
AS
BEGIN
	declare @accuracy float = 0.4, @precision float = 0.001;

insert @RT
(	
	regId 
	,regIItemId 
    ,objid 
	,WIC 
	,objectName 
	,objectAuthors 
	,objectPerformers 
	,sumAllTogether 
)
 select regId, regIItemId, objid, WIC, objectName, objectAuthors, objectPerformers, sumAllTogether 
 from dbo.ft_Tsk_3_AutoLink (@regId);

If exists ( select  1 from vMyAnk where TypeAlg = 1 )
BEGIN
 --Теперь по WID
insert @RT
(	
	regId 
	,regIItemId 
    ,objid 
	,WIC 
	,objectName 
	,objectAuthors 
	,objectPerformers 
	,sumAllTogether 
)
 select regId, regIItemId, NULL, WIC, objectName, objectAuthors, objectPerformers, sumAllTogether 
 from dbo.ft_Tsk_3_AutoLink_WIDW(@regId);
END

RETURN
END
--select * from dbo.ft_Tsk_3_AutoLink_FULL (3361)
--select * from WID_IPI..vtsk_3_OR_01
