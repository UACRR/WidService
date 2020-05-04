
create function  [dbo].[ft_tsk_3_SearchObjWID_1115]  ( @name varchar(254), @authors varchar(255) = NULL, @performer varchar(255) = NULL )
--Лупа по внешней базе по базовым таблицам с витринами по КОНТЕКСТУ
--коефф-т совпадения счтается в конце
RETURNS @RT TABLE
(	
	 objid integer null
	,WIC int null
    ,iswc varchar(20)  null --t1.innerCode, 
	,name varchar(254) null  --оригинальное название
	,performer varchar(254) null
	,author varchar(254) null
	,genre varchar(100) null
	,duration time null
	,sumAllTogether float null
	--,nameAlt varchar(254) null  --найденное название
)
AS
BEGIN


--declare @name varchar(200) = 'CINDY' , @performer varchar(100) = NULL, @authors varchar(200) = 'TERRI SALLI CC CLEMENTINA';
	declare @accuracy float = 0.3, @precision float = 0.01;

    set @authors = CASE WHEN @authors = '' THEN NULL ELSE @authors END
    set @performer = CASE WHEN @performer = '' THEN NULL ELSE @performer END
	set @name = ltrim(rtrim(@name))

    --Если есть скобки с 5-й позиции - убираю веcь текст, начиная со скобок - для поиска. Искать буду честно. 
	--!!! Еще нужно удалить для контекстного поиска автора и исполнителя одинокую букву !!! -- не сделано!

	declare  @name1 varchar(200), @performer1 varchar(100) = isnull(REPLACE (@performer,' ','|'),'|') 
			                    , @authors1 varchar(200) = isnull(REPLACE (@authors,' ','|'),'|') ;

	set @name1 = trim (substring (@name, 1, (Case WHEN patindex('%(%', @name) > 4 THEN patindex('%(%', @name)-1 ELSE 254 END )))
	set @name1  = ''+'"'+@name1+'"'+'' 
	         --@name1 varchar(200) = isnull(REPLACE (@NAME,' ','|'),'|') 
    
  declare @TmpWIC table
  (WIC integer not null primary key, accName float) 

  insert into @TmpWIC (WIC, accName)
   select t1.WIC, max([dbo].[Ft_tsk_3_Accurace]( t1.altttl, @name, @precision )) as accName 
     from WID_IPI..TblAltTtl t1 
   where CONTAINS(t1.AltTtl, @name1)  
        --and ([dbo].[Ft_tsk_3_Accurace_strong]( t1.altttl, @name, @precision )) >=@accuracy
  group by t1.WIC 

declare @TmpAuthor table 
( WIC integer not null, 
  id integer not null identity, 
  Author varchar(254), 
  accAuthor float, 
 primary key (WIC, id) )

declare @TmpPerformer table 
( WIC integer not null, 
  id integer not null identity, 
  Performer varchar(254), 
  accPerformer float, 
 primary key (WIC, id) )
 
 declare @TmpAccAuthors table 
( WIC integer not null, 
  accAuthors float, 
 primary key (WIC) )

declare @TmpAccPerformer table 
( WIC integer not null, 
  accPerformer float, 
 primary key (WIC) )

insert into @TmpAuthor (WIC, Author, accAuthor)
 select t1.WIC, t2.lstName + ' '+t2.fstName, 
   @accuracy --1--dbo.[Ft_tsk_3_Accurace]( t2.lstName+isnull(' '+t2.fstName,''), @authors, @precision ) 
   from @TmpWIC t1 
    join WID_IPI..wObjectAuthor t2 on t1.WIC = t2.WIC 
  where CONTAINS((t2.lstName,t2.fstName), @authors1) 

insert into @TmpPerformer (WIC, Performer, accPerformer)
 select t1.WIC, t2.lstNa + ' '+t2.fstNa, 
   @accuracy --1--dbo.[Ft_tsk_3_Accurace]( t2.lstNa+isnull(' '+t2.fstNa,''), @performer, @precision ) 
   from @TmpWIC t1 
    join WID_IPI..TblArtist t2 on t1.WIC = t2.WIC 
  where CONTAINS((t2.lstNa, t2.FstNa), @performer1) 

--ПРосчитываю коеффициент по авторам с учетом сплита параметра
;with TabValue as 
(
select t1.WIC, max(forAdd) as forAdd, 
        max(isnull(t1.accAuthor,0)) + max(dbo.[Ft_tsk_3_Accurace](  t2.value, t1.Author, @precision )) as accAuthor
 from @TmpAuthor t1 
 cross apply ( SELECT 1 as forAdd, value FROM STRING_SPLIT(@authors, ' ')) as t2 
 where dbo.[Ft_tsk_3_Accurace]( t2.value, t1.Author, @precision ) >0.75 --and WIC = 17577140
 group by t1.WIC, value 
 ) 
insert into @TmpAccAuthors (WIC, accAuthors)
select WIC, sum(forAdd) * max(accAuthor) as accAuthor
 from TabValue 
 group by WIC 

--ПРосчитываю коеффициент по исполнителям с учетом сплита параметра
;with TabValue as 
(
select t1.WIC, max(forAdd) as forAdd, 
        max(isnull(t1.accPerformer,0))+max(dbo.[Ft_tsk_3_Accurace](  t2.value, t1.Performer, @precision )) as accAuthor
 from @TmpPerformer t1 
 cross apply ( SELECT 1 as forAdd, value FROM STRING_SPLIT(@performer, ' ')) as t2 
 where dbo.[Ft_tsk_3_Accurace]( t2.value, t1.Performer, @precision ) >0.75 --and WIC = 17577140
 group by t1.WIC, value 
 ) 
insert into @TmpAccPerformer (WIC, accPerformer)
select WIC, sum(forAdd) * max(accAuthor) as accPerformer
 from TabValue 
 group by WIC 

;with TabSum as 
 (select  t1.WIC, max(accName) as accName, 
  + max(isnull(t2.accAuthors,0) + isnull(t3.accPerformer,0)) as accTotal
   from @TmpWIC t1 
     left join @TmpAccAuthors t2 on t1.WIC = t2.WIC 
	 left join @TmpAccPerformer t3 on t1.WIC = t3.WIC
  group by t1.WIC
  )
insert into @RT 
( WIC, iswc, name, performer, author, genre, sumAllTogether)
  select t0.WIC, t0.ISWC, t0.name, t0.performers, t0.authors, t0.genreName, (t1.accName+isnull(t1.accTotal,0)) as accTotal --*100/3
 from TabSum t1
      join wid_ipi..wObject t0 on t0.WIC = t1.WIC
 where  t1.accName + t1.accTotal > @accuracy*2  --коефф 2 подобран
 --where  t1.accName > @accuracy and t1.accTotal > @accuracy  
 	
RETURN
END
--select * from ft_tsk_3_SearchObjWID_1115 ('CINDY' , 'MICHAEL FARLEY', 'mike') order by sumAlltogether desc  --2013635
--select * from ft_tsk_3_SearchObjWID_1115 ('friends' , '', '5') order by sumAlltogether desc --where wic = 2516966


