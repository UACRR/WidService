/****** Object:  UserDefinedFunction [dbo].[ft_Tsk_3_AutoLink_WID]    Script Date: 25.07.2019 3:49:28 ******/

CREATE procedure  [dbo].[p_Tsk_3_AutoLink_WIDW_1031]  @regId int 
as
--Версия с курсором по контекстному поиску
begin
create  TABLE #RT
(	
	regId int
	,regIItemId int
	,WIC int
	,objectName varchar(254) null
	,objectAuthors varchar(254) null
	,objectPerformers varchar(254) null
	,sumAllTogether float
	, ItemName varchar(100)
	, performer varchar(100)
	, authorMusic varchar(100)
	, authorText varchar(100)
)

--drop table #data_tbl
create table #data_tbl(
	regId int
	,regIItemId int
	,WIC		int
	,accName	float
	,accPerformer float
	,accAuthorText float
	,accAuthorMusic		float
	,sumAllTogether float
primary key (wic, regId, regIItemId)
)


-- drop table #result_data
create table #result_data(
	rowid		int
	,regId		int
	,regIItemId int
	,WIC		int
	,sumAllTogether float
primary key (wic, regId, regIItemId, rowId)
)

declare @accuracy float = 0.4, @precision float = 0.001 ;--, @regId int = 3361;

 create table #TmpRegisterItem 
 ( regId integer not null, 
   regIItemId integer not null, 
   ItemName varchar(100), 
   performer varchar(100), 
   authorMusic varchar(100), 
   authorText varchar(100), 
   primary key (regId, regIItemId) 
 )

  insert into #TmpRegisterItem (regId, regIItemId, ItemName, performer, authorMusic, authorText)
  select 
	    regId, regIItemId
	   ,trim(ItemName) as ItemName 
	   , case when trim(performer) = '' then null else rtrim(trim(performer)) end performer
	   , case when trim(authorText) = '' then null else rtrim(trim(authorText)) end authorText
	   , case when trim(authorMusic) = '' then null else rtrim(trim(authorMusic)) end authorMusic
	   from  RegisterItem  t1 
	where regId = @regId 

delete #data_tbl
--Отбираю по названиям ОП
--declare @accuracy float = 0.75, @precision float = 0.001 ;--, @regId int = 3361;
insert  #data_tbl (regId, regIItemId, WIC, accName)
	select 
	  t1.regId
	, t1.regIItemId 
	, t2.WIC
	, max([dbo].[Ft_tsk_3_Accurace]( t2.altttl, t1.ItemName, @precision )) as accName
	--, t1.ItemName
	--, t2.name
   from #TmpRegisterItem t1 
     join WID_IPI..TblAltTtl t2 on left(t1.ItemName,3) = left(t2.altttl,3)
        and ( [dbo].[Ft_tsk_3_Accurace_strong]( t2.altttl, t1.ItemName, @precision ) >= @accuracy ) -- name
     group by t1.regId, t1.regIItemId, t2.WIC

--Собрать максимальные коеффициенты 
;with TmpMax as 
(select t1.regId, t1.regIItemId, max(accName) as accName
  from #data_tbl t1 
  group by t1.regId, t1.regIItemId)
 delete #data_tbl 
    from #data_tbl t1 
	    ,TmpMax t2 
   where t1.regId = t2.regId and t1.regIItemId = t2.regIItemId and t1.accName <> t2.accName

--Определить коефф-ты авторов и исполнителей
--Исполнитель
--declare @accuracy float = 0.75, @precision float = 0.001 ;--, @regId int = 3361;
;with tabAccPerf as 
(
  select t1.regId, t1.regIItemId, t2.WIC, max([dbo].[Ft_tsk_3_Accurace]( t1.performer, t3.LstNa+' '+t3.FstNa, @precision )) as accPerformer
      from #TmpRegisterItem t1 
	    join #data_tbl t2 on t1.regId = t2.regId and t1.regIItemId = t2.regIItemId
	    join WID_IPI..TblArtist t3 on t2.WIC = t3.WIC
	 group by t1.regId, t1.regIItemId, t2.WIC
)
   Update #data_tbl set accPerformer = t2.accPerformer
      from #data_tbl t1
	    join tabAccPerf t2 on t1.regId = t2.regId and t1.regIItemId = t2.regIItemId and t1.wic = t2.wic

