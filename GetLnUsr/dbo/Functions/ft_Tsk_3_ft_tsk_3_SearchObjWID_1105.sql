CREATE FUNCTION [dbo].[ft_Tsk_3_ft_tsk_3_SearchObjWID_1105]  (@name varchar(100), @authors varchar(255) = NULL, @performer varchar(255) = NULL)
--Поиск по ЛУПЕ по WID
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

 declare @accuracy float = 0.4, @precision float = 0.001;

   set @authors = CASE WHEN @authors = '' THEN NULL ELSE @authors END
   set @performer = CASE WHEN @performer = '' THEN NULL ELSE @performer END

	--declare @name varchar(200) = 'CINDY' , @performer varchar(100) = NULL, @authors varchar(200) = 'TERRI SALLI CC CLEMENTINA';
	declare  @name1 varchar(200) = ''+'"'+@name+'"'+'' 
	         --@name1 varchar(200) = isnull(REPLACE (@NAME,' ','|'),'|') 
	        ,@performer1 varchar(100) = isnull(REPLACE (@performer,' ','|'),'|') 
			,@authors1 varchar(200) = isnull(REPLACE (@authors,' ','|'),'|') ;

  declare @TmpObj table 
  (
	id integer not null identity, 
	WIC integer not null,
	name varchar(250) null,
  	accName float, 
	primary key (WIC, id) 
  )

   delete @TmpObj 
   insert into @TmpObj ( WIC, name,  accName)
    select t1.WIC, max(t1.AltTtl),  1 --max([dbo].[Ft_tsk_3_Accurace]( t2.AltTtl, t1.ItemName, @precision ))
	   from  WID_IPI..TblAltTtl t1 
	  where CONTAINS(t1.AltTtl, @name1)  
        and ([dbo].[Ft_tsk_3_Accurace_strong]( t1.altttl, @name, @precision )) >=@accuracy
  group by t1.WIC 


;	with 
	data_tbl as 
	( 
	select 
	t2.WIC
	, max( [dbo].[Ft_tsk_3_Accurace]( t2.name, @name1, @precision )) as accName
	, max( [dbo].[Ft_tsk_3_Accurace_strong]( t4.LstNa+' '+t4.FstNa, @performer1, @precision )) as accPerformer
	, max( [dbo].[Ft_tsk_3_Accurace_strong]( t3.lstName+' '+t3.fstName, @authors1, @precision )) as accAuthor
        , (max( [dbo].[Ft_tsk_3_Accurace]( t2.name, @name1, @precision )) + 
           max( [dbo].[Ft_tsk_3_Accurace_strong]( t4.LstNa+' '+t4.FstNa , @performer1, @precision )) + 
	       max( [dbo].[Ft_tsk_3_Accurace_strong]( t3.lstName+' '+t3.fstName, @authors1, @precision )) )  as sumAllTogether
     from 
       @TmpObj t2 
       left outer join WID_IPI..TblArtist t4 on t4.WIC = t2.WIC
       left outer join WID_IPI..wObjectAuthor t3 on t3.WIC = t2.WIC --and t3.roleCode <> 8 
   where 
	  (
	    ( (@authors1 is null or (@authors1 is not null and [dbo].[Ft_tsk_3_Accurace]( t3.lstName+' '+t3.fstName, @authors1, @precision ) >= @accuracy )) 
	    ) -- authors
 	   OR (@performer1 is null or (@performer1 is not null and [dbo].[Ft_tsk_3_Accurace]( t4.lstNa+' '+t4.FstNa, @performer1, @precision )  >= @accuracy  )) -- performers
	) -- main check
	group by t2.WIC

	)
	, result_data as 
	(
	select 
	row_number() over( partition by t1.sumAllTogether  order by t1.sumAllTogether desc
		 ) as rowid,
	t1.WIC , t1.accName, t1.accAuthor, t1.accPerformer, t1.sumAllTogether
	from data_tbl t1
	where accPerformer + accAuthor >= @accuracy
	)

 insert into @RT 
	( WIC, iswc, name, performer, author, genre, sumAllTogether)
  select t1.WIC, t2.ISWC, t2.name, t2.performers, t2.authors, t2.genreName, t1.sumAllTogether*100/3
	from result_data t1
		left join WID_IPI..wObject t2 on t2.WIC = t1.WIC
	order by 1,2

RETURN
END
--select * from ft_Tsk_3_ft_tsk_3_SearchObjWID_1105 ( 'ABI GEZUNT KEN MEN' , NULL, 'DANIEL KEMPIN')
--select * from WID_IPI..vtsk_3_OR_01_1
