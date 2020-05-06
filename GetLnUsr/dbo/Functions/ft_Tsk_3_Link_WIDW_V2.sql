CREATE FUNCTION [dbo].[ft_Tsk_3_Link_WIDW_V2]  ( @name varchar(100), @authors varchar(255) = NULL, @performer varchar(255) = NULL )
--Лупа по внешней базе по базовім таблицам с витринами по КОНТЕКСТУ
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
	declare @name1 varchar(200) = isnull(REPLACE (@NAME,' ','|'),'|'), 
	        @performer1 varchar(100) = isnull(REPLACE (@performer,' ','|'),'|'), 
			@authors1 varchar(200) = isnull(REPLACE (@authors,' ','|'),'|') ;

	with 
	data_tbl as 
	( 
	select 
	t2.WIC
	, max( [dbo].[Ft_tsk_3_Accurace_strong]( t2.altTtl, @name, @precision )) as accName
	, max( [dbo].[Ft_tsk_3_Accurace_strong]( t4.LstNa+isnull(' '+t4.FstNa,''), @performer, @precision )) as accPerformer
	, max( [dbo].[Ft_tsk_3_Accurace_strong]( t3.lstName+isnull(' '+t3.fstName,''), @authors, @precision )) as accAuthors
        , max( [dbo].[Ft_tsk_3_Accurace_strong]( t2.altTtl, @name, @precision )) + 
          max( [dbo].[Ft_tsk_3_Accurace_strong]( t4.LstNa+isnull(' '+t4.FstNa,''), @performer, @precision )) + 
	      max( [dbo].[Ft_tsk_3_Accurace_strong]( t3.lstName+isnull(' '+t3.fstName,''), @authors, @precision )) as sumAllTogether
     from 
       WID_IPI..TblAltTtl t2 
       left outer join WID_IPI..TblArtist t4 on t4.WIC = t2.WIC
       left outer join WID_IPI..wObjectAuthor t3 on t3.WIC = t2.WIC and t3.roleCode <> 8 
  where 
    (( [dbo].[Ft_tsk_3_Accurace]( t2.AltTtl, @name, @precision  )  )>= @accuracy  
	   and CONTAINS(t2.AltTtl, @name1) )

and ( @authors is null or 
    ( (@authors is not null and [dbo].[Ft_tsk_3_Accurace]( t3.lstName+isnull(' '+t3.FstName,''), @authors, @precision ) >= @accuracy ) 
	   and ( CONTAINS((t3.lstName, t3.fstName), @authors1) OR (t3.lstName is NULL))
	 )  -- authors
or	( @performer is null 
     or ( ( (@performer is not null and [dbo].[Ft_tsk_3_Accurace]( isnull(t4.lstNa+isnull(' '+t4.FstNa,''),@performer), @performer, @precision )  >= @accuracy  ) ) -- performers
	  and ( CONTAINS((t4.lstNa,t4.FstNa), @performer1) OR (t4.lstNa is NULL))
	 ) ) )-- main check
	 
	group by t2.WIC
	)
	, result_data as 
	(
	select 
	row_number() over( partition by 1  order by t1.sumAllTogether desc
		 ) as rowid,
	t1.WIC , t1.accName, t1.accAuthors, t1.accPerformer, t1.sumAllTogether
	from data_tbl t1
	where accPerformer + accAuthors + accName > 0 
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
	order by 7,1

RETURN
END
--select * from ft_Tsk_3_Link_WIDW_V2 ('CINDY' , 'TERRI SALLI CC CLEMENTINA', NULL) order by sumAlltogether desc
--select * from ft_Tsk_3_Link_WIDW_V2 ('HARK THE HERALD ANGELS', NULL, NULL) order by sumAlltogether desc
--t1 join registerItem t2 on t1.regid = t2.regId and t1.regiItemId = t2.regIItemId 
--select * from WID_IPI..vtsk_3_OR_01_1 where wic=9
--select top 100 * from wid_ipi..wobject where wic = 9
/*
select count(*) 
from wid_ipi..tblAltTtl t2 
where 
( [dbo].[Ft_tsk_3_Accurace]( t2.AltTtl, 'angel', 0.001 )  ) >0.3-- name
  and CONTAINS(t2.AltTtl, 'angel')
*/
