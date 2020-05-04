CREATE FUNCTION [dbo].[ft_Tsk_3_Link_WIDW_V4]  ( @name varchar(100), @authors varchar(255) = NULL, @performer varchar(255) = NULL )
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
	declare  --@name1 varchar(200) = '"@name"' 
	         @name1 varchar(200) = isnull(REPLACE (@NAME,' ','|'),'|') 
	        ,@performer1 varchar(100) = isnull(REPLACE (@performer,' ','|'),'|') 
			,@authors1 varchar(200) = isnull(REPLACE (@authors,' ','|'),'|') ;

	with 
	data_tbl as 
	( 
	select 
	t2.WIC
	, max( [dbo].[Ft_tsk_3_Accurace_strong]( t2.altTtl, @name, @precision )) as accName
	, max( [dbo].[Ft_tsk_3_Accurace]( t4.LstNa+isnull(' '+t4.FstNa,''), @performer, @precision )) as accPerformer
	, max( [dbo].[Ft_tsk_3_Accurace]( t3.lstName+isnull(' '+t3.fstName,''), @authors, @precision )) as accAuthors
        , max( [dbo].[Ft_tsk_3_Accurace_strong]( t2.altTtl, @name, @precision )) + 
          max( [dbo].[Ft_tsk_3_Accurace]( t4.LstNa+isnull(' '+t4.FstNa,''), @performer, @precision )) + 
	      max( [dbo].[Ft_tsk_3_Accurace]( t3.lstName+isnull(' '+t3.fstName,''), @authors, @precision )) as sumAllTogether
     from 
       WID_IPI..TblAltTtl t2 
       left outer join WID_IPI..TblArtist t4 on t4.WIC = t2.WIC
       left outer join WID_IPI..wObjectAuthor t3 on t3.WIC = t2.WIC --and t3.roleCode <> 8 
  where 
    (( [dbo].[Ft_tsk_3_Accurace]( t2.AltTtl, @name, @precision  )  )>= @accuracy  
	   and CONTAINS(t2.AltTtl, @name1) )

	group by t2.WIC
	)

	insert into @RT 
	( WIC,iswc,name, performer,author,genre,sumAllTogether)
	select top 300
		 t1.WIC
		,t2.iswc 
		,left(t2.name, 254) as name
		,left(t2.performers, 254) as performer
		,left(t2.Authors, 254) as author
		,t2.genreName
		,t1.sumAllTogether*100/3
	from data_tbl t1
		 join WID_IPI..wObject t2 on t2.WIC = t1.WIC
	where sumAllTogether > 0 
	order by sumAllTogether desc

RETURN
END

--select * from ft_Tsk_3_Link_WIDW_V4 ('CINDY' , 'TERRI SALLI CC CLEMENTINA', NULL) where author like '%terri%' order by sumAlltogether desc
--select * from ft_Tsk_3_Link_WIDW_V4 ('HARK THE HERALD ANGELS', 'HARRIS KEVIN JAMES', 'PROLIFIC ARTS') order by sumAlltogether desc
--select * from WID_IPI..vtsk_3_OR_01_1 where wic=9
--select top 100 * from wid_ipi..wobject where wic = 9

/*
select top 100 * 
from wid_ipi..tblAltTtl t2 
where 
( [dbo].[Ft_tsk_3_Accurace]( t2.AltTtl, 'yori', 0.001 )  ) >0.3-- name
  and CONTAINS(t2.AltTtl, 'yori')
*/
