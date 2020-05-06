
CREATE FUNCTION [dbo].[ft_Tsk_3_AutoLink_WIDW_V4]  (@regId int )
--Автопривязка по внешней базе с витринами
--Версия 3 улучшенная c шагом
RETURNS @RT TABLE
(	
	regId int
	,regIItemId int
	,WIC int
	,objectName varchar(254) null
	,objectAuthors varchar(254) null
	,objectPerformers varchar(254) null
	,sumAllTogether float
)
AS
BEGIN

	declare @accuracy float = 0.4, @precision float = 0.001;

  --Делаю цикл, чтобы не зависало на большом количестве записей отчета

declare @i1 integer = 0, @i2 integer = 100, @iN integer = 0
set @i1 = (select min(regIItemId) from RegisterItem where regId = @regId and isnull(objid,0)+isnull(WIC,0) = 0)
set @iN = (select max(regIItemId) from RegisterItem where regId = @regId and isnull(objid,0)+isnull(WIC,0) = 0)

 WHILE @i1 < @iN
 BEGIN 
	with 
	data_tbl as 
	( 
	select 
	t1.regId,
	t1.regIItemId, 
	t2.WIC
	, max( [dbo].[Ft_tsk_3_Accurace]( t2.name, t1.ItemName, @precision )) as accName
	, max( [dbo].[Ft_tsk_3_Accurace]( t4.LstNa, t1.performer, @precision )) as accPerformer
	, max( [dbo].[Ft_tsk_3_Accurace]( t3.lstName, t1.authorText, @precision )) as accAuthorText 
	, max( [dbo].[Ft_tsk_3_Accurace]( t3.lstName, t1.authorMusic, @precision )) as accAuthor
        , max( [dbo].[Ft_tsk_3_Accurace]( t2.name, t1.ItemName, @precision )) + 
          max( [dbo].[Ft_tsk_3_Accurace]( t4.LstNa, t1.performer, @precision )) + 
	  max( [dbo].[Ft_tsk_3_Accurace]( t3.lstName, t1.authorText, @precision )) + 
	  max( [dbo].[Ft_tsk_3_Accurace]( t3.lstName, t1.authorMusic, @precision )) 
	as sumAllTogether
     from 
	( select regId, regIItemId, objid, WIC 
	   , trim(ItemName) as ItemName 
	   , case when trim(performer) = '' then null else rtrim(trim(performer)) end performer
	   , case when trim(authorText) = '' then null else rtrim(trim(authorText)) end authorText
	   , case when trim(authorMusic) = '' then null else rtrim(trim(authorMusic)) end authorMusic
	   from  RegisterItem  ) t1
       join WID_IPI..wSeekObject t2 on left(REPLACE(t1.ItemName,' ',''),3) = t2.nameIdx 
       left outer join WID_IPI..wSeekPerformer t4 on t4.WIC = t2.WIC
       left outer join WID_IPI..wObjectAuthor t3 on t3.WIC = t2.WIC and t3.roleCode <> 8 
   where regId = @regid  and t1.regIItemId between @i1 and @i1+@i2 --and t1.regIItemId in ( 1,2,3,4,5,6,7,8,9,10)  --для теста
	and t1.objId is null 
	and t1.WIC is null
	and ( [dbo].[Ft_tsk_3_Accurace]( t2.name, t1.ItemName, @precision ) >= @accuracy ) -- name
	and (
	    ( (t1.authorText is null or (t1.authorText is not null and [dbo].[Ft_tsk_3_Accurace]( t3.lstName, t1.authorText, @precision ) >= @accuracy )) 
	    and (t1.authorMusic is null or (t1.authorMusic is not null and [dbo].[Ft_tsk_3_Accurace]( t3.lstName, t1.authorMusic, @precision ) >= @accuracy ))	
	    ) -- authors
 	   and (t1.performer is null or (t1.performer is not null and [dbo].[Ft_tsk_3_Accurace]( t4.lstNa, t1.performer, @precision )  >= @accuracy  )) -- performers
	) -- main check
	group by t1.regid, t1.regIItemId, t2.WIC

	)
	, result_data as 
	(
	select 
	row_number() over( partition by t1.regId,t1.regIItemId  order by t1.regId,t1.regIItemId, t1.sumAllTogether desc
		 ) as rowid,
	t1.regId, t1.regIItemId, t1.WIC , t1.accName, t1.accAuthor, t1.accAuthorText, t1.accPerformer, t1.sumAllTogether
	from data_tbl t1
	where accPerformer + accAuthorText + accAuthor  > 0 --and accName > 0
	)

	insert into @RT
	select
		 t1.regId
		,t1.regIItemId
		,t1.WIC
		,left(t2.name, 254) as objectName
		,left(t2.Authors, 254) as objectAuthors
		,left(t2.performers, 254) as objectPerformers
		,t1.sumAllTogether
	from result_data t1
		left join WID_IPI..wObject t2 on t2.WIC = t1.WIC
	where rowid = 1
	order by 1,2

   set @i1 = @i1 + @i2+1
 END

RETURN
END
--select * from ft_Tsk_3_AutoLink_WIDW (10) t1 join registerItem t2 on t1.regid = t2.regId and t1.regiItemId = t2.regIItemId 
--select * from WID_IPI..vtsk_3_OR_01_1

