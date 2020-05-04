
CREATE FUNCTION [dbo].[ft_tsk_3_SearchObjWID_Do1105]  ( @name varchar(100), @authors varchar(255) = NULL, @performer varchar(255) = NULL )
--Лупа по внешней базе по базовым таблицам с витринами по КОНТЕКСТУ
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

	declare @accuracy float = 0.3, @precision float = 0.01;

    set @authors = CASE WHEN @authors = '' THEN NULL ELSE @authors END
    set @performer = CASE WHEN @performer = '' THEN NULL ELSE @performer END

	--declare @name varchar(200) = 'CINDY' , @performer varchar(100) = NULL, @authors varchar(200) = 'TERRI SALLI CC CLEMENTINA';
	declare  @name1 varchar(200) = ''+'"'+@name+'"'+'' 
	         --@name1 varchar(200) = isnull(REPLACE (@NAME,' ','|'),'|') 
	        ,@performer1 varchar(100) = isnull(REPLACE (@performer,' ','|'),'|') 
			,@authors1 varchar(200) = isnull(REPLACE (@authors,' ','|'),'|') ;

  declare @TmpWIC table
  (WIC integer not null primary key, accName float) 

  insert into @TmpWIC (WIC, accName)
   select t1.WIC, max([dbo].[Ft_tsk_3_Accurace]( t1.altttl, @name, @precision )) as accName
     from WID_IPI..TblAltTtl t1 
     --left join WID_IPI..TblArtist t2 on t1.WIC = t2.WIC 
	 --left join WID_IPI..wObjectAuthor t3 on t1.WIC = t3.WIC
   where CONTAINS(t1.AltTtl, @name1)  
        and ([dbo].[Ft_tsk_3_Accurace_strong]( t1.altttl, @name, @precision )) >=@accuracy
  group by t1.WIC 

 insert into @RT 
	( WIC, iswc, name, performer, author, genre, sumAllTogether)
  select t0.WIC, t0.ISWC, t0.name, t0.performers, t0.authors, t0.genreName, t10.accTotal*100/3
 from wid_ipi..wObject t0, 
 (
 select t1.WIC, 
 (max(t1.accName) +  
  max(([dbo].[Ft_tsk_3_Accurace]( t2.LstNa+isnull(' '+t2.fstNa,''), @performer, @precision )))  + --as accPerfomer,
  max(([dbo].[Ft_tsk_3_Accurace]( t3.lstName+isnull(' '+t3.fstName,''), @authors, @precision ))) ) --as accAuthor  
   as accTotal
   from @TmpWIC t1 
     left join WID_IPI..TblArtist t2 on t1.WIC = t2.WIC 
	 left join WID_IPI..wObjectAuthor t3 on t1.WIC = t3.WIC
--  where (@performer is NULL OR ([dbo].[Ft_tsk_3_Accurace]( t2.LstNa+isnull(' '+t2.fstNa,''), @performer, @precision )) >=@accuracy) 
--    or (@authors is NULL OR ([dbo].[Ft_tsk_3_Accurace]( t3.LstName+isnull(' '+t3.fstName,''), @authors, @precision )) >=@accuracy) 
  group by t1.WIC
 ) t10 
 where t0.WIC = t10.WIC 
 and  t10.accTotal > @accuracy and t10.accTotal>1
 --order by accTotal desc
  
RETURN
END
--select * from ft_tsk_3_SearchObjWID ('ABI GEZUNT KEN MEN' , NULL, 'DANIEL KEMPIN') order by sumAlltogether desc
