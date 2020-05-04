create FUNCTION [dbo].[ft_Tsk_3_AutoLink_WIDW_1101]  (@regId int )
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
--declare @regId integer = 1279

  declare @TmpObj table 
  (
	id integer not null identity, 
	regId integer,
	regIItemId integer, 
	WIC integer not null,
	name varchar(250) null,
  	accName float, 
	primary key (WIC, id) 
  )
  --create index tmp1 on @tmpObj (regId, regIItemId)

   delete @TmpObj 
   insert into @TmpObj (regId, regIItemId, WIC,name,  accName)
    select t1.regId, t1.regIItemId, t2.WIC, max(t2.AltTtl),  max([dbo].[Ft_tsk_3_Accurace]( t2.AltTtl, t1.ItemName, @precision ))
	   from  RegisterItem  t1
       join WID_IPI..TblAltTtl t2 on ItemName = t2.AltTtl
    where  regId = @regId 
       and [dbo].[Ft_tsk_3_Accurace]( t2.AltTtl, t1.ItemName, @precision ) > @accuracy
    group by t1.regId, t1.regIItemId, t2.WIC ;


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
       join  @TmpObj t2 on t1.regId = t2.regId and t1.regIItemId = t2.regIItemId
       left outer join WID_IPI..TblArtist t4 on t4.WIC = t2.WIC
       left outer join WID_IPI..wObjectAuthor t3 on t3.WIC = t2.WIC and t3.roleCode <> 8 
   where t1.regId = @regid  --and t1.regIItemId in ( 1,2,3,4,5,6,7,8,9,10)  --для теста
	and t1.objId is null 
	and t1.WIC is null
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

RETURN
END
--select * from ft_Tsk_3_AutoLink_WIDW_1101 (1279) t1 join registerItem t2 on t1.regid = t2.regId and t1.regiItemId = t2.regIItemId 
--select * from WID_IPI..vtsk_3_OR_01_1