--declare @accuracy float = 0.75, @precision float = 0.001 ;--, @regId int = 3361;
--Автор текста
;with tabAccPerf as 
(
  select t1.regId, t1.regIItemId, t2.WIC, max([dbo].[Ft_tsk_3_Accurace]( t1.authorText, t3.lstName+' '+t3.fstName, @precision )) as acc
      from #TmpRegisterItem t1 
	    join #data_tbl t2 on t1.regId = t2.regId and t1.regIItemId = t2.regIItemId
	    join WID_IPI..wObjectAuthor t3 on t2.WIC = t3.WIC
	 where t1.authorText <> ''
	 group by t1.regId, t1.regIItemId, t2.WIC
)
   Update #data_tbl set accAuthorText = t2.acc
      from #data_tbl t1
	    join tabAccPerf t2 on t1.regId = t2.regId and t1.regIItemId = t2.regIItemId and t1.wic = t2.wic

--declare @accuracy float = 0.75, @precision float = 0.001 ;--, @regId int = 3361;
--Автор Музыки
;with tabAcc as 
(
  select t1.regId, t1.regIItemId, t2.WIC, max([dbo].[Ft_tsk_3_Accurace]( t1.authorMusic, t3.lstName+' '+t3.fstName, @precision )) as acc
      from #TmpRegisterItem t1 
	    join #data_tbl t2 on t1.regId = t2.regId and t1.regIItemId = t2.regIItemId
	    join WID_IPI..wObjectAuthor t3 on t2.WIC = t3.WIC
	 where t1.authorMusic <> ''
	 group by t1.regId, t1.regIItemId, t2.WIC
)
   Update #data_tbl set accAuthorMusic = t2.acc
      from #data_tbl t1
	    join tabAcc t2 on t1.regId = t2.regId and t1.regIItemId = t2.regIItemId and t1.wic = t2.wic

--Считаю общий коефф-т
  update #data_tbl set sumAllTogether  = accName + dbo.fs_MaxValue( dbo.fs_MaxValue( isnull(accPerformer,0), isnull(accAuthorMusic,0)) , isnull(accAuthorText,0)) 

--Выбрать максимальные результаты коеффициентов совпадения
	delete #result_data 

	insert  #result_data (rowid,regId,regIItemId,WIC,sumAllTogether)
	select 
	row_number() over( partition by t1.regId,t1.regIItemId  order by t1.regId,t1.regIItemId, t1.sumAllTogether desc
		 ) as rowid,
	t1.regId, t1.regIItemId, t1.WIC , sumAllTogether as accAuthor
	from #data_tbl t1
	where t1.sumAllTogether > 1

	insert into #RT 
	(regId, regIItemId, WIC, objectName, objectAuthors, objectPerformers, sumAllTogether, ItemName, performer, authorMusic, authorText)
	select
		 t1.regId
		,t1.regIItemId
		,t1.WIC
		,left(t2.name, 254) as objectName
		,left(t2.Authors, 254) as objectAuthors
		,left(t2.performers, 254) as objectPerformers
		,t1.sumAllTogether
		, t3.ItemName
		, t3.performer
		, t3.authorMusic
		, t3.authorText
	from #result_data t1
		left join WID_IPI..wObject t2 on t2.WIC = t1.WIC
		join #TmpRegisterItem t3 on t1.regId = t3.regId and t1.regIItemId = t3.regIItemId
	where rowid = 1
	
	select * from #RT  
	 order by 1,2

END

--exec p_Tsk_3_AutoLink_WIDW_1031 3361
