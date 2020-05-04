
CREATE function  [dbo].[ft_tsk_3_SearchObjWID_1114]  ( @name varchar(254), @authors varchar(255) = NULL, @performer varchar(255) = NULL )
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
   select t1.WIC, @accuracy + max([dbo].[Ft_tsk_3_Accurace]( t1.altttl, @name, @precision )) as accName 
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
 
insert into @TmpAuthor (WIC, Author, accAuthor)
 select t1.WIC, t2.lstName + ' '+t2.fstName, 
   @accuracy --1--dbo.[Ft_tsk_3_Accurace]( t2.lstName+isnull(' '+t2.fstName,''), @authors, @precision ) 
   from @TmpWIC t1 
    join WID_IPI..wObjectAuthor t2 on t1.WIC = t2.WIC 
  where CONTAINS((t2.lstName,t2.fstName), @authors1) 

--select * from @TmpAuthor

insert into @TmpPerformer (WIC, Performer, accPerformer)
 select t1.WIC, t2.lstNa + ' '+t2.fstNa, 
   @accuracy --1--dbo.[Ft_tsk_3_Accurace]( t2.lstNa+isnull(' '+t2.fstNa,''), @performer, @precision ) 
   from @TmpWIC t1 
    join WID_IPI..TblArtist t2 on t1.WIC = t2.WIC 
  where CONTAINS((t2.lstNa, t2.FstNa), @performer1) 

/*
;with TabSum as 
 (select  t1.WIC, max(isnull(t1.accName,0)) as accName, --max(t2.AccAuthor) as accAuthor, max(t3.accPerformer) as accPerformer
  max(isnull(t2.AccAuthor,0)) + max(isnull(t3.accPerformer,0)) as accTotal
   from @TmpWIC t1 
     left join @TmpAuthor t2 on t1.WIC = t2.WIC 
	 left join @TmpPerformer t3 on t1.WIC = t3.WIC
  group by t1.WIC
  )
*/
;with TabSum as 
 (select  t1.WIC, max(accName) as accName, 
  +sum(isnull([dbo].[Ft_tsk_3_Accurace]( isnull(t2.Author,''), @authors, @precision ),0)) + max(isnull(t2.accAuthor,0))  --as accAuthor 
  +sum(isnull([dbo].[Ft_tsk_3_Accurace]( isnull(t3.Performer,''), @performer, @precision ),0)) + max(isnull(t3.accPerformer,0)) --as accPerformer 
   as accTotal
   from @TmpWIC t1 
     left join @TmpAuthor t2 on t1.WIC = t2.WIC 
	 left join @TmpPerformer t3 on t1.WIC = t3.WIC
  group by t1.WIC
  )
insert into @RT 
( WIC, iswc, name, performer, author, genre, sumAllTogether)
  select t0.WIC, t0.ISWC, t0.name, t0.performers, t0.authors, t0.genreName, (t1.accName+isnull(t1.accTotal,0)) as accTotal --*100/3
 from TabSum t1
      join wid_ipi..wObject t0 on t0.WIC = t1.WIC
 where  t1.accName + t1.accTotal > @accuracy*2
 

RETURN
END
--select * from ft_tsk_3_SearchObjWID_1114 ('CINDY' , 'MICHAEL FARLEY', 'mike') order by sumAlltogether desc  --2013635
--select * from ft_tsk_3_SearchObjWID_1114 ('friends' , 'VANZ JOEL', '') order by sumAlltogether desc
