CREATE procedure [dbo].[Ptsk_3_SearchObjWID_V4]   @name varchar(100), @authors varchar(255) = NULL, @performer varchar(255) = NULL 
--Лупа по внешней базе по базовым таблицам с витринами по КОНТЕКСТУ
as BEGIN 

declare @RetCode integer = 0

create table #RT 
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
create table #TmpWIC 
 (WIC integer not null primary key, 
  accName float) 

create table #TmpAcc 
(WIC integer not NULL primary key, 
 accName float, 
 accPerfomer float, 
 accAuthor float
 )

delete #TmpAcc 
delete #TmpWIC 
delete #RT 

   --declare @name varchar(200) = 'CINDY' , @performer varchar(100) = NULL, @authors varchar(200) = 'TERRI SALLI CC CLEMENTINA';
   --declare @name varchar(200) = 'YELLOW ROSE OF TEXAS' , @performer varchar(100) = NULL, @authors varchar(200) = 'SHAIMAN MARC';
 
	declare @accuracy float = 0.3, @precision float = 0.001;

    set @authors = CASE WHEN @authors = '' THEN NULL ELSE @authors END
    set @performer = CASE WHEN @performer = '' THEN NULL ELSE @performer END


	declare  @name1 varchar(200) = ''+'"'+@name+'"'+'' 
	         --@name1 varchar(200) = isnull(REPLACE (@NAME,' ','|'),'|') 
	        ,@performer1 varchar(100) = isnull(REPLACE (@performer,' ','|'),'|') 
			,@authors1 varchar(200) = isnull(REPLACE (@authors,' ','|'),'|') ;

  insert into #TmpWIC (WIC, accName)
   select t1.WIC, max([dbo].[Ft_tsk_3_Accurace]( t1.altttl, @name, @precision )) as accName
     from WID_IPI..TblAltTtl t1 
   where CONTAINS(t1.AltTtl, @name1)  
        and ([dbo].[Ft_tsk_3_Accurace_strong]( t1.altttl, @name, @precision )) >=@accuracy
  group by t1.WIC 
  
 insert into #TmpAcc (WIC, accName, accPerfomer, accAuthor)
 select t1.WIC
 , max(t1.accName)
 , max(([dbo].[Ft_tsk_3_Accurace]( t2.LstNa+isnull(' '+t2.fstNa,''), @performer, @precision )))   --as accPerfomer,
 , max(([dbo].[Ft_tsk_3_Accurace]( t3.lstName+isnull(' '+t3.fstName,''), @authors, @precision ))) --as accAuthor  
   from #TmpWIC t1 
     left join WID_IPI..TblArtist t2 on t1.WIC = t2.WIC 
	 left join WID_IPI..wObjectAuthor t3 on t1.WIC = t3.WIC
  where --(@performer is NULL OR ([dbo].[Ft_tsk_3_Accurace]( t2.LstNa+isnull(' '+t2.fstNa,''), @performer, @precision )) >=@accuracy) 
        --and (@authors is NULL OR ([dbo].[Ft_tsk_3_Accurace]( t3.LstName+isnull(' '+t3.fstName,''), @authors, @precision )) >=@accuracy) 
   (CASE WHEN @performer is NULL THEN 0 ELSE ([dbo].[Ft_tsk_3_Accurace]( t2.LstNa+isnull(' '+t2.fstNa,''), @performer, @precision )) END) 
   + (CASE WHEN @authors is NULL THEN 0 ELSE ([dbo].[Ft_tsk_3_Accurace]( t3.LstName+isnull(' '+t3.fstName,''), @authors, @precision )) END ) > @accuracy 
    group by t1.WIC

  insert into #RT 
	( WIC, iswc, name, performer, author, genre, sumAllTogether)
  select t0.WIC, t0.ISWC, t0.name, t0.performers, t0.authors, t0.genreName, (t2.accName+t2.accAuthor+t2.accPerfomer)*100/3
 from wid_ipi..wObject t0
    join #TmpAcc t2 on t2.WIC = t0.WIC
 --where t2.accName+t2.accAuthor+t2.accPerfomer > @accuracy 
 --order by accTotal desc

  select * from #RT order by sumAllTogether desc

RETURN 0
END

--exec Ptsk_3_SearchObjWID_V4 'YELLOW ROSE OF TEXAS' , 'SHAIMAN MARC', NULL
