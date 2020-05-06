CREATE FUNCTION [dbo].[ft_Tsk_3_Link_WIDW_V1]  ( @name varchar(100), @authors varchar(255) = NULL, @performer varchar(255) = NULL )
--Автопривязка по внешней базе с витринами
--Версия 3 улучшенная c шагом
RETURNS @RT TABLE
(	
	 objid integer null
	,WIC int null
    ,iswc varchar(20)  null --t1.innerCode, 
	,name varchar(254) null
	,performer varchar(254) null
	,author varchar(254) null
	,genre varchar(100) null
	,duration time null
	,sumAllTogether float null
)
AS
BEGIN

	declare @accuracy float = 0.3, @precision float = 0.001;
	--declare @name varchar(200) = 'CINDY' , @performer varchar(100) = NULL, @authors varchar(200) = 'TERRI SALLI CC CLEMENTINA';

	with 
	data_tbl as 
	( 
	select 
	t2.WIC
	, max( [dbo].[Ft_tsk_3_Accurace]( t2.name, @name, @precision )) as accName
	, max( [dbo].[Ft_tsk_3_Accurace]( t4.LstNa, @performer, @precision )) as accPerformer
	, max( [dbo].[Ft_tsk_3_Accurace]( t3.lstName, @authors, @precision )) as accAuthors
        , max( [dbo].[Ft_tsk_3_Accurace]( t2.name, @name, @precision )) + 
          max( [dbo].[Ft_tsk_3_Accurace]( t4.LstNa, @performer, @precision )) + 
	      max( [dbo].[Ft_tsk_3_Accurace]( t3.lstName, @authors, @precision )) as sumAllTogether
     from 
       WID_IPI..wSeekObject t2 
       left outer join WID_IPI..wSeekPerformer t4 on t4.WIC = t2.WIC
       left outer join WID_IPI..wObjectAuthor t3 on t3.WIC = t2.WIC and t3.roleCode <> 8 
   where left(REPLACE(@name,' ',''),3) = t2.nameIdx  
	and ( [dbo].[Ft_tsk_3_Accurace]( t2.name, @name, @precision ) >= @accuracy ) -- name
	and ( @authors is null or (@authors is not null and [dbo].[Ft_tsk_3_Accurace]( t3.lstName+isnull(' '+t3.FstName,''), @authors, @precision ) >= @accuracy )) -- authors
    and	( @performer is null or (@performer is not null and [dbo].[Ft_tsk_3_Accurace]( isnull(t4.lstNa+isnull(' '+t4.FstNa,''),@performer), @performer, @precision )  >= @accuracy  ) ) -- performers
	 -- main check
	group by t2.WIC
	)
	, result_data as 
	(
	select 
	row_number() over( partition by 1  order by t1.sumAllTogether desc
		 ) as rowid,
	t1.WIC , t1.accName, t1.accAuthors, t1.accPerformer, t1.sumAllTogether
	from data_tbl t1
	where accPerformer + accAuthors  > 0 --and accName > 0
	)

	insert into @RT 
	( WIC,iswc,name, performer,author,genre,sumAllTogether)
	select
		 t1.WIC
		,t2.iswc 
		,left(t2.name, 254) as name
		,left(t2.performers, 254) as performer
		,left(t2.Authors, 254) as author
		,t2.genreName
		,t1.sumAllTogether
	from result_data t1
		left join WID_IPI..wObject t2 on t2.WIC = t1.WIC
	--where rowid = 1
	order by 1,2

RETURN
END
--select * from ft_Tsk_3_Link_WIDW ('CINDY' , 'TERRI SALLI CC CLEMENTINA', NULL) 
--select * from ft_Tsk_3_Link_WIDW ('HARK THE HERALD ANGELS', 'DAVID BRUCE', NULL) 

--    t1 join registerItem t2 on t1.regid = t2.regId and t1.regiItemId = t2.regIItemId 
--select * from WID_IPI..vtsk_3_OR_01_1 where wic=9
--select top 100 * from wid_ipi..wobject where wic = 9
