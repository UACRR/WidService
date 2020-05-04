/****** Object:  UserDefinedFunction [dbo].[ft_Tsk_3_AutoLink_WID]    Script Date: 25.07.2019 3:49:28 ******/

CREATE procedure  [dbo].[p_Tsk_3_AutoLink_WIDW_Cursor]  @regId int 
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
)

create table #data_tbl(
	regId int
	,regIItemId int
	,WIC		int
	,accName	float
	,accPerformer float
	,accAuthorText float
	,accAuthor		float
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

/*

insert into #data_tbl 
( regId, regIItemId, WIC, accName, accPerformer, accAuthorText, accAuthor, sumAllTogether) 
select  regId, regIItemId, WIC, accName, accPerformer, accAuthorText, accAuthor, sumAllTogether 

  declare cur cursor for   select   regIItemId,KindCode,ObjId,AccCredit,AccDebet,ItemName,custId from #data_tbl                                 
    declare     @regIItemId		integer
	declare		@KindCode		int                                            
    declare     @ObjId         integer
	declare     @AccCredit		varchar(14)
    declare     @AccDebet		varchar(14)
	declare		@AccID		integer
	declare		@KindCodeCH  varchar(2)  
	declare		@AccName	varchar(30)                                          
	declare		@ItemName		varchar(100)
	declare		@custid1		int
	declare @custname varchar(100)
    open cur                                                   
    fetch cur into  @regIItemId,@KindCode,@ObjId,@AccCredit,@AccDebet,@ItemName,@custid1
                                                   
    while @@fetch_status =0                                                   
	    BEGIN 



   	fetch cur into  @regIItemId,@KindCode,@ObjId,@AccCredit,@AccDebet,@ItemName,@custid1
END                                                   
close cur   
deallocate cur     
*/

/*
declare @i1 integer = 0, @i2 integer = 100, @iN integer = 0
set @i1 = (select min(regIItemId) from RegisterItem where regId = @regId and isnull(objid,0)+isnull(WIC,0) = 0)
set @iN = (select max(regIItemId) from RegisterItem where regId = @regId and isnull(objid,0)+isnull(WIC,0) = 0)

 WHILE @i1 < @iN
 BEGIN 
*/
 delete #data_tbl 

insert  #data_tbl(regId,regIItemId,WIC,accName,accPerformer,accAuthorText,accAuthor,sumAllTogether)
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
       join WID_IPI..wSeekObject t2 on left(REPLACE(t1.ItemName,' ',''),3) = t2.nameIdx 
       left outer join WID_IPI..wSeekPerformer t4 on t4.WIC = t2.WIC
       left outer join WID_IPI..wObjectAuthor t3 on t3.WIC = t2.WIC and t3.roleCode <> 8 
   where regId = @regid  --and t1.regIItemId between @i1 and @i1+@i2 --and t1.regIItemId in ( 1,2,3,4,5,6,7,8,9,10)  --для теста
	and t1.objId is null 
	and t1.WIC is null
	and ( [dbo].[Ft_tsk_3_Accurace]( t2.name, t1.ItemName, @precision ) >= @accuracy ) -- name
	and (
	    ( (t1.authorText is null or (t1.authorText is not null and [dbo].[Ft_tsk_3_Accurace]( t3.lstName, t1.authorText, @precision ) >= @accuracy )) 
	    and (t1.authorMusic is null or (t1.authorMusic is not null and [dbo].[Ft_tsk_3_Accurace]( t3.lstName, t1.authorMusic, @precision ) >= @accuracy ))	
	    ) -- authors
 	   and (t1.performer is null or (t1.performer is not null and [dbo].[Ft_tsk_3_Accurace]( t4.lstNa, t1.performer, @precision )  >= @accuracy  )) -- performers
	) -- main check
	group by t1.regid, t1.regIItemId, t2.WIC


/*
	from 
	( select regId, regIItemId, objid, WIC 
	   , trim(ItemName) as ItemName 
	   , case when trim(performer) = '' then null else trim(performer) end performer
	   , case when trim(authorText) = '' then null else trim(authorText) end authorText
	   , case when trim(authorMusic) = '' then null else trim(authorMusic) end authorMusic
	   from  RegisterItem  
	   where regId =@regId) t1
	join  
	(select t2.wic, t2.ttl as name, t3.LstNa+' '+t3.FstNa as performer, t4.IntrPtyRol as rhRole, t5.name +' '+t5.FST_NAME as author
      from 
   ( select WIC, Ttl from WID_IPI..TblTitle
			union 
           select WIC, AltTtl from WID_IPI..TblAltTtl) t2 
    left outer join WID_IPI..TblArtist t3 on t3.WIC = t2.WIC
	left outer join WID_IPI..TblIntrPty t4 on t4.WIC = t3.WIC
	left outer join WID_IPI..TBLIPINAME t5 on t5.IP_NAME_NR = t4.IPINr
       where t4.IntrPtyRol not in ('E') ) t2  on left(t1.ItemName,3) = left(t2.name,3)  --исключаю из авторов издателей
    where
	t1.regid = @regId --and t1.regIItemId in ( 1,2,3,4,5,6,7,8,9,10)  --для теста
	and t1.objId is null 
	and t1.WIC is null
	and ( [dbo].[Ft_tsk_3_Accurace]( t2.name, t1.ItemName, @precision ) >= @accuracy ) -- name
	and (
	    ( (t1.authorText is null or (t1.authorText is not null and [dbo].[Ft_tsk_3_Accurace]( t2.author, t1.authorText, @precision ) >= @accuracy )) 
	    and (t1.authorMusic is null or (t1.authorMusic is not null and [dbo].[Ft_tsk_3_Accurace]( t2.author, t1.authorMusic, @precision ) >= @accuracy ))	
	    ) -- authors
 	   and (t1.performer is null or (t1.performer is not null and [dbo].[Ft_tsk_3_Accurace]( t2.performer, t1.performer, @precision )  >= @accuracy  )) -- performers
	) -- main check
	group by t1.regid, t1.regIItemId, t2.WIC
*/	
	delete #result_data 

	insert  #result_data 
	select 
	row_number() over( partition by t1.regId,t1.regIItemId  order by t1.regId,t1.regIItemId, t1.sumAllTogether desc
		 ) as rowid,
	t1.regId, t1.regIItemId, t1.WIC , --t1.accName, t1.accAuthor, t1.accAuthorText, t1.accPerformer, 
	t1.sumAllTogether
	from #data_tbl t1
	where accPerformer + accAuthorText + accAuthor  > 0
	

	insert into #RT
	select
		 t1.regId
		,t1.regIItemId
		,t1.WIC
		,left(t2.namem, 254) as objectName
		,left(t2.Authors, 254) as objectAuthors
		,left(t2.performer, 254) as objectPerformers
		,t1.sumAllTogether
	from #result_data t1
		left join WID_IPI..vtsk_3_OR_01 t2 on t2.WIC = t1.WIC
	where rowid = 1
	order by 1,2
--	set @i1 = @i1 + @i2+1
--END
	select * from #RT

END

--exec p_Tsk_3_AutoLink_WIDW_Cursor 3361
